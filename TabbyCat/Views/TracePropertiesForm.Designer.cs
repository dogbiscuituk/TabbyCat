namespace TabbyCat.Views
{
    partial class TracePropertiesForm
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
            this.TracePropertiesEdit = new TabbyCat.Controls.TracePropertiesEdit();
            this.SuspendLayout();
            // 
            // TracePropertiesEdit
            // 
            this.TracePropertiesEdit.BackColor = System.Drawing.SystemColors.Control;
            this.TracePropertiesEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.TracePropertiesEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TracePropertiesEdit.Location = new System.Drawing.Point(0, 0);
            this.TracePropertiesEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TracePropertiesEdit.Name = "TracePropertiesEdit";
            this.TracePropertiesEdit.Size = new System.Drawing.Size(352, 250);
            this.TracePropertiesEdit.TabIndex = 0;
            // 
            // TracePropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(352, 250);
            this.Controls.Add(this.TracePropertiesEdit);
            this.Name = "TracePropertiesForm";
            this.TabText = "Trace";
            this.Text = "Trace properties";
            this.ResumeLayout(false);

        }

        #endregion

        internal Controls.TracePropertiesEdit TracePropertiesEdit;
    }
}