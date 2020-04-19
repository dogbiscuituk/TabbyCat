namespace TabbyCat.Controls
{
    partial class CodeEdit
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeEdit));
            this.ToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.MainSplit = new System.Windows.Forms.SplitContainer();
            this.EditSplit = new System.Windows.Forms.SplitContainer();
            this.TopSplit = new System.Windows.Forms.SplitContainer();
            this.SecondaryTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.PopupEditMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.miRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miCut = new System.Windows.Forms.ToolStripMenuItem();
            this.miCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.miPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.PrimaryTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.SecondaryRuler = new FastColoredTextBoxNS.Ruler();
            this.SecondaryMap = new FastColoredTextBoxNS.DocumentMap();
            this.BottomSplit = new System.Windows.Forms.SplitContainer();
            this.PrimaryRuler = new FastColoredTextBoxNS.Ruler();
            this.PrimaryMap = new FastColoredTextBoxNS.DocumentMap();
            this.jmkScrollPanel1 = new Jmk.Controls.JmkScrollPanel();
            this.lblBuiltInHelp = new Jmk.Controls.JmkLinkLabel();
            this.Toolbar = new Jmk.Controls.JmkToolStrip();
            this.tbExport = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbExportHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.tbExportRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.tbPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbUndo = new System.Windows.Forms.ToolStripButton();
            this.tbRedo = new System.Windows.Forms.ToolStripButton();
            this.tbCut = new System.Windows.Forms.ToolStripButton();
            this.tbCopy = new System.Windows.Forms.ToolStripButton();
            this.tbPaste = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbRuler = new System.Windows.Forms.ToolStripMenuItem();
            this.tbLineNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.tbDocumentMap = new System.Windows.Forms.ToolStripMenuItem();
            this.tbShader = new System.Windows.Forms.ToolStripSplitButton();
            this.miVertex = new System.Windows.Forms.ToolStripMenuItem();
            this.miTessellationControl = new System.Windows.Forms.ToolStripMenuItem();
            this.miTessellationEvaluation = new System.Windows.Forms.ToolStripMenuItem();
            this.miGeometry = new System.Windows.Forms.ToolStripMenuItem();
            this.miFragment = new System.Windows.Forms.ToolStripMenuItem();
            this.miCompute = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSplit = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSplitHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSplitVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSplitNone = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripContainer.ContentPanel.SuspendLayout();
            this.ToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).BeginInit();
            this.MainSplit.Panel1.SuspendLayout();
            this.MainSplit.Panel2.SuspendLayout();
            this.MainSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditSplit)).BeginInit();
            this.EditSplit.Panel1.SuspendLayout();
            this.EditSplit.Panel2.SuspendLayout();
            this.EditSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopSplit)).BeginInit();
            this.TopSplit.Panel1.SuspendLayout();
            this.TopSplit.Panel2.SuspendLayout();
            this.TopSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondaryTextBox)).BeginInit();
            this.PopupEditMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrimaryTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomSplit)).BeginInit();
            this.BottomSplit.Panel1.SuspendLayout();
            this.BottomSplit.Panel2.SuspendLayout();
            this.BottomSplit.SuspendLayout();
            this.jmkScrollPanel1.SuspendLayout();
            this.Toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStripContainer
            // 
            // 
            // ToolStripContainer.ContentPanel
            // 
            this.ToolStripContainer.ContentPanel.Controls.Add(this.MainSplit);
            this.ToolStripContainer.ContentPanel.Size = new System.Drawing.Size(360, 430);
            this.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer.LeftToolStripPanelVisible = false;
            this.ToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer.Name = "ToolStripContainer";
            this.ToolStripContainer.RightToolStripPanelVisible = false;
            this.ToolStripContainer.Size = new System.Drawing.Size(360, 455);
            this.ToolStripContainer.TabIndex = 0;
            this.ToolStripContainer.Text = "toolStripContainer1";
            // 
            // ToolStripContainer.TopToolStripPanel
            // 
            this.ToolStripContainer.TopToolStripPanel.Controls.Add(this.Toolbar);
            // 
            // MainSplit
            // 
            this.MainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MainSplit.Location = new System.Drawing.Point(0, 0);
            this.MainSplit.Name = "MainSplit";
            this.MainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplit.Panel1
            // 
            this.MainSplit.Panel1.Controls.Add(this.EditSplit);
            // 
            // MainSplit.Panel2
            // 
            this.MainSplit.Panel2.Controls.Add(this.jmkScrollPanel1);
            this.MainSplit.Size = new System.Drawing.Size(360, 430);
            this.MainSplit.SplitterDistance = 401;
            this.MainSplit.TabIndex = 4;
            // 
            // EditSplit
            // 
            this.EditSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditSplit.Location = new System.Drawing.Point(0, 0);
            this.EditSplit.Name = "EditSplit";
            this.EditSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // EditSplit.Panel1
            // 
            this.EditSplit.Panel1.Controls.Add(this.TopSplit);
            this.EditSplit.Panel1MinSize = 0;
            // 
            // EditSplit.Panel2
            // 
            this.EditSplit.Panel2.Controls.Add(this.BottomSplit);
            this.EditSplit.Panel2MinSize = 0;
            this.EditSplit.Size = new System.Drawing.Size(360, 401);
            this.EditSplit.SplitterDistance = 197;
            this.EditSplit.SplitterWidth = 5;
            this.EditSplit.TabIndex = 3;
            // 
            // TopSplit
            // 
            this.TopSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.TopSplit.Location = new System.Drawing.Point(0, 0);
            this.TopSplit.Name = "TopSplit";
            // 
            // TopSplit.Panel1
            // 
            this.TopSplit.Panel1.Controls.Add(this.SecondaryTextBox);
            this.TopSplit.Panel1.Controls.Add(this.SecondaryRuler);
            // 
            // TopSplit.Panel2
            // 
            this.TopSplit.Panel2.Controls.Add(this.SecondaryMap);
            this.TopSplit.Size = new System.Drawing.Size(360, 197);
            this.TopSplit.SplitterDistance = 228;
            this.TopSplit.SplitterWidth = 5;
            this.TopSplit.TabIndex = 5;
            // 
            // SecondaryTextBox
            // 
            this.SecondaryTextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.SecondaryTextBox.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.SecondaryTextBox.AutoScrollMinSize = new System.Drawing.Size(0, 15);
            this.SecondaryTextBox.BackBrush = null;
            this.SecondaryTextBox.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.SecondaryTextBox.CharHeight = 15;
            this.SecondaryTextBox.CharWidth = 7;
            this.SecondaryTextBox.ContextMenuStrip = this.PopupEditMenu;
            this.SecondaryTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SecondaryTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.SecondaryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SecondaryTextBox.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.SecondaryTextBox.IsReplaceMode = false;
            this.SecondaryTextBox.Language = FastColoredTextBoxNS.Language.CSharp;
            this.SecondaryTextBox.LeftBracket = '(';
            this.SecondaryTextBox.LeftBracket2 = '{';
            this.SecondaryTextBox.LeftPadding = 16;
            this.SecondaryTextBox.Location = new System.Drawing.Point(0, 28);
            this.SecondaryTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.SecondaryTextBox.Name = "SecondaryTextBox";
            this.SecondaryTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.SecondaryTextBox.RightBracket = ')';
            this.SecondaryTextBox.RightBracket2 = '}';
            this.SecondaryTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.SecondaryTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("SecondaryTextBox.ServiceColors")));
            this.SecondaryTextBox.ShowFoldingLines = true;
            this.SecondaryTextBox.ShowLineNumbers = false;
            this.SecondaryTextBox.Size = new System.Drawing.Size(228, 169);
            this.SecondaryTextBox.SourceTextBox = this.PrimaryTextBox;
            this.SecondaryTextBox.TabIndex = 1;
            this.SecondaryTextBox.TabLength = 2;
            this.SecondaryTextBox.WordWrap = true;
            this.SecondaryTextBox.Zoom = 100;
            // 
            // PopupEditMenu
            // 
            this.PopupEditMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miUndo,
            this.miRedo,
            this.toolStripMenuItem1,
            this.miCut,
            this.miCopy,
            this.miPaste,
            this.miDelete});
            this.PopupEditMenu.Name = "PopupEditMenu";
            this.PopupEditMenu.Size = new System.Drawing.Size(108, 142);
            // 
            // miUndo
            // 
            this.miUndo.Image = global::TabbyCat.Controls.Properties.Resources.Edit_UndoHS;
            this.miUndo.Name = "miUndo";
            this.miUndo.Size = new System.Drawing.Size(107, 22);
            this.miUndo.Text = "&Undo";
            // 
            // miRedo
            // 
            this.miRedo.Image = global::TabbyCat.Controls.Properties.Resources.Edit_RedoHS;
            this.miRedo.Name = "miRedo";
            this.miRedo.Size = new System.Drawing.Size(107, 22);
            this.miRedo.Text = "&Redo";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(104, 6);
            // 
            // miCut
            // 
            this.miCut.Image = global::TabbyCat.Controls.Properties.Resources.CutHS;
            this.miCut.Name = "miCut";
            this.miCut.Size = new System.Drawing.Size(107, 22);
            this.miCut.Text = "Cu&t";
            // 
            // miCopy
            // 
            this.miCopy.Image = global::TabbyCat.Controls.Properties.Resources.CopyHS;
            this.miCopy.Name = "miCopy";
            this.miCopy.Size = new System.Drawing.Size(107, 22);
            this.miCopy.Text = "&Copy";
            // 
            // miPaste
            // 
            this.miPaste.Image = global::TabbyCat.Controls.Properties.Resources.PasteHS;
            this.miPaste.Name = "miPaste";
            this.miPaste.Size = new System.Drawing.Size(107, 22);
            this.miPaste.Text = "&Paste";
            // 
            // miDelete
            // 
            this.miDelete.Image = global::TabbyCat.Controls.Properties.Resources.Delete;
            this.miDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(107, 22);
            this.miDelete.Text = "&Delete";
            // 
            // PrimaryTextBox
            // 
            this.PrimaryTextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.PrimaryTextBox.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.PrimaryTextBox.AutoScrollMinSize = new System.Drawing.Size(0, 15);
            this.PrimaryTextBox.BackBrush = null;
            this.PrimaryTextBox.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.PrimaryTextBox.CharHeight = 15;
            this.PrimaryTextBox.CharWidth = 7;
            this.PrimaryTextBox.ContextMenuStrip = this.PopupEditMenu;
            this.PrimaryTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PrimaryTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.PrimaryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrimaryTextBox.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.PrimaryTextBox.IsReplaceMode = false;
            this.PrimaryTextBox.Language = FastColoredTextBoxNS.Language.CSharp;
            this.PrimaryTextBox.LeftBracket = '(';
            this.PrimaryTextBox.LeftBracket2 = '{';
            this.PrimaryTextBox.LeftPadding = 16;
            this.PrimaryTextBox.Location = new System.Drawing.Point(0, 28);
            this.PrimaryTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.PrimaryTextBox.Name = "PrimaryTextBox";
            this.PrimaryTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.PrimaryTextBox.RightBracket = ')';
            this.PrimaryTextBox.RightBracket2 = '}';
            this.PrimaryTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.PrimaryTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("PrimaryTextBox.ServiceColors")));
            this.PrimaryTextBox.ShowFoldingLines = true;
            this.PrimaryTextBox.ShowLineNumbers = false;
            this.PrimaryTextBox.Size = new System.Drawing.Size(228, 171);
            this.PrimaryTextBox.TabIndex = 2;
            this.PrimaryTextBox.TabLength = 2;
            this.PrimaryTextBox.WordWrap = true;
            this.PrimaryTextBox.Zoom = 100;
            // 
            // SecondaryRuler
            // 
            this.SecondaryRuler.BackColor = System.Drawing.SystemColors.Control;
            this.SecondaryRuler.BackColor2 = System.Drawing.SystemColors.Control;
            this.SecondaryRuler.Dock = System.Windows.Forms.DockStyle.Top;
            this.SecondaryRuler.Location = new System.Drawing.Point(0, 0);
            this.SecondaryRuler.MaximumSize = new System.Drawing.Size(1073741824, 24);
            this.SecondaryRuler.MinimumSize = new System.Drawing.Size(0, 28);
            this.SecondaryRuler.Name = "SecondaryRuler";
            this.SecondaryRuler.Size = new System.Drawing.Size(228, 28);
            this.SecondaryRuler.TabIndex = 4;
            this.SecondaryRuler.Target = this.SecondaryTextBox;
            this.SecondaryRuler.Visible = false;
            // 
            // SecondaryMap
            // 
            this.SecondaryMap.BackColor = System.Drawing.SystemColors.Control;
            this.SecondaryMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SecondaryMap.ForeColor = System.Drawing.Color.Maroon;
            this.SecondaryMap.Location = new System.Drawing.Point(0, 0);
            this.SecondaryMap.Name = "SecondaryMap";
            this.SecondaryMap.Size = new System.Drawing.Size(127, 197);
            this.SecondaryMap.TabIndex = 0;
            this.SecondaryMap.Target = this.SecondaryTextBox;
            // 
            // BottomSplit
            // 
            this.BottomSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.BottomSplit.Location = new System.Drawing.Point(0, 0);
            this.BottomSplit.Name = "BottomSplit";
            // 
            // BottomSplit.Panel1
            // 
            this.BottomSplit.Panel1.Controls.Add(this.PrimaryTextBox);
            this.BottomSplit.Panel1.Controls.Add(this.PrimaryRuler);
            // 
            // BottomSplit.Panel2
            // 
            this.BottomSplit.Panel2.Controls.Add(this.PrimaryMap);
            this.BottomSplit.Size = new System.Drawing.Size(360, 199);
            this.BottomSplit.SplitterDistance = 228;
            this.BottomSplit.SplitterWidth = 5;
            this.BottomSplit.TabIndex = 4;
            // 
            // PrimaryRuler
            // 
            this.PrimaryRuler.BackColor = System.Drawing.SystemColors.Control;
            this.PrimaryRuler.BackColor2 = System.Drawing.SystemColors.Control;
            this.PrimaryRuler.Dock = System.Windows.Forms.DockStyle.Top;
            this.PrimaryRuler.Location = new System.Drawing.Point(0, 0);
            this.PrimaryRuler.MaximumSize = new System.Drawing.Size(1073741824, 24);
            this.PrimaryRuler.MinimumSize = new System.Drawing.Size(0, 28);
            this.PrimaryRuler.Name = "PrimaryRuler";
            this.PrimaryRuler.Size = new System.Drawing.Size(228, 28);
            this.PrimaryRuler.TabIndex = 3;
            this.PrimaryRuler.Target = this.PrimaryTextBox;
            this.PrimaryRuler.Visible = false;
            // 
            // PrimaryMap
            // 
            this.PrimaryMap.BackColor = System.Drawing.SystemColors.Control;
            this.PrimaryMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrimaryMap.ForeColor = System.Drawing.Color.Maroon;
            this.PrimaryMap.Location = new System.Drawing.Point(0, 0);
            this.PrimaryMap.Name = "PrimaryMap";
            this.PrimaryMap.Size = new System.Drawing.Size(127, 199);
            this.PrimaryMap.TabIndex = 0;
            this.PrimaryMap.Target = this.PrimaryTextBox;
            // 
            // jmkScrollPanel1
            // 
            this.jmkScrollPanel1.AutoScroll = true;
            this.jmkScrollPanel1.Controls.Add(this.lblBuiltInHelp);
            this.jmkScrollPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jmkScrollPanel1.Location = new System.Drawing.Point(0, 0);
            this.jmkScrollPanel1.Name = "jmkScrollPanel1";
            this.jmkScrollPanel1.Size = new System.Drawing.Size(360, 25);
            this.jmkScrollPanel1.TabIndex = 2;
            // 
            // lblBuiltInHelp
            // 
            this.lblBuiltInHelp.AutoSize = true;
            this.lblBuiltInHelp.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.lblBuiltInHelp.Location = new System.Drawing.Point(0, 0);
            this.lblBuiltInHelp.Name = "lblBuiltInHelp";
            this.lblBuiltInHelp.Padding = new System.Windows.Forms.Padding(2);
            this.lblBuiltInHelp.Size = new System.Drawing.Size(165, 21);
            this.lblBuiltInHelp.TabIndex = 1;
            this.lblBuiltInHelp.Text = "Help text will appear here.";
            // 
            // Toolbar
            // 
            this.Toolbar.Dock = System.Windows.Forms.DockStyle.None;
            this.Toolbar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbExport,
            this.tbPrint,
            this.toolStripSeparator1,
            this.tbUndo,
            this.tbRedo,
            this.tbCut,
            this.tbCopy,
            this.tbPaste,
            this.tbDelete,
            this.toolStripSeparator2,
            this.tbOptions,
            this.tbShader});
            this.Toolbar.Location = new System.Drawing.Point(0, 0);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(360, 25);
            this.Toolbar.Stretch = true;
            this.Toolbar.TabIndex = 0;
            // 
            // tbExport
            // 
            this.tbExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbExportHTML,
            this.tbExportRTF});
            this.tbExport.Image = global::TabbyCat.Controls.Properties.Resources.saveHS;
            this.tbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbExport.Name = "tbExport";
            this.tbExport.Size = new System.Drawing.Size(29, 22);
            this.tbExport.ToolTipText = "Export";
            // 
            // tbExportHTML
            // 
            this.tbExportHTML.Name = "tbExportHTML";
            this.tbExportHTML.Size = new System.Drawing.Size(180, 22);
            this.tbExportHTML.Text = "Save as HTML...";
            // 
            // tbExportRTF
            // 
            this.tbExportRTF.Name = "tbExportRTF";
            this.tbExportRTF.Size = new System.Drawing.Size(180, 22);
            this.tbExportRTF.Text = "Save as RTF...";
            // 
            // tbPrint
            // 
            this.tbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPrint.Image = global::TabbyCat.Controls.Properties.Resources.PrintHS;
            this.tbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPrint.Name = "tbPrint";
            this.tbPrint.Size = new System.Drawing.Size(23, 22);
            this.tbPrint.ToolTipText = "Print...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbUndo
            // 
            this.tbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbUndo.Image = global::TabbyCat.Controls.Properties.Resources.Edit_UndoHS;
            this.tbUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbUndo.Name = "tbUndo";
            this.tbUndo.Size = new System.Drawing.Size(23, 22);
            this.tbUndo.ToolTipText = "Undo";
            // 
            // tbRedo
            // 
            this.tbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRedo.Image = global::TabbyCat.Controls.Properties.Resources.Edit_RedoHS;
            this.tbRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRedo.Name = "tbRedo";
            this.tbRedo.Size = new System.Drawing.Size(23, 22);
            this.tbRedo.ToolTipText = "Redo";
            // 
            // tbCut
            // 
            this.tbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCut.Image = global::TabbyCat.Controls.Properties.Resources.CutHS;
            this.tbCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCut.Name = "tbCut";
            this.tbCut.Size = new System.Drawing.Size(23, 22);
            this.tbCut.ToolTipText = "Cut";
            // 
            // tbCopy
            // 
            this.tbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCopy.Image = global::TabbyCat.Controls.Properties.Resources.CopyHS;
            this.tbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCopy.Name = "tbCopy";
            this.tbCopy.Size = new System.Drawing.Size(23, 22);
            this.tbCopy.ToolTipText = "Copy";
            // 
            // tbPaste
            // 
            this.tbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPaste.Image = global::TabbyCat.Controls.Properties.Resources.PasteHS;
            this.tbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPaste.Name = "tbPaste";
            this.tbPaste.Size = new System.Drawing.Size(23, 22);
            this.tbPaste.ToolTipText = "Paste";
            // 
            // tbDelete
            // 
            this.tbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDelete.Image = global::TabbyCat.Controls.Properties.Resources.Delete;
            this.tbDelete.ImageTransparentColor = System.Drawing.Color.White;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(23, 22);
            this.tbDelete.ToolTipText = "Delete";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tbOptions
            // 
            this.tbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbRuler,
            this.tbLineNumbers,
            this.tbDocumentMap,
            this.toolStripMenuItem2,
            this.tbSplit});
            this.tbOptions.Image = global::TabbyCat.Controls.Properties.Resources.OptionsHS;
            this.tbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbOptions.Name = "tbOptions";
            this.tbOptions.Size = new System.Drawing.Size(29, 22);
            this.tbOptions.ToolTipText = "Options";
            // 
            // tbRuler
            // 
            this.tbRuler.Name = "tbRuler";
            this.tbRuler.Size = new System.Drawing.Size(180, 22);
            this.tbRuler.Text = "Ruler";
            // 
            // tbLineNumbers
            // 
            this.tbLineNumbers.Name = "tbLineNumbers";
            this.tbLineNumbers.Size = new System.Drawing.Size(180, 22);
            this.tbLineNumbers.Text = "Line Numbers";
            // 
            // tbDocumentMap
            // 
            this.tbDocumentMap.Name = "tbDocumentMap";
            this.tbDocumentMap.Size = new System.Drawing.Size(180, 22);
            this.tbDocumentMap.Text = "Document Map";
            // 
            // tbShader
            // 
            this.tbShader.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbShader.AutoSize = false;
            this.tbShader.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbShader.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miVertex,
            this.miTessellationControl,
            this.miTessellationEvaluation,
            this.miGeometry,
            this.miFragment,
            this.miCompute});
            this.tbShader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbShader.Image = ((System.Drawing.Image)(resources.GetObject("tbShader.Image")));
            this.tbShader.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbShader.Name = "tbShader";
            this.tbShader.Size = new System.Drawing.Size(96, 22);
            this.tbShader.Text = "Vertex";
            this.tbShader.ToolTipText = "Selected Shader";
            // 
            // miVertex
            // 
            this.miVertex.Name = "miVertex";
            this.miVertex.Size = new System.Drawing.Size(133, 22);
            this.miVertex.Text = "Vertex";
            this.miVertex.ToolTipText = "Vertex Shader";
            // 
            // miTessellationControl
            // 
            this.miTessellationControl.Name = "miTessellationControl";
            this.miTessellationControl.Size = new System.Drawing.Size(133, 22);
            this.miTessellationControl.Text = "Tess Ctrl";
            this.miTessellationControl.ToolTipText = "Tessellation Control Shader";
            // 
            // miTessellationEvaluation
            // 
            this.miTessellationEvaluation.Name = "miTessellationEvaluation";
            this.miTessellationEvaluation.Size = new System.Drawing.Size(133, 22);
            this.miTessellationEvaluation.Text = "Tess Eval";
            this.miTessellationEvaluation.ToolTipText = "Tessellation Evaluation Shader";
            // 
            // miGeometry
            // 
            this.miGeometry.Name = "miGeometry";
            this.miGeometry.Size = new System.Drawing.Size(133, 22);
            this.miGeometry.Text = "Geometry";
            this.miGeometry.ToolTipText = "Geometry Shader";
            // 
            // miFragment
            // 
            this.miFragment.Name = "miFragment";
            this.miFragment.Size = new System.Drawing.Size(133, 22);
            this.miFragment.Text = "Fragment";
            this.miFragment.ToolTipText = "Fragment Shader";
            // 
            // miCompute
            // 
            this.miCompute.Name = "miCompute";
            this.miCompute.Size = new System.Drawing.Size(133, 22);
            this.miCompute.Text = "Compute";
            this.miCompute.ToolTipText = "Compute Shader";
            // 
            // tbSplit
            // 
            this.tbSplit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSplitHorizontal,
            this.tbSplitVertical,
            this.toolStripMenuItem3,
            this.tbSplitNone});
            this.tbSplit.Image = global::TabbyCat.Controls.Properties.Resources.TileWindowsHorizontallyHS;
            this.tbSplit.Name = "tbSplit";
            this.tbSplit.Size = new System.Drawing.Size(180, 22);
            this.tbSplit.Text = "Split";
            // 
            // tbSplitHorizontal
            // 
            this.tbSplitHorizontal.Name = "tbSplitHorizontal";
            this.tbSplitHorizontal.Size = new System.Drawing.Size(180, 22);
            this.tbSplitHorizontal.Text = "Horizontal";
            // 
            // tbSplitVertical
            // 
            this.tbSplitVertical.Name = "tbSplitVertical";
            this.tbSplitVertical.Size = new System.Drawing.Size(180, 22);
            this.tbSplitVertical.Text = "Vertical";
            // 
            // tbSplitNone
            // 
            this.tbSplitNone.Name = "tbSplitNone";
            this.tbSplitNone.Size = new System.Drawing.Size(180, 22);
            this.tbSplitNone.Text = "None";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // CodeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ToolStripContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CodeEdit";
            this.Size = new System.Drawing.Size(360, 455);
            this.ToolStripContainer.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer.ResumeLayout(false);
            this.ToolStripContainer.PerformLayout();
            this.MainSplit.Panel1.ResumeLayout(false);
            this.MainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).EndInit();
            this.MainSplit.ResumeLayout(false);
            this.EditSplit.Panel1.ResumeLayout(false);
            this.EditSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EditSplit)).EndInit();
            this.EditSplit.ResumeLayout(false);
            this.TopSplit.Panel1.ResumeLayout(false);
            this.TopSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TopSplit)).EndInit();
            this.TopSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SecondaryTextBox)).EndInit();
            this.PopupEditMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PrimaryTextBox)).EndInit();
            this.BottomSplit.Panel1.ResumeLayout(false);
            this.BottomSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BottomSplit)).EndInit();
            this.BottomSplit.ResumeLayout(false);
            this.jmkScrollPanel1.ResumeLayout(false);
            this.jmkScrollPanel1.PerformLayout();
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ToolStripContainer ToolStripContainer;
        public Jmk.Controls.JmkToolStrip Toolbar;
        public System.Windows.Forms.ToolStripDropDownButton tbExport;
        public System.Windows.Forms.ToolStripMenuItem tbExportHTML;
        public System.Windows.Forms.ToolStripMenuItem tbExportRTF;
        public System.Windows.Forms.ToolStripButton tbPrint;
        public System.Windows.Forms.ToolStripDropDownButton tbOptions;
        public System.Windows.Forms.ToolStripMenuItem tbRuler;
        public System.Windows.Forms.ToolStripMenuItem tbLineNumbers;
        public System.Windows.Forms.ToolStripMenuItem tbDocumentMap;
        public System.Windows.Forms.SplitContainer EditSplit;
        public System.Windows.Forms.SplitContainer TopSplit;
        public FastColoredTextBoxNS.FastColoredTextBox SecondaryTextBox;
        public FastColoredTextBoxNS.FastColoredTextBox PrimaryTextBox;
        public FastColoredTextBoxNS.Ruler SecondaryRuler;
        public FastColoredTextBoxNS.DocumentMap SecondaryMap;
        public System.Windows.Forms.SplitContainer BottomSplit;
        public FastColoredTextBoxNS.Ruler PrimaryRuler;
        public FastColoredTextBoxNS.DocumentMap PrimaryMap;
        public System.Windows.Forms.ToolStripSplitButton tbShader;
        public System.Windows.Forms.ToolStripMenuItem miVertex;
        public System.Windows.Forms.ToolStripMenuItem miTessellationControl;
        public System.Windows.Forms.ToolStripMenuItem miTessellationEvaluation;
        public System.Windows.Forms.ToolStripMenuItem miGeometry;
        public System.Windows.Forms.ToolStripMenuItem miFragment;
        public System.Windows.Forms.ToolStripMenuItem miCompute;
        public System.Windows.Forms.SplitContainer MainSplit;
        public Jmk.Controls.JmkLinkLabel lblBuiltInHelp;
        public Jmk.Controls.JmkScrollPanel jmkScrollPanel1;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton tbUndo;
        public System.Windows.Forms.ToolStripButton tbRedo;
        public System.Windows.Forms.ToolStripButton tbCut;
        public System.Windows.Forms.ToolStripButton tbCopy;
        public System.Windows.Forms.ToolStripButton tbPaste;
        public System.Windows.Forms.ToolStripButton tbDelete;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ContextMenuStrip PopupEditMenu;
        public System.Windows.Forms.ToolStripMenuItem miUndo;
        public System.Windows.Forms.ToolStripMenuItem miRedo;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem miCut;
        public System.Windows.Forms.ToolStripMenuItem miCopy;
        public System.Windows.Forms.ToolStripMenuItem miPaste;
        public System.Windows.Forms.ToolStripMenuItem miDelete;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem tbSplit;
        public System.Windows.Forms.ToolStripMenuItem tbSplitHorizontal;
        public System.Windows.Forms.ToolStripMenuItem tbSplitVertical;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        public System.Windows.Forms.ToolStripMenuItem tbSplitNone;
    }
}
