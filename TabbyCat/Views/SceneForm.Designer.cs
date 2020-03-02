namespace TabbyCat.Views
{
    partial class SceneForm
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
            this.ToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.StatusBar = new TabbyCat.Controls.TgStatusStrip();
            this.tbDecelerate = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbReverse = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbStop = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbPause = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbForward = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbAccelerate = new System.Windows.Forms.ToolStripDropDownButton();
            this.SpeedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Tlabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.GLControl = new OpenTK.GLControl();
            this.Toolbar = new TabbyCat.Controls.TgToolStrip();
            this.tbNew = new System.Windows.Forms.ToolStripSplitButton();
            this.tbNewEmptyScene = new System.Windows.Forms.ToolStripMenuItem();
            this.tbNewFromTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.tbOpen = new System.Windows.Forms.ToolStripSplitButton();
            this.tbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbUndo = new System.Windows.Forms.ToolStripSplitButton();
            this.tbRedo = new System.Windows.Forms.ToolStripSplitButton();
            this.tbCut = new System.Windows.Forms.ToolStripButton();
            this.tbCopy = new System.Windows.Forms.ToolStripButton();
            this.tbPaste = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbAdd = new System.Windows.Forms.ToolStripButton();
            this.MainMenu = new TabbyCat.Controls.TgMenuStrip();
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
            this.EditRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.EditOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.SceneMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SceneAddNewTrace = new System.Windows.Forms.ToolStripMenuItem();
            this.SceneEditCode = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeDecelerate = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeReverse = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeStop = new System.Windows.Forms.ToolStripMenuItem();
            this.TimePause = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeForward = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeAccelerate = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpOpenGLShadingLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.HelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.ToolStripContainer.ContentPanel.SuspendLayout();
            this.ToolStripContainer.LeftToolStripPanel.SuspendLayout();
            this.ToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.Toolbar.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStripContainer
            // 
            // 
            // ToolStripContainer.BottomToolStripPanel
            // 
            this.ToolStripContainer.BottomToolStripPanel.Controls.Add(this.StatusBar);
            // 
            // ToolStripContainer.ContentPanel
            // 
            this.ToolStripContainer.ContentPanel.Controls.Add(this.GLControl);
            this.ToolStripContainer.ContentPanel.Size = new System.Drawing.Size(767, 404);
            this.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // ToolStripContainer.LeftToolStripPanel
            // 
            this.ToolStripContainer.LeftToolStripPanel.Controls.Add(this.Toolbar);
            this.ToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer.Name = "ToolStripContainer";
            this.ToolStripContainer.Size = new System.Drawing.Size(800, 450);
            this.ToolStripContainer.TabIndex = 0;
            this.ToolStripContainer.Text = "toolStripContainer1";
            // 
            // ToolStripContainer.TopToolStripPanel
            // 
            this.ToolStripContainer.TopToolStripPanel.Controls.Add(this.MainMenu);
            // 
            // StatusBar
            // 
            this.StatusBar.Dock = System.Windows.Forms.DockStyle.None;
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbDecelerate,
            this.tbReverse,
            this.tbStop,
            this.tbPause,
            this.tbForward,
            this.tbAccelerate,
            this.SpeedLabel,
            this.Tlabel});
            this.StatusBar.Location = new System.Drawing.Point(0, 0);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(800, 22);
            this.StatusBar.TabIndex = 0;
            // 
            // tbDecelerate
            // 
            this.tbDecelerate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDecelerate.Image = global::TabbyCat.Properties.Resources.RewindHS;
            this.tbDecelerate.ImageTransparentColor = System.Drawing.Color.White;
            this.tbDecelerate.Name = "tbDecelerate";
            this.tbDecelerate.ShowDropDownArrow = false;
            this.tbDecelerate.Size = new System.Drawing.Size(20, 20);
            this.tbDecelerate.ToolTipText = "Decelerate";
            // 
            // tbReverse
            // 
            this.tbReverse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbReverse.Image = global::TabbyCat.Properties.Resources.BackHS;
            this.tbReverse.ImageTransparentColor = System.Drawing.Color.White;
            this.tbReverse.Name = "tbReverse";
            this.tbReverse.ShowDropDownArrow = false;
            this.tbReverse.Size = new System.Drawing.Size(20, 20);
            this.tbReverse.ToolTipText = "Reverse";
            // 
            // tbStop
            // 
            this.tbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbStop.Image = global::TabbyCat.Properties.Resources.StopHS;
            this.tbStop.ImageTransparentColor = System.Drawing.Color.White;
            this.tbStop.Name = "tbStop";
            this.tbStop.ShowDropDownArrow = false;
            this.tbStop.Size = new System.Drawing.Size(20, 20);
            this.tbStop.ToolTipText = "Stop";
            // 
            // tbPause
            // 
            this.tbPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPause.Image = global::TabbyCat.Properties.Resources.PauseHS;
            this.tbPause.ImageTransparentColor = System.Drawing.Color.White;
            this.tbPause.Name = "tbPause";
            this.tbPause.ShowDropDownArrow = false;
            this.tbPause.Size = new System.Drawing.Size(20, 20);
            this.tbPause.ToolTipText = "Pause";
            // 
            // tbForward
            // 
            this.tbForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbForward.Image = global::TabbyCat.Properties.Resources.PlayHS;
            this.tbForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbForward.Name = "tbForward";
            this.tbForward.ShowDropDownArrow = false;
            this.tbForward.Size = new System.Drawing.Size(20, 20);
            this.tbForward.ToolTipText = "Forward";
            // 
            // tbAccelerate
            // 
            this.tbAccelerate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbAccelerate.Image = global::TabbyCat.Properties.Resources.FFwdHS;
            this.tbAccelerate.ImageTransparentColor = System.Drawing.Color.White;
            this.tbAccelerate.Name = "tbAccelerate";
            this.tbAccelerate.ShowDropDownArrow = false;
            this.tbAccelerate.Size = new System.Drawing.Size(20, 20);
            this.tbAccelerate.ToolTipText = "Accelerate";
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
            this.Tlabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GLControl
            // 
            this.GLControl.BackColor = System.Drawing.Color.Black;
            this.GLControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GLControl.Location = new System.Drawing.Point(0, 0);
            this.GLControl.Name = "GLControl";
            this.GLControl.Size = new System.Drawing.Size(767, 404);
            this.GLControl.TabIndex = 0;
            this.GLControl.VSync = false;
            // 
            // Toolbar
            // 
            this.Toolbar.Dock = System.Windows.Forms.DockStyle.None;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbNew,
            this.tbOpen,
            this.tbSave,
            this.toolStripSeparator1,
            this.tbUndo,
            this.tbRedo,
            this.tbCut,
            this.tbCopy,
            this.tbPaste,
            this.tbDelete,
            this.toolStripSeparator2,
            this.tbAdd});
            this.Toolbar.Location = new System.Drawing.Point(0, 3);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(33, 253);
            this.Toolbar.TabIndex = 0;
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
            this.tbNew.Size = new System.Drawing.Size(31, 20);
            this.tbNew.ToolTipText = "Create a new file (^N)";
            // 
            // tbNewEmptyScene
            // 
            this.tbNewEmptyScene.Name = "tbNewEmptyScene";
            this.tbNewEmptyScene.ShortcutKeyDisplayString = "^N";
            this.tbNewEmptyScene.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tbNewEmptyScene.Size = new System.Drawing.Size(193, 22);
            this.tbNewEmptyScene.Text = "&New Empty Scene";
            // 
            // tbNewFromTemplate
            // 
            this.tbNewFromTemplate.Name = "tbNewFromTemplate";
            this.tbNewFromTemplate.Size = new System.Drawing.Size(193, 22);
            this.tbNewFromTemplate.Text = "New from &Template...";
            // 
            // tbOpen
            // 
            this.tbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbOpen.Image = global::TabbyCat.Properties.Resources.OpenFileHS;
            this.tbOpen.ImageTransparentColor = System.Drawing.Color.Black;
            this.tbOpen.Name = "tbOpen";
            this.tbOpen.Size = new System.Drawing.Size(31, 20);
            this.tbOpen.ToolTipText = "Open an existing file (^O)";
            // 
            // tbSave
            // 
            this.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSave.Image = global::TabbyCat.Properties.Resources.saveHS;
            this.tbSave.ImageTransparentColor = System.Drawing.Color.White;
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(31, 20);
            this.tbSave.ToolTipText = "Save to file (^S)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(31, 6);
            // 
            // tbUndo
            // 
            this.tbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbUndo.Enabled = false;
            this.tbUndo.Image = global::TabbyCat.Properties.Resources.Edit_UndoHS;
            this.tbUndo.ImageTransparentColor = System.Drawing.Color.White;
            this.tbUndo.Name = "tbUndo";
            this.tbUndo.Size = new System.Drawing.Size(31, 20);
            this.tbUndo.ToolTipText = "Undo (^Z)";
            // 
            // tbRedo
            // 
            this.tbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRedo.Enabled = false;
            this.tbRedo.Image = global::TabbyCat.Properties.Resources.Edit_RedoHS;
            this.tbRedo.ImageTransparentColor = System.Drawing.Color.White;
            this.tbRedo.Name = "tbRedo";
            this.tbRedo.Size = new System.Drawing.Size(31, 20);
            this.tbRedo.ToolTipText = "Redo (^Y)";
            // 
            // tbCut
            // 
            this.tbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCut.Enabled = false;
            this.tbCut.Image = global::TabbyCat.Properties.Resources.CutHS;
            this.tbCut.ImageTransparentColor = System.Drawing.Color.White;
            this.tbCut.Name = "tbCut";
            this.tbCut.Size = new System.Drawing.Size(31, 20);
            this.tbCut.Text = "toolStripButton1";
            // 
            // tbCopy
            // 
            this.tbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCopy.Enabled = false;
            this.tbCopy.Image = global::TabbyCat.Properties.Resources.CopyHS;
            this.tbCopy.ImageTransparentColor = System.Drawing.Color.White;
            this.tbCopy.Name = "tbCopy";
            this.tbCopy.Size = new System.Drawing.Size(31, 20);
            this.tbCopy.Text = "toolStripButton2";
            // 
            // tbPaste
            // 
            this.tbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPaste.Enabled = false;
            this.tbPaste.Image = global::TabbyCat.Properties.Resources.PasteHS;
            this.tbPaste.ImageTransparentColor = System.Drawing.Color.White;
            this.tbPaste.Name = "tbPaste";
            this.tbPaste.Size = new System.Drawing.Size(31, 20);
            this.tbPaste.Text = "toolStripButton3";
            // 
            // tbDelete
            // 
            this.tbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDelete.Enabled = false;
            this.tbDelete.Image = global::TabbyCat.Properties.Resources.Delete;
            this.tbDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(31, 20);
            this.tbDelete.Text = "toolStripButton4";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(31, 6);
            // 
            // tbAdd
            // 
            this.tbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbAdd.Image = global::TabbyCat.Properties.Resources.action_add_16xLG;
            this.tbAdd.ImageTransparentColor = System.Drawing.Color.White;
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(31, 20);
            this.tbAdd.ToolTipText = "Add a new Trace (F2)";
            // 
            // MainMenu
            // 
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.EditMenu,
            this.SceneMenu,
            this.ViewMenu,
            this.TimeMenu,
            this.HelpMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(800, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
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
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "&File";
            // 
            // FileNew
            // 
            this.FileNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNewEmptyScene,
            this.FileNewFromTemplate});
            this.FileNew.Image = global::TabbyCat.Properties.Resources.NewDocumentHS;
            this.FileNew.Name = "FileNew";
            this.FileNew.Size = new System.Drawing.Size(196, 22);
            this.FileNew.Text = "&New";
            // 
            // FileNewEmptyScene
            // 
            this.FileNewEmptyScene.Name = "FileNewEmptyScene";
            this.FileNewEmptyScene.ShortcutKeyDisplayString = "^N";
            this.FileNewEmptyScene.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.FileNewEmptyScene.Size = new System.Drawing.Size(166, 22);
            this.FileNewEmptyScene.Text = "&Empty Scene";
            // 
            // FileNewFromTemplate
            // 
            this.FileNewFromTemplate.Name = "FileNewFromTemplate";
            this.FileNewFromTemplate.Size = new System.Drawing.Size(166, 22);
            this.FileNewFromTemplate.Text = "&From Template";
            // 
            // FileOpen
            // 
            this.FileOpen.Image = global::TabbyCat.Properties.Resources.OpenFileHS;
            this.FileOpen.ImageTransparentColor = System.Drawing.Color.Black;
            this.FileOpen.Name = "FileOpen";
            this.FileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.FileOpen.Size = new System.Drawing.Size(196, 22);
            this.FileOpen.Text = "&Open...";
            // 
            // FileReopen
            // 
            this.FileReopen.Name = "FileReopen";
            this.FileReopen.Size = new System.Drawing.Size(196, 22);
            this.FileReopen.Text = "&Reopen";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(193, 6);
            // 
            // FileSave
            // 
            this.FileSave.Image = global::TabbyCat.Properties.Resources.saveHS;
            this.FileSave.Name = "FileSave";
            this.FileSave.ShortcutKeyDisplayString = "^S";
            this.FileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.FileSave.Size = new System.Drawing.Size(196, 22);
            this.FileSave.Text = "&Save";
            // 
            // FileSaveAs
            // 
            this.FileSaveAs.Name = "FileSaveAs";
            this.FileSaveAs.Size = new System.Drawing.Size(196, 22);
            this.FileSaveAs.Text = "Save &As...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(193, 6);
            // 
            // FileClose
            // 
            this.FileClose.Name = "FileClose";
            this.FileClose.ShortcutKeyDisplayString = "^F4";
            this.FileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.FileClose.Size = new System.Drawing.Size(196, 22);
            this.FileClose.Text = "&Close";
            // 
            // FileExit
            // 
            this.FileExit.Name = "FileExit";
            this.FileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.FileExit.Size = new System.Drawing.Size(196, 22);
            this.FileExit.Text = "Close All && E&xit";
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
            this.EditRefresh,
            this.EditOptions});
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(39, 20);
            this.EditMenu.Text = "&Edit";
            // 
            // EditUndo
            // 
            this.EditUndo.Enabled = false;
            this.EditUndo.Image = global::TabbyCat.Properties.Resources.Edit_UndoHS;
            this.EditUndo.ImageTransparentColor = System.Drawing.Color.White;
            this.EditUndo.Name = "EditUndo";
            this.EditUndo.ShortcutKeyDisplayString = "^Z";
            this.EditUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.EditUndo.Size = new System.Drawing.Size(155, 22);
            this.EditUndo.Text = "&Undo";
            // 
            // EditRedo
            // 
            this.EditRedo.Enabled = false;
            this.EditRedo.Image = global::TabbyCat.Properties.Resources.Edit_RedoHS;
            this.EditRedo.ImageTransparentColor = System.Drawing.Color.White;
            this.EditRedo.Name = "EditRedo";
            this.EditRedo.ShortcutKeyDisplayString = "^Y";
            this.EditRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.EditRedo.Size = new System.Drawing.Size(155, 22);
            this.EditRedo.Text = "&Redo";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(152, 6);
            // 
            // EditCut
            // 
            this.EditCut.Enabled = false;
            this.EditCut.Image = global::TabbyCat.Properties.Resources.CutHS;
            this.EditCut.ImageTransparentColor = System.Drawing.Color.White;
            this.EditCut.Name = "EditCut";
            this.EditCut.ShortcutKeyDisplayString = "^X";
            this.EditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.EditCut.Size = new System.Drawing.Size(155, 22);
            this.EditCut.Text = "Cu&t";
            // 
            // EditCopy
            // 
            this.EditCopy.Enabled = false;
            this.EditCopy.Image = global::TabbyCat.Properties.Resources.CopyHS;
            this.EditCopy.ImageTransparentColor = System.Drawing.Color.White;
            this.EditCopy.Name = "EditCopy";
            this.EditCopy.ShortcutKeyDisplayString = "^C";
            this.EditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.EditCopy.Size = new System.Drawing.Size(155, 22);
            this.EditCopy.Text = "&Copy";
            // 
            // EditPaste
            // 
            this.EditPaste.Enabled = false;
            this.EditPaste.Image = global::TabbyCat.Properties.Resources.PasteHS;
            this.EditPaste.ImageTransparentColor = System.Drawing.Color.White;
            this.EditPaste.Name = "EditPaste";
            this.EditPaste.ShortcutKeyDisplayString = "^V";
            this.EditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.EditPaste.Size = new System.Drawing.Size(155, 22);
            this.EditPaste.Text = "&Paste";
            // 
            // EditDelete
            // 
            this.EditDelete.Enabled = false;
            this.EditDelete.Image = global::TabbyCat.Properties.Resources.Delete;
            this.EditDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.EditDelete.Name = "EditDelete";
            this.EditDelete.Size = new System.Drawing.Size(155, 22);
            this.EditDelete.Text = "&Delete";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(152, 6);
            // 
            // EditSelectAll
            // 
            this.EditSelectAll.Name = "EditSelectAll";
            this.EditSelectAll.ShortcutKeyDisplayString = "^A";
            this.EditSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.EditSelectAll.Size = new System.Drawing.Size(155, 22);
            this.EditSelectAll.Text = "Select &All";
            // 
            // EditInvertSelection
            // 
            this.EditInvertSelection.Name = "EditInvertSelection";
            this.EditInvertSelection.Size = new System.Drawing.Size(155, 22);
            this.EditInvertSelection.Text = "&Invert Selection";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(152, 6);
            // 
            // EditRefresh
            // 
            this.EditRefresh.Name = "EditRefresh";
            this.EditRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.EditRefresh.Size = new System.Drawing.Size(155, 22);
            this.EditRefresh.Text = "R&efresh";
            // 
            // EditOptions
            // 
            this.EditOptions.Name = "EditOptions";
            this.EditOptions.Size = new System.Drawing.Size(155, 22);
            this.EditOptions.Text = "&Options...";
            // 
            // SceneMenu
            // 
            this.SceneMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SceneAddNewTrace,
            this.SceneEditCode});
            this.SceneMenu.Name = "SceneMenu";
            this.SceneMenu.Size = new System.Drawing.Size(50, 20);
            this.SceneMenu.Text = "&Scene";
            // 
            // SceneAddNewTrace
            // 
            this.SceneAddNewTrace.Image = global::TabbyCat.Properties.Resources.action_add_16xLG;
            this.SceneAddNewTrace.ImageTransparentColor = System.Drawing.Color.White;
            this.SceneAddNewTrace.Name = "SceneAddNewTrace";
            this.SceneAddNewTrace.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.SceneAddNewTrace.Size = new System.Drawing.Size(182, 22);
            this.SceneAddNewTrace.Text = "&Add a New Trace";
            // 
            // SceneEditCode
            // 
            this.SceneEditCode.Name = "SceneEditCode";
            this.SceneEditCode.Size = new System.Drawing.Size(182, 22);
            this.SceneEditCode.Text = "&Edit Code";
            // 
            // ViewMenu
            // 
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewFullScreen,
            this.toolStripMenuItem3,
            this.ViewProperties});
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(44, 20);
            this.ViewMenu.Text = "&View";
            // 
            // ViewFullScreen
            // 
            this.ViewFullScreen.Image = global::TabbyCat.Properties.Resources.FullScreenHS;
            this.ViewFullScreen.Name = "ViewFullScreen";
            this.ViewFullScreen.Size = new System.Drawing.Size(180, 22);
            this.ViewFullScreen.Text = "&Full Screen";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // ViewProperties
            // 
            this.ViewProperties.Name = "ViewProperties";
            this.ViewProperties.Size = new System.Drawing.Size(180, 22);
            this.ViewProperties.Text = "&Properties";
            // 
            // TimeMenu
            // 
            this.TimeMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TimeMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TimeDecelerate,
            this.TimeReverse,
            this.TimeStop,
            this.TimePause,
            this.TimeForward,
            this.TimeAccelerate});
            this.TimeMenu.Name = "TimeMenu";
            this.TimeMenu.Size = new System.Drawing.Size(46, 20);
            this.TimeMenu.Text = "&Time";
            // 
            // TimeDecelerate
            // 
            this.TimeDecelerate.Image = global::TabbyCat.Properties.Resources.RewindHS;
            this.TimeDecelerate.ImageTransparentColor = System.Drawing.Color.White;
            this.TimeDecelerate.Name = "TimeDecelerate";
            this.TimeDecelerate.Size = new System.Drawing.Size(129, 22);
            this.TimeDecelerate.Text = "&Decelerate";
            // 
            // TimeReverse
            // 
            this.TimeReverse.Image = global::TabbyCat.Properties.Resources.BackHS;
            this.TimeReverse.ImageTransparentColor = System.Drawing.Color.White;
            this.TimeReverse.Name = "TimeReverse";
            this.TimeReverse.Size = new System.Drawing.Size(129, 22);
            this.TimeReverse.Text = "&Reverse";
            // 
            // TimeStop
            // 
            this.TimeStop.Image = global::TabbyCat.Properties.Resources.StopHS;
            this.TimeStop.ImageTransparentColor = System.Drawing.Color.White;
            this.TimeStop.Name = "TimeStop";
            this.TimeStop.Size = new System.Drawing.Size(129, 22);
            this.TimeStop.Text = "&Stop";
            // 
            // TimePause
            // 
            this.TimePause.Image = global::TabbyCat.Properties.Resources.PauseHS;
            this.TimePause.ImageTransparentColor = System.Drawing.Color.White;
            this.TimePause.Name = "TimePause";
            this.TimePause.Size = new System.Drawing.Size(129, 22);
            this.TimePause.Text = "&Pause";
            // 
            // TimeForward
            // 
            this.TimeForward.Image = global::TabbyCat.Properties.Resources.PlayHS;
            this.TimeForward.Name = "TimeForward";
            this.TimeForward.Size = new System.Drawing.Size(129, 22);
            this.TimeForward.Text = "&Forward";
            // 
            // TimeAccelerate
            // 
            this.TimeAccelerate.Image = global::TabbyCat.Properties.Resources.FFwdHS;
            this.TimeAccelerate.ImageTransparentColor = System.Drawing.Color.White;
            this.TimeAccelerate.Name = "TimeAccelerate";
            this.TimeAccelerate.Size = new System.Drawing.Size(129, 22);
            this.TimeAccelerate.Text = "&Accelerate";
            // 
            // HelpMenu
            // 
            this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpOpenGLShadingLanguage,
            this.toolStripMenuItem12,
            this.HelpAbout});
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(44, 20);
            this.HelpMenu.Text = "&Help";
            // 
            // HelpOpenGLShadingLanguage
            // 
            this.HelpOpenGLShadingLanguage.Name = "HelpOpenGLShadingLanguage";
            this.HelpOpenGLShadingLanguage.Size = new System.Drawing.Size(229, 22);
            this.HelpOpenGLShadingLanguage.Text = "OpenGL® Shading Language";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(226, 6);
            // 
            // HelpAbout
            // 
            this.HelpAbout.Name = "HelpAbout";
            this.HelpAbout.Size = new System.Drawing.Size(229, 22);
            this.HelpAbout.Text = "&About";
            // 
            // SceneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ToolStripContainer);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "SceneForm";
            this.Text = "SceneForm";
            this.ToolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.BottomToolStripPanel.PerformLayout();
            this.ToolStripContainer.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer.LeftToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.LeftToolStripPanel.PerformLayout();
            this.ToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer.ResumeLayout(false);
            this.ToolStripContainer.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolStripContainer ToolStripContainer;
        internal TabbyCat.Controls.TgMenuStrip MainMenu;
        internal System.Windows.Forms.ToolStripMenuItem FileMenu;
        internal System.Windows.Forms.ToolStripMenuItem EditMenu;
        internal System.Windows.Forms.ToolStripMenuItem ViewMenu;
        internal System.Windows.Forms.ToolStripMenuItem HelpMenu;
        internal TabbyCat.Controls.TgStatusStrip StatusBar;
        internal OpenTK.GLControl GLControl;
        internal TabbyCat.Controls.TgToolStrip Toolbar;
        internal System.Windows.Forms.ToolStripMenuItem ViewProperties;
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
        internal System.Windows.Forms.ToolStripMenuItem EditRefresh;
        internal System.Windows.Forms.ToolStripMenuItem EditOptions;
        internal System.Windows.Forms.ToolStripMenuItem SceneMenu;
        internal System.Windows.Forms.ToolStripMenuItem SceneAddNewTrace;
        internal System.Windows.Forms.ToolStripMenuItem SceneEditCode;
        internal System.Windows.Forms.ToolStripMenuItem TimeMenu;
        internal System.Windows.Forms.ToolStripMenuItem TimeDecelerate;
        internal System.Windows.Forms.ToolStripMenuItem TimeReverse;
        internal System.Windows.Forms.ToolStripMenuItem TimeStop;
        internal System.Windows.Forms.ToolStripMenuItem TimePause;
        internal System.Windows.Forms.ToolStripMenuItem TimeForward;
        internal System.Windows.Forms.ToolStripMenuItem TimeAccelerate;
        internal System.Windows.Forms.ToolStripMenuItem HelpOpenGLShadingLanguage;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        internal System.Windows.Forms.ToolStripMenuItem HelpAbout;
        internal System.Windows.Forms.ToolStripSplitButton tbNew;
        internal System.Windows.Forms.ToolStripMenuItem tbNewEmptyScene;
        internal System.Windows.Forms.ToolStripMenuItem tbNewFromTemplate;
        internal System.Windows.Forms.ToolStripSplitButton tbOpen;
        internal System.Windows.Forms.ToolStripButton tbSave;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripSplitButton tbUndo;
        internal System.Windows.Forms.ToolStripSplitButton tbRedo;
        internal System.Windows.Forms.ToolStripButton tbCut;
        internal System.Windows.Forms.ToolStripButton tbCopy;
        internal System.Windows.Forms.ToolStripButton tbPaste;
        internal System.Windows.Forms.ToolStripButton tbDelete;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton tbAdd;
        internal System.Windows.Forms.ToolStripMenuItem ViewFullScreen;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        internal System.Windows.Forms.ToolStripDropDownButton tbDecelerate;
        internal System.Windows.Forms.ToolStripDropDownButton tbReverse;
        internal System.Windows.Forms.ToolStripDropDownButton tbStop;
        internal System.Windows.Forms.ToolStripDropDownButton tbPause;
        internal System.Windows.Forms.ToolStripDropDownButton tbForward;
        internal System.Windows.Forms.ToolStripDropDownButton tbAccelerate;
        internal System.Windows.Forms.ToolStripStatusLabel SpeedLabel;
        internal System.Windows.Forms.ToolStripStatusLabel Tlabel;
    }
}