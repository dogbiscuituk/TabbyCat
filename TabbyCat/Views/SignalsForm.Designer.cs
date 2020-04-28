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
            this.Toolbar = new System.Windows.Forms.ToolStrip();
            this.AddButton = new System.Windows.Forms.ToolStripSplitButton();
            this.DeleteAllButton = new System.Windows.Forms.ToolStripButton();
            this.AmplitudeLabel = new System.Windows.Forms.Label();
            this.WaveTypeSlider = new System.Windows.Forms.ToolStripMenuItem();
            this.WaveTypeSine = new System.Windows.Forms.ToolStripMenuItem();
            this.WaveTypeSquare = new System.Windows.Forms.ToolStripMenuItem();
            this.WaveTypeTriangle = new System.Windows.Forms.ToolStripMenuItem();
            this.WaveTypeSawtooth = new System.Windows.Forms.ToolStripMenuItem();
            this.WaveTypeReverseSawtooth = new System.Windows.Forms.ToolStripMenuItem();
            this.separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.WaveTypeCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.WaveTypeNoise = new System.Windows.Forms.ToolStripMenuItem();
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
            this.NameLabel.Location = new System.Drawing.Point(0, 0);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(50, 25);
            this.NameLabel.TabIndex = 6;
            this.NameLabel.Text = "Name";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.FrequencyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrequencyLabel.Location = new System.Drawing.Point(179, 0);
            this.FrequencyLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FrequencyLabel.Name = "label1";
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
            this.WaveTypeSawtooth,
            this.WaveTypeReverseSawtooth,
            this.separator1,
            this.WaveTypeCustom,
            this.WaveTypeNoise});
            this.AddButton.Image = global::TabbyCat.Properties.Resources.action_add_16xLG;
            this.AddButton.ImageTransparentColor = System.Drawing.Color.White;
            this.AddButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(32, 25);
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
            this.AmplitudeLabel.Location = new System.Drawing.Point(50, 0);
            this.AmplitudeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.AmplitudeLabel.Name = "AmplitudeLabel";
            this.AmplitudeLabel.Size = new System.Drawing.Size(129, 25);
            this.AmplitudeLabel.TabIndex = 4;
            this.AmplitudeLabel.Text = "Amplitude";
            this.AmplitudeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Slider
            // 
            this.WaveTypeSlider.Image = global::TabbyCat.Properties.Resources.WaveTypeDC;
            this.WaveTypeSlider.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeSlider.Name = "Slider";
            this.WaveTypeSlider.Size = new System.Drawing.Size(180, 22);
            this.WaveTypeSlider.Text = "Slider";
            // 
            // Sine
            // 
            this.WaveTypeSine.Image = global::TabbyCat.Properties.Resources.WaveTypeSine;
            this.WaveTypeSine.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeSine.Name = "Sine";
            this.WaveTypeSine.Size = new System.Drawing.Size(180, 22);
            this.WaveTypeSine.Text = "Sine";
            // 
            // Square
            // 
            this.WaveTypeSquare.Image = global::TabbyCat.Properties.Resources.WaveTypeSquare;
            this.WaveTypeSquare.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeSquare.Name = "Square";
            this.WaveTypeSquare.Size = new System.Drawing.Size(180, 22);
            this.WaveTypeSquare.Text = "Square";
            // 
            // Triangle
            // 
            this.WaveTypeTriangle.Image = global::TabbyCat.Properties.Resources.WaveTypeTriangle;
            this.WaveTypeTriangle.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeTriangle.Name = "Triangle";
            this.WaveTypeTriangle.Size = new System.Drawing.Size(180, 22);
            this.WaveTypeTriangle.Text = "Triangle";
            // 
            // Sawtooth
            // 
            this.WaveTypeSawtooth.Image = global::TabbyCat.Properties.Resources.WaveTypeSawtooth2;
            this.WaveTypeSawtooth.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeSawtooth.Name = "Sawtooth";
            this.WaveTypeSawtooth.Size = new System.Drawing.Size(180, 22);
            this.WaveTypeSawtooth.Text = "Sawtooth";
            // 
            // ReverseSawtooth
            // 
            this.WaveTypeReverseSawtooth.Image = global::TabbyCat.Properties.Resources.WaveTypeReverseSawtooth1;
            this.WaveTypeReverseSawtooth.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeReverseSawtooth.Name = "ReverseSawtooth";
            this.WaveTypeReverseSawtooth.Size = new System.Drawing.Size(180, 22);
            this.WaveTypeReverseSawtooth.Text = "Reverse sawtooth";
            // 
            // toolStripMenuItem1
            // 
            this.separator1.Name = "toolStripMenuItem1";
            this.separator1.Size = new System.Drawing.Size(177, 6);
            // 
            // Custom
            // 
            this.WaveTypeCustom.Image = global::TabbyCat.Properties.Resources.WaveTypeCustom;
            this.WaveTypeCustom.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeCustom.Name = "Custom";
            this.WaveTypeCustom.Size = new System.Drawing.Size(180, 22);
            this.WaveTypeCustom.Text = "Custom...";
            // 
            // Noise
            // 
            this.WaveTypeNoise.Image = global::TabbyCat.Properties.Resources.WaveTypeRandom;
            this.WaveTypeNoise.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeNoise.Name = "Noise";
            this.WaveTypeNoise.Size = new System.Drawing.Size(180, 22);
            this.WaveTypeNoise.Text = "Noise";
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
        public System.Windows.Forms.ToolStrip Toolbar;
        public System.Windows.Forms.ToolStripSplitButton AddButton;
        public System.Windows.Forms.ToolStripButton DeleteAllButton;
        public System.Windows.Forms.Label AmplitudeLabel;
        public System.Windows.Forms.Label NameLabel;
        public System.Windows.Forms.ToolStripMenuItem WaveTypeSlider;
        public System.Windows.Forms.ToolStripMenuItem WaveTypeSine;
        public System.Windows.Forms.ToolStripMenuItem WaveTypeSquare;
        public System.Windows.Forms.ToolStripMenuItem WaveTypeTriangle;
        public System.Windows.Forms.ToolStripMenuItem WaveTypeSawtooth;
        public System.Windows.Forms.ToolStripMenuItem WaveTypeReverseSawtooth;
        public System.Windows.Forms.ToolStripSeparator separator1;
        public System.Windows.Forms.ToolStripMenuItem WaveTypeCustom;
        public System.Windows.Forms.ToolStripMenuItem WaveTypeNoise;
    }
}