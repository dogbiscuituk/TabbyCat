﻿namespace TabbyCat.Controllers
{
    using FastColoredTextBoxNS;
    using Models;
    using OpenTK.Graphics.OpenGL;
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Types;
    using UserControls;
    using Utils;
    using Views;
    using WeifenLuo.WinFormsUI.Docking;

    public abstract class CodeCon : DockingCon
    {
        // Constructors

        protected CodeCon(WorldCon worldCon) : base(worldCon)
        {
            LoadShaderCode();
            AppCon.InitControlTheme(CodeEdit.HorizontalToolbar, CodeEdit.VerticalToolbar, CodeEdit.PopupEditMenu);
            ShowRuler = false;
            ShowLineNumbers = false;
            ShowDocumentMap = false;
            SplitType = SplitType.None;
            var items = CodeEdit.tbShader.DropDownItems;
            items[0].Tag = ShaderType.VertexShader;
            items[1].Tag = ShaderType.TessControlShader;
            items[2].Tag = ShaderType.TessEvaluationShader;
            items[3].Tag = ShaderType.GeometryShader;
            items[4].Tag = ShaderType.FragmentShader;
            items[5].Tag = ShaderType.ComputeShader;
        }

        // Private fields

        private FastColoredTextBox _activeTextBox;
        private CodeForm _codeForm;
        private CodePageCon _primaryCon, _secondaryCon;
        private ShaderType _shaderType = ShaderType.VertexShader;
        private SplitType _splitType;

        // Public properties

        public CodeForm CodeForm => _codeForm ?? (_codeForm = new CodeForm()
        {
            TabText = GetTabText(),
            Text = GetText(),
            ToolTipText = GetToolTipText()
        });

        // Protected properties

        protected CodeEdit CodeEdit => CodeForm.CodeEdit;

        protected override DockContent Form => CodeForm;

        protected CodePageCon PrimaryCon => _primaryCon ?? (_primaryCon = new CodePageCon(PrimaryTextBox));

        protected FastColoredTextBox PrimaryTextBox => CodeEdit.PrimaryTextBox;

        protected ShapeSelection ShapeSelection => WorldCon.ShapeSelection;

        protected abstract Property Shader { get; }

        protected abstract IScript ShaderSet { get; }

        protected ShaderType ShaderType
        {
            get => _shaderType;
            private set
            {
                if (ShaderType == value)
                    return;
                _shaderType = value;
                CodeEdit.tbShader.Text =
                    CodeEdit.tbShader.DropDownItems
                        .Cast<ToolStripMenuItem>()
                        .First(p => (ShaderType)p.Tag == ShaderType)
                        .Text;
                LoadContent();
            }
        }

        // Private properties

        private SplitContainer PrimarySplitter => CodeEdit.BottomSplit;

        private CodePageCon SecondaryCon => _secondaryCon ?? (_secondaryCon = new CodePageCon(SecondaryTextBox));

        private SplitContainer SecondarySplitter => CodeEdit.TopSplit;

        private FastColoredTextBox SecondaryTextBox => CodeEdit.SecondaryTextBox;

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
                CodeEdit.Refresh();
            }
        }

        private bool ShowRuler
        {
            get => CodeEdit.PrimaryRuler.Visible || CodeEdit.SecondaryRuler.Visible;
            set
            {
                CodeEdit.PrimaryRuler.Visible = value;
                CodeEdit.SecondaryRuler.Visible = value;
                CodeEdit.Refresh();
            }
        }

        private SplitContainer Splitter => CodeEdit.EditSplit;

        private SplitType SplitType
        {
            get => _splitType;
            set
            {
                _splitType = value;
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

        // Public methods

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            ConnectMenu(connect);
            ConnectToolbar(connect);
            ConnectTextBoxes(connect);
            ConnectHelp(connect);
            if (connect)
            {
                WorldCon.PropertyEdit += WorldCon_PropertyEdit;
                WorldCon.Pulse += WorldCon_Pulse;
                WorldCon.SelectionChanged += WorldCon_SelectionChanged;
                LoadContent();
            }
            else
            {
                WorldCon.PropertyEdit -= WorldCon_PropertyEdit;
                WorldCon.Pulse -= WorldCon_Pulse;
                WorldCon.SelectionChanged -= WorldCon_SelectionChanged;
            }
        }

        // Protected methods

        protected virtual bool CodeChanged(Property property) => property == Shader;

        protected override void DisposeManagedState()
        {
            base.DisposeManagedState();
            PrimaryCon?.Dispose();
            SecondaryCon?.Dispose();
        }

        protected abstract string GetRegion();

        protected string GetScript() => GetScript(ShaderType);

        protected virtual void LoadScript()
        {
            var script = GetScript();
            PrimaryTextBox.Text = script;
            SecondaryTextBox.Text = script;
        }

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.CodeForm_Save, CodeEdit.tbExport);
            Localize(Resources.CodeForm_SaveAsHTML, CodeEdit.tbExportHTML);
            Localize(Resources.CodeForm_SaveAsRTF, CodeEdit.tbExportRTF);
            Localize(Resources.CodeForm_Print, CodeEdit.tbPrint);
            Localize(Resources.CodeForm_Undo, CodeEdit.tbUndo, CodeEdit.miUndo);
            Localize(Resources.CodeForm_Redo, CodeEdit.tbRedo, CodeEdit.miRedo);
            Localize(Resources.CodeForm_Cut, CodeEdit.tbCut, CodeEdit.miCut);
            Localize(Resources.CodeForm_Copy, CodeEdit.tbCopy, CodeEdit.miCopy);
            Localize(Resources.CodeForm_Paste, CodeEdit.tbPaste, CodeEdit.miPaste);
            Localize(Resources.CodeForm_Delete, CodeEdit.tbDelete, CodeEdit.miDelete);
            Localize(Resources.CodeForm_Options, CodeEdit.tbOptions);
            Localize(Resources.CodeForm_OptionsRuler, CodeEdit.tbRuler);
            Localize(Resources.CodeForm_OptionsLineNumbers, CodeEdit.tbLineNumbers);
            Localize(Resources.CodeForm_OptionsDocumentMap, CodeEdit.tbDocumentMap);
            Localize(Resources.CodeForm_Split, CodeEdit.tbSplit);
            Localize(Resources.CodeForm_SplitHorizontal, CodeEdit.tbSplitHorizontal);
            Localize(Resources.CodeForm_SplitVertical, CodeEdit.tbSplitVertical);
            Localize(Resources.CodeForm_SplitNone, CodeEdit.tbSplitNone);
        }

        protected abstract void RunShaderCommand(string text);

        protected override void UpdateProperties(IEnumerable<Property> properties)
        {
            if (properties == null)
                return;
            if (Updating)
                return;
            Updating = true;
            if (properties.Any(CodeChanged))
                LoadScript();
            Updating = false;
        }

        protected virtual void UpdateUI()
        {
            CodeEdit.tbExport.Enabled = CodeEdit.tbPrint.Enabled = !string.IsNullOrEmpty(PrimaryTextBox.Text);
            CodeEdit.tbUndo.Enabled = CodeEdit.miUndo.Enabled = _activeTextBox != null && _activeTextBox.UndoEnabled;
            CodeEdit.tbRedo.Enabled = CodeEdit.miRedo.Enabled = _activeTextBox != null && _activeTextBox.RedoEnabled;
            CodeEdit.tbCut.Enabled = CodeEdit.tbCopy.Enabled = CodeEdit.tbDelete.Enabled =
                CodeEdit.miCut.Enabled = CodeEdit.miCopy.Enabled = CodeEdit.miDelete.Enabled =
                    _activeTextBox != null && !_activeTextBox.Selection.IsEmpty;
        }

        // Private methods

        private void BuiltInHelp_ActiveLinkChanged(object sender, EventArgs e) => WorldForm.ToolTip.SetToolTip(CodeEdit.lblBuiltInHelp, CodeEdit.lblBuiltInHelp.ActiveLink?.Description);

        private void BuiltInHelp_LookupParameterValue(object sender, LookupParameterEventArgs e) => e.Value = LookupParameterValue(e.Name);

        private void BuiltInHelpParent_Resize(object sender, EventArgs e) => ResizeBuiltInHelp();

        private void Copy_Click(object sender, EventArgs e) => _activeTextBox?.Copy();

        private void Cut_Click(object sender, EventArgs e) => _activeTextBox?.Cut();

        private void Delete_Click(object sender, EventArgs e) => _activeTextBox?.ClearSelected();

        private void DocumentMap_Click(object sender, EventArgs e) => ShowDocumentMap = !ShowDocumentMap;

        private void ExportHTML_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog
            {
                Filter = Resources.SaveHtmlDialog_Filter,
                Title = Resources.SaveHtmlDialog_Title
            })
                if (dialog.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(dialog.FileName, GetHTML(dialog.FilterIndex));
        }

        private void ExportRTF_Click(object sender, EventArgs e)
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

        private string GetTabText() => GetText(Resources.ShaderForm_TabText);

        private string GetText() => GetText(Resources.ShaderForm_Text);

        private string GetText(string format) => format.Format(GetRegion());

        private string GetToolTipText() => GetText(Resources.ShaderForm_ToolTipText);

        private void LineNumbers_Click(object sender, EventArgs e) => ShowLineNumbers = !ShowLineNumbers;

        private void Options_DropDownOpening(object sender, EventArgs e)
        {
            CodeEdit.tbRuler.Checked = ShowRuler;
            CodeEdit.tbLineNumbers.Checked = ShowLineNumbers;
            CodeEdit.tbDocumentMap.Checked = ShowDocumentMap;
        }

        private void Paste_Click(object sender, EventArgs e) => _activeTextBox?.Paste();

        private void Print_Click(object sender, EventArgs e) => PrimaryTextBox.Print(new PrintDialogSettings() { ShowPrintPreviewDialog = true });

        private void Redo_Click(object sender, EventArgs e) => _activeTextBox?.Redo();

        private void Ruler_Click(object sender, EventArgs e) => ShowRuler = !ShowRuler;

        private void Shader_ButtonClick(object sender, EventArgs e) => SelectNextShader();

        private void Shader_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) => ShaderType = (ShaderType)e.ClickedItem.Tag;

        private void Shader_DropDownOpening(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in CodeEdit.tbShader.DropDownItems)
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

        private void Split_ButtonClick(object sender, EventArgs e) => SplitType = (SplitType)((int)(SplitType + 1) % 3);

        private void Split_DropDownOpening(object sender, EventArgs e)
        {
            CodeEdit.tbSplitHorizontal.Checked = SplitType == SplitType.Horizontal;
            CodeEdit.tbSplitVertical.Checked = SplitType == SplitType.Vertical;
            CodeEdit.tbSplitNone.Checked = SplitType == SplitType.None;
        }

        private void SplitHorizontal_Click(object sender, EventArgs e) => SplitType = SplitType.Horizontal;

        private void SplitNone_Click(object sender, EventArgs e) => SplitType = SplitType.None;

        private void SplitVertical_Click(object sender, EventArgs e) => SplitType = SplitType.Vertical;

        private void TextBox_SelectionChanged(object sender, EventArgs e) => UpdateUI();

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Updating)
            {
                Updating = true;
                try
                {
                    SaveShaderCode();
                    UpdateUI();
                }
                finally
                {
                    Updating = false;
                }
            }
        }

        private void Undo_Click(object sender, EventArgs e) => _activeTextBox?.Undo();

        private void WorldCon_PropertyEdit(object sender, PropertyEditEventArgs e) => UpdateProperty(e.Property);

        private void WorldCon_Pulse(object sender, EventArgs e) => CodeEdit.tbPaste.Enabled = CanPaste();

        private void WorldCon_SelectionChanged(object sender, EventArgs e) => OnSelectionChanged();

        private void ConnectHelp(bool connect)
        {
            if (connect)
            {
                CodeEdit.lblBuiltInHelp.ActiveLinkChanged += BuiltInHelp_ActiveLinkChanged;
                CodeEdit.lblBuiltInHelp.LinkClicked += BuiltInHelp_LinkClicked;
                CodeEdit.lblBuiltInHelp.LookupParameterValue += BuiltInHelp_LookupParameterValue;
                CodeEdit.lblBuiltInHelp.Parent.Resize += BuiltInHelpParent_Resize;
            }
            else
            {
                CodeEdit.lblBuiltInHelp.ActiveLinkChanged -= BuiltInHelp_ActiveLinkChanged;
                CodeEdit.lblBuiltInHelp.LinkClicked -= BuiltInHelp_LinkClicked;
                CodeEdit.lblBuiltInHelp.LookupParameterValue -= BuiltInHelp_LookupParameterValue;
                CodeEdit.lblBuiltInHelp.Parent.Resize -= BuiltInHelpParent_Resize;
            }
        }

        private void ConnectMenu(bool connect)
        {
            if (connect)
            {
                CodeEdit.miUndo.Click += Undo_Click;
                CodeEdit.miRedo.Click += Redo_Click;
                CodeEdit.miCut.Click += Cut_Click;
                CodeEdit.miCopy.Click += Copy_Click;
                CodeEdit.miPaste.Click += Paste_Click;
                CodeEdit.miDelete.Click += Delete_Click;
            }
            else
            {
                CodeEdit.miUndo.Click -= Undo_Click;
                CodeEdit.miRedo.Click -= Redo_Click;
                CodeEdit.miCut.Click -= Cut_Click;
                CodeEdit.miCopy.Click -= Copy_Click;
                CodeEdit.miPaste.Click -= Paste_Click;
                CodeEdit.miDelete.Click -= Delete_Click;
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
                CodeEdit.tbDocumentMap.Click += DocumentMap_Click;
                CodeEdit.tbExportHTML.Click += ExportHTML_Click;
                CodeEdit.tbExportRTF.Click += ExportRTF_Click;
                CodeEdit.tbLineNumbers.Click += LineNumbers_Click;
                CodeEdit.tbOptions.DropDownOpening += Options_DropDownOpening;
                CodeEdit.tbPrint.Click += Print_Click;
                CodeEdit.tbUndo.Click += Undo_Click;
                CodeEdit.tbRedo.Click += Redo_Click;
                CodeEdit.tbCut.Click += Cut_Click;
                CodeEdit.tbCopy.Click += Copy_Click;
                CodeEdit.tbPaste.Click += Paste_Click;
                CodeEdit.tbDelete.Click += Delete_Click;
                CodeEdit.tbRuler.Click += Ruler_Click;
                CodeEdit.tbSplit.ButtonClick += Split_ButtonClick;
                CodeEdit.tbSplit.DropDownOpening += Split_DropDownOpening;
                CodeEdit.tbSplitHorizontal.Click += SplitHorizontal_Click;
                CodeEdit.tbSplitVertical.Click += SplitVertical_Click;
                CodeEdit.tbSplitNone.Click += SplitNone_Click;
                CodeEdit.tbShader.ButtonClick += Shader_ButtonClick;
                CodeEdit.tbShader.DropDownOpening += Shader_DropDownOpening;
                CodeEdit.tbShader.DropDownItemClicked += Shader_DropDownItemClicked;
            }
            else
            {
                CodeEdit.tbDocumentMap.Click -= DocumentMap_Click;
                CodeEdit.tbExportHTML.Click -= ExportHTML_Click;
                CodeEdit.tbExportRTF.Click -= ExportRTF_Click;
                CodeEdit.tbLineNumbers.Click -= LineNumbers_Click;
                CodeEdit.tbOptions.DropDownOpening -= Options_DropDownOpening;
                CodeEdit.tbPrint.Click -= Print_Click;
                CodeEdit.tbUndo.Click -= Undo_Click;
                CodeEdit.tbRedo.Click -= Redo_Click;
                CodeEdit.tbCut.Click -= Cut_Click;
                CodeEdit.tbCopy.Click -= Copy_Click;
                CodeEdit.tbPaste.Click -= Paste_Click;
                CodeEdit.tbDelete.Click -= Delete_Click;
                CodeEdit.tbRuler.Click -= Ruler_Click;
                CodeEdit.tbSplit.ButtonClick -= Split_ButtonClick;
                CodeEdit.tbSplit.DropDownOpening -= Split_DropDownOpening;
                CodeEdit.tbSplitHorizontal.Click -= SplitHorizontal_Click;
                CodeEdit.tbSplitVertical.Click -= SplitVertical_Click;
                CodeEdit.tbSplitNone.Click -= SplitNone_Click;
                CodeEdit.tbShader.ButtonClick -= Shader_ButtonClick;
                CodeEdit.tbShader.DropDownOpening -= Shader_DropDownOpening;
                CodeEdit.tbShader.DropDownItemClicked -= Shader_DropDownItemClicked;
            }
        }

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

        private string GetScript(ShaderType shaderType) => ShaderSet.GetScript(shaderType);

        private void LoadContent()
        {
            LoadShaderCode();
            CodeEdit.lblBuiltInHelp.Text = GetBuiltInHelp();
        }

        private void LoadShaderCode()
        {
            if (Updating)
                return;
            Updating = true;
            LoadScript();
            Updating = false;
            UpdateUI();
        }

        private void OnSelectionChanged() => LoadShaderCode();

        private void ResizeBuiltInHelp() => CodeEdit.lblBuiltInHelp.MaximumSize = new Size(
            CodeEdit.lblBuiltInHelp.Parent.ClientSize.Width - SystemInformation.VerticalScrollBarWidth, 0);

        private void SaveShaderCode() => RunShaderCommand(CodeEdit.PrimaryTextBox.Text);

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
            _activeTextBox = activeTextBox;
            UpdateUI();
        }

        // Private static methods

        private static void BuiltInHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => LaunchBrowser(e.Link.LinkData.ToString());

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

        private static string LookupParameterValue(string parameterName)
        {
            switch (parameterName)
            {
                case "GLSLUrl":
                    return AppCon.Options.GLSLPath;
                default:
                    return string.Empty;
            }
        }
    }
}
