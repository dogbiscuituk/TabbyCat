﻿namespace TabbyCat.Controllers
{
    using Jmk.Common;
    using OpenTK;
    using OpenTK.Graphics;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using TabbyCat.Commands;
    using TabbyCat.Common.Utility;
    using TabbyCat.Models;
    using TabbyCat.Properties;
    using TabbyCat.Views;

    internal class WorldController
    {
        #region Constructor

        internal WorldController()
        {
            WorldForm = new WorldForm();
            Scene = new Scene(this);
            ClockController = new ClockController(this);
            CommandProcessor = new CommandProcessor(this);
            new FullScreenController(this);
            JsonController = new JsonController(this);
            PropertiesController = new PropertiesController(this);
            RenderController = new RenderController(this);
            ConnectAll(true);
        }

        #endregion

        #region Fields, Properties, Events

        internal ClockController ClockController;
        internal CommandProcessor CommandProcessor { get; private set; }
        internal GLControl GLControl => GLControlParent[0] as GLControl;
        internal PropertiesController PropertiesController;
        internal GLInfo GLInfo => RenderController._GLInfo ?? RenderController?.GLInfo;
        internal GLMode GLMode => RenderController._GLMode ?? RenderController?.GLMode;
        internal readonly RenderController RenderController;
        internal Scene Scene;
        internal Selection Selection = new Selection();
        internal ToolTip ToolTip => WorldForm.ToolTip;
        internal WorldForm WorldForm;

        internal event PropertyChangedEventHandler PropertyChanged;
        internal event EventHandler SelectionChanged;

        private readonly List<string> ChangedPropertyNames = new List<string>();
        private Clock Clock => ClockController.Clock;
        private Control.ControlCollection GLControlParent => WorldForm?.SplitContainer1.Panel1.Controls;
        private string GLSLUrl => Settings.Default.GLSLUrl;
        private readonly JsonController JsonController;

        #endregion

        #region Internal Methods

        internal void LoadFromFile(string filePath) => JsonController.LoadFromFile(filePath);
        internal void ModifiedChanged() => WorldForm.Text = JsonController.WindowCaption;
        internal void Show() => WorldForm.Show();
        internal void Show(IWin32Window owner) => WorldForm.Show(owner);

        #endregion

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
        private void FileClose_Click(object sender, System.EventArgs e) => WorldForm.Close();
        private void FileExit_Click(object sender, System.EventArgs e) => AppController.Close();
        private void EditSelectAll_Click(object sender, EventArgs e) => SelectAll();
        private void EditInvertSelection_Click(object sender, EventArgs e) => InvertSelection();
        private void EditOptions_Click(object sender, EventArgs e) => EditOptions();
        private void EditRefresh_Click(object sender, EventArgs e) => RenderController.Refresh();
        private void SceneAddNewTrace_Click(object sender, EventArgs e) => AddNewTrace();
        private void HelpAbout_Click(object sender, EventArgs e) => HelpAbout();
        private void HelpTheOpenGLShadingLanguage_Click(object sender, EventArgs e) => ShowOpenGLSLBook();
        // WorldForm
        private void WorldForm_FormClosed(object sender, FormClosedEventArgs e) => FormClosed();
        private void WorldForm_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !FormClosing(e.CloseReason);
        // Selection
        private void Selection_Changed(object sender, EventArgs e) => OnSelectionChanged();
        // Toolbar
        private void TbOpen_DropDownOpening(object sender, EventArgs e) => WorldForm.FileReopen.CloneTo(WorldForm.tbOpen);
        private void TbSave_Click(object sender, EventArgs e) => SaveOrSaveAs();

        #endregion

        private int UpdateCount;

        #region Private Methods

        private void AddNewTrace()
        {
            CommandProcessor.AppendTrace();
            Selection.BeginUpdate();
            Selection.Clear();
            Selection.Add(Scene.Traces.Last());
            Selection.EndUpdate();
        }

        private void BackColorChanged() => GLControl.Parent.BackColor = Scene.BackgroundColour;

        internal void BeginUpdate() => ++UpdateCount;

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
            }
            else
            {
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
                WorldForm.FileNewEmptyScene.Click += FileNewEmptyScene_Click;
                WorldForm.FileNewFromTemplate.Click += FileNewFromTemplate_Click;
                WorldForm.FileOpen.Click += FileOpen_Click;
                WorldForm.FileSave.Click += FileSave_Click;
                WorldForm.FileSaveAs.Click += FileSaveAs_Click;
                WorldForm.FileClose.Click += FileClose_Click;
                WorldForm.FileExit.Click += FileExit_Click;
                WorldForm.EditSelectAll.Click += EditSelectAll_Click;
                WorldForm.EditInvertSelection.Click += EditInvertSelection_Click;
                WorldForm.EditOptions.Click += EditOptions_Click;
                WorldForm.EditRefresh.Click += EditRefresh_Click;
                WorldForm.SceneAddNewTrace.Click += SceneAddNewTrace_Click;
                WorldForm.HelpOpenGLShadingLanguage.Click += HelpTheOpenGLShadingLanguage_Click;
                WorldForm.HelpAbout.Click += HelpAbout_Click;
                // WorldForm
                WorldForm.FormClosed += WorldForm_FormClosed;
                WorldForm.FormClosing += WorldForm_FormClosing;
                // Selection
                Selection.Changed += Selection_Changed;
                // Toolbar
                WorldForm.tbAdd.Click += SceneAddNewTrace_Click;
                WorldForm.tbNew.ButtonClick += FileNewEmptyScene_Click;
                WorldForm.tbNewEmptyScene.Click += FileNewEmptyScene_Click;
                WorldForm.tbNewFromTemplate.Click += FileNewFromTemplate_Click;
                WorldForm.tbOpen.ButtonClick += FileOpen_Click;
                WorldForm.tbOpen.DropDownOpening += TbOpen_DropDownOpening;
                WorldForm.tbSave.Click += TbSave_Click;
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
                WorldForm.FileNewEmptyScene.Click -= FileNewEmptyScene_Click;
                WorldForm.FileNewFromTemplate.Click -= FileNewFromTemplate_Click;
                WorldForm.FileOpen.Click -= FileOpen_Click;
                WorldForm.FileSave.Click -= FileSave_Click;
                WorldForm.FileSaveAs.Click -= FileSaveAs_Click;
                WorldForm.FileClose.Click -= FileClose_Click;
                WorldForm.FileExit.Click -= FileExit_Click;
                WorldForm.EditSelectAll.Click -= EditSelectAll_Click;
                WorldForm.EditInvertSelection.Click -= EditInvertSelection_Click;
                WorldForm.EditOptions.Click -= EditOptions_Click;
                WorldForm.EditRefresh.Click -= EditRefresh_Click;
                WorldForm.SceneAddNewTrace.Click -= SceneAddNewTrace_Click;
                WorldForm.HelpOpenGLShadingLanguage.Click -= HelpTheOpenGLShadingLanguage_Click;
                WorldForm.HelpAbout.Click -= HelpAbout_Click;
                // WorldForm
                WorldForm.FormClosed -= WorldForm_FormClosed;
                WorldForm.FormClosing -= WorldForm_FormClosing;
                // Selection
                Selection.Changed -= Selection_Changed;
                // Toolbar
                WorldForm.tbAdd.Click -= SceneAddNewTrace_Click;
                WorldForm.tbNew.ButtonClick -= FileNewEmptyScene_Click;
                WorldForm.tbNewEmptyScene.Click -= FileNewEmptyScene_Click;
                WorldForm.tbNewFromTemplate.Click -= FileNewFromTemplate_Click;
                WorldForm.tbOpen.ButtonClick -= FileOpen_Click;
                WorldForm.tbOpen.DropDownOpening -= TbOpen_DropDownOpening;
                WorldForm.tbSave.Click -= TbSave_Click;
            }
            ConnectGLControl(connect);
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
                optionsController.ShowModal(WorldForm);
        }

        internal void EndUpdate()
        {
            if (--UpdateCount == 0)
            {
                foreach (var propertyName in ChangedPropertyNames)
                    OnPropertyChanged(propertyName);
                ChangedPropertyNames.Clear();
            }
        }

        private void FileLoaded()
        {
            ConnectControllers(false);
            Scene.WorldController = this;
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

        private WorldController GetNewWorldController()
        {
            if (AppController.Options.OpenInNewWindow)
                return AppController.AddNewWorldController();
            if (!JsonController.SaveIfModified())
                return null;
            JsonController.Clear();
            return this;
        }

        private void HelpAbout() => new AboutController().ShowDialog(WorldForm);

        private void InvertSelection() => Selection.Set(Scene.Traces.Where(p => !Selection.Contains(p)).ToList());

        private void NewEmptyScene()
        {
            GetNewWorldController();
            CommandProcessor.Clear();
        }

        private void NewFromTemplate()
        {
            var worldController = OpenFile(FilterIndex.Template);
            if (worldController != null)
                worldController.JsonController.FilePath = string.Empty;
        }

        private WorldController OpenFile(FilterIndex filterIndex = FilterIndex.File) =>
            OpenFile(JsonController.SelectFilePath(filterIndex));

        private WorldController OpenFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return null;
            var worldController = GetNewWorldController();
            worldController?.LoadFromFile(filePath);
            return worldController;
        }

        private void Resize() => RenderController.InvalidateProjection();

        private bool SaveFile() => JsonController.Save();

        private bool SaveFileAs() => JsonController.SaveAs();

        private bool SaveOrSaveAs() => Scene.IsModified ? SaveFile() : SaveFileAs();

        private void SelectAll() => Selection.AddRange(Scene.Traces);

        internal void ShowOpenGLSLBook() => $"{GLSLUrl}".Launch();

        private void UpdateCaption() { WorldForm.Text = JsonController.WindowCaption; }

        #endregion

        internal void OnPropertyChanged(string propertyName)
        {
            switch (propertyName)
            {
                case PropertyNames.Traces:
                    UpdateSelection();
                    RenderController.InvalidateProgram();
                    break;
                case PropertyNames.FPS:
                    ClockInit();
                    break;
                case PropertyNames.CameraPosition:
                case PropertyNames.CameraFocus:
                    RenderController.InvalidateCameraView();
                    break;
                case PropertyNames.GLTargetVersion:
                case PropertyNames.SceneVertex:
                case PropertyNames.SceneTessControl:
                case PropertyNames.SceneTessEvaluation:
                case PropertyNames.SceneGeometry:
                case PropertyNames.SceneFragment:
                case PropertyNames.SceneCompute:
                case PropertyNames.TraceVertex:
                case PropertyNames.TraceTessControl:
                case PropertyNames.TraceTessEvaluation:
                case PropertyNames.TraceGeometry:
                case PropertyNames.TraceFragment:
                case PropertyNames.TraceCompute:
                    RenderController.InvalidateProgram();
                    break;
                case PropertyNames.ProjectionType:
                case PropertyNames.FieldOfView:
                case PropertyNames.NearPlane:
                case PropertyNames.FarPlane:
                    RenderController.InvalidateProjection();
                    break;
                case PropertyNames.Samples:
                    RecreateGLControl(new GLMode(GLMode, propertyName, Scene.Samples));
                    break;
                case PropertyNames.Pattern:
                case PropertyNames.StripCount:
                    RenderController.InvalidateAllTraces();
                    break;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            GLControl.Invalidate();
        }

        private void OnSelectionChanged() => SelectionChanged?.Invoke(this, EventArgs.Empty);

        private void RecreateGLControl(GraphicsMode mode = null)
        {
            GLControl
                oldControl = GLControl,
                newControl = mode == null ? new GLControl() : new GLControl(mode);
            newControl.BackColor = Scene.BackgroundColour;
            newControl.Dock = DockStyle.Fill;
            newControl.Location = new System.Drawing.Point(0, 0);
            newControl.Name = "GLControl";
            newControl.Size = new System.Drawing.Size(100, 100);
            newControl.TabIndex = 1;
            newControl.VSync = Scene.VSync;
            BackColorChanged();
            GLControlParent.Owner.SuspendLayout();
            ConnectGLControl(false);
            GLControlParent.Remove(oldControl);
            GLControlParent.Add(newControl);
            ConnectGLControl(true);
            RenderController.Refresh();
            GLControlParent.Owner.ResumeLayout();
            oldControl.Dispose();
        }

        private void UpdateSelection()
        {
            Selection.BeginUpdate();
            Selection
                .Where(p => !Scene.Traces.Contains(p))
                .ToList()
                .ForEach(p => Selection.Remove(p));
            Selection.EndUpdate();
        }
    }
}
