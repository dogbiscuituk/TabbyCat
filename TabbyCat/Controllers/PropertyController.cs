namespace TabbyCat.Controllers
{
    using System.Windows.Forms;
    using TabbyCat.Models;
    using TabbyCat.Views;

    internal class PropertyController
    {
        internal PropertyController(SceneController sceneController)
        {
            SceneController = sceneController;
            SceneEditController = new SceneEditController(this);
            TraceEditController = new TraceEditController(this);
            ShaderController = new ShaderController(this);
            Editor = new PropertyEditor();
        }

        internal bool FormVisible
        {
            get => Editor.Visible;
            set
            {
                if (FormVisible != value)
                    if (value)
                    {
                        Connect(true);
                        Editor.Show(SceneForm);
                    }
                    else
                    {
                        Editor.Hide();
                        Connect(false);
                    }
            }
        }

        private PropertyEditor _Editor;
        internal PropertyEditor Editor
        {
            get => _Editor;
            set
            {
                if (Editor != null)
                {
                }
                _Editor = value;
                if (Editor != null)
                {
                }
            }
        }

        private readonly SceneEditController SceneEditController;
        private readonly ShaderController ShaderController;
        private readonly TraceEditController TraceEditController;

        internal Scene Scene => SceneController.Scene;
        internal SceneController SceneController;

        private SceneForm SceneForm => SceneController.SceneForm;

        internal void Show(IWin32Window owner) => Editor.Show(owner);

        private void Connect(bool connect)
        {
            SceneEditController.Connect(connect);
            TraceEditController.Connect(connect);
            ShaderController.Connect(connect);
        }
    }
}
