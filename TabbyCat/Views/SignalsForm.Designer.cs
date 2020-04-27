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
            this.AmplitudeHeader = new System.Windows.Forms.Label();
            this.FrequencyHeader = new System.Windows.Forms.Label();
            this.Toolbar = new System.Windows.Forms.ToolStrip();
            this.AddButton = new System.Windows.Forms.ToolStripSplitButton();
            this.WaveTypeSlider = new System.Windows.Forms.ToolStripMenuItem();
            this.WaveTypeSine = new System.Windows.Forms.ToolStripMenuItem();
            this.WaveTypeSquare = new System.Windows.Forms.ToolStripMenuItem();
            this.WaveTypeTriangle = new System.Windows.Forms.ToolStripMenuItem();
            this.WaveTypeSawtooth = new System.Windows.Forms.ToolStripMenuItem();
            this.WaveTypeReverseSawtooth = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.WaveTypeCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.WaveTypeNoise = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteButton = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.TableLayoutPanel.SuspendLayout();
            this.Toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.AutoSize = true;
            this.TableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel.ColumnCount = 4;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel.Controls.Add(this.AmplitudeHeader, 1, 0);
            this.TableLayoutPanel.Controls.Add(this.FrequencyHeader, 2, 0);
            this.TableLayoutPanel.Controls.Add(this.Toolbar, 3, 0);
            this.TableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 2;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.Size = new System.Drawing.Size(251, 25);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // AmplitudeHeader
            // 
            this.AmplitudeHeader.AutoSize = true;
            this.AmplitudeHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AmplitudeHeader.Location = new System.Drawing.Point(43, 0);
            this.AmplitudeHeader.Margin = new System.Windows.Forms.Padding(0);
            this.AmplitudeHeader.Name = "AmplitudeHeader";
            this.AmplitudeHeader.Size = new System.Drawing.Size(101, 25);
            this.AmplitudeHeader.TabIndex = 5;
            this.AmplitudeHeader.Text = "Amplitude";
            this.AmplitudeHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrequencyHeader
            // 
            this.FrequencyHeader.AutoSize = true;
            this.FrequencyHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrequencyHeader.Location = new System.Drawing.Point(144, 0);
            this.FrequencyHeader.Margin = new System.Windows.Forms.Padding(0);
            this.FrequencyHeader.Name = "FrequencyHeader";
            this.FrequencyHeader.Size = new System.Drawing.Size(49, 25);
            this.FrequencyHeader.TabIndex = 6;
            this.FrequencyHeader.Text = "Hz";
            this.FrequencyHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Toolbar
            // 
            this.Toolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddButton,
            this.DeleteButton});
            this.Toolbar.Location = new System.Drawing.Point(193, 0);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Padding = new System.Windows.Forms.Padding(0);
            this.Toolbar.Size = new System.Drawing.Size(58, 25);
            this.Toolbar.TabIndex = 7;
            // 
            // AddButton
            // 
            this.AddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WaveTypeSlider,
            this.WaveTypeSine,
            this.WaveTypeSquare,
            this.WaveTypeTriangle,
            this.WaveTypeSawtooth,
            this.WaveTypeReverseSawtooth,
            this.toolStripMenuItem9,
            this.WaveTypeCustom,
            this.WaveTypeNoise});
            this.AddButton.Image = global::TabbyCat.Properties.Resources.action_add_16xLG;
            this.AddButton.ImageTransparentColor = System.Drawing.Color.White;
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(32, 22);
            this.AddButton.Text = "toolStripSplitButton1";
            this.AddButton.ToolTipText = "Add a new signal";
            // 
            // WaveTypeSlider
            // 
            this.WaveTypeSlider.Image = global::TabbyCat.Properties.Resources.WaveTypeDC;
            this.WaveTypeSlider.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeSlider.Name = "WaveTypeSlider";
            this.WaveTypeSlider.Size = new System.Drawing.Size(166, 22);
            this.WaveTypeSlider.Text = "Slider";
            // 
            // WaveTypeSine
            // 
            this.WaveTypeSine.Image = global::TabbyCat.Properties.Resources.WaveTypeSine;
            this.WaveTypeSine.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeSine.Name = "WaveTypeSine";
            this.WaveTypeSine.Size = new System.Drawing.Size(166, 22);
            this.WaveTypeSine.Text = "Sine";
            // 
            // WaveTypeSquare
            // 
            this.WaveTypeSquare.Image = global::TabbyCat.Properties.Resources.WaveTypeSquare;
            this.WaveTypeSquare.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeSquare.Name = "WaveTypeSquare";
            this.WaveTypeSquare.Size = new System.Drawing.Size(166, 22);
            this.WaveTypeSquare.Text = "Square";
            // 
            // WaveTypeTriangle
            // 
            this.WaveTypeTriangle.Image = global::TabbyCat.Properties.Resources.WaveTypeTriangle;
            this.WaveTypeTriangle.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeTriangle.Name = "WaveTypeTriangle";
            this.WaveTypeTriangle.Size = new System.Drawing.Size(166, 22);
            this.WaveTypeTriangle.Text = "Triangle";
            // 
            // WaveTypeSawtooth
            // 
            this.WaveTypeSawtooth.Image = global::TabbyCat.Properties.Resources.WaveTypeSawtooth2;
            this.WaveTypeSawtooth.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeSawtooth.Name = "WaveTypeSawtooth";
            this.WaveTypeSawtooth.Size = new System.Drawing.Size(166, 22);
            this.WaveTypeSawtooth.Text = "Sawtooth";
            // 
            // WaveTypeReverseSawtooth
            // 
            this.WaveTypeReverseSawtooth.Image = global::TabbyCat.Properties.Resources.WaveTypeReverseSawtooth1;
            this.WaveTypeReverseSawtooth.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeReverseSawtooth.Name = "WaveTypeReverseSawtooth";
            this.WaveTypeReverseSawtooth.Size = new System.Drawing.Size(166, 22);
            this.WaveTypeReverseSawtooth.Text = "Reverse sawtooth";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(163, 6);
            // 
            // WaveTypeCustom
            // 
            this.WaveTypeCustom.Image = global::TabbyCat.Properties.Resources.WaveTypeCustom;
            this.WaveTypeCustom.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeCustom.Name = "WaveTypeCustom";
            this.WaveTypeCustom.Size = new System.Drawing.Size(166, 22);
            this.WaveTypeCustom.Text = "Custom";
            // 
            // WaveTypeNoise
            // 
            this.WaveTypeNoise.Image = global::TabbyCat.Properties.Resources.WaveTypeRandom;
            this.WaveTypeNoise.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeNoise.Name = "WaveTypeNoise";
            this.WaveTypeNoise.Size = new System.Drawing.Size(166, 22);
            this.WaveTypeNoise.Text = "Noise";
            // 
            // DeleteButton
            // 
            this.DeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteButton.Image = global::TabbyCat.Properties.Resources.Delete;
            this.DeleteButton.ImageTransparentColor = System.Drawing.Color.White;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(23, 22);
            this.DeleteButton.Text = "toolStripButton1";
            this.DeleteButton.ToolTipText = "Remove all signals";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SignalsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(251, 175);
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
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        internal System.Windows.Forms.Label AmplitudeHeader;
        internal System.Windows.Forms.Label FrequencyHeader;
        internal System.Windows.Forms.ToolStrip Toolbar;
        internal System.Windows.Forms.ToolStripSplitButton AddButton;
        internal System.Windows.Forms.ToolStripButton DeleteButton;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ToolStripMenuItem WaveTypeSlider;
        internal System.Windows.Forms.ToolStripMenuItem WaveTypeSine;
        internal System.Windows.Forms.ToolStripMenuItem WaveTypeSquare;
        internal System.Windows.Forms.ToolStripMenuItem WaveTypeTriangle;
        internal System.Windows.Forms.ToolStripMenuItem WaveTypeSawtooth;
        internal System.Windows.Forms.ToolStripMenuItem WaveTypeReverseSawtooth;
        internal System.Windows.Forms.ToolStripMenuItem WaveTypeCustom;
        internal System.Windows.Forms.ToolStripMenuItem WaveTypeNoise;
        internal System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
    }
}