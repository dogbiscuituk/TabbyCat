namespace TabbyCat.Controllers
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
            Connect(true);
        }

        #endregion

        #region Internal Fields

        internal ClockController ClockController;
        internal PropertiesController PropertiesController;
        internal readonly RenderController RenderController;
        internal Scene Scene;
        internal Selection Selection = new Selection();
        internal WorldForm WorldForm;

        #endregion

        #region Internal Properties

        internal CommandProcessor CommandProcessor { get; private set; }
        internal GLControl GLControl => GLControlParent[0] as GLControl;
        internal GLInfo GLInfo => RenderController._GLInfo ?? RenderController?.GLInfo;
        internal GLMode GLMode => RenderController._GLMode ?? RenderController?.GLMode;
        internal ToolTip ToolTip => WorldForm.ToolTip;

        #endregion

        #region Internal Events

        internal event PropertyChangedEventHandler PropertyChanged;
        internal event EventHandler Pulse;
        internal event EventHandler SelectionChanged;

        #endregion

        #region Internal Methods

        internal void LoadFromFile(string filePath) => JsonController.LoadFromFile(filePath);
        internal void ModifiedChanged() => WorldForm.Text = JsonController.WindowCaption;
        internal void Show() => WorldForm.Show();
        internal void Show(IWin32Window owner) => WorldForm.Show(owner);

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

        internal void OnPulse()
        {
            UpdateToolbar();
            UpdateStatusBar();
            Pulse?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Private Fields

        private readonly List<string> ChangedPropertyNames = new List<string>();
        private readonly JsonController JsonController;
        private string LastSpeed, LastTime, LastFPS;
        private int UpdateCount;

        #endregion

        #region Private Properties

        private Clock Clock => ClockController.Clock;
        private Control.ControlCollection GLControlParent => WorldForm?.SplitContainer1.Panel1.Controls;
        private string GLSLUrl => Settings.Default.GLSLUrl;

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

        private void ClockInit() => Clock.Interval_ms = GetFrameMilliseconds();

        private void ClockShutdown() => Clock.Stop();

        private void ClockStartup()
        {
            ClockInit();
            Clock.Start();
            ClockController.UpdateTimeControls();
        }

        private void Connect(bool connect)
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
            ConnectJsonController(connect);
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

        private void CopyToClipboard() => JsonController.ClipboardCopy(Selection);

        private void DeleteSelection()
        {
            if (!Selection.Any())
                return;
            var indices = Selection.Select(p => p.Index).OrderByDescending(p => p).ToList();
            foreach (var index in indices)
                CommandProcessor.DeleteTrace(index);
            Selection.Clear();
        }

        private void EditOptions()
        {
            using (var optionsController = new OptionsController())
                optionsController.ShowModal(WorldForm);
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

        private void OnSelectionChanged()
        {
            UIController.EnableButtons(Selection.Any(), new ToolStripItem[] {
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
        }

        private void Resize() => RenderController.InvalidateProjection();

        private bool SaveFile() => JsonController.Save();

        private bool SaveFileAs() => JsonController.SaveAs();

        private bool SaveOrSaveAs() => Scene.IsModified ? SaveFile() : SaveFileAs();

        private void SelectAll() => Selection.AddRange(Scene.Traces);

        internal void ShowOpenGLSLBook() => $"{GLSLUrl}".Launch();

        private void UpdateCaption() { WorldForm.Text = JsonController.WindowCaption; }

        private void UpdateFramesPerSecond()
        {
            var fps = string.Format("FPS={0:f1}", RenderController.FramesPerSecond);
            if (LastFPS != fps)
                LastFPS = WorldForm.FPSlabel.Text = fps;
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
            var time = string.Format("t={0:f1}", Clock.VirtualSecondsElapsed);
            if (LastTime != time)
                LastTime = WorldForm.Tlabel.Text = time;
        }

        #endregion
    }
}
