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
            this.SceneControl = new OpenTK.GLControl();
            this.SuspendLayout();
            // 
            // SceneControl
            // 
            this.SceneControl.BackColor = System.Drawing.Color.White;
            this.SceneControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SceneControl.Location = new System.Drawing.Point(0, 0);
            this.SceneControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.SceneControl.Name = "SceneControl";
            this.SceneControl.Size = new System.Drawing.Size(564, 357);
            this.SceneControl.TabIndex = 1;
            this.SceneControl.VSync = false;
            // 
            // SceneForm
            // 
            this.AllowEndUserDocking = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 357);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.SceneControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SceneForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Scene";
            this.ResumeLayout(false);

        }

        #endregion

        public OpenTK.GLControl SceneControl;
    }
}