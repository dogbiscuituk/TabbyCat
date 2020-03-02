namespace TabbyCat.Controllers
{
    using System.Windows.Forms;
    using TabbyCat.Views;

    internal class PropertyController
    {
        internal PropertyController(SceneController sceneController)
        {
            SceneController = sceneController;
            PropertyEditor = new PropertyEditor();
        }

        internal bool FormVisible
        {
            get => PropertyEditor.Visible;
            set
            {
                if (FormVisible != value)
                    if (value)
                        PropertyEditor.Show(SceneForm);
                    else
                        PropertyEditor.Hide();
            }
        }

        private PropertyEditor _PropertyEditor;
        internal PropertyEditor PropertyEditor
        {
            get => _PropertyEditor;
            set
            {
                if (PropertyEditor != null)
                {
                    PropertyEditor.FormClosing -= PropertyEditor_FormClosing;
                }
                _PropertyEditor = value;
                if (PropertyEditor != null)
                {
                    PropertyEditor.FormClosing += PropertyEditor_FormClosing;
                }
            }
        }

        private void PropertyEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                PropertyEditor.Hide();
                e.Cancel = true;
            }
        }

        internal SceneController SceneController;

        private SceneForm SceneForm => SceneController.SceneForm;

        internal void Show(IWin32Window owner) => PropertyEditor.Show(owner);
    }
}
