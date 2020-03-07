namespace TabbyCat.Controllers
{
    using TabbyCat.Controls;
    using TabbyCat.Models;
    using TabbyCat.Views;

    internal class PropertyController
    {
        #region Constructors

        internal PropertyController(SceneController sceneController)
        {
            SceneController = sceneController;
            SceneEditController = new SceneEditController(this);
            ShaderController = new ShaderController(this);
            TraceEditController = new TraceEditController(this);
            Connect(true);
        }

        #endregion

        #region Fields & Properties

        private readonly SceneEditController SceneEditController;
        private readonly TraceEditController TraceEditController;

        internal TabbedEdit Editor => SceneForm.TabbedEdit;
        internal Scene Scene => SceneController.Scene;
        internal SceneController SceneController;
        internal readonly ShaderController ShaderController;

        private SceneForm SceneForm => SceneController.SceneForm;

        #endregion

        #region Private Methods

        private void Connect(bool connect)
        {
            SceneEditController.Connect(connect);
            TraceEditController.Connect(connect);
            ShaderController.Connect(connect);
        }

        #endregion
    }
}
