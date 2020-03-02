namespace TabbyCat.Controllers
{
    using System.Windows.Forms;
    using TabbyCat.Views;

    public class SceneController
    {
        public SceneController()
        {
            SceneForm = new SceneForm();
            PropertyController = new PropertyController(this);
        }

        internal PropertyController PropertyController;

        internal bool PropertyEditorVisible
        {
            get => PropertyController.FormVisible;
            set => PropertyController.FormVisible = value;
        }

        private SceneForm _SceneForm;
        internal SceneForm SceneForm
        {
            get => _SceneForm;
            set
            {
                if (SceneForm != null)
                {
                    SceneForm.ViewPropertyEditor.Click -= ViewPropertyEditor_Click;
                }
                _SceneForm = value;
                if (SceneForm != null)
                {
                    SceneForm.ViewPropertyEditor.Click += ViewPropertyEditor_Click;
                }
            }
        }

        private void ViewPropertyEditor_Click(object sender, System.EventArgs e)
        {
            PropertyEditorVisible = !PropertyEditorVisible;
        }

        internal void Show(IWin32Window owner) => SceneForm.Show(owner);
    }
}
