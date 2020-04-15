namespace TabbyCat.Views
{
    partial class TraceForm
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
            this.TraceEdit = new TabbyCat.Controls.TraceEdit();
            this.SuspendLayout();
            // 
            // TraceEdit
            // 
            this.TraceEdit.BackColor = System.Drawing.SystemColors.Control;
            this.TraceEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TraceEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TraceEdit.Location = new System.Drawing.Point(0, 0);
            this.TraceEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TraceEdit.Name = "TraceEdit";
            this.TraceEdit.Size = new System.Drawing.Size(383, 254);
            this.TraceEdit.TabIndex = 0;
            // 
            // TraceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 254);
            this.Controls.Add(this.TraceEdit);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TraceForm";
            this.TabText = "Trace";
            this.Text = "Trace properties";
            this.ResumeLayout(false);

        }

        #endregion

        internal Controls.TraceEdit TraceEdit;
    }
}