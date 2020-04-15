﻿namespace TabbyCat.Controllers
{
    using FastColoredTextBoxNS;
    using Jmk.Common;
    using Jmk.Controls;
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TabbyCat.Commands;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.Controls;
    using TabbyCat.Controls.Types;
    using TabbyCat.Models;
    using TabbyCat.Properties;
    using TabbyCat.Views;

    internal partial class ShaderController : LocalizationController
    {
        private FastColoredTextBox ActiveTextBox;
        private ShaderRegion _ShaderRegion;
        private ShaderType _ShaderType = ShaderType.VertexShader;
        private SplitType _SplitType;
        private bool Updating;

        internal ShaderController(WorldController worldController, ShaderRegion shaderRegion) : base(worldController)
        {
            ShaderRegion = shaderRegion;
            ShowRuler = false;
            ShowLineNumbers = false;
            ShowDocumentMap = false;
            SplitType = SplitType.None;
            var items = ShaderEdit.tbShader.DropDownItems;
            items[0].Tag = ShaderType.VertexShader;
            items[1].Tag = ShaderType.TessControlShader;
            items[2].Tag = ShaderType.TessEvaluationShader;
            items[3].Tag = ShaderType.GeometryShader;
            items[4].Tag = ShaderType.FragmentShader;
            items[5].Tag = ShaderType.ComputeShader;
        }

        private GLPageController _PrimaryController, _SecondaryController;
        private ShaderForm _ShaderForm;

        private GLPageController PrimaryController => _PrimaryController ?? (_PrimaryController = new GLPageController(PrimaryTextBox));
        private GLPageController SecondaryController => _SecondaryController ?? (_SecondaryController= new GLPageController(SecondaryTextBox));

        private SplitContainer PrimarySplitter => ShaderEdit.BottomSplit;
        private FastColoredTextBox PrimaryTextBox => ShaderEdit.PrimaryTextBox;
        private TraceSelection Selection => WorldController.Selection;
        private SplitContainer SecondarySplitter => ShaderEdit.TopSplit;
        private FastColoredTextBox SecondaryTextBox => ShaderEdit.SecondaryTextBox;
        private ShaderEdit ShaderEdit => ShaderForm.ShaderEdit;
        internal ShaderForm ShaderForm => _ShaderForm ?? (_ShaderForm = new ShaderForm());
        private SplitContainer Splitter => ShaderEdit.EditSplit;

        internal ShaderRegion ShaderRegion
        {
            get => _ShaderRegion;
            set
            {
                if (ShaderRegion == value)
                    return;
                _ShaderRegion = value;
                LoadShaderCode();
            }
        }

        private string ShaderName
        {
            get
            {
                switch (ShaderRegion)
                {
                    case ShaderRegion.Scene:
                        return ShaderType.SceneShaderName();
                    case ShaderRegion.Trace:
                        return ShaderType.TraceShaderName();
                    case ShaderRegion.All:
                        return ShaderType.ShaderName();
                }
                return string.Empty;
            }
        }

        private IShaderSet ShaderSet
        {
            get
            {
                switch (ShaderRegion)
                {
                    case ShaderRegion.Scene:
                        return Scene;
                    case ShaderRegion.Trace:
                        return Selection;
                    case ShaderRegion.All:
                        return RenderController;
                }
                return null;
            }
        }

        private ShaderType ShaderType
        {
            get => _ShaderType;
            set
            {
                if (ShaderType != value)
                {
                    _ShaderType = value;
                    ShaderEdit.tbShader.Text =
                        ShaderEdit.tbShader.DropDownItems
                        .Cast<ToolStripMenuItem>()
                        .First(p => (ShaderType)p.Tag == ShaderType)
                        .Text;
                    LoadBuiltInHelp();
                }
            }
        }

        private bool ShowDocumentMap
        {
            get => !PrimarySplitter.Panel2Collapsed || !SecondarySplitter.Panel2Collapsed;
            set
            {
                PrimarySplitter.Panel2Collapsed = !value;
                SecondarySplitter.Panel2Collapsed = !value;
            }
        }

        private bool ShowLineNumbers
        {
            get => PrimaryTextBox.ShowLineNumbers || SecondaryTextBox.ShowLineNumbers;
            set
            {
                PrimaryTextBox.ShowLineNumbers = value;
                SecondaryTextBox.ShowLineNumbers = value;
                ShaderEdit.Refresh();
            }
        }

        private bool ShowRuler
        {
            get => ShaderEdit.PrimaryRuler.Visible || ShaderEdit.SecondaryRuler.Visible;
            set
            {
                ShaderEdit.PrimaryRuler.Visible = value;
                ShaderEdit.SecondaryRuler.Visible = value;
                ShaderEdit.Refresh();
            }
        }

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

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            ConnectMenu(connect);
            ConnectToolbar(connect);
            ConnectTextBoxes(connect);
            ConnectHelp(connect);
            if (connect)
            {
                WorldController.PropertyChanged += WorldController_PropertyChanged;
                WorldController.Pulse += WorldController_Pulse;
                WorldController.SelectionChanged += WorldController_SelectionChanged;
                LoadBuiltInHelp();
            }
            else
            {
                WorldController.PropertyChanged -= WorldController_PropertyChanged;
                WorldController.Pulse -= WorldController_Pulse;
                WorldController.SelectionChanged -= WorldController_SelectionChanged;
            }
        }

        protected override void DisposeManagedState()
        {
            base.DisposeManagedState();
            PrimaryController?.Dispose();
            SecondaryController?.Dispose();
        }

        private void BuiltInHelp_ActiveLinkChanged(object sender, EventArgs e) =>
            WorldForm.ToolTip.SetToolTip(ShaderEdit.lblBuiltInHelp, ShaderEdit.lblBuiltInHelp.ActiveLink?.Description);

        private void BuiltInHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            e.Link.LinkData.ToString().Launch();

        private void BuiltInHelp_LookupParameterValue(object sender, LookupParameterEventArgs e) =>
            e.Value = LookupParameterValue(e.Name);

        private void BuiltInHelpParent_Resize(object sender, EventArgs e) =>
            ResizeBuiltInHelp();

        private void Copy_Click(object sender, EventArgs e) => ActiveTextBox?.Copy();

        private void Cut_Click(object sender, EventArgs e) => ActiveTextBox?.Cut();

        private void Delete_Click(object sender, EventArgs e) => ActiveTextBox?.ClearSelected();

        private void DocumentMap_Click(object sender, System.EventArgs e) =>
            ShowDocumentMap = !ShowDocumentMap;

        private void ExportHTML_Click(object sender, System.EventArgs e)
        {
            using (var dialog = new SaveFileDialog
            {
                Filter = Resources.SaveHtmlDialog_Filter,
                Title = Resources.SaveHtmlDialog_Title
            })
                if (dialog.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(dialog.FileName, GetHTML(dialog.FilterIndex));
        }

        private void ExportRTF_Click(object sender, System.EventArgs e)
        {
            using (var dialog = new SaveFileDialog
            {
                Filter = Resources.SaveRtfDialog_Filter,
                Title = Resources.SaveRtfDialog_Title
            })
                if (dialog.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(dialog.FileName, PrimaryTextBox.Rtf);
        }

        private void Focus_Changed(object sender, EventArgs e) => SetActiveTextBox(sender as FastColoredTextBox);

        private void Help_Click(object sender, System.EventArgs e) { }

        private void LineNumbers_Click(object sender, System.EventArgs e) =>
            ShowLineNumbers = !ShowLineNumbers;

        private void Options_DropDownOpening(object sender, System.EventArgs e)
        {
            ShaderEdit.tbRuler.Checked = ShowRuler;
            ShaderEdit.tbLineNumbers.Checked = ShowLineNumbers;
            ShaderEdit.tbDocumentMap.Checked = ShowDocumentMap;
        }

        private void Paste_Click(object sender, EventArgs e) => ActiveTextBox?.Paste();

        private void Print_Click(object sender, System.EventArgs e) =>
            PrimaryTextBox.Print(new PrintDialogSettings() { ShowPrintPreviewDialog = true });

        private void PropertyTab_SelectedIndexChanged(object sender, System.EventArgs e) => LoadShaderCode();

        private void Redo_Click(object sender, EventArgs e) => ActiveTextBox?.Redo();

        private void Ruler_Click(object sender, System.EventArgs e) => ShowRuler = !ShowRuler;

        private void Shader_ButtonClick(object sender, EventArgs e) => SelectNextShader();

        private void Shader_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) =>
            ShaderType = (ShaderType)e.ClickedItem.Tag;

        private void Shader_DropDownOpening(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in ShaderEdit.tbShader.DropDownItems)
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

        private void TextBox_SelectionChanged(object sender, EventArgs e) => UpdateUI();

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SaveShaderCode();
            UpdateUI();
        }

        private void Undo_Click(object sender, EventArgs e) => ActiveTextBox?.Undo();

        private void WorldController_PropertyChanged(object sender, PropertyChangedEventArgs e) =>
            UpdateProperties(e.PropertyName);

        private void WorldController_Pulse(object sender, EventArgs e) => ShaderEdit.tbPaste.Enabled = CanPaste();

        private void WorldController_SelectionChanged(object sender, EventArgs e) =>
            OnSelectionChanged();

        private static bool CanPaste()
        {
            try
            {
                return Clipboard.ContainsText();
            }
            catch (ExternalException)
            {
                return false;
            }
        }

        private void ConnectHelp(bool connect)
        {
            if (connect)
            {
                ShaderEdit.lblBuiltInHelp.ActiveLinkChanged += BuiltInHelp_ActiveLinkChanged;
                ShaderEdit.lblBuiltInHelp.LinkClicked += BuiltInHelp_LinkClicked;
                ShaderEdit.lblBuiltInHelp.LookupParameterValue += BuiltInHelp_LookupParameterValue;
                ShaderEdit.lblBuiltInHelp.Parent.Resize += BuiltInHelpParent_Resize;
            }
            else
            {
                ShaderEdit.lblBuiltInHelp.ActiveLinkChanged -= BuiltInHelp_ActiveLinkChanged;
                ShaderEdit.lblBuiltInHelp.LinkClicked -= BuiltInHelp_LinkClicked;
                ShaderEdit.lblBuiltInHelp.LookupParameterValue -= BuiltInHelp_LookupParameterValue;
                ShaderEdit.lblBuiltInHelp.Parent.Resize -= BuiltInHelpParent_Resize;
            }
        }

        private void ConnectMenu(bool connect)
        {
            if (connect)
            {
                ShaderEdit.miUndo.Click += Undo_Click;
                ShaderEdit.miRedo.Click += Redo_Click;
                ShaderEdit.miCut.Click += Cut_Click;
                ShaderEdit.miCopy.Click += Copy_Click;
                ShaderEdit.miPaste.Click += Paste_Click;
                ShaderEdit.miDelete.Click += Delete_Click;
            }
            else
            {
                ShaderEdit.miUndo.Click -= Undo_Click;
                ShaderEdit.miRedo.Click -= Redo_Click;
                ShaderEdit.miCut.Click -= Cut_Click;
                ShaderEdit.miCopy.Click -= Copy_Click;
                ShaderEdit.miPaste.Click -= Paste_Click;
                ShaderEdit.miDelete.Click -= Delete_Click;
            }
        }

        private void ConnectTextBox(FastColoredTextBox textBox, bool connect)
        {
            if (connect)
            {
                textBox.Enter += Focus_Changed;
                textBox.SelectionChanged += TextBox_SelectionChanged;
                textBox.TextChanged += TextBox_TextChanged;
            }
            else
            {
                textBox.Enter -= Focus_Changed;
                textBox.SelectionChanged -= TextBox_SelectionChanged;
                textBox.TextChanged -= TextBox_TextChanged;
            }
        }

        private void ConnectTextBoxes(bool connect)
        {
            ConnectTextBox(PrimaryTextBox, connect);
            ConnectTextBox(SecondaryTextBox, connect);
        }

        private void ConnectToolbar(bool connect)
        {
            if (connect)
            {
                ShaderEdit.tbDocumentMap.Click += DocumentMap_Click;
                ShaderEdit.tbExportHTML.Click += ExportHTML_Click;
                ShaderEdit.tbExportRTF.Click += ExportRTF_Click;
                ShaderEdit.tbHelp.Click += Help_Click;
                ShaderEdit.tbLineNumbers.Click += LineNumbers_Click;
                ShaderEdit.tbOptions.DropDownOpening += Options_DropDownOpening;
                ShaderEdit.tbPrint.Click += Print_Click;
                ShaderEdit.tbUndo.Click += Undo_Click;
                ShaderEdit.tbRedo.Click += Redo_Click;
                ShaderEdit.tbCut.Click += Cut_Click;
                ShaderEdit.tbCopy.Click += Copy_Click;
                ShaderEdit.tbPaste.Click += Paste_Click;
                ShaderEdit.tbDelete.Click += Delete_Click;
                ShaderEdit.tbRuler.Click += Ruler_Click;
                ShaderEdit.tbSplit.Click += Split_Click;
                ShaderEdit.tbShader.ButtonClick += Shader_ButtonClick;
                ShaderEdit.tbShader.DropDownOpening += Shader_DropDownOpening;
                ShaderEdit.tbShader.DropDownItemClicked += Shader_DropDownItemClicked;
            }
            else
            {
                ShaderEdit.tbDocumentMap.Click -= DocumentMap_Click;
                ShaderEdit.tbExportHTML.Click -= ExportHTML_Click;
                ShaderEdit.tbExportRTF.Click -= ExportRTF_Click;
                ShaderEdit.tbHelp.Click -= Help_Click;
                ShaderEdit.tbLineNumbers.Click -= LineNumbers_Click;
                ShaderEdit.tbOptions.DropDownOpening -= Options_DropDownOpening;
                ShaderEdit.tbPrint.Click -= Print_Click;
                ShaderEdit.tbUndo.Click -= Undo_Click;
                ShaderEdit.tbRedo.Click -= Redo_Click;
                ShaderEdit.tbCut.Click -= Cut_Click;
                ShaderEdit.tbCopy.Click -= Copy_Click;
                ShaderEdit.tbPaste.Click -= Paste_Click;
                ShaderEdit.tbDelete.Click -= Delete_Click;
                ShaderEdit.tbRuler.Click -= Ruler_Click;
                ShaderEdit.tbSplit.Click -= Split_Click;
                ShaderEdit.tbShader.ButtonClick -= Shader_ButtonClick;
                ShaderEdit.tbShader.DropDownOpening -= Shader_DropDownOpening;
                ShaderEdit.tbShader.DropDownItemClicked -= Shader_DropDownItemClicked;
            }
        }

        private void CycleSplit() => SplitType = (SplitType)((int)(SplitType + 1) % 3);

        private string GetBuiltInHelp()
        {
            switch (ShaderType)
            {
                case ShaderType.VertexShader:
                    return Resources.Built_in_VertexShader;
                case ShaderType.TessControlShader:
                    return Resources.Built_in_TessControlShader;
                case ShaderType.TessEvaluationShader:
                    return Resources.Built_in_TessEvaluationShader;
                case ShaderType.GeometryShader:
                    return Resources.Built_in_GeometryShader;
                case ShaderType.FragmentShader:
                    return Resources.Built_in_FragmentShader;
                case ShaderType.ComputeShader:
                    return Resources.Built_in_ComputeShader;
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
            LoadShaderCode();
            ShaderEdit.lblBuiltInHelp.Text = GetBuiltInHelp();
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

        private string LookupParameterValue(string parameterName)
        {
            switch (parameterName)
            {
                case "GLSLUrl":
                    return AppController.Options.GLSLPath;
                default:
                    return string.Empty;
            }
        }

        private void OnSelectionChanged() => LoadShaderCode();

        private void ResizeBuiltInHelp() => ShaderEdit.lblBuiltInHelp.MaximumSize = new Size(
            ShaderEdit.lblBuiltInHelp.Parent.ClientSize.Width - SystemInformation.VerticalScrollBarWidth, 0);

        private void Run(ICommand command) => CommandProcessor.Run(command);

        private void SaveShaderCode()
        {
            if (Updating)
                return;
            Updating = true;
            var text = ShaderEdit.PrimaryTextBox.Text;
            switch (ShaderRegion)
            {
                case ShaderRegion.Scene:
                    Run(new SceneShaderCommand(ShaderType, text));
                    break;
                case ShaderRegion.Trace:
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

        private void SetActiveTextBox(FastColoredTextBox activeTextBox)
        {
            ActiveTextBox = activeTextBox;
            UpdateUI();
        }

        protected override void UpdateProperties(params string[] propertyNames)
        {
            if (Updating)
                return;
            Updating = true;
            foreach (var propertyName in propertyNames)
                if (propertyName == ShaderName)
                    ShaderEdit.PrimaryTextBox.Text = GetScript();
            Updating = false;
        }

        private void UpdateUI()
        {
            UIController.EnableControls(
                ShaderRegion != ShaderRegion.Trace || !Selection.IsEmpty,
                new Control[]
                {
                    ShaderEdit.Toolbar,
                    ShaderEdit.PrimaryTextBox,
                    ShaderEdit.SecondaryTextBox
                });
            ShaderEdit.tbExport.Enabled = ShaderEdit.tbPrint.Enabled = !string.IsNullOrEmpty(PrimaryTextBox.Text);
            ShaderEdit.tbUndo.Enabled = ShaderEdit.miUndo.Enabled = ActiveTextBox != null && ActiveTextBox.UndoEnabled;
            ShaderEdit.tbRedo.Enabled = ShaderEdit.miRedo.Enabled = ActiveTextBox != null && ActiveTextBox.RedoEnabled;
            ShaderEdit.tbCut.Enabled = ShaderEdit.tbCopy.Enabled = ShaderEdit.tbDelete.Enabled =
            ShaderEdit.miCut.Enabled = ShaderEdit.miCopy.Enabled = ShaderEdit.miDelete.Enabled =
                ActiveTextBox != null && !ActiveTextBox.Selection.IsEmpty;
        }
    }
}
