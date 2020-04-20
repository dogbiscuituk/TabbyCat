﻿namespace TabbyCat.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Jmk.Common;
    using OpenTK;
    using OpenTK.Graphics;
    using TabbyCat.Commands;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utils;
    using TabbyCat.Models;
    using TabbyCat.Properties;
    using TabbyCat.Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal class WorldCon : LocalizationCon
    {
        internal WorldCon() : base(null)
        {
            WorldForm = new WorldForm();
            Scene = new Scene(this);
            AppCon.InitControlTheme(
                WorldPanel,
                WorldForm.MainMenu,
                WorldForm.PopupMenu,
                WorldForm.Toolbar,
                WorldForm.StatusBar);
            ShowControls();
            Connect(true);
            PopupMenu_Opening(this, new CancelEventArgs());
        }

        internal TraceSelection Selection = new TraceSelection();

        protected DockPane GraphicsStatePane => GraphicsStateForm.Pane;
        protected DockPane SceneCodePane => SceneCodeForm.Pane;
        protected DockPane ScenePane => SceneForm.Pane;
        protected DockPane ScenePropertiesPane => ScenePropertiesForm.Pane;
        protected DockPane ShaderCodePane => ShaderCodeForm.Pane;
        protected DockPane TraceCodePane => TraceCodeForm.Pane;
        protected DockPane TracePropertiesPane => TracePropertiesForm.Pane;
        protected DockPanel WorldPanel => WorldForm.DockPanel;

        private readonly List<string> ChangedPropertyNames = new List<string>();
        private string LastSpeed, LastTime, LastFPS;
        private int UpdateCount;

        private CameraCon _CameraCon;
        private ClockCon _ClockCon;
        private CommandProcessor _CommandProcessor;
        private GraphicsStateCon _GraphicsStateCon;
        private JsonCon _JsonCon;
        private CodeCon _SceneCodeCon, _ShaderCodeCon, _TraceCodeCon;
        private RenderCon _RenderCon;
        private SceneCon _SceneCon;
        private ScenePropertiesCon _ScenePropertiesCon;
        private TracePropertiesCon _TracePropertiesCon;

        protected internal override Scene Scene { get; set; }
        protected internal override WorldForm WorldForm { get; }

        internal override CommandProcessor CommandProcessor => _CommandProcessor ?? (_CommandProcessor = new CommandProcessor(this));

        protected override CameraCon CameraCon => _CameraCon ?? (_CameraCon = new CameraCon(this));
        protected override ClockCon ClockCon => _ClockCon ?? (_ClockCon = new ClockCon(this));
        protected override GraphicsStateCon GraphicsStateCon => _GraphicsStateCon ?? (_GraphicsStateCon = new GraphicsStateCon(this));
        protected override JsonCon JsonCon => _JsonCon ?? (_JsonCon = new JsonCon(this));
        protected override RenderCon RenderCon => _RenderCon ?? (_RenderCon = new RenderCon(this));
        protected override CodeCon SceneCodeCon => _SceneCodeCon ?? (_SceneCodeCon = new CodeCon(this, ShaderRegion.Scene));
        protected override SceneCon SceneCon => _SceneCon ?? (_SceneCon = new SceneCon(this));
        protected override ScenePropertiesCon ScenePropertiesCon => _ScenePropertiesCon ?? (_ScenePropertiesCon = new ScenePropertiesCon(this));
        protected override CodeCon ShaderCodeCon => _ShaderCodeCon ?? (_ShaderCodeCon = new CodeCon(this, ShaderRegion.All));
        protected override CodeCon TraceCodeCon => _TraceCodeCon ?? (_TraceCodeCon = new CodeCon(this, ShaderRegion.Trace));
        protected override TracePropertiesCon TracePropertiesCon => _TracePropertiesCon ?? (_TracePropertiesCon= new TracePropertiesCon(this));

        internal GLInfo GLInfo => RenderCon._GLInfo ?? RenderCon?.GLInfo;
        private static string GLSLUrl => Settings.Default.GLSLUrl;
        internal GraphicsMode GraphicsMode => RenderCon._GraphicsMode ?? RenderCon?.GraphicsMode;

        internal event PropertyChangedEventHandler PropertyChanged;
        internal event EventHandler
            Pulse,
            SelectionChanged;

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                ConnectEventHandlers(true);
                ConnectCons(true);
                CommandProcessor.Clear();
                Clock.Tick += Clock_Tick;
                ClockStartup();
            }
            else
            {
                ClockShutdown();
                Clock.Tick -= Clock_Tick;
                RenderCon.InvalidateProgram();
                CommandProcessor.Clear();
                ConnectCons(false);
                ConnectEventHandlers(false);
                AppCon.Remove(this);
            }
        }

        protected override void DisposeManagedState()
        {
            base.DisposeManagedState();
            ClockCon?.Dispose();
            JsonCon?.Dispose();
            WorldForm?.Dispose();
        }

        protected override void Localize()
        {
            base.Localize();
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
            Localize(Resources.Menu_View_Scene, WorldForm.ViewScene);
            Localize(Resources.Menu_View_SceneProperties, WorldForm.ViewSceneProperties);
            Localize(Resources.Menu_View_TraceProperties, WorldForm.ViewTraceProperties);
            Localize(Resources.Menu_View_AllCode, WorldForm.ViewAllCode);
            Localize(Resources.Menu_View_SceneCode, WorldForm.ViewSceneCode);
            Localize(Resources.Menu_View_TraceCode, WorldForm.ViewTraceCode);
            Localize(Resources.Menu_View_GraphicsState, WorldForm.ViewGraphicsState);
            Localize(Resources.Menu_Time_Accelerate, WorldForm.TimeAccelerate);
            Localize(Resources.Menu_Time_Decelerate, WorldForm.TimeDecelerate);
            Localize(Resources.Menu_Time_Forward, WorldForm.TimeForward);
            Localize(Resources.Menu_Time_Pause, WorldForm.TimePause);
            Localize(Resources.Menu_Time_Reverse, WorldForm.TimeReverse);
            Localize(Resources.Menu_Time_Stop, WorldForm.TimeStop);
            Localize(Resources.Menu_Help, WorldForm.HelpMenu);
            Localize(Resources.Menu_Help_OpenGLShadingLanguage, WorldForm.HelpOpenGLShadingLanguage);
            Localize(string.Format(CultureInfo.CurrentCulture, Resources.Menu_Help_About, Application.ProductName), WorldForm.HelpAbout);
        }

        protected internal override void UpdateAllProperties()
        {
            TracePropertiesCon.UpdateAllProperties();
            ScenePropertiesCon.UpdateAllProperties();
        }

        internal void LoadFromFile(string filePath) => JsonCon.LoadFromFile(filePath);

        internal void ModifiedChanged() => WorldForm.Text = JsonCon.WindowCaption;

        internal void Show() => WorldForm.Show();

        internal void Show(IWin32Window owner) => WorldForm.Show(owner);

        internal void OnPropertyChanged(string propertyName)
        {
            switch (propertyName)
            {
                case PropertyNames.Traces:
                    UpdateSelection();
                    break;
                case PropertyNames.FPS:
                    ClockInit();
                    break;
                case PropertyNames.Samples:
                    RecreateGLControl("Samples", Scene.Samples);
                    break;
                case PropertyNames.Stereo:
                    RecreateGLControl("Stereo", Scene.Stereo);
                    break;
                case PropertyNames.GPULog:
                case PropertyNames.GPUStatus:
                    UpdateGpuStatusLabel();
                    break;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            SceneControl.Invalidate();
        }

        internal void OnPulse()
        {
            UpdateToolbar();
            UpdateStatusBar();
            Pulse?.Invoke(this, EventArgs.Empty);
        }

        private void Clock_Tick(object sender, EventArgs e) { RenderCon.Render(); }

        private void GLControl_BackColorChanged(object sender, EventArgs e) => BackColorChanged();
        private void GLControl_ClientSizeChanged(object sender, EventArgs e) => Resize();
        private void GLControl_Load(object sender, EventArgs e) { }
        private void GLControl_Paint(object sender, PaintEventArgs e) => RenderCon.Render();
        private void GLControl_Resize(object sender, EventArgs e) { }

        private void JsonCon_FileLoaded(object sender, EventArgs e) => FileLoaded();
        private void JsonCon_FilePathChanged(object sender, EventArgs e) => UpdateCaption();
        private void JsonCon_FilePathRequest(object sender, SdiCon.FilePathEventArgs e) => FilePathRequest(e);
        private void JsonCon_FileReopen(object sender, SdiCon.FilePathEventArgs e) => OpenFile(e.FilePath);
        private void JsonCon_FileSaved(object sender, EventArgs e) => FileSaved();
        private void JsonCon_FileSaving(object sender, CancelEventArgs e) => e.Cancel = false;

        private void FileNewEmptyScene_Click(object sender, System.EventArgs e) => NewEmptyScene();
        private void FileNewFromTemplate_Click(object sender, System.EventArgs e) => NewFromTemplate();
        private void FileOpen_Click(object sender, System.EventArgs e) => OpenFile();
        private void FileSave_Click(object sender, System.EventArgs e) => SaveFile();
        private void FileSaveAs_Click(object sender, System.EventArgs e) => SaveFileAs();
        private void FileClose_Click(object sender, System.EventArgs e) => WorldForm.Close();
        private void FileExit_Click(object sender, System.EventArgs e) => AppCon.Close();
        private void EditAddNewTrace_Click(object sender, EventArgs e) => AddNewTrace();
        private void EditCut_Click(object sender, EventArgs e) => CutToClipboard();
        private void EditCopy_Click(object sender, EventArgs e) => CopyToClipboard();
        private void EditPaste_Click(object sender, EventArgs e) => PasteFromClipboard();
        private void EditDelete_Click(object sender, EventArgs e) => DeleteSelection();
        private void EditSelectAll_Click(object sender, EventArgs e) => SelectAll();
        private void EditInvertSelection_Click(object sender, EventArgs e) => InvertSelection();
        private void EditOptions_Click(object sender, EventArgs e) => EditOptions();
        private void ViewSceneProperties_Click(object sender, EventArgs e) => ToggleVisibility(ScenePropertiesCon);
        private void ViewTraceProperties_Click(object sender, EventArgs e) => ToggleVisibility(TracePropertiesCon);
        private void ViewViewGraphicsState_Click(object sender, EventArgs e) => ToggleVisibility(GraphicsStateCon);
        private void ViewSceneCode_Click(object sender, EventArgs e) => ToggleVisibility(SceneCodeCon);
        private void ViewTraceCode_Click(object sender, EventArgs e) => ToggleVisibility(TraceCodeCon);
        private void ViewGpuCode_Click(object sender, EventArgs e) => ToggleVisibility(ShaderCodeCon);
        private void ViewScene_Click(object sender, EventArgs e) => ToggleVisibility(SceneCon);
        private void HelpAbout_Click(object sender, EventArgs e) => HelpAbout();
        private void HelpTheOpenGLShadingLanguage_Click(object sender, EventArgs e) => ShowOpenGLSLBook();
        private void PopupMenu_Opening(object sender, CancelEventArgs e) => CreateMainMenuClone();

        private void WorldForm_FormClosed(object sender, FormClosedEventArgs e) => FormClosed();
        private void WorldForm_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !FormClosing(e.CloseReason);

        private void Selection_Changed(object sender, EventArgs e) => OnSelectionChanged();

        private void TbOpen_DropDownOpening(object sender, EventArgs e) => WorldForm.FileReopen.CloneTo(WorldForm.tbOpen);
        private void TbSave_Click(object sender, EventArgs e) => SaveOrSaveAs();

        private void AddNewTrace()
        {
            CommandProcessor.AppendTrace();
            Selection.Set(new[] { Scene.Traces.Last() });
        }

        private void BackColorChanged() => SceneControl.Parent.BackColor = Scene.BackgroundColour;

        private void BeginUpdate() => ++UpdateCount;

        private void ClockInit() => Clock.IntervalMilliseconds = GetFrameMilliseconds();

        private void ClockShutdown() => Clock.Stop();

        private void ClockStartup()
        {
            ClockInit();
            Clock.Start();
            ClockCon.UpdateTimeControls();
        }

        private void CreateMainMenuClone()
        {
            WorldForm.MainMenu.CloneTo(WorldForm.PopupMenu);
            WorldForm.PopupMenu.Items.Insert(6, new ToolStripSeparator());
        }

        private void ConnectCons(bool connect)
        {
            CameraCon.Connect(connect);
            ClockCon.Connect(connect);
            ConnectJsonCon(connect);
            GraphicsStateCon.Connect(connect);
            ShaderCodeCon.Connect(connect);
            RenderCon.Connect(connect);
            TracePropertiesCon.Connect(connect);
            TraceCodeCon.Connect(connect);
            ScenePropertiesCon.Connect(connect);
            SceneCodeCon.Connect(connect);
            if (connect)
            {
            }
            else
            {
                RenderCon.Unload();
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
                SceneControl.BackColorChanged += GLControl_BackColorChanged;
                SceneControl.ClientSizeChanged += GLControl_ClientSizeChanged;
                SceneControl.Load += GLControl_Load;
                SceneControl.Paint += GLControl_Paint;
                SceneControl.Resize += GLControl_Resize;
            }
            else
            {
                SceneControl.BackColorChanged -= GLControl_BackColorChanged;
                SceneControl.ClientSizeChanged -= GLControl_ClientSizeChanged;
                SceneControl.Load -= GLControl_Load;
                SceneControl.Paint -= GLControl_Paint;
                SceneControl.Resize -= GLControl_Resize;
            }
        }

        private void ConnectJsonCon(bool connect)
        {
            if (connect)
            {
                JsonCon.FileLoaded += JsonCon_FileLoaded;
                JsonCon.FilePathChanged += JsonCon_FilePathChanged;
                JsonCon.FilePathRequest += JsonCon_FilePathRequest;
                JsonCon.FileReopen += JsonCon_FileReopen;
                JsonCon.FileSaving += JsonCon_FileSaving;
                JsonCon.FileSaved += JsonCon_FileSaved;
            }
            else
            {
                JsonCon.FileLoaded -= JsonCon_FileLoaded;
                JsonCon.FilePathChanged -= JsonCon_FilePathChanged;
                JsonCon.FilePathRequest -= JsonCon_FilePathRequest;
                JsonCon.FileReopen -= JsonCon_FileReopen;
                JsonCon.FileSaving -= JsonCon_FileSaving;
                JsonCon.FileSaved -= JsonCon_FileSaved;
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
                WorldForm.ViewSceneProperties.Click += ViewSceneProperties_Click;
                WorldForm.ViewTraceProperties.Click += ViewTraceProperties_Click;
                WorldForm.ViewGraphicsState.Click += ViewViewGraphicsState_Click;
                WorldForm.ViewSceneCode.Click += ViewSceneCode_Click;
                WorldForm.ViewTraceCode.Click += ViewTraceCode_Click;
                WorldForm.ViewAllCode.Click += ViewGpuCode_Click;
                WorldForm.ViewScene.Click += ViewScene_Click;
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
                WorldForm.ViewSceneProperties.Click -= ViewSceneProperties_Click;
                WorldForm.ViewTraceProperties.Click -= ViewTraceProperties_Click;
                WorldForm.ViewGraphicsState.Click -= ViewViewGraphicsState_Click;
                WorldForm.ViewSceneCode.Click -= ViewSceneCode_Click;
                WorldForm.ViewTraceCode.Click -= ViewTraceCode_Click;
                WorldForm.ViewAllCode.Click -= ViewGpuCode_Click;
                WorldForm.ViewScene.Click -= ViewScene_Click;
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

        private void CopyToClipboard() => JsonCon.ClipboardCopy(Selection.Traces);

        private void CutToClipboard()
        {
            CopyToClipboard();
            DeleteSelection();
        }

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
            using (var optionsCon = new OptionsCon(this))
                optionsCon.ShowModal();
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
            ConnectCons(false);
            Scene.WorldCon = this;
            BeginUpdate();
            Scene.AttachTraces();
            CommandProcessor.Clear();
            EndUpdate();
            ConnectCons(true);
            RecreateGLControl();
            SetDefaultCamera();
            UpdateAllProperties();
        }

        private void FilePathRequest(SdiCon.FilePathEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.FilePath))
                e.FilePath = Scene.Title.ToFilename();
        }

        private void FileSaved()
        {
            BeginUpdate();
            CommandProcessor.Save();
            EndUpdate();
            SetDefaultCamera();
            UpdateAllProperties();
        }

        private void FormClosed() => Connect(false);

        private bool FormClosing(CloseReason _) => JsonCon.SaveIfModified();

        private int GetFrameMilliseconds() => (int)Math.Round(1000f / Math.Min(Math.Max(Scene.FPS, 1), int.MaxValue));

        private WorldCon GetNewWorldCon()
        {
            if (AppCon.Options.OpenInNewWindow)
                return AppCon.AddNewWorldCon();
            if (!JsonCon.SaveIfModified())
                return null;
            JsonCon.Clear();
            SetDefaultCamera();
            return this;
        }

        private void HelpAbout()
        {
            using (AboutCon aboutCon = new AboutCon(this))
                aboutCon.ShowDialog(WorldForm);
        }

        private void InvertSelection() => Selection.Set(Scene.Traces.Where(p => !Selection.Traces.Contains(p)).ToList());

        private void NewEmptyScene() => GetNewWorldCon();

        private void NewFromTemplate()
        {
            var worldCon = OpenFile(FilterIndex.Template);
            if (worldCon != null)
                worldCon.JsonCon.FilePath = string.Empty;
        }

        private void OnSelectionChanged()
        {
            ToolStripUtils.EnableButtons(!Selection.IsEmpty, new ToolStripItem[] {
                WorldForm.EditCut,
                WorldForm.EditCopy,
                WorldForm.EditDelete,
                WorldForm.tbCut,
                WorldForm.tbCopy,
                WorldForm.tbDelete });
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        private WorldCon OpenFile(FilterIndex filterIndex = FilterIndex.File) =>
            OpenFile(JsonCon.SelectFilePath(filterIndex));

        private WorldCon OpenFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return null;
            var worldCon = GetNewWorldCon();
            worldCon?.LoadFromFile(filePath);
            return worldCon;
        }

        private void PasteFromClipboard()
        {
            var traces = JsonCon.ClipboardPaste();
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

        private void RecreateGLControl() => RecreateGLControl(GraphicsMode);

        private void RecreateGLControl(string propertyName, object value) => RecreateGLControl(GraphicsMode.Change(propertyName, value));

        private void RecreateGLControl(GraphicsMode mode)
        {
            var parent = SceneControl.Parent;
            GLControl
                oldControl = SceneControl,
                newControl = mode == null ? new GLControl() : new GLControl(mode);
            newControl.BackColor = Scene.BackgroundColour;
            newControl.Dock = DockStyle.Fill;
            newControl.Location = new System.Drawing.Point(0, 0);
            newControl.Name = "GLControl";
            newControl.Size = new System.Drawing.Size(100, 100);
            newControl.TabIndex = 1;
            newControl.VSync = Scene.VSync;
            BackColorChanged();
            parent.SuspendLayout();
            ConnectGLControl(false);
            parent.Controls.Remove(oldControl);
            parent.Controls.Add(newControl);
            ConnectGLControl(true);
            RenderCon.Refresh();
            parent.ResumeLayout();
            oldControl.Dispose();
            RefreshGraphicsMode();
        }

        internal void RefreshGraphicsMode() => OnPropertyChanged(PropertyNames.GraphicsMode);

        private void Resize() => RenderCon.InvalidateProjection();

        private bool SaveFile() => JsonCon.Save();

        private bool SaveFileAs() => JsonCon.SaveAs();

        private bool SaveOrSaveAs() => Scene.IsModified ? SaveFile() : SaveFileAs();

        private void SelectAll() => Selection.AddRange(Scene.Traces);

        private void SetDefaultCamera() => CameraCon.SetDefaultCamera();

        private static void SetVisibility(DockingCon dockingCon, bool visible)
        {
            if (visible)
                dockingCon.Form.Activate();
            else
                dockingCon.Form.Hide();
        }

        private void ShowControls()
        {
            SceneForm.Show(WorldPanel, DockState.Document);
            ShaderCodeForm.Show(WorldPanel, DockState.DockRight);
            ScenePropertiesForm.Show(WorldPanel, DockState.DockLeft);
            TracePropertiesForm.Show(ScenePropertiesPane, DockAlignment.Bottom, 2.0 / 3);
            SceneCodeForm.Show(TracePropertiesPane, DockAlignment.Bottom, 0.5);
            TraceCodeForm.Show(SceneCodePane, null);
            GraphicsStateForm.Show(SceneCodePane, null);
            TraceCodeForm.Activate();
        }

        internal void ShowOpenGLSLBook() => $"{GLSLUrl}".Launch();

        private void ToggleVisibility(DockingCon dockingCon) => SetVisibility(dockingCon, !dockingCon.Form.Visible);

        private void UpdateCaption() { WorldForm.Text = JsonCon.WindowCaption; }

        private void UpdateFramesPerSecond()
        {
            var fps = string.Format(CultureInfo.CurrentCulture, "FPS={0:f1}", RenderCon.FramesPerSecond);
            if (LastFPS != fps)
                LastFPS = WorldForm.FPSlabel.Text = fps;
        }

        private void UpdateGpuStatusLabel()
        {
            var label = WorldForm.GpuStatusLabel;
            label.ForeColor = Scene.GPUStatus.GetColour();
            var text = Scene.GPULog;
            label.Text = Regex.Replace(text, @"\s+", " ");
            label.ToolTipText = text;
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

        private void UpdateToolbar() => WorldForm.EditPaste.Enabled = WorldForm.tbPaste.Enabled = AppCon.CanPaste;

        private void UpdateVirtualTime()
        {
            var time = string.Format(CultureInfo.CurrentCulture, "t={0:f1}", Clock.VirtualSecondsElapsed);
            if (LastTime != time)
                LastTime = WorldForm.Tlabel.Text = time;
        }
    }
}
