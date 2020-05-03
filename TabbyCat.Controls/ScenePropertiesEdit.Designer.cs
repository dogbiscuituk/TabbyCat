namespace TabbyCat.Controls
{
    partial class ScenePropertiesEdit
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
            this.cbStereo = new System.Windows.Forms.CheckBox();
            this.seCameraPositionX = new System.Windows.Forms.NumericUpDown();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.edTitle = new System.Windows.Forms.TextBox();
            this.lblDirection = new System.Windows.Forms.Label();
            this.lblProjection = new System.Windows.Forms.Label();
            this.lblFieldOfView = new System.Windows.Forms.Label();
            this.lblNearPlane = new System.Windows.Forms.Label();
            this.lblFarPlane = new System.Windows.Forms.Label();
            this.seCameraPositionY = new System.Windows.Forms.NumericUpDown();
            this.seCameraPositionZ = new System.Windows.Forms.NumericUpDown();
            this.seFrustumMinX = new System.Windows.Forms.NumericUpDown();
            this.seFrustumMinY = new System.Windows.Forms.NumericUpDown();
            this.seFrustumMinZ = new System.Windows.Forms.NumericUpDown();
            this.seFrustumMaxX = new System.Windows.Forms.NumericUpDown();
            this.seFrustumMaxY = new System.Windows.Forms.NumericUpDown();
            this.seFrustumMaxZ = new System.Windows.Forms.NumericUpDown();
            this.lblBackground = new System.Windows.Forms.Label();
            this.lblTargetFPS = new System.Windows.Forms.Label();
            this.lblSamples = new System.Windows.Forms.Label();
            this.lblGLSLVersion = new System.Windows.Forms.Label();
            this.seFPS = new System.Windows.Forms.NumericUpDown();
            this.cbVSync = new System.Windows.Forms.CheckBox();
            this.cbBackground = new System.Windows.Forms.ComboBox();
            this.seProjectionType = new System.Windows.Forms.DomainUpDown();
            this.seGLSLVersion = new System.Windows.Forms.DomainUpDown();
            this.seSampleCount = new System.Windows.Forms.DomainUpDown();
            this.seFieldOfView = new Jmk.Controls.JmkNumericUpDownDegrees();
            this.seCameraPitch = new Jmk.Controls.JmkNumericUpDownDegrees();
            this.seCameraYaw = new Jmk.Controls.JmkNumericUpDownDegrees();
            this.seCameraRoll = new Jmk.Controls.JmkNumericUpDownDegrees();
            this.TableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraPositionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraPositionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraPositionZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMinX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMinY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMinZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMaxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMaxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMaxZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFieldOfView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraYaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraRoll)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.AutoSize = true;
            this.TableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel.BackColor = System.Drawing.SystemColors.Window;
            this.TableLayoutPanel.ColumnCount = 4;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.TableLayoutPanel.Controls.Add(this.cbStereo, 3, 3);
            this.TableLayoutPanel.Controls.Add(this.seCameraPositionX, 1, 1);
            this.TableLayoutPanel.Controls.Add(this.lblPosition, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.lblTitle, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.edTitle, 1, 0);
            this.TableLayoutPanel.Controls.Add(this.lblDirection, 0, 2);
            this.TableLayoutPanel.Controls.Add(this.lblProjection, 0, 3);
            this.TableLayoutPanel.Controls.Add(this.lblFieldOfView, 0, 4);
            this.TableLayoutPanel.Controls.Add(this.lblNearPlane, 0, 5);
            this.TableLayoutPanel.Controls.Add(this.lblFarPlane, 0, 6);
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
            this.TableLayoutPanel.Controls.Add(this.lblBackground, 0, 8);
            this.TableLayoutPanel.Controls.Add(this.lblTargetFPS, 2, 4);
            this.TableLayoutPanel.Controls.Add(this.lblSamples, 0, 7);
            this.TableLayoutPanel.Controls.Add(this.lblGLSLVersion, 2, 7);
            this.TableLayoutPanel.Controls.Add(this.seFPS, 3, 4);
            this.TableLayoutPanel.Controls.Add(this.cbVSync, 3, 8);
            this.TableLayoutPanel.Controls.Add(this.cbBackground, 1, 8);
            this.TableLayoutPanel.Controls.Add(this.seProjectionType, 1, 3);
            this.TableLayoutPanel.Controls.Add(this.seGLSLVersion, 3, 7);
            this.TableLayoutPanel.Controls.Add(this.seSampleCount, 1, 7);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.TableLayoutPanel.Size = new System.Drawing.Size(305, 248);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // cbStereo
            // 
            this.cbStereo.AutoSize = true;
            this.cbStereo.BackColor = System.Drawing.SystemColors.Info;
            this.cbStereo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbStereo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbStereo.FlatAppearance.BorderSize = 0;
            this.cbStereo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbStereo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStereo.Location = new System.Drawing.Point(234, 88);
            this.cbStereo.Name = "cbStereo";
            this.cbStereo.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.cbStereo.Size = new System.Drawing.Size(68, 21);
            this.cbStereo.TabIndex = 12;
            this.cbStereo.Text = "Stereo";
            this.cbStereo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.seCameraPositionX.Location = new System.Drawing.Point(88, 34);
            this.seCameraPositionX.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seCameraPositionX.Name = "seCameraPositionX";
            this.seCameraPositionX.Size = new System.Drawing.Size(67, 21);
            this.seCameraPositionX.TabIndex = 3;
            this.seCameraPositionX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.BackColor = System.Drawing.SystemColors.Window;
            this.lblPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPosition.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(3, 34);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(3);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(79, 21);
            this.lblPosition.TabIndex = 2;
            this.lblPosition.Text = "Position";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.Window;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 3);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(79, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Scene title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edTitle
            // 
            this.edTitle.BackColor = System.Drawing.SystemColors.Window;
            this.edTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TableLayoutPanel.SetColumnSpan(this.edTitle, 3);
            this.edTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edTitle.Location = new System.Drawing.Point(88, 3);
            this.edTitle.Name = "edTitle";
            this.edTitle.Size = new System.Drawing.Size(214, 25);
            this.edTitle.TabIndex = 1;
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.BackColor = System.Drawing.SystemColors.Window;
            this.lblDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDirection.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirection.Location = new System.Drawing.Point(3, 61);
            this.lblDirection.Margin = new System.Windows.Forms.Padding(3);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(79, 21);
            this.lblDirection.TabIndex = 6;
            this.lblDirection.Text = "Direction";
            this.lblDirection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProjection
            // 
            this.lblProjection.AutoSize = true;
            this.lblProjection.BackColor = System.Drawing.SystemColors.Info;
            this.lblProjection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProjection.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjection.Location = new System.Drawing.Point(3, 88);
            this.lblProjection.Margin = new System.Windows.Forms.Padding(3);
            this.lblProjection.Name = "lblProjection";
            this.lblProjection.Size = new System.Drawing.Size(79, 21);
            this.lblProjection.TabIndex = 10;
            this.lblProjection.Text = "Projection";
            this.lblProjection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFieldOfView
            // 
            this.lblFieldOfView.AutoSize = true;
            this.lblFieldOfView.BackColor = System.Drawing.SystemColors.Info;
            this.lblFieldOfView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFieldOfView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFieldOfView.Location = new System.Drawing.Point(3, 115);
            this.lblFieldOfView.Margin = new System.Windows.Forms.Padding(3);
            this.lblFieldOfView.Name = "lblFieldOfView";
            this.lblFieldOfView.Size = new System.Drawing.Size(79, 21);
            this.lblFieldOfView.TabIndex = 13;
            this.lblFieldOfView.Text = "Field of view";
            this.lblFieldOfView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNearPlane
            // 
            this.lblNearPlane.AutoSize = true;
            this.lblNearPlane.BackColor = System.Drawing.SystemColors.Info;
            this.lblNearPlane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNearPlane.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNearPlane.Location = new System.Drawing.Point(3, 142);
            this.lblNearPlane.Margin = new System.Windows.Forms.Padding(3);
            this.lblNearPlane.Name = "lblNearPlane";
            this.lblNearPlane.Size = new System.Drawing.Size(79, 21);
            this.lblNearPlane.TabIndex = 17;
            this.lblNearPlane.Text = "Near plane";
            this.lblNearPlane.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFarPlane
            // 
            this.lblFarPlane.AutoSize = true;
            this.lblFarPlane.BackColor = System.Drawing.SystemColors.Info;
            this.lblFarPlane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFarPlane.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFarPlane.Location = new System.Drawing.Point(3, 169);
            this.lblFarPlane.Margin = new System.Windows.Forms.Padding(3);
            this.lblFarPlane.Name = "lblFarPlane";
            this.lblFarPlane.Size = new System.Drawing.Size(79, 21);
            this.lblFarPlane.TabIndex = 21;
            this.lblFarPlane.Text = "Far plane";
            this.lblFarPlane.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.seCameraPositionY.Location = new System.Drawing.Point(161, 34);
            this.seCameraPositionY.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seCameraPositionY.Name = "seCameraPositionY";
            this.seCameraPositionY.Size = new System.Drawing.Size(67, 21);
            this.seCameraPositionY.TabIndex = 4;
            this.seCameraPositionY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.seCameraPositionZ.Location = new System.Drawing.Point(234, 34);
            this.seCameraPositionZ.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seCameraPositionZ.Name = "seCameraPositionZ";
            this.seCameraPositionZ.Size = new System.Drawing.Size(68, 21);
            this.seCameraPositionZ.TabIndex = 5;
            this.seCameraPositionZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seFrustumMinX
            // 
            this.seFrustumMinX.BackColor = System.Drawing.SystemColors.Info;
            this.seFrustumMinX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seFrustumMinX.DecimalPlaces = 3;
            this.seFrustumMinX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seFrustumMinX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seFrustumMinX.Location = new System.Drawing.Point(88, 142);
            this.seFrustumMinX.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFrustumMinX.Name = "seFrustumMinX";
            this.seFrustumMinX.Size = new System.Drawing.Size(67, 21);
            this.seFrustumMinX.TabIndex = 18;
            this.seFrustumMinX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seFrustumMinY
            // 
            this.seFrustumMinY.BackColor = System.Drawing.SystemColors.Info;
            this.seFrustumMinY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seFrustumMinY.DecimalPlaces = 3;
            this.seFrustumMinY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seFrustumMinY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seFrustumMinY.Location = new System.Drawing.Point(161, 142);
            this.seFrustumMinY.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFrustumMinY.Name = "seFrustumMinY";
            this.seFrustumMinY.Size = new System.Drawing.Size(67, 21);
            this.seFrustumMinY.TabIndex = 19;
            this.seFrustumMinY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seFrustumMinZ
            // 
            this.seFrustumMinZ.BackColor = System.Drawing.SystemColors.Info;
            this.seFrustumMinZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seFrustumMinZ.DecimalPlaces = 3;
            this.seFrustumMinZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seFrustumMinZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seFrustumMinZ.Location = new System.Drawing.Point(234, 142);
            this.seFrustumMinZ.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFrustumMinZ.Name = "seFrustumMinZ";
            this.seFrustumMinZ.Size = new System.Drawing.Size(68, 21);
            this.seFrustumMinZ.TabIndex = 20;
            this.seFrustumMinZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seFrustumMaxX
            // 
            this.seFrustumMaxX.BackColor = System.Drawing.SystemColors.Info;
            this.seFrustumMaxX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seFrustumMaxX.DecimalPlaces = 3;
            this.seFrustumMaxX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seFrustumMaxX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seFrustumMaxX.Location = new System.Drawing.Point(88, 169);
            this.seFrustumMaxX.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFrustumMaxX.Name = "seFrustumMaxX";
            this.seFrustumMaxX.Size = new System.Drawing.Size(67, 21);
            this.seFrustumMaxX.TabIndex = 22;
            this.seFrustumMaxX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seFrustumMaxY
            // 
            this.seFrustumMaxY.BackColor = System.Drawing.SystemColors.Info;
            this.seFrustumMaxY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seFrustumMaxY.DecimalPlaces = 3;
            this.seFrustumMaxY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seFrustumMaxY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seFrustumMaxY.Location = new System.Drawing.Point(161, 169);
            this.seFrustumMaxY.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFrustumMaxY.Name = "seFrustumMaxY";
            this.seFrustumMaxY.Size = new System.Drawing.Size(67, 21);
            this.seFrustumMaxY.TabIndex = 23;
            this.seFrustumMaxY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seFrustumMaxZ
            // 
            this.seFrustumMaxZ.BackColor = System.Drawing.SystemColors.Info;
            this.seFrustumMaxZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seFrustumMaxZ.DecimalPlaces = 3;
            this.seFrustumMaxZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seFrustumMaxZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seFrustumMaxZ.Location = new System.Drawing.Point(234, 169);
            this.seFrustumMaxZ.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFrustumMaxZ.Name = "seFrustumMaxZ";
            this.seFrustumMaxZ.Size = new System.Drawing.Size(68, 21);
            this.seFrustumMaxZ.TabIndex = 24;
            this.seFrustumMaxZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBackground
            // 
            this.lblBackground.AutoSize = true;
            this.lblBackground.BackColor = System.Drawing.SystemColors.Window;
            this.lblBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBackground.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackground.Location = new System.Drawing.Point(3, 223);
            this.lblBackground.Margin = new System.Windows.Forms.Padding(3);
            this.lblBackground.Name = "lblBackground";
            this.lblBackground.Size = new System.Drawing.Size(79, 22);
            this.lblBackground.TabIndex = 29;
            this.lblBackground.Text = "Background";
            this.lblBackground.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTargetFPS
            // 
            this.lblTargetFPS.AutoSize = true;
            this.lblTargetFPS.BackColor = System.Drawing.SystemColors.Info;
            this.lblTargetFPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTargetFPS.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetFPS.Location = new System.Drawing.Point(161, 115);
            this.lblTargetFPS.Margin = new System.Windows.Forms.Padding(3);
            this.lblTargetFPS.Name = "lblTargetFPS";
            this.lblTargetFPS.Size = new System.Drawing.Size(67, 21);
            this.lblTargetFPS.TabIndex = 15;
            this.lblTargetFPS.Text = "Target FPS";
            this.lblTargetFPS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSamples
            // 
            this.lblSamples.AutoSize = true;
            this.lblSamples.BackColor = System.Drawing.SystemColors.Window;
            this.lblSamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSamples.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSamples.Location = new System.Drawing.Point(3, 196);
            this.lblSamples.Margin = new System.Windows.Forms.Padding(3);
            this.lblSamples.Name = "lblSamples";
            this.lblSamples.Size = new System.Drawing.Size(79, 21);
            this.lblSamples.TabIndex = 25;
            this.lblSamples.Text = "#Samples";
            this.lblSamples.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGLSLVersion
            // 
            this.lblGLSLVersion.AutoSize = true;
            this.lblGLSLVersion.BackColor = System.Drawing.SystemColors.Window;
            this.lblGLSLVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGLSLVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGLSLVersion.Location = new System.Drawing.Point(161, 196);
            this.lblGLSLVersion.Margin = new System.Windows.Forms.Padding(3);
            this.lblGLSLVersion.Name = "lblGLSLVersion";
            this.lblGLSLVersion.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblGLSLVersion.Size = new System.Drawing.Size(67, 21);
            this.lblGLSLVersion.TabIndex = 27;
            this.lblGLSLVersion.Text = "GL version";
            this.lblGLSLVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // seFPS
            // 
            this.seFPS.BackColor = System.Drawing.SystemColors.Info;
            this.seFPS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seFPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seFPS.Location = new System.Drawing.Point(234, 115);
            this.seFPS.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFPS.Name = "seFPS";
            this.seFPS.Size = new System.Drawing.Size(68, 21);
            this.seFPS.TabIndex = 16;
            this.seFPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbVSync
            // 
            this.cbVSync.AutoSize = true;
            this.cbVSync.BackColor = System.Drawing.SystemColors.Window;
            this.cbVSync.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbVSync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbVSync.FlatAppearance.BorderSize = 0;
            this.cbVSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbVSync.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVSync.Location = new System.Drawing.Point(234, 223);
            this.cbVSync.Name = "cbVSync";
            this.cbVSync.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.cbVSync.Size = new System.Drawing.Size(68, 22);
            this.cbVSync.TabIndex = 31;
            this.cbVSync.Text = "VSync";
            this.cbVSync.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.cbBackground.ItemHeight = 16;
            this.cbBackground.Location = new System.Drawing.Point(88, 223);
            this.cbBackground.Name = "cbBackground";
            this.cbBackground.Size = new System.Drawing.Size(140, 22);
            this.cbBackground.TabIndex = 30;
            // 
            // seProjectionType
            // 
            this.seProjectionType.BackColor = System.Drawing.SystemColors.Info;
            this.seProjectionType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TableLayoutPanel.SetColumnSpan(this.seProjectionType, 2);
            this.seProjectionType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seProjectionType.Location = new System.Drawing.Point(88, 88);
            this.seProjectionType.Name = "seProjectionType";
            this.seProjectionType.ReadOnly = true;
            this.seProjectionType.Size = new System.Drawing.Size(140, 21);
            this.seProjectionType.TabIndex = 11;
            this.seProjectionType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seGLSLVersion
            // 
            this.seGLSLVersion.BackColor = System.Drawing.SystemColors.Window;
            this.seGLSLVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seGLSLVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seGLSLVersion.Location = new System.Drawing.Point(234, 196);
            this.seGLSLVersion.Name = "seGLSLVersion";
            this.seGLSLVersion.ReadOnly = true;
            this.seGLSLVersion.Size = new System.Drawing.Size(68, 21);
            this.seGLSLVersion.TabIndex = 28;
            this.seGLSLVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seSampleCount
            // 
            this.seSampleCount.BackColor = System.Drawing.SystemColors.Window;
            this.seSampleCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seSampleCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seSampleCount.Location = new System.Drawing.Point(88, 196);
            this.seSampleCount.Name = "seSampleCount";
            this.seSampleCount.ReadOnly = true;
            this.seSampleCount.Size = new System.Drawing.Size(67, 21);
            this.seSampleCount.TabIndex = 26;
            this.seSampleCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seFieldOfView
            // 
            this.seFieldOfView.BackColor = System.Drawing.SystemColors.Info;
            this.seFieldOfView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seFieldOfView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seFieldOfView.Location = new System.Drawing.Point(88, 115);
            this.seFieldOfView.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFieldOfView.Name = "seFieldOfView";
            this.seFieldOfView.Size = new System.Drawing.Size(67, 21);
            this.seFieldOfView.TabIndex = 14;
            this.seFieldOfView.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seCameraPitch
            // 
            this.seCameraPitch.BackColor = System.Drawing.SystemColors.Window;
            this.seCameraPitch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seCameraPitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seCameraPitch.Location = new System.Drawing.Point(88, 61);
            this.seCameraPitch.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seCameraPitch.Name = "seCameraPitch";
            this.seCameraPitch.Size = new System.Drawing.Size(67, 21);
            this.seCameraPitch.TabIndex = 7;
            this.seCameraPitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seCameraYaw
            // 
            this.seCameraYaw.BackColor = System.Drawing.SystemColors.Window;
            this.seCameraYaw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seCameraYaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seCameraYaw.Location = new System.Drawing.Point(161, 61);
            this.seCameraYaw.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seCameraYaw.Name = "seCameraYaw";
            this.seCameraYaw.Size = new System.Drawing.Size(67, 21);
            this.seCameraYaw.TabIndex = 8;
            this.seCameraYaw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seCameraRoll
            // 
            this.seCameraRoll.BackColor = System.Drawing.SystemColors.Window;
            this.seCameraRoll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seCameraRoll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seCameraRoll.Location = new System.Drawing.Point(234, 61);
            this.seCameraRoll.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seCameraRoll.Name = "seCameraRoll";
            this.seCameraRoll.Size = new System.Drawing.Size(68, 21);
            this.seCameraRoll.TabIndex = 9;
            this.seCameraRoll.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ScenePropertiesEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.TableLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ScenePropertiesEdit";
            this.Size = new System.Drawing.Size(305, 248);
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraPositionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraPositionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraPositionZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMinX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMinY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMinZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMaxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMaxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrustumMaxZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFieldOfView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraYaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCameraRoll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.TextBox edTitle;
        public System.Windows.Forms.NumericUpDown seCameraPositionX;
        public System.Windows.Forms.Label lblPosition;
        public System.Windows.Forms.Label lblDirection;
        public System.Windows.Forms.Label lblProjection;
        public System.Windows.Forms.Label lblFieldOfView;
        public System.Windows.Forms.Label lblNearPlane;
        public System.Windows.Forms.Label lblFarPlane;
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
        public System.Windows.Forms.Label lblBackground;
        public System.Windows.Forms.Label lblTargetFPS;
        public System.Windows.Forms.Label lblSamples;
        public System.Windows.Forms.Label lblGLSLVersion;
        public System.Windows.Forms.NumericUpDown seFPS;
        public System.Windows.Forms.CheckBox cbVSync;
        public System.Windows.Forms.ComboBox cbBackground;
        public System.Windows.Forms.DomainUpDown seProjectionType;
        public System.Windows.Forms.DomainUpDown seGLSLVersion;
        public System.Windows.Forms.CheckBox cbStereo;
        public System.Windows.Forms.DomainUpDown seSampleCount;
    }
}
