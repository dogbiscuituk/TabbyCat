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
            ScenePropertyController = new ScenePropertyController(this);
            TracePropertyController = new TracePropertyController(this);
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
                    Editor.FormClosing -= PropertyEditor_FormClosing;
                }
                _Editor = value;
                if (Editor != null)
                {
                    Editor.FormClosing += PropertyEditor_FormClosing;
                }
            }
        }

        private readonly ScenePropertyController ScenePropertyController;
        private readonly ShaderController ShaderController;
        private readonly TracePropertyController TracePropertyController;

        private void PropertyEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Editor.Hide();
                e.Cancel = true;
            }
        }

        internal Scene Scene => SceneController.Scene;
        internal SceneController SceneController;

        private SceneForm SceneForm => SceneController.SceneForm;

        internal void Show(IWin32Window owner) => Editor.Show(owner);

        private void Connect(bool connect)
        {
            ScenePropertyController.Connect(connect);
            TracePropertyController.Connect(connect);
            ShaderController.Connect(connect);
        }
    }
}
