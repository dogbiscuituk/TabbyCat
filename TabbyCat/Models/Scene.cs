namespace TabbyCat.Models
{
    using Common.Types;
    using Common.Utils;
    using Controllers;
    using Newtonsoft.Json;
    using OpenTK;
    using OpenTK.Graphics;
    using Properties;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;

    public class Scene : CodeBase, IScene
    {
        public Scene() : base() => Init();

        internal Scene(WorldCon worldCon) : this() => WorldCon = worldCon;

        internal WorldCon WorldCon;

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

        [JsonProperty] public List<Signal> Signals { get; private set; }
        [JsonProperty] public List<Trace> Traces { get; private set; }

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

        internal CommandCon CommandCon => WorldCon?.CommandCon;

        internal GraphicsMode GraphicsMode => WorldCon?.GraphicsMode;

        internal bool IsModified => CommandCon?.IsModified ?? false;

        private GLControl GLControl => WorldCon?.SceneControl;

        internal void AddSignal(Signal signal) => Signals.Add(signal);

        internal void AddTrace(Trace trace) => Traces.Add(trace);

        internal void AttachTraces()
        {
            foreach (var trace in Traces)
                trace.Scene = this;
        }

        internal void Clear() => Init();

        internal Matrix4 GetCameraView() => MathUtils.CreateCameraView(Camera);

        internal GraphicsMode GetGraphicsMode() => WorldCon?.GraphicsMode;

        internal Matrix4 GetProjection() => MathUtils.CreateProjection(Projection, GLControl.ClientSize);

        internal void InsertSignal(int index, Signal signal) => Signals.Insert(index, signal);

        internal void InsertTrace(int index, Trace trace) => Traces.Insert(index, trace);

        internal void OnCollectionChanged(string propertyName, bool adding, int index) => WorldCon.OnCollectionChanged(propertyName, adding, index);

        internal void OnPropertyChanged(string propertyName) => WorldCon?.OnPropertyChanged(propertyName);

        internal void RemoveSignal(int index)
        {
            if (index >= 0 && index < Signals.Count)
                Signals.RemoveAt(index);
        }

        internal void RemoveTrace(int index)
        {
            if (index >= 0 && index < Traces.Count)
                Traces.RemoveAt(index);
        }

        internal void SetCameraView(Matrix4 _) { }

        internal void SetProjection(Matrix4 _) { }

        private void Init()
        {
            InitShaders();
            BackgroundColour = Color.White;
            Camera = new Camera(2 * Vector3.UnitZ, Vector3.Zero);
            FPS = 60;
            GLTargetVersion = "330";
            GPULog = string.Empty;
            GPUStatus = GPUStatus.OK;
            Projection = new Projection(75, 16, 9, 0.1f, 1000);
            Signals = new List<Signal>();
            Title = string.Empty;
            Traces = new List<Trace>();
            VSync = false;
        }

        private void InitShaders()
        {
            VertexShader = Resources.Scene_VertexShader;
            TessControlShader = Resources.Scene_TessControlShader;
            TessEvaluationShader = Resources.Scene_TessEvaluationShader;
            GeometryShader = Resources.Scene_GeometryShader;
            FragmentShader = Resources.Scene_FragmentShader;
            ComputeShader = Resources.Scene_ComputeShader;
        }
    }
}
