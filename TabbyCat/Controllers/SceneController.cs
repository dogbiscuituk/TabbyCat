namespace TabbyCat.Controllers
{
    using System.Windows.Forms;
    using TabbyCat.Models;
    using TabbyCat.Views;

    internal class SceneController
    {
        internal SceneController()
        {
            SceneForm = new SceneForm();
            Scene = new Scene(this);
            JsonController = new JsonController(this);
            PropertyController = new PropertyController(this);
            ConnectAll(true);
        }

        internal PropertyController PropertyController;

        private bool PropertyEditorVisible
        {
            get => PropertyController.FormVisible;
            set => PropertyController.FormVisible = value;
        }

        internal Scene Scene;
        internal SceneForm SceneForm;

        #region Private Properties

        private readonly JsonController JsonController;

        #endregion

        #region Private Event Handlers

        // Menu
        private void FileNewEmptyScene_Click(object sender, System.EventArgs e) => NewEmptyScene();
        private void FileNewFromTemplate_Click(object sender, System.EventArgs e) => NewFromTemplate();
        private void FileOpen_Click(object sender, System.EventArgs e) => OpenFile();
        private void FileSave_Click(object sender, System.EventArgs e) => SaveFile();
        private void FileSaveAs_Click(object sender, System.EventArgs e) => SaveFileAs();
        private void FileClose_Click(object sender, System.EventArgs e) => SceneForm.Close();
        private void FileExit_Click(object sender, System.EventArgs e) => AppController.Close();
        private void ViewProperties_Click(object sender, System.EventArgs e) => PropertyEditorVisible = !PropertyEditorVisible;
        // Form
        private void SceneForm_FormClosed(object sender, FormClosedEventArgs e) => FormClosed();
        private void SceneForm_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !FormClosing(e.CloseReason);

        #endregion

        #region Private Methods

        private void ConnectAll(bool connect)
        {
            if (connect)
            {
                ConnectEventHandlers(true);
            }
            else
            {
                ConnectEventHandlers(false);
            }
        }

        private void ConnectEventHandlers(bool connect)
        {
            if (connect)
            {
                // Menu
                SceneForm.FileNewEmptyScene.Click += FileNewEmptyScene_Click;
                SceneForm.FileNewFromTemplate.Click += FileNewFromTemplate_Click;
                SceneForm.FileOpen.Click += FileOpen_Click;
                SceneForm.FileSave.Click += FileSave_Click;
                SceneForm.FileSaveAs.Click += FileSaveAs_Click;
                SceneForm.FileClose.Click += FileClose_Click;
                SceneForm.FileExit.Click += FileExit_Click;
                SceneForm.ViewProperties.Click += ViewProperties_Click;
                // Form
                SceneForm.FormClosed += SceneForm_FormClosed;
                SceneForm.FormClosing += SceneForm_FormClosing;
            }
            else
            {
                // Menu
                SceneForm.FileNewEmptyScene.Click -= FileNewEmptyScene_Click;
                SceneForm.FileNewFromTemplate.Click -= FileNewFromTemplate_Click;
                SceneForm.FileOpen.Click -= FileOpen_Click;
                SceneForm.FileSave.Click -= FileSave_Click;
                SceneForm.FileSaveAs.Click -= FileSaveAs_Click;
                SceneForm.FileClose.Click -= FileClose_Click;
                SceneForm.FileExit.Click -= FileExit_Click;
                SceneForm.ViewProperties.Click -= ViewProperties_Click;
                // Form
                SceneForm.FormClosed -= SceneForm_FormClosed;
                SceneForm.FormClosing -= SceneForm_FormClosing;
            }
        }

        private void FormClosed() => ConnectAll(false);

        private bool FormClosing(CloseReason _) => JsonController.SaveIfModified();

        private void NewEmptyScene() { }

        private void NewFromTemplate() { }

        private void OpenFile() { }

        private void SaveFile() { }

        private void SaveFileAs() { }

        #endregion

        internal void Show(IWin32Window owner) => SceneForm.Show(owner);
    }
}
