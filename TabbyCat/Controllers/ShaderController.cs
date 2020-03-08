namespace TabbyCat.Controllers
{
    using FastColoredTextBoxNS;
    using OpenTK.Graphics.OpenGL;
    using System.IO;
    using System.Windows.Forms;
    using TabbyCat.Controls;
    using TabbyCat.Views;

    internal class ShaderController
    {
        #region Constructors

        internal ShaderController(PropertyController propertyController)
        {
            PropertyController = propertyController;
            new GLPageController(PrimaryTextBox);
            new GLPageController(SecondaryTextBox);
            Editor.miVertex.Tag = ShaderType.VertexShader;
            Editor.miTessellationControl.Tag = ShaderType.TessControlShader;
            Editor.miTessellationEvaluation.Tag = ShaderType.TessEvaluationShader;
            Editor.miGeometry.Tag = ShaderType.GeometryShader;
            Editor.miFragment.Tag = ShaderType.FragmentShader;
            Editor.miCompute.Tag = ShaderType.ComputeShader;
        }

        #endregion

        #region Fields & Properties

        internal ShaderEdit Editor => PropertyEditor.ShaderEdit;

        private Orientation Orientation { get => Splitter.Orientation; set => SetSplit(value); }
        private SplitContainer PrimarySplitter => Editor.PrimarySplitter;
        private FastColoredTextBox PrimaryTextBox => Editor.PrimaryTextBox;
        private readonly PropertyController PropertyController;
        private TabbedEdit PropertyEditor => PropertyController.Editor;
        private SceneController SceneController => PropertyController.SceneController;
        private SceneForm SceneForm => SceneController.SceneForm;
        private SplitContainer SecondarySplitter => Editor.SecondarySplitter;
        private FastColoredTextBox SecondaryTextBox => Editor.SecondaryTextBox;
        private SplitContainer Splitter => Editor.Splitter;

        private bool UseScene => PropertyEditor.TabControl.SelectedIndex == 0;

        private bool ShowDocumentMap
        {
            get => !PrimarySplitter.Panel2Collapsed;
            set => PrimarySplitter.Panel2Collapsed = SecondarySplitter.Panel2Collapsed = !value;
        }

        private bool ShowLineNumbers
        {
            get => PrimaryTextBox.ShowLineNumbers;
            set
            {
                PrimaryTextBox.ShowLineNumbers = SecondaryTextBox.ShowLineNumbers = value;
                Editor.Refresh();
            }
        }

        private bool ShowRuler
        {
            get => Editor.PrimaryRuler.Visible;
            set
            {
                Editor.PrimaryRuler.Visible = Editor.SecondaryRuler.Visible = value;
                Editor.Refresh();
            }
        }

        #endregion

        #region Private Event Handlers

        private void DocumentMap_Click(object sender, System.EventArgs e) =>
            ShowDocumentMap = !ShowDocumentMap;

        private void ExportHTML_Click(object sender, System.EventArgs e)
        {
            using (var dialog = new SaveFileDialog
            {
                Filter = "HTML with <PRE>|*.html|HTML without <PRE>|*.html",
                Title = "Export as HTML"
            })
                if (dialog.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(dialog.FileName, GetHTML(dialog.FilterIndex));
        }

        private void ExportRTF_Click(object sender, System.EventArgs e)
        {
            using (var dialog = new SaveFileDialog
            {
                Filter = "Rich Text Format|*.rtf",
                Title = "Export As RTF"
            })
                if (dialog.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(dialog.FileName, PrimaryTextBox.Rtf);
        }

        private void Help_Click(object sender, System.EventArgs e) => HotkeysController.Show(SceneForm);

        private void LineNumbers_Click(object sender, System.EventArgs e) =>
            ShowLineNumbers = !ShowLineNumbers;

        private void Options_DropDownOpening(object sender, System.EventArgs e)
        {
            Editor.btnRuler.Checked = ShowRuler;
            Editor.btnLineNumbers.Checked = ShowLineNumbers;
            Editor.btnDocumentMap.Checked = ShowDocumentMap;
            Editor.btnSplit.Checked = Orientation == Orientation.Vertical;
        }

        private void Print_Click(object sender, System.EventArgs e) =>
            PrimaryTextBox.Print(new PrintDialogSettings() { ShowPrintPreviewDialog = true });

        private void Ruler_Click(object sender, System.EventArgs e) => ShowRuler = !ShowRuler;

        private void Split_Click(object sender, System.EventArgs e) => ToggleSplit();

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) => UpdateUI();

        #endregion

        #region Private Methods

        internal void Connect(bool connect)
        {
            if (connect)
            {
                Editor.btnShader.DropDownOpening += Shader_DropDownOpening;
                Editor.miVertex.Click += Shader_Click;
                Editor.miTessellationControl.Click += Shader_Click;
                Editor.miTessellationEvaluation.Click += Shader_Click;
                Editor.miGeometry.Click += Shader_Click;
                Editor.miFragment.Click += Shader_Click;
                Editor.miCompute.Click += Shader_Click;
                Editor.btnDocumentMap.Click += DocumentMap_Click;
                Editor.btnExportHTML.Click += ExportHTML_Click;
                Editor.btnExportRTF.Click += ExportRTF_Click;
                Editor.btnHelp.Click += Help_Click;
                Editor.btnLineNumbers.Click += LineNumbers_Click;
                Editor.btnOptions.DropDownOpening += Options_DropDownOpening;
                Editor.btnPrint.Click += Print_Click;
                Editor.btnRuler.Click += Ruler_Click;
                Editor.btnSplit.Click += Split_Click;
                Editor.PrimaryTextBox.TextChanged += TextBox_TextChanged;
                Editor.SecondaryTextBox.TextChanged += TextBox_TextChanged;
            }
            else
            {
                Editor.btnDocumentMap.Click -= DocumentMap_Click;
                Editor.btnExportHTML.Click -= ExportHTML_Click;
                Editor.btnExportRTF.Click -= ExportRTF_Click;
                Editor.btnHelp.Click -= Help_Click;
                Editor.btnLineNumbers.Click -= LineNumbers_Click;
                Editor.btnOptions.DropDownOpening -= Options_DropDownOpening;
                Editor.btnPrint.Click -= Print_Click;
                Editor.btnRuler.Click -= Ruler_Click;
                Editor.btnSplit.Click -= Split_Click;
                Editor.PrimaryTextBox.TextChanged -= TextBox_TextChanged;
                Editor.SecondaryTextBox.TextChanged -= TextBox_TextChanged;
            }
        }

        private void Shader_DropDownOpening(object sender, System.EventArgs e)
        {
            foreach (ToolStripMenuItem item in ((ToolStripDropDownItem)sender).DropDownItems)
                item.Checked = (ShaderType)item.Tag == ShaderType;
        }

        private ShaderType _ShaderType = ShaderType.VertexShader;
        private ShaderType ShaderType
        {
            get => _ShaderType;
            set
            {
                if (ShaderType != value)
                {
                    _ShaderType = value;
                    GetShaderCode();
                }
            }
        }

        private void GetShaderCode()
        {

        }

        private void Shader_Click(object sender, System.EventArgs e) =>
            ShaderType = (ShaderType)((ToolStripItem)sender).Tag;

        private string GetHTML(int filterIndex)
        {
            switch (filterIndex)
            {
                case 1:
                    return PrimaryTextBox.Html;
                case 2:
                    return new ExportToHTML { UseNbsp = false, UseForwardNbsp = true }.GetHtml(PrimaryTextBox);
                default:
                    return string.Empty;
            }
        }

        private void SetSplit(Orientation orientation)
        {
            Splitter.Orientation = orientation;
            var size = Orientation == Orientation.Horizontal
                ? Splitter.Height
                : Splitter.Width;
            SetSplitSize(size / 2 - 2);
        }

        private void SetSplitSize(int size) => Splitter.SplitterDistance = size;

        private void ToggleSplit() =>
            SetSplit(Splitter.SplitterDistance == 0 || Orientation == Orientation.Vertical
                ? Orientation.Horizontal
                : Orientation.Vertical);

        private void UpdateUI()
        {
            Editor.btnExport.Enabled =
                Editor.btnPrint.Enabled =
                Editor.PrimaryTextBox.Text != string.Empty;
        }

        #endregion
    }
}
