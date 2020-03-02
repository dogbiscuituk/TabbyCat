namespace TabbyCat.Models
{
    using System.Drawing;
    using TabbyCat.Controllers;

    public class Scene
    {
        #region Constructors

        public Scene() => RestoreDefaults();

        internal Scene(SceneController sceneController)
        {
            this.sceneController = sceneController;
        }

        #endregion

        public Color BackgroundColour { get; set; }
        public Camera Camera = new Camera();
        public int FPS { get; set; }
        public string GLSLTargetVersion { get; set; }
        public Projection Projection = new Projection();
        private SceneController sceneController;

        public int SampleCount { get; set; }
        public string Title { get; set; }
        public bool VSync { get; set; }

        internal bool IsModified { get; set; }

        internal void Clear() { }

        private void RestoreDefaults()
        {
            /*
            _BackgroundColour = Defaults.BackgroundColour;
            _Camera = Defaults.Camera;
            _FPS = Defaults.FPS;
            _GLTargetVersion = Defaults.GLTargetVersion;
            _GPUCode = Defaults.GPUCode;
            _GPULog = Defaults.GPULog;
            _Projection = Defaults.Projection;
            _Shader1Vertex = Resources.VertexHead;
            _Shader2TessControl = Defaults.Shader2TessControl;
            _Shader3TessEvaluation = Defaults.Shader3TessEvaluation;
            _Shader4Geometry = Defaults.Shader4Geometry;
            _Shader5Fragment = Resources.FragmentHead;
            _Shader6Compute = Defaults.Shader6Compute;
            _Title = Defaults.Title;
            _VSync = Defaults.VSync;
            Traces = Defaults.Traces;
            */
        }
    }
}
