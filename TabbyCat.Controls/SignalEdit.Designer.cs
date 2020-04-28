namespace TabbyCat.Controls
{
    partial class SignalEdit
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
            this.NameEditor = new System.Windows.Forms.TextBox();
            this.AmplitudeSlider = new System.Windows.Forms.TrackBar();
            this.FrequencySlider = new System.Windows.Forms.TrackBar();
            this.Toolbar = new Jmk.Controls.JmkToolStrip();
            this.WaveTypeButton = new System.Windows.Forms.ToolStripSplitButton();
            this.DeleteButton = new System.Windows.Forms.ToolStripButton();
            this.TableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmplitudeSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencySlider)).BeginInit();
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
            this.TableLayoutPanel.Controls.Add(this.NameEditor, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.AmplitudeSlider, 1, 0);
            this.TableLayoutPanel.Controls.Add(this.FrequencySlider, 2, 0);
            this.TableLayoutPanel.Controls.Add(this.Toolbar, 3, 0);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 1;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(260, 25);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // NameEditor
            // 
            this.NameEditor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameEditor.Location = new System.Drawing.Point(3, 4);
            this.NameEditor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NameEditor.Name = "NameEditor";
            this.NameEditor.Size = new System.Drawing.Size(44, 18);
            this.NameEditor.TabIndex = 0;
            this.NameEditor.Text = "A";
            this.NameEditor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AmplitudeSlider
            // 
            this.AmplitudeSlider.AutoSize = false;
            this.AmplitudeSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AmplitudeSlider.Location = new System.Drawing.Point(50, 0);
            this.AmplitudeSlider.Margin = new System.Windows.Forms.Padding(0);
            this.AmplitudeSlider.Name = "AmplitudeSlider";
            this.AmplitudeSlider.Size = new System.Drawing.Size(81, 25);
            this.AmplitudeSlider.TabIndex = 1;
            this.AmplitudeSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // FrequencySlider
            // 
            this.FrequencySlider.AutoSize = false;
            this.FrequencySlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrequencySlider.Location = new System.Drawing.Point(131, 0);
            this.FrequencySlider.Margin = new System.Windows.Forms.Padding(0);
            this.FrequencySlider.Name = "FrequencySlider";
            this.FrequencySlider.Size = new System.Drawing.Size(40, 25);
            this.FrequencySlider.TabIndex = 2;
            this.FrequencySlider.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // Toolbar
            // 
            this.Toolbar.GripMargin = new System.Windows.Forms.Padding(0);
            this.Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WaveTypeButton,
            this.DeleteButton});
            this.Toolbar.Location = new System.Drawing.Point(171, 0);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Padding = new System.Windows.Forms.Padding(0);
            this.Toolbar.Size = new System.Drawing.Size(89, 25);
            this.Toolbar.TabIndex = 3;
            // 
            // WaveTypeButton
            // 
            this.WaveTypeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.WaveTypeButton.Image = global::TabbyCat.Controls.Properties.Resources.WaveTypeDC;
            this.WaveTypeButton.ImageTransparentColor = System.Drawing.Color.White;
            this.WaveTypeButton.Margin = new System.Windows.Forms.Padding(0);
            this.WaveTypeButton.Name = "WaveTypeButton";
            this.WaveTypeButton.Size = new System.Drawing.Size(32, 25);
            // 
            // DeleteButton
            // 
            this.DeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteButton.Image = global::TabbyCat.Controls.Properties.Resources.Delete;
            this.DeleteButton.ImageTransparentColor = System.Drawing.Color.White;
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(23, 25);
            // 
            // SignalEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SignalEdit";
            this.Size = new System.Drawing.Size(260, 25);
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmplitudeSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencySlider)).EndInit();
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        public System.Windows.Forms.TextBox NameEditor;
        public System.Windows.Forms.TrackBar AmplitudeSlider;
        public System.Windows.Forms.TrackBar FrequencySlider;
        public Jmk.Controls.JmkToolStrip Toolbar;
        public System.Windows.Forms.ToolStripSplitButton WaveTypeButton;
        public System.Windows.Forms.ToolStripButton DeleteButton;
    }
}
