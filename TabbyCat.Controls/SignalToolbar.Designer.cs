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
            this.Constant = new System.Windows.Forms.ToolStripMenuItem();
            this.Sine = new System.Windows.Forms.ToolStripMenuItem();
            this.Square = new System.Windows.Forms.ToolStripMenuItem();
            this.Triangle = new System.Windows.Forms.ToolStripMenuItem();
            this.Sawtooth = new System.Windows.Forms.ToolStripMenuItem();
            this.BackwardSawtooth = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.Custom = new System.Windows.Forms.ToolStripMenuItem();
            this.Noise = new System.Windows.Forms.ToolStripMenuItem();
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
            this.Constant,
            this.Sine,
            this.Square,
            this.Triangle,
            this.Sawtooth,
            this.BackwardSawtooth,
            this.toolStripMenuItem1,
            this.Custom,
            this.Noise});
            this.WaveTypeButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WaveTypeButton.Image = ((System.Drawing.Image)(resources.GetObject("WaveTypeButton.Image")));
            this.WaveTypeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WaveTypeButton.Name = "WaveTypeButton";
            this.WaveTypeButton.Size = new System.Drawing.Size(32, 22);
            this.WaveTypeButton.Text = "toolStripSplitButton1";
            // 
            // FixedValue
            // 
            this.Constant.Image = global::TabbyCat.Controls.Properties.Resources.WaveTypeDC;
            this.Constant.ImageTransparentColor = System.Drawing.Color.White;
            this.Constant.Name = "FixedValue";
            this.Constant.Size = new System.Drawing.Size(180, 22);
            this.Constant.Text = "Constant";
            // 
            // SineWave
            // 
            this.Sine.Image = global::TabbyCat.Controls.Properties.Resources.WaveTypeSine;
            this.Sine.ImageTransparentColor = System.Drawing.Color.White;
            this.Sine.Name = "SineWave";
            this.Sine.Size = new System.Drawing.Size(180, 22);
            this.Sine.Text = "Sine wave";
            // 
            // SquareWave
            // 
            this.Square.Image = global::TabbyCat.Controls.Properties.Resources.WaveTypeSquare;
            this.Square.ImageTransparentColor = System.Drawing.Color.White;
            this.Square.Name = "SquareWave";
            this.Square.Size = new System.Drawing.Size(180, 22);
            this.Square.Text = "Square wave";
            // 
            // TriangleWave
            // 
            this.Triangle.Image = global::TabbyCat.Controls.Properties.Resources.WaveTypeTriangle;
            this.Triangle.ImageTransparentColor = System.Drawing.Color.White;
            this.Triangle.Name = "TriangleWave";
            this.Triangle.Size = new System.Drawing.Size(180, 22);
            this.Triangle.Text = "Triangle wave";
            // 
            // ForwardSawtooth
            // 
            this.Sawtooth.Image = global::TabbyCat.Controls.Properties.Resources.WaveTypeSawtooth;
            this.Sawtooth.ImageTransparentColor = System.Drawing.Color.White;
            this.Sawtooth.Name = "ForwardSawtooth";
            this.Sawtooth.Size = new System.Drawing.Size(180, 22);
            this.Sawtooth.Text = "Sawtooth";
            // 
            // BackwardSawtooth
            // 
            this.BackwardSawtooth.Image = global::TabbyCat.Controls.Properties.Resources.WaveTypeReverseSawtooth;
            this.BackwardSawtooth.ImageTransparentColor = System.Drawing.Color.White;
            this.BackwardSawtooth.Name = "BackwardSawtooth";
            this.BackwardSawtooth.Size = new System.Drawing.Size(180, 22);
            this.BackwardSawtooth.Text = "Reverse sawtooth";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // CustomWave
            // 
            this.Custom.Image = global::TabbyCat.Controls.Properties.Resources.WaveTypeCustom;
            this.Custom.ImageTransparentColor = System.Drawing.Color.White;
            this.Custom.Name = "CustomWave";
            this.Custom.Size = new System.Drawing.Size(180, 22);
            this.Custom.Text = "Custom";
            // 
            // RandomLevels
            // 
            this.Noise.Image = global::TabbyCat.Controls.Properties.Resources.WaveTypeRandom;
            this.Noise.ImageTransparentColor = System.Drawing.Color.White;
            this.Noise.Name = "RandomLevels";
            this.Noise.Size = new System.Drawing.Size(180, 22);
            this.Noise.Text = "Noise";
            // 
            // DeleteButton
            // 
            this.DeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Image = global::TabbyCat.Controls.Properties.Resources.Delete;
            this.DeleteButton.ImageTransparentColor = System.Drawing.Color.White;
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
        public System.Windows.Forms.ToolStripMenuItem Constant;
        public System.Windows.Forms.ToolStripMenuItem Sine;
        public System.Windows.Forms.ToolStripMenuItem Square;
        public System.Windows.Forms.ToolStripMenuItem Triangle;
        public System.Windows.Forms.ToolStripMenuItem Sawtooth;
        public System.Windows.Forms.ToolStripMenuItem BackwardSawtooth;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem Custom;
        public System.Windows.Forms.ToolStripMenuItem Noise;
    }
}
