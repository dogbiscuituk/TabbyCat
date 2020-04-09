namespace TabbyCat.Models
{
    using Newtonsoft.Json;
    using OpenTK;
    using OpenTK.Graphics;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using TabbyCat.Commands;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.Controllers;
    using TabbyCat.Properties;

    public class Scene : Code, IScene
    {
        public Scene()
        {
            BackgroundColour = Color.White;
            Camera = new Camera(2 * Vector3.UnitZ, Vector3.Zero);
            FPS = 60;
            GLTargetVersion = "330";
            GPULog = string.Empty;
            GPUStatus = GPUStatus.OK;
            Projection = new Projection(75, 16, 9, 0.1f, 1000);
            Shader1Vertex = Resources.Scene_Shader1Vertex;
            Shader2TessControl = Resources.Scene_Shader2TessControl;
            Shader3TessEvaluation = Resources.Scene_Shader3TessEvaluation;
            Shader4Geometry = Resources.Scene_Shader4Geometry;
            Shader5Fragment = Resources.Scene_Shader5Fragment;
            Shader6Compute = Resources.Scene_Shader6Compute;
            Title = string.Empty;
            Traces = new List<Trace>();
            VSync = false;
        }

        internal Scene(WorldController worldController) : this() => WorldController = worldController;

        internal WorldController WorldController;

        private string _GPULog = string.Empty;
        private GPUStatus _GPUStatus;

        public Color BackgroundColour { get; set; }
        public Camera Camera { get; set; }
        public float FPS { get; set; }
        public string GLTargetVersion { get; set; }
        public Projection Projection { get; set; }
        public int Samples { get; set; }
        public bool Stereo { get; set; }
        public bool VSync { get; set; }

        [DefaultValue("")]
        public string Title { get; set; }

        [JsonProperty]
        public List<Trace> Traces { get; private set; }

        [JsonIgnore]
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

        [JsonIgnore]
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

        internal CommandProcessor CommandProcessor => WorldController?.CommandProcessor;

        internal GraphicsMode GraphicsMode => WorldController?.GraphicsMode;

        internal bool IsModified => CommandProcessor?.IsModified ?? false;

        private GLControl GLControl => WorldController?.GLControl;

        internal void AddTrace(Trace trace) => Traces.Add(trace);

        internal void AttachTraces()
        {
            foreach (var trace in Traces)
                trace.Scene = this;
        }

        internal void Clear() { }

        internal Matrix4 GetCameraView() => Maths.CreateCameraView(Camera);

        internal GraphicsMode GetGraphicsMode() => WorldController?.GraphicsMode;

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
    }
}
