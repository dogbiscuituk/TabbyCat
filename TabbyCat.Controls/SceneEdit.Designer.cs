namespace TabbyCat.Controls
{
    partial class SceneEdit
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
            this.cbStereo = new System.Windows.Forms.CheckBox();
            this.seCameraPositionX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.edTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFieldOfView = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.seFieldOfView = new Jmk.Controls.JmkNumericUpDownDegrees();
            this.seCameraPositionY = new System.Windows.Forms.NumericUpDown();
            this.seCameraPositionZ = new System.Windows.Forms.NumericUpDown();
            this.seCameraPitch = new Jmk.Controls.JmkNumericUpDownDegrees();
            this.seCameraYaw = new Jmk.Controls.JmkNumericUpDownDegrees();
            this.seCameraRoll = new Jmk.Controls.JmkNumericUpDownDegrees();
            this.seFrustumMinX = new System.Windows.Forms.NumericUpDown();
            this.seFrustumMinY = new System.Windows.Forms.NumericUpDown();
            this.seFrustumMinZ = new System.Windows.Forms.NumericUpDown();
            this.seFrustumMaxX = new System.Windows.Forms.NumericUpDown();
            this.seFrustumMaxY = new System.Windows.Forms.NumericUpDown();
            this.seFrustumMaxZ = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.seFPS = new System.Windows.Forms.NumericUpDown();
            this.cbVSync = new System.Windows.Forms.CheckBox();
            this.cbBackground = new System.Windows.Forms.ComboBox();
            this.seProjectionType = new System.Windows.Forms.DomainUpDown();
            this.seGLSLVersion = new System.Windows.Forms.DomainUpDown();
            this.seSampleCount = new System.Windows.Forms.DomainUpDown();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.TableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraPositionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFieldOfView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraPositionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraPositionZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraYaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraRoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMinX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMinY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMinZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMaxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMaxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMaxZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFPS)).BeginInit();
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
            this.TableLayoutPanel.Controls.Add(this.cbStereo, 3, 3);
            this.TableLayoutPanel.Controls.Add(this.seCameraPositionX, 1, 1);
            this.TableLayoutPanel.Controls.Add(this.label2, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.edTitle, 1, 0);
            this.TableLayoutPanel.Controls.Add(this.label3, 0, 2);
            this.TableLayoutPanel.Controls.Add(this.label4, 0, 3);
            this.TableLayoutPanel.Controls.Add(this.lblFieldOfView, 0, 4);
            this.TableLayoutPanel.Controls.Add(this.label6, 0, 5);
            this.TableLayoutPanel.Controls.Add(this.label7, 0, 6);
            this.TableLayoutPanel.Controls.Add(this.seFieldOfView, 1, 4);
            this.TableLayoutPanel.Controls.Add(this.seCameraPositionY, 2, 1);
            this.TableLayoutPanel.Controls.Add(this.seCameraPositionZ, 3, 1);
            this.TableLayoutPanel.Controls.Add(this.seCameraPitch, 1, 2);
            this.TableLayoutPanel.Controls.Add(this.seCameraYaw, 2, 2);
            this.TableLayoutPanel.Controls.Add(this.seCameraRoll, 3, 2);
            this.TableLayoutPanel.Controls.Add(this.seFrustumMinX, 1, 5);
            this.TableLayoutPanel.Controls.Add(this.seFrustumMinY, 2, 5);
            this.TableLayoutPanel.Controls.Add(this.seFrustumMinZ, 3, 5);
            this.TableLayoutPanel.Controls.Add(this.seFrustumMaxX, 1, 6);
            this.TableLayoutPanel.Controls.Add(this.seFrustumMaxY, 2, 6);
            this.TableLayoutPanel.Controls.Add(this.seFrustumMaxZ, 3, 6);
            this.TableLayoutPanel.Controls.Add(this.label8, 0, 8);
            this.TableLayoutPanel.Controls.Add(this.label9, 2, 4);
            this.TableLayoutPanel.Controls.Add(this.label10, 0, 7);
            this.TableLayoutPanel.Controls.Add(this.label12, 2, 7);
            this.TableLayoutPanel.Controls.Add(this.seFPS, 3, 4);
            this.TableLayoutPanel.Controls.Add(this.cbVSync, 3, 8);
            this.TableLayoutPanel.Controls.Add(this.cbBackground, 1, 8);
            this.TableLayoutPanel.Controls.Add(this.seProjectionType, 1, 3);
            this.TableLayoutPanel.Controls.Add(this.seGLSLVersion, 3, 7);
            this.TableLayoutPanel.Controls.Add(this.seSampleCount, 1, 7);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.TableLayoutPanel.Size = new System.Drawing.Size(360, 237);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // cbStereo
            // 
            this.cbStereo.AutoSize = true;
            this.cbStereo.BackColor = System.Drawing.SystemColors.Control;
            this.cbStereo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbStereo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbStereo.FlatAppearance.BorderSize = 0;
            this.cbStereo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbStereo.Location = new System.Drawing.Point(272, 81);
            this.cbStereo.Margin = new System.Windows.Forms.Padding(2);
            this.cbStereo.Name = "cbStereo";
            this.cbStereo.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.cbStereo.Size = new System.Drawing.Size(86, 21);
            this.cbStereo.TabIndex = 12;
            this.cbStereo.Text = "Stereo";
            this.cbStereo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.cbStereo, "Whether or not the current display mode is stereoscopic");
            this.cbStereo.UseVisualStyleBackColor = false;
            // 
            // seCameraPositionX
            // 
            this.seCameraPositionX.BackColor = System.Drawing.SystemColors.Window;
            this.seCameraPositionX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seCameraPositionX.DecimalPlaces = 3;
            this.seCameraPositionX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seCameraPositionX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seCameraPositionX.Location = new System.Drawing.Point(92, 31);
            this.seCameraPositionX.Margin = new System.Windows.Forms.Padding(2);
            this.seCameraPositionX.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seCameraPositionX.Name = "seCameraPositionX";
            this.seCameraPositionX.Size = new System.Drawing.Size(86, 21);
            this.seCameraPositionX.TabIndex = 3;
            this.seCameraPositionX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seCameraPositionX, "Camera X");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Position";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.label2, "Camera position");
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
            this.label1.Text = "Scene title";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.label1, "The title of this scene");
            // 
            // edTitle
            // 
            this.edTitle.BackColor = System.Drawing.SystemColors.Window;
            this.edTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TableLayoutPanel.SetColumnSpan(this.edTitle, 3);
            this.edTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edTitle.Location = new System.Drawing.Point(92, 2);
            this.edTitle.Margin = new System.Windows.Forms.Padding(2);
            this.edTitle.Name = "edTitle";
            this.edTitle.Size = new System.Drawing.Size(266, 25);
            this.edTitle.TabIndex = 1;
            this.ToolTip.SetToolTip(this.edTitle, "The title of this scene");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 54);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label3.Size = new System.Drawing.Size(84, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Direction";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.label3, "Camera direction");
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
            this.label4.Text = "Projection";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.label4, "Scene projection type");
            // 
            // lblFieldOfView
            // 
            this.lblFieldOfView.AutoSize = true;
            this.lblFieldOfView.BackColor = System.Drawing.SystemColors.Control;
            this.lblFieldOfView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFieldOfView.Location = new System.Drawing.Point(3, 104);
            this.lblFieldOfView.Name = "lblFieldOfView";
            this.lblFieldOfView.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblFieldOfView.Size = new System.Drawing.Size(84, 25);
            this.lblFieldOfView.TabIndex = 13;
            this.lblFieldOfView.Text = "Field of view";
            this.lblFieldOfView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.lblFieldOfView, "The perspective field of view angle (degrees)");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 129);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label6.Size = new System.Drawing.Size(84, 25);
            this.label6.TabIndex = 17;
            this.label6.Text = "Near plane";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 154);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label7.Size = new System.Drawing.Size(84, 25);
            this.label7.TabIndex = 21;
            this.label7.Text = "Far plane";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // seFieldOfView
            // 
            this.seFieldOfView.BackColor = System.Drawing.SystemColors.Window;
            this.seFieldOfView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seFieldOfView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seFieldOfView.Location = new System.Drawing.Point(92, 106);
            this.seFieldOfView.Margin = new System.Windows.Forms.Padding(2);
            this.seFieldOfView.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFieldOfView.Name = "seFieldOfView";
            this.seFieldOfView.Size = new System.Drawing.Size(86, 21);
            this.seFieldOfView.TabIndex = 14;
            this.seFieldOfView.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seFieldOfView, "The perspective field of view angle (degrees)");
            // 
            // seCameraPositionY
            // 
            this.seCameraPositionY.BackColor = System.Drawing.SystemColors.Window;
            this.seCameraPositionY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seCameraPositionY.DecimalPlaces = 3;
            this.seCameraPositionY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seCameraPositionY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seCameraPositionY.Location = new System.Drawing.Point(182, 31);
            this.seCameraPositionY.Margin = new System.Windows.Forms.Padding(2);
            this.seCameraPositionY.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seCameraPositionY.Name = "seCameraPositionY";
            this.seCameraPositionY.Size = new System.Drawing.Size(86, 21);
            this.seCameraPositionY.TabIndex = 4;
            this.seCameraPositionY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seCameraPositionY, "Camera Y");
            // 
            // seCameraPositionZ
            // 
            this.seCameraPositionZ.BackColor = System.Drawing.SystemColors.Window;
            this.seCameraPositionZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seCameraPositionZ.DecimalPlaces = 3;
            this.seCameraPositionZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seCameraPositionZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seCameraPositionZ.Location = new System.Drawing.Point(272, 31);
            this.seCameraPositionZ.Margin = new System.Windows.Forms.Padding(2);
            this.seCameraPositionZ.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seCameraPositionZ.Name = "seCameraPositionZ";
            this.seCameraPositionZ.Size = new System.Drawing.Size(86, 21);
            this.seCameraPositionZ.TabIndex = 5;
            this.seCameraPositionZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seCameraPositionZ, "Camera Z");
            // 
            // seCameraPitch
            // 
            this.seCameraPitch.BackColor = System.Drawing.SystemColors.Window;
            this.seCameraPitch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seCameraPitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seCameraPitch.Location = new System.Drawing.Point(92, 56);
            this.seCameraPitch.Margin = new System.Windows.Forms.Padding(2);
            this.seCameraPitch.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seCameraPitch.Name = "seCameraPitch";
            this.seCameraPitch.Size = new System.Drawing.Size(86, 21);
            this.seCameraPitch.TabIndex = 7;
            this.seCameraPitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seCameraPitch, "Camera pitch");
            // 
            // seCameraYaw
            // 
            this.seCameraYaw.BackColor = System.Drawing.SystemColors.Window;
            this.seCameraYaw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seCameraYaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seCameraYaw.Location = new System.Drawing.Point(182, 56);
            this.seCameraYaw.Margin = new System.Windows.Forms.Padding(2);
            this.seCameraYaw.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seCameraYaw.Name = "seCameraYaw";
            this.seCameraYaw.Size = new System.Drawing.Size(86, 21);
            this.seCameraYaw.TabIndex = 8;
            this.seCameraYaw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seCameraYaw, "Camera Yaw");
            // 
            // seCameraRoll
            // 
            this.seCameraRoll.BackColor = System.Drawing.SystemColors.Window;
            this.seCameraRoll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seCameraRoll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seCameraRoll.Location = new System.Drawing.Point(272, 56);
            this.seCameraRoll.Margin = new System.Windows.Forms.Padding(2);
            this.seCameraRoll.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seCameraRoll.Name = "seCameraRoll";
            this.seCameraRoll.Size = new System.Drawing.Size(86, 21);
            this.seCameraRoll.TabIndex = 9;
            this.seCameraRoll.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seCameraRoll, "Camera Roll");
            // 
            // seFrustumMinX
            // 
            this.seFrustumMinX.BackColor = System.Drawing.SystemColors.Window;
            this.seFrustumMinX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seFrustumMinX.DecimalPlaces = 3;
            this.seFrustumMinX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seFrustumMinX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seFrustumMinX.Location = new System.Drawing.Point(92, 131);
            this.seFrustumMinX.Margin = new System.Windows.Forms.Padding(2);
            this.seFrustumMinX.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFrustumMinX.Name = "seFrustumMinX";
            this.seFrustumMinX.Size = new System.Drawing.Size(86, 21);
            this.seFrustumMinX.TabIndex = 18;
            this.seFrustumMinX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seFrustumMinX, "The X component of the projection near plane");
            // 
            // seFrustumMinY
            // 
            this.seFrustumMinY.BackColor = System.Drawing.SystemColors.Window;
            this.seFrustumMinY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seFrustumMinY.DecimalPlaces = 3;
            this.seFrustumMinY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seFrustumMinY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seFrustumMinY.Location = new System.Drawing.Point(182, 131);
            this.seFrustumMinY.Margin = new System.Windows.Forms.Padding(2);
            this.seFrustumMinY.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFrustumMinY.Name = "seFrustumMinY";
            this.seFrustumMinY.Size = new System.Drawing.Size(86, 21);
            this.seFrustumMinY.TabIndex = 19;
            this.seFrustumMinY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seFrustumMinY, "The Y component of the projection near plane");
            // 
            // seFrustumMinZ
            // 
            this.seFrustumMinZ.BackColor = System.Drawing.SystemColors.Window;
            this.seFrustumMinZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seFrustumMinZ.DecimalPlaces = 3;
            this.seFrustumMinZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seFrustumMinZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seFrustumMinZ.Location = new System.Drawing.Point(272, 131);
            this.seFrustumMinZ.Margin = new System.Windows.Forms.Padding(2);
            this.seFrustumMinZ.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFrustumMinZ.Name = "seFrustumMinZ";
            this.seFrustumMinZ.Size = new System.Drawing.Size(86, 21);
            this.seFrustumMinZ.TabIndex = 20;
            this.seFrustumMinZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seFrustumMinZ, "The Z component of the projection near plane");
            // 
            // seFrustumMaxX
            // 
            this.seFrustumMaxX.BackColor = System.Drawing.SystemColors.Window;
            this.seFrustumMaxX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seFrustumMaxX.DecimalPlaces = 3;
            this.seFrustumMaxX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seFrustumMaxX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seFrustumMaxX.Location = new System.Drawing.Point(92, 156);
            this.seFrustumMaxX.Margin = new System.Windows.Forms.Padding(2);
            this.seFrustumMaxX.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFrustumMaxX.Name = "seFrustumMaxX";
            this.seFrustumMaxX.Size = new System.Drawing.Size(86, 21);
            this.seFrustumMaxX.TabIndex = 22;
            this.seFrustumMaxX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seFrustumMaxX, "The X component of the projection far plane");
            // 
            // seFrustumMaxY
            // 
            this.seFrustumMaxY.BackColor = System.Drawing.SystemColors.Window;
            this.seFrustumMaxY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seFrustumMaxY.DecimalPlaces = 3;
            this.seFrustumMaxY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seFrustumMaxY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seFrustumMaxY.Location = new System.Drawing.Point(182, 156);
            this.seFrustumMaxY.Margin = new System.Windows.Forms.Padding(2);
            this.seFrustumMaxY.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFrustumMaxY.Name = "seFrustumMaxY";
            this.seFrustumMaxY.Size = new System.Drawing.Size(86, 21);
            this.seFrustumMaxY.TabIndex = 23;
            this.seFrustumMaxY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seFrustumMaxY, "The Y component of the projection far plane");
            // 
            // seFrustumMaxZ
            // 
            this.seFrustumMaxZ.BackColor = System.Drawing.SystemColors.Window;
            this.seFrustumMaxZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seFrustumMaxZ.DecimalPlaces = 3;
            this.seFrustumMaxZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seFrustumMaxZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seFrustumMaxZ.Location = new System.Drawing.Point(272, 156);
            this.seFrustumMaxZ.Margin = new System.Windows.Forms.Padding(2);
            this.seFrustumMaxZ.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFrustumMaxZ.Name = "seFrustumMaxZ";
            this.seFrustumMaxZ.Size = new System.Drawing.Size(86, 21);
            this.seFrustumMaxZ.TabIndex = 24;
            this.seFrustumMaxZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seFrustumMaxZ, "The Z component of the projection far plane");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 204);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label8.Size = new System.Drawing.Size(84, 30);
            this.label8.TabIndex = 29;
            this.label8.Text = "Background";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.label8, "The colour of the scene background");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(183, 104);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label9.Size = new System.Drawing.Size(84, 25);
            this.label9.TabIndex = 15;
            this.label9.Text = "Target FPS";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.label9, "The target number of frames per second");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 179);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label10.Size = new System.Drawing.Size(84, 25);
            this.label10.TabIndex = 25;
            this.label10.Text = "#Samples";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.label10, "The number of samples interpolated over");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(183, 179);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label12.Size = new System.Drawing.Size(84, 25);
            this.label12.TabIndex = 27;
            this.label12.Text = "GL version";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.label12, "The Shader Language version targeted by this code");
            // 
            // seFPS
            // 
            this.seFPS.BackColor = System.Drawing.SystemColors.Window;
            this.seFPS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seFPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seFPS.Location = new System.Drawing.Point(272, 106);
            this.seFPS.Margin = new System.Windows.Forms.Padding(2);
            this.seFPS.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFPS.Name = "seFPS";
            this.seFPS.Size = new System.Drawing.Size(86, 21);
            this.seFPS.TabIndex = 16;
            this.seFPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seFPS, "The target number of frames per second");
            // 
            // cbVSync
            // 
            this.cbVSync.AutoSize = true;
            this.cbVSync.BackColor = System.Drawing.SystemColors.Control;
            this.cbVSync.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbVSync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbVSync.FlatAppearance.BorderSize = 0;
            this.cbVSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbVSync.Location = new System.Drawing.Point(272, 206);
            this.cbVSync.Margin = new System.Windows.Forms.Padding(2);
            this.cbVSync.Name = "cbVSync";
            this.cbVSync.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.cbVSync.Size = new System.Drawing.Size(86, 26);
            this.cbVSync.TabIndex = 31;
            this.cbVSync.Text = "VSync";
            this.cbVSync.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.cbVSync, "Whether or not to apply vertical sync");
            this.cbVSync.UseVisualStyleBackColor = false;
            // 
            // cbBackground
            // 
            this.cbBackground.BackColor = System.Drawing.SystemColors.Window;
            this.TableLayoutPanel.SetColumnSpan(this.cbBackground, 2);
            this.cbBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbBackground.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBackground.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBackground.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBackground.FormattingEnabled = true;
            this.cbBackground.Location = new System.Drawing.Point(92, 206);
            this.cbBackground.Margin = new System.Windows.Forms.Padding(2);
            this.cbBackground.Name = "cbBackground";
            this.cbBackground.Size = new System.Drawing.Size(176, 26);
            this.cbBackground.TabIndex = 30;
            this.ToolTip.SetToolTip(this.cbBackground, "The colour of the scene background");
            // 
            // seProjectionType
            // 
            this.seProjectionType.BackColor = System.Drawing.SystemColors.Window;
            this.seProjectionType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TableLayoutPanel.SetColumnSpan(this.seProjectionType, 2);
            this.seProjectionType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seProjectionType.Location = new System.Drawing.Point(92, 81);
            this.seProjectionType.Margin = new System.Windows.Forms.Padding(2);
            this.seProjectionType.Name = "seProjectionType";
            this.seProjectionType.ReadOnly = true;
            this.seProjectionType.Size = new System.Drawing.Size(176, 21);
            this.seProjectionType.TabIndex = 11;
            this.seProjectionType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seProjectionType, "Scene projection type");
            // 
            // seGLSLVersion
            // 
            this.seGLSLVersion.BackColor = System.Drawing.SystemColors.Window;
            this.seGLSLVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seGLSLVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seGLSLVersion.Location = new System.Drawing.Point(272, 181);
            this.seGLSLVersion.Margin = new System.Windows.Forms.Padding(2);
            this.seGLSLVersion.Name = "seGLSLVersion";
            this.seGLSLVersion.ReadOnly = true;
            this.seGLSLVersion.Size = new System.Drawing.Size(86, 21);
            this.seGLSLVersion.TabIndex = 28;
            this.seGLSLVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seGLSLVersion, "The Shader Language version targeted by this code");
            // 
            // seSampleCount
            // 
            this.seSampleCount.BackColor = System.Drawing.SystemColors.Window;
            this.seSampleCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seSampleCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seSampleCount.Location = new System.Drawing.Point(92, 181);
            this.seSampleCount.Margin = new System.Windows.Forms.Padding(2);
            this.seSampleCount.Name = "seSampleCount";
            this.seSampleCount.ReadOnly = true;
            this.seSampleCount.Size = new System.Drawing.Size(86, 21);
            this.seSampleCount.TabIndex = 26;
            this.seSampleCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.seSampleCount, "The number of samples interpolated over");
            // 
            // ToolTip
            // 
            this.ToolTip.BackColor = System.Drawing.SystemColors.Window;
            // 
            // SceneEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.TableLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SceneEdit";
            this.Size = new System.Drawing.Size(360, 237);
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraPositionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFieldOfView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraPositionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraPositionZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraYaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraRoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMinX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMinY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMinZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMaxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMaxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMaxZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFPS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox edTitle;
        public System.Windows.Forms.NumericUpDown seCameraPositionX;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblFieldOfView;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        public Jmk.Controls.JmkNumericUpDownDegrees seFieldOfView;
        public System.Windows.Forms.NumericUpDown seCameraPositionY;
        public System.Windows.Forms.NumericUpDown seCameraPositionZ;
        public Jmk.Controls.JmkNumericUpDownDegrees seCameraPitch;
        public Jmk.Controls.JmkNumericUpDownDegrees seCameraYaw;
        public Jmk.Controls.JmkNumericUpDownDegrees seCameraRoll;
        public System.Windows.Forms.NumericUpDown seFrustumMinX;
        public System.Windows.Forms.NumericUpDown seFrustumMinY;
        public System.Windows.Forms.NumericUpDown seFrustumMinZ;
        public System.Windows.Forms.NumericUpDown seFrustumMaxX;
        public System.Windows.Forms.NumericUpDown seFrustumMaxY;
        public System.Windows.Forms.NumericUpDown seFrustumMaxZ;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.NumericUpDown seFPS;
        public System.Windows.Forms.CheckBox cbVSync;
        public System.Windows.Forms.ComboBox cbBackground;
        public System.Windows.Forms.ToolTip ToolTip;
        public System.Windows.Forms.DomainUpDown seProjectionType;
        public System.Windows.Forms.DomainUpDown seGLSLVersion;
        public System.Windows.Forms.CheckBox cbStereo;
        public System.Windows.Forms.DomainUpDown seSampleCount;
    }
}
