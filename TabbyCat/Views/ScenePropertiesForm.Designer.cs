namespace TabbyCat.Views
{
    partial class ScenePropertiesForm
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
            this.ScenePropertiesEdit = new TabbyCat.Controls.ScenePropertiesEdit();
            this.SuspendLayout();
            // 
            // ScenePropertiesEdit
            // 
            this.ScenePropertiesEdit.BackColor = System.Drawing.SystemColors.Control;
            this.ScenePropertiesEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScenePropertiesEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScenePropertiesEdit.Location = new System.Drawing.Point(0, 0);
            this.ScenePropertiesEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ScenePropertiesEdit.Name = "ScenePropertiesEdit";
            this.ScenePropertiesEdit.Size = new System.Drawing.Size(352, 250);
            this.ScenePropertiesEdit.TabIndex = 0;
            // 
            // ScenePropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 250);
            this.Controls.Add(this.ScenePropertiesEdit);
            this.Name = "ScenePropertiesForm";
            this.TabText = "Scene";
            this.Text = "Scene properties";
            this.ResumeLayout(false);

        }

        #endregion

        internal Controls.ScenePropertiesEdit ScenePropertiesEdit;
    }
}