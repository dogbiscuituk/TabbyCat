namespace TabbyCat.Controllers
{
    using Common.Types;
    using Common.Utils;
    using Jmk.Common;
    using Models;
    using OpenTK;
    using OpenTK.Graphics;
    using OpenTK.Graphics.OpenGL;
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    internal partial class RenderCon : LocalizationCon
    {
        // Constructors

        internal RenderCon(WorldCon worldCon) : base(worldCon) => Stopwatch.Start();

        // Internal fields

        internal float FramesPerSecond;
        internal static GLInfo _GLInfo;
        internal bool SceneControlSuspended;

        internal static GraphicsMode _GraphicsMode;

        // Private fields

        private bool
            CameraViewValid,
            ProgramCompiled,
            ProjectionValid;

        private int
            TickCount,
            TickIndex;

        private int
            ProgramID,
            VertexShaderID,
            TessControlShaderID,
            TessEvaluationShaderID,
            GeometryShaderID,
            FragmentShaderID,
            ComputeShaderID;

        private int
            Loc_CameraView,
            Loc_Projection,
            Loc_TimeValue,
            Loc_TraceNumber,
            Loc_Transform;

        private List<int> Loc_Signals = new List<int>();

        private readonly long[] Ticks = new long[64];

        private StringBuilder GpuLog;

        private readonly System.Diagnostics.Stopwatch Stopwatch = new System.Diagnostics.Stopwatch();

        private int CurrencyCount;

        // Private static fields

        private static readonly object
            GLInfoSyncRoot = new object(),
            GLModeSyncRoot = new object();

        // Internal properties

        internal GLInfo GLInfo
        {
            get
            {
                if (_GLInfo == null)
                {
                    GLInfo info = null;
                    UsingGL(() => { info = new GLInfo(); });
                    lock (GLInfoSyncRoot)
                        _GLInfo = info;
                }
                return _GLInfo;
            }
        }

        internal List<ShaderType> ShaderTypes { get; } = new List<ShaderType>();

        // Protected internal properties

        protected internal override GraphicsMode GraphicsMode
        {
            get
            {
                if (_GraphicsMode == null)
                {
                    GraphicsMode mode = null;
                    UsingGL(() => { mode = SceneControl.GraphicsMode; });
                    lock (GLModeSyncRoot)
                        _GraphicsMode = mode;
                }
                return _GraphicsMode;
            }
        }

        // Private properties

        private bool ProgramValid => ProgramCompiled && Scene.GPUStatus == GPUStatus.OK;

        // Internal methods

        internal GLInfo GetGLInfo()
        {
            GLInfo info = null;
            UsingGL(() => { info = new GLInfo(); });
            return info;
        }

        internal void Invalidate()
        {
            InvalidateAllTraces();
            InvalidateCameraView();
            InvalidateProgram();
            InvalidateProjection();
        }

        internal void InvalidateAllTraces() => Scene.Traces.ForEach(InvalidateTrace);

        internal void InvalidateCameraView() => CameraViewValid = false;

        internal void InvalidateProgram()
        {
            ProgramCompiled = false;
            InvalidateCameraView();
            InvalidateProjection();
            UsingGL(() =>
            {
                DeleteShaders();
                if (ProgramID != 0)
                {
                    GL.DeleteProgram(ProgramID);
                    ProgramID = 0;
                }
            });
        }

        internal void InvalidateProjection() => ProjectionValid = false;

        internal void InvalidateTrace(Trace trace)
        {
            if (trace.Vao != null)
                UsingGL(() =>
                {
                    trace.Vao.ReleaseBuffers();
                    trace.Vao = null;
                });
        }

        internal void Refresh()
        {
            lock (GLModeSyncRoot)
                _GraphicsMode = null;
            InvalidateProgram();
            InvalidateAllTraces();
        }

        internal void Render() => UsingGL(() =>
        {
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);
            GL.ClearColor(Scene.BackgroundColour);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            ValidateProgram();
            if (ProgramValid)
            {
                GL.UseProgram(ProgramID); // Start Shader
                ValidateCameraView();
                ValidateProjection();
                LoadParameters();
                for (int traceIndex = 0; traceIndex < Scene.Traces.Count; traceIndex++)
                {
                    var trace = Scene.Traces[traceIndex];
                    if (!trace.Visible)
                        continue;
                    var traceNumber = traceIndex + 1;
                    LoadTraceNumber(traceNumber);
                    LoadTransform(trace);
                    ValidateTrace(trace);
                    GL.BindVertexArray(trace.Vao.VaoID);
                    GL.EnableVertexAttribArray(0);
                    GL.DrawElements((PrimitiveType)((int)trace.Pattern & 0x0F), trace.Vao.ElementCount, DrawElementsType.UnsignedInt, 0);
                    GL.DisableVertexAttribArray(0);
                    GL.BindVertexArray(0);
                }
                GL.UseProgram(0); // Stop Shader
                UpdateFPS();
            }
            SceneControl.SwapBuffers();
        });

        internal void Unload() => UsingGL(InvalidateAllTraces);

        internal bool UsingGL(Action action)
        {
            var ok = !SceneControlSuspended &&
                SceneControl?.IsHandleCreated == true &&
                SceneControl?.HasValidContext == true &&
                SceneControl?.Visible == true;
            if (ok)
            {
                if (++CurrencyCount == 1)
                    SceneControl.MakeCurrent();
                try
                {
                    action();
                }
                finally
                {
                    if (--CurrencyCount == 0)
                        SceneControl.Context.MakeCurrent(null);
                }
            }
            return ok;
        }

        // Protected internal methods

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                WorldCon.PropertyChanged += WorldCon_PropertyChanged;
            }
            else
            {
                WorldCon.PropertyChanged -= WorldCon_PropertyChanged;
            }
        }

        // Private methods

        private void BindAttribute(int attributeIndex, string variableName) => GL.BindAttribLocation(ProgramID, attributeIndex, variableName);

        private void BindAttributes() => BindAttribute(0, "position");

        private int CreateShader(ShaderType shaderType)
        {
            var script = GetScript(shaderType);
            if (string.IsNullOrWhiteSpace(script))
                return 0;
            Log($"Compiling {shaderType.ShaderName()};");
            var shaderID = GL.CreateShader(shaderType);
            GL.ShaderSource(shaderID, script);
            GL.CompileShader(shaderID);
            GL.AttachShader(ProgramID, shaderID);
            Log(GL.GetShaderInfoLog(shaderID));
            ShaderTypes.Add(shaderType);
            return shaderID;
        }

        private void CreateShaders()
        {
            ShaderTypes.Clear();
            VertexShaderID = CreateShader(ShaderType.VertexShader);
            TessControlShaderID = CreateShader(ShaderType.TessControlShader);
            TessEvaluationShaderID = CreateShader(ShaderType.TessEvaluationShader);
            GeometryShaderID = CreateShader(ShaderType.GeometryShader);
            FragmentShaderID = CreateShader(ShaderType.FragmentShader);
            ComputeShaderID = CreateShader(ShaderType.ComputeShader);
        }

        private void DeleteShader(ref int shaderID)
        {
            if (shaderID != 0)
            {
                GL.DetachShader(ProgramID, shaderID);
                GL.DeleteShader(shaderID);
                shaderID = 0;
            }
        }

        private void DeleteShaders()
        {
            DeleteShader(ref VertexShaderID);
            DeleteShader(ref TessControlShaderID);
            DeleteShader(ref TessEvaluationShaderID);
            DeleteShader(ref GeometryShaderID);
            DeleteShader(ref FragmentShaderID);
            DeleteShader(ref ComputeShaderID);
        }

        private string GetSignalScript()
        {
            var script = new StringBuilder();
            script.Append("uniform float timeValue");
            foreach (var signal in Scene.Signals)
                script.AppendFormat(CultureInfo.CurrentCulture, ", {0}", signal.Name);
            script.Append(";");
            return script.ToString();
        }

        private int GetUniformLocation(string uniformName) => GL.GetUniformLocation(ProgramID, uniformName);

        private void GetUniformLocations()
        {
            Loc_CameraView = GetUniformLocation("cameraView");
            Loc_Projection = GetUniformLocation("projection");
            Loc_TimeValue = GetUniformLocation("timeValue");
            Loc_TraceNumber = GetUniformLocation("traceNumber");
            Loc_Transform = GetUniformLocation("transform");
            Loc_Signals.Clear();
            foreach (var signal in Scene.Signals)
                Loc_Signals.Add(GetUniformLocation(signal.Name));
        }

        private void LoadCameraView() => LoadMatrix(Loc_CameraView, Scene.GetCameraView());

        private void LoadParameters() // Time and AC/DC signals.
        {
            var time = Clock.VirtualSecondsElapsed;
            LoadFloat(Loc_TimeValue, time);
            for (int index = 0; index < Scene.Signals.Count; index++)
            {
                var signal = Scene.Signals[index];
                LoadFloat(Loc_Signals[index], signal.GetValueAt(time));
            }
        }

        private void LoadProjection() => LoadMatrix(Loc_Projection, Scene.GetProjection());

        private void LoadTraceNumber(int traceIndex) => LoadInt(Loc_TraceNumber, traceIndex);

        private void LoadTransform(Trace trace) => LoadMatrix(Loc_Transform, trace.GetTransform());

        private void Log(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return;
            GpuLog.AppendLine(s.Trim());
            s = s.ToUpper(CultureInfo.InvariantCulture);
            if (s.Contains("ERROR"))
                Scene.GPUStatus = GPUStatus.Error;
            else if (Scene.GPUStatus == GPUStatus.OK && s.Contains("WARNING"))
                Scene.GPUStatus = GPUStatus.Warning;
        }

        private void UpdateFPS()
        {
            Ticks[TickIndex = (TickIndex + 1) % Ticks.Length] = Stopwatch.ElapsedMilliseconds;
            if (TickCount < Ticks.Length) TickCount++;
            var fps = 0f;
            if (TickCount > 1)
            {
                var ticks = Ticks.Take(TickCount);
                fps = 1000f * (TickCount - 1) / (ticks.Max() - ticks.Min());
            }
            FramesPerSecond = fps;
        }

        private void ValidateCameraView()
        {
            if (CameraViewValid)
                return;
            LoadCameraView();
            CameraViewValid = true;
        }

        private void ValidateProgram()
        {
            if (ProgramCompiled)
                return;
            Scene.GPUStatus = GPUStatus.OK;
            GpuLog = new StringBuilder();
            ProgramID = GL.CreateProgram();
            CreateShaders();
            if (!ShaderTypes.Any())
                Log("No Trace Shaders found to compile.");
            if (Scene.GPUStatus == GPUStatus.OK)
            {
                Log("Linking program;");
                BindAttributes();
                GL.LinkProgram(ProgramID);
                GL.ValidateProgram(ProgramID);
                Log(GL.GetProgramInfoLog(ProgramID));
            }
            DeleteShaders();
            Log("End of log.");
            Scene.GPULog = GpuLog.ToString().TrimEnd();
            GpuLog = null;
            GetUniformLocations();
            ProgramCompiled = true;
        }

        private void ValidateProjection()
        {
            if (ProjectionValid)
                return;
            GL.Viewport(SceneControl.Size);
            LoadProjection();
            ProjectionValid = true;
        }

        private void ValidateTrace(Trace trace)
        {
            if (trace.Vao == null)
                UsingGL(() => trace.Vao = new Vao(trace));
        }

        private void WorldCon_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case PropertyNames.Camera:
                case PropertyNames.CameraPosition:
                case PropertyNames.CameraFocus:
                    InvalidateCameraView();
                    break;
                case PropertyNames.ProjectionType:
                case PropertyNames.FieldOfView:
                case PropertyNames.NearPlane:
                case PropertyNames.FarPlane:
                    InvalidateProjection();
                    break;
                case PropertyNames.GLTargetVersion:
                case PropertyNames.SceneVertex:
                case PropertyNames.SceneTessControl:
                case PropertyNames.SceneTessEvaluation:
                case PropertyNames.SceneGeometry:
                case PropertyNames.SceneFragment:
                case PropertyNames.SceneCompute:
                case PropertyNames.Signals:
                case PropertyNames.Traces:
                case PropertyNames.TraceVertex:
                case PropertyNames.TraceTessControl:
                case PropertyNames.TraceTessEvaluation:
                case PropertyNames.TraceGeometry:
                case PropertyNames.TraceFragment:
                case PropertyNames.TraceCompute:
                    InvalidateProgram();
                    break;
                case PropertyNames.Pattern:
                case PropertyNames.StripeCount:
                    RenderCon.InvalidateAllTraces();
                    break;
            }
        }

        // Private static methods

        private static void LoadFloat(int location, float value) => GL.Uniform1(location, value);

        private static void LoadInt(int location, int value) => GL.Uniform1(location, value);

        private static void LoadMatrix(int location, Matrix4 value) => GL.UniformMatrix4(location, false, ref value);
    }

    partial class RenderCon : IScript
    {
        public string GetScript(ShaderType shaderType)
        {
            var version = Scene.GLTargetVersion;
            var signals = GetSignalScript();
            var sceneScript = Scene.GetScript(shaderType);
            var traceScripts = string.Concat(Scene.Traces.Select(
                p => string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.Format_Trace,
                    p.Index + 1,
                    p,
                    Tokens.BeginTrace(p.Index),
                    p.GetScript(shaderType).Indent("  "),
                    Tokens.EndTrace(p.Index))));
            var cases = !Scene.Traces.Any()
                ? string.Empty
                : Scene.Traces
                    .Select(p => string.Format(CultureInfo.InvariantCulture, Resources.Format_Case, p.Index + 1))
                    .Aggregate((p, q) => $"{p}{q}");
            return !Scene.Traces.Any(p => !string.IsNullOrWhiteSpace(p.GetScript(shaderType)))
                ? string.Empty
                : string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.Format_Scene,
                    version,
                    signals,
                    Tokens.BeginScene,
                    sceneScript,
                    Tokens.EndScene,
                    traceScripts,
                    cases);
        }

        public void SetScript(ShaderType shaderType, string value) => throw new System.NotImplementedException();
    }
}
