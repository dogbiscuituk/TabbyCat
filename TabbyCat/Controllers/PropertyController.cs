namespace TabbyCat.Controllers
{
    using System.Windows.Forms;
    using TabbyCat.Controls;
    using TabbyCat.Models;
    using TabbyCat.Views;

    internal class PropertyController
    {
        internal PropertyController(SceneController sceneController)
        {
            SceneController = sceneController;
            SceneEditController = new SceneEditController(this);
            ShaderController = new ShaderController(this);
            TraceEditController = new TraceEditController(this);
            Connect(true);
        }

        private readonly SceneEditController SceneEditController;
        private readonly ShaderController ShaderController;
        private readonly TraceEditController TraceEditController;

        internal Scene Scene => SceneController.Scene;
        internal SceneController SceneController;
        internal TabbedEdit Editor => SceneForm.TabbedEdit;

        private SceneForm SceneForm => SceneController.SceneForm;

        private void Connect(bool connect)
        {
            SceneEditController.Connect(connect);
            TraceEditController.Connect(connect);
            ShaderController.Connect(connect);
        }
    }
}
