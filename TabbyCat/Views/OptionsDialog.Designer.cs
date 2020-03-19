namespace TabbyCat.Views
{
    partial class OptionsDialog
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbWindowReuse = new System.Windows.Forms.RadioButton();
            this.rbWindowNew = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTemplatesFolder = new System.Windows.Forms.Button();
            this.btnFilesFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.edTemplatesFolder = new System.Windows.Forms.TextBox();
            this.edFilesFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.tpGLSLStyles = new System.Windows.Forms.TabPage();
            this.GLSLStylesPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.edGLSLUrl = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.tpGLSLStyles.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbWindowReuse);
            this.groupBox1.Controls.Add(this.rbWindowNew);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "When creating a new scene, or reopening an existing one:";
            // 
            // rbWindowReuse
            // 
            this.rbWindowReuse.AutoSize = true;
            this.rbWindowReuse.Location = new System.Drawing.Point(8, 48);
            this.rbWindowReuse.Name = "rbWindowReuse";
            this.rbWindowReuse.Size = new System.Drawing.Size(279, 19);
            this.rbWindowReuse.TabIndex = 1;
            this.rbWindowReuse.Text = "&Reuse the current window (saving any changes).";
            this.rbWindowReuse.UseVisualStyleBackColor = true;
            // 
            // rbWindowNew
            // 
            this.rbWindowNew.AutoSize = true;
            this.rbWindowNew.Location = new System.Drawing.Point(8, 22);
            this.rbWindowNew.Name = "rbWindowNew";
            this.rbWindowNew.Size = new System.Drawing.Size(237, 19);
            this.rbWindowNew.TabIndex = 0;
            this.rbWindowNew.Text = "&Create a new window for the new scene.";
            this.rbWindowNew.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(289, 284);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 27);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(382, 284);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnTemplatesFolder);
            this.groupBox3.Controls.Add(this.btnFilesFolder);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.edTemplatesFolder);
            this.groupBox3.Controls.Add(this.edFilesFolder);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(6, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(441, 87);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Default folders";
            // 
            // btnTemplatesFolder
            // 
            this.btnTemplatesFolder.FlatAppearance.BorderSize = 0;
            this.btnTemplatesFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemplatesFolder.Image = global::TabbyCat.Properties.Resources.FolderHS;
            this.btnTemplatesFolder.Location = new System.Drawing.Point(406, 52);
            this.btnTemplatesFolder.Name = "btnTemplatesFolder";
            this.btnTemplatesFolder.Size = new System.Drawing.Size(23, 23);
            this.btnTemplatesFolder.TabIndex = 5;
            this.btnTemplatesFolder.UseVisualStyleBackColor = true;
            // 
            // btnFilesFolder
            // 
            this.btnFilesFolder.FlatAppearance.BorderSize = 0;
            this.btnFilesFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilesFolder.Image = global::TabbyCat.Properties.Resources.FolderHS;
            this.btnFilesFolder.Location = new System.Drawing.Point(406, 22);
            this.btnFilesFolder.Name = "btnFilesFolder";
            this.btnFilesFolder.Size = new System.Drawing.Size(23, 23);
            this.btnFilesFolder.TabIndex = 4;
            this.btnFilesFolder.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "&Templates:";
            // 
            // edTemplatesFolder
            // 
            this.edTemplatesFolder.BackColor = System.Drawing.SystemColors.Control;
            this.edTemplatesFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edTemplatesFolder.Location = new System.Drawing.Point(84, 55);
            this.edTemplatesFolder.Name = "edTemplatesFolder";
            this.edTemplatesFolder.Size = new System.Drawing.Size(322, 16);
            this.edTemplatesFolder.TabIndex = 2;
            // 
            // edFilesFolder
            // 
            this.edFilesFolder.BackColor = System.Drawing.SystemColors.Control;
            this.edFilesFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edFilesFolder.Location = new System.Drawing.Point(84, 27);
            this.edFilesFolder.Name = "edFilesFolder";
            this.edFilesFolder.Size = new System.Drawing.Size(322, 16);
            this.edFilesFolder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scene &Files:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.edGLSLUrl);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(6, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(441, 51);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "OpenGL Shading Language";
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tpGeneral);
            this.TabControl.Controls.Add(this.tpGLSLStyles);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(461, 266);
            this.TabControl.TabIndex = 6;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.groupBox1);
            this.tpGeneral.Controls.Add(this.groupBox2);
            this.tpGeneral.Controls.Add(this.groupBox3);
            this.tpGeneral.Location = new System.Drawing.Point(4, 24);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(453, 238);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // tpGLSLStyles
            // 
            this.tpGLSLStyles.Controls.Add(this.GLSLStylesPropertyGrid);
            this.tpGLSLStyles.Location = new System.Drawing.Point(4, 24);
            this.tpGLSLStyles.Name = "tpGLSLStyles";
            this.tpGLSLStyles.Padding = new System.Windows.Forms.Padding(3);
            this.tpGLSLStyles.Size = new System.Drawing.Size(453, 238);
            this.tpGLSLStyles.TabIndex = 1;
            this.tpGLSLStyles.Text = "Editor";
            this.tpGLSLStyles.UseVisualStyleBackColor = true;
            // 
            // GLSLStylesPropertyGrid
            // 
            this.GLSLStylesPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GLSLStylesPropertyGrid.Location = new System.Drawing.Point(3, 3);
            this.GLSLStylesPropertyGrid.Name = "GLSLStylesPropertyGrid";
            this.GLSLStylesPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.GLSLStylesPropertyGrid.Size = new System.Drawing.Size(447, 232);
            this.GLSLStylesPropertyGrid.TabIndex = 0;
            this.GLSLStylesPropertyGrid.ToolbarVisible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Specification URL:";
            // 
            // edGLSLUrl
            // 
            this.edGLSLUrl.BackColor = System.Drawing.SystemColors.Control;
            this.edGLSLUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edGLSLUrl.Location = new System.Drawing.Point(115, 24);
            this.edGLSLUrl.Name = "edGLSLUrl";
            this.edGLSLUrl.Size = new System.Drawing.Size(314, 16);
            this.edGLSLUrl.TabIndex = 3;
            // 
            // OptionsDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(482, 320);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpGLSLStyles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.RadioButton rbWindowReuse;
        internal System.Windows.Forms.RadioButton rbWindowNew;
        internal System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Button btnTemplatesFolder;
        internal System.Windows.Forms.Button btnFilesFolder;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox edTemplatesFolder;
        internal System.Windows.Forms.TextBox edFilesFolder;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.TabControl TabControl;
        internal System.Windows.Forms.TabPage tpGeneral;
        internal System.Windows.Forms.TabPage tpGLSLStyles;
        internal System.Windows.Forms.PropertyGrid GLSLStylesPropertyGrid;
        internal System.Windows.Forms.TextBox edGLSLUrl;
        internal System.Windows.Forms.Label label3;
    }
}