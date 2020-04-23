namespace TabbyCat.Views
{
    partial class GraphicsStateForm
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
            this.GraphicsStateView = new TabbyCat.Controls.GraphicsStateView();
            this.SuspendLayout();
            // 
            // GraphicsStateView
            // 
            this.GraphicsStateView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GraphicsStateView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GraphicsStateView.Location = new System.Drawing.Point(0, 0);
            this.GraphicsStateView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.GraphicsStateView.Name = "GraphicsStateView";
            this.GraphicsStateView.Size = new System.Drawing.Size(354, 169);
            this.GraphicsStateView.TabIndex = 0;
            // 
            // GraphicsStateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 169);
            this.Controls.Add(this.GraphicsStateView);
            this.Name = "GraphicsStateForm";
            this.TabText = "Graphics state";
            this.Text = "Graphics state";
            this.ResumeLayout(false);

        }

        #endregion

        internal Controls.GraphicsStateView GraphicsStateView;
    }
}