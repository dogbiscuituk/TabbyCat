namespace TabbyCat.Views
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
            this.Toolbar = new Jmk.Controls.JmkToolStrip();
            this.tbNew = new System.Windows.Forms.ToolStripSplitButton();
            this.tbNewEmptyScene = new System.Windows.Forms.ToolStripMenuItem();
            this.tbNewFromTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.tbOpen = new System.Windows.Forms.ToolStripSplitButton();
            this.tbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbAdd = new System.Windows.Forms.ToolStripButton();
            this.tbUndo = new System.Windows.Forms.ToolStripSplitButton();
            this.tbRedo = new System.Windows.Forms.ToolStripSplitButton();
            this.tbCut = new System.Windows.Forms.ToolStripButton();
            this.tbCopy = new System.Windows.Forms.ToolStripButton();
            this.tbPaste = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.StatusBar = new Jmk.Controls.JmkStatusStrip();
            this.SpeedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Tlabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.FPSlabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.GpuStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenu = new Jmk.Controls.JmkMenuStrip();
            this.TimeDecelerate = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeReverse = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeStop = new System.Windows.Forms.ToolStripMenuItem();
            this.TimePause = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeForward = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeAccelerate = new System.Windows.Forms.ToolStripMenuItem();
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
            this.EditAddNewTrace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
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
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewSceneProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewTraceProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewAllCode = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewSceneCode = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewTraceCode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewGraphicsState = new System.Windows.Forms.ToolStripMenuItem();
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
            this.DockPanel.DefaultFloatWindowSize = new System.Drawing.Size(370, 289);
            this.DockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DockPanel.DockLeftPortion = 360D;
            this.DockPanel.DockRightPortion = 330D;
            this.DockPanel.DocumentTabStripLocation = WeifenLuo.WinFormsUI.Docking.DocumentTabStripLocation.Bottom;
            this.DockPanel.Location = new System.Drawing.Point(33, 25);
            this.DockPanel.Name = "DockPanel";
            this.DockPanel.Size = new System.Drawing.Size(975, 682);
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
            this.tbDelete});
            this.Toolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.Toolbar.Location = new System.Drawing.Point(0, 25);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(33, 682);
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
            this.tbAdd.Image = global::TabbyCat.Properties.Resources.action_add_16xLG;
            this.tbAdd.ImageTransparentColor = System.Drawing.Color.White;
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(30, 20);
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
            // StatusBar
            // 
            this.StatusBar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SpeedLabel,
            this.Tlabel,
            this.FPSlabel,
            this.GpuStatusLabel});
            this.StatusBar.Location = new System.Drawing.Point(0, 707);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.ShowItemToolTips = true;
            this.StatusBar.Size = new System.Drawing.Size(1008, 22);
            this.StatusBar.TabIndex = 2;
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = false;
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(64, 17);
            this.SpeedLabel.Text = "time × 1";
            // 
            // Tlabel
            // 
            this.Tlabel.AutoSize = false;
            this.Tlabel.Name = "Tlabel";
            this.Tlabel.Size = new System.Drawing.Size(64, 17);
            this.Tlabel.Text = "t=0.0";
            // 
            // FPSlabel
            // 
            this.FPSlabel.AutoSize = false;
            this.FPSlabel.Name = "FPSlabel";
            this.FPSlabel.Size = new System.Drawing.Size(64, 17);
            this.FPSlabel.Text = "FPS=0.0";
            // 
            // GpuStatusLabel
            // 
            this.GpuStatusLabel.Name = "GpuStatusLabel";
            this.GpuStatusLabel.Size = new System.Drawing.Size(801, 17);
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
            this.FileMenu,
            this.EditMenu,
            this.ViewMenu,
            this.CameraMenu,
            this.HelpMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.ShowItemToolTips = true;
            this.MainMenu.Size = new System.Drawing.Size(1008, 25);
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
            this.EditAddNewTrace,
            this.toolStripMenuItem4,
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
            // EditAddNewTrace
            // 
            this.EditAddNewTrace.Image = global::TabbyCat.Properties.Resources.action_add_16xLG;
            this.EditAddNewTrace.ImageTransparentColor = System.Drawing.Color.White;
            this.EditAddNewTrace.Name = "EditAddNewTrace";
            this.EditAddNewTrace.Size = new System.Drawing.Size(176, 22);
            this.EditAddNewTrace.Text = "Add a New Trace";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(173, 6);
            // 
            // EditUndo
            // 
            this.EditUndo.Enabled = false;
            this.EditUndo.Image = global::TabbyCat.Properties.Resources.Edit_UndoHS;
            this.EditUndo.ImageTransparentColor = System.Drawing.Color.White;
            this.EditUndo.Name = "EditUndo";
            this.EditUndo.Size = new System.Drawing.Size(176, 22);
            this.EditUndo.Text = "Undo";
            // 
            // EditRedo
            // 
            this.EditRedo.Enabled = false;
            this.EditRedo.Image = global::TabbyCat.Properties.Resources.Edit_RedoHS;
            this.EditRedo.ImageTransparentColor = System.Drawing.Color.White;
            this.EditRedo.Name = "EditRedo";
            this.EditRedo.Size = new System.Drawing.Size(176, 22);
            this.EditRedo.Text = "Redo";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(173, 6);
            // 
            // EditCut
            // 
            this.EditCut.Enabled = false;
            this.EditCut.Image = global::TabbyCat.Properties.Resources.CutHS;
            this.EditCut.ImageTransparentColor = System.Drawing.Color.White;
            this.EditCut.Name = "EditCut";
            this.EditCut.Size = new System.Drawing.Size(176, 22);
            this.EditCut.Text = "Cut";
            // 
            // EditCopy
            // 
            this.EditCopy.Enabled = false;
            this.EditCopy.Image = global::TabbyCat.Properties.Resources.CopyHS;
            this.EditCopy.ImageTransparentColor = System.Drawing.Color.White;
            this.EditCopy.Name = "EditCopy";
            this.EditCopy.Size = new System.Drawing.Size(176, 22);
            this.EditCopy.Text = "Copy";
            // 
            // EditPaste
            // 
            this.EditPaste.Image = global::TabbyCat.Properties.Resources.PasteHS;
            this.EditPaste.ImageTransparentColor = System.Drawing.Color.White;
            this.EditPaste.Name = "EditPaste";
            this.EditPaste.Size = new System.Drawing.Size(176, 22);
            this.EditPaste.Text = "Paste";
            // 
            // EditDelete
            // 
            this.EditDelete.Enabled = false;
            this.EditDelete.Image = global::TabbyCat.Properties.Resources.Delete;
            this.EditDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.EditDelete.Name = "EditDelete";
            this.EditDelete.Size = new System.Drawing.Size(176, 22);
            this.EditDelete.Text = "Delete";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(173, 6);
            // 
            // EditSelectAll
            // 
            this.EditSelectAll.Name = "EditSelectAll";
            this.EditSelectAll.Size = new System.Drawing.Size(176, 22);
            this.EditSelectAll.Text = "Select All";
            // 
            // EditInvertSelection
            // 
            this.EditInvertSelection.Name = "EditInvertSelection";
            this.EditInvertSelection.Size = new System.Drawing.Size(176, 22);
            this.EditInvertSelection.Text = "Invert Selection";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(173, 6);
            // 
            // EditOptions
            // 
            this.EditOptions.Name = "EditOptions";
            this.EditOptions.Size = new System.Drawing.Size(176, 22);
            this.EditOptions.Text = "Options...";
            // 
            // ViewMenu
            // 
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewScene,
            this.toolStripMenuItem6,
            this.ViewSceneProperties,
            this.ViewTraceProperties,
            this.toolStripMenuItem3,
            this.ViewAllCode,
            this.ViewSceneCode,
            this.ViewTraceCode,
            this.toolStripMenuItem7,
            this.ViewGraphicsState});
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(47, 21);
            this.ViewMenu.Text = "View";
            // 
            // ViewScene
            // 
            this.ViewScene.Name = "ViewScene";
            this.ViewScene.Size = new System.Drawing.Size(175, 22);
            this.ViewScene.Text = "Scene";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(172, 6);
            // 
            // ViewSceneProperties
            // 
            this.ViewSceneProperties.Name = "ViewSceneProperties";
            this.ViewSceneProperties.Size = new System.Drawing.Size(175, 22);
            this.ViewSceneProperties.Text = "Scene properties";
            // 
            // ViewTraceProperties
            // 
            this.ViewTraceProperties.Name = "ViewTraceProperties";
            this.ViewTraceProperties.Size = new System.Drawing.Size(175, 22);
            this.ViewTraceProperties.Text = "Trace properties";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(172, 6);
            // 
            // ViewAllCode
            // 
            this.ViewAllCode.Name = "ViewAllCode";
            this.ViewAllCode.Size = new System.Drawing.Size(175, 22);
            this.ViewAllCode.Text = "All code";
            // 
            // ViewSceneCode
            // 
            this.ViewSceneCode.Name = "ViewSceneCode";
            this.ViewSceneCode.Size = new System.Drawing.Size(175, 22);
            this.ViewSceneCode.Text = "Scene code";
            // 
            // ViewTraceCode
            // 
            this.ViewTraceCode.Name = "ViewTraceCode";
            this.ViewTraceCode.Size = new System.Drawing.Size(175, 22);
            this.ViewTraceCode.Text = "Trace code";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(172, 6);
            // 
            // ViewGraphicsState
            // 
            this.ViewGraphicsState.Name = "ViewGraphicsState";
            this.ViewGraphicsState.Size = new System.Drawing.Size(175, 22);
            this.ViewGraphicsState.Text = "Graphics state";
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
            this.ClientSize = new System.Drawing.Size(1008, 729);
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
        internal System.Windows.Forms.ToolTip ToolTip;
        internal System.Windows.Forms.ContextMenuStrip PopupMenu;
        internal Jmk.Controls.JmkStatusStrip StatusBar;
        internal System.Windows.Forms.ToolStripStatusLabel SpeedLabel;
        internal System.Windows.Forms.ToolStripStatusLabel Tlabel;
        internal System.Windows.Forms.ToolStripStatusLabel FPSlabel;
        internal Jmk.Controls.JmkToolStrip Toolbar;
        internal System.Windows.Forms.ToolStripSplitButton tbNew;
        internal System.Windows.Forms.ToolStripMenuItem tbNewEmptyScene;
        internal System.Windows.Forms.ToolStripMenuItem tbNewFromTemplate;
        internal System.Windows.Forms.ToolStripSplitButton tbOpen;
        internal System.Windows.Forms.ToolStripButton tbSave;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton tbAdd;
        internal System.Windows.Forms.ToolStripSplitButton tbUndo;
        internal System.Windows.Forms.ToolStripSplitButton tbRedo;
        internal System.Windows.Forms.ToolStripButton tbCut;
        internal System.Windows.Forms.ToolStripButton tbCopy;
        internal System.Windows.Forms.ToolStripButton tbPaste;
        internal System.Windows.Forms.ToolStripButton tbDelete;
        internal Jmk.Controls.JmkMenuStrip MainMenu;
        internal System.Windows.Forms.ToolStripMenuItem TimeDecelerate;
        internal System.Windows.Forms.ToolStripMenuItem TimeReverse;
        internal System.Windows.Forms.ToolStripMenuItem TimeStop;
        internal System.Windows.Forms.ToolStripMenuItem TimePause;
        internal System.Windows.Forms.ToolStripMenuItem TimeForward;
        internal System.Windows.Forms.ToolStripMenuItem TimeAccelerate;
        internal System.Windows.Forms.ToolStripMenuItem FileMenu;
        internal System.Windows.Forms.ToolStripMenuItem FileNew;
        internal System.Windows.Forms.ToolStripMenuItem FileNewEmptyScene;
        internal System.Windows.Forms.ToolStripMenuItem FileNewFromTemplate;
        internal System.Windows.Forms.ToolStripMenuItem FileOpen;
        internal System.Windows.Forms.ToolStripMenuItem FileReopen;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem FileSave;
        internal System.Windows.Forms.ToolStripMenuItem FileSaveAs;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        internal System.Windows.Forms.ToolStripMenuItem FileClose;
        internal System.Windows.Forms.ToolStripMenuItem FileExit;
        internal System.Windows.Forms.ToolStripMenuItem EditMenu;
        internal System.Windows.Forms.ToolStripMenuItem EditAddNewTrace;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        internal System.Windows.Forms.ToolStripMenuItem EditUndo;
        internal System.Windows.Forms.ToolStripMenuItem EditRedo;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        internal System.Windows.Forms.ToolStripMenuItem EditCut;
        internal System.Windows.Forms.ToolStripMenuItem EditCopy;
        internal System.Windows.Forms.ToolStripMenuItem EditPaste;
        internal System.Windows.Forms.ToolStripMenuItem EditDelete;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        internal System.Windows.Forms.ToolStripMenuItem EditSelectAll;
        internal System.Windows.Forms.ToolStripMenuItem EditInvertSelection;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        internal System.Windows.Forms.ToolStripMenuItem EditOptions;
        internal System.Windows.Forms.ToolStripMenuItem CameraMenu;
        internal System.Windows.Forms.ToolStripMenuItem CameraMove;
        internal System.Windows.Forms.ToolStripMenuItem CameraMoveLeft;
        internal System.Windows.Forms.ToolStripMenuItem CameraMoveRight;
        internal System.Windows.Forms.ToolStripMenuItem CameraMoveUp;
        internal System.Windows.Forms.ToolStripMenuItem CameraMoveDown;
        internal System.Windows.Forms.ToolStripMenuItem CameraMoveForward;
        internal System.Windows.Forms.ToolStripMenuItem CameraMoveBack;
        internal System.Windows.Forms.ToolStripMenuItem CameraStrafe;
        internal System.Windows.Forms.ToolStripMenuItem CameraStrafeLeft;
        internal System.Windows.Forms.ToolStripMenuItem CameraStrafeRight;
        internal System.Windows.Forms.ToolStripMenuItem CameraStrafeUp;
        internal System.Windows.Forms.ToolStripMenuItem CameraStrafeDown;
        internal System.Windows.Forms.ToolStripMenuItem CameraRollLeft;
        internal System.Windows.Forms.ToolStripMenuItem CameraRollRight;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        internal System.Windows.Forms.ToolStripMenuItem CameraReset;
        internal System.Windows.Forms.ToolStripMenuItem HelpMenu;
        internal System.Windows.Forms.ToolStripMenuItem HelpOpenGLShadingLanguage;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        internal System.Windows.Forms.ToolStripMenuItem HelpAbout;
        internal WeifenLuo.WinFormsUI.Docking.DockPanel DockPanel;
        internal System.Windows.Forms.ToolStripMenuItem ViewMenu;
        internal System.Windows.Forms.ToolStripStatusLabel GpuStatusLabel;
        internal System.Windows.Forms.ToolStripMenuItem ViewSceneProperties;
        internal System.Windows.Forms.ToolStripMenuItem ViewTraceProperties;
        internal System.Windows.Forms.ToolStripMenuItem ViewGraphicsState;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        internal System.Windows.Forms.ToolStripMenuItem ViewSceneCode;
        internal System.Windows.Forms.ToolStripMenuItem ViewTraceCode;
        internal System.Windows.Forms.ToolStripMenuItem ViewAllCode;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        internal System.Windows.Forms.ToolStripMenuItem ViewScene;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
    }
}