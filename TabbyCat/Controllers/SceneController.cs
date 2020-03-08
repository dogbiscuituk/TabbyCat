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


        internal ClockController ClockController;
        internal CommandProcessor CommandProcessor { get; private set; }
        internal GLControl GLControl => SceneForm.GLControl;
        internal PropertyController PropertyController;
        internal GLMode GLMode => RenderController._GLMode ?? RenderController?.GLMode;
        internal readonly RenderController RenderController;
        internal Scene Scene;
        internal SceneForm SceneForm;
        internal Selection Selection = new Selection();

        #region Internal Methods

        internal void LoadFromFile(string filePath) => JsonController.LoadFromFile(filePath);
        internal void ModifiedChanged() => SceneForm.Text = JsonController.WindowCaption;
        internal void SetGLMode(GLMode mode) => RecreateGLControl(mode);
        internal void Show() => SceneForm.Show();
        internal void Show(IWin32Window owner) => SceneForm.Show(owner);

        #endregion

        #region Private Properties

        private readonly List<string> ChangedPropertyNames = new List<string>();
        private Clock Clock => ClockController.Clock;
        private const string GLSLUrl = "https://www.khronos.org/registry/OpenGL/specs/gl/GLSLangSpec.4.60.html";
        private readonly JsonController JsonController;

        #endregion

        internal event PropertyChangedEventHandler PropertyChanged;
        internal event EventHandler SelectionChanged;

        #region Private Event Handlers

        // Clock
        private void Clock_Tick(object sender, EventArgs e) { RenderController.Render(); }
        // GLControl
        private void GLControl_BackColorChanged(object sender, EventArgs e) => BackColorChanged();
        private void GLControl_ClientSizeChanged(object sender, EventArgs e) => Resize();
        private void GLControl_Load(object sender, EventArgs e) { }
        private void GLControl_Paint(object sender, PaintEventArgs e) => RenderController.Render();
        private void GLControl_Resize(object sender, EventArgs e) { }
        // JsonController
        private void JsonController_FileLoaded(object sender, EventArgs e) => FileLoaded();
        private void JsonController_FilePathChanged(object sender, EventArgs e) => UpdateCaption();
        private void JsonController_FilePathRequest(object sender, SdiController.FilePathEventArgs e) => FilePathRequest(e);
        private void JsonController_FileReopen(object sender, SdiController.FilePathEventArgs e) => OpenFile(e.FilePath);
        private void JsonController_FileSaved(object sender, EventArgs e) => FileSaved();
        private void JsonController_FileSaving(object sender, CancelEventArgs e) => e.Cancel = false;
        // Menu
        private void FileNewEmptyScene_Click(object sender, System.EventArgs e) => NewEmptyScene();
        private void FileNewFromTemplate_Click(object sender, System.EventArgs e) => NewFromTemplate();
        private void FileOpen_Click(object sender, System.EventArgs e) => OpenFile();
        private void FileSave_Click(object sender, System.EventArgs e) => SaveFile();
        private void FileSaveAs_Click(object sender, System.EventArgs e) => SaveFileAs();
        private void FileClose_Click(object sender, System.EventArgs e) => SceneForm.Close();
        private void FileExit_Click(object sender, System.EventArgs e) => AppController.Close();
        private void EditOptions_Click(object sender, EventArgs e) => EditOptions();
        private void EditRefresh_Click(object sender, EventArgs e) => RenderController.Refresh();
        private void SceneAddNewTrace_Click(object sender, EventArgs e) => CommandProcessor.AppendTrace();
        private void HelpAbout_Click(object sender, EventArgs e) => HelpAbout();
        private void HelpTheOpenGLShadingLanguage_Click(object sender, EventArgs e) => ShowOpenGLSLBook();
        // SceneForm
        private void SceneForm_FormClosed(object sender, FormClosedEventArgs e) => FormClosed();
        private void SceneForm_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !FormClosing(e.CloseReason);
        // Toolbar
        private void TbOpen_DropDownOpening(object sender, EventArgs e) => SceneForm.FileReopen.CloneTo(SceneForm.tbOpen);
        private void TbSave_Click(object sender, EventArgs e) => SaveOrSaveAs();

        #endregion

        private int UpdateCount;

        #region Private Methods

        private void BackColorChanged() => GLControl.Parent.BackColor = Scene.BackgroundColour;

        private void ClockInit() => Clock.Interval_ms = GetFrameMilliseconds();

        private void ClockShutdown() => Clock.Stop();

        private void ClockStartup()
        {
            ClockInit();
            Clock.Start();
            ClockController.UpdateTimeControls();
        }

        private void ConnectAll(bool connect)
        {
            if (connect)
            {
                ConnectEventHandlers(true);
                ConnectControllers(true);
                CommandProcessor.Clear();
                Clock.Tick += Clock_Tick;
                ClockStartup();
            }
            else
            {
                ClockShutdown();
                Clock.Tick -= Clock_Tick;
                RenderController.InvalidateProgram();
                CommandProcessor.Clear();
                ConnectControllers(false);
                ConnectEventHandlers(false);
                AppController.Remove(this);
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
                // JsonController
                JsonController.FileLoaded += JsonController_FileLoaded;
                JsonController.FilePathChanged += JsonController_FilePathChanged;
                JsonController.FilePathRequest += JsonController_FilePathRequest;
                JsonController.FileReopen += JsonController_FileReopen;
                JsonController.FileSaving += JsonController_FileSaving;
                JsonController.FileSaved += JsonController_FileSaved;
                // Menu
                SceneForm.FileNewEmptyScene.Click += FileNewEmptyScene_Click;
                SceneForm.FileNewFromTemplate.Click += FileNewFromTemplate_Click;
                SceneForm.FileOpen.Click += FileOpen_Click;
                SceneForm.FileSave.Click += FileSave_Click;
                SceneForm.FileSaveAs.Click += FileSaveAs_Click;
                SceneForm.FileClose.Click += FileClose_Click;
                SceneForm.FileExit.Click += FileExit_Click;
                SceneForm.EditOptions.Click += EditOptions_Click;
                SceneForm.EditRefresh.Click += EditRefresh_Click;
                SceneForm.SceneAddNewTrace.Click += SceneAddNewTrace_Click;
                SceneForm.HelpOpenGLShadingLanguage.Click += HelpTheOpenGLShadingLanguage_Click;
                SceneForm.HelpAbout.Click += HelpAbout_Click;
                // SceneForm
                SceneForm.FormClosed += SceneForm_FormClosed;
                SceneForm.FormClosing += SceneForm_FormClosing;
                // Toolbar
                SceneForm.tbAdd.Click += SceneAddNewTrace_Click;
                SceneForm.tbNew.ButtonClick += FileNewEmptyScene_Click;
                SceneForm.tbNewEmptyScene.Click += FileNewEmptyScene_Click;
                SceneForm.tbNewFromTemplate.Click += FileNewFromTemplate_Click;
                SceneForm.tbOpen.ButtonClick += FileOpen_Click;
                SceneForm.tbOpen.DropDownOpening += TbOpen_DropDownOpening;
                SceneForm.tbSave.Click += TbSave_Click;
            }
            else
            {
                // JsonController
                JsonController.FileLoaded -= JsonController_FileLoaded;
                JsonController.FilePathChanged -= JsonController_FilePathChanged;
                JsonController.FilePathRequest -= JsonController_FilePathRequest;
                JsonController.FileReopen -= JsonController_FileReopen;
                JsonController.FileSaving -= JsonController_FileSaving;
                JsonController.FileSaved -= JsonController_FileSaved;
                // Menu
                SceneForm.FileNewEmptyScene.Click -= FileNewEmptyScene_Click;
                SceneForm.FileNewFromTemplate.Click -= FileNewFromTemplate_Click;
                SceneForm.FileOpen.Click -= FileOpen_Click;
                SceneForm.FileSave.Click -= FileSave_Click;
                SceneForm.FileSaveAs.Click -= FileSaveAs_Click;
                SceneForm.FileClose.Click -= FileClose_Click;
                SceneForm.FileExit.Click -= FileExit_Click;
                SceneForm.EditOptions.Click -= EditOptions_Click;
                SceneForm.EditRefresh.Click -= EditRefresh_Click;
                SceneForm.SceneAddNewTrace.Click -= SceneAddNewTrace_Click;
                SceneForm.HelpOpenGLShadingLanguage.Click -= HelpTheOpenGLShadingLanguage_Click;
                SceneForm.HelpAbout.Click -= HelpAbout_Click;
                // SceneForm
                SceneForm.FormClosed -= SceneForm_FormClosed;
                SceneForm.FormClosing -= SceneForm_FormClosing;
                // Toolbar
                SceneForm.tbAdd.Click -= SceneAddNewTrace_Click;
                SceneForm.tbNew.ButtonClick -= FileNewEmptyScene_Click;
                SceneForm.tbNewEmptyScene.Click -= FileNewEmptyScene_Click;
                SceneForm.tbNewFromTemplate.Click -= FileNewFromTemplate_Click;
                SceneForm.tbOpen.ButtonClick -= FileOpen_Click;
                SceneForm.tbOpen.DropDownOpening -= TbOpen_DropDownOpening;
                SceneForm.tbSave.Click -= TbSave_Click;
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

        private void EditOptions()
        {
            using (var optionsController = new OptionsController())
                optionsController.ShowModal(SceneForm);
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

        private int GetFrameMilliseconds() => (int)Math.Round(1000 / Math.Min(Math.Max(Scene.FPS, 1), int.MaxValue));

        private SceneController GetNewSceneController()
        {
            if (AppController.Options.OpenInNewWindow)
                return AppController.AddNewSceneController();
            if (!JsonController.SaveIfModified())
                return null;
            JsonController.Clear();
            return this;
        }

        private void HelpAbout() => new AboutController().ShowDialog(SceneForm);

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

        internal void ShowOpenGLSLBook() => $"{GLSLUrl}".Launch();

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

        internal void OnSelectionChanged() =>
            SelectionChanged?.Invoke(this, EventArgs.Empty);

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
