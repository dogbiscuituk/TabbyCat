namespace TabbyCat.Views
{
    partial class ParametersForm
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
            this.slider1 = new TabbyCat.Controls.Slider();
            this.SuspendLayout();
            // 
            // slider1
            // 
            this.slider1.Dock = System.Windows.Forms.DockStyle.Top;
            this.slider1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slider1.Location = new System.Drawing.Point(0, 0);
            this.slider1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.slider1.Name = "slider1";
            this.slider1.Size = new System.Drawing.Size(276, 20);
            this.slider1.TabIndex = 0;
            // 
            // ParametersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(276, 179);
            this.Controls.Add(this.slider1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ParametersForm";
            this.TabText = "Controls";
            this.Text = "Controls";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Slider slider1;
    }
}