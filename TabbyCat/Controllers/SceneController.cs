namespace TabbyCat.Controllers
{
    using System.Windows.Forms;
    using TabbyCat.Views;

    internal class SceneController
    {
        internal SceneController()
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
                    SceneForm.FileClose.Click -= FileClose_Click;
                    SceneForm.FileExit.Click -= FileExit_Click;
                    SceneForm.ViewProperties.Click -= ViewProperties_Click;
                }
                _SceneForm = value;
                if (SceneForm != null)
                {
                    SceneForm.FileClose.Click += FileClose_Click;
                    SceneForm.FileExit.Click += FileExit_Click;
                    SceneForm.ViewProperties.Click += ViewProperties_Click;
                }
            }
        }

        #region Private Event Handlers

        private void FileClose_Click(object sender, System.EventArgs e) => SceneForm.Close();
        private void FileExit_Click(object sender, System.EventArgs e) => AppController.Close();
        private void ViewProperties_Click(object sender, System.EventArgs e) => PropertyEditorVisible = !PropertyEditorVisible;

        #endregion

        internal void Show(IWin32Window owner) => SceneForm.Show(owner);
    }
}
