namespace TabbyCat.Controls
{
    partial class TraceEdit
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
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblSelectedTraces = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.edDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.seLocationY = new System.Windows.Forms.NumericUpDown();
            this.seLocationZ = new System.Windows.Forms.NumericUpDown();
            this.seScaleX = new System.Windows.Forms.NumericUpDown();
            this.seScaleY = new System.Windows.Forms.NumericUpDown();
            this.seScaleZ = new System.Windows.Forms.NumericUpDown();
            this.seMinimumX = new System.Windows.Forms.NumericUpDown();
            this.seMinimumY = new System.Windows.Forms.NumericUpDown();
            this.seMinimumZ = new System.Windows.Forms.NumericUpDown();
            this.seMaximumX = new System.Windows.Forms.NumericUpDown();
            this.seMaximumY = new System.Windows.Forms.NumericUpDown();
            this.seMaximumZ = new System.Windows.Forms.NumericUpDown();
            this.seStripCountX = new System.Windows.Forms.NumericUpDown();
            this.seStripCountY = new System.Windows.Forms.NumericUpDown();
            this.seStripCountZ = new System.Windows.Forms.NumericUpDown();
            this.cbPattern = new System.Windows.Forms.ComboBox();
            this.cbVisible = new System.Windows.Forms.CheckBox();
            this.seLocationX = new System.Windows.Forms.NumericUpDown();
            this.SelectionToolbar = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.sePitch = new Jmk.Controls.JmkNumericUpDownDegrees();
            this.seYaw = new Jmk.Controls.JmkNumericUpDownDegrees();
            this.seRoll = new Jmk.Controls.JmkNumericUpDownDegrees();
            this.TableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seLocationY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLocationZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seScaleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seScaleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seScaleZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMinimumX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMinimumY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMinimumZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMaximumX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMaximumY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMaximumZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStripCountX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStripCountY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStripCountZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLocationX)).BeginInit();
            this.SelectionToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sePitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seYaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seRoll)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.TableLayoutPanel.ColumnCount = 4;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.Controls.Add(this.lblSelectedTraces, 0, 8);
            this.TableLayoutPanel.Controls.Add(this.label8, 0, 6);
            this.TableLayoutPanel.Controls.Add(this.label2, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.edDescription, 1, 0);
            this.TableLayoutPanel.Controls.Add(this.label3, 0, 2);
            this.TableLayoutPanel.Controls.Add(this.label4, 0, 3);
            this.TableLayoutPanel.Controls.Add(this.label5, 0, 7);
            this.TableLayoutPanel.Controls.Add(this.label6, 0, 4);
            this.TableLayoutPanel.Controls.Add(this.label7, 0, 5);
            this.TableLayoutPanel.Controls.Add(this.seLocationY, 2, 1);
            this.TableLayoutPanel.Controls.Add(this.seLocationZ, 3, 1);
            this.TableLayoutPanel.Controls.Add(this.sePitch, 1, 2);
            this.TableLayoutPanel.Controls.Add(this.seYaw, 2, 2);
            this.TableLayoutPanel.Controls.Add(this.seRoll, 3, 2);
            this.TableLayoutPanel.Controls.Add(this.seScaleX, 1, 3);
            this.TableLayoutPanel.Controls.Add(this.seScaleY, 2, 3);
            this.TableLayoutPanel.Controls.Add(this.seScaleZ, 3, 3);
            this.TableLayoutPanel.Controls.Add(this.seMinimumX, 1, 4);
            this.TableLayoutPanel.Controls.Add(this.seMinimumY, 2, 4);
            this.TableLayoutPanel.Controls.Add(this.seMinimumZ, 3, 4);
            this.TableLayoutPanel.Controls.Add(this.seMaximumX, 1, 5);
            this.TableLayoutPanel.Controls.Add(this.seMaximumY, 2, 5);
            this.TableLayoutPanel.Controls.Add(this.seMaximumZ, 3, 5);
            this.TableLayoutPanel.Controls.Add(this.seStripCountX, 1, 6);
            this.TableLayoutPanel.Controls.Add(this.seStripCountY, 2, 6);
            this.TableLayoutPanel.Controls.Add(this.seStripCountZ, 3, 6);
            this.TableLayoutPanel.Controls.Add(this.cbPattern, 1, 7);
            this.TableLayoutPanel.Controls.Add(this.cbVisible, 3, 7);
            this.TableLayoutPanel.Controls.Add(this.seLocationX, 1, 1);
            this.TableLayoutPanel.Controls.Add(this.SelectionToolbar, 1, 8);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 10;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.Size = new System.Drawing.Size(360, 246);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // lblSelectedTraces
            // 
            this.lblSelectedTraces.BackColor = System.Drawing.SystemColors.Control;
            this.lblSelectedTraces.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSelectedTraces.Location = new System.Drawing.Point(3, 208);
            this.lblSelectedTraces.Name = "lblSelectedTraces";
            this.lblSelectedTraces.Size = new System.Drawing.Size(84, 34);
            this.lblSelectedTraces.TabIndex = 29;
            this.lblSelectedTraces.Text = "Selected\r\ntrace(s)";
            this.lblSelectedTraces.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 154);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label8.Size = new System.Drawing.Size(84, 25);
            this.label8.TabIndex = 22;
            this.label8.Text = "#Strips";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Location";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.label2, "Trace location");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label1.Size = new System.Drawing.Size(84, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Description";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.label1, "The description of this trace");
            // 
            // edDescription
            // 
            this.edDescription.BackColor = System.Drawing.SystemColors.Window;
            this.edDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TableLayoutPanel.SetColumnSpan(this.edDescription, 3);
            this.edDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edDescription.Location = new System.Drawing.Point(92, 2);
            this.edDescription.Margin = new System.Windows.Forms.Padding(2);
            this.edDescription.Name = "edDescription";
            this.edDescription.Size = new System.Drawing.Size(266, 25);
            this.edDescription.TabIndex = 1;
            this.ToolTip.SetToolTip(this.edDescription, "The description of this trace");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 54);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label3.Size = new System.Drawing.Size(84, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Orientation";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 79);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label4.Size = new System.Drawing.Size(84, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Scale";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.label4, "Trace magnification factor");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 29);
            this.label5.TabIndex = 26;
            this.label5.Text = "Pattern";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.label5, "The texture of the trace");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 104);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label6.Size = new System.Drawing.Size(84, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Minimum";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 129);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label7.Size = new System.Drawing.Size(84, 25);
            this.label7.TabIndex = 18;
            this.label7.Text = "Maximum";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // seLocationY
            // 
            this.seLocationY.BackColor = System.Drawing.SystemColors.Window;
            this.seLocationY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seLocationY.DecimalPlaces = 3;
            this.seLocationY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seLocationY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seLocationY.Location = new System.Drawing.Point(182, 31);
            this.seLocationY.Margin = new System.Windows.Forms.Padding(2);
            this.seLocationY.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seLocationY.Name = "seLocationY";
            this.seLocationY.Size = new System.Drawing.Size(86, 21);
            this.seLocationY.TabIndex = 4;
            this.seLocationY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seLocationY, "Location Y");
            // 
            // seLocationZ
            // 
            this.seLocationZ.BackColor = System.Drawing.SystemColors.Window;
            this.seLocationZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seLocationZ.DecimalPlaces = 3;
            this.seLocationZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seLocationZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seLocationZ.Location = new System.Drawing.Point(272, 31);
            this.seLocationZ.Margin = new System.Windows.Forms.Padding(2);
            this.seLocationZ.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seLocationZ.Name = "seLocationZ";
            this.seLocationZ.Size = new System.Drawing.Size(86, 21);
            this.seLocationZ.TabIndex = 5;
            this.seLocationZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seLocationZ, "Location Z");
            // 
            // seScaleX
            // 
            this.seScaleX.BackColor = System.Drawing.SystemColors.Window;
            this.seScaleX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seScaleX.DecimalPlaces = 3;
            this.seScaleX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seScaleX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seScaleX.Location = new System.Drawing.Point(92, 81);
            this.seScaleX.Margin = new System.Windows.Forms.Padding(2);
            this.seScaleX.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seScaleX.Name = "seScaleX";
            this.seScaleX.Size = new System.Drawing.Size(86, 21);
            this.seScaleX.TabIndex = 11;
            this.seScaleX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seScaleX, "The X component of scale");
            // 
            // seScaleY
            // 
            this.seScaleY.BackColor = System.Drawing.SystemColors.Window;
            this.seScaleY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seScaleY.DecimalPlaces = 3;
            this.seScaleY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seScaleY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seScaleY.Location = new System.Drawing.Point(182, 81);
            this.seScaleY.Margin = new System.Windows.Forms.Padding(2);
            this.seScaleY.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seScaleY.Name = "seScaleY";
            this.seScaleY.Size = new System.Drawing.Size(86, 21);
            this.seScaleY.TabIndex = 12;
            this.seScaleY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seScaleY, "The Y component of scale");
            // 
            // seScaleZ
            // 
            this.seScaleZ.BackColor = System.Drawing.SystemColors.Window;
            this.seScaleZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seScaleZ.DecimalPlaces = 3;
            this.seScaleZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seScaleZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seScaleZ.Location = new System.Drawing.Point(272, 81);
            this.seScaleZ.Margin = new System.Windows.Forms.Padding(2);
            this.seScaleZ.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seScaleZ.Name = "seScaleZ";
            this.seScaleZ.Size = new System.Drawing.Size(86, 21);
            this.seScaleZ.TabIndex = 13;
            this.seScaleZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seScaleZ, "The Z component of scale");
            // 
            // seMinimumX
            // 
            this.seMinimumX.BackColor = System.Drawing.SystemColors.Window;
            this.seMinimumX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seMinimumX.DecimalPlaces = 3;
            this.seMinimumX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seMinimumX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seMinimumX.Location = new System.Drawing.Point(92, 106);
            this.seMinimumX.Margin = new System.Windows.Forms.Padding(2);
            this.seMinimumX.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seMinimumX.Name = "seMinimumX";
            this.seMinimumX.Size = new System.Drawing.Size(86, 21);
            this.seMinimumX.TabIndex = 15;
            this.seMinimumX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seMinimumX, "The minimum value of X");
            // 
            // seMinimumY
            // 
            this.seMinimumY.BackColor = System.Drawing.SystemColors.Window;
            this.seMinimumY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seMinimumY.DecimalPlaces = 3;
            this.seMinimumY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seMinimumY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seMinimumY.Location = new System.Drawing.Point(182, 106);
            this.seMinimumY.Margin = new System.Windows.Forms.Padding(2);
            this.seMinimumY.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seMinimumY.Name = "seMinimumY";
            this.seMinimumY.Size = new System.Drawing.Size(86, 21);
            this.seMinimumY.TabIndex = 16;
            this.seMinimumY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seMinimumY, "The minimum value of Y");
            // 
            // seMinimumZ
            // 
            this.seMinimumZ.BackColor = System.Drawing.SystemColors.Window;
            this.seMinimumZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seMinimumZ.DecimalPlaces = 3;
            this.seMinimumZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seMinimumZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seMinimumZ.Location = new System.Drawing.Point(272, 106);
            this.seMinimumZ.Margin = new System.Windows.Forms.Padding(2);
            this.seMinimumZ.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seMinimumZ.Name = "seMinimumZ";
            this.seMinimumZ.Size = new System.Drawing.Size(86, 21);
            this.seMinimumZ.TabIndex = 17;
            this.seMinimumZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seMinimumZ, "The minimum value of Z");
            // 
            // seMaximumX
            // 
            this.seMaximumX.BackColor = System.Drawing.SystemColors.Window;
            this.seMaximumX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seMaximumX.DecimalPlaces = 3;
            this.seMaximumX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seMaximumX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seMaximumX.Location = new System.Drawing.Point(92, 131);
            this.seMaximumX.Margin = new System.Windows.Forms.Padding(2);
            this.seMaximumX.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seMaximumX.Name = "seMaximumX";
            this.seMaximumX.Size = new System.Drawing.Size(86, 21);
            this.seMaximumX.TabIndex = 19;
            this.seMaximumX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seMaximumX, "The maximum value of X");
            // 
            // seMaximumY
            // 
            this.seMaximumY.BackColor = System.Drawing.SystemColors.Window;
            this.seMaximumY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seMaximumY.DecimalPlaces = 3;
            this.seMaximumY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seMaximumY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seMaximumY.Location = new System.Drawing.Point(182, 131);
            this.seMaximumY.Margin = new System.Windows.Forms.Padding(2);
            this.seMaximumY.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seMaximumY.Name = "seMaximumY";
            this.seMaximumY.Size = new System.Drawing.Size(86, 21);
            this.seMaximumY.TabIndex = 20;
            this.seMaximumY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seMaximumY, "The maximum value of Y");
            // 
            // seMaximumZ
            // 
            this.seMaximumZ.BackColor = System.Drawing.SystemColors.Window;
            this.seMaximumZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seMaximumZ.DecimalPlaces = 3;
            this.seMaximumZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seMaximumZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seMaximumZ.Location = new System.Drawing.Point(272, 131);
            this.seMaximumZ.Margin = new System.Windows.Forms.Padding(2);
            this.seMaximumZ.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seMaximumZ.Name = "seMaximumZ";
            this.seMaximumZ.Size = new System.Drawing.Size(86, 21);
            this.seMaximumZ.TabIndex = 21;
            this.seMaximumZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seMaximumZ, "The maximum value of Z");
            // 
            // seStripCountX
            // 
            this.seStripCountX.BackColor = System.Drawing.SystemColors.Window;
            this.seStripCountX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seStripCountX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seStripCountX.Location = new System.Drawing.Point(92, 156);
            this.seStripCountX.Margin = new System.Windows.Forms.Padding(2);
            this.seStripCountX.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seStripCountX.Name = "seStripCountX";
            this.seStripCountX.Size = new System.Drawing.Size(86, 21);
            this.seStripCountX.TabIndex = 23;
            this.seStripCountX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seStripCountX, "The number of strips in the X direction");
            // 
            // seStripCountY
            // 
            this.seStripCountY.BackColor = System.Drawing.SystemColors.Window;
            this.seStripCountY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seStripCountY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seStripCountY.Location = new System.Drawing.Point(182, 156);
            this.seStripCountY.Margin = new System.Windows.Forms.Padding(2);
            this.seStripCountY.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seStripCountY.Name = "seStripCountY";
            this.seStripCountY.Size = new System.Drawing.Size(86, 21);
            this.seStripCountY.TabIndex = 24;
            this.seStripCountY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seStripCountY, "The number of strips in the Y direction");
            // 
            // seStripCountZ
            // 
            this.seStripCountZ.BackColor = System.Drawing.SystemColors.Window;
            this.seStripCountZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seStripCountZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seStripCountZ.Location = new System.Drawing.Point(272, 156);
            this.seStripCountZ.Margin = new System.Windows.Forms.Padding(2);
            this.seStripCountZ.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seStripCountZ.Name = "seStripCountZ";
            this.seStripCountZ.Size = new System.Drawing.Size(86, 21);
            this.seStripCountZ.TabIndex = 25;
            this.seStripCountZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seStripCountZ, "The number of strips in the Z direction");
            // 
            // cbPattern
            // 
            this.cbPattern.BackColor = System.Drawing.SystemColors.Window;
            this.TableLayoutPanel.SetColumnSpan(this.cbPattern, 2);
            this.cbPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPattern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPattern.FormattingEnabled = true;
            this.cbPattern.Location = new System.Drawing.Point(92, 181);
            this.cbPattern.Margin = new System.Windows.Forms.Padding(2);
            this.cbPattern.Name = "cbPattern";
            this.cbPattern.Size = new System.Drawing.Size(176, 25);
            this.cbPattern.TabIndex = 27;
            this.ToolTip.SetToolTip(this.cbPattern, "The texture of the trace");
            // 
            // cbVisible
            // 
            this.cbVisible.AutoSize = true;
            this.cbVisible.BackColor = System.Drawing.SystemColors.Control;
            this.cbVisible.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbVisible.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbVisible.FlatAppearance.BorderSize = 0;
            this.cbVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbVisible.Location = new System.Drawing.Point(272, 181);
            this.cbVisible.Margin = new System.Windows.Forms.Padding(2);
            this.cbVisible.Name = "cbVisible";
            this.cbVisible.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.cbVisible.Size = new System.Drawing.Size(86, 25);
            this.cbVisible.TabIndex = 28;
            this.cbVisible.Text = "Visible";
            this.cbVisible.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.cbVisible, "Whether or not this trace is visible");
            this.cbVisible.UseVisualStyleBackColor = false;
            // 
            // seLocationX
            // 
            this.seLocationX.BackColor = System.Drawing.SystemColors.Window;
            this.seLocationX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seLocationX.DecimalPlaces = 3;
            this.seLocationX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seLocationX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seLocationX.Location = new System.Drawing.Point(92, 31);
            this.seLocationX.Margin = new System.Windows.Forms.Padding(2);
            this.seLocationX.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seLocationX.Name = "seLocationX";
            this.seLocationX.Size = new System.Drawing.Size(86, 21);
            this.seLocationX.TabIndex = 3;
            this.seLocationX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seLocationX, "Location X");
            // 
            // SelectionToolbar
            // 
            this.TableLayoutPanel.SetColumnSpan(this.SelectionToolbar, 3);
            this.SelectionToolbar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectionToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.SelectionToolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.SelectionToolbar.Location = new System.Drawing.Point(90, 208);
            this.SelectionToolbar.Name = "SelectionToolbar";
            this.SelectionToolbar.Padding = new System.Windows.Forms.Padding(3, 3, 1, 0);
            this.SelectionToolbar.Size = new System.Drawing.Size(270, 23);
            this.SelectionToolbar.TabIndex = 30;
            this.SelectionToolbar.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(22, 17);
            this.toolStripLabel1.Text = "All";
            // 
            // ToolTip
            // 
            this.ToolTip.BackColor = System.Drawing.SystemColors.Window;
            // 
            // sePitch
            // 
            this.sePitch.BackColor = System.Drawing.SystemColors.Window;
            this.sePitch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sePitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sePitch.Location = new System.Drawing.Point(92, 56);
            this.sePitch.Margin = new System.Windows.Forms.Padding(2);
            this.sePitch.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sePitch.Name = "sePitch";
            this.sePitch.Size = new System.Drawing.Size(86, 21);
            this.sePitch.TabIndex = 7;
            this.sePitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.sePitch, "Trace pitch");
            // 
            // seYaw
            // 
            this.seYaw.BackColor = System.Drawing.SystemColors.Window;
            this.seYaw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seYaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seYaw.Location = new System.Drawing.Point(182, 56);
            this.seYaw.Margin = new System.Windows.Forms.Padding(2);
            this.seYaw.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seYaw.Name = "seYaw";
            this.seYaw.Size = new System.Drawing.Size(86, 21);
            this.seYaw.TabIndex = 8;
            this.seYaw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seYaw, "Trace yaw");
            // 
            // seRoll
            // 
            this.seRoll.BackColor = System.Drawing.SystemColors.Window;
            this.seRoll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seRoll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seRoll.Location = new System.Drawing.Point(272, 56);
            this.seRoll.Margin = new System.Windows.Forms.Padding(2);
            this.seRoll.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seRoll.Name = "seRoll";
            this.seRoll.Size = new System.Drawing.Size(86, 21);
            this.seRoll.TabIndex = 9;
            this.seRoll.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seRoll, "Trace roll");
            // 
            // TraceEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.TableLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TraceEdit";
            this.Size = new System.Drawing.Size(360, 246);
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seLocationY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLocationZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seScaleX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seScaleY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seScaleZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMinimumX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMinimumY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMinimumZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMaximumX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMaximumY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMaximumZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStripCountX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStripCountY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStripCountZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLocationX)).EndInit();
            this.SelectionToolbar.ResumeLayout(false);
            this.SelectionToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sePitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seYaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seRoll)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox edDescription;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown seLocationX;
        public System.Windows.Forms.NumericUpDown seLocationY;
        public System.Windows.Forms.NumericUpDown seLocationZ;
        public Jmk.Controls.JmkNumericUpDownDegrees sePitch;
        public Jmk.Controls.JmkNumericUpDownDegrees seYaw;
        public Jmk.Controls.JmkNumericUpDownDegrees seRoll;
        public System.Windows.Forms.NumericUpDown seScaleX;
        public System.Windows.Forms.NumericUpDown seScaleY;
        public System.Windows.Forms.NumericUpDown seScaleZ;
        public System.Windows.Forms.NumericUpDown seMinimumX;
        public System.Windows.Forms.NumericUpDown seMinimumY;
        public System.Windows.Forms.NumericUpDown seMinimumZ;
        public System.Windows.Forms.NumericUpDown seMaximumX;
        public System.Windows.Forms.NumericUpDown seMaximumY;
        public System.Windows.Forms.NumericUpDown seMaximumZ;
        public System.Windows.Forms.NumericUpDown seStripCountX;
        public System.Windows.Forms.NumericUpDown seStripCountY;
        public System.Windows.Forms.NumericUpDown seStripCountZ;
        public System.Windows.Forms.ComboBox cbPattern;
        public System.Windows.Forms.CheckBox cbVisible;
        public System.Windows.Forms.ToolTip ToolTip;
        public System.Windows.Forms.Label lblSelectedTraces;
        public System.Windows.Forms.ToolStrip SelectionToolbar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}
