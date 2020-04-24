namespace TabbyCat.Views
{
    partial class ParametersForm
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
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FrequencyHeader = new System.Windows.Forms.Label();
            this.AmplitudeHeader = new System.Windows.Forms.Label();
            this.TableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.AutoSize = true;
            this.TableLayoutPanel.ColumnCount = 4;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel.Controls.Add(this.AmplitudeHeader, 1, 0);
            this.TableLayoutPanel.Controls.Add(this.FrequencyHeader, 2, 0);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 2;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(251, 42);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // FrequencyHeader
            // 
            this.FrequencyHeader.AutoSize = true;
            this.FrequencyHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrequencyHeader.Location = new System.Drawing.Point(128, 0);
            this.FrequencyHeader.Name = "FrequencyHeader";
            this.FrequencyHeader.Size = new System.Drawing.Size(119, 17);
            this.FrequencyHeader.TabIndex = 6;
            this.FrequencyHeader.Text = "Frequency";
            this.FrequencyHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AmplitudeHeader
            // 
            this.AmplitudeHeader.AutoSize = true;
            this.AmplitudeHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AmplitudeHeader.Location = new System.Drawing.Point(3, 0);
            this.AmplitudeHeader.Name = "AmplitudeHeader";
            this.AmplitudeHeader.Size = new System.Drawing.Size(119, 17);
            this.AmplitudeHeader.TabIndex = 5;
            this.AmplitudeHeader.Text = "Amplitude";
            this.AmplitudeHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ParametersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(251, 175);
            this.Controls.Add(this.TableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ParametersForm";
            this.TabText = "Controls";
            this.Text = "Controls";
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        internal System.Windows.Forms.Label AmplitudeHeader;
        internal System.Windows.Forms.Label FrequencyHeader;
    }
}