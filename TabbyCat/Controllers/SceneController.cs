namespace TabbyCat.Controllers
{
    using OpenTK;
    using OpenTK.Graphics;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    using TabbyCat.Commands;
    using TabbyCat.Common.Utility;
    using TabbyCat.Models;
    using TabbyCat.Views;

    internal class SceneController
    {
        internal SceneController()
        {
            SceneForm = new SceneForm();
            Scene = new Scene(this);
            ClockController = new ClockController(this);
            CommandProcessor = new CommandProcessor(this);
            JsonController = new JsonController(this);
            PropertyController = new PropertyController(this);
            RenderController = new RenderController(this);
            ConnectAll(true);
        }

        internal PropertyController PropertyController;

        private bool PropertyEditorVisible
        {
            get => PropertyController.FormVisible;
            set => PropertyController.FormVisible = value;
        }

        internal ClockController ClockController;
        internal CommandProcessor CommandProcessor { get; private set; }
        internal GLControl GLControl => SceneForm.GLControl;
        internal GLMode GLMode => RenderController._GLMode ?? RenderController?.GLMode;
        internal readonly RenderController RenderController;
        internal Scene Scene;
        internal SceneForm SceneForm;

        #region Internal Methods

        internal void LoadFromFile(string filePath) => JsonController.LoadFromFile(filePath);
        internal void ModifiedChanged() => SceneForm.Text = JsonController.WindowCaption;
        internal void SetGLMode(GLMode mode) => RecreateGLControl(mode);
        internal void Show() => SceneForm.Show();
        internal void Show(IWin32Window owner) => SceneForm.Show(owner);

        #endregion

        #region Private Properties

        private readonly List<string> ChangedPropertyNames = new List<string>();
        private readonly JsonController JsonController;

        #endregion

        internal event PropertyChangedEventHandler PropertyChanged;

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
        // GLControl
        private void GLControl_BackColorChanged(object sender, EventArgs e) => BackColorChanged();
        private void GLControl_ClientSizeChanged(object sender, EventArgs e) => Resize();
        private void GLControl_Load(object sender, EventArgs e) { }
        private void GLControl_Paint(object sender, PaintEventArgs e) => RenderController.Render();
        private void GLControl_Resize(object sender, EventArgs e) { }
        // Json
        private void JsonController_FileLoaded(object sender, EventArgs e) => FileLoaded();
        private void JsonController_FilePathChanged(object sender, EventArgs e) => UpdateCaption();
        private void JsonController_FilePathRequest(object sender, SdiController.FilePathEventArgs e) => FilePathRequest(e);
        private void JsonController_FileReopen(object sender, SdiController.FilePathEventArgs e) => OpenFile(e.FilePath);
        private void JsonController_FileSaved(object sender, EventArgs e) => FileSaved();
        private void JsonController_FileSaving(object sender, CancelEventArgs e) => e.Cancel = false;

        #endregion

        private int UpdateCount;

        #region Private Methods

        private void BackColorChanged() => GLControl.Parent.BackColor = Scene.BackgroundColour;

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

        private void ConnectControllers(bool connect)
        {
            if (connect)
            {
                //PropertyGridController.SelectedObject = Scene;
            }
            else
            {
                //PropertyGridController.SelectedObject = null;
                RenderController.Unload();
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
                // Json
                JsonController.FileLoaded += JsonController_FileLoaded;
                JsonController.FilePathChanged += JsonController_FilePathChanged;
                JsonController.FilePathRequest += JsonController_FilePathRequest;
                JsonController.FileReopen += JsonController_FileReopen;
                JsonController.FileSaving += JsonController_FileSaving;
                JsonController.FileSaved += JsonController_FileSaved;
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
                // Json
                JsonController.FileLoaded -= JsonController_FileLoaded;
                JsonController.FilePathChanged -= JsonController_FilePathChanged;
                JsonController.FilePathRequest -= JsonController_FilePathRequest;
                JsonController.FileReopen -= JsonController_FileReopen;
                JsonController.FileSaving -= JsonController_FileSaving;
                JsonController.FileSaved -= JsonController_FileSaved;
            }
        }

        private void ConnectGLControl(bool connect)
        {
            if (connect)
            {
                GLControl.BackColorChanged += GLControl_BackColorChanged;
                GLControl.ClientSizeChanged += GLControl_ClientSizeChanged;
                GLControl.Load += GLControl_Load;
                GLControl.Paint += GLControl_Paint;
                GLControl.Resize += GLControl_Resize;
            }
            else
            {
                GLControl.BackColorChanged -= GLControl_BackColorChanged;
                GLControl.ClientSizeChanged -= GLControl_ClientSizeChanged;
                GLControl.Load -= GLControl_Load;
                GLControl.Paint -= GLControl_Paint;
                GLControl.Resize -= GLControl_Resize;
            }
        }

        private void FileLoaded()
        {
            ConnectControllers(false);
            Scene.SceneController = this;
            BeginUpdate();
            Scene.AttachTraces();
            CommandProcessor.Clear();
            EndUpdate();
            ConnectControllers(true);
            RecreateGLControl(Scene.GLMode);
        }

        private void FilePathRequest(SdiController.FilePathEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.FilePath))
                e.FilePath = Scene.Title.ToFilename();
        }

        private void FileSaved()
        {
            BeginUpdate();
            CommandProcessor.Save();
            EndUpdate();
        }

        private void FormClosed() => ConnectAll(false);

        private bool FormClosing(CloseReason _) => JsonController.SaveIfModified();

        private SceneController GetNewSceneController()
        {
            if (AppController.Options.OpenInNewWindow)
                return AppController.AddNewSceneController();
            if (!JsonController.SaveIfModified())
                return null;
            JsonController.Clear();
            return this;
        }

        private void NewEmptyScene()
        {
            GetNewSceneController();
            CommandProcessor.Clear();
        }

        private void NewFromTemplate()
        {
            var sceneController = OpenFile(FilterIndex.Template);
            if (sceneController != null)
                sceneController.JsonController.FilePath = string.Empty;
        }

        private SceneController OpenFile(FilterIndex filterIndex = FilterIndex.File) =>
            OpenFile(JsonController.SelectFilePath(filterIndex));

        private SceneController OpenFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return null;
            var sceneController = GetNewSceneController();
            sceneController?.LoadFromFile(filePath);
            return sceneController;
        }

        private void RecreateGLControl(GraphicsMode mode = null)
        {
            BackColorChanged();
            ConnectGLControl(false);
            var control = GLControl;
            var controls = GLControl.Parent.Controls;
            controls.Remove(control);
            control.Dispose();
            control = mode == null ? new GLControl() : new GLControl(mode);
            control.BackColor = Scene.BackgroundColour;
            control.Dock = DockStyle.Fill;
            control.Location = new System.Drawing.Point(0, 0);
            control.Name = "GLControl";
            control.Size = new System.Drawing.Size(100, 100);
            control.TabIndex = 1;
            control.VSync = Scene.VSync;
            controls.Add(control);
            ConnectGLControl(true);
            RenderController.Refresh();
        }

        private void Resize() => RenderController.InvalidateProjection();

        private bool SaveFile() => JsonController.Save();

        private bool SaveFileAs() => JsonController.SaveAs();

        private bool SaveOrSaveAs() => Scene.IsModified ? SaveFile() : SaveFileAs();

        private void UpdateCaption() { SceneForm.Text = JsonController.WindowCaption; }

        #endregion

        internal void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        internal void BeginUpdate() => ++UpdateCount;

        internal void EndUpdate()
        {
            if (--UpdateCount == 0)
            {
                foreach (var propertyName in ChangedPropertyNames)
                    OnPropertyChanged(propertyName);
                ChangedPropertyNames.Clear();
            }
        }
    }
}
