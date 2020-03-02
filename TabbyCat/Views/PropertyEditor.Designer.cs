namespace TabbyCat.Views
{
    partial class PropertyEditor
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tpScene = new System.Windows.Forms.TabPage();
            this.tpTraces = new System.Windows.Forms.TabPage();
            this.scenePropertiesControl1 = new TabbyCatControls.ScenePropertiesControl();
            this.tracePropertiesControl1 = new TabbyCatControls.TracePropertiesControl();
            this.TabControl.SuspendLayout();
            this.tpScene.SuspendLayout();
            this.tpTraces.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tpScene);
            this.TabControl.Controls.Add(this.tpTraces);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(424, 377);
            this.TabControl.TabIndex = 0;
            // 
            // tpScene
            // 
            this.tpScene.Controls.Add(this.scenePropertiesControl1);
            this.tpScene.Location = new System.Drawing.Point(4, 22);
            this.tpScene.Name = "tpScene";
            this.tpScene.Padding = new System.Windows.Forms.Padding(3);
            this.tpScene.Size = new System.Drawing.Size(416, 351);
            this.tpScene.TabIndex = 0;
            this.tpScene.Text = "Scene";
            this.tpScene.UseVisualStyleBackColor = true;
            // 
            // tpTraces
            // 
            this.tpTraces.Controls.Add(this.tracePropertiesControl1);
            this.tpTraces.Location = new System.Drawing.Point(4, 22);
            this.tpTraces.Name = "tpTraces";
            this.tpTraces.Padding = new System.Windows.Forms.Padding(3);
            this.tpTraces.Size = new System.Drawing.Size(416, 424);
            this.tpTraces.TabIndex = 1;
            this.tpTraces.Text = "Trace";
            this.tpTraces.UseVisualStyleBackColor = true;
            // 
            // scenePropertiesControl1
            // 
            this.scenePropertiesControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scenePropertiesControl1.Location = new System.Drawing.Point(8, 6);
            this.scenePropertiesControl1.Name = "scenePropertiesControl1";
            this.scenePropertiesControl1.Size = new System.Drawing.Size(400, 347);
            this.scenePropertiesControl1.TabIndex = 0;
            // 
            // tracePropertiesControl1
            // 
            this.tracePropertiesControl1.Location = new System.Drawing.Point(8, 6);
            this.tracePropertiesControl1.Name = "tracePropertiesControl1";
            this.tracePropertiesControl1.Size = new System.Drawing.Size(400, 254);
            this.tracePropertiesControl1.TabIndex = 0;
            // 
            // PropertyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 377);
            this.Controls.Add(this.TabControl);
            this.Name = "PropertyEditor";
            this.Text = "Property Editor";
            this.TabControl.ResumeLayout(false);
            this.tpScene.ResumeLayout(false);
            this.tpTraces.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tpScene;
        private System.Windows.Forms.TabPage tpTraces;
        private TabbyCatControls.ScenePropertiesControl scenePropertiesControl1;
        private TabbyCatControls.TracePropertiesControl tracePropertiesControl1;
    }
}