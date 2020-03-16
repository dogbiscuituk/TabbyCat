namespace TabbyCat.Controllers
{
    using FastColoredTextBoxNS;
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using TabbyCat.Commands;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.Controls;
    using TabbyCat.Models;
    using TabbyCat.Properties;
    using TabbyCat.Views;

    internal class ShaderController
    {
        #region Constructors

        internal ShaderController(PropertiesController propertiesController)
        {
            PropertiesController = propertiesController;
            new GLPageController(PrimaryTextBox);
            new GLPageController(SecondaryTextBox);
            ShowRuler = false;
            ShowLineNumbers = false;
            ShowDocumentMap = false;
            SplitType = SplitType.None;
            var items = Editor.btnShader.DropDownItems;
            items[0].Tag = ShaderType.VertexShader;
            items[1].Tag = ShaderType.TessControlShader;
            items[2].Tag = ShaderType.TessEvaluationShader;
            items[3].Tag = ShaderType.GeometryShader;
            items[4].Tag = ShaderType.FragmentShader;
            items[5].Tag = ShaderType.ComputeShader;
            LoadShaderCode();
            LoadBuiltInHelp();
        }

        #endregion

        #region Fields & Properties

        internal ShaderEdit Editor => PropertiesEditor.ShaderEdit;

        private CommandProcessor CommandProcessor => WorldController.CommandProcessor;
        private SplitContainer PrimarySplitter => Editor.PrimarySplitter;
        private FastColoredTextBox PrimaryTextBox => Editor.PrimaryTextBox;
        private readonly PropertiesController PropertiesController;
        private PropertiesEdit PropertiesEditor => PropertiesController.PropertiesEdit;
        private TabControl PropertiesTabControl => PropertiesEditor.TabControl;
        private int PropertiesTabIndex => PropertiesTabControl.SelectedIndex;
        private RenderController RenderController => WorldController.RenderController;
        private Scene Scene => WorldController.Scene;
        private Selection Selection => WorldController.Selection;
        private SplitContainer SecondarySplitter => Editor.SecondarySplitter;
        private FastColoredTextBox SecondaryTextBox => Editor.SecondaryTextBox;
        private SplitContainer Splitter => Editor.Splitter;
        private bool Updating;
        private WorldController WorldController => PropertiesController.WorldController;
        private WorldForm WorldForm => WorldController.WorldForm;

        private string ShaderName
        {
            get
            {
                switch (PropertiesTabIndex)
                {
                    case 0:
                        return ShaderType.SceneShaderName();
                    case 1:
                        return ShaderType.TraceShaderName();
                    default:
                        return string.Empty;
                }
            }
        }

        private IShaderSet ShaderSet
        {
            get
            {
                switch (PropertiesTabIndex)
                {
                    case 0:
                        return Scene;
                    case 1:
                        return Selection;
                    default:
                        return RenderController;
                }
            }
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
                    Editor.btnShader.Text =
                        Editor.btnShader.DropDownItems
                        .Cast<ToolStripMenuItem>()
                        .First(p => (ShaderType)p.Tag == ShaderType)
                        .Text;
                    LoadShaderCode();
                    LoadBuiltInHelp();
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
                        Splitter.SplitterDistance = (Splitter.Height - 4) / 2;
                        break;
                    case SplitType.Vertical:
                        Splitter.Panel2Collapsed = false;
                        Splitter.Orientation = Orientation.Vertical;
                        Splitter.SplitterDistance = (Splitter.Width - 4) / 2;
                        break;
                }
            }
        }

        #endregion

        #region Private Event Handlers

        private void BuiltInHelpParent_Resize(object sender, EventArgs e) =>
            ResizeBuiltInHelp();

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

        private void Help_Click(object sender, System.EventArgs e) => HotkeysController.Show(WorldForm);

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

        private void Shader_ButtonClick(object sender, EventArgs e) => SelectNextShader();

        private void Shader_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) =>
            ShaderType = (ShaderType)e.ClickedItem.Tag;

        private void Shader_DropDownOpening(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in Editor.btnShader.DropDownItems)
            {
                var shaderType = (ShaderType)item.Tag;
                item.CheckState =
                    shaderType == ShaderType
                    ? CheckState.Checked
                    : string.IsNullOrWhiteSpace(GetScript(shaderType))
                    ? CheckState.Unchecked
                    : CheckState.Indeterminate;
            }
        }

        private void Split_Click(object sender, System.EventArgs e) => CycleSplit();

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SaveShaderCode();
            UpdateUI();
        }

        private void WorldController_SelectionChanged(object sender, EventArgs e) =>
            LoadShaderCode();

        private void WorldController_PropertyChanged(object sender, PropertyChangedEventArgs e) =>
            UpdateProperties(e.PropertyName);

        #endregion

        #region Private Methods

        internal void Connect(bool connect)
        {
            if (connect)
            {
                Editor.btnDocumentMap.Click += DocumentMap_Click;
                Editor.btnExportHTML.Click += ExportHTML_Click;
                Editor.btnExportRTF.Click += ExportRTF_Click;
                Editor.btnHelp.Click += Help_Click;
                Editor.btnLineNumbers.Click += LineNumbers_Click;
                Editor.btnOptions.DropDownOpening += Options_DropDownOpening;
                Editor.btnPrint.Click += Print_Click;
                Editor.btnRuler.Click += Ruler_Click;
                Editor.btnSplit.Click += Split_Click;
                Editor.btnShader.ButtonClick += Shader_ButtonClick;
                Editor.btnShader.DropDownOpening += Shader_DropDownOpening;
                Editor.btnShader.DropDownItemClicked += Shader_DropDownItemClicked;
                Editor.PrimaryTextBox.TextChanged += TextBox_TextChanged;
                Editor.SecondaryTextBox.TextChanged += TextBox_TextChanged;
                Editor.lblBuiltInHelp.Parent.Resize += BuiltInHelpParent_Resize;
                PropertiesTabControl.SelectedIndexChanged += PropertyTab_SelectedIndexChanged;
                WorldController.PropertyChanged += WorldController_PropertyChanged;
                WorldController.SelectionChanged += WorldController_SelectionChanged;
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
                Editor.btnShader.ButtonClick -= Shader_ButtonClick;
                Editor.btnShader.DropDownOpening -= Shader_DropDownOpening;
                Editor.btnShader.DropDownItemClicked -= Shader_DropDownItemClicked;
                Editor.PrimaryTextBox.TextChanged -= TextBox_TextChanged;
                Editor.SecondaryTextBox.TextChanged -= TextBox_TextChanged;
                Editor.lblBuiltInHelp.Parent.Resize -= BuiltInHelpParent_Resize;
                PropertiesTabControl.SelectedIndexChanged -= PropertyTab_SelectedIndexChanged;
                WorldController.PropertyChanged -= WorldController_PropertyChanged;
                WorldController.SelectionChanged -= WorldController_SelectionChanged;
            }
        }

        private void CycleSplit() => SplitType = (SplitType)((int)(SplitType + 1) % 3);

        private string GetBuiltInHelp()
        {
            switch (ShaderType)
            {
                case ShaderType.VertexShader:
                    return Resources.Built_in_Shader1Vertex;
                case ShaderType.TessControlShader:
                    return Resources.Built_in_Shader2TessControl;
                case ShaderType.TessEvaluationShader:
                    return Resources.Built_in_Shader3TessEvaluation;
                case ShaderType.GeometryShader:
                    return Resources.Built_in_Shader4Geometry;
                case ShaderType.FragmentShader:
                    return Resources.Built_in_Shader5Fragment;
                case ShaderType.ComputeShader:
                    return Resources.Built_in_Shader6Compute;
                default:
                    return string.Empty;
            }
        }

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

        private string GetScript() => GetScript(ShaderType);
            
        private string GetScript(ShaderType shaderType) => ShaderSet.GetScript(shaderType);

        private void LoadBuiltInHelp()
        {
            Editor.lblBuiltInHelp.Text = GetBuiltInHelp();
        }

        private void LoadShaderCode()
        {
            if (Updating)
                return;
            Updating = true;
            PrimaryTextBox.Text = GetScript();
            Updating = false;
            UpdateUI();
        }

        private void ResizeBuiltInHelp() => Editor.lblBuiltInHelp.MaximumSize = new Size(
            Editor.lblBuiltInHelp.Parent.ClientSize.Width - SystemInformation.VerticalScrollBarWidth, 0);

        private void Run(ICommand command) => CommandProcessor.Run(command);

        private void SaveShaderCode()
        {
            if (Updating)
                return;
            Updating = true;
            var text = Editor.PrimaryTextBox.Text;
            switch (PropertiesTabIndex)
            {
                case 0:
                    Run(new SceneShaderCommand(ShaderType, text));
                    break;
                case 1:
                    Selection.ForEach(p => Run(new TraceShaderCommand(p.Index, ShaderType, text)));
                    break;
            }
            Updating = false;
        }

        private void SelectNextShader()
        {
            var s = ShaderType;
            do
                s = s.Next();
            while (string.IsNullOrWhiteSpace(GetScript(s)) && s != ShaderType);
            if (s == ShaderType)
                s = s.Next();
            ShaderType = s;
        }

        private void UpdateProperties(params string[] propertyNames)
        {
            if (Updating)
                return;
            Updating = true;
            foreach (var propertyName in propertyNames)
                if (propertyName == ShaderName)
                    Editor.PrimaryTextBox.Text = GetScript();
            Updating = false;
        }

        private void UpdateUI() =>
            Editor.btnExport.Enabled =
            Editor.btnPrint.Enabled =
            PrimaryTextBox.Text != string.Empty;

        #endregion
    }
}
