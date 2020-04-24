namespace TabbyCat.Controls
{
    partial class SignalToolbar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignalToolbar));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.FixedValue = new System.Windows.Forms.ToolStripMenuItem();
            this.SineWave = new System.Windows.Forms.ToolStripMenuItem();
            this.TriangleWave = new System.Windows.Forms.ToolStripMenuItem();
            this.ForwardSawtooth = new System.Windows.Forms.ToolStripMenuItem();
            this.BackwardSawtooth = new System.Windows.Forms.ToolStripMenuItem();
            this.SquareWave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.RandomLevels = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomWave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripButton1});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(55, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FixedValue,
            this.SineWave,
            this.TriangleWave,
            this.ForwardSawtooth,
            this.BackwardSawtooth,
            this.SquareWave,
            this.toolStripMenuItem1,
            this.RandomLevels,
            this.CustomWave});
            this.toolStripSplitButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // FixedValue
            // 
            this.FixedValue.Image = global::TabbyCat.Controls.Properties.Resources.CutHS;
            this.FixedValue.ImageTransparentColor = System.Drawing.Color.White;
            this.FixedValue.Name = "FixedValue";
            this.FixedValue.Size = new System.Drawing.Size(188, 22);
            this.FixedValue.Tag = "0";
            this.FixedValue.Text = "Fixed value";
            // 
            // SineWave
            // 
            this.SineWave.Image = global::TabbyCat.Controls.Properties.Resources.CopyHS;
            this.SineWave.ImageTransparentColor = System.Drawing.Color.White;
            this.SineWave.Name = "SineWave";
            this.SineWave.Size = new System.Drawing.Size(188, 22);
            this.SineWave.Tag = "1";
            this.SineWave.Text = "Sine wave";
            // 
            // TriangleWave
            // 
            this.TriangleWave.Image = global::TabbyCat.Controls.Properties.Resources.PasteHS;
            this.TriangleWave.ImageTransparentColor = System.Drawing.Color.White;
            this.TriangleWave.Name = "TriangleWave";
            this.TriangleWave.Size = new System.Drawing.Size(188, 22);
            this.TriangleWave.Tag = "2";
            this.TriangleWave.Text = "Triangle wave";
            // 
            // ForwardSawtooth
            // 
            this.ForwardSawtooth.Image = global::TabbyCat.Controls.Properties.Resources.Delete;
            this.ForwardSawtooth.ImageTransparentColor = System.Drawing.Color.White;
            this.ForwardSawtooth.Name = "ForwardSawtooth";
            this.ForwardSawtooth.Size = new System.Drawing.Size(188, 22);
            this.ForwardSawtooth.Tag = "3";
            this.ForwardSawtooth.Text = "Forward sawtooth";
            // 
            // BackwardSawtooth
            // 
            this.BackwardSawtooth.Image = global::TabbyCat.Controls.Properties.Resources.Edit_UndoHS;
            this.BackwardSawtooth.ImageTransparentColor = System.Drawing.Color.White;
            this.BackwardSawtooth.Name = "BackwardSawtooth";
            this.BackwardSawtooth.Size = new System.Drawing.Size(188, 22);
            this.BackwardSawtooth.Tag = "4";
            this.BackwardSawtooth.Text = "Backward sawtooth";
            // 
            // SquareWave
            // 
            this.SquareWave.Image = global::TabbyCat.Controls.Properties.Resources.Edit_RedoHS;
            this.SquareWave.ImageTransparentColor = System.Drawing.Color.White;
            this.SquareWave.Name = "SquareWave";
            this.SquareWave.Size = new System.Drawing.Size(188, 22);
            this.SquareWave.Tag = "5";
            this.SquareWave.Text = "Square wave";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(185, 6);
            // 
            // RandomLevels
            // 
            this.RandomLevels.Image = global::TabbyCat.Controls.Properties.Resources.saveHS;
            this.RandomLevels.ImageTransparentColor = System.Drawing.Color.White;
            this.RandomLevels.Name = "RandomLevels";
            this.RandomLevels.Size = new System.Drawing.Size(188, 22);
            this.RandomLevels.Tag = "6";
            this.RandomLevels.Text = "Random levels";
            // 
            // CustomWave
            // 
            this.CustomWave.Image = global::TabbyCat.Controls.Properties.Resources.PrintHS;
            this.CustomWave.ImageTransparentColor = System.Drawing.Color.White;
            this.CustomWave.Name = "CustomWave";
            this.CustomWave.Size = new System.Drawing.Size(188, 22);
            this.CustomWave.Tag = "7";
            this.CustomWave.Text = "Custom wave";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = global::TabbyCat.Controls.Properties.Resources.Delete;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // SignalToolbar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SignalToolbar";
            this.Size = new System.Drawing.Size(55, 25);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        public System.Windows.Forms.ToolStripMenuItem FixedValue;
        public System.Windows.Forms.ToolStripMenuItem SineWave;
        public System.Windows.Forms.ToolStripMenuItem TriangleWave;
        public System.Windows.Forms.ToolStripMenuItem ForwardSawtooth;
        public System.Windows.Forms.ToolStripMenuItem BackwardSawtooth;
        public System.Windows.Forms.ToolStripMenuItem SquareWave;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem RandomLevels;
        public System.Windows.Forms.ToolStripMenuItem CustomWave;
    }
}
