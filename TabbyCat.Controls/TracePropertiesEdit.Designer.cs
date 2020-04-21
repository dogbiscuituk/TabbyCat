namespace TabbyCat.Controls
{
    partial class TracePropertiesEdit
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
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblStripes = new System.Windows.Forms.CheckBox();
            this.lblMaximum = new System.Windows.Forms.CheckBox();
            this.lblMinimum = new System.Windows.Forms.CheckBox();
            this.lblScale = new System.Windows.Forms.CheckBox();
            this.lblSelectedTraces = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.edDescription = new System.Windows.Forms.TextBox();
            this.lblOrientation = new System.Windows.Forms.Label();
            this.lblPattern = new System.Windows.Forms.Label();
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
            this.seStripeCountX = new System.Windows.Forms.NumericUpDown();
            this.seStripeCountY = new System.Windows.Forms.NumericUpDown();
            this.seStripeCountZ = new System.Windows.Forms.NumericUpDown();
            this.cbPattern = new System.Windows.Forms.ComboBox();
            this.cbVisible = new System.Windows.Forms.CheckBox();
            this.seLocationX = new System.Windows.Forms.NumericUpDown();
            this.SelectionToolbar = new System.Windows.Forms.ToolStrip();
            this.lblAll = new System.Windows.Forms.ToolStripLabel();
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
            ((System.ComponentModel.ISupportInitialize)(this.seStripeCountX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStripeCountY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStripeCountZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLocationX)).BeginInit();
            this.SelectionToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sePitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seYaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seRoll)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.AutoSize = true;
            this.TableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.TableLayoutPanel.ColumnCount = 4;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.Controls.Add(this.lblStripes, 0, 6);
            this.TableLayoutPanel.Controls.Add(this.lblMaximum, 0, 5);
            this.TableLayoutPanel.Controls.Add(this.lblMinimum, 0, 4);
            this.TableLayoutPanel.Controls.Add(this.lblScale, 0, 3);
            this.TableLayoutPanel.Controls.Add(this.lblSelectedTraces, 0, 8);
            this.TableLayoutPanel.Controls.Add(this.lblLocation, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.lblDescription, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.edDescription, 1, 0);
            this.TableLayoutPanel.Controls.Add(this.lblOrientation, 0, 2);
            this.TableLayoutPanel.Controls.Add(this.lblPattern, 0, 7);
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
            this.TableLayoutPanel.Controls.Add(this.seStripeCountX, 1, 6);
            this.TableLayoutPanel.Controls.Add(this.seStripeCountY, 2, 6);
            this.TableLayoutPanel.Controls.Add(this.seStripeCountZ, 3, 6);
            this.TableLayoutPanel.Controls.Add(this.cbPattern, 1, 7);
            this.TableLayoutPanel.Controls.Add(this.cbVisible, 3, 7);
            this.TableLayoutPanel.Controls.Add(this.seLocationX, 1, 1);
            this.TableLayoutPanel.Controls.Add(this.SelectionToolbar, 1, 8);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableLayoutPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
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
            this.TableLayoutPanel.Size = new System.Drawing.Size(352, 189);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // lblStripes
            // 
            this.lblStripes.AutoSize = true;
            this.lblStripes.BackColor = System.Drawing.SystemColors.Control;
            this.lblStripes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblStripes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStripes.FlatAppearance.BorderSize = 0;
            this.lblStripes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStripes.Location = new System.Drawing.Point(0, 130);
            this.lblStripes.Margin = new System.Windows.Forms.Padding(0);
            this.lblStripes.Name = "lblStripes";
            this.lblStripes.Size = new System.Drawing.Size(88, 21);
            this.lblStripes.TabIndex = 34;
            this.lblStripes.Text = "#Stripes";
            this.lblStripes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblStripes.UseVisualStyleBackColor = false;
            // 
            // lblMaximum
            // 
            this.lblMaximum.AutoSize = true;
            this.lblMaximum.BackColor = System.Drawing.SystemColors.Control;
            this.lblMaximum.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMaximum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaximum.FlatAppearance.BorderSize = 0;
            this.lblMaximum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMaximum.Location = new System.Drawing.Point(0, 109);
            this.lblMaximum.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaximum.Name = "lblMaximum";
            this.lblMaximum.Size = new System.Drawing.Size(88, 21);
            this.lblMaximum.TabIndex = 33;
            this.lblMaximum.Text = "Maximum";
            this.lblMaximum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMaximum.UseVisualStyleBackColor = false;
            // 
            // lblMinimum
            // 
            this.lblMinimum.AutoSize = true;
            this.lblMinimum.BackColor = System.Drawing.SystemColors.Control;
            this.lblMinimum.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMinimum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinimum.FlatAppearance.BorderSize = 0;
            this.lblMinimum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMinimum.Location = new System.Drawing.Point(0, 88);
            this.lblMinimum.Margin = new System.Windows.Forms.Padding(0);
            this.lblMinimum.Name = "lblMinimum";
            this.lblMinimum.Size = new System.Drawing.Size(88, 21);
            this.lblMinimum.TabIndex = 32;
            this.lblMinimum.Text = "Minimum";
            this.lblMinimum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMinimum.UseVisualStyleBackColor = false;
            // 
            // lblScale
            // 
            this.lblScale.AutoSize = true;
            this.lblScale.BackColor = System.Drawing.SystemColors.Control;
            this.lblScale.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScale.FlatAppearance.BorderSize = 0;
            this.lblScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblScale.Location = new System.Drawing.Point(0, 67);
            this.lblScale.Margin = new System.Windows.Forms.Padding(0);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(88, 21);
            this.lblScale.TabIndex = 31;
            this.lblScale.Text = "Scale";
            this.lblScale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblScale.UseVisualStyleBackColor = false;
            // 
            // lblSelectedTraces
            // 
            this.lblSelectedTraces.AutoSize = true;
            this.lblSelectedTraces.BackColor = System.Drawing.SystemColors.Control;
            this.lblSelectedTraces.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSelectedTraces.Location = new System.Drawing.Point(0, 172);
            this.lblSelectedTraces.Margin = new System.Windows.Forms.Padding(0);
            this.lblSelectedTraces.Name = "lblSelectedTraces";
            this.lblSelectedTraces.Size = new System.Drawing.Size(88, 17);
            this.lblSelectedTraces.TabIndex = 29;
            this.lblSelectedTraces.Text = "Selection";
            this.lblSelectedTraces.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.BackColor = System.Drawing.SystemColors.Control;
            this.lblLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLocation.Location = new System.Drawing.Point(0, 25);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(88, 21);
            this.lblLocation.TabIndex = 2;
            this.lblLocation.Text = "Location";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.SystemColors.Control;
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescription.Location = new System.Drawing.Point(0, 0);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(88, 25);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edDescription
            // 
            this.edDescription.BackColor = System.Drawing.SystemColors.Window;
            this.edDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TableLayoutPanel.SetColumnSpan(this.edDescription, 3);
            this.edDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edDescription.Location = new System.Drawing.Point(88, 0);
            this.edDescription.Margin = new System.Windows.Forms.Padding(0);
            this.edDescription.Name = "edDescription";
            this.edDescription.Size = new System.Drawing.Size(264, 25);
            this.edDescription.TabIndex = 1;
            // 
            // lblOrientation
            // 
            this.lblOrientation.AutoSize = true;
            this.lblOrientation.BackColor = System.Drawing.SystemColors.Control;
            this.lblOrientation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrientation.Location = new System.Drawing.Point(0, 46);
            this.lblOrientation.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrientation.Name = "lblOrientation";
            this.lblOrientation.Size = new System.Drawing.Size(88, 21);
            this.lblOrientation.TabIndex = 6;
            this.lblOrientation.Text = "Orientation";
            this.lblOrientation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPattern
            // 
            this.lblPattern.AutoSize = true;
            this.lblPattern.BackColor = System.Drawing.SystemColors.Control;
            this.lblPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPattern.Location = new System.Drawing.Point(0, 151);
            this.lblPattern.Margin = new System.Windows.Forms.Padding(0);
            this.lblPattern.Name = "lblPattern";
            this.lblPattern.Size = new System.Drawing.Size(88, 21);
            this.lblPattern.TabIndex = 26;
            this.lblPattern.Text = "Pattern";
            this.lblPattern.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.seLocationY.Location = new System.Drawing.Point(176, 25);
            this.seLocationY.Margin = new System.Windows.Forms.Padding(0);
            this.seLocationY.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seLocationY.Name = "seLocationY";
            this.seLocationY.Size = new System.Drawing.Size(88, 21);
            this.seLocationY.TabIndex = 4;
            this.seLocationY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.seLocationZ.Location = new System.Drawing.Point(264, 25);
            this.seLocationZ.Margin = new System.Windows.Forms.Padding(0);
            this.seLocationZ.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seLocationZ.Name = "seLocationZ";
            this.seLocationZ.Size = new System.Drawing.Size(88, 21);
            this.seLocationZ.TabIndex = 5;
            this.seLocationZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.seScaleX.Location = new System.Drawing.Point(88, 67);
            this.seScaleX.Margin = new System.Windows.Forms.Padding(0);
            this.seScaleX.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seScaleX.Name = "seScaleX";
            this.seScaleX.Size = new System.Drawing.Size(88, 21);
            this.seScaleX.TabIndex = 11;
            this.seScaleX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.seScaleY.Location = new System.Drawing.Point(176, 67);
            this.seScaleY.Margin = new System.Windows.Forms.Padding(0);
            this.seScaleY.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seScaleY.Name = "seScaleY";
            this.seScaleY.Size = new System.Drawing.Size(88, 21);
            this.seScaleY.TabIndex = 12;
            this.seScaleY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.seScaleZ.Location = new System.Drawing.Point(264, 67);
            this.seScaleZ.Margin = new System.Windows.Forms.Padding(0);
            this.seScaleZ.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seScaleZ.Name = "seScaleZ";
            this.seScaleZ.Size = new System.Drawing.Size(88, 21);
            this.seScaleZ.TabIndex = 13;
            this.seScaleZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.seMinimumX.Location = new System.Drawing.Point(88, 88);
            this.seMinimumX.Margin = new System.Windows.Forms.Padding(0);
            this.seMinimumX.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seMinimumX.Name = "seMinimumX";
            this.seMinimumX.Size = new System.Drawing.Size(88, 21);
            this.seMinimumX.TabIndex = 15;
            this.seMinimumX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.seMinimumY.Location = new System.Drawing.Point(176, 88);
            this.seMinimumY.Margin = new System.Windows.Forms.Padding(0);
            this.seMinimumY.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seMinimumY.Name = "seMinimumY";
            this.seMinimumY.Size = new System.Drawing.Size(88, 21);
            this.seMinimumY.TabIndex = 16;
            this.seMinimumY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.seMinimumZ.Location = new System.Drawing.Point(264, 88);
            this.seMinimumZ.Margin = new System.Windows.Forms.Padding(0);
            this.seMinimumZ.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seMinimumZ.Name = "seMinimumZ";
            this.seMinimumZ.Size = new System.Drawing.Size(88, 21);
            this.seMinimumZ.TabIndex = 17;
            this.seMinimumZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.seMaximumX.Location = new System.Drawing.Point(88, 109);
            this.seMaximumX.Margin = new System.Windows.Forms.Padding(0);
            this.seMaximumX.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seMaximumX.Name = "seMaximumX";
            this.seMaximumX.Size = new System.Drawing.Size(88, 21);
            this.seMaximumX.TabIndex = 19;
            this.seMaximumX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.seMaximumY.Location = new System.Drawing.Point(176, 109);
            this.seMaximumY.Margin = new System.Windows.Forms.Padding(0);
            this.seMaximumY.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seMaximumY.Name = "seMaximumY";
            this.seMaximumY.Size = new System.Drawing.Size(88, 21);
            this.seMaximumY.TabIndex = 20;
            this.seMaximumY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.seMaximumZ.Location = new System.Drawing.Point(264, 109);
            this.seMaximumZ.Margin = new System.Windows.Forms.Padding(0);
            this.seMaximumZ.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seMaximumZ.Name = "seMaximumZ";
            this.seMaximumZ.Size = new System.Drawing.Size(88, 21);
            this.seMaximumZ.TabIndex = 21;
            this.seMaximumZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seStripeCountX
            // 
            this.seStripeCountX.BackColor = System.Drawing.SystemColors.Window;
            this.seStripeCountX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seStripeCountX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seStripeCountX.Location = new System.Drawing.Point(88, 130);
            this.seStripeCountX.Margin = new System.Windows.Forms.Padding(0);
            this.seStripeCountX.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seStripeCountX.Name = "seStripeCountX";
            this.seStripeCountX.Size = new System.Drawing.Size(88, 21);
            this.seStripeCountX.TabIndex = 23;
            this.seStripeCountX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seStripeCountY
            // 
            this.seStripeCountY.BackColor = System.Drawing.SystemColors.Window;
            this.seStripeCountY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seStripeCountY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seStripeCountY.Location = new System.Drawing.Point(176, 130);
            this.seStripeCountY.Margin = new System.Windows.Forms.Padding(0);
            this.seStripeCountY.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seStripeCountY.Name = "seStripeCountY";
            this.seStripeCountY.Size = new System.Drawing.Size(88, 21);
            this.seStripeCountY.TabIndex = 24;
            this.seStripeCountY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seStripeCountZ
            // 
            this.seStripeCountZ.BackColor = System.Drawing.SystemColors.Window;
            this.seStripeCountZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seStripeCountZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seStripeCountZ.Location = new System.Drawing.Point(264, 130);
            this.seStripeCountZ.Margin = new System.Windows.Forms.Padding(0);
            this.seStripeCountZ.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seStripeCountZ.Name = "seStripeCountZ";
            this.seStripeCountZ.Size = new System.Drawing.Size(88, 21);
            this.seStripeCountZ.TabIndex = 25;
            this.seStripeCountZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbPattern
            // 
            this.cbPattern.BackColor = System.Drawing.SystemColors.Window;
            this.TableLayoutPanel.SetColumnSpan(this.cbPattern, 2);
            this.cbPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbPattern.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPattern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPattern.FormattingEnabled = true;
            this.cbPattern.ItemHeight = 16;
            this.cbPattern.Location = new System.Drawing.Point(88, 151);
            this.cbPattern.Margin = new System.Windows.Forms.Padding(0);
            this.cbPattern.Name = "cbPattern";
            this.cbPattern.Size = new System.Drawing.Size(176, 22);
            this.cbPattern.TabIndex = 27;
            // 
            // cbVisible
            // 
            this.cbVisible.AutoSize = true;
            this.cbVisible.BackColor = System.Drawing.SystemColors.Control;
            this.cbVisible.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbVisible.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbVisible.FlatAppearance.BorderSize = 0;
            this.cbVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbVisible.Location = new System.Drawing.Point(264, 151);
            this.cbVisible.Margin = new System.Windows.Forms.Padding(0);
            this.cbVisible.Name = "cbVisible";
            this.cbVisible.Size = new System.Drawing.Size(88, 21);
            this.cbVisible.TabIndex = 28;
            this.cbVisible.Text = "Visible?";
            this.cbVisible.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.seLocationX.Location = new System.Drawing.Point(88, 25);
            this.seLocationX.Margin = new System.Windows.Forms.Padding(0);
            this.seLocationX.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seLocationX.Name = "seLocationX";
            this.seLocationX.Size = new System.Drawing.Size(88, 21);
            this.seLocationX.TabIndex = 3;
            this.seLocationX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SelectionToolbar
            // 
            this.TableLayoutPanel.SetColumnSpan(this.SelectionToolbar, 3);
            this.SelectionToolbar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectionToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblAll});
            this.SelectionToolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.SelectionToolbar.Location = new System.Drawing.Point(88, 172);
            this.SelectionToolbar.Name = "SelectionToolbar";
            this.SelectionToolbar.Padding = new System.Windows.Forms.Padding(0);
            this.SelectionToolbar.Size = new System.Drawing.Size(264, 17);
            this.SelectionToolbar.TabIndex = 30;
            this.SelectionToolbar.Text = "toolStrip1";
            // 
            // lblAll
            // 
            this.lblAll.Margin = new System.Windows.Forms.Padding(0);
            this.lblAll.Name = "lblAll";
            this.lblAll.Size = new System.Drawing.Size(22, 17);
            this.lblAll.Text = "All";
            this.lblAll.ToolTipText = "Select or deselect all traces";
            // 
            // sePitch
            // 
            this.sePitch.BackColor = System.Drawing.SystemColors.Window;
            this.sePitch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sePitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sePitch.Location = new System.Drawing.Point(88, 46);
            this.sePitch.Margin = new System.Windows.Forms.Padding(0);
            this.sePitch.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sePitch.Name = "sePitch";
            this.sePitch.Size = new System.Drawing.Size(88, 21);
            this.sePitch.TabIndex = 7;
            this.sePitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seYaw
            // 
            this.seYaw.BackColor = System.Drawing.SystemColors.Window;
            this.seYaw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seYaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seYaw.Location = new System.Drawing.Point(176, 46);
            this.seYaw.Margin = new System.Windows.Forms.Padding(0);
            this.seYaw.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seYaw.Name = "seYaw";
            this.seYaw.Size = new System.Drawing.Size(88, 21);
            this.seYaw.TabIndex = 8;
            this.seYaw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seRoll
            // 
            this.seRoll.BackColor = System.Drawing.SystemColors.Window;
            this.seRoll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seRoll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seRoll.Location = new System.Drawing.Point(264, 46);
            this.seRoll.Margin = new System.Windows.Forms.Padding(0);
            this.seRoll.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seRoll.Name = "seRoll";
            this.seRoll.Size = new System.Drawing.Size(88, 21);
            this.seRoll.TabIndex = 9;
            this.seRoll.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TracePropertiesEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.TableLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TracePropertiesEdit";
            this.Size = new System.Drawing.Size(352, 195);
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
            ((System.ComponentModel.ISupportInitialize)(this.seStripeCountX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStripeCountY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStripeCountZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLocationX)).EndInit();
            this.SelectionToolbar.ResumeLayout(false);
            this.SelectionToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sePitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seYaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seRoll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        public System.Windows.Forms.Label lblDescription;
        public System.Windows.Forms.TextBox edDescription;
        public System.Windows.Forms.Label lblLocation;
        public System.Windows.Forms.Label lblOrientation;
        public System.Windows.Forms.Label lblPattern;
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
        public System.Windows.Forms.NumericUpDown seStripeCountX;
        public System.Windows.Forms.NumericUpDown seStripeCountY;
        public System.Windows.Forms.NumericUpDown seStripeCountZ;
        public System.Windows.Forms.ComboBox cbPattern;
        public System.Windows.Forms.CheckBox cbVisible;
        public System.Windows.Forms.Label lblSelectedTraces;
        public System.Windows.Forms.ToolStrip SelectionToolbar;
        public System.Windows.Forms.ToolStripLabel lblAll;
        public System.Windows.Forms.CheckBox lblScale;
        public System.Windows.Forms.CheckBox lblMinimum;
        public System.Windows.Forms.CheckBox lblMaximum;
        public System.Windows.Forms.CheckBox lblStripes;
    }
}
