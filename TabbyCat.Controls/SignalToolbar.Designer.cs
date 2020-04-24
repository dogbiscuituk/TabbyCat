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
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.WaveTypeButton = new System.Windows.Forms.ToolStripSplitButton();
            this.FixedValue = new System.Windows.Forms.ToolStripMenuItem();
            this.SineWave = new System.Windows.Forms.ToolStripMenuItem();
            this.TriangleWave = new System.Windows.Forms.ToolStripMenuItem();
            this.ForwardSawtooth = new System.Windows.Forms.ToolStripMenuItem();
            this.BackwardSawtooth = new System.Windows.Forms.ToolStripMenuItem();
            this.SquareWave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.RandomLevels = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomWave = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WaveTypeButton,
            this.DeleteButton});
            this.ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.ToolStrip.Size = new System.Drawing.Size(55, 25);
            this.ToolStrip.TabIndex = 0;
            this.ToolStrip.Text = "toolStrip1";
            // 
            // WaveTypeButton
            // 
            this.WaveTypeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.WaveTypeButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FixedValue,
            this.SineWave,
            this.TriangleWave,
            this.ForwardSawtooth,
            this.BackwardSawtooth,
            this.SquareWave,
            this.toolStripMenuItem1,
            this.RandomLevels,
            this.CustomWave});
            this.WaveTypeButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WaveTypeButton.Image = ((System.Drawing.Image)(resources.GetObject("WaveTypeButton.Image")));
            this.WaveTypeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WaveTypeButton.Name = "WaveTypeButton";
            this.WaveTypeButton.Size = new System.Drawing.Size(32, 22);
            this.WaveTypeButton.Text = "toolStripSplitButton1";
            // 
            // FixedValue
            // 
            this.FixedValue.Image = global::TabbyCat.Controls.Properties.Resources.CutHS;
            this.FixedValue.ImageTransparentColor = System.Drawing.Color.White;
            this.FixedValue.Name = "FixedValue";
            this.FixedValue.Size = new System.Drawing.Size(188, 22);
            this.FixedValue.Text = "Fixed value";
            // 
            // SineWave
            // 
            this.SineWave.Image = global::TabbyCat.Controls.Properties.Resources.CopyHS;
            this.SineWave.ImageTransparentColor = System.Drawing.Color.White;
            this.SineWave.Name = "SineWave";
            this.SineWave.Size = new System.Drawing.Size(188, 22);
            this.SineWave.Text = "Sine wave";
            // 
            // TriangleWave
            // 
            this.TriangleWave.Image = global::TabbyCat.Controls.Properties.Resources.PasteHS;
            this.TriangleWave.ImageTransparentColor = System.Drawing.Color.White;
            this.TriangleWave.Name = "TriangleWave";
            this.TriangleWave.Size = new System.Drawing.Size(188, 22);
            this.TriangleWave.Text = "Triangle wave";
            // 
            // ForwardSawtooth
            // 
            this.ForwardSawtooth.Image = global::TabbyCat.Controls.Properties.Resources.Delete;
            this.ForwardSawtooth.ImageTransparentColor = System.Drawing.Color.White;
            this.ForwardSawtooth.Name = "ForwardSawtooth";
            this.ForwardSawtooth.Size = new System.Drawing.Size(188, 22);
            this.ForwardSawtooth.Text = "Forward sawtooth";
            // 
            // BackwardSawtooth
            // 
            this.BackwardSawtooth.Image = global::TabbyCat.Controls.Properties.Resources.Edit_UndoHS;
            this.BackwardSawtooth.ImageTransparentColor = System.Drawing.Color.White;
            this.BackwardSawtooth.Name = "BackwardSawtooth";
            this.BackwardSawtooth.Size = new System.Drawing.Size(188, 22);
            this.BackwardSawtooth.Text = "Backward sawtooth";
            // 
            // SquareWave
            // 
            this.SquareWave.Image = global::TabbyCat.Controls.Properties.Resources.Edit_RedoHS;
            this.SquareWave.ImageTransparentColor = System.Drawing.Color.White;
            this.SquareWave.Name = "SquareWave";
            this.SquareWave.Size = new System.Drawing.Size(188, 22);
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
            this.RandomLevels.Text = "Random levels";
            // 
            // CustomWave
            // 
            this.CustomWave.Image = global::TabbyCat.Controls.Properties.Resources.PrintHS;
            this.CustomWave.ImageTransparentColor = System.Drawing.Color.White;
            this.CustomWave.Name = "CustomWave";
            this.CustomWave.Size = new System.Drawing.Size(188, 22);
            this.CustomWave.Text = "Custom wave";
            // 
            // DeleteButton
            // 
            this.DeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Image = global::TabbyCat.Controls.Properties.Resources.Delete;
            this.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(23, 20);
            this.DeleteButton.Text = "toolStripButton1";
            // 
            // SignalToolbar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.ToolStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SignalToolbar";
            this.Size = new System.Drawing.Size(55, 25);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip ToolStrip;
        public System.Windows.Forms.ToolStripSplitButton WaveTypeButton;
        public System.Windows.Forms.ToolStripButton DeleteButton;
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
