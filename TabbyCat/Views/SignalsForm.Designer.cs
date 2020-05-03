namespace TabbyCat.Views
{
    partial class SignalsForm
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.FrequencyLabel = new System.Windows.Forms.Label();
            this.Toolbar = new Jmk.Controls.JmkToolStrip();
            this.AddButton = new System.Windows.Forms.ToolStripSplitButton();
            this.WaveTypeSlider = new System.Windows.Forms.ToolStripMenuItem();
            this.WaveTypeSine = new System.Windows.Forms.ToolStripMenuItem();
            this.WaveTypeSquare = new System.Windows.Forms.ToolStripMenuItem();
            this.WaveTypeTriangle = new System.Windows.Forms.ToolStripMenuItem();
            this.WaveTypeRampUp = new System.Windows.Forms.ToolStripMenuItem();
            this.WaveTypeRampDown = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteAllButton = new System.Windows.Forms.ToolStripButton();
            this.AmplitudeLabel = new System.Windows.Forms.Label();
            this.TableLayoutPanel.SuspendLayout();
            this.Toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.ColumnCount = 4;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel.Controls.Add(this.NameLabel, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.FrequencyLabel, 2, 0);
            this.TableLayoutPanel.Controls.Add(this.Toolbar, 3, 0);
            this.TableLayoutPanel.Controls.Add(this.AmplitudeLabel, 1, 0);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 1;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(300, 25);
            this.TableLayoutPanel.TabIndex = 1;
            // 
            // NameLabel
            // 
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(0, 0);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(50, 25);
            this.NameLabel.TabIndex = 6;
            this.NameLabel.Text = "Name";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrequencyLabel
            // 
            this.FrequencyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrequencyLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FrequencyLabel.Location = new System.Drawing.Point(179, 0);
            this.FrequencyLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FrequencyLabel.Name = "FrequencyLabel";
            this.FrequencyLabel.Size = new System.Drawing.Size(63, 25);
            this.FrequencyLabel.TabIndex = 5;
            this.FrequencyLabel.Text = "Hz";
            this.FrequencyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Toolbar
            // 
            this.Toolbar.GripMargin = new System.Windows.Forms.Padding(0);
            this.Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddButton,
            this.DeleteAllButton});
            this.Toolbar.Location = new System.Drawing.Point(242, 0);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Padding = new System.Windows.Forms.Padding(0);
            this.Toolbar.Size = new System.Drawing.Size(58, 25);
            this.Toolbar.TabIndex = 3;
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.SystemColors.Control;
            this.AddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WaveTypeSlider,
            this.WaveTypeSine,
            this.WaveTypeSquare,
            this.WaveTypeTriangle,
            this.WaveTypeRampUp,
            this.WaveTypeRampDown});
            this.AddButton.Image = global::TabbyCat.Properties.Resources.AddSignal;
            this.AddButton.ImageTransparentColor = System.Drawing.Color.White;
            this.AddButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(32, 25);
            // 
            // WaveTypeSlider
            // 
            this.WaveTypeSlider.Image = global::TabbyCat.Properties.Resources.WaveType_Constant;
            this.WaveTypeSlider.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeSlider.Name = "WaveTypeSlider";
            this.WaveTypeSlider.Size = new System.Drawing.Size(138, 22);
            this.WaveTypeSlider.Text = "Slider";
            // 
            // WaveTypeSine
            // 
            this.WaveTypeSine.Image = global::TabbyCat.Properties.Resources.WaveType_Sine;
            this.WaveTypeSine.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeSine.Name = "WaveTypeSine";
            this.WaveTypeSine.Size = new System.Drawing.Size(138, 22);
            this.WaveTypeSine.Text = "Sine";
            // 
            // WaveTypeSquare
            // 
            this.WaveTypeSquare.Image = global::TabbyCat.Properties.Resources.WaveType_Square;
            this.WaveTypeSquare.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeSquare.Name = "WaveTypeSquare";
            this.WaveTypeSquare.Size = new System.Drawing.Size(138, 22);
            this.WaveTypeSquare.Text = "Square";
            // 
            // WaveTypeTriangle
            // 
            this.WaveTypeTriangle.Image = global::TabbyCat.Properties.Resources.WaveType_Triangle;
            this.WaveTypeTriangle.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeTriangle.Name = "WaveTypeTriangle";
            this.WaveTypeTriangle.Size = new System.Drawing.Size(138, 22);
            this.WaveTypeTriangle.Text = "Triangle";
            // 
            // WaveTypeRampUp
            // 
            this.WaveTypeRampUp.Image = global::TabbyCat.Properties.Resources.WaveType_RampUp;
            this.WaveTypeRampUp.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeRampUp.Name = "WaveTypeRampUp";
            this.WaveTypeRampUp.Size = new System.Drawing.Size(138, 22);
            this.WaveTypeRampUp.Text = "Ramp up";
            // 
            // WaveTypeRampDown
            // 
            this.WaveTypeRampDown.Image = global::TabbyCat.Properties.Resources.WaveType_RampDown;
            this.WaveTypeRampDown.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeRampDown.Name = "WaveTypeRampDown";
            this.WaveTypeRampDown.Size = new System.Drawing.Size(138, 22);
            this.WaveTypeRampDown.Text = "Ramp down";
            // 
            // DeleteAllButton
            // 
            this.DeleteAllButton.BackColor = System.Drawing.SystemColors.Control;
            this.DeleteAllButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteAllButton.Image = global::TabbyCat.Properties.Resources.Delete;
            this.DeleteAllButton.ImageTransparentColor = System.Drawing.Color.White;
            this.DeleteAllButton.Margin = new System.Windows.Forms.Padding(0);
            this.DeleteAllButton.Name = "DeleteAllButton";
            this.DeleteAllButton.Size = new System.Drawing.Size(23, 25);
            // 
            // AmplitudeLabel
            // 
            this.AmplitudeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AmplitudeLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmplitudeLabel.Location = new System.Drawing.Point(50, 0);
            this.AmplitudeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.AmplitudeLabel.Name = "AmplitudeLabel";
            this.AmplitudeLabel.Size = new System.Drawing.Size(129, 25);
            this.AmplitudeLabel.TabIndex = 4;
            this.AmplitudeLabel.Text = "Amplitude";
            this.AmplitudeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SignalsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(300, 186);
            this.Controls.Add(this.TableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "SignalsForm";
            this.TabText = "Signal generator";
            this.Text = "Signal generator";
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        public System.Windows.Forms.Label FrequencyLabel;
        public Jmk.Controls.JmkToolStrip Toolbar;
        public System.Windows.Forms.ToolStripSplitButton AddButton;
        public System.Windows.Forms.ToolStripButton DeleteAllButton;
        public System.Windows.Forms.Label AmplitudeLabel;
        public System.Windows.Forms.Label NameLabel;
        public System.Windows.Forms.ToolStripMenuItem WaveTypeSlider;
        public System.Windows.Forms.ToolStripMenuItem WaveTypeSine;
        public System.Windows.Forms.ToolStripMenuItem WaveTypeSquare;
        public System.Windows.Forms.ToolStripMenuItem WaveTypeTriangle;
        public System.Windows.Forms.ToolStripMenuItem WaveTypeRampUp;
        public System.Windows.Forms.ToolStripMenuItem WaveTypeRampDown;
    }
}