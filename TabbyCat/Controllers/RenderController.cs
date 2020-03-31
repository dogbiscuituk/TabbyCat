namespace TabbyCat.Controllers
{
    using Jmk.Common;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using Properties;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.Models;

    public class RenderController : IShaderSet
    {
        #region Constructors

        internal RenderController(WorldController worldController)
        {
            WorldController = worldController;
            Stopwatch.Start();
        }

        #endregion

        #region Public Methods

        public string GetScript(ShaderType shaderType) =>
            !Scene.Traces.Any(p => !string.IsNullOrWhiteSpace(p.GetScript(shaderType)))
            ? string.Empty
            : string.Format(Resources.Format_Scene,
                Scene.GLTargetVersion,
                Scene.GetScript(shaderType),
                string.Concat(
                    Scene.Traces.Select(
                        p => string.Format(
                            Resources.Format_Trace,
                            p.Index + 1,
                            p,
                            p.GetScript(shaderType).Indent("  ")))),
                Scene.Traces.Any()
                    ? Scene.Traces.Select(p => string.Format(Resources.Format_Case, p.Index + 1))
                        .Aggregate((p, q) => $"{p}{q}")
                    : string.Empty);

        public void SetScript(ShaderType shaderType, string value) =>
            throw new System.NotImplementedException();

        #endregion

        #region Internal Properties

        internal float FramesPerSecond;

        internal static GLInfo _GLInfo;
        internal GLInfo GLInfo
        {
            get
            {
                if (_GLInfo == null && MakeCurrent(true))
                {
                    var info = new GLInfo();
                    MakeCurrent(false);
                    lock (GLInfoSyncRoot)
                        _GLInfo = info;
                }
                return _GLInfo;
            }
        }

        internal static GLMode _GLMode;
        internal GLMode GLMode
        {
            get
            {
                if (_GLMode == null && MakeCurrent(true))
                {
                    var mode = new GLMode(GLControl);
                    MakeCurrent(false);
                    lock (GLModeSyncRoot)
                        _GLMode = mode;
                }
                return _GLMode;
            }
        }

        internal List<ShaderType> ShaderTypes { get; } = new List<ShaderType>();

        #endregion

        #region Internal Methods

        internal GLInfo GetGLInfo()
        {
            if (MakeCurrent(true))
                try
                {
                    return new GLInfo();
                }
                finally
                {
                    MakeCurrent(false);
                }
            return null;
        }

        internal void InvalidateAllTraces() => Scene.Traces.ForEach(p => InvalidateTrace(p));

        internal void InvalidateCameraView() => CameraViewValid = false;

        internal void InvalidateProgram()
        {
            ProgramCompiled = false;
            InvalidateCameraView();
            InvalidateProjection();
            if (!MakeCurrent(true))
                return;
            DeleteShaders();
            if (ProgramID != 0)
            {
                GL.DeleteProgram(ProgramID);
                ProgramID = 0;
            }
            MakeCurrent(false);
        }

        internal void InvalidateProjection() => ProjectionValid = false;

        internal void InvalidateTrace(Trace trace)
        {
            if (MakeCurrent(true))
            {
                trace.Vao?.Release();
                MakeCurrent(false);
            }
            trace.Vao = null;
        }

        internal void Refresh()
        {
            lock (GLModeSyncRoot)
                _GLMode = null;
            InvalidateProgram();
            InvalidateAllTraces();
        }

        internal void Render()
        {
            if (!MakeCurrent(true))
                return;
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
                LoadTimeValue();
                for (int traceIndex = 0; traceIndex < Scene.Traces.Count; traceIndex++)
                {
                    var trace = Scene.Traces[traceIndex];
                    if (!trace.Visible)
                        continue;
                    var traceNumber = traceIndex + 1;
                    LoadTraceNumber(traceNumber);
                    LoadTransform(trace);
                    ValidateTrace(trace);
                    var vao = trace.Vao;
                    GL.BindVertexArray(vao.ID);
                    GL.EnableVertexAttribArray(0);
                    GL.DrawElements((PrimitiveType)((int)trace.Pattern & 0x0F),
                        vao.ElementCount, DrawElementsType.UnsignedInt, 0);
                    GL.DisableVertexAttribArray(0);
                    GL.BindVertexArray(0);
                }
                GL.UseProgram(0); // Stop Shader
                UpdateFPS();
            }
            GLControl.SwapBuffers();
            MakeCurrent(false);
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

        internal bool Unload()
        {
            var result = MakeCurrent(true);
            if (result)
            {
                InvalidateAllTraces();
                MakeCurrent(false);
            }
            return result;
        }

        #endregion

        #region Private Fields

        private static readonly object GLInfoSyncRoot = new object();
        private static readonly object GLModeSyncRoot = new object();
        private readonly System.Diagnostics.Stopwatch Stopwatch = new System.Diagnostics.Stopwatch();
        private readonly long[] Ticks = new long[64];
        private int TickCount, TickIndex;
        private readonly WorldController WorldController;

        /// <summary>
        /// Program and Shader IDs.
        /// </summary>
        private int
            ProgramID,
            VertexShaderID,
            TessControlShaderID,
            TessEvaluationShaderID,
            GeometryShaderID,
            FragmentShaderID,
            ComputeShaderID;

        /// <summary>
        /// Uniform locations.
        /// </summary>
        private int
            Loc_CameraView,
            Loc_Projection,
            Loc_TimeValue,
            Loc_TraceNumber,
            Loc_Transform;

        private int
            CurrencyCount;

        private bool
            CameraViewValid,
            ProgramCompiled,
            ProjectionValid;

        private StringBuilder
            GpuLog;

        #endregion

        #region Private Properties

        private Clock Clock => ClockController.Clock;
        private ClockController ClockController => WorldController.ClockController;
        private GLControl GLControl => WorldController.GLControl;
        private bool ProgramValid => ProgramCompiled && Scene.GPUStatus == GPUStatus.OK;
        private Scene Scene => WorldController.Scene;

        #endregion

        #region Private Methods

        #region Create / Delete Shaders

        private void BindAttribute(int attributeIndex, string variableName) =>
            GL.BindAttribLocation(ProgramID, attributeIndex, variableName);

        private void BindAttributes() => BindAttribute(0, "position");

        private int CreateShader(ShaderType shaderType)
        {
            var script = GetScript(shaderType);
            if (string.IsNullOrWhiteSpace(script))
                return 0;
            Log($"Compiling {shaderType.ShaderName()}...");
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

        private void Log(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return;
            GpuLog.AppendLine(s.Trim());
            s = s.ToUpper();
            if (s.ToUpper().Contains("ERROR"))
                Scene.GPUStatus = GPUStatus.Error;
            else if (Scene.GPUStatus == GPUStatus.OK && s.Contains("WARNING"))
                Scene.GPUStatus = GPUStatus.Warning;
        }

        private bool MakeCurrent(bool current)
        {
            if (!GLControl.HasValidContext)
                return false;
            if (current)
            {
                if (++CurrencyCount == 1)
                    GLControl.MakeCurrent();
            }
            else
            {
                if (--CurrencyCount == 0)
                    GLControl.Context.MakeCurrent(null);
            }
            return true;
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
                Log("Linking program...");
                BindAttributes();
                GL.LinkProgram(ProgramID);
                GL.ValidateProgram(ProgramID);
                Log(GL.GetProgramInfoLog(ProgramID));
                GetUniformLocations();
            }
            DeleteShaders();
            Log("End of log.");
            Scene.GPULog = GpuLog.ToString().TrimEnd();
            GpuLog = null;
            ProgramCompiled = true;
        }

        private void ValidateProjection()
        {
            if (ProjectionValid)
                return;
            GL.Viewport(GLControl.Size);
            LoadProjection();
            ProjectionValid = true;
        }

        private void ValidateTrace(Trace trace)
        {
            if (trace.Vao == null)
                trace.Vao = VaoStore.AcquireVao(trace.Pattern, trace.StripCount);
        }

        #endregion

        private List<Vao> Vaos = new List<Vao>();

        #region Load / Unload Traces

        private int BindIndicesBuffer(int[] indices)
        {
            var vboID = CreateVbo();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, vboID);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(int), indices, BufferUsageHint.StaticDraw);
            return vboID;
        }

        private int CreateVao()
        {
            GL.GenVertexArrays(1, out int vaoID);
            return vaoID;
        }

        private int CreateVbo()
        {
            GL.GenBuffers(1, out int vboID);
            return vboID;
        }

        private void DeleteVao(ref int vaoID)
        {
            if (vaoID != 0)
            {
                GL.DeleteVertexArray(vaoID);
                vaoID = 0;
            }
        }

        private void DeleteVbo(ref int vboID)
        {
            if (vboID != 0)
            {
                GL.DeleteBuffer(vboID);
                vboID = 0;
            }
        }

        private int StoreDataInAttributeList(int attributeNumber, float[] data)
        {
            var vboID = CreateVbo();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Length * sizeof(float), data, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(attributeNumber, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            return vboID;
        }

        #endregion

        #region Uniforms

        private int GetUniformLocation(string uniformName) => GL.GetUniformLocation(ProgramID, uniformName);

        private void GetUniformLocations()
        {
            Loc_CameraView = GetUniformLocation("cameraView");
            Loc_Projection = GetUniformLocation("projection");
            Loc_TimeValue = GetUniformLocation("timeValue");
            Loc_TraceNumber = GetUniformLocation("traceNumber");
            Loc_Transform = GetUniformLocation("transform");
        }

        private static void LoadFloat(int location, float value) => GL.Uniform1(location, value);
        private static void LoadInt(int location, int value) => GL.Uniform1(location, value);
        private static void LoadMatrix(int location, Matrix4 value) => GL.UniformMatrix4(location, false, ref value);

        private void LoadProjection() => LoadMatrix(Loc_Projection, Scene.GetProjection());
        private void LoadTimeValue() => LoadFloat(Loc_TimeValue, Clock.VirtualSecondsElapsed);
        private void LoadTraceNumber(int traceIndex) => LoadInt(Loc_TraceNumber, traceIndex);
        private void LoadTransform(Trace trace) => LoadMatrix(Loc_Transform, trace.GetTransform());
        private void LoadCameraView() => LoadMatrix(Loc_CameraView, Scene.GetCameraView());

        #endregion

        #endregion
    }
}
