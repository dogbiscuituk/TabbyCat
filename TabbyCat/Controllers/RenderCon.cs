namespace TabbyCat.Controllers
{
    using OpenTK;
    using OpenTK.Graphics;
    using OpenTK.Graphics.OpenGL;
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Types;
    using Utils;
    using Trace = Models.Trace;

    public partial class RenderCon : LocalizationCon
    {
        // Constructors

        public RenderCon(WorldCon worldCon) : base(worldCon) => _stopwatch.Start();

        // Private fields

        private bool
            _cameraViewValid,
            _programCompiled,
            _projectionValid;

        private int
            _tickCount,
            _tickIndex;

        private int
            _program,
            _vertexShader,
            _tessControlShader,
            _tessEvaluationShader,
            _geometryShader,
            _fragmentShader,
            _computeShader;

        private int
            _locCameraView,
            _locProjection,
            _locTimeValue,
            _locTraceNumber,
            _locTransform;

        private readonly List<int> _locSignals = new List<int>();

        private int _currencyCount;

        private StringBuilder _gpuLog;

        private readonly Stopwatch _stopwatch = new Stopwatch();

        private readonly long[] _ticks = new long[64];

        // Private static fields

        private static readonly object
            InfoSyncRoot = new object(),
            ModeSyncRoot = new object();

        // Public properties

        public float FramesPerSecond { get; private set; }

        public GLInfo GLInfo
        {
            get
            {
                if (TheGLInfo == null)
                {
                    GLInfo info = null;
                    UsingGL(() => info = new GLInfo());
                    lock (InfoSyncRoot)
                        TheGLInfo = info;
                }
                return TheGLInfo;
            }
        }

        public override GraphicsMode GraphicsMode
        {
            get
            {
                if (TheGraphicsMode == null)
                {
                    GraphicsMode mode = null;
                    UsingGL(() => mode = SceneControl.GraphicsMode);
                    lock (ModeSyncRoot)
                        TheGraphicsMode = mode;
                }
                return TheGraphicsMode;
            }
        }

        public bool SceneControlSuspended { get; set; }

        // Public static properties

        public static GLInfo TheGLInfo { get; private set; }

        // Private properties

        private bool ProgramValid => _programCompiled && Scene.GPUStatus == GPUStatus.OK;

        private List<ShaderType> ShaderTypes { get; } = new List<ShaderType>();

        // Private static properties

        private static GraphicsMode TheGraphicsMode { get; set; }

        // Public methods

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
                WorldCon.PropertyEdit += WorldCon_PropertyEdit;
            else
                WorldCon.PropertyEdit -= WorldCon_PropertyEdit;
        }

        public void Invalidate()
        {
            InvalidateAllTraces();
            InvalidateCameraView();
            InvalidateProgram();
            InvalidateProjection();
        }

        public void InvalidateProgram()
        {
            _programCompiled = false;
            InvalidateCameraView();
            InvalidateProjection();
            UsingGL(() =>
            {
                DeleteShaders();
                if (_program != 0)
                {
                    GL.DeleteProgram(_program);
                    _program = 0;
                }
            });
        }

        public void InvalidateProjection() => _projectionValid = false;

        public void Refresh()
        {
            lock (ModeSyncRoot)
                TheGraphicsMode = null;
            InvalidateProgram();
            InvalidateAllTraces();
        }

        public void Render() => UsingGL(() =>
        {
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);
            GL.ClearColor(Scene.BackgroundColour);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            ValidateProgram();
            if (ProgramValid)
            {
                GL.UseProgram(_program); // Start Shader
                ValidateCameraView();
                ValidateProjection();
                LoadParameters();
                for (var traceIndex = 0; traceIndex < Scene.Traces.Count; traceIndex++)
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

        public void Unload() => UsingGL(InvalidateAllTraces);

        // Private methods

        private void BindAttribute(int attributeIndex, string variableName) => GL.BindAttribLocation(_program, attributeIndex, variableName);

        private void BindAttributes() => BindAttribute(0, "position");

        private int CreateShader(ShaderType shaderType)
        {
            var script = GetScript(shaderType);
            if (string.IsNullOrWhiteSpace(script))
                return 0;
            Log($"Compiling {shaderType.ShaderName()};");
            var shader = GL.CreateShader(shaderType);
            GL.ShaderSource(shader, script);
            GL.CompileShader(shader);
            GL.AttachShader(_program, shader);
            Log(GL.GetShaderInfoLog(shader));
            ShaderTypes.Add(shaderType);
            return shader;
        }

        private void CreateShaders()
        {
            ShaderTypes.Clear();
            _vertexShader = CreateShader(ShaderType.VertexShader);
            _tessControlShader = CreateShader(ShaderType.TessControlShader);
            _tessEvaluationShader = CreateShader(ShaderType.TessEvaluationShader);
            _geometryShader = CreateShader(ShaderType.GeometryShader);
            _fragmentShader = CreateShader(ShaderType.FragmentShader);
            _computeShader = CreateShader(ShaderType.ComputeShader);
        }

        private void DeleteShader(ref int shaderId)
        {
            if (shaderId != 0)
            {
                GL.DetachShader(_program, shaderId);
                GL.DeleteShader(shaderId);
                shaderId = 0;
            }
        }

        private void DeleteShaders()
        {
            DeleteShader(ref _vertexShader);
            DeleteShader(ref _tessControlShader);
            DeleteShader(ref _tessEvaluationShader);
            DeleteShader(ref _geometryShader);
            DeleteShader(ref _fragmentShader);
            DeleteShader(ref _computeShader);
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

        private int GetUniformLocation(string uniformName) => GL.GetUniformLocation(_program, uniformName);

        private void GetUniformLocations()
        {
            _locCameraView = GetUniformLocation("cameraView");
            _locProjection = GetUniformLocation("projection");
            _locTimeValue = GetUniformLocation("timeValue");
            _locTraceNumber = GetUniformLocation("traceNumber");
            _locTransform = GetUniformLocation("transform");
            _locSignals.Clear();
            foreach (var signal in Scene.Signals)
                _locSignals.Add(GetUniformLocation(signal.Name));
        }

        private void InvalidateAllTraces() => Scene.Traces.ForEach(InvalidateTrace);

        private void InvalidateCameraView() => _cameraViewValid = false;

        private void InvalidateTrace(Trace trace)
        {
            if (trace?.Vao != null)
                UsingGL(() =>
                {
                    trace.Vao.ReleaseBuffers();
                    trace.Vao = null;
                });
        }

        private void LoadCameraView() => LoadMatrix(_locCameraView, Scene.GetCameraView());

        private void LoadParameters() // Time and AC/DC signals.
        {
            var time = Clock.VirtualSecondsElapsed;
            LoadFloat(_locTimeValue, time);
            for (var index = 0; index < Scene.Signals.Count; index++)
            {
                var signal = Scene.Signals[index];
                LoadFloat(_locSignals[index], signal.GetValueAt(time));
            }
        }

        private void LoadProjection() => LoadMatrix(_locProjection, Scene.GetProjectionMatrix());

        private void LoadTraceNumber(int traceIndex) => LoadInt(_locTraceNumber, traceIndex);

        private void LoadTransform(Trace trace) => LoadMatrix(_locTransform, trace.GetTransform());

        private void Log(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return;
            _gpuLog.AppendLine(s.Trim());
            s = s.ToUpper(CultureInfo.InvariantCulture);
            if (s.Contains("ERROR"))
                Scene.GPUStatus = GPUStatus.Error;
            else if (Scene.GPUStatus == GPUStatus.OK && s.Contains("WARNING"))
                Scene.GPUStatus = GPUStatus.Warning;
        }

        private void UpdateFPS()
        {
            _ticks[_tickIndex = (_tickIndex + 1) % _ticks.Length] = _stopwatch.ElapsedMilliseconds;
            if (_tickCount < _ticks.Length)
                _tickCount++;
            var fps = 0f;
            if (_tickCount > 1)
            {
                var ticks = _ticks.Take(_tickCount).ToArray();
                fps = 1000f * (_tickCount - 1) / (ticks.Max() - ticks.Min());
            }
            FramesPerSecond = fps;
        }

        private void UsingGL(Action action)
        {
            if (action == null)
                return;
            var ok = !SceneControlSuspended &&
                     SceneControl?.IsHandleCreated == true &&
                     SceneControl?.HasValidContext == true &&
                     SceneControl?.Visible == true;
            if (ok)
            {
                if (++_currencyCount == 1)
                    SceneControl.MakeCurrent();
                try
                {
                    action();
                }
                finally
                {
                    if (--_currencyCount == 0)
                        SceneControl.Context.MakeCurrent(null);
                }
            }
        }

        private void ValidateCameraView()
        {
            if (_cameraViewValid)
                return;
            LoadCameraView();
            _cameraViewValid = true;
        }

        private void ValidateProgram()
        {
            if (_programCompiled)
                return;
            Scene.GPUStatus = GPUStatus.OK;
            _gpuLog = new StringBuilder();
            _program = GL.CreateProgram();
            CreateShaders();
            if (!ShaderTypes.Any())
                Log("No Trace Shaders found to compile.");
            if (Scene.GPUStatus == GPUStatus.OK)
            {
                Log("Linking program;");
                BindAttributes();
                GL.LinkProgram(_program);
                GL.ValidateProgram(_program);
                Log(GL.GetProgramInfoLog(_program));
            }
            DeleteShaders();
            Log("End of log.");
            Scene.GPULog = _gpuLog.ToString().TrimEnd();
            _gpuLog = null;
            GetUniformLocations();
            _programCompiled = true;
        }

        private void ValidateProjection()
        {
            if (_projectionValid)
                return;
            GL.Viewport(SceneControl.Size);
            LoadProjection();
            _projectionValid = true;
        }

        private void ValidateTrace(Trace trace)
        {
            if (trace.Vao == null)
                UsingGL(() => trace.Vao = new Vao(trace));
        }

        private void WorldCon_PropertyEdit(object sender, PropertyEditEventArgs e)
        {
            if (e.Property.InvalidatesCameraView())
                InvalidateCameraView();
            if (e.Property.InvalidatesProgram())
                InvalidateProgram();
            if (e.Property.InvalidatesProjection())
                InvalidateProjection();
            if (e.Property.InvalidatesTrace())
                InvalidateAllTraces();
        }

        // Private static methods

        private static void LoadFloat(int location, float value) => GL.Uniform1(location, value);

        private static void LoadInt(int location, int value) => GL.Uniform1(location, value);

        private static void LoadMatrix(int location, Matrix4 value) => GL.UniformMatrix4(location, false, ref value);
    }

    public partial class RenderCon : IScript
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
            return Scene.Traces.All(p => string.IsNullOrWhiteSpace(p.GetScript(shaderType)))
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

        public void SetScript(ShaderType shaderType, string value) => throw new NotImplementedException();
    }
}
