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
            this.TracePropertiesControl = new TabbyCatControls.TracePropertiesControl();
            this.ScenePropertiesControl = new TabbyCatControls.ScenePropertiesControl();
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
            this.TabControl.Size = new System.Drawing.Size(416, 369);
            this.TabControl.TabIndex = 0;
            // 
            // tpScene
            // 
            this.tpScene.Controls.Add(this.ScenePropertiesControl);
            this.tpScene.Location = new System.Drawing.Point(4, 24);
            this.tpScene.Name = "tpScene";
            this.tpScene.Padding = new System.Windows.Forms.Padding(3);
            this.tpScene.Size = new System.Drawing.Size(408, 341);
            this.tpScene.TabIndex = 0;
            this.tpScene.Text = "Scene";
            this.tpScene.UseVisualStyleBackColor = true;
            // 
            // tpTraces
            // 
            this.tpTraces.Controls.Add(this.TracePropertiesControl);
            this.tpTraces.Location = new System.Drawing.Point(4, 24);
            this.tpTraces.Name = "tpTraces";
            this.tpTraces.Padding = new System.Windows.Forms.Padding(3);
            this.tpTraces.Size = new System.Drawing.Size(408, 341);
            this.tpTraces.TabIndex = 1;
            this.tpTraces.Text = "Trace";
            this.tpTraces.UseVisualStyleBackColor = true;
            // 
            // TracePropertiesControl
            // 
            this.TracePropertiesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TracePropertiesControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TracePropertiesControl.Location = new System.Drawing.Point(3, 3);
            this.TracePropertiesControl.Name = "TracePropertiesControl";
            this.TracePropertiesControl.Size = new System.Drawing.Size(402, 335);
            this.TracePropertiesControl.TabIndex = 0;
            // 
            // ScenePropertiesControl
            // 
            this.ScenePropertiesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScenePropertiesControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScenePropertiesControl.Location = new System.Drawing.Point(3, 3);
            this.ScenePropertiesControl.Name = "ScenePropertiesControl";
            this.ScenePropertiesControl.Size = new System.Drawing.Size(402, 335);
            this.ScenePropertiesControl.TabIndex = 1;
            // 
            // PropertyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 369);
            this.Controls.Add(this.TabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PropertyEditor";
            this.Text = "Properties";
            this.TabControl.ResumeLayout(false);
            this.tpScene.ResumeLayout(false);
            this.tpTraces.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl;
        internal System.Windows.Forms.TabPage tpScene;
        internal System.Windows.Forms.TabPage tpTraces;
        internal TabbyCatControls.TracePropertiesControl TracePropertiesControl;
        internal TabbyCatControls.ScenePropertiesControl ScenePropertiesControl;
    }
}