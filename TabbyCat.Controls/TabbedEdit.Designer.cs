namespace TabbyCat.Controls
{
    partial class TabbedEdit
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
            this.ScenePropertiesControl = new TabbyCatControls.ScenePropertiesControl();
            this.tpTraces = new System.Windows.Forms.TabPage();
            this.TracePropertiesControl = new TabbyCatControls.TracePropertiesControl();
            this.ShaderEdit = new TabbyCat.Controls.ShaderEdit();
            this.TabControl.SuspendLayout();
            this.tpScene.SuspendLayout();
            this.tpTraces.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tpScene);
            this.TabControl.Controls.Add(this.tpTraces);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(334, 314);
            this.TabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.TabControl.TabIndex = 2;
            // 
            // tpScene
            // 
            this.tpScene.Controls.Add(this.ScenePropertiesControl);
            this.tpScene.Location = new System.Drawing.Point(4, 22);
            this.tpScene.Name = "tpScene";
            this.tpScene.Padding = new System.Windows.Forms.Padding(3);
            this.tpScene.Size = new System.Drawing.Size(326, 288);
            this.tpScene.TabIndex = 0;
            this.tpScene.Text = "Scene";
            this.tpScene.UseVisualStyleBackColor = true;
            // 
            // ScenePropertiesControl
            // 
            this.ScenePropertiesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScenePropertiesControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScenePropertiesControl.Location = new System.Drawing.Point(3, 3);
            this.ScenePropertiesControl.MinimumSize = new System.Drawing.Size(320, 280);
            this.ScenePropertiesControl.Name = "ScenePropertiesControl";
            this.ScenePropertiesControl.Size = new System.Drawing.Size(320, 282);
            this.ScenePropertiesControl.TabIndex = 1;
            // 
            // tpTraces
            // 
            this.tpTraces.Controls.Add(this.TracePropertiesControl);
            this.tpTraces.Location = new System.Drawing.Point(4, 22);
            this.tpTraces.Name = "tpTraces";
            this.tpTraces.Padding = new System.Windows.Forms.Padding(3);
            this.tpTraces.Size = new System.Drawing.Size(324, 288);
            this.tpTraces.TabIndex = 1;
            this.tpTraces.Text = "Trace";
            this.tpTraces.UseVisualStyleBackColor = true;
            // 
            // TracePropertiesControl
            // 
            this.TracePropertiesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TracePropertiesControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TracePropertiesControl.Location = new System.Drawing.Point(3, 3);
            this.TracePropertiesControl.MinimumSize = new System.Drawing.Size(320, 256);
            this.TracePropertiesControl.Name = "TracePropertiesControl";
            this.TracePropertiesControl.Size = new System.Drawing.Size(320, 282);
            this.TracePropertiesControl.TabIndex = 0;
            // 
            // shaderEdit1
            // 
            this.ShaderEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShaderEdit.Location = new System.Drawing.Point(0, 314);
            this.ShaderEdit.MinimumSize = new System.Drawing.Size(334, 0);
            this.ShaderEdit.Name = "shaderEdit1";
            this.ShaderEdit.Size = new System.Drawing.Size(334, 280);
            this.ShaderEdit.TabIndex = 3;
            // 
            // TabbedEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ShaderEdit);
            this.Controls.Add(this.TabControl);
            this.Name = "TabbedEdit";
            this.Size = new System.Drawing.Size(334, 594);
            this.TabControl.ResumeLayout(false);
            this.tpScene.ResumeLayout(false);
            this.tpTraces.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl TabControl;
        public System.Windows.Forms.TabPage tpScene;
        public TabbyCatControls.ScenePropertiesControl ScenePropertiesControl;
        public System.Windows.Forms.TabPage tpTraces;
        public TabbyCatControls.TracePropertiesControl TracePropertiesControl;
        public ShaderEdit ShaderEdit;
    }
}
