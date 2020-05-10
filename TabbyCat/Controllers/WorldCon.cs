﻿namespace TabbyCat.Controllers
{
    using Commands;
    using Models;
    using Properties;
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Types;
    using Utils;
    using Views;
    using WeifenLuo.WinFormsUI.Docking;

    public partial class WorldCon : LocalizationCon
    {
        public WorldCon() : base(null)
        {
            WorldForm = new WorldForm();
            Scene = new Scene(this);
            InitControlTheme();
            RestoreWindowLayout();
            Connect(true);
            PopupWorldForm_Opening(this, new CancelEventArgs());
        }

        public TraceSelection TraceSelection { get; } = new TraceSelection();

        private string
            LastSpeed,
            LastTime,
            LastFPS;

        public override Scene Scene { get; set; }

        public override WorldForm WorldForm { get; }

        public GLInfo GLInfo => RenderCon.TheGLInfo ?? RenderCon?.GLInfo;

        private static string GLSLUrl => Settings.Default.GLSLUrl;

        public event EventHandler<CollectionEditEventArgs> CollectionEdit;

        public event EventHandler<PropertyEditEventArgs> PropertyEdit;

        public event EventHandler
            Pulse,
            SelectionChanged;

        public void LoadFromFile(string filePath) => JsonCon.LoadFromFile(filePath);

        public void ModifiedChanged() => WorldForm.Text = JsonCon.WindowCaption;

        public void RefreshGraphicsMode() => OnPropertyEdit(Property.GraphicsMode);

        public void Show() => WorldForm.Show();

        public void Show(IWin32Window owner) => WorldForm.Show(owner);

        public void OnCollectionEdit(Property collection, int index, bool adding)
        {
            $"WorldCon.OnCollectionEdit(\"{collection}\", adding: {adding}, index: {index});".Spit();
            CollectionEdit?.Invoke(this, new CollectionEditEventArgs(collection, index, adding));
        }

        public void OnPropertyEdit(Property property, int index = 0)
        {
            $"WorldCon.OnPropertyEdit(\"{property}\", index: {index});".Spit();
            PropertyEdit?.Invoke(this, new PropertyEditEventArgs(property, index));
        }

        public void OnPulse()
        {
            UpdateToolbar();
            UpdateStatusBar();
            Pulse?.Invoke(this, EventArgs.Empty);
        }

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                ConnectEventHandlers(true);
                ConnectCons(true);
                CommandCon.Clear();
                Clock.Tick += Clock_Tick;
                ClockStartup();
            }
            else
            {
                ClockShutdown();
                Clock.Tick -= Clock_Tick;
                RenderCon.InvalidateProgram();
                CommandCon.Clear();
                ConnectCons(false);
                ConnectEventHandlers(false);
                AppCon.Remove(this);
            }
        }

        public override void UpdateAllProperties()
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
            Localize(Resources.WorldForm_AddMenu, WorldForm.AddMenu, WorldForm.tbAdd);
            Localize(Resources.WorldForm_AddCurve, WorldForm.AddCurve, WorldForm.tbAddCurve);
            Localize(Resources.WorldForm_AddSurface, WorldForm.AddSurface, WorldForm.tbAddSurface);
            Localize(Resources.WorldForm_AddVolume, WorldForm.AddVolume, WorldForm.tbAddVolume);
            Localize(Resources.WorldForm_EditMenu, WorldForm.EditMenu);
            Localize(Resources.WorldForm_EditUndo, WorldForm.EditUndo, WorldForm.tbUndo);
            Localize(Resources.WorldForm_EditRedo, WorldForm.EditRedo, WorldForm.tbRedo);
            Localize(Resources.WorldForm_EditCut, WorldForm.EditCut, WorldForm.tbCut);
            Localize(Resources.WorldForm_EditCopy, WorldForm.EditCopy, WorldForm.tbCopy);
            Localize(Resources.WorldForm_EditPaste, WorldForm.EditPaste, WorldForm.tbPaste);
            Localize(Resources.WorldForm_EditDelete, WorldForm.EditDelete, WorldForm.tbDelete);
            Localize(Resources.WorldForm_EditSelectAll, WorldForm.EditSelectAll);
            Localize(Resources.WorldForm_EditInvertSelection, WorldForm.EditInvertSelection);
            Localize(Resources.WorldForm_EditOptions, WorldForm.EditOptions);
            Localize(Resources.WorldForm_View, WorldForm.ViewMenu);
            Localize(Resources.WorldForm_TimeAccelerate, WorldForm.TimeAccelerate);
            Localize(Resources.WorldForm_TimeDecelerate, WorldForm.TimeDecelerate);
            Localize(Resources.WorldForm_TimeForward, WorldForm.TimeForward);
            Localize(Resources.WorldForm_TimePause, WorldForm.TimePause);
            Localize(Resources.WorldForm_TimeReverse, WorldForm.TimeReverse);
            Localize(Resources.WorldForm_TimeStop, WorldForm.TimeStop);
            Localize(Resources.WorldForm_HelpMenu, WorldForm.HelpMenu);
            Localize(Resources.WorldForm_HelpOpenGLShadingLanguage, WorldForm.HelpOpenGLShadingLanguage);
            LocalizeFmt(Resources.WorldForm_HelpAbout, Application.ProductName, WorldForm.HelpAbout);
        }

        private void Clock_Tick(object sender, EventArgs e) => RenderCon.Render();

        private void AddCurve_Click(object sender, EventArgs e) => AddCurve();

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

        private void PopupWorldForm_Opening(object sender, CancelEventArgs e) => CreateMainMenuClone();

        private void WorldForm_FormClosed(object sender, FormClosedEventArgs e) => FormClosed();

        private void WorldForm_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !FormClosing(e.CloseReason);

        private void Selection_Changed(object sender, EventArgs e) => OnSelectionChanged();

        private void AddCurve() => AddTrace(TraceType.Curve);

        private void AddSurface() => AddTrace(TraceType.Surface);

        private void AddTrace(TraceType traceType)
        {
            var trace = GetNewTrace(traceType);
            trace.Scene = Scene;
            CommandCon.AppendTrace(trace);
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

        private void CreateMainMenuClone() => WorldForm.MainMenu.CloneTo(WorldForm.PopupMenu, ToolStripUtils.CloneOptions.All);

        private void ConnectEventHandlers(bool connect)
        {
            ConnectMainMenu(connect);
            ConnectToolbar(connect);
            if (connect)
            {
                PropertyEdit += WorldCon_PropertyEdit;
                TraceSelection.Changed += Selection_Changed;
                WorldForm.FormClosed += WorldForm_FormClosed;
                WorldForm.FormClosing += WorldForm_FormClosing;
            }
            else
            {
                PropertyEdit -= WorldCon_PropertyEdit;
                TraceSelection.Changed -= Selection_Changed;
                WorldForm.FormClosed -= WorldForm_FormClosed;
                WorldForm.FormClosing -= WorldForm_FormClosing;
            }
            SceneCon.Connect(connect);
        }

        private void ConnectMainMenu(bool connect)
        {
            if (connect)
            {
                WorldForm.AddCurve.Click += AddCurve_Click;
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
                WorldForm.PopupMenu.Opening += PopupWorldForm_Opening;
            }
            else
            {
                WorldForm.AddCurve.Click -= AddCurve_Click;
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
                WorldForm.PopupMenu.Opening -= PopupWorldForm_Opening;
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
                CommandCon.DeleteTrace(index);
            TraceSelection.Clear();
        }

        private void EditOptions()
        {
            using (var optionsCon = new OptionsCon(this))
                optionsCon.ShowModal();
        }

        private void FormClosed() => Connect(false);

        private bool FormClosing(CloseReason _) => JsonCon.SaveIfModified();

        private int GetFrameMilliseconds() => (int)Math.Round(1000f / Math.Min(Math.Max(Scene.TargetFPS, 1), int.MaxValue));

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
            using (var aboutCon = new AboutCon(this))
                aboutCon.ShowDialog(WorldForm);
        }

        private void InitControlTheme() => AppCon.InitControlTheme(
            WorldPanel,
            WorldForm.MainMenu,
            WorldForm.PopupMenu,
            WorldForm.Toolbar,
            WorldForm.StatusBar);

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

        public static void ShowOpenGLSLBook() => LaunchBrowser($"{GLSLUrl}");

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
    public partial class WorldCon
    {
        // Private fields

        private CameraCon _CameraCon;
        private ClockCon _ClockCon;
        private CommandCon _CommandCon;
        private FullScreenCon _FullScreenCon;
        private HotkeysCon _HotkeysCon;
        private JsonCon _JsonCon;
        private RenderCon _RenderCon;
        private SceneCodeCon _SceneCodeCon;
        private SceneCon _SceneCon;
        private ScenePropertiesCon _ScenePropertiesCon;
        private ShaderCodeCon _ShaderCodeCon;
        private SignalsCon _ControlCon;
        private TraceCodeCon _TraceCodeCon;
        private TracePropertiesCon _TracePropertiesCon;

        // Public properties

        public override CommandCon CommandCon => _CommandCon ?? (_CommandCon = new CommandCon(this));
        public override JsonCon JsonCon => _JsonCon ?? (_JsonCon = new JsonCon(this));

        // Protected properties

        protected override CameraCon CameraCon => _CameraCon ?? (_CameraCon = new CameraCon(this));
        protected override ClockCon ClockCon => _ClockCon ?? (_ClockCon = new ClockCon(this));
        protected override FullScreenCon FullScreenCon => _FullScreenCon ?? (_FullScreenCon = new FullScreenCon(this));
        protected override HotkeysCon HotkeysCon => _HotkeysCon ?? (_HotkeysCon = new HotkeysCon(this));
        protected override SignalsCon SignalsCon => _ControlCon ?? (_ControlCon = new SignalsCon(this));
        protected override RenderCon RenderCon => _RenderCon ?? (_RenderCon = new RenderCon(this));
        protected override SceneCodeCon SceneCodeCon => _SceneCodeCon ?? (_SceneCodeCon = new SceneCodeCon(this));
        protected override SceneCon SceneCon => _SceneCon ?? (_SceneCon = new SceneCon(this));
        protected override ScenePropertiesCon ScenePropertiesCon => _ScenePropertiesCon ?? (_ScenePropertiesCon = new ScenePropertiesCon(this));
        protected override ShaderCodeCon ShaderCodeCon => _ShaderCodeCon ?? (_ShaderCodeCon = new ShaderCodeCon(this));
        protected override TraceCodeCon TraceCodeCon => _TraceCodeCon ?? (_TraceCodeCon = new TraceCodeCon(this));
        protected override TracePropertiesCon TracePropertiesCon => _TracePropertiesCon ?? (_TracePropertiesCon = new TracePropertiesCon(this));

        // Private properties

        private DockPane HotkeysPane => HotkeysForm.Pane;
        private DockPane SceneCodePane => SceneCodeForm.Pane;
        private DockPane ScenePane => SceneForm.Pane;
        private DockPane ScenePropertiesPane => ScenePropertiesForm.Pane;
        private DockPane ShaderCodePane => ShaderCodeForm.Pane;
        private DockPane SignalsPane => SignalsForm.Pane;
        private DockPane TraceCodePane => TraceCodeForm.Pane;
        private DockPane TracePropertiesPane => TracePropertiesForm.Pane;
        private DockPanel WorldPanel => WorldForm.DockPanel;

        // Public methods

        public void ConnectCons(bool connect)
        {
            Array.ForEach(new LocalizationCon[]
            {
                CameraCon,
                ClockCon,
                CommandCon,
                FullScreenCon,
                HotkeysCon,
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

        // Private methods

        private void RestoreWindowLayout()
        {
            const float
                hTop = 0.34f,
                hBottom = 0.35f;
            SceneForm.Show(WorldPanel, DockState.Document);
            ShaderCodeForm.Show(WorldPanel, DockState.DockRight);
            TracePropertiesForm.Show(WorldPanel, DockState.DockLeft);
            TraceCodeForm.Show(TracePropertiesPane, DockAlignment.Bottom, 1 - hTop);
            ScenePropertiesForm.Show(TraceCodePane, DockAlignment.Bottom, hBottom / (1 - hTop));
            SceneCodeForm.Show(TraceCodePane, null);
            TraceCodeForm.Activate();
            SignalsForm.Show(ShaderCodePane, DockAlignment.Bottom, hBottom);
            HotkeysForm.Show(SignalsPane, null);
            SignalsForm.Activate();
        }

        private void WorldCon_PropertyEdit(object sender, PropertyEditEventArgs e)
        {
            switch (e.Property)
            {
                case Property.Traces:
                    UpdateSelection();
                    break;
                case Property.TargetFPS:
                    ClockInit();
                    break;
                case Property.GraphicsMode:
                case Property.Samples:
                case Property.Stereo:
                    UpdateGraphicsModeLabel();
                    break;
                case Property.GPULog:
                case Property.GPUStatus:
                    UpdateGpuStatusLabel();
                    break;
            }
            SceneControl.Invalidate();
        }
    }
}
