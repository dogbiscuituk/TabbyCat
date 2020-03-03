namespace TabbyCat.Models
{
    using Newtonsoft.Json;
    using OpenTK;
    using System.Collections.Generic;
    using System.Drawing;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.Controllers;

    internal class Scene : Foo
    {
        #region Constructors

        public Scene() => RestoreDefaults();

        internal Scene(SceneController sceneController)
        {
            SceneController = sceneController;
        }

        #endregion

        [JsonProperty]
        internal Color _BackgroundColour;
        internal Color BackgroundColour
        {
            get => _BackgroundColour;
            set
            {
                if (BackgroundColour != value)
                {
                    _BackgroundColour = value;
                    OnPropertyChanged(nameof(BackgroundColour));
                }
            }
        }

        [JsonProperty]
        internal Camera _Camera;
        internal Camera Camera
        {
            get => _Camera;
            set
            {
                if (Camera != value)
                {
                    _Camera = value;
                    OnPropertyChanged(nameof(Camera));
                }
            }
        }

        [JsonProperty]
        internal double _FPS;
        internal double FPS
        {
            get => _FPS;
            set
            {
                if (FPS != value)
                {
                    _FPS = value;
                    OnPropertyChanged(nameof(FPS));
                }
            }
        }

        public GLMode GLMode
        {
            get => SceneController?.GLMode;
            set => Run(new GLModeCommand(value));
        }

        [JsonProperty]
        internal string _GLTargetVersion;
        internal string GLTargetVersion
        {
            get => _GLTargetVersion;
            set
            {
                if (GLTargetVersion != value)
                {
                    _GLTargetVersion = value;
                    OnPropertyChanged(nameof(GLTargetVersion));
                }
            }
        }

        [JsonProperty]
        internal Projection _Projection;
        internal Projection Projection
        {
            get => _Projection;
            set
            {
                if (Projection != value)
                {
                    _Projection = value;
                    OnPropertyChanged(nameof(Projection));
                }
            }
        }

        [JsonProperty]
        internal int _SampleCount;
        internal int SampleCount
        {
            get => _SampleCount;
            set
            {
                if (SampleCount != value)
                {
                    _SampleCount = value;
                    OnPropertyChanged(nameof(SampleCount));
                }
            }
        }

        [JsonProperty]
        internal string _Title;
        internal string Title
        {
            get => _Title;
            set
            {
                if (Title != value)
                {
                    _Title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        [JsonProperty]
        internal List<Trace> _Traces;
        internal List<Trace> Traces => _Traces;

        [JsonProperty]
        internal bool _VSync;
        internal bool VSync
        {
            get => _VSync;
            set
            {
                if (VSync != value)
                {
                    _VSync = value;
                    OnPropertyChanged(nameof(VSync));
                }
            }
        }

        internal string _GPUCode;
        internal string _GPULog;
        internal GPUStatus _GPUStatus;

        internal bool IsModified { get; set; }

        internal CommandProcessor CommandProcessor => SceneController?.CommandProcessor;
        internal SceneController SceneController;

        internal void Clear() { }

        #region Private Classes

        public class Defaults
        {
            public const string
                BackgroundColourString = "White",
                CameraString = "0, 0, 2, 0, 0, 0",
                GLTargetVersion = "330",
                GPUCode = "",
                GPULog = "",
                GPUStatusString = "OK",
                Shader2TessControl = "",
                Shader3TessEvaluation = "",
                Shader4Geometry = "",
                Shader6Compute = "",
                Title = "";

            public const bool
                VSync = false;

            public const double
                FPS = 60;

            public GPUStatus
                GPUStatus = GPUStatus.OK;

            public static Camera
                Camera = new Camera();

            public static Color
                BackgroundColour = Color.White;

            public static Projection
                Projection = new Projection(75, 16, 9, 0.1f, 1000);

            public static List<Trace>
                Traces => new List<Trace>();
        }

        #endregion

        #region Private Methods

        internal void AttachTraces()
        {
            foreach (var trace in Traces)
                trace.Init(this);
        }

        private void RestoreDefaults()
        {
            _BackgroundColour = Defaults.BackgroundColour;
            _Camera = Defaults.Camera;
            _FPS = Defaults.FPS;
            _GLTargetVersion = Defaults.GLTargetVersion;
            _Projection = Defaults.Projection;
            _Title = Defaults.Title;
            _VSync = Defaults.VSync;
            /*
            _GPUCode = Defaults.GPUCode;
            _GPULog = Defaults.GPULog;
            _Shader1Vertex = Resources.VertexHead;
            _Shader2TessControl = Defaults.Shader2TessControl;
            _Shader3TessEvaluation = Defaults.Shader3TessEvaluation;
            _Shader4Geometry = Defaults.Shader4Geometry;
            _Shader5Fragment = Resources.FragmentHead;
            _Shader6Compute = Defaults.Shader6Compute;
            Traces = Defaults.Traces;
            */
        }

        private void Run(IScenePropertyCommand command)
        {
            if (CommandProcessor != null)
                CommandProcessor.Run(command);
            else
                command.RunOn(this);
        }

        #endregion

        internal Matrix4d GetCameraView() => Maths.CreateCameraView(Camera);
        internal GLMode GetGLMode() => SceneController?.GLMode;
        internal Matrix4d GetProjection() => Maths.CreateProjection(Projection, GLControl.ClientSize);

        internal override void OnPropertyChanged(string propertyName) =>
            SceneController.OnPropertyChanged($"Scene.{propertyName}");
    }
}
