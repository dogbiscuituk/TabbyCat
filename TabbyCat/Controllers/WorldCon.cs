namespace TabbyCat.Controllers
{
    using Commands;
    using Common.Types;
    using Common.Utils;
    using Jmk.Common;
    using Models;
    using Properties;
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal partial class WorldCon : LocalizationCon
    {
        internal WorldCon() : base(null)
        {
            WorldForm = new WorldForm();
            Scene = new Scene(this);
            InitControlTheme();
            RestoreWindowLayout();
            Connect(true);
            PopupMenu_Opening(this, new CancelEventArgs());
        }

        internal TraceSelection TraceSelection = new TraceSelection();

        private string
            LastSpeed,
            LastTime,
            LastFPS;

        protected internal override Scene Scene { get; set; }

        protected internal override WorldForm WorldForm { get; }

        internal GLInfo GLInfo => RenderCon._GLInfo ?? RenderCon?.GLInfo;

        private static string GLSLUrl => Settings.Default.GLSLUrl;

        internal event PropertyChangedEventHandler PropertyChanged;

        internal event EventHandler
            Pulse,
            SelectionChanged;

        internal void InitControlTheme() => AppCon.InitControlTheme(
            WorldPanel,
            WorldForm.MainMenu,
            WorldForm.PopupMenu,
            WorldForm.Toolbar,
            WorldForm.StatusBar);

        internal void LoadFromFile(string filePath) => JsonCon.LoadFromFile(filePath);

        internal void ModifiedChanged() => WorldForm.Text = JsonCon.WindowCaption;

        internal void RefreshGraphicsMode() => OnPropertyChanged(PropertyNames.GraphicsMode);

        internal void Show() => WorldForm.Show();

        internal void Show(IWin32Window owner) => WorldForm.Show(owner);

        internal void OnPropertyChanged(string propertyName)
        {
            $"WorldCon.OnPropertyChanged(\"{propertyName}\")".Spit();
            switch (propertyName)
            {
                case PropertyNames.Traces:
                    UpdateSelection();
                    break;
                case PropertyNames.FPS:
                    ClockInit();
                    break;
                case PropertyNames.GraphicsMode:
                case PropertyNames.Samples:
                case PropertyNames.Stereo:
                    UpdateGraphicsModeLabel();
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

        protected internal override void UpdateAllProperties()
        {
            SceneCodeCon.UpdateAllProperties();
            ScenePropertiesCon.UpdateAllProperties();
            ShaderCodeCon.UpdateAllProperties();
            SignalsCon.UpdateAllProperties();
            TraceCodeCon.UpdateAllProperties();
            TracePropertiesCon.UpdateAllProperties();
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
            Localize(Resources.Menu_Add, WorldForm.AddMenu, WorldForm.tbAdd);
            Localize(Resources.Menu_Add_Curve, WorldForm.AddCurve, WorldForm.tbAddCurve);
            Localize(Resources.Menu_Add_Surface, WorldForm.AddSurface, WorldForm.tbAddSurface);
            Localize(Resources.Menu_Add_Volume, WorldForm.AddVolume, WorldForm.tbAddVolume);
            Localize(Resources.Menu_Add_Signal, WorldForm.AddSignal, WorldForm.tbAddSignal);
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

        private void Clock_Tick(object sender, EventArgs e) { RenderCon.Render(); }

        private void AddCurve_Click(object sender, EventArgs e) => AddCurve();
        private void AddSignal_Click(object sender, EventArgs e) => AddSignal();
        private void AddSurface_Click(object sender, EventArgs e) => AddSurface();
        private void AddVolume_Click(object sender, EventArgs e) => AddVolume();
        private void EditCut_Click(object sender, EventArgs e) => CutToClipboard();
        private void EditCopy_Click(object sender, EventArgs e) => CopyToClipboard();
        private void EditPaste_Click(object sender, EventArgs e) => PasteFromClipboard();
        private void EditDelete_Click(object sender, EventArgs e) => DeleteSelection();
        private void EditSelectAll_Click(object sender, EventArgs e) => SelectAll();
        private void EditInvertSelection_Click(object sender, EventArgs e) => InvertSelection();
        private void EditOptions_Click(object sender, EventArgs e) => EditOptions();

        private void ViewRestoreWindowLayout_Click(object sender, EventArgs e) => RestoreWindowLayout();

        private void HelpAbout_Click(object sender, EventArgs e) => HelpAbout();
        private void HelpTheOpenGLShadingLanguage_Click(object sender, EventArgs e) => ShowOpenGLSLBook();
        private void PopupMenu_Opening(object sender, CancelEventArgs e) => CreateMainMenuClone();

        private void WorldForm_FormClosed(object sender, FormClosedEventArgs e) => FormClosed();
        private void WorldForm_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !FormClosing(e.CloseReason);

        private void Selection_Changed(object sender, EventArgs e) => OnSelectionChanged();

        private void AddSignal() => CommandProcessor.AppendSignal();

        private void AddCurve() => AddTrace(TraceType.Curve);

        private void AddSurface() => AddTrace(TraceType.Surface);

        private void AddTrace(TraceType traceType)
        {
            var trace = GetNewTrace(traceType);
            trace.Scene = Scene;
            CommandProcessor.AppendTrace(trace);
            TraceSelection.Set(new[] { Scene.Traces.Last() });
        }

        private void AddVolume() => AddTrace(TraceType.Volume);

        private void ClockInit() => Clock.IntervalMilliseconds = GetFrameMilliseconds();

        private void ClockShutdown() => Clock.Stop();

        private void ClockStartup()
        {
            ClockInit();
            Clock.Start();
            ClockCon.UpdateTimeControls();
        }

        private void CreateMainMenuClone() => WorldForm.MainMenu.CloneTo(WorldForm.PopupMenu);

        private void ConnectEventHandlers(bool connect)
        {
            ConnectMainMenu(connect);
            ConnectToolbar(connect);
            if (connect)
            {
                WorldForm.FormClosed += WorldForm_FormClosed;
                WorldForm.FormClosing += WorldForm_FormClosing;
                TraceSelection.Changed += Selection_Changed;
            }
            else
            {
                WorldForm.FormClosed -= WorldForm_FormClosed;
                WorldForm.FormClosing -= WorldForm_FormClosing;
                TraceSelection.Changed -= Selection_Changed;
            }
            SceneCon.Connect(connect);
        }

        private void ConnectMainMenu(bool connect)
        {
            if (connect)
            {
                WorldForm.AddCurve.Click += AddCurve_Click;
                WorldForm.AddSignal.Click += AddSignal_Click;
                WorldForm.AddSurface.Click += AddSurface_Click;
                WorldForm.AddVolume.Click += AddVolume_Click;
                WorldForm.EditCut.Click += EditCut_Click;
                WorldForm.EditCopy.Click += EditCopy_Click;
                WorldForm.EditPaste.Click += EditPaste_Click;
                WorldForm.EditDelete.Click += EditDelete_Click;
                WorldForm.EditSelectAll.Click += EditSelectAll_Click;
                WorldForm.EditInvertSelection.Click += EditInvertSelection_Click;
                WorldForm.EditOptions.Click += EditOptions_Click;
                WorldForm.ViewRestoreWindowLayout.Click += ViewRestoreWindowLayout_Click;
                WorldForm.HelpOpenGLShadingLanguage.Click += HelpTheOpenGLShadingLanguage_Click;
                WorldForm.HelpAbout.Click += HelpAbout_Click;
                WorldForm.PopupMenu.Opening += PopupMenu_Opening;
            }
            else
            {
                WorldForm.AddCurve.Click -= AddCurve_Click;
                WorldForm.AddSignal.Click += AddSignal_Click;
                WorldForm.AddSurface.Click -= AddSurface_Click;
                WorldForm.AddVolume.Click -= AddVolume_Click;
                WorldForm.EditCut.Click -= EditCut_Click;
                WorldForm.EditCopy.Click -= EditCopy_Click;
                WorldForm.EditPaste.Click -= EditPaste_Click;
                WorldForm.EditDelete.Click -= EditDelete_Click;
                WorldForm.EditSelectAll.Click -= EditSelectAll_Click;
                WorldForm.EditInvertSelection.Click -= EditInvertSelection_Click;
                WorldForm.EditOptions.Click -= EditOptions_Click;
                WorldForm.ViewRestoreWindowLayout.Click -= ViewRestoreWindowLayout_Click;
                WorldForm.HelpOpenGLShadingLanguage.Click -= HelpTheOpenGLShadingLanguage_Click;
                WorldForm.HelpAbout.Click -= HelpAbout_Click;
                WorldForm.PopupMenu.Opening -= PopupMenu_Opening;
            }
        }

        private void ConnectToolbar(bool connect)
        {
            if (connect)
            {
                WorldForm.tbAdd.ButtonClick += AddCurve_Click;
                WorldForm.tbAddCurve.Click += AddCurve_Click;
                WorldForm.tbAddSurface.Click += AddSurface_Click;
                WorldForm.tbAddVolume.Click += AddVolume_Click;
                WorldForm.tbAddSignal.Click += AddSignal_Click;
                WorldForm.tbCut.Click += EditCut_Click;
                WorldForm.tbCopy.Click += EditCopy_Click;
                WorldForm.tbPaste.Click += EditPaste_Click;
                WorldForm.tbDelete.Click += EditDelete_Click;
            }
            else
            {
                WorldForm.tbAdd.ButtonClick -= AddCurve_Click;
                WorldForm.tbAddCurve.Click -= AddCurve_Click;
                WorldForm.tbAddSurface.Click -= AddSurface_Click;
                WorldForm.tbAddVolume.Click -= AddVolume_Click;
                WorldForm.tbAddSignal.Click -= AddSignal_Click;
                WorldForm.tbCut.Click -= EditCut_Click;
                WorldForm.tbCopy.Click -= EditCopy_Click;
                WorldForm.tbPaste.Click -= EditPaste_Click;
                WorldForm.tbDelete.Click -= EditDelete_Click;
            }
        }

        private void CopyToClipboard() => JsonCon.ClipboardCopy(TraceSelection.Traces);

        private void CutToClipboard()
        {
            CopyToClipboard();
            DeleteSelection();
        }

        private void DeleteSelection()
        {
            if (TraceSelection.IsEmpty)
                return;
            var indices = TraceSelection.GetTraceIndices().OrderByDescending(p => p).ToList();
            foreach (var index in indices)
                CommandProcessor.DeleteTrace(index);
            TraceSelection.Clear();
        }

        private void EditOptions()
        {
            using (var optionsCon = new OptionsCon(this))
                optionsCon.ShowModal();
        }

        private void FormClosed() => Connect(false);

        private bool FormClosing(CloseReason _) => JsonCon.SaveIfModified();

        private int GetFrameMilliseconds() => (int)Math.Round(1000f / Math.Min(Math.Max(Scene.FPS, 1), int.MaxValue));

        private static Trace GetNewTrace(TraceType traceType)
        {
            switch (traceType)
            {
                case TraceType.Curve:
                    return new Curve();
                case TraceType.Surface:
                    return new Surface();
                case TraceType.Volume:
                    return new Volume();
                default:
                    return null;
            }
        }

        private void HelpAbout()
        {
            using (AboutCon aboutCon = new AboutCon(this))
                aboutCon.ShowDialog(WorldForm);
        }

        private void InvertSelection() => TraceSelection.Set(Scene.Traces.Where(p => !TraceSelection.Traces.Contains(p)).ToList());

        private void OnSelectionChanged()
        {
            ToolStripUtils.EnableButtons(!TraceSelection.IsEmpty, new ToolStripItem[] {
                WorldForm.EditCut,
                WorldForm.EditCopy,
                WorldForm.EditDelete,
                WorldForm.tbCut,
                WorldForm.tbCopy,
                WorldForm.tbDelete });
            SelectionChanged?.Invoke(this, EventArgs.Empty);
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
                Run(new TraceInsertCommand(index++, trace));
            }
            TraceSelection.Set(traces);
        }

        private void SelectAll() => TraceSelection.AddRange(Scene.Traces);

        internal void ShowOpenGLSLBook() => $"{GLSLUrl}".Launch();

        private void UpdateFramesPerSecond()
        {
            var fps = string.Format(CultureInfo.CurrentCulture, "FPS={0:f1}", RenderCon.FramesPerSecond);
            if (LastFPS != fps)
                LastFPS = WorldForm.FpsLabel.Text = fps;
        }

        private void UpdateGpuStatusLabel()
        {
            var label = WorldForm.GpuStatusLabel;
            label.ForeColor = Scene.GPUStatus.GetColour();
            var text = Scene.GPULog;
            label.Text = Regex.Replace(text, @"\s+", " ");
            label.ToolTipText = text;
        }

        private void UpdateGraphicsModeLabel()
        {
            var label = WorldForm.GraphicsModeLabel;
            var mode = GraphicsMode;
            label.Text = string.Format(CultureInfo.CurrentCulture, Resources.Text_GraphicsModeIndexFormat, mode.Index);
            label.ToolTipText = mode.AsString();
        }

        private void UpdateSelection()
        {
            TraceSelection.BeginUpdate();
            TraceSelection.Traces
                .Where(p => !Scene.Traces.Contains(p))
                .ToList()
                .ForEach(p => TraceSelection.Remove(p));
            TraceSelection.EndUpdate();
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
                LastTime = WorldForm.TimeLabel.Text = time;
        }
    }

    /// <summary>
    /// Child controllers.
    /// </summary>
    partial class WorldCon
    {
        private CommandProcessor _CommandProcessor;

        private CameraCon _CameraCon;
        private ClockCon _ClockCon;
        private SignalsCon _ControlCon;
        private FullScreenCon _FullScreenCon;
        private JsonCon _JsonCon;
        private RenderCon _RenderCon;
        private SceneCodeCon _SceneCodeCon;
        private SceneCon _SceneCon;
        private ScenePropertiesCon _ScenePropertiesCon;
        private ShaderCodeCon _ShaderCodeCon;
        private TraceCodeCon _TraceCodeCon;
        private TracePropertiesCon _TracePropertiesCon;

        internal override CommandProcessor CommandProcessor => _CommandProcessor ?? (_CommandProcessor = new CommandProcessor(this));

        protected internal override JsonCon JsonCon => _JsonCon ?? (_JsonCon = new JsonCon(this));

        protected override CameraCon CameraCon => _CameraCon ?? (_CameraCon = new CameraCon(this));
        protected override ClockCon ClockCon => _ClockCon ?? (_ClockCon = new ClockCon(this));
        protected override FullScreenCon FullScreenCon => _FullScreenCon ?? (_FullScreenCon = new FullScreenCon(this));
        protected override SignalsCon SignalsCon => _ControlCon ?? (_ControlCon = new SignalsCon(this));
        protected override RenderCon RenderCon => _RenderCon ?? (_RenderCon = new RenderCon(this));
        protected override SceneCodeCon SceneCodeCon => _SceneCodeCon ?? (_SceneCodeCon = new SceneCodeCon(this));
        protected override SceneCon SceneCon => _SceneCon ?? (_SceneCon = new SceneCon(this));
        protected override ScenePropertiesCon ScenePropertiesCon => _ScenePropertiesCon ?? (_ScenePropertiesCon = new ScenePropertiesCon(this));
        protected override ShaderCodeCon ShaderCodeCon => _ShaderCodeCon ?? (_ShaderCodeCon = new ShaderCodeCon(this));
        protected override TraceCodeCon TraceCodeCon => _TraceCodeCon ?? (_TraceCodeCon = new TraceCodeCon(this));
        protected override TracePropertiesCon TracePropertiesCon => _TracePropertiesCon ?? (_TracePropertiesCon = new TracePropertiesCon(this));

        protected DockPane ControlPane => SignalsForm.Pane;
        protected DockPane SceneCodePane => SceneCodeForm.Pane;
        protected DockPane ScenePane => SceneForm.Pane;
        protected DockPane ScenePropertiesPane => ScenePropertiesForm.Pane;
        protected DockPane ShaderCodePane => ShaderCodeForm.Pane;
        protected DockPane TraceCodePane => TraceCodeForm.Pane;
        protected DockPane TracePropertiesPane => TracePropertiesForm.Pane;
        protected DockPanel WorldPanel => WorldForm.DockPanel;

        internal void ConnectCons(bool connect)
        {
            Array.ForEach(new LocalizationCon[]
            {
                CameraCon,
                ClockCon,
                FullScreenCon,
                SignalsCon,
                JsonCon,
                RenderCon,
                SceneCodeCon,
                SceneCon,
                ScenePropertiesCon,
                ShaderCodeCon,
                TraceCodeCon,
                TracePropertiesCon
            }, p => p.Connect(connect));
            if (connect)
            {
            }
            else
            {
                RenderCon.Unload();
            }
        }

        private void RestoreWindowLayout()
        {
            const double h = 0.28;
            SceneForm.Show(WorldPanel, DockState.Document);
            ShaderCodeForm.Show(WorldPanel, DockState.DockRight);
            TracePropertiesForm.Show(WorldPanel, DockState.DockLeft);
            TraceCodeForm.Show(TracePropertiesPane, DockAlignment.Bottom, 1 - h);
            ScenePropertiesForm.Show(TraceCodePane, DockAlignment.Bottom, h / (1 - h));
            SceneCodeForm.Show(TraceCodePane, null);
            TraceCodeForm.Activate();
            SignalsForm.Show(ShaderCodePane, DockAlignment.Bottom, h);
        }
    }
}
