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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.Splitter = new System.Windows.Forms.SplitContainer();
            this.SecondarySplitter = new System.Windows.Forms.SplitContainer();
            this.SecondaryTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.PrimaryTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.SecondaryRuler = new FastColoredTextBoxNS.Ruler();
            this.SecondaryMap = new FastColoredTextBoxNS.DocumentMap();
            this.PrimarySplitter = new System.Windows.Forms.SplitContainer();
            this.PrimaryRuler = new FastColoredTextBoxNS.Ruler();
            this.PrimaryMap = new FastColoredTextBoxNS.DocumentMap();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
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
            this.btnShader = new System.Windows.Forms.ToolStripDropDownButton();
            this.miVertex = new System.Windows.Forms.ToolStripMenuItem();
            this.miTessellationControl = new System.Windows.Forms.ToolStripMenuItem();
            this.miTessellationEvaluation = new System.Windows.Forms.ToolStripMenuItem();
            this.miGeometry = new System.Windows.Forms.ToolStripMenuItem();
            this.miFragment = new System.Windows.Forms.ToolStripMenuItem();
            this.miCompute = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
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
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.Splitter);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(247, 284);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(247, 309);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
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
            this.Splitter.Size = new System.Drawing.Size(247, 284);
            this.Splitter.SplitterDistance = 88;
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
            this.SecondarySplitter.Size = new System.Drawing.Size(247, 88);
            this.SecondarySplitter.SplitterDistance = 131;
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
            this.SecondaryTextBox.AutoScrollMinSize = new System.Drawing.Size(0, 14);
            this.SecondaryTextBox.BackBrush = null;
            this.SecondaryTextBox.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.SecondaryTextBox.CharHeight = 14;
            this.SecondaryTextBox.CharWidth = 8;
            this.SecondaryTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SecondaryTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.SecondaryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SecondaryTextBox.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.SecondaryTextBox.IsReplaceMode = false;
            this.SecondaryTextBox.Language = FastColoredTextBoxNS.Language.CSharp;
            this.SecondaryTextBox.LeftBracket = '(';
            this.SecondaryTextBox.LeftBracket2 = '{';
            this.SecondaryTextBox.LeftPadding = 16;
            this.SecondaryTextBox.Location = new System.Drawing.Point(0, 24);
            this.SecondaryTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.SecondaryTextBox.Name = "SecondaryTextBox";
            this.SecondaryTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.SecondaryTextBox.RightBracket = ')';
            this.SecondaryTextBox.RightBracket2 = '}';
            this.SecondaryTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.SecondaryTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("SecondaryTextBox.ServiceColors")));
            this.SecondaryTextBox.ShowFoldingLines = true;
            this.SecondaryTextBox.ShowLineNumbers = false;
            this.SecondaryTextBox.Size = new System.Drawing.Size(131, 64);
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
            this.PrimaryTextBox.AutoScrollMinSize = new System.Drawing.Size(0, 14);
            this.PrimaryTextBox.BackBrush = null;
            this.PrimaryTextBox.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.PrimaryTextBox.CharHeight = 14;
            this.PrimaryTextBox.CharWidth = 8;
            this.PrimaryTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PrimaryTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.PrimaryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrimaryTextBox.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.PrimaryTextBox.IsReplaceMode = false;
            this.PrimaryTextBox.Language = FastColoredTextBoxNS.Language.CSharp;
            this.PrimaryTextBox.LeftBracket = '(';
            this.PrimaryTextBox.LeftBracket2 = '{';
            this.PrimaryTextBox.LeftPadding = 16;
            this.PrimaryTextBox.Location = new System.Drawing.Point(0, 24);
            this.PrimaryTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.PrimaryTextBox.Name = "PrimaryTextBox";
            this.PrimaryTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.PrimaryTextBox.RightBracket = ')';
            this.PrimaryTextBox.RightBracket2 = '}';
            this.PrimaryTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.PrimaryTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("PrimaryTextBox.ServiceColors")));
            this.PrimaryTextBox.ShowFoldingLines = true;
            this.PrimaryTextBox.ShowLineNumbers = false;
            this.PrimaryTextBox.Size = new System.Drawing.Size(131, 168);
            this.PrimaryTextBox.TabIndex = 2;
            this.PrimaryTextBox.TabLength = 2;
            this.PrimaryTextBox.WordWrap = true;
            this.PrimaryTextBox.Zoom = 100;
            // 
            // SecondaryRuler
            // 
            this.SecondaryRuler.Dock = System.Windows.Forms.DockStyle.Top;
            this.SecondaryRuler.Location = new System.Drawing.Point(0, 0);
            this.SecondaryRuler.MaximumSize = new System.Drawing.Size(1252698752, 28);
            this.SecondaryRuler.MinimumSize = new System.Drawing.Size(0, 24);
            this.SecondaryRuler.Name = "SecondaryRuler";
            this.SecondaryRuler.Size = new System.Drawing.Size(131, 24);
            this.SecondaryRuler.TabIndex = 4;
            this.SecondaryRuler.Target = this.SecondaryTextBox;
            this.SecondaryRuler.Visible = false;
            // 
            // SecondaryMap
            // 
            this.SecondaryMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SecondaryMap.ForeColor = System.Drawing.Color.Maroon;
            this.SecondaryMap.Location = new System.Drawing.Point(0, 0);
            this.SecondaryMap.Name = "SecondaryMap";
            this.SecondaryMap.Size = new System.Drawing.Size(112, 88);
            this.SecondaryMap.TabIndex = 0;
            this.SecondaryMap.Target = this.SecondaryTextBox;
            this.SecondaryMap.Text = "documentMap1";
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
            this.PrimarySplitter.Size = new System.Drawing.Size(247, 192);
            this.PrimarySplitter.SplitterDistance = 131;
            this.PrimarySplitter.TabIndex = 4;
            // 
            // PrimaryRuler
            // 
            this.PrimaryRuler.Dock = System.Windows.Forms.DockStyle.Top;
            this.PrimaryRuler.Location = new System.Drawing.Point(0, 0);
            this.PrimaryRuler.MaximumSize = new System.Drawing.Size(1073741824, 24);
            this.PrimaryRuler.MinimumSize = new System.Drawing.Size(0, 24);
            this.PrimaryRuler.Name = "PrimaryRuler";
            this.PrimaryRuler.Size = new System.Drawing.Size(131, 24);
            this.PrimaryRuler.TabIndex = 3;
            this.PrimaryRuler.Target = this.PrimaryTextBox;
            this.PrimaryRuler.Visible = false;
            // 
            // PrimaryMap
            // 
            this.PrimaryMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrimaryMap.ForeColor = System.Drawing.Color.Maroon;
            this.PrimaryMap.Location = new System.Drawing.Point(0, 0);
            this.PrimaryMap.Name = "PrimaryMap";
            this.PrimaryMap.Size = new System.Drawing.Size(112, 192);
            this.PrimaryMap.TabIndex = 0;
            this.PrimaryMap.Target = this.PrimaryTextBox;
            this.PrimaryMap.Text = "documentMap2";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShader,
            this.btnExport,
            this.btnPrint,
            this.btnOptions,
            this.btnSplit,
            this.btnHelp});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(168, 25);
            this.toolStrip1.TabIndex = 0;
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
            this.btnExportHTML.Size = new System.Drawing.Size(180, 22);
            this.btnExportHTML.Text = "Export as &HTML...";
            // 
            // btnExportRTF
            // 
            this.btnExportRTF.Name = "btnExportRTF";
            this.btnExportRTF.Size = new System.Drawing.Size(180, 22);
            this.btnExportRTF.Text = "Export as &RTF...";
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrint.Image = global::TabbyCat.Controls.Properties.Resources.PrintHS;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(23, 22);
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
            this.btnRuler.Size = new System.Drawing.Size(180, 22);
            this.btnRuler.Text = "&Ruler";
            // 
            // btnLineNumbers
            // 
            this.btnLineNumbers.Name = "btnLineNumbers";
            this.btnLineNumbers.Size = new System.Drawing.Size(180, 22);
            this.btnLineNumbers.Text = "&Line Numbers";
            // 
            // btnDocumentMap
            // 
            this.btnDocumentMap.Name = "btnDocumentMap";
            this.btnDocumentMap.Size = new System.Drawing.Size(180, 22);
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
            this.btnShader.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
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
            this.btnShader.Size = new System.Drawing.Size(29, 22);
            this.btnShader.Text = "toolStripDropDownButton1";
            // 
            // miVertex
            // 
            this.miVertex.Name = "miVertex";
            this.miVertex.Size = new System.Drawing.Size(193, 22);
            this.miVertex.Text = "&Vertex";
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
            this.miGeometry.Text = "&Geometry";
            // 
            // miFragment
            // 
            this.miFragment.Name = "miFragment";
            this.miFragment.Size = new System.Drawing.Size(193, 22);
            this.miFragment.Text = "&Fragment";
            // 
            // miCompute
            // 
            this.miCompute.Name = "miCompute";
            this.miCompute.Size = new System.Drawing.Size(193, 22);
            this.miCompute.Text = "&Compute";
            // 
            // ShaderEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "ShaderEdit";
            this.Size = new System.Drawing.Size(247, 309);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
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
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripDropDownButton btnExport;
        internal System.Windows.Forms.ToolStripMenuItem btnExportHTML;
        internal System.Windows.Forms.ToolStripMenuItem btnExportRTF;
        internal System.Windows.Forms.ToolStripButton btnPrint;
        internal System.Windows.Forms.ToolStripDropDownButton btnOptions;
        internal System.Windows.Forms.ToolStripMenuItem btnRuler;
        internal System.Windows.Forms.ToolStripMenuItem btnLineNumbers;
        internal System.Windows.Forms.ToolStripMenuItem btnDocumentMap;
        internal System.Windows.Forms.ToolStripButton btnSplit;
        internal System.Windows.Forms.ToolStripButton btnHelp;
        internal System.Windows.Forms.SplitContainer Splitter;
        internal System.Windows.Forms.SplitContainer SecondarySplitter;
        internal FastColoredTextBoxNS.FastColoredTextBox SecondaryTextBox;
        internal FastColoredTextBoxNS.FastColoredTextBox PrimaryTextBox;
        internal FastColoredTextBoxNS.Ruler SecondaryRuler;
        internal FastColoredTextBoxNS.DocumentMap SecondaryMap;
        internal System.Windows.Forms.SplitContainer PrimarySplitter;
        internal FastColoredTextBoxNS.Ruler PrimaryRuler;
        internal FastColoredTextBoxNS.DocumentMap PrimaryMap;
        private System.Windows.Forms.ToolStripDropDownButton btnShader;
        private System.Windows.Forms.ToolStripMenuItem miVertex;
        private System.Windows.Forms.ToolStripMenuItem miTessellationControl;
        private System.Windows.Forms.ToolStripMenuItem miTessellationEvaluation;
        private System.Windows.Forms.ToolStripMenuItem miGeometry;
        private System.Windows.Forms.ToolStripMenuItem miFragment;
        private System.Windows.Forms.ToolStripMenuItem miCompute;
    }
}
