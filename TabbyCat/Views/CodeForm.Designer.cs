namespace TabbyCat.Views
{
    partial class CodeForm
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
            this.CodeEdit = new UserControls.CodeEdit();
            this.SuspendLayout();
            // 
            // CodeEdit
            // 
            this.CodeEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeEdit.Location = new System.Drawing.Point(0, 0);
            this.CodeEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CodeEdit.Name = "CodeEdit";
            this.CodeEdit.Size = new System.Drawing.Size(383, 358);
            this.CodeEdit.TabIndex = 0;
            // 
            // CodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 358);
            this.Controls.Add(this.CodeEdit);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CodeForm";
            this.Text = "";
            this.ResumeLayout(false);

        }

        #endregion

        internal UserControls.CodeEdit CodeEdit;
    }
}