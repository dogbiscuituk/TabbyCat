namespace TabbyCat.Models
{
    using Controllers;
    using Newtonsoft.Json;
    using OpenTK;
    using Properties;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using Types;
    using Utils;

    public class Scene : Shaders, IScene
    {
        // Constructors

        public Scene() => Init();

        public Scene(WorldCon worldCon) : this() => WorldCon = worldCon;

        // Private fields

        private string _gpuLog = string.Empty;

        private GPUStatus _gpuStatus;

        // Public properties

        public Color BackgroundColour { get; set; }

        public Camera Camera { get; set; }

        public string GLTargetVersion { get; set; }

        public Projection Projection { get; set; }

        public int Samples { get; set; }

        public List<Shape> Shapes { get; private set; }

        public List<Signal> Signals { get; private set; }

        public bool Stereo { get; set; }

        public float TargetFPS { get; set; }

        [DefaultValue("")]
        public string Title { get; set; }

        public bool VSync { get; set; }

        [JsonIgnore]
        public GPUStatus GPUStatus
        {
            get => _gpuStatus;
            set
            {
                if (GPUStatus == value)
                    return;
                _gpuStatus = value;
                OnPropertyEdit(Property.GpuStatus);
            }
        }

        [JsonIgnore]
        public string GPULog
        {
            get => _gpuLog;
            set
            {
                if (GPULog == value)
                    return;
                _gpuLog = value;
                OnPropertyEdit(Property.GpuLog);
            }
        }

        [JsonIgnore]
        public bool IsModified => CommandCon?.IsModified ?? false;

        [JsonIgnore]
        public WorldCon WorldCon { get; set; }

        // Private properties

        private CommandCon CommandCon => WorldCon?.CommandCon;

        private GLControl GLControl => WorldCon?.SceneControl;

        // Public methods

        public void AddSignal(Signal signal) => Signals.Add(signal);

        public void AddShape(Shape shape) => Shapes.Add(shape);

        public void AttachShapes()
        {
            foreach (var shape in Shapes)
                shape.Scene = this;
        }

        public void Clear() => Init();

        public Matrix4 GetCameraView() => MathUtils.CreateCameraView(Camera);

        public Matrix4 GetProjectionMatrix() => MathUtils.CreateProjection(Projection, GLControl.ClientSize);

        public void InsertShape(int index, Shape shape) => Shapes.Insert(index, shape);

        public void InsertSignal(int index, Signal signal) => Signals.Insert(index, signal);

        public void OnCollectionEdit(Property property, int index, bool adding) => WorldCon.OnCollectionEdit(property, index, adding);

        public void OnPropertyEdit(Property property, int index = 0) => WorldCon?.OnPropertyEdit(property, index);

        public void RemoveShape(int index)
        {
            if (index >= 0 && index < Shapes.Count)
                Shapes.RemoveAt(index);
        }

        public void RemoveSignal(int index)
        {
            if (index >= 0 && index < Signals.Count)
                Signals.RemoveAt(index);
        }

        // Private methods

        private void Init()
        {
            BackgroundColour = Color.White;
            Camera = Camera.Default;
            GLTargetVersion = "330";
            GPULog = string.Empty;
            GPUStatus = GPUStatus.None;
            Projection = Projection.Default;
            Signals = new List<Signal>();
            TargetFPS = 60;
            Title = string.Empty;
            Shapes = new List<Shape>();
            VSync = false;
            InitShaders();
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
