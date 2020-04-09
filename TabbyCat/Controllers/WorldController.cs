namespace TabbyCat.Controllers
{
    using Jmk.Common;
    using OpenTK;
    using OpenTK.Graphics;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;
    using TabbyCat.Commands;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.Models;
    using TabbyCat.Views;
    using TabbyCat.Properties;

    internal class WorldController : LocalizationController, IDisposable
    {
        #region Constructor

        internal WorldController() : base(null)
        {
            WorldForm = new WorldForm();
            Scene = new Scene(this);
            CameraController = new CameraController(this);
            ClockController = new ClockController(this);
            CommandProcessor = new CommandProcessor(this);
            FullScreenController = new FullScreenController(this);
            JsonController = new JsonController(this);
            PropertiesController = new PropertiesController(this);
            RenderController = new RenderController(this);
            SceneController = new SceneController(this);
            ShaderController = new ShaderController(this);
            TraceController = new TraceController(this);
            Connect(true);
            PopupMenu_Opening(this, new CancelEventArgs());
            WorldController = this;
        }

        #endregion

        protected override ClockController ClockController { get; set; }

        internal override CommandProcessor CommandProcessor { get; set; }

        protected override PropertiesController PropertiesController { get; set; }

        protected override RenderController RenderController { get; set; }

        protected override SceneController SceneController { get; set; }

        protected override ShaderController ShaderController { get; set; }

        protected override TraceController TraceController { get; set; }

        protected internal override WorldForm WorldForm { get; set; }

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
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

        protected internal override Scene Scene { get; set; }

        #region Internal Fields

        internal TraceSelection Selection = new TraceSelection();

        #endregion

        #region Protected Internal Properties

        #endregion

        #region Internal Properties

        internal GLControl GLControl => GLControlParent[0] as GLControl;
        internal GLInfo GLInfo => RenderController._GLInfo ?? RenderController?.GLInfo;
        internal GraphicsMode GraphicsMode => RenderController._GraphicsMode ?? RenderController?.GraphicsMode;
        internal ToolTip ToolTip => WorldForm.ToolTip;

        #endregion

        #region Internal Events

        internal event PropertyChangedEventHandler PropertyChanged;
        internal event EventHandler Pulse;
        internal event EventHandler SelectionChanged;

        #endregion

        #region Internal Methods

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.Menu_File, WorldForm.FileMenu);
            Localize(Resources.Menu_File_New, WorldForm.FileNew, WorldForm.tbNew);
            Localize(Resources.Menu_File_New_EmptyScene, WorldForm.FileNewEmptyScene, WorldForm.tbNewEmptyScene);
            Localize(Resources.Menu_File_New_FromTemplate, WorldForm.FileNewFromTemplate, WorldForm.tbNewFromTemplate);
            Localize(Resources.Menu_File_Open, WorldForm.FileOpen, WorldForm.tbOpen);
            Localize(Resources.Menu_File_Reopen, WorldForm.FileReopen);
            Localize(Resources.Menu_File_Save, WorldForm.FileSave, WorldForm.tbSave);
            Localize(Resources.Menu_File_SaveAs, WorldForm.FileSaveAs);
            Localize(Resources.Menu_File_Close, WorldForm.FileClose);
            Localize(Resources.Menu_File_CloseAllAndExit, WorldForm.FileExit);
            Localize(Resources.Menu_Edit, WorldForm.EditMenu);
            Localize(Resources.Menu_Edit_AddANewTrace, WorldForm.EditAddNewTrace, WorldForm.tbAdd);
            Localize(Resources.Menu_Edit_Undo, WorldForm.EditUndo, WorldForm.tbUndo);
            Localize(Resources.Menu_Edit_Redo, WorldForm.EditRedo, WorldForm.tbRedo);
            Localize(Resources.Menu_Edit_Cut, WorldForm.EditCut, WorldForm.tbCut);
            Localize(Resources.Menu_Edit_Copy, WorldForm.EditCopy, WorldForm.tbCopy);
            Localize(Resources.Menu_Edit_Paste, WorldForm.EditPaste, WorldForm.tbPaste);
            Localize(Resources.Menu_Edit_Delete, WorldForm.EditDelete, WorldForm.tbDelete);
            Localize(Resources.Menu_Edit_SelectAll, WorldForm.EditSelectAll);
            Localize(Resources.Menu_Edit_InvertSelection, WorldForm.EditInvertSelection);
            Localize(Resources.Menu_Edit_Options, WorldForm.EditOptions);
            Localize(Resources.Menu_View, WorldForm.ViewMenu);
            Localize(Resources.Menu_View_FullScreen, WorldForm.ViewFullScreen);
            Localize(Resources.Menu_View_Properties, WorldForm.ViewProperties);
            Localize(Resources.Menu_Camera, WorldForm.CameraMenu);
            Localize(Resources.Menu_Camera_Strafe, WorldForm.CameraStrafe);
            Localize(Resources.Menu_Camera_Strafe_Down, WorldForm.CameraStrafeDown);
            Localize(Resources.Menu_Camera_Strafe_Left, WorldForm.CameraStrafeLeft);
            Localize(Resources.Menu_Camera_Strafe_Right, WorldForm.CameraStrafeRight);
            Localize(Resources.Menu_Camera_Strafe_Up, WorldForm.CameraStrafeUp);
            Localize(Resources.Menu_Camera_Move, WorldForm.CameraMove);
            Localize(Resources.Menu_Camera_Move_Down, WorldForm.CameraMoveDown);
            Localize(Resources.Menu_Camera_Move_Left, WorldForm.CameraMoveLeft);
            Localize(Resources.Menu_Camera_Move_Right, WorldForm.CameraMoveRight);
            Localize(Resources.Menu_Camera_Move_Up, WorldForm.CameraMoveUp);
            Localize(Resources.Menu_Camera_Move_Forward, WorldForm.CameraMoveForward);
            Localize(Resources.Menu_Camera_Move_Back, WorldForm.CameraMoveBack);
            Localize(Resources.Menu_Camera_RollLeft, WorldForm.CameraRollLeft);
            Localize(Resources.Menu_Camera_RollRight, WorldForm.CameraRollRight);
            Localize(Resources.Menu_Time, WorldForm.TimeMenu);
            Localize(Resources.Menu_Time_Accelerate, WorldForm.TimeAccelerate, WorldForm.tbAccelerate);
            Localize(Resources.Menu_Time_Decelerate, WorldForm.TimeDecelerate, WorldForm.tbDecelerate);
            Localize(Resources.Menu_Time_Forward, WorldForm.TimeForward, WorldForm.tbForward);
            Localize(Resources.Menu_Time_Pause, WorldForm.TimePause, WorldForm.tbPause);
            Localize(Resources.Menu_Time_Reverse, WorldForm.TimeReverse, WorldForm.tbReverse);
            Localize(Resources.Menu_Time_Stop, WorldForm.TimeStop, WorldForm.tbStop);
            Localize(Resources.Menu_Help, WorldForm.HelpMenu);
            Localize(Resources.Menu_Help_OpenGLShadingLanguage, WorldForm.HelpOpenGLShadingLanguage);
            Localize(string.Format(CultureInfo.CurrentCulture, Resources.Menu_Help_About, Application.ProductName), WorldForm.HelpAbout);
        }

        internal void LoadFromFile(string filePath) => JsonController.LoadFromFile(filePath);
        internal void ModifiedChanged() => WorldForm.Text = JsonController.WindowCaption;
        internal void Show() => WorldForm.Show();
        internal void Show(IWin32Window owner) => WorldForm.Show(owner);

        internal void OnPropertyChanged(string propertyName)
        {
            GraphicsMode gm;
            switch (propertyName)
            {
                case PropertyNames.Traces:
                    UpdateSelection();
                    RenderController.InvalidateProgram();
                    break;
                case PropertyNames.FPS:
                    ClockInit();
                    break;
                case PropertyNames.Camera:
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
                    gm = GraphicsMode;
                    RecreateGLControl(new GraphicsMode(
                        accum: gm.AccumulatorFormat,
                        buffers: gm.Buffers,
                        color: gm.ColorFormat,
                        depth: gm.Depth,
                        samples: Scene.Samples,
                        stencil: gm.Stencil,
                        stereo: gm.Stereo));
                    break;
                case PropertyNames.Stereo:
                    gm = GraphicsMode;
                    RecreateGLControl(new GraphicsMode(
                        accum: gm.AccumulatorFormat,
                        buffers: gm.Buffers,
                        color: gm.ColorFormat,
                        depth: gm.Depth,
                        samples: gm.Samples,
                        stencil: gm.Stencil,
                        stereo: Scene.Stereo));
                    break;
                case PropertyNames.Pattern:
                case PropertyNames.StripCount:
                    RenderController.InvalidateAllTraces();
                    break;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            GLControl.Invalidate();
        }

        internal void OnPulse()
        {
            UpdateToolbar();
            UpdateStatusBar();
            Pulse?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Private Fields

        private readonly CameraController CameraController;
        private readonly List<string> ChangedPropertyNames = new List<string>();
        private readonly FullScreenController FullScreenController;
        private readonly JsonController JsonController;
        private string LastSpeed, LastTime, LastFPS;
        private int UpdateCount;

        #endregion

        #region Private Properties

        private Control.ControlCollection GLControlParent => WorldForm?.SplitContainer1.Panel1.Controls;

        private static string GLSLUrl => Settings.Default.GLSLUrl;

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
        // Menus
        private void FileNewEmptyScene_Click(object sender, System.EventArgs e) => NewEmptyScene();
        private void FileNewFromTemplate_Click(object sender, System.EventArgs e) => NewFromTemplate();
        private void FileOpen_Click(object sender, System.EventArgs e) => OpenFile();
        private void FileSave_Click(object sender, System.EventArgs e) => SaveFile();
        private void FileSaveAs_Click(object sender, System.EventArgs e) => SaveFileAs();
        private void FileClose_Click(object sender, System.EventArgs e) => WorldForm.Close();
        private void FileExit_Click(object sender, System.EventArgs e) => AppController.Close();
        private void EditAddNewTrace_Click(object sender, EventArgs e) => AddNewTrace();
        private void EditCut_Click(object sender, EventArgs e) => CutToClipboard();
        private void EditCopy_Click(object sender, EventArgs e) => CopyToClipboard();
        private void EditPaste_Click(object sender, EventArgs e) => PasteFromClipboard();
        private void EditDelete_Click(object sender, EventArgs e) => DeleteSelection();
        private void EditSelectAll_Click(object sender, EventArgs e) => SelectAll();
        private void EditInvertSelection_Click(object sender, EventArgs e) => InvertSelection();
        private void EditOptions_Click(object sender, EventArgs e) => EditOptions();
        private void HelpAbout_Click(object sender, EventArgs e) => HelpAbout();
        private void HelpTheOpenGLShadingLanguage_Click(object sender, EventArgs e) => ShowOpenGLSLBook();
        private void PopupMenu_Opening(object sender, CancelEventArgs e) => WorldForm.MainMenu.CloneTo(WorldForm.PopupMenu);
        // WorldForm
        private void WorldForm_FormClosed(object sender, FormClosedEventArgs e) => FormClosed();
        private void WorldForm_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !FormClosing(e.CloseReason);
        // Selection
        private void Selection_Changed(object sender, EventArgs e) => OnSelectionChanged();
        // Toolbar
        private void TbOpen_DropDownOpening(object sender, EventArgs e) => WorldForm.FileReopen.CloneTo(WorldForm.tbOpen);
        private void TbSave_Click(object sender, EventArgs e) => SaveOrSaveAs();

        #endregion

        #region Private Methods

        private void AddNewTrace()
        {
            CommandProcessor.AppendTrace();
            Selection.Set(new[] { Scene.Traces.Last() });
        }

        private void BackColorChanged() => GLControl.Parent.BackColor = Scene.BackgroundColour;

        private void BeginUpdate() => ++UpdateCount;

        private void ClockInit() => Clock.IntervalMilliseconds = GetFrameMilliseconds();

        private void ClockShutdown() => Clock.Stop();

        private void ClockStartup()
        {
            ClockInit();
            Clock.Start();
            ClockController.UpdateTimeControls();
        }

        private void ConnectControllers(bool connect)
        {
            CameraController.Connect(connect);
            ClockController.Connect(connect);
            FullScreenController.Connect(connect);
            ConnectJsonController(connect);
            PropertiesController.Connect(connect);
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
            ConnectMainMenu(connect);
            ConnectToolbar(connect);
            if (connect)
            {
                WorldForm.FormClosed += WorldForm_FormClosed;
                WorldForm.FormClosing += WorldForm_FormClosing;
                Selection.Changed += Selection_Changed;
            }
            else
            {
                WorldForm.FormClosed -= WorldForm_FormClosed;
                WorldForm.FormClosing -= WorldForm_FormClosing;
                Selection.Changed -= Selection_Changed;
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

        private void ConnectJsonController(bool connect)
        {
            if (connect)
            {
                JsonController.FileLoaded += JsonController_FileLoaded;
                JsonController.FilePathChanged += JsonController_FilePathChanged;
                JsonController.FilePathRequest += JsonController_FilePathRequest;
                JsonController.FileReopen += JsonController_FileReopen;
                JsonController.FileSaving += JsonController_FileSaving;
                JsonController.FileSaved += JsonController_FileSaved;
            }
            else
            {
                JsonController.FileLoaded -= JsonController_FileLoaded;
                JsonController.FilePathChanged -= JsonController_FilePathChanged;
                JsonController.FilePathRequest -= JsonController_FilePathRequest;
                JsonController.FileReopen -= JsonController_FileReopen;
                JsonController.FileSaving -= JsonController_FileSaving;
                JsonController.FileSaved -= JsonController_FileSaved;
            }
        }

        private void ConnectMainMenu(bool connect)
        {
            if (connect)
            {
                WorldForm.FileNewEmptyScene.Click += FileNewEmptyScene_Click;
                WorldForm.FileNewFromTemplate.Click += FileNewFromTemplate_Click;
                WorldForm.FileOpen.Click += FileOpen_Click;
                WorldForm.FileSave.Click += FileSave_Click;
                WorldForm.FileSaveAs.Click += FileSaveAs_Click;
                WorldForm.FileClose.Click += FileClose_Click;
                WorldForm.FileExit.Click += FileExit_Click;
                WorldForm.EditAddNewTrace.Click += EditAddNewTrace_Click;
                WorldForm.EditCut.Click += EditCut_Click;
                WorldForm.EditCopy.Click += EditCopy_Click;
                WorldForm.EditPaste.Click += EditPaste_Click;
                WorldForm.EditDelete.Click += EditDelete_Click;
                WorldForm.EditSelectAll.Click += EditSelectAll_Click;
                WorldForm.EditInvertSelection.Click += EditInvertSelection_Click;
                WorldForm.EditOptions.Click += EditOptions_Click;
                WorldForm.HelpOpenGLShadingLanguage.Click += HelpTheOpenGLShadingLanguage_Click;
                WorldForm.HelpAbout.Click += HelpAbout_Click;
                WorldForm.PopupMenu.Opening += PopupMenu_Opening;
            }
            else
            {
                WorldForm.FileNewEmptyScene.Click -= FileNewEmptyScene_Click;
                WorldForm.FileNewFromTemplate.Click -= FileNewFromTemplate_Click;
                WorldForm.FileOpen.Click -= FileOpen_Click;
                WorldForm.FileSave.Click -= FileSave_Click;
                WorldForm.FileSaveAs.Click -= FileSaveAs_Click;
                WorldForm.FileClose.Click -= FileClose_Click;
                WorldForm.FileExit.Click -= FileExit_Click;
                WorldForm.EditAddNewTrace.Click -= EditAddNewTrace_Click;
                WorldForm.EditCut.Click -= EditCut_Click;
                WorldForm.EditCopy.Click -= EditCopy_Click;
                WorldForm.EditPaste.Click -= EditPaste_Click;
                WorldForm.EditDelete.Click -= EditDelete_Click;
                WorldForm.EditSelectAll.Click -= EditSelectAll_Click;
                WorldForm.EditInvertSelection.Click -= EditInvertSelection_Click;
                WorldForm.EditOptions.Click -= EditOptions_Click;
                WorldForm.HelpOpenGLShadingLanguage.Click -= HelpTheOpenGLShadingLanguage_Click;
                WorldForm.HelpAbout.Click -= HelpAbout_Click;
                WorldForm.PopupMenu.Opening -= PopupMenu_Opening;
            }
        }

        private void ConnectToolbar(bool connect)
        {
            if (connect)
            {
                WorldForm.tbAdd.Click += EditAddNewTrace_Click;
                WorldForm.tbCut.Click += EditCut_Click;
                WorldForm.tbCopy.Click += EditCopy_Click;
                WorldForm.tbPaste.Click += EditPaste_Click;
                WorldForm.tbDelete.Click += EditDelete_Click;
                WorldForm.tbNew.ButtonClick += FileNewEmptyScene_Click;
                WorldForm.tbNewEmptyScene.Click += FileNewEmptyScene_Click;
                WorldForm.tbNewFromTemplate.Click += FileNewFromTemplate_Click;
                WorldForm.tbOpen.ButtonClick += FileOpen_Click;
                WorldForm.tbOpen.DropDownOpening += TbOpen_DropDownOpening;
                WorldForm.tbSave.Click += TbSave_Click;
            }
            else
            {
                WorldForm.tbAdd.Click -= EditAddNewTrace_Click;
                WorldForm.tbCut.Click -= EditCut_Click;
                WorldForm.tbCopy.Click -= EditCopy_Click;
                WorldForm.tbPaste.Click -= EditPaste_Click;
                WorldForm.tbDelete.Click -= EditDelete_Click;
                WorldForm.tbNew.ButtonClick -= FileNewEmptyScene_Click;
                WorldForm.tbNewEmptyScene.Click -= FileNewEmptyScene_Click;
                WorldForm.tbNewFromTemplate.Click -= FileNewFromTemplate_Click;
                WorldForm.tbOpen.ButtonClick -= FileOpen_Click;
                WorldForm.tbOpen.DropDownOpening -= TbOpen_DropDownOpening;
                WorldForm.tbSave.Click -= TbSave_Click;
            }
        }

        private void CutToClipboard()
        {
            CopyToClipboard();
            DeleteSelection();
        }

        private void CopyToClipboard() => JsonController.ClipboardCopy(Selection.Traces);

        private void DeleteSelection()
        {
            if (Selection.IsEmpty)
                return;
            var indices = Selection.GetTraceIndices().OrderByDescending(p => p).ToList();
            foreach (var index in indices)
                CommandProcessor.DeleteTrace(index);
            Selection.Clear();
        }

        private void EditOptions()
        {
            using (var optionsController = new OptionsController(this))
                optionsController.ShowModal();
        }

        private void EndUpdate()
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
            RecreateGLControl(Scene.GraphicsMode);
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

        private void FormClosed() => Connect(false);

        private bool FormClosing(CloseReason _) => JsonController.SaveIfModified();

        private int GetFrameMilliseconds() => (int)Math.Round(1000f / Math.Min(Math.Max(Scene.FPS, 1), int.MaxValue));

        private WorldController GetNewWorldController()
        {
            if (AppController.Options.OpenInNewWindow)
                return AppController.AddNewWorldController();
            if (!JsonController.SaveIfModified())
                return null;
            JsonController.Clear();
            return this;
        }

        private void HelpAbout() => new AboutController(this).ShowDialog(WorldForm);

        private void InvertSelection() =>
            Selection.Set(Scene.Traces.Where(p => !Selection.Traces.Contains(p)).ToList());

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

        private void OnSelectionChanged()
        {
            UIController.EnableButtons(!Selection.IsEmpty, new ToolStripItem[] {
                WorldForm.EditCut,
                WorldForm.EditCopy,
                WorldForm.EditDelete,
                WorldForm.tbCut,
                WorldForm.tbCopy,
                WorldForm.tbDelete });
            SelectionChanged?.Invoke(this, EventArgs.Empty);
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

        private void PasteFromClipboard()
        {
            var traces = JsonController.ClipboardPaste();
            if (traces == null || !traces.Any())
                return;
            var index = Scene.Traces.Count;
            foreach (var trace in traces)
            {
                trace.Scene = Scene;
                CommandProcessor.Run(new TraceInsertCommand(index++) { Value = trace });
            }
            Selection.Set(traces);
        }

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
            RefreshGraphicsMode();
        }

        internal void RefreshGraphicsMode() => OnPropertyChanged(PropertyNames.GraphicsMode);

        private void Resize() => RenderController.InvalidateProjection();

        private bool SaveFile() => JsonController.Save();

        private bool SaveFileAs() => JsonController.SaveAs();

        private bool SaveOrSaveAs() => Scene.IsModified ? SaveFile() : SaveFileAs();

        private void SelectAll() => Selection.AddRange(Scene.Traces);

        internal void ShowOpenGLSLBook() => $"{GLSLUrl}".Launch();

        private void UpdateCaption() { WorldForm.Text = JsonController.WindowCaption; }

        private void UpdateFramesPerSecond()
        {
            var fps = string.Format(CultureInfo.CurrentCulture, "FPS={0:f1}", RenderController.FramesPerSecond);
            if (LastFPS != fps)
                LastFPS = WorldForm.FPSlabel.Text = fps;
        }

        private void UpdateSelection()
        {
            Selection.BeginUpdate();
            Selection.Traces
                .Where(p => !Scene.Traces.Contains(p))
                .ToList()
                .ForEach(p => Selection.Remove(p));
            Selection.EndUpdate();
        }

        private void UpdateStatusBar()
        {
            UpdateTimeFactor();
            UpdateVirtualTime();
            UpdateFramesPerSecond();
        }

        private void UpdateTimeFactor()
        {
            string speed;
            var factor = Clock.VirtualTimeFactor;
            if (factor == 0)
                speed = "time × 0";
            else
            {
                var divide = Math.Abs(factor) < 1;
                if (divide)
                    factor = 1 / factor;
                speed = divide ? $"time ÷ {factor}" : $"time × {factor}";
            }
            if (LastSpeed != speed)
                LastSpeed = WorldForm.SpeedLabel.Text = speed;

        }

        private void UpdateToolbar() =>
            WorldForm.EditPaste.Enabled = WorldForm.tbPaste.Enabled = AppController.CanPaste;

        private void UpdateVirtualTime()
        {
            var time = string.Format(CultureInfo.CurrentCulture, "t={0:f1}", Clock.VirtualSecondsElapsed);
            if (LastTime != time)
                LastTime = WorldForm.Tlabel.Text = time;
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    ClockController?.Dispose();
                    JsonController?.Dispose();
                    WorldForm?.Dispose();
                }
                disposed = true;
            }
        }

        private bool disposed;

        #endregion
    }
}
