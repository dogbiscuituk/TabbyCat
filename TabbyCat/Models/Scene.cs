namespace TabbyCat.Models
{
    using OpenTK;
    using System.Collections.Generic;
    using System.Drawing;
    using TabbyCat.Commands;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.Controllers;
    using TabbyCat.Properties;

    public class Scene : Code
    {
        #region Constructors

        public Scene() : base() => Init();

        internal Scene(SceneController sceneController) : this()
            => SceneController = sceneController;

        #endregion

        #region Public Properties

        public Color BackgroundColour { get; set; }
        public Camera Camera { get; set; }
        public double FPS { get; set; }
        public GLMode GLMode { get; set; }
        public string GLTargetVersion { get; set; }
        public Projection Projection { get; set; }
        public int SampleCount { get; set; }
        public string Title { get; set; }
        public List<Trace> Traces = new List<Trace>();
        public bool VSync { get; set; }
        public string GPUCode { get; set; }
        public string GPULog { get; set; }
        public GPUStatus GPUStatus { get; set; }

        #endregion

        #region Internal Properties

        internal CommandProcessor CommandProcessor => SceneController?.CommandProcessor;

        internal bool IsModified => CommandProcessor.IsModified;

        internal SceneController SceneController;

        #endregion

        #region Internal Methods

        internal void AddTrace(Trace trace) => Traces.Add(trace);

        internal void AttachTraces()
        {
            foreach (var trace in Traces)
                trace.Scene = this;
        }

        internal void Clear() { }

        internal Matrix4d GetCameraView() => Maths.CreateCameraView(Camera);

        internal GLMode GetGLMode() => SceneController?.GLMode;

        internal Matrix4d GetProjection() => Maths.CreateProjection(Projection, GLControl.ClientSize);

        internal void InsertTrace(int index, Trace trace) => Traces.Insert(index, trace);

        internal Trace NewTrace() => new Trace(this);

        internal void OnPropertyChanged(string propertyName) => SceneController.OnPropertyChanged(propertyName);

        internal void RemoveTrace(int index)
        {
            if (index >= 0 && index < Traces.Count)
                Traces.RemoveAt(index);
        }

        internal void SetCameraView(Matrix4d _) { }

        internal void SetGLMode(GLMode mode) => SceneController?.SetGLMode(mode);

        internal void SetProjection(Matrix4d _) { }

        #endregion

        #region Private Classes

        private class Defaults
        {
            internal const string
                GLTargetVersion = "330",
                GPUCode = "",
                GPULog = "",
                Title = "";

            internal const bool
                VSync = false;

            internal const double
                FPS = 60;

            internal GPUStatus
                GPUStatus = GPUStatus.OK;

            internal static Camera
                Camera = new Camera();

            internal static Color
                BackgroundColour = Color.White;

            internal static Projection
                Projection = new Projection(75, 16, 9, 0.1f, 1000);

            internal static List<Trace>
                Traces => new List<Trace>();
        }

        #endregion

        #region Private Properties

        private GLControl GLControl => SceneController?.GLControl;

        #endregion

        #region Private Methods

        private void Init()
        {
            BackgroundColour = Defaults.BackgroundColour;
            Camera = Defaults.Camera;
            FPS = Defaults.FPS;
            GLTargetVersion = Defaults.GLTargetVersion;
            GPUCode = Defaults.GPUCode;
            GPULog = Defaults.GPULog;
            Projection = Defaults.Projection;
            Shader1Vertex = Resources.Scene_Shader1Vertex;
            Shader2TessControl = Resources.Scene_Shader2TessControl;
            Shader3TessEvaluation = Resources.Scene_Shader3TessEvaluation;
            Shader4Geometry = Resources.Scene_Shader4Geometry;
            Shader5Fragment = Resources.Scene_Shader5Fragment;
            Shader6Compute = Resources.Scene_Shader6Compute;
            Title = Defaults.Title;
            Traces = Defaults.Traces;
            VSync = Defaults.VSync;
        }

        #endregion
    }
}
