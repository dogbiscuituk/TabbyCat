﻿namespace TabbyCat.Views
{
    partial class WorldForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.Toolbar = new TabbyCat.CustomControls.JmkToolStrip();
            this.tbNew = new System.Windows.Forms.ToolStripSplitButton();
            this.tbNewEmptyScene = new System.Windows.Forms.ToolStripMenuItem();
            this.tbNewFromTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.tbOpen = new System.Windows.Forms.ToolStripSplitButton();
            this.tbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbAdd = new System.Windows.Forms.ToolStripSplitButton();
            this.tbAddCurve = new System.Windows.Forms.ToolStripMenuItem();
            this.tbAddSurface = new System.Windows.Forms.ToolStripMenuItem();
            this.tbAddVolume = new System.Windows.Forms.ToolStripMenuItem();
            this.tbUndo = new System.Windows.Forms.ToolStripSplitButton();
            this.tbRedo = new System.Windows.Forms.ToolStripSplitButton();
            this.tbCut = new System.Windows.Forms.ToolStripButton();
            this.tbCopy = new System.Windows.Forms.ToolStripButton();
            this.tbPaste = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbFullScreen = new System.Windows.Forms.ToolStripButton();
            this.StatusBar = new TabbyCat.CustomControls.JmkStatusStrip();
            this.GraphicsModeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SpeedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.FpsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.GpuStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenu = new TabbyCat.CustomControls.JmkMenuStrip();
            this.TimeDecelerate = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeReverse = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeStop = new System.Windows.Forms.ToolStripMenuItem();
            this.TimePause = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeForward = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeAccelerate = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNewEmptyScene = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNewFromTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.FileReopen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.FileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.FileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EditUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.EditRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.EditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.EditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.EditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.EditDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.EditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.EditInvertSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.EditOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewScene = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewSignals = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewSceneProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewShapeProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewShaderCode = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewSceneCode = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewShapeCode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewRestoreWindowLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AddCurve = new System.Windows.Forms.ToolStripMenuItem();
            this.AddSurface = new System.Windows.Forms.ToolStripMenuItem();
            this.AddVolume = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraMove = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraMoveLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraMoveRight = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraMoveForward = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraMoveBack = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraStrafe = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraStrafeLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraStrafeRight = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraStrafeUp = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraStrafeDown = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraRollLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraRollRight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.CameraReset = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpOpenGLShadingLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpCodeHotkeys = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.HelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.Toolbar.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolTip
            // 
            this.ToolTip.AutomaticDelay = 100;
            this.ToolTip.AutoPopDelay = 10000;
            this.ToolTip.InitialDelay = 100;
            this.ToolTip.ReshowDelay = 20;
            // 
            // PopupMenu
            // 
            this.PopupMenu.Name = "PopupMenu";
            this.PopupMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // DockPanel
            // 
            this.DockPanel.DefaultFloatWindowSize = new System.Drawing.Size(328, 288);
            this.DockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DockPanel.DockLeftPortion = 320D;
            this.DockPanel.DockRightPortion = 320D;
            this.DockPanel.Location = new System.Drawing.Point(33, 25);
            this.DockPanel.Name = "DockPanel";
            this.DockPanel.Size = new System.Drawing.Size(1551, 814);
            this.DockPanel.TabIndex = 5;
            // 
            // Toolbar
            // 
            this.Toolbar.Dock = System.Windows.Forms.DockStyle.Left;
            this.Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbNew,
            this.tbOpen,
            this.tbSave,
            this.toolStripSeparator1,
            this.tbAdd,
            this.tbUndo,
            this.tbRedo,
            this.tbCut,
            this.tbCopy,
            this.tbPaste,
            this.tbDelete,
            this.toolStripSeparator2,
            this.tbFullScreen});
            this.Toolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.Toolbar.Location = new System.Drawing.Point(0, 25);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(33, 814);
            this.Toolbar.TabIndex = 3;
            // 
            // tbNew
            // 
            this.tbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbNewEmptyScene,
            this.tbNewFromTemplate});
            this.tbNew.Image = global::TabbyCat.Properties.Resources.NewDocumentHS;
            this.tbNew.ImageTransparentColor = System.Drawing.Color.White;
            this.tbNew.Name = "tbNew";
            this.tbNew.Size = new System.Drawing.Size(30, 20);
            // 
            // tbNewEmptyScene
            // 
            this.tbNewEmptyScene.Name = "tbNewEmptyScene";
            this.tbNewEmptyScene.Size = new System.Drawing.Size(187, 22);
            this.tbNewEmptyScene.Text = "New Empty Scene";
            // 
            // tbNewFromTemplate
            // 
            this.tbNewFromTemplate.Name = "tbNewFromTemplate";
            this.tbNewFromTemplate.Size = new System.Drawing.Size(187, 22);
            this.tbNewFromTemplate.Text = "New from Template...";
            // 
            // tbOpen
            // 
            this.tbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbOpen.Image = global::TabbyCat.Properties.Resources.OpenFileHS;
            this.tbOpen.ImageTransparentColor = System.Drawing.Color.Black;
            this.tbOpen.Name = "tbOpen";
            this.tbOpen.Size = new System.Drawing.Size(30, 20);
            // 
            // tbSave
            // 
            this.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSave.Image = global::TabbyCat.Properties.Resources.saveHS;
            this.tbSave.ImageTransparentColor = System.Drawing.Color.White;
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(30, 20);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(30, 6);
            // 
            // tbAdd
            // 
            this.tbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbAddCurve,
            this.tbAddSurface,
            this.tbAddVolume});
            this.tbAdd.Image = global::TabbyCat.Properties.Resources.action_add_16xLG;
            this.tbAdd.ImageTransparentColor = System.Drawing.Color.White;
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(30, 20);
            // 
            // tbAddCurve
            // 
            this.tbAddCurve.Name = "tbAddCurve";
            this.tbAddCurve.Size = new System.Drawing.Size(114, 22);
            this.tbAddCurve.Text = "Curve";
            // 
            // tbAddSurface
            // 
            this.tbAddSurface.Name = "tbAddSurface";
            this.tbAddSurface.Size = new System.Drawing.Size(114, 22);
            this.tbAddSurface.Text = "Surface";
            // 
            // tbAddVolume
            // 
            this.tbAddVolume.Name = "tbAddVolume";
            this.tbAddVolume.Size = new System.Drawing.Size(114, 22);
            this.tbAddVolume.Text = "Volume";
            // 
            // tbUndo
            // 
            this.tbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbUndo.Enabled = false;
            this.tbUndo.Image = global::TabbyCat.Properties.Resources.Edit_UndoHS;
            this.tbUndo.ImageTransparentColor = System.Drawing.Color.White;
            this.tbUndo.Name = "tbUndo";
            this.tbUndo.Size = new System.Drawing.Size(30, 20);
            // 
            // tbRedo
            // 
            this.tbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRedo.Enabled = false;
            this.tbRedo.Image = global::TabbyCat.Properties.Resources.Edit_RedoHS;
            this.tbRedo.ImageTransparentColor = System.Drawing.Color.White;
            this.tbRedo.Name = "tbRedo";
            this.tbRedo.Size = new System.Drawing.Size(30, 20);
            // 
            // tbCut
            // 
            this.tbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCut.Enabled = false;
            this.tbCut.Image = global::TabbyCat.Properties.Resources.CutHS;
            this.tbCut.ImageTransparentColor = System.Drawing.Color.White;
            this.tbCut.Name = "tbCut";
            this.tbCut.Size = new System.Drawing.Size(30, 20);
            // 
            // tbCopy
            // 
            this.tbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCopy.Enabled = false;
            this.tbCopy.Image = global::TabbyCat.Properties.Resources.CopyHS;
            this.tbCopy.ImageTransparentColor = System.Drawing.Color.White;
            this.tbCopy.Name = "tbCopy";
            this.tbCopy.Size = new System.Drawing.Size(30, 20);
            // 
            // tbPaste
            // 
            this.tbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPaste.Image = global::TabbyCat.Properties.Resources.PasteHS;
            this.tbPaste.ImageTransparentColor = System.Drawing.Color.White;
            this.tbPaste.Name = "tbPaste";
            this.tbPaste.Size = new System.Drawing.Size(30, 20);
            // 
            // tbDelete
            // 
            this.tbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDelete.Enabled = false;
            this.tbDelete.Image = global::TabbyCat.Properties.Resources.Delete;
            this.tbDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(30, 20);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(30, 6);
            // 
            // tbFullScreen
            // 
            this.tbFullScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbFullScreen.Image = global::TabbyCat.Properties.Resources.FullScreenHS;
            this.tbFullScreen.ImageTransparentColor = System.Drawing.Color.White;
            this.tbFullScreen.Name = "tbFullScreen";
            this.tbFullScreen.Size = new System.Drawing.Size(30, 20);
            this.tbFullScreen.Text = "toolStripButton1";
            // 
            // StatusBar
            // 
            this.StatusBar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GraphicsModeLabel,
            this.SpeedLabel,
            this.TimeLabel,
            this.FpsLabel,
            this.GpuStatusLabel});
            this.StatusBar.Location = new System.Drawing.Point(0, 839);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.ShowItemToolTips = true;
            this.StatusBar.Size = new System.Drawing.Size(1584, 22);
            this.StatusBar.TabIndex = 2;
            // 
            // GraphicsModeLabel
            // 
            this.GraphicsModeLabel.AutoSize = false;
            this.GraphicsModeLabel.Name = "GraphicsModeLabel";
            this.GraphicsModeLabel.Size = new System.Drawing.Size(64, 17);
            this.GraphicsModeLabel.Text = "mode 0";
            this.GraphicsModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = false;
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(64, 17);
            this.SpeedLabel.Text = "time × 1";
            this.SpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = false;
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(64, 17);
            this.TimeLabel.Text = "t=0.0";
            this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FpsLabel
            // 
            this.FpsLabel.AutoSize = false;
            this.FpsLabel.Name = "FpsLabel";
            this.FpsLabel.Size = new System.Drawing.Size(64, 17);
            this.FpsLabel.Text = "FPS=0.0";
            this.FpsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GpuStatusLabel
            // 
            this.GpuStatusLabel.Name = "GpuStatusLabel";
            this.GpuStatusLabel.Size = new System.Drawing.Size(1313, 17);
            this.GpuStatusLabel.Spring = true;
            this.GpuStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainMenu
            // 
            this.MainMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TimeDecelerate,
            this.TimeReverse,
            this.TimeStop,
            this.TimePause,
            this.TimeForward,
            this.TimeAccelerate,
            this.aToolStripMenuItem,
            this.FileMenu,
            this.EditMenu,
            this.ViewMenu,
            this.AddMenu,
            this.CameraMenu,
            this.HelpMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.ShowItemToolTips = true;
            this.MainMenu.Size = new System.Drawing.Size(1584, 25);
            this.MainMenu.TabIndex = 4;
            // 
            // TimeDecelerate
            // 
            this.TimeDecelerate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TimeDecelerate.Image = global::TabbyCat.Properties.Resources.RewindHS;
            this.TimeDecelerate.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TimeDecelerate.ImageTransparentColor = System.Drawing.Color.White;
            this.TimeDecelerate.Name = "TimeDecelerate";
            this.TimeDecelerate.Padding = new System.Windows.Forms.Padding(0);
            this.TimeDecelerate.Size = new System.Drawing.Size(20, 21);
            this.TimeDecelerate.Text = "Decelerate";
            // 
            // TimeReverse
            // 
            this.TimeReverse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TimeReverse.Image = global::TabbyCat.Properties.Resources.BackHS;
            this.TimeReverse.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TimeReverse.ImageTransparentColor = System.Drawing.Color.White;
            this.TimeReverse.Name = "TimeReverse";
            this.TimeReverse.Padding = new System.Windows.Forms.Padding(0);
            this.TimeReverse.Size = new System.Drawing.Size(20, 21);
            this.TimeReverse.Text = "Reverse";
            // 
            // TimeStop
            // 
            this.TimeStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TimeStop.Image = global::TabbyCat.Properties.Resources.StopHS;
            this.TimeStop.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TimeStop.ImageTransparentColor = System.Drawing.Color.White;
            this.TimeStop.Name = "TimeStop";
            this.TimeStop.Padding = new System.Windows.Forms.Padding(0);
            this.TimeStop.Size = new System.Drawing.Size(20, 21);
            this.TimeStop.Text = "Stop";
            // 
            // TimePause
            // 
            this.TimePause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TimePause.Image = global::TabbyCat.Properties.Resources.PauseHS;
            this.TimePause.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TimePause.ImageTransparentColor = System.Drawing.Color.White;
            this.TimePause.Name = "TimePause";
            this.TimePause.Padding = new System.Windows.Forms.Padding(0);
            this.TimePause.Size = new System.Drawing.Size(20, 21);
            this.TimePause.Text = "Pause";
            // 
            // TimeForward
            // 
            this.TimeForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TimeForward.Image = global::TabbyCat.Properties.Resources.PlayHS;
            this.TimeForward.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TimeForward.Name = "TimeForward";
            this.TimeForward.Padding = new System.Windows.Forms.Padding(0);
            this.TimeForward.Size = new System.Drawing.Size(20, 21);
            this.TimeForward.Text = "Forward";
            // 
            // TimeAccelerate
            // 
            this.TimeAccelerate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TimeAccelerate.Image = global::TabbyCat.Properties.Resources.FFwdHS;
            this.TimeAccelerate.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TimeAccelerate.ImageTransparentColor = System.Drawing.Color.White;
            this.TimeAccelerate.Name = "TimeAccelerate";
            this.TimeAccelerate.Padding = new System.Windows.Forms.Padding(0);
            this.TimeAccelerate.Size = new System.Drawing.Size(20, 21);
            this.TimeAccelerate.Text = "Accelerate";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(25, 21);
            this.aToolStripMenuItem.Text = "-";
            this.aToolStripMenuItem.Visible = false;
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNew,
            this.FileOpen,
            this.FileReopen,
            this.toolStripMenuItem1,
            this.FileSave,
            this.FileSaveAs,
            this.toolStripMenuItem2,
            this.FileClose,
            this.FileExit});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(39, 21);
            this.FileMenu.Text = "File";
            // 
            // FileNew
            // 
            this.FileNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNewEmptyScene,
            this.FileNewFromTemplate});
            this.FileNew.Image = global::TabbyCat.Properties.Resources.NewDocumentHS;
            this.FileNew.Name = "FileNew";
            this.FileNew.Size = new System.Drawing.Size(164, 22);
            this.FileNew.Text = "New";
            // 
            // FileNewEmptyScene
            // 
            this.FileNewEmptyScene.Name = "FileNewEmptyScene";
            this.FileNewEmptyScene.Size = new System.Drawing.Size(172, 22);
            this.FileNewEmptyScene.Text = "&Empty Scene";
            // 
            // FileNewFromTemplate
            // 
            this.FileNewFromTemplate.Name = "FileNewFromTemplate";
            this.FileNewFromTemplate.Size = new System.Drawing.Size(172, 22);
            this.FileNewFromTemplate.Text = "&From Template...";
            // 
            // FileOpen
            // 
            this.FileOpen.Image = global::TabbyCat.Properties.Resources.OpenFileHS;
            this.FileOpen.ImageTransparentColor = System.Drawing.Color.Black;
            this.FileOpen.Name = "FileOpen";
            this.FileOpen.Size = new System.Drawing.Size(164, 22);
            this.FileOpen.Text = "Open...";
            // 
            // FileReopen
            // 
            this.FileReopen.Name = "FileReopen";
            this.FileReopen.Size = new System.Drawing.Size(164, 22);
            this.FileReopen.Text = "Reopen";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(161, 6);
            // 
            // FileSave
            // 
            this.FileSave.Image = global::TabbyCat.Properties.Resources.saveHS;
            this.FileSave.Name = "FileSave";
            this.FileSave.Size = new System.Drawing.Size(164, 22);
            this.FileSave.Text = "Save";
            // 
            // FileSaveAs
            // 
            this.FileSaveAs.Name = "FileSaveAs";
            this.FileSaveAs.Size = new System.Drawing.Size(164, 22);
            this.FileSaveAs.Text = "Save As...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(161, 6);
            // 
            // FileClose
            // 
            this.FileClose.Name = "FileClose";
            this.FileClose.Size = new System.Drawing.Size(164, 22);
            this.FileClose.Text = "Close";
            // 
            // FileExit
            // 
            this.FileExit.Name = "FileExit";
            this.FileExit.Size = new System.Drawing.Size(164, 22);
            this.FileExit.Text = "Close All && Exit";
            // 
            // EditMenu
            // 
            this.EditMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditUndo,
            this.EditRedo,
            this.toolStripMenuItem8,
            this.EditCut,
            this.EditCopy,
            this.EditPaste,
            this.EditDelete,
            this.toolStripMenuItem9,
            this.EditSelectAll,
            this.EditInvertSelection,
            this.toolStripMenuItem10,
            this.EditOptions});
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(42, 21);
            this.EditMenu.Text = "Edit";
            // 
            // EditUndo
            // 
            this.EditUndo.Enabled = false;
            this.EditUndo.Image = global::TabbyCat.Properties.Resources.Edit_UndoHS;
            this.EditUndo.ImageTransparentColor = System.Drawing.Color.White;
            this.EditUndo.Name = "EditUndo";
            this.EditUndo.Size = new System.Drawing.Size(164, 22);
            this.EditUndo.Text = "Undo";
            // 
            // EditRedo
            // 
            this.EditRedo.Enabled = false;
            this.EditRedo.Image = global::TabbyCat.Properties.Resources.Edit_RedoHS;
            this.EditRedo.ImageTransparentColor = System.Drawing.Color.White;
            this.EditRedo.Name = "EditRedo";
            this.EditRedo.Size = new System.Drawing.Size(164, 22);
            this.EditRedo.Text = "Redo";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(161, 6);
            // 
            // EditCut
            // 
            this.EditCut.Enabled = false;
            this.EditCut.Image = global::TabbyCat.Properties.Resources.CutHS;
            this.EditCut.ImageTransparentColor = System.Drawing.Color.White;
            this.EditCut.Name = "EditCut";
            this.EditCut.Size = new System.Drawing.Size(164, 22);
            this.EditCut.Text = "Cut";
            // 
            // EditCopy
            // 
            this.EditCopy.Enabled = false;
            this.EditCopy.Image = global::TabbyCat.Properties.Resources.CopyHS;
            this.EditCopy.ImageTransparentColor = System.Drawing.Color.White;
            this.EditCopy.Name = "EditCopy";
            this.EditCopy.Size = new System.Drawing.Size(164, 22);
            this.EditCopy.Text = "Copy";
            // 
            // EditPaste
            // 
            this.EditPaste.Image = global::TabbyCat.Properties.Resources.PasteHS;
            this.EditPaste.ImageTransparentColor = System.Drawing.Color.White;
            this.EditPaste.Name = "EditPaste";
            this.EditPaste.Size = new System.Drawing.Size(164, 22);
            this.EditPaste.Text = "Paste";
            // 
            // EditDelete
            // 
            this.EditDelete.Enabled = false;
            this.EditDelete.Image = global::TabbyCat.Properties.Resources.Delete;
            this.EditDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.EditDelete.Name = "EditDelete";
            this.EditDelete.Size = new System.Drawing.Size(164, 22);
            this.EditDelete.Text = "Delete";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(161, 6);
            // 
            // EditSelectAll
            // 
            this.EditSelectAll.Name = "EditSelectAll";
            this.EditSelectAll.Size = new System.Drawing.Size(164, 22);
            this.EditSelectAll.Text = "Select All";
            // 
            // EditInvertSelection
            // 
            this.EditInvertSelection.Name = "EditInvertSelection";
            this.EditInvertSelection.Size = new System.Drawing.Size(164, 22);
            this.EditInvertSelection.Text = "Invert Selection";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(161, 6);
            // 
            // EditOptions
            // 
            this.EditOptions.Name = "EditOptions";
            this.EditOptions.Size = new System.Drawing.Size(164, 22);
            this.EditOptions.Text = "Options...";
            // 
            // ViewMenu
            // 
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewScene,
            this.ViewSignals,
            this.toolStripMenuItem6,
            this.ViewSceneProperties,
            this.ViewShapeProperties,
            this.toolStripMenuItem3,
            this.ViewShaderCode,
            this.ViewSceneCode,
            this.ViewShapeCode,
            this.toolStripMenuItem7,
            this.ViewFullScreen,
            this.ViewRestoreWindowLayout});
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(47, 21);
            this.ViewMenu.Text = "View";
            // 
            // ViewScene
            // 
            this.ViewScene.Name = "ViewScene";
            this.ViewScene.Size = new System.Drawing.Size(208, 22);
            this.ViewScene.Text = "Scene";
            // 
            // ViewSignals
            // 
            this.ViewSignals.Name = "ViewSignals";
            this.ViewSignals.Size = new System.Drawing.Size(208, 22);
            this.ViewSignals.Text = "Signals";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(205, 6);
            // 
            // ViewSceneProperties
            // 
            this.ViewSceneProperties.Name = "ViewSceneProperties";
            this.ViewSceneProperties.Size = new System.Drawing.Size(208, 22);
            this.ViewSceneProperties.Text = "Scene properties";
            // 
            // ViewShapeProperties
            // 
            this.ViewShapeProperties.Name = "ViewShapeProperties";
            this.ViewShapeProperties.Size = new System.Drawing.Size(208, 22);
            this.ViewShapeProperties.Text = "Shape properties";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(205, 6);
            // 
            // ViewShaderCode
            // 
            this.ViewShaderCode.Name = "ViewShaderCode";
            this.ViewShaderCode.Size = new System.Drawing.Size(208, 22);
            this.ViewShaderCode.Text = "All code";
            // 
            // ViewSceneCode
            // 
            this.ViewSceneCode.Name = "ViewSceneCode";
            this.ViewSceneCode.Size = new System.Drawing.Size(208, 22);
            this.ViewSceneCode.Text = "Scene code";
            // 
            // ViewShapeCode
            // 
            this.ViewShapeCode.Name = "ViewShapeCode";
            this.ViewShapeCode.Size = new System.Drawing.Size(208, 22);
            this.ViewShapeCode.Text = "Shape code";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(205, 6);
            // 
            // ViewFullScreen
            // 
            this.ViewFullScreen.Image = global::TabbyCat.Properties.Resources.FullScreenHS;
            this.ViewFullScreen.ImageTransparentColor = System.Drawing.Color.White;
            this.ViewFullScreen.Name = "ViewFullScreen";
            this.ViewFullScreen.Size = new System.Drawing.Size(208, 22);
            this.ViewFullScreen.Text = "Full screen";
            // 
            // ViewRestoreWindowLayout
            // 
            this.ViewRestoreWindowLayout.Name = "ViewRestoreWindowLayout";
            this.ViewRestoreWindowLayout.Size = new System.Drawing.Size(208, 22);
            this.ViewRestoreWindowLayout.Text = "Restore window layout";
            // 
            // AddMenu
            // 
            this.AddMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddCurve,
            this.AddSurface,
            this.AddVolume});
            this.AddMenu.Image = global::TabbyCat.Properties.Resources.action_add_16xLG;
            this.AddMenu.ImageTransparentColor = System.Drawing.Color.White;
            this.AddMenu.Name = "AddMenu";
            this.AddMenu.Size = new System.Drawing.Size(44, 21);
            this.AddMenu.Text = "Add";
            // 
            // AddCurve
            // 
            this.AddCurve.Name = "AddCurve";
            this.AddCurve.Size = new System.Drawing.Size(119, 22);
            this.AddCurve.Text = "Curve";
            // 
            // AddSurface
            // 
            this.AddSurface.Name = "AddSurface";
            this.AddSurface.Size = new System.Drawing.Size(119, 22);
            this.AddSurface.Text = "Surface";
            // 
            // AddVolume
            // 
            this.AddVolume.Name = "AddVolume";
            this.AddVolume.Size = new System.Drawing.Size(119, 22);
            this.AddVolume.Text = "Volume";
            // 
            // CameraMenu
            // 
            this.CameraMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CameraMove,
            this.CameraStrafe,
            this.toolStripMenuItem5,
            this.CameraReset});
            this.CameraMenu.Name = "CameraMenu";
            this.CameraMenu.Size = new System.Drawing.Size(65, 21);
            this.CameraMenu.Text = "Camera";
            // 
            // CameraMove
            // 
            this.CameraMove.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CameraMoveLeft,
            this.CameraMoveRight,
            this.CameraMoveUp,
            this.CameraMoveDown,
            this.CameraMoveForward,
            this.CameraMoveBack});
            this.CameraMove.Name = "CameraMove";
            this.CameraMove.Size = new System.Drawing.Size(110, 22);
            this.CameraMove.Text = "Move";
            // 
            // CameraMoveLeft
            // 
            this.CameraMoveLeft.Name = "CameraMoveLeft";
            this.CameraMoveLeft.Size = new System.Drawing.Size(124, 22);
            this.CameraMoveLeft.Text = "Left";
            // 
            // CameraMoveRight
            // 
            this.CameraMoveRight.Name = "CameraMoveRight";
            this.CameraMoveRight.Size = new System.Drawing.Size(124, 22);
            this.CameraMoveRight.Text = "Right";
            // 
            // CameraMoveUp
            // 
            this.CameraMoveUp.Name = "CameraMoveUp";
            this.CameraMoveUp.Size = new System.Drawing.Size(124, 22);
            this.CameraMoveUp.Text = "Up";
            // 
            // CameraMoveDown
            // 
            this.CameraMoveDown.Name = "CameraMoveDown";
            this.CameraMoveDown.Size = new System.Drawing.Size(124, 22);
            this.CameraMoveDown.Text = "Down";
            // 
            // CameraMoveForward
            // 
            this.CameraMoveForward.Name = "CameraMoveForward";
            this.CameraMoveForward.Size = new System.Drawing.Size(124, 22);
            this.CameraMoveForward.Text = "Forward";
            // 
            // CameraMoveBack
            // 
            this.CameraMoveBack.Name = "CameraMoveBack";
            this.CameraMoveBack.Size = new System.Drawing.Size(124, 22);
            this.CameraMoveBack.Text = "Back";
            // 
            // CameraStrafe
            // 
            this.CameraStrafe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CameraStrafeLeft,
            this.CameraStrafeRight,
            this.CameraStrafeUp,
            this.CameraStrafeDown,
            this.CameraRollLeft,
            this.CameraRollRight});
            this.CameraStrafe.Name = "CameraStrafe";
            this.CameraStrafe.Size = new System.Drawing.Size(110, 22);
            this.CameraStrafe.Text = "Strafe";
            // 
            // CameraStrafeLeft
            // 
            this.CameraStrafeLeft.Name = "CameraStrafeLeft";
            this.CameraStrafeLeft.Size = new System.Drawing.Size(132, 22);
            this.CameraStrafeLeft.Text = "Left";
            // 
            // CameraStrafeRight
            // 
            this.CameraStrafeRight.Name = "CameraStrafeRight";
            this.CameraStrafeRight.Size = new System.Drawing.Size(132, 22);
            this.CameraStrafeRight.Text = "Right";
            // 
            // CameraStrafeUp
            // 
            this.CameraStrafeUp.Name = "CameraStrafeUp";
            this.CameraStrafeUp.Size = new System.Drawing.Size(132, 22);
            this.CameraStrafeUp.Text = "Up";
            // 
            // CameraStrafeDown
            // 
            this.CameraStrafeDown.Name = "CameraStrafeDown";
            this.CameraStrafeDown.Size = new System.Drawing.Size(132, 22);
            this.CameraStrafeDown.Text = "Down";
            // 
            // CameraRollLeft
            // 
            this.CameraRollLeft.Name = "CameraRollLeft";
            this.CameraRollLeft.Size = new System.Drawing.Size(132, 22);
            this.CameraRollLeft.Text = "Roll Left";
            // 
            // CameraRollRight
            // 
            this.CameraRollRight.Name = "CameraRollRight";
            this.CameraRollRight.Size = new System.Drawing.Size(132, 22);
            this.CameraRollRight.Text = "Roll Right";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(107, 6);
            // 
            // CameraReset
            // 
            this.CameraReset.Name = "CameraReset";
            this.CameraReset.Size = new System.Drawing.Size(110, 22);
            this.CameraReset.Text = "Reset";
            // 
            // HelpMenu
            // 
            this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpOpenGLShadingLanguage,
            this.HelpCodeHotkeys,
            this.toolStripMenuItem12,
            this.HelpAbout});
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(47, 21);
            this.HelpMenu.Text = "Help";
            // 
            // HelpOpenGLShadingLanguage
            // 
            this.HelpOpenGLShadingLanguage.Name = "HelpOpenGLShadingLanguage";
            this.HelpOpenGLShadingLanguage.Size = new System.Drawing.Size(247, 22);
            this.HelpOpenGLShadingLanguage.Text = "OpenGL® Shading Language";
            // 
            // HelpCodeHotkeys
            // 
            this.HelpCodeHotkeys.Name = "HelpCodeHotkeys";
            this.HelpCodeHotkeys.Size = new System.Drawing.Size(247, 22);
            this.HelpCodeHotkeys.Text = "Code hotkeys";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(244, 6);
            // 
            // HelpAbout
            // 
            this.HelpAbout.Name = "HelpAbout";
            this.HelpAbout.Size = new System.Drawing.Size(247, 22);
            this.HelpAbout.Text = "About";
            // 
            // WorldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.ContextMenuStrip = this.PopupMenu;
            this.Controls.Add(this.DockPanel);
            this.Controls.Add(this.Toolbar);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.MainMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WorldForm";
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolTip ToolTip;
        public System.Windows.Forms.ContextMenuStrip PopupMenu;
        public CustomControls.JmkStatusStrip StatusBar;
        public System.Windows.Forms.ToolStripStatusLabel SpeedLabel;
        public System.Windows.Forms.ToolStripStatusLabel TimeLabel;
        public System.Windows.Forms.ToolStripStatusLabel FpsLabel;
        public CustomControls.JmkToolStrip Toolbar;
        public System.Windows.Forms.ToolStripSplitButton tbNew;
        public System.Windows.Forms.ToolStripMenuItem tbNewEmptyScene;
        public System.Windows.Forms.ToolStripMenuItem tbNewFromTemplate;
        public System.Windows.Forms.ToolStripSplitButton tbOpen;
        public System.Windows.Forms.ToolStripButton tbSave;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripSplitButton tbAdd;
        public System.Windows.Forms.ToolStripSplitButton tbUndo;
        public System.Windows.Forms.ToolStripSplitButton tbRedo;
        public System.Windows.Forms.ToolStripButton tbCut;
        public System.Windows.Forms.ToolStripButton tbCopy;
        public System.Windows.Forms.ToolStripButton tbPaste;
        public System.Windows.Forms.ToolStripButton tbDelete;
        public CustomControls.JmkMenuStrip MainMenu;
        public System.Windows.Forms.ToolStripMenuItem TimeDecelerate;
        public System.Windows.Forms.ToolStripMenuItem TimeReverse;
        public System.Windows.Forms.ToolStripMenuItem TimeStop;
        public System.Windows.Forms.ToolStripMenuItem TimePause;
        public System.Windows.Forms.ToolStripMenuItem TimeForward;
        public System.Windows.Forms.ToolStripMenuItem TimeAccelerate;
        public System.Windows.Forms.ToolStripMenuItem FileMenu;
        public System.Windows.Forms.ToolStripMenuItem FileNew;
        public System.Windows.Forms.ToolStripMenuItem FileOpen;
        public System.Windows.Forms.ToolStripMenuItem FileReopen;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem FileSave;
        public System.Windows.Forms.ToolStripMenuItem FileSaveAs;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem FileClose;
        public System.Windows.Forms.ToolStripMenuItem FileExit;
        public System.Windows.Forms.ToolStripMenuItem EditMenu;
        public System.Windows.Forms.ToolStripMenuItem EditUndo;
        public System.Windows.Forms.ToolStripMenuItem EditRedo;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        public System.Windows.Forms.ToolStripMenuItem EditCut;
        public System.Windows.Forms.ToolStripMenuItem EditCopy;
        public System.Windows.Forms.ToolStripMenuItem EditPaste;
        public System.Windows.Forms.ToolStripMenuItem EditDelete;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        public System.Windows.Forms.ToolStripMenuItem EditSelectAll;
        public System.Windows.Forms.ToolStripMenuItem EditInvertSelection;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        public System.Windows.Forms.ToolStripMenuItem EditOptions;
        public System.Windows.Forms.ToolStripMenuItem CameraMenu;
        public System.Windows.Forms.ToolStripMenuItem CameraMove;
        public System.Windows.Forms.ToolStripMenuItem CameraMoveLeft;
        public System.Windows.Forms.ToolStripMenuItem CameraMoveRight;
        public System.Windows.Forms.ToolStripMenuItem CameraMoveUp;
        public System.Windows.Forms.ToolStripMenuItem CameraMoveDown;
        public System.Windows.Forms.ToolStripMenuItem CameraMoveForward;
        public System.Windows.Forms.ToolStripMenuItem CameraMoveBack;
        public System.Windows.Forms.ToolStripMenuItem CameraStrafe;
        public System.Windows.Forms.ToolStripMenuItem CameraStrafeLeft;
        public System.Windows.Forms.ToolStripMenuItem CameraStrafeRight;
        public System.Windows.Forms.ToolStripMenuItem CameraStrafeUp;
        public System.Windows.Forms.ToolStripMenuItem CameraStrafeDown;
        public System.Windows.Forms.ToolStripMenuItem CameraRollLeft;
        public System.Windows.Forms.ToolStripMenuItem CameraRollRight;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        public System.Windows.Forms.ToolStripMenuItem CameraReset;
        public System.Windows.Forms.ToolStripMenuItem HelpMenu;
        public System.Windows.Forms.ToolStripMenuItem HelpOpenGLShadingLanguage;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        public System.Windows.Forms.ToolStripMenuItem HelpAbout;
        public WeifenLuo.WinFormsUI.Docking.DockPanel DockPanel;
        public System.Windows.Forms.ToolStripMenuItem ViewMenu;
        public System.Windows.Forms.ToolStripStatusLabel GpuStatusLabel;
        public System.Windows.Forms.ToolStripMenuItem ViewSceneProperties;
        public System.Windows.Forms.ToolStripMenuItem ViewShapeProperties;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        public System.Windows.Forms.ToolStripMenuItem ViewSceneCode;
        public System.Windows.Forms.ToolStripMenuItem ViewShapeCode;
        public System.Windows.Forms.ToolStripMenuItem ViewShaderCode;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        public System.Windows.Forms.ToolStripMenuItem ViewScene;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        public System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem tbAddCurve;
        public System.Windows.Forms.ToolStripMenuItem tbAddSurface;
        public System.Windows.Forms.ToolStripMenuItem FileNewEmptyScene;
        public System.Windows.Forms.ToolStripMenuItem FileNewFromTemplate;
        public System.Windows.Forms.ToolStripMenuItem AddCurve;
        public System.Windows.Forms.ToolStripMenuItem AddSurface;
        public System.Windows.Forms.ToolStripMenuItem AddMenu;
        public System.Windows.Forms.ToolStripMenuItem AddVolume;
        public System.Windows.Forms.ToolStripMenuItem tbAddVolume;
        public System.Windows.Forms.ToolStripMenuItem ViewSignals;
        public System.Windows.Forms.ToolStripMenuItem ViewRestoreWindowLayout;
        public System.Windows.Forms.ToolStripStatusLabel GraphicsModeLabel;
        public System.Windows.Forms.ToolStripMenuItem ViewFullScreen;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton tbFullScreen;
        public System.Windows.Forms.ToolStripMenuItem HelpCodeHotkeys;
    }
}