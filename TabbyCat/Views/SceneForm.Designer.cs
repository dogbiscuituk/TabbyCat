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
            this.sceneEdit1 = new TabbyCat.Controls.SceneEdit();
            this.SuspendLayout();
            // 
            // sceneEdit1
            // 
            this.sceneEdit1.BackColor = System.Drawing.SystemColors.Control;
            this.sceneEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneEdit1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sceneEdit1.Location = new System.Drawing.Point(0, 0);
            this.sceneEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sceneEdit1.Name = "sceneEdit1";
            this.sceneEdit1.Size = new System.Drawing.Size(374, 262);
            this.sceneEdit1.TabIndex = 0;
            // 
            // SceneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 262);
            this.Controls.Add(this.sceneEdit1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SceneForm";
            this.Text = "Scene";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SceneEdit sceneEdit1;
    }
}