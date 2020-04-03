namespace TabbyCat.MvcModels
{
    using OpenTK;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using TabbyCat.Commands;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.MvcControllers;
    using TabbyCat.Properties;

    public class Scene : Code, IScene
    {
        #region Constructors

        public Scene() => Init();

        internal Scene(WorldController worldController) : this() => WorldController = worldController;

        #endregion

        #region Public Properties

        public Color BackgroundColour { get; set; }
        public SimpleCamera Camera { get; set; }
        public float FPS { get; set; }
        public string GLTargetVersion { get; set; }
        public Projection Projection { get; set; }
        public int Samples { get; set; }

        [DefaultValue("")]
        public string Title { get; set; }

        public List<Trace> Traces = new List<Trace>();
        public bool VSync { get; set; }

        private GPUStatus _GPUStatus;
        public GPUStatus GPUStatus
        {
            get => _GPUStatus;
            set
            {
                if (GPUStatus == value)
                    return;
                _GPUStatus = value;
                OnPropertyChanged(PropertyNames.GPUStatus);
            }
        }

        private string _GPULog = string.Empty;
        public string GPULog
        {
            get => _GPULog;
            set
            {
                if (GPULog == value)
                    return;
                _GPULog = value;
                OnPropertyChanged(PropertyNames.GPULog);
            }
        }

        #endregion

        #region Internal Properties

        internal CommandProcessor CommandProcessor => WorldController?.CommandProcessor;
        internal GLMode GLMode => WorldController?.GLMode;
        internal bool IsModified => CommandProcessor?.IsModified ?? false;
        internal WorldController WorldController;

        #endregion

        #region Internal Methods

        internal void AddTrace(Trace trace) => Traces.Add(trace);

        internal void AttachTraces()
        {
            foreach (var trace in Traces)
                trace.Scene = this;
        }

        internal void Clear() { }

        internal Matrix4 GetCameraView() => Maths.CreateCameraView(Camera);

        internal GLMode GetGLMode() => WorldController?.GLMode;

        internal Matrix4 GetProjection() => Maths.CreateProjection(Projection, GLControl.ClientSize);

        internal void InsertTrace(int index, Trace trace) => Traces.Insert(index, trace);

        internal Trace NewTrace() => new Trace(this);

        internal void OnPropertyChanged(string propertyName) => WorldController?.OnPropertyChanged(propertyName);

        internal void RemoveTrace(int index)
        {
            if (index >= 0 && index < Traces.Count)
                Traces.RemoveAt(index);
        }

        internal void SetCameraView(Matrix4 _) { }

        internal void SetProjection(Matrix4 _) { }

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

            internal const float
                FPS = 60;

            internal GPUStatus
                GPUStatus = GPUStatus.OK;

            internal static SimpleCamera
                Camera = new SimpleCamera(Vector3.UnitZ * 2, Vector3.Zero);

            internal static Color
                BackgroundColour = Color.White;

            internal static Projection
                Projection = new Projection(75, 16, 9, 0.1f, 1000);

            internal static List<Trace>
                Traces => new List<Trace>();
        }

        #endregion

        #region Private Properties

        private GLControl GLControl => WorldController?.GLControl;

        #endregion

        #region Private Methods

        private void Init()
        {
            BackgroundColour = Defaults.BackgroundColour;
            Camera = Defaults.Camera;
            FPS = Defaults.FPS;
            GLTargetVersion = Defaults.GLTargetVersion;
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
