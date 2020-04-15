namespace TabbyCat.Views
{
    partial class ShaderForm
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
            this.ShaderEdit = new TabbyCat.Controls.ShaderEdit();
            this.SuspendLayout();
            // 
            // ShaderEdit
            // 
            this.ShaderEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShaderEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShaderEdit.Location = new System.Drawing.Point(0, 0);
            this.ShaderEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ShaderEdit.Name = "ShaderEdit";
            this.ShaderEdit.Size = new System.Drawing.Size(383, 358);
            this.ShaderEdit.TabIndex = 0;
            // 
            // ShaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 358);
            this.Controls.Add(this.ShaderEdit);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShaderForm";
            this.Text = "Code";
            this.ResumeLayout(false);

        }

        #endregion

        internal Controls.ShaderEdit ShaderEdit;
    }
}