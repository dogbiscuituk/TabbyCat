namespace TabbyCat.Views
{
    partial class SignalPropertiesDialog
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
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.seWaveType = new System.Windows.Forms.DomainUpDown();
            this.seFrequencyMaximum = new System.Windows.Forms.NumericUpDown();
            this.seFrequencyValue = new System.Windows.Forms.NumericUpDown();
            this.seFrequencyMinimum = new System.Windows.Forms.NumericUpDown();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.seAmplitudeMaximum = new System.Windows.Forms.NumericUpDown();
            this.seAmplitudeValue = new System.Windows.Forms.NumericUpDown();
            this.seAmplitudeMinimum = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAmplitude = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.edName = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.TableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seFrequencyMaximum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrequencyValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrequencyMinimum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAmplitudeMaximum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAmplitudeValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAmplitudeMinimum)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.BackColor = System.Drawing.SystemColors.Window;
            this.TableLayoutPanel.ColumnCount = 4;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.Controls.Add(this.seWaveType, 3, 0);
            this.TableLayoutPanel.Controls.Add(this.seFrequencyMaximum, 3, 3);
            this.TableLayoutPanel.Controls.Add(this.seFrequencyValue, 2, 3);
            this.TableLayoutPanel.Controls.Add(this.seFrequencyMinimum, 1, 3);
            this.TableLayoutPanel.Controls.Add(this.lblFrequency, 0, 3);
            this.TableLayoutPanel.Controls.Add(this.label7, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.seAmplitudeMaximum, 3, 2);
            this.TableLayoutPanel.Controls.Add(this.seAmplitudeValue, 2, 2);
            this.TableLayoutPanel.Controls.Add(this.seAmplitudeMinimum, 1, 2);
            this.TableLayoutPanel.Controls.Add(this.label6, 3, 1);
            this.TableLayoutPanel.Controls.Add(this.label5, 1, 1);
            this.TableLayoutPanel.Controls.Add(this.label4, 2, 1);
            this.TableLayoutPanel.Controls.Add(this.lblAmplitude, 0, 2);
            this.TableLayoutPanel.Controls.Add(this.label1, 2, 0);
            this.TableLayoutPanel.Controls.Add(this.edName, 1, 0);
            this.TableLayoutPanel.Controls.Add(this.lblTitle, 0, 0);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 5;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.Size = new System.Drawing.Size(360, 106);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // seWaveType
            // 
            this.seWaveType.BackColor = System.Drawing.SystemColors.Window;
            this.seWaveType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seWaveType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seWaveType.Location = new System.Drawing.Point(273, 3);
            this.seWaveType.Name = "seWaveType";
            this.seWaveType.ReadOnly = true;
            this.seWaveType.Size = new System.Drawing.Size(84, 21);
            this.seWaveType.TabIndex = 31;
            this.seWaveType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seFrequencyMaximum
            // 
            this.seFrequencyMaximum.BackColor = System.Drawing.SystemColors.Window;
            this.seFrequencyMaximum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seFrequencyMaximum.DecimalPlaces = 3;
            this.seFrequencyMaximum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seFrequencyMaximum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seFrequencyMaximum.Location = new System.Drawing.Point(273, 80);
            this.seFrequencyMaximum.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFrequencyMaximum.Name = "seFrequencyMaximum";
            this.seFrequencyMaximum.Size = new System.Drawing.Size(84, 21);
            this.seFrequencyMaximum.TabIndex = 30;
            this.seFrequencyMaximum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seFrequencyValue
            // 
            this.seFrequencyValue.BackColor = System.Drawing.SystemColors.Window;
            this.seFrequencyValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seFrequencyValue.DecimalPlaces = 3;
            this.seFrequencyValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seFrequencyValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seFrequencyValue.Location = new System.Drawing.Point(183, 80);
            this.seFrequencyValue.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFrequencyValue.Name = "seFrequencyValue";
            this.seFrequencyValue.Size = new System.Drawing.Size(84, 21);
            this.seFrequencyValue.TabIndex = 29;
            this.seFrequencyValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seFrequencyMinimum
            // 
            this.seFrequencyMinimum.BackColor = System.Drawing.SystemColors.Window;
            this.seFrequencyMinimum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seFrequencyMinimum.DecimalPlaces = 3;
            this.seFrequencyMinimum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seFrequencyMinimum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seFrequencyMinimum.Location = new System.Drawing.Point(93, 80);
            this.seFrequencyMinimum.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFrequencyMinimum.Name = "seFrequencyMinimum";
            this.seFrequencyMinimum.Size = new System.Drawing.Size(84, 21);
            this.seFrequencyMinimum.TabIndex = 28;
            this.seFrequencyMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.BackColor = System.Drawing.SystemColors.Window;
            this.lblFrequency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFrequency.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrequency.Location = new System.Drawing.Point(3, 77);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(84, 27);
            this.lblFrequency.TabIndex = 27;
            this.lblFrequency.Text = "Frequency";
            this.lblFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Window;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(0, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 23);
            this.label7.TabIndex = 26;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // seAmplitudeMaximum
            // 
            this.seAmplitudeMaximum.BackColor = System.Drawing.SystemColors.Window;
            this.seAmplitudeMaximum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seAmplitudeMaximum.DecimalPlaces = 3;
            this.seAmplitudeMaximum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seAmplitudeMaximum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seAmplitudeMaximum.Location = new System.Drawing.Point(273, 53);
            this.seAmplitudeMaximum.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seAmplitudeMaximum.Name = "seAmplitudeMaximum";
            this.seAmplitudeMaximum.Size = new System.Drawing.Size(84, 21);
            this.seAmplitudeMaximum.TabIndex = 25;
            this.seAmplitudeMaximum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seAmplitudeValue
            // 
            this.seAmplitudeValue.BackColor = System.Drawing.SystemColors.Window;
            this.seAmplitudeValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seAmplitudeValue.DecimalPlaces = 3;
            this.seAmplitudeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seAmplitudeValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seAmplitudeValue.Location = new System.Drawing.Point(183, 53);
            this.seAmplitudeValue.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seAmplitudeValue.Name = "seAmplitudeValue";
            this.seAmplitudeValue.Size = new System.Drawing.Size(84, 21);
            this.seAmplitudeValue.TabIndex = 24;
            this.seAmplitudeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seAmplitudeMinimum
            // 
            this.seAmplitudeMinimum.BackColor = System.Drawing.SystemColors.Window;
            this.seAmplitudeMinimum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seAmplitudeMinimum.DecimalPlaces = 3;
            this.seAmplitudeMinimum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seAmplitudeMinimum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seAmplitudeMinimum.Location = new System.Drawing.Point(93, 53);
            this.seAmplitudeMinimum.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seAmplitudeMinimum.Name = "seAmplitudeMinimum";
            this.seAmplitudeMinimum.Size = new System.Drawing.Size(84, 21);
            this.seAmplitudeMinimum.TabIndex = 23;
            this.seAmplitudeMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Window;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(273, 30);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Maximum";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(93, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Minimum";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(183, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Value";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAmplitude
            // 
            this.lblAmplitude.AutoSize = true;
            this.lblAmplitude.BackColor = System.Drawing.SystemColors.Window;
            this.lblAmplitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAmplitude.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmplitude.Location = new System.Drawing.Point(3, 50);
            this.lblAmplitude.Name = "lblAmplitude";
            this.lblAmplitude.Size = new System.Drawing.Size(84, 27);
            this.lblAmplitude.TabIndex = 4;
            this.lblAmplitude.Text = "Amplitude";
            this.lblAmplitude.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(183, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Wave type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edName
            // 
            this.edName.BackColor = System.Drawing.SystemColors.Window;
            this.edName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edName.Location = new System.Drawing.Point(90, 0);
            this.edName.Margin = new System.Windows.Forms.Padding(0);
            this.edName.Name = "edName";
            this.edName.Size = new System.Drawing.Size(90, 25);
            this.edName.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.Window;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(84, 27);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Name";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(192, 113);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 26);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(273, 113);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // SignalPropertiesDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(360, 146);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.TableLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignalPropertiesDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Signal properties";
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seFrequencyMaximum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrequencyValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFrequencyMinimum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAmplitudeMaximum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAmplitudeValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAmplitudeMinimum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblAmplitude;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox edName;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown seAmplitudeMaximum;
        public System.Windows.Forms.NumericUpDown seAmplitudeValue;
        public System.Windows.Forms.NumericUpDown seAmplitudeMinimum;
        public System.Windows.Forms.NumericUpDown seFrequencyMaximum;
        public System.Windows.Forms.NumericUpDown seFrequencyValue;
        public System.Windows.Forms.NumericUpDown seFrequencyMinimum;
        public System.Windows.Forms.Label lblFrequency;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.DomainUpDown seWaveType;
    }
}