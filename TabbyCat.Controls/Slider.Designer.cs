namespace TabbyCat.Controls
{
    partial class Slider
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
            this.Label = new System.Windows.Forms.Label();
            this.TrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label.Location = new System.Drawing.Point(0, 0);
            this.Label.Margin = new System.Windows.Forms.Padding(0);
            this.Label.MinimumSize = new System.Drawing.Size(20, 20);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(20, 20);
            this.Label.TabIndex = 0;
            this.Label.Text = "A";
            this.Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TrackBar
            // 
            this.TrackBar.AutoSize = false;
            this.TrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrackBar.LargeChange = 10;
            this.TrackBar.Location = new System.Drawing.Point(20, 0);
            this.TrackBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TrackBar.Maximum = 1000;
            this.TrackBar.Name = "TrackBar";
            this.TrackBar.Size = new System.Drawing.Size(180, 20);
            this.TrackBar.TabIndex = 1;
            this.TrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // Slider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TrackBar);
            this.Controls.Add(this.Label);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Slider";
            this.Size = new System.Drawing.Size(200, 20);
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.TrackBar TrackBar;
    }
}
