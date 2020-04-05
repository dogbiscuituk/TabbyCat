namespace TabbyCat.MvcViews
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
            this.ToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.StatusBar = new Jmk.Controls.JmkStatusStrip();
            this.tbDecelerate = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbReverse = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbStop = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbPause = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbForward = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbAccelerate = new System.Windows.Forms.ToolStripDropDownButton();
            this.SpeedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Tlabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.FPSlabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GLControl = new OpenTK.GLControl();
            this.PropertiesEdit = new TabbyCat.Controls.PropertiesEdit();
            this.PopupPropertiesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopupPropertiesUndock = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupPropertiesHide = new System.Windows.Forms.ToolStripMenuItem();
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
            this.MainMenu = new Jmk.Controls.JmkMenuStrip();
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
            this.ViewFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveStrafe = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveRight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.MoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveCircle = new System.Windows.Forms.ToolStripMenuItem();
            this.CircleLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.CircleRight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.CircleUp = new System.Windows.Forms.ToolStripMenuItem();
            this.CircleDown = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveZoomRoll = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.RollClockwise = new System.Windows.Forms.ToolStripMenuItem();
            this.RollAnticlockwise = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.ToolStripContainer.ContentPanel.SuspendLayout();
            this.ToolStripContainer.LeftToolStripPanel.SuspendLayout();
            this.ToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer.SuspendLayout();
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.PopupPropertiesMenu.SuspendLayout();
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
            this.ToolStripContainer.ContentPanel.Controls.Add(this.SplitContainer1);
            this.ToolStripContainer.ContentPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ToolStripContainer.ContentPanel.Size = new System.Drawing.Size(975, 682);
            this.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // ToolStripContainer.LeftToolStripPanel
            // 
            this.ToolStripContainer.LeftToolStripPanel.Controls.Add(this.Toolbar);
            this.ToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ToolStripContainer.Name = "ToolStripContainer";
            this.ToolStripContainer.Size = new System.Drawing.Size(1008, 729);
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
            this.StatusBar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbDecelerate,
            this.tbReverse,
            this.tbStop,
            this.tbPause,
            this.tbForward,
            this.tbAccelerate,
            this.SpeedLabel,
            this.Tlabel,
            this.FPSlabel});
            this.StatusBar.Location = new System.Drawing.Point(0, 0);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(1008, 22);
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
            // 
            // FPSlabel
            // 
            this.FPSlabel.AutoSize = false;
            this.FPSlabel.Name = "FPSlabel";
            this.FPSlabel.Size = new System.Drawing.Size(64, 17);
            this.FPSlabel.Text = "FPS=0.0";
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.GLControl);
            this.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.PropertiesEdit);
            this.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SplitContainer1.Panel2MinSize = 386;
            this.SplitContainer1.Size = new System.Drawing.Size(975, 682);
            this.SplitContainer1.SplitterDistance = 578;
            this.SplitContainer1.SplitterWidth = 5;
            this.SplitContainer1.TabIndex = 1;
            // 
            // GLControl
            // 
            this.GLControl.BackColor = System.Drawing.Color.Black;
            this.GLControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GLControl.Location = new System.Drawing.Point(0, 0);
            this.GLControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GLControl.Name = "GLControl";
            this.GLControl.Size = new System.Drawing.Size(578, 682);
            this.GLControl.TabIndex = 0;
            this.GLControl.VSync = false;
            // 
            // PropertiesEdit
            // 
            this.PropertiesEdit.ContextMenuStrip = this.PopupPropertiesMenu;
            this.PropertiesEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertiesEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropertiesEdit.Location = new System.Drawing.Point(0, 0);
            this.PropertiesEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.PropertiesEdit.Name = "PropertiesEdit";
            this.PropertiesEdit.Size = new System.Drawing.Size(392, 682);
            this.PropertiesEdit.TabIndex = 0;
            // 
            // PopupPropertiesMenu
            // 
            this.PopupPropertiesMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupPropertiesUndock,
            this.PopupPropertiesHide});
            this.PopupPropertiesMenu.Name = "PopupPropertiesMenu";
            this.PopupPropertiesMenu.Size = new System.Drawing.Size(116, 48);
            // 
            // PopupPropertiesUndock
            // 
            this.PopupPropertiesUndock.Name = "PopupPropertiesUndock";
            this.PopupPropertiesUndock.Size = new System.Drawing.Size(115, 22);
            this.PopupPropertiesUndock.Text = "&Undock";
            // 
            // PopupPropertiesHide
            // 
            this.PopupPropertiesHide.Name = "PopupPropertiesHide";
            this.PopupPropertiesHide.Size = new System.Drawing.Size(115, 22);
            this.PopupPropertiesHide.Text = "&Hide";
            // 
            // Toolbar
            // 
            this.Toolbar.Dock = System.Windows.Forms.DockStyle.None;
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
            this.Toolbar.Location = new System.Drawing.Point(0, 3);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(33, 238);
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
            // tbAdd
            // 
            this.tbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbAdd.Image = global::TabbyCat.Properties.Resources.action_add_16xLG;
            this.tbAdd.ImageTransparentColor = System.Drawing.Color.White;
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(31, 20);
            this.tbAdd.ToolTipText = "Add a new trace (F2)";
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
            this.tbCut.ToolTipText = "Cut";
            // 
            // tbCopy
            // 
            this.tbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCopy.Enabled = false;
            this.tbCopy.Image = global::TabbyCat.Properties.Resources.CopyHS;
            this.tbCopy.ImageTransparentColor = System.Drawing.Color.White;
            this.tbCopy.Name = "tbCopy";
            this.tbCopy.Size = new System.Drawing.Size(31, 20);
            this.tbCopy.ToolTipText = "Copy";
            // 
            // tbPaste
            // 
            this.tbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPaste.Image = global::TabbyCat.Properties.Resources.PasteHS;
            this.tbPaste.ImageTransparentColor = System.Drawing.Color.White;
            this.tbPaste.Name = "tbPaste";
            this.tbPaste.Size = new System.Drawing.Size(31, 20);
            this.tbPaste.ToolTipText = "Paste";
            // 
            // tbDelete
            // 
            this.tbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDelete.Enabled = false;
            this.tbDelete.Image = global::TabbyCat.Properties.Resources.Delete;
            this.tbDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(31, 20);
            this.tbDelete.ToolTipText = "Delete selected trace(s)";
            // 
            // MainMenu
            // 
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MainMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.EditMenu,
            this.ViewMenu,
            this.MoveMenu,
            this.TimeMenu,
            this.HelpMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1008, 25);
            this.MainMenu.TabIndex = 0;
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
            this.FileMenu.Text = "&File";
            // 
            // FileNew
            // 
            this.FileNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNewEmptyScene,
            this.FileNewFromTemplate});
            this.FileNew.Image = global::TabbyCat.Properties.Resources.NewDocumentHS;
            this.FileNew.Name = "FileNew";
            this.FileNew.Size = new System.Drawing.Size(209, 22);
            this.FileNew.Text = "&New";
            // 
            // FileNewEmptyScene
            // 
            this.FileNewEmptyScene.Name = "FileNewEmptyScene";
            this.FileNewEmptyScene.ShortcutKeyDisplayString = "^N";
            this.FileNewEmptyScene.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.FileNewEmptyScene.Size = new System.Drawing.Size(177, 22);
            this.FileNewEmptyScene.Text = "&Empty Scene";
            // 
            // FileNewFromTemplate
            // 
            this.FileNewFromTemplate.Name = "FileNewFromTemplate";
            this.FileNewFromTemplate.Size = new System.Drawing.Size(177, 22);
            this.FileNewFromTemplate.Text = "&From Template...";
            // 
            // FileOpen
            // 
            this.FileOpen.Image = global::TabbyCat.Properties.Resources.OpenFileHS;
            this.FileOpen.ImageTransparentColor = System.Drawing.Color.Black;
            this.FileOpen.Name = "FileOpen";
            this.FileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.FileOpen.Size = new System.Drawing.Size(209, 22);
            this.FileOpen.Text = "&Open...";
            // 
            // FileReopen
            // 
            this.FileReopen.Name = "FileReopen";
            this.FileReopen.Size = new System.Drawing.Size(209, 22);
            this.FileReopen.Text = "&Reopen";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(206, 6);
            // 
            // FileSave
            // 
            this.FileSave.Image = global::TabbyCat.Properties.Resources.saveHS;
            this.FileSave.Name = "FileSave";
            this.FileSave.ShortcutKeyDisplayString = "^S";
            this.FileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.FileSave.Size = new System.Drawing.Size(209, 22);
            this.FileSave.Text = "&Save";
            // 
            // FileSaveAs
            // 
            this.FileSaveAs.Name = "FileSaveAs";
            this.FileSaveAs.Size = new System.Drawing.Size(209, 22);
            this.FileSaveAs.Text = "Save &As...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(206, 6);
            // 
            // FileClose
            // 
            this.FileClose.Name = "FileClose";
            this.FileClose.ShortcutKeyDisplayString = "^F4";
            this.FileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.FileClose.Size = new System.Drawing.Size(209, 22);
            this.FileClose.Text = "&Close";
            // 
            // FileExit
            // 
            this.FileExit.Name = "FileExit";
            this.FileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.FileExit.Size = new System.Drawing.Size(209, 22);
            this.FileExit.Text = "Close All && E&xit";
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
            this.EditMenu.Text = "&Edit";
            // 
            // EditAddNewTrace
            // 
            this.EditAddNewTrace.Image = global::TabbyCat.Properties.Resources.action_add_16xLG;
            this.EditAddNewTrace.ImageTransparentColor = System.Drawing.Color.White;
            this.EditAddNewTrace.Name = "EditAddNewTrace";
            this.EditAddNewTrace.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.EditAddNewTrace.Size = new System.Drawing.Size(197, 22);
            this.EditAddNewTrace.Text = "&Add a New Trace";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(194, 6);
            // 
            // EditUndo
            // 
            this.EditUndo.Enabled = false;
            this.EditUndo.Image = global::TabbyCat.Properties.Resources.Edit_UndoHS;
            this.EditUndo.ImageTransparentColor = System.Drawing.Color.White;
            this.EditUndo.Name = "EditUndo";
            this.EditUndo.ShortcutKeyDisplayString = "";
            this.EditUndo.Size = new System.Drawing.Size(197, 22);
            this.EditUndo.Text = "&Undo";
            // 
            // EditRedo
            // 
            this.EditRedo.Enabled = false;
            this.EditRedo.Image = global::TabbyCat.Properties.Resources.Edit_RedoHS;
            this.EditRedo.ImageTransparentColor = System.Drawing.Color.White;
            this.EditRedo.Name = "EditRedo";
            this.EditRedo.ShortcutKeyDisplayString = "";
            this.EditRedo.Size = new System.Drawing.Size(197, 22);
            this.EditRedo.Text = "&Redo";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(194, 6);
            // 
            // EditCut
            // 
            this.EditCut.Enabled = false;
            this.EditCut.Image = global::TabbyCat.Properties.Resources.CutHS;
            this.EditCut.ImageTransparentColor = System.Drawing.Color.White;
            this.EditCut.Name = "EditCut";
            this.EditCut.ShortcutKeyDisplayString = "";
            this.EditCut.Size = new System.Drawing.Size(197, 22);
            this.EditCut.Text = "Cu&t";
            // 
            // EditCopy
            // 
            this.EditCopy.Enabled = false;
            this.EditCopy.Image = global::TabbyCat.Properties.Resources.CopyHS;
            this.EditCopy.ImageTransparentColor = System.Drawing.Color.White;
            this.EditCopy.Name = "EditCopy";
            this.EditCopy.ShortcutKeyDisplayString = "";
            this.EditCopy.Size = new System.Drawing.Size(197, 22);
            this.EditCopy.Text = "&Copy";
            // 
            // EditPaste
            // 
            this.EditPaste.Image = global::TabbyCat.Properties.Resources.PasteHS;
            this.EditPaste.ImageTransparentColor = System.Drawing.Color.White;
            this.EditPaste.Name = "EditPaste";
            this.EditPaste.ShortcutKeyDisplayString = "";
            this.EditPaste.Size = new System.Drawing.Size(197, 22);
            this.EditPaste.Text = "&Paste";
            // 
            // EditDelete
            // 
            this.EditDelete.Enabled = false;
            this.EditDelete.Image = global::TabbyCat.Properties.Resources.Delete;
            this.EditDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.EditDelete.Name = "EditDelete";
            this.EditDelete.Size = new System.Drawing.Size(197, 22);
            this.EditDelete.Text = "&Delete";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(194, 6);
            // 
            // EditSelectAll
            // 
            this.EditSelectAll.Name = "EditSelectAll";
            this.EditSelectAll.ShortcutKeyDisplayString = "";
            this.EditSelectAll.Size = new System.Drawing.Size(197, 22);
            this.EditSelectAll.Text = "Select &All";
            // 
            // EditInvertSelection
            // 
            this.EditInvertSelection.Name = "EditInvertSelection";
            this.EditInvertSelection.Size = new System.Drawing.Size(197, 22);
            this.EditInvertSelection.Text = "&Invert Selection";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(194, 6);
            // 
            // EditOptions
            // 
            this.EditOptions.Name = "EditOptions";
            this.EditOptions.Size = new System.Drawing.Size(197, 22);
            this.EditOptions.Text = "&Options...";
            // 
            // ViewMenu
            // 
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewFullScreen,
            this.toolStripMenuItem3,
            this.ViewProperties});
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(47, 21);
            this.ViewMenu.Text = "&View";
            // 
            // ViewFullScreen
            // 
            this.ViewFullScreen.Image = global::TabbyCat.Properties.Resources.FullScreenHS;
            this.ViewFullScreen.Name = "ViewFullScreen";
            this.ViewFullScreen.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.ViewFullScreen.Size = new System.Drawing.Size(166, 22);
            this.ViewFullScreen.Text = "&Full Screen";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(163, 6);
            // 
            // ViewProperties
            // 
            this.ViewProperties.Name = "ViewProperties";
            this.ViewProperties.Size = new System.Drawing.Size(166, 22);
            this.ViewProperties.Text = "&Properties";
            // 
            // MoveMenu
            // 
            this.MoveMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MoveStrafe,
            this.MoveCircle,
            this.MoveZoomRoll});
            this.MoveMenu.Name = "MoveMenu";
            this.MoveMenu.Size = new System.Drawing.Size(65, 21);
            this.MoveMenu.Text = "&Camera";
            // 
            // MoveStrafe
            // 
            this.MoveStrafe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MoveLeft,
            this.MoveRight,
            this.toolStripMenuItem5,
            this.MoveUp,
            this.MoveDown});
            this.MoveStrafe.Name = "MoveStrafe";
            this.MoveStrafe.Size = new System.Drawing.Size(145, 22);
            this.MoveStrafe.Text = "&Strafe";
            // 
            // MoveLeft
            // 
            this.MoveLeft.Name = "MoveLeft";
            this.MoveLeft.ShortcutKeyDisplayString = "^Left";
            this.MoveLeft.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.MoveLeft.Size = new System.Drawing.Size(159, 22);
            this.MoveLeft.Text = "&Left";
            // 
            // MoveRight
            // 
            this.MoveRight.Name = "MoveRight";
            this.MoveRight.ShortcutKeyDisplayString = "^Right";
            this.MoveRight.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.MoveRight.Size = new System.Drawing.Size(159, 22);
            this.MoveRight.Text = "&Right";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(156, 6);
            // 
            // MoveUp
            // 
            this.MoveUp.Name = "MoveUp";
            this.MoveUp.ShortcutKeyDisplayString = "^Up";
            this.MoveUp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.MoveUp.Size = new System.Drawing.Size(159, 22);
            this.MoveUp.Text = "&Up";
            // 
            // MoveDown
            // 
            this.MoveDown.Name = "MoveDown";
            this.MoveDown.ShortcutKeyDisplayString = "^Down";
            this.MoveDown.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.MoveDown.Size = new System.Drawing.Size(159, 22);
            this.MoveDown.Text = "&Down";
            // 
            // MoveCircle
            // 
            this.MoveCircle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CircleLeft,
            this.CircleRight,
            this.toolStripMenuItem6,
            this.CircleUp,
            this.CircleDown});
            this.MoveCircle.Name = "MoveCircle";
            this.MoveCircle.Size = new System.Drawing.Size(145, 22);
            this.MoveCircle.Text = "&Circle";
            // 
            // CircleLeft
            // 
            this.CircleLeft.Name = "CircleLeft";
            this.CircleLeft.ShortcutKeyDisplayString = "Shift+^Left";
            this.CircleLeft.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Left)));
            this.CircleLeft.Size = new System.Drawing.Size(193, 22);
            this.CircleLeft.Text = "&Left";
            // 
            // CircleRight
            // 
            this.CircleRight.Name = "CircleRight";
            this.CircleRight.ShortcutKeyDisplayString = "Shift+^Right";
            this.CircleRight.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Right)));
            this.CircleRight.Size = new System.Drawing.Size(193, 22);
            this.CircleRight.Text = "&Right";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(190, 6);
            // 
            // CircleUp
            // 
            this.CircleUp.Name = "CircleUp";
            this.CircleUp.ShortcutKeyDisplayString = "Shift+^Up";
            this.CircleUp.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Up)));
            this.CircleUp.Size = new System.Drawing.Size(193, 22);
            this.CircleUp.Text = "&Up";
            // 
            // CircleDown
            // 
            this.CircleDown.Name = "CircleDown";
            this.CircleDown.ShortcutKeyDisplayString = "Shift+^Down";
            this.CircleDown.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Down)));
            this.CircleDown.Size = new System.Drawing.Size(193, 22);
            this.CircleDown.Text = "&Down";
            // 
            // MoveZoomRoll
            // 
            this.MoveZoomRoll.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomIn,
            this.ZoomOut,
            this.toolStripMenuItem7,
            this.RollClockwise,
            this.RollAnticlockwise});
            this.MoveZoomRoll.Name = "MoveZoomRoll";
            this.MoveZoomRoll.Size = new System.Drawing.Size(145, 22);
            this.MoveZoomRoll.Text = "&Zoom / Roll";
            // 
            // ZoomIn
            // 
            this.ZoomIn.Name = "ZoomIn";
            this.ZoomIn.ShortcutKeyDisplayString = "^PgUp";
            this.ZoomIn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.PageUp)));
            this.ZoomIn.Size = new System.Drawing.Size(260, 22);
            this.ZoomIn.Text = "Zoom &In";
            // 
            // ZoomOut
            // 
            this.ZoomOut.Name = "ZoomOut";
            this.ZoomOut.ShortcutKeyDisplayString = "^PgDn";
            this.ZoomOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Next)));
            this.ZoomOut.Size = new System.Drawing.Size(260, 22);
            this.ZoomOut.Text = "Zoom &Out";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(257, 6);
            // 
            // RollClockwise
            // 
            this.RollClockwise.Name = "RollClockwise";
            this.RollClockwise.ShortcutKeyDisplayString = "Shift+^PgUp";
            this.RollClockwise.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.PageUp)));
            this.RollClockwise.Size = new System.Drawing.Size(260, 22);
            this.RollClockwise.Text = "Roll &Clockwise";
            // 
            // RollAnticlockwise
            // 
            this.RollAnticlockwise.Name = "RollAnticlockwise";
            this.RollAnticlockwise.ShortcutKeyDisplayString = "Shift+^PgDn";
            this.RollAnticlockwise.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Next)));
            this.RollAnticlockwise.Size = new System.Drawing.Size(260, 22);
            this.RollAnticlockwise.Text = "Roll &Anticlockwise";
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
            this.TimeMenu.Image = global::TabbyCat.Properties.Resources.ThinkTimenode_8848;
            this.TimeMenu.ImageTransparentColor = System.Drawing.Color.White;
            this.TimeMenu.Name = "TimeMenu";
            this.TimeMenu.Size = new System.Drawing.Size(48, 21);
            this.TimeMenu.Text = "&Time";
            // 
            // TimeDecelerate
            // 
            this.TimeDecelerate.Image = global::TabbyCat.Properties.Resources.RewindHS;
            this.TimeDecelerate.ImageTransparentColor = System.Drawing.Color.White;
            this.TimeDecelerate.Name = "TimeDecelerate";
            this.TimeDecelerate.Size = new System.Drawing.Size(180, 22);
            this.TimeDecelerate.Text = "&Decelerate";
            // 
            // TimeReverse
            // 
            this.TimeReverse.Image = global::TabbyCat.Properties.Resources.BackHS;
            this.TimeReverse.ImageTransparentColor = System.Drawing.Color.White;
            this.TimeReverse.Name = "TimeReverse";
            this.TimeReverse.Size = new System.Drawing.Size(180, 22);
            this.TimeReverse.Text = "&Reverse";
            // 
            // TimeStop
            // 
            this.TimeStop.Image = global::TabbyCat.Properties.Resources.StopHS;
            this.TimeStop.ImageTransparentColor = System.Drawing.Color.White;
            this.TimeStop.Name = "TimeStop";
            this.TimeStop.Size = new System.Drawing.Size(180, 22);
            this.TimeStop.Text = "&Stop";
            // 
            // TimePause
            // 
            this.TimePause.Image = global::TabbyCat.Properties.Resources.PauseHS;
            this.TimePause.ImageTransparentColor = System.Drawing.Color.White;
            this.TimePause.Name = "TimePause";
            this.TimePause.Size = new System.Drawing.Size(180, 22);
            this.TimePause.Text = "&Pause";
            // 
            // TimeForward
            // 
            this.TimeForward.Image = global::TabbyCat.Properties.Resources.PlayHS;
            this.TimeForward.Name = "TimeForward";
            this.TimeForward.Size = new System.Drawing.Size(180, 22);
            this.TimeForward.Text = "&Forward";
            // 
            // TimeAccelerate
            // 
            this.TimeAccelerate.Image = global::TabbyCat.Properties.Resources.FFwdHS;
            this.TimeAccelerate.ImageTransparentColor = System.Drawing.Color.White;
            this.TimeAccelerate.Name = "TimeAccelerate";
            this.TimeAccelerate.Size = new System.Drawing.Size(180, 22);
            this.TimeAccelerate.Text = "&Accelerate";
            // 
            // HelpMenu
            // 
            this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpOpenGLShadingLanguage,
            this.toolStripMenuItem12,
            this.HelpAbout});
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(47, 21);
            this.HelpMenu.Text = "&Help";
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
            this.HelpAbout.Text = "&About";
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
            // WorldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.ContextMenuStrip = this.PopupMenu;
            this.Controls.Add(this.ToolStripContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WorldForm";
            this.Text = "WorldForm";
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
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.PopupPropertiesMenu.ResumeLayout(false);
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolStripContainer ToolStripContainer;
        internal Jmk.Controls.JmkMenuStrip MainMenu;
        internal System.Windows.Forms.ToolStripMenuItem FileMenu;
        internal System.Windows.Forms.ToolStripMenuItem EditMenu;
        internal System.Windows.Forms.ToolStripMenuItem ViewMenu;
        internal System.Windows.Forms.ToolStripMenuItem HelpMenu;
        internal Jmk.Controls.JmkStatusStrip StatusBar;
        internal OpenTK.GLControl GLControl;
        internal Jmk.Controls.JmkToolStrip Toolbar;
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
        internal System.Windows.Forms.ToolStripMenuItem EditOptions;
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
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal Controls.PropertiesEdit PropertiesEdit;
        internal System.Windows.Forms.ContextMenuStrip PopupPropertiesMenu;
        internal System.Windows.Forms.ToolStripMenuItem PopupPropertiesUndock;
        internal System.Windows.Forms.ToolStripMenuItem PopupPropertiesHide;
        internal System.Windows.Forms.ToolTip ToolTip;
        internal System.Windows.Forms.ToolStripMenuItem EditAddNewTrace;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        internal System.Windows.Forms.ToolStripStatusLabel FPSlabel;
        internal System.Windows.Forms.ToolStripMenuItem MoveMenu;
        internal System.Windows.Forms.ToolStripMenuItem MoveStrafe;
        internal System.Windows.Forms.ToolStripMenuItem MoveLeft;
        internal System.Windows.Forms.ToolStripMenuItem MoveRight;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        internal System.Windows.Forms.ToolStripMenuItem MoveUp;
        internal System.Windows.Forms.ToolStripMenuItem MoveDown;
        internal System.Windows.Forms.ToolStripMenuItem MoveCircle;
        internal System.Windows.Forms.ToolStripMenuItem CircleLeft;
        internal System.Windows.Forms.ToolStripMenuItem CircleRight;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        internal System.Windows.Forms.ToolStripMenuItem CircleUp;
        internal System.Windows.Forms.ToolStripMenuItem CircleDown;
        internal System.Windows.Forms.ToolStripMenuItem MoveZoomRoll;
        internal System.Windows.Forms.ToolStripMenuItem ZoomIn;
        internal System.Windows.Forms.ToolStripMenuItem ZoomOut;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        internal System.Windows.Forms.ToolStripMenuItem RollClockwise;
        internal System.Windows.Forms.ToolStripMenuItem RollAnticlockwise;
        internal System.Windows.Forms.ContextMenuStrip PopupMenu;
    }
}