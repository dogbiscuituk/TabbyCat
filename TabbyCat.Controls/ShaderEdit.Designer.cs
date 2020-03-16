namespace TabbyCat.Controls
{
    partial class ShaderEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShaderEdit));
            this.ToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Splitter = new System.Windows.Forms.SplitContainer();
            this.SecondarySplitter = new System.Windows.Forms.SplitContainer();
            this.SecondaryTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.PrimaryTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.SecondaryRuler = new FastColoredTextBoxNS.Ruler();
            this.SecondaryMap = new FastColoredTextBoxNS.DocumentMap();
            this.PrimarySplitter = new System.Windows.Forms.SplitContainer();
            this.PrimaryRuler = new FastColoredTextBoxNS.Ruler();
            this.PrimaryMap = new FastColoredTextBoxNS.DocumentMap();
            this.lblBuiltInHelp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Toolbar = new System.Windows.Forms.ToolStrip();
            this.btnExport = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnExportHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnRuler = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLineNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDocumentMap = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSplit = new System.Windows.Forms.ToolStripButton();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.btnShader = new System.Windows.Forms.ToolStripSplitButton();
            this.miVertex = new System.Windows.Forms.ToolStripMenuItem();
            this.miTessellationControl = new System.Windows.Forms.ToolStripMenuItem();
            this.miTessellationEvaluation = new System.Windows.Forms.ToolStripMenuItem();
            this.miGeometry = new System.Windows.Forms.ToolStripMenuItem();
            this.miFragment = new System.Windows.Forms.ToolStripMenuItem();
            this.miCompute = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripContainer.ContentPanel.SuspendLayout();
            this.ToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Splitter)).BeginInit();
            this.Splitter.Panel1.SuspendLayout();
            this.Splitter.Panel2.SuspendLayout();
            this.Splitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondarySplitter)).BeginInit();
            this.SecondarySplitter.Panel1.SuspendLayout();
            this.SecondarySplitter.Panel2.SuspendLayout();
            this.SecondarySplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondaryTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrimaryTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrimarySplitter)).BeginInit();
            this.PrimarySplitter.Panel1.SuspendLayout();
            this.PrimarySplitter.Panel2.SuspendLayout();
            this.PrimarySplitter.SuspendLayout();
            this.Toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStripContainer
            // 
            // 
            // ToolStripContainer.ContentPanel
            // 
            this.ToolStripContainer.ContentPanel.Controls.Add(this.splitContainer1);
            this.ToolStripContainer.ContentPanel.Size = new System.Drawing.Size(320, 455);
            this.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer.LeftToolStripPanelVisible = false;
            this.ToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer.Name = "ToolStripContainer";
            this.ToolStripContainer.RightToolStripPanelVisible = false;
            this.ToolStripContainer.Size = new System.Drawing.Size(320, 480);
            this.ToolStripContainer.TabIndex = 0;
            this.ToolStripContainer.Text = "toolStripContainer1";
            // 
            // ToolStripContainer.TopToolStripPanel
            // 
            this.ToolStripContainer.TopToolStripPanel.Controls.Add(this.Toolbar);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Splitter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.lblBuiltInHelp);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(320, 455);
            this.splitContainer1.SplitterDistance = 359;
            this.splitContainer1.TabIndex = 4;
            // 
            // Splitter
            // 
            this.Splitter.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Splitter.Location = new System.Drawing.Point(0, 0);
            this.Splitter.Name = "Splitter";
            this.Splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Splitter.Panel1
            // 
            this.Splitter.Panel1.Controls.Add(this.SecondarySplitter);
            this.Splitter.Panel1MinSize = 0;
            // 
            // Splitter.Panel2
            // 
            this.Splitter.Panel2.Controls.Add(this.PrimarySplitter);
            this.Splitter.Panel2MinSize = 0;
            this.Splitter.Size = new System.Drawing.Size(320, 359);
            this.Splitter.SplitterDistance = 177;
            this.Splitter.SplitterWidth = 5;
            this.Splitter.TabIndex = 3;
            // 
            // SecondarySplitter
            // 
            this.SecondarySplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SecondarySplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SecondarySplitter.Location = new System.Drawing.Point(0, 0);
            this.SecondarySplitter.Name = "SecondarySplitter";
            // 
            // SecondarySplitter.Panel1
            // 
            this.SecondarySplitter.Panel1.Controls.Add(this.SecondaryTextBox);
            this.SecondarySplitter.Panel1.Controls.Add(this.SecondaryRuler);
            // 
            // SecondarySplitter.Panel2
            // 
            this.SecondarySplitter.Panel2.Controls.Add(this.SecondaryMap);
            this.SecondarySplitter.Size = new System.Drawing.Size(320, 177);
            this.SecondarySplitter.SplitterDistance = 213;
            this.SecondarySplitter.SplitterWidth = 5;
            this.SecondarySplitter.TabIndex = 5;
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
            this.SecondaryTextBox.Size = new System.Drawing.Size(213, 149);
            this.SecondaryTextBox.SourceTextBox = this.PrimaryTextBox;
            this.SecondaryTextBox.TabIndex = 1;
            this.SecondaryTextBox.TabLength = 2;
            this.SecondaryTextBox.WordWrap = true;
            this.SecondaryTextBox.Zoom = 100;
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
            this.PrimaryTextBox.Size = new System.Drawing.Size(213, 149);
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
            this.SecondaryRuler.MaximumSize = new System.Drawing.Size(1461481856, 32);
            this.SecondaryRuler.MinimumSize = new System.Drawing.Size(0, 28);
            this.SecondaryRuler.Name = "SecondaryRuler";
            this.SecondaryRuler.Size = new System.Drawing.Size(213, 28);
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
            this.SecondaryMap.Size = new System.Drawing.Size(102, 177);
            this.SecondaryMap.TabIndex = 0;
            this.SecondaryMap.Target = this.SecondaryTextBox;
            this.SecondaryMap.Text = "documentMap1";
            this.SecondaryMap.Visible = false;
            // 
            // PrimarySplitter
            // 
            this.PrimarySplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrimarySplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.PrimarySplitter.Location = new System.Drawing.Point(0, 0);
            this.PrimarySplitter.Name = "PrimarySplitter";
            // 
            // PrimarySplitter.Panel1
            // 
            this.PrimarySplitter.Panel1.Controls.Add(this.PrimaryTextBox);
            this.PrimarySplitter.Panel1.Controls.Add(this.PrimaryRuler);
            // 
            // PrimarySplitter.Panel2
            // 
            this.PrimarySplitter.Panel2.Controls.Add(this.PrimaryMap);
            this.PrimarySplitter.Size = new System.Drawing.Size(320, 177);
            this.PrimarySplitter.SplitterDistance = 213;
            this.PrimarySplitter.SplitterWidth = 5;
            this.PrimarySplitter.TabIndex = 4;
            // 
            // PrimaryRuler
            // 
            this.PrimaryRuler.BackColor = System.Drawing.SystemColors.Control;
            this.PrimaryRuler.BackColor2 = System.Drawing.SystemColors.Control;
            this.PrimaryRuler.Dock = System.Windows.Forms.DockStyle.Top;
            this.PrimaryRuler.Location = new System.Drawing.Point(0, 0);
            this.PrimaryRuler.MaximumSize = new System.Drawing.Size(1252698752, 28);
            this.PrimaryRuler.MinimumSize = new System.Drawing.Size(0, 28);
            this.PrimaryRuler.Name = "PrimaryRuler";
            this.PrimaryRuler.Size = new System.Drawing.Size(213, 28);
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
            this.PrimaryMap.Size = new System.Drawing.Size(102, 177);
            this.PrimaryMap.TabIndex = 0;
            this.PrimaryMap.Target = this.PrimaryTextBox;
            this.PrimaryMap.Text = "documentMap2";
            this.PrimaryMap.Visible = false;
            // 
            // lblBuiltInHelp
            // 
            this.lblBuiltInHelp.AutoSize = true;
            this.lblBuiltInHelp.Location = new System.Drawing.Point(3, 19);
            this.lblBuiltInHelp.Name = "lblBuiltInHelp";
            this.lblBuiltInHelp.Padding = new System.Windows.Forms.Padding(2);
            this.lblBuiltInHelp.Size = new System.Drawing.Size(147, 19);
            this.lblBuiltInHelp.TabIndex = 1;
            this.lblBuiltInHelp.Text = "Help text will appear here.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2);
            this.label1.Size = new System.Drawing.Size(197, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Special built-in language variables";
            // 
            // Toolbar
            // 
            this.Toolbar.Dock = System.Windows.Forms.DockStyle.None;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExport,
            this.btnPrint,
            this.btnOptions,
            this.btnSplit,
            this.btnHelp,
            this.btnShader});
            this.Toolbar.Location = new System.Drawing.Point(3, 0);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(283, 25);
            this.Toolbar.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExportHTML,
            this.btnExportRTF});
            this.btnExport.Image = global::TabbyCat.Controls.Properties.Resources.saveHS;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(29, 22);
            this.btnExport.ToolTipText = "Export";
            // 
            // btnExportHTML
            // 
            this.btnExportHTML.Name = "btnExportHTML";
            this.btnExportHTML.Size = new System.Drawing.Size(166, 22);
            this.btnExportHTML.Text = "Export as &HTML...";
            // 
            // btnExportRTF
            // 
            this.btnExportRTF.Name = "btnExportRTF";
            this.btnExportRTF.Size = new System.Drawing.Size(166, 22);
            this.btnExportRTF.Text = "Export as &RTF...";
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrint.Image = global::TabbyCat.Controls.Properties.Resources.PrintHS;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(23, 22);
            this.btnPrint.ToolTipText = "Print...";
            // 
            // btnOptions
            // 
            this.btnOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRuler,
            this.btnLineNumbers,
            this.btnDocumentMap});
            this.btnOptions.Image = global::TabbyCat.Controls.Properties.Resources.OptionsHS;
            this.btnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(29, 22);
            this.btnOptions.ToolTipText = "Options";
            // 
            // btnRuler
            // 
            this.btnRuler.Name = "btnRuler";
            this.btnRuler.Size = new System.Drawing.Size(157, 22);
            this.btnRuler.Text = "&Ruler";
            // 
            // btnLineNumbers
            // 
            this.btnLineNumbers.Name = "btnLineNumbers";
            this.btnLineNumbers.Size = new System.Drawing.Size(157, 22);
            this.btnLineNumbers.Text = "&Line Numbers";
            // 
            // btnDocumentMap
            // 
            this.btnDocumentMap.Name = "btnDocumentMap";
            this.btnDocumentMap.Size = new System.Drawing.Size(157, 22);
            this.btnDocumentMap.Text = "&Document Map";
            // 
            // btnSplit
            // 
            this.btnSplit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSplit.Image = global::TabbyCat.Controls.Properties.Resources.TileWindowsHorizontallyHS;
            this.btnSplit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(23, 22);
            this.btnSplit.ToolTipText = "Split";
            // 
            // btnHelp
            // 
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHelp.Image = global::TabbyCat.Controls.Properties.Resources.info;
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(23, 22);
            this.btnHelp.ToolTipText = "Help";
            // 
            // btnShader
            // 
            this.btnShader.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnShader.AutoSize = false;
            this.btnShader.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnShader.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miVertex,
            this.miTessellationControl,
            this.miTessellationEvaluation,
            this.miGeometry,
            this.miFragment,
            this.miCompute});
            this.btnShader.Image = ((System.Drawing.Image)(resources.GetObject("btnShader.Image")));
            this.btnShader.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShader.Name = "btnShader";
            this.btnShader.Size = new System.Drawing.Size(144, 22);
            this.btnShader.Text = "Vertex Shader";
            this.btnShader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // miVertex
            // 
            this.miVertex.Name = "miVertex";
            this.miVertex.Size = new System.Drawing.Size(193, 22);
            this.miVertex.Text = "&Vertex Shader";
            // 
            // miTessellationControl
            // 
            this.miTessellationControl.Name = "miTessellationControl";
            this.miTessellationControl.Size = new System.Drawing.Size(193, 22);
            this.miTessellationControl.Text = "&Tessellation Control";
            // 
            // miTessellationEvaluation
            // 
            this.miTessellationEvaluation.Name = "miTessellationEvaluation";
            this.miTessellationEvaluation.Size = new System.Drawing.Size(193, 22);
            this.miTessellationEvaluation.Text = "Tessellation &Evaluation";
            // 
            // miGeometry
            // 
            this.miGeometry.Name = "miGeometry";
            this.miGeometry.Size = new System.Drawing.Size(193, 22);
            this.miGeometry.Text = "&Geometry Shader";
            // 
            // miFragment
            // 
            this.miFragment.Name = "miFragment";
            this.miFragment.Size = new System.Drawing.Size(193, 22);
            this.miFragment.Text = "&Fragment Shader";
            // 
            // miCompute
            // 
            this.miCompute.Name = "miCompute";
            this.miCompute.Size = new System.Drawing.Size(193, 22);
            this.miCompute.Text = "&Compute Shader";
            // 
            // ShaderEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ToolStripContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ShaderEdit";
            this.Size = new System.Drawing.Size(320, 480);
            this.ToolStripContainer.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer.ResumeLayout(false);
            this.ToolStripContainer.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Splitter.Panel1.ResumeLayout(false);
            this.Splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Splitter)).EndInit();
            this.Splitter.ResumeLayout(false);
            this.SecondarySplitter.Panel1.ResumeLayout(false);
            this.SecondarySplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SecondarySplitter)).EndInit();
            this.SecondarySplitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SecondaryTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrimaryTextBox)).EndInit();
            this.PrimarySplitter.Panel1.ResumeLayout(false);
            this.PrimarySplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PrimarySplitter)).EndInit();
            this.PrimarySplitter.ResumeLayout(false);
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ToolStripContainer ToolStripContainer;
        public System.Windows.Forms.ToolStrip Toolbar;
        public System.Windows.Forms.ToolStripDropDownButton btnExport;
        public System.Windows.Forms.ToolStripMenuItem btnExportHTML;
        public System.Windows.Forms.ToolStripMenuItem btnExportRTF;
        public System.Windows.Forms.ToolStripButton btnPrint;
        public System.Windows.Forms.ToolStripDropDownButton btnOptions;
        public System.Windows.Forms.ToolStripMenuItem btnRuler;
        public System.Windows.Forms.ToolStripMenuItem btnLineNumbers;
        public System.Windows.Forms.ToolStripMenuItem btnDocumentMap;
        public System.Windows.Forms.ToolStripButton btnSplit;
        public System.Windows.Forms.ToolStripButton btnHelp;
        public System.Windows.Forms.SplitContainer Splitter;
        public System.Windows.Forms.SplitContainer SecondarySplitter;
        public FastColoredTextBoxNS.FastColoredTextBox SecondaryTextBox;
        public FastColoredTextBoxNS.FastColoredTextBox PrimaryTextBox;
        public FastColoredTextBoxNS.Ruler SecondaryRuler;
        public FastColoredTextBoxNS.DocumentMap SecondaryMap;
        public System.Windows.Forms.SplitContainer PrimarySplitter;
        public FastColoredTextBoxNS.Ruler PrimaryRuler;
        public FastColoredTextBoxNS.DocumentMap PrimaryMap;
        public System.Windows.Forms.ToolStripSplitButton btnShader;
        public System.Windows.Forms.ToolStripMenuItem miVertex;
        public System.Windows.Forms.ToolStripMenuItem miTessellationControl;
        public System.Windows.Forms.ToolStripMenuItem miTessellationEvaluation;
        public System.Windows.Forms.ToolStripMenuItem miGeometry;
        public System.Windows.Forms.ToolStripMenuItem miFragment;
        public System.Windows.Forms.ToolStripMenuItem miCompute;
        public System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblBuiltInHelp;
    }
}
