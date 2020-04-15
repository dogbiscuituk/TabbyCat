namespace TabbyCat.Views
{
    partial class GpuForm
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
            this.gpuEdit1 = new TabbyCat.Controls.GPUEdit();
            this.SuspendLayout();
            // 
            // gpuEdit1
            // 
            this.gpuEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpuEdit1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpuEdit1.Location = new System.Drawing.Point(0, 0);
            this.gpuEdit1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gpuEdit1.Name = "gpuEdit1";
            this.gpuEdit1.Size = new System.Drawing.Size(354, 169);
            this.gpuEdit1.TabIndex = 0;
            // 
            // GPUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 169);
            this.Controls.Add(this.gpuEdit1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GPUForm";
            this.Text = "GPU";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.GPUEdit gpuEdit1;
    }
}