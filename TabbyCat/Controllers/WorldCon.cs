﻿namespace TabbyCat.Controllers
{
    using Commands;
    using Models;
    using Properties;
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Types;
    using Utils;
    using Views;
    using WeifenLuo.WinFormsUI.Docking;

    public sealed partial class WorldCon : LocalCon
    {
        // Constructors

        public WorldCon() : base(null)
        {
            WorldForm = new WorldForm();
            Scene = new Scene(this);
            InitControlTheme();
            RestoreWindowLayout();
            Connect(true);
            PopupWorldForm_Opening(this, new CancelEventArgs());
        }

        // Private fields

        private string
            _lastSpeed,
            _lastTime,
            _lastFps;

        // Public properties

        //public GLInfo GLInfo => RenderCon.TheGLInfo ?? RenderCon?.GLInfo;

        /*
        public GLInfo GLInfo
        {
            get
            {
                var info = RenderCon.TheGLInfo;
                if (info != null)
                    return info;
                info = RenderCon.GLInfo;
                return info;
            }
        }
        */

        public override Scene Scene { get; set; }

        public ShapeSelection ShapeSelection { get; } = new ShapeSelection();

        public override WorldForm WorldForm { get; }

        // Private static properties

        private static string GLSLUrl => Settings.Default.GLSLUrl;

        // Public events

        public event EventHandler<CollectionEditEventArgs> CollectionEdit;

        public event EventHandler<PropertyEditEventArgs> PropertyEdit;

        public event EventHandler Pulse;

        public event EventHandler SelectionChanged;

        // Public methods

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

        public void LoadFromFile(string filePath) => JsonCon.LoadFromFile(filePath);

        public void ModifiedChanged() => WorldForm.Text = JsonCon.WindowCaption;

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

        public void RefreshGraphicsMode() => OnPropertyEdit(Property.GraphicsMode);

        public void Show() => WorldForm.Show();

        public override void UpdateAllProperties()
        {
            SceneCodeCon.UpdateAllProperties();
            ScenePropertiesCon.UpdateAllProperties();
            ShaderCodeCon.UpdateAllProperties();
            SignalsCon.UpdateAllProperties();
            ShapeCodeCon.UpdateAllProperties();
            ShapePropertiesCon.UpdateAllProperties();
        }

        //Protected methods

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

        // Private methods

        private void AddCurve_Click(object sender, EventArgs e) => AddShape(ShapeType.Curve);

        private void AddSurface_Click(object sender, EventArgs e) => AddShape(ShapeType.Surface);

        private void AddShape(ShapeType shapeType)
        {
            if (!Scene.Shapes.Any())
            {
                AddShape(new XAxis());
                AddShape(new YAxis());
                AddShape(new ZAxis());
            }
            AddShape(GetNewShape(shapeType));
        }

        private void AddShape(Shape shape)
        {
            shape.Scene = Scene;
            CommandCon.AppendShape(shape);
            ShapeSelection.Set(new[] { shape });
        }

        private void AddVolume_Click(object sender, EventArgs e) => AddShape(ShapeType.Volume);

        private void Clock_Tick(object sender, EventArgs e) => RenderCon.Render();

        private void ClockInit() => Clock.IntervalMilliseconds = GetFrameMilliseconds();

        private void ClockShutdown() => Clock.Stop();

        private void ClockStartup()
        {
            ClockInit();
            Clock.Start();
            ClockCon.UpdateTimeControls();
        }

        private void ConnectEventHandlers(bool connect)
        {
            ConnectMainMenu(connect);
            ConnectToolbar(connect);
            if (connect)
            {
                PropertyEdit += WorldCon_PropertyEdit;
                ShapeSelection.Changed += Selection_Changed;
                WorldForm.FormClosed += WorldForm_FormClosed;
                WorldForm.FormClosing += WorldForm_FormClosing;
            }
            else
            {
                PropertyEdit -= WorldCon_PropertyEdit;
                ShapeSelection.Changed -= Selection_Changed;
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

        private void CopyToClipboard() => JsonCon.ClipboardCopy(ShapeSelection.Shapes);

        private void CreateMainMenuClone() => WorldForm.MainMenu.CloneTo(WorldForm.PopupMenu, ToolStripCloneOptions.All);

        private void CutToClipboard()
        {
            CopyToClipboard();
            DeleteSelection();
        }

        private void DeleteSelection()
        {
            if (ShapeSelection.IsEmpty)
                return;
            var indices = ShapeSelection.GetShapeIndices().OrderByDescending(p => p).ToList();
            foreach (var index in indices)
                CommandCon.DeleteShape(index);
            ShapeSelection.Clear();
        }

        private void EditCopy_Click(object sender, EventArgs e) => CopyToClipboard();

        private void EditCut_Click(object sender, EventArgs e) => CutToClipboard();

        private void EditDelete_Click(object sender, EventArgs e) => DeleteSelection();

        private void EditInvertSelection_Click(object sender, EventArgs e) => ShapeSelection.Set(Scene.Shapes.Where(p => !ShapeSelection.Shapes.Contains(p)).ToList());

        private int GetFrameMilliseconds() => (int)Math.Round(1000f / Math.Min(Math.Max(Scene.TargetFPS, 1), int.MaxValue));

        private static Shape GetNewShape(ShapeType shapeType)
        {
            switch (shapeType)
            {
                case ShapeType.Curve:
                    return new Curve();
                case ShapeType.Surface:
                    return new Surface();
                case ShapeType.Volume:
                    return new Volume();
                default:
                    return null;
            }
        }

        private void InitControlTheme() => AppCon.InitControlTheme(
            WorldPanel,
            WorldForm.MainMenu,
            WorldForm.PopupMenu,
            WorldForm.Toolbar,
            WorldForm.StatusBar);

        private void EditOptions_Click(object sender, EventArgs e)
        {
            using (var optionsCon = new OptionsCon(this))
                optionsCon.ShowModal();
        }

        private void EditPaste_Click(object sender, EventArgs e)
        {
            var shapes = JsonCon.ClipboardPaste().ToList();
            if (!shapes.Any())
                return;
            var index = Scene.Shapes.Count;
            foreach (var shape in shapes)
            {
                shape.Scene = Scene;
                Run(new ShapeInsertCommand(index++, shape));
            }
            ShapeSelection.Set(shapes);
        }

        private void EditSelectAll_Click(object sender, EventArgs e) => ShapeSelection.AddRange(Scene.Shapes);

        private void HelpAbout_Click(object sender, EventArgs e)
        {
            using (var aboutCon = new AboutCon(this))
                aboutCon.ShowDialog(WorldForm);
        }

        private void OnSelectionChanged()
        {
            ToolStripUtils.EnableButtons(!ShapeSelection.IsEmpty, new ToolStripItem[] {
                WorldForm.EditCut,
                WorldForm.EditCopy,
                WorldForm.EditDelete,
                WorldForm.tbCut,
                WorldForm.tbCopy,
                WorldForm.tbDelete });
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        private void PopupWorldForm_Opening(object sender, CancelEventArgs e) => CreateMainMenuClone();

        private void Selection_Changed(object sender, EventArgs e) => OnSelectionChanged();

        private void UpdateFramesPerSecond()
        {
            var fps = Resources.WorldForm_FPS.Format(RenderCon.FramesPerSecond);
            if (_lastFps != fps)
                _lastFps = WorldForm.FpsLabel.Text = fps;
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
            /*
            var label = WorldForm.GraphicsModeLabel;
            var mode = GraphicsMode;
            label.Text = Resources.Text_GraphicsModeIndexFormat.Format(mode.Index);
            label.ToolTipText = mode.AsString();
            */
        }

        private void UpdateSelection()
        {
            ShapeSelection.BeginUpdate();
            ShapeSelection.Shapes
                .Where(p => !Scene.Shapes.Contains(p))
                .ToList()
                .ForEach(p => ShapeSelection.Remove(p));
            ShapeSelection.EndUpdate();
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
            if (_lastSpeed != speed)
                _lastSpeed = WorldForm.SpeedLabel.Text = speed;
        }

        private void UpdateToolbar() => WorldForm.EditPaste.Enabled = WorldForm.tbPaste.Enabled = AppCon.CanPaste;

        private void UpdateVirtualTime()
        {
            var time = Resources.WorldForm_Time.Format(Clock.VirtualSecondsElapsed);
            if (_lastTime != time)
                _lastTime = WorldForm.TimeLabel.Text = time;
        }

        private void ViewRestoreWindowLayout_Click(object sender, EventArgs e) => RestoreWindowLayout();

        private void WorldForm_FormClosed(object sender, FormClosedEventArgs e) => Connect(false);

        private void WorldForm_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !JsonCon.SaveIfModified();

        // Private static methods

        private static void HelpTheOpenGLShadingLanguage_Click(object sender, EventArgs e) => ShowOpenGLSLBook();

        private static void ShowOpenGLSLBook() => LaunchBrowser($"{GLSLUrl}");
    }

    /// <summary>
    /// Child controllers.
    /// </summary>
    public sealed partial class WorldCon
    {
        // Private fields

        private CameraCon _cameraCon;
        private ClockCon _clockCon;
        private CommandCon _commandCon;
        private FullScreenCon _fullScreenCon;
        private HotkeysCon _hotkeysCon;
        private JsonCon _jsonCon;
        private RenderCon _renderCon;
        private SceneCodeCon _sceneCodeCon;
        private SceneCon _sceneCon;
        private ScenePropertiesCon _scenePropertiesCon;
        private ShaderCodeCon _shaderCodeCon;
        private SignalsCon _signalsCon;
        private ShapeCodeCon _shapeCodeCon;
        private ShapePropertiesCon _shapePropertiesCon;

        // Public properties

        public override CommandCon CommandCon => _commandCon ?? (_commandCon = new CommandCon(this));
        public override JsonCon JsonCon => _jsonCon ?? (_jsonCon = new JsonCon(this));

        // Protected properties

        protected override CameraCon CameraCon => _cameraCon ?? (_cameraCon = new CameraCon(this));
        protected override ClockCon ClockCon => _clockCon ?? (_clockCon = new ClockCon(this));
        protected override FullScreenCon FullScreenCon => _fullScreenCon ?? (_fullScreenCon = new FullScreenCon(this));
        protected override HotkeysCon HotkeysCon => _hotkeysCon ?? (_hotkeysCon = new HotkeysCon(this));
        protected override SignalsCon SignalsCon => _signalsCon ?? (_signalsCon = new SignalsCon(this));
        protected override RenderCon RenderCon => _renderCon ?? (_renderCon = new RenderCon(this));
        protected override SceneCodeCon SceneCodeCon => _sceneCodeCon ?? (_sceneCodeCon = new SceneCodeCon(this));
        protected override SceneCon SceneCon => _sceneCon ?? (_sceneCon = new SceneCon(this));
        protected override ScenePropertiesCon ScenePropertiesCon => _scenePropertiesCon ?? (_scenePropertiesCon = new ScenePropertiesCon(this));
        protected override ShaderCodeCon ShaderCodeCon => _shaderCodeCon ?? (_shaderCodeCon = new ShaderCodeCon(this));
        protected override ShapeCodeCon ShapeCodeCon => _shapeCodeCon ?? (_shapeCodeCon = new ShapeCodeCon(this));
        protected override ShapePropertiesCon ShapePropertiesCon => _shapePropertiesCon ?? (_shapePropertiesCon = new ShapePropertiesCon(this));

        // Private properties

        private DockPane HotkeysPane => HotkeysForm.Pane;
        private DockPane SceneCodePane => SceneCodeForm.Pane;
        private DockPane ScenePane => SceneForm.Pane;
        private DockPane ScenePropertiesPane => ScenePropertiesForm.Pane;
        private DockPane ShaderCodePane => ShaderCodeForm.Pane;
        private DockPane SignalsPane => SignalsForm.Pane;
        private DockPane ShapeCodePane => ShapeCodeForm.Pane;
        private DockPane ShapePropertiesPane => ShapePropertiesForm.Pane;
        private DockPanel WorldPanel => WorldForm.DockPanel;

        // Public methods

        public void ConnectCons(bool connect)
        {
            Array.ForEach(new LocalCon[]
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
                ShapeCodeCon,
                ShapePropertiesCon
            }, p => p.Connect(connect));
            if (!connect)
                RenderCon.Unload();
        }

        // Private methods

        private void RestoreWindowLayout()
        {
            const float
                hTop = 0.34f,
                hBottom = 0.35f;
            SceneForm.Show(WorldPanel, DockState.Document);
            ShaderCodeForm.Show(WorldPanel, DockState.DockRight);
            ShapePropertiesForm.Show(WorldPanel, DockState.DockLeft);
            ShapeCodeForm.Show(ShapePropertiesPane, DockAlignment.Bottom, 1 - hTop);
            ScenePropertiesForm.Show(ShapeCodePane, DockAlignment.Bottom, hBottom / (1 - hTop));
            SceneCodeForm.Show(ShapeCodePane, null);
            ShapeCodeForm.Activate();
            SignalsForm.Show(ShaderCodePane, DockAlignment.Bottom, hBottom);
            HotkeysForm.Show(WorldPanel, DockState.Float);
            HotkeysForm.Hide();
            SignalsForm.Activate();
        }

        private void WorldCon_PropertyEdit(object sender, PropertyEditEventArgs e)
        {
            switch (e.Property)
            {
                case Property.Shapes:
                    UpdateSelection();
                    break;
                case Property.TargetFps:
                    ClockInit();
                    break;
                case Property.GraphicsMode:
                case Property.Samples:
                case Property.Stereo:
                    UpdateGraphicsModeLabel();
                    break;
                case Property.GpuLog:
                case Property.GpuStatus:
                    UpdateGpuStatusLabel();
                    break;
            }
            SceneControl.Invalidate();
        }
    }
}
