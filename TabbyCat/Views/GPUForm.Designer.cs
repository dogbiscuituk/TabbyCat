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
            this.GpuEdit = new TabbyCat.Controls.GPUEdit();
            this.SuspendLayout();
            // 
            // gpuEdit1
            // 
            this.GpuEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GpuEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GpuEdit.Location = new System.Drawing.Point(0, 0);
            this.GpuEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.GpuEdit.Name = "gpuEdit1";
            this.GpuEdit.Size = new System.Drawing.Size(354, 169);
            this.GpuEdit.TabIndex = 0;
            // 
            // GpuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 169);
            this.Controls.Add(this.GpuEdit);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GpuForm";
            this.TabText = "GPU";
            this.Text = "GPU status";
            this.ResumeLayout(false);

        }

        #endregion

        internal Controls.GPUEdit GpuEdit;
    }
}