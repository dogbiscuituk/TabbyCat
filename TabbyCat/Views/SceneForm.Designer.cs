namespace TabbyCat.Views
{
    partial class SceneForm
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
            this.SceneEdit = new TabbyCat.Controls.SceneEdit();
            this.SuspendLayout();
            // 
            // SceneEdit
            // 
            this.SceneEdit.BackColor = System.Drawing.SystemColors.Control;
            this.SceneEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SceneEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SceneEdit.Location = new System.Drawing.Point(0, 0);
            this.SceneEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SceneEdit.Name = "SceneEdit";
            this.SceneEdit.Size = new System.Drawing.Size(352, 250);
            this.SceneEdit.TabIndex = 0;
            // 
            // SceneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 250);
            this.Controls.Add(this.SceneEdit);
            this.Name = "SceneForm";
            this.TabText = "Scene";
            this.Text = "Scene properties";
            this.ResumeLayout(false);

        }

        #endregion

        internal Controls.SceneEdit SceneEdit;
    }
}