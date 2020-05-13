namespace TabbyCat.Views
{
    partial class ShapePropertiesForm
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
            this.ShapePropertiesEdit = new UserControls.ShapePropertiesEdit();
            this.SuspendLayout();
            // 
            // ShapePropertiesEdit
            // 
            this.ShapePropertiesEdit.AutoScroll = true;
            this.ShapePropertiesEdit.AutoSize = true;
            this.ShapePropertiesEdit.BackColor = System.Drawing.SystemColors.Window;
            this.ShapePropertiesEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShapePropertiesEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShapePropertiesEdit.Location = new System.Drawing.Point(0, 0);
            this.ShapePropertiesEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ShapePropertiesEdit.Name = "ShapePropertiesEdit";
            this.ShapePropertiesEdit.Size = new System.Drawing.Size(301, 286);
            this.ShapePropertiesEdit.TabIndex = 0;
            // 
            // ShapePropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(301, 286);
            this.Controls.Add(this.ShapePropertiesEdit);
            this.Name = "ShapePropertiesForm";
            this.TabText = "Shape";
            this.Text = "Shape properties";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public UserControls.ShapePropertiesEdit ShapePropertiesEdit;
    }
}