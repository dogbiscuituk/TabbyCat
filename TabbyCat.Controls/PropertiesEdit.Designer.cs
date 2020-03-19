namespace TabbyCat.Controls
{
    partial class PropertiesEdit
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tpScene = new System.Windows.Forms.TabPage();
            this.SceneEdit = new TabbyCatControls.SceneEdit();
            this.tpTraces = new System.Windows.Forms.TabPage();
            this.TraceEdit = new TabbyCatControls.TraceEdit();
            this.tpGPU = new System.Windows.Forms.TabPage();
            this.lblGPULog = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ShaderEdit = new TabbyCat.Controls.ShaderEdit();
            this.TabControl.SuspendLayout();
            this.tpScene.SuspendLayout();
            this.tpTraces.SuspendLayout();
            this.tpGPU.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tpScene);
            this.TabControl.Controls.Add(this.tpTraces);
            this.TabControl.Controls.Add(this.tpGPU);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(390, 384);
            this.TabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.TabControl.TabIndex = 2;
            // 
            // tpScene
            // 
            this.tpScene.Controls.Add(this.SceneEdit);
            this.tpScene.Location = new System.Drawing.Point(4, 22);
            this.tpScene.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpScene.Name = "tpScene";
            this.tpScene.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpScene.Size = new System.Drawing.Size(382, 358);
            this.tpScene.TabIndex = 0;
            this.tpScene.Text = "Scene";
            this.tpScene.UseVisualStyleBackColor = true;
            // 
            // SceneEdit
            // 
            this.SceneEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SceneEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SceneEdit.Location = new System.Drawing.Point(3, 4);
            this.SceneEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SceneEdit.Name = "SceneEdit";
            this.SceneEdit.Size = new System.Drawing.Size(376, 350);
            this.SceneEdit.TabIndex = 1;
            // 
            // tpTraces
            // 
            this.tpTraces.Controls.Add(this.TraceEdit);
            this.tpTraces.Location = new System.Drawing.Point(4, 22);
            this.tpTraces.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpTraces.Name = "tpTraces";
            this.tpTraces.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpTraces.Size = new System.Drawing.Size(382, 358);
            this.tpTraces.TabIndex = 1;
            this.tpTraces.Text = "Trace";
            this.tpTraces.UseVisualStyleBackColor = true;
            // 
            // TraceEdit
            // 
            this.TraceEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TraceEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TraceEdit.Location = new System.Drawing.Point(3, 4);
            this.TraceEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TraceEdit.MinimumSize = new System.Drawing.Size(373, 335);
            this.TraceEdit.Name = "TraceEdit";
            this.TraceEdit.Size = new System.Drawing.Size(376, 350);
            this.TraceEdit.TabIndex = 0;
            // 
            // tpGPU
            // 
            this.tpGPU.AutoScroll = true;
            this.tpGPU.Controls.Add(this.lblGPULog);
            this.tpGPU.Controls.Add(this.label1);
            this.tpGPU.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpGPU.Location = new System.Drawing.Point(4, 26);
            this.tpGPU.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpGPU.Name = "tpGPU";
            this.tpGPU.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpGPU.Size = new System.Drawing.Size(382, 354);
            this.tpGPU.TabIndex = 2;
            this.tpGPU.Text = "GPU";
            this.tpGPU.UseVisualStyleBackColor = true;
            // 
            // lblGPULog
            // 
            this.lblGPULog.AutoSize = true;
            this.lblGPULog.Location = new System.Drawing.Point(3, 29);
            this.lblGPULog.Name = "lblGPULog";
            this.lblGPULog.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblGPULog.Size = new System.Drawing.Size(164, 23);
            this.lblGPULog.TabIndex = 2;
            this.lblGPULog.Text = "GPU Log will appear here.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label1.Size = new System.Drawing.Size(31, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Log";
            // 
            // ShaderEdit
            // 
            this.ShaderEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShaderEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShaderEdit.Location = new System.Drawing.Point(0, 384);
            this.ShaderEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ShaderEdit.MinimumSize = new System.Drawing.Size(390, 0);
            this.ShaderEdit.Name = "ShaderEdit";
            this.ShaderEdit.Size = new System.Drawing.Size(390, 393);
            this.ShaderEdit.TabIndex = 3;
            // 
            // PropertiesEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ShaderEdit);
            this.Controls.Add(this.TabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PropertiesEdit";
            this.Size = new System.Drawing.Size(390, 777);
            this.TabControl.ResumeLayout(false);
            this.tpScene.ResumeLayout(false);
            this.tpTraces.ResumeLayout(false);
            this.tpGPU.ResumeLayout(false);
            this.tpGPU.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl TabControl;
        public System.Windows.Forms.TabPage tpScene;
        public TabbyCatControls.SceneEdit SceneEdit;
        public System.Windows.Forms.TabPage tpTraces;
        public TabbyCatControls.TraceEdit TraceEdit;
        public ShaderEdit ShaderEdit;
        public System.Windows.Forms.TabPage tpGPU;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblGPULog;
    }
}
