namespace TabbyCat.Views
{
    partial class HotkeysForm
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
            this.hotkeysView1 = new TabbyCat.UserControls.HotkeysView();
            this.SuspendLayout();
            // 
            // hotkeysView1
            // 
            this.hotkeysView1.AutoScroll = true;
            this.hotkeysView1.BackColor = System.Drawing.SystemColors.Info;
            this.hotkeysView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hotkeysView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotkeysView1.Location = new System.Drawing.Point(0, 0);
            this.hotkeysView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hotkeysView1.Name = "hotkeysView1";
            this.hotkeysView1.Size = new System.Drawing.Size(314, 444);
            this.hotkeysView1.TabIndex = 0;
            // 
            // HotkeysForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(314, 444);
            this.Controls.Add(this.hotkeysView1);
            this.Name = "HotkeysForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Code hotkeys";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.HotkeysView hotkeysView1;
    }
}

