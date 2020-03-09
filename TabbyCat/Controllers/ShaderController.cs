namespace TabbyCat.Controllers
{
    using FastColoredTextBoxNS;
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;
    using TabbyCat.Commands;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.Controls;
    using TabbyCat.Models;
    using TabbyCat.Views;

    internal class ShaderController
    {
        #region Constructors

        internal ShaderController(PropertiesController propertiesController)
        {
            PropertiesController = propertiesController;
            new GLPageController(PrimaryTextBox);
            new GLPageController(SecondaryTextBox);
            Editor.miVertex.Tag = ShaderType.VertexShader;
            Editor.miTessellationControl.Tag = ShaderType.TessControlShader;
            Editor.miTessellationEvaluation.Tag = ShaderType.TessEvaluationShader;
            Editor.miGeometry.Tag = ShaderType.GeometryShader;
            Editor.miFragment.Tag = ShaderType.FragmentShader;
            Editor.miCompute.Tag = ShaderType.ComputeShader;
            ShowRuler = false;
            ShowLineNumbers = false;
            ShowDocumentMap = false;
            SplitType = SplitType.None;
            LoadShaderCode();
        }

        #endregion

        #region Fields & Properties

        internal ShaderEdit Editor => PropertiesEditor.ShaderEdit;

        private CommandProcessor CommandProcessor => SceneController.CommandProcessor;
        private SplitContainer PrimarySplitter => Editor.PrimarySplitter;
        private FastColoredTextBox PrimaryTextBox => Editor.PrimaryTextBox;
        private readonly PropertiesController PropertiesController;
        private TabbedEdit PropertiesEditor => PropertiesController.TabbedEdit;
        private TabControl PropertiesTabControl => PropertiesEditor.TabControl;
        private int PropertiesTabSelectedIndex => PropertiesTabControl.SelectedIndex;
        private Scene Scene => SceneController.Scene;
        private SceneController SceneController => PropertiesController.SceneController;
        private SceneForm SceneForm => SceneController.SceneForm;
        private bool SceneTab => PropertiesTabSelectedIndex == 0;
        private Selection Selection => SceneController.Selection;
        private SplitContainer SecondarySplitter => Editor.SecondarySplitter;
        private FastColoredTextBox SecondaryTextBox => Editor.SecondaryTextBox;
        private string ShaderName => SceneTab ? ShaderType.SceneShaderName() : ShaderType.TraceShaderName();
        private Shaders Shaders => SceneTab ? (Shaders)Scene : Selection;
        private SplitContainer Splitter => Editor.Splitter;
        private bool Updating;

        private ShaderType _ShaderType = ShaderType.VertexShader;
        private ShaderType ShaderType
        {
            get => _ShaderType;
            set
            {
                if (ShaderType != value)
                {
                    _ShaderType = value;
                    LoadShaderCode();
                }
            }
        }

        private SplitType _SplitType;
        private SplitType SplitType
        {
            get => _SplitType;
            set
            {
                _SplitType = value;
                switch (SplitType)
                {
                    case SplitType.None:
                        Splitter.Panel2Collapsed = true;
                        break;
                    case SplitType.Horizontal:
                        Splitter.Panel2Collapsed = false;
                        Splitter.Orientation = Orientation.Horizontal;
                        Splitter.SplitterDistance = Splitter.Height / 2 - 2;
                        break;
                    case SplitType.Vertical:
                        Splitter.Panel2Collapsed = false;
                        Splitter.Orientation = Orientation.Vertical;
                        Splitter.SplitterDistance = Splitter.Width / 2 - 2;
                        break;
                }
            }
        }

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
        }

        private void Print_Click(object sender, System.EventArgs e) =>
            PrimaryTextBox.Print(new PrintDialogSettings() { ShowPrintPreviewDialog = true });

        private void PropertyTab_SelectedIndexChanged(object sender, System.EventArgs e) =>
            LoadShaderCode();

        private void Ruler_Click(object sender, System.EventArgs e) =>
            ShowRuler = !ShowRuler;

        private void SceneController_SelectionChanged(object sender, EventArgs e) =>
            LoadShaderCode();

        private void SceneController_PropertyChanged(object sender, PropertyChangedEventArgs e) =>
            UpdateProperties(e.PropertyName);

        private void Shader_Click(object sender, System.EventArgs e) =>
            ShaderType = (ShaderType)((ToolStripItem)sender).Tag;

        private void Shader_DropDownOpening(object sender, System.EventArgs e)
        {
            foreach (ToolStripMenuItem item in ((ToolStripDropDownItem)sender).DropDownItems)
                item.Checked = (ShaderType)item.Tag == ShaderType;
        }

        private void Split_Click(object sender, System.EventArgs e) => CycleSplit();

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SaveShaderCode();
            UpdateUI();
        }

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
                PropertiesTabControl.SelectedIndexChanged += PropertyTab_SelectedIndexChanged;
                SceneController.PropertyChanged += SceneController_PropertyChanged;
                SceneController.SelectionChanged += SceneController_SelectionChanged;
            }
            else
            {
                Editor.btnShader.DropDownOpening -= Shader_DropDownOpening;
                Editor.miVertex.Click -= Shader_Click;
                Editor.miTessellationControl.Click -= Shader_Click;
                Editor.miTessellationEvaluation.Click -= Shader_Click;
                Editor.miGeometry.Click -= Shader_Click;
                Editor.miFragment.Click -= Shader_Click;
                Editor.miCompute.Click -= Shader_Click;
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
                PropertiesTabControl.SelectedIndexChanged -= PropertyTab_SelectedIndexChanged;
                SceneController.PropertyChanged -= SceneController_PropertyChanged;
                SceneController.SelectionChanged -= SceneController_SelectionChanged;
            }
        }

        private void CycleSplit() => SplitType = (SplitType)((int)(SplitType + 1) % 3);

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

        private void LoadShaderCode()
        {
            if (Updating)
                return;
            Updating = true;
            PrimaryTextBox.Text = Shaders.GetScript(ShaderType);
            Updating = false;
            UpdateUI();
        }

        private void Run(ICommand command) => CommandProcessor.Run(command);

        private void SaveShaderCode()
        {
            if (Updating)
                return;
            Updating = true;
            var text = Editor.PrimaryTextBox.Text;
            if (SceneTab)
                Run(new SceneShaderCommand(ShaderType, text));
            else
                foreach(var trace in Selection.Traces)
                    Run(new TraceShaderCommand(trace.Index, ShaderType, text));
            Updating = false;
        }

        private void UpdateProperties(params string[] propertyNames)
        {
            if (Updating)
                return;
            Updating = true;
            foreach (var propertyName in propertyNames)
                if (propertyName == ShaderName)
                {
                    Editor.PrimaryTextBox.Text = Shaders.GetScript(ShaderType);
                }
            Updating = false;
        }

        private void UpdateUI()
        {
            Editor.btnExport.Enabled =
                Editor.btnPrint.Enabled =
                PrimaryTextBox.Text != string.Empty;
        }

        #endregion
    }
}
