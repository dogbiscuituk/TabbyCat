namespace TabbyCat.Controllers
{
    using FastColoredTextBoxNS;
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    using TabbyCat.Controls;
    using TabbyCat.Models;
    using TabbyCat.Views;

    internal class GLProgramController
    {
        #region Constructor

        internal GLProgramController(SceneController sceneController)
        {
            SceneController = sceneController;
            LoadAll();
        }

        internal GLProgramController(string caption)
        {
            Form.ActiveControl = PrimaryTextBox;
            SetSplitSize(0);
            ShowDocumentMap = false;
            PageController = new GLPageController(PrimaryTextBox);
            new GLPageController(SecondaryTextBox);
            Form.btnExportHTML.Click += FileExportHTML_Click;
            Form.btnExportRTF.Click += FileExportRTF_Click;
            Form.btnPrint.Click += FilePrint_Click;
            Form.btnOptions.DropDownOpening += ViewMenu_DropDownOpening;
            Form.btnRuler.Click += ViewRuler_Click;
            Form.btnLineNumbers.Click += ViewLineNumbers_Click;
            Form.btnDocumentMap.Click += ViewDocumentMap_Click;
            Form.btnSplit.Click += BtnSplit_Click;
            Form.btnHelp.Click += BtnHelp_Click;
        }

        #endregion

        #region Internal Properties

        internal string Text
        {
            get => PrimaryTextBox.Text;
            set => PrimaryTextBox.Text = value;
        }

        #endregion

        #region Private Fields

        private readonly GLPageController PageController;
        private readonly SceneController SceneController;

        #endregion

        #region Private Properties

        private RenderController RenderController => SceneController.RenderController;
        private Scene Scene => SceneController.Scene;
        private SceneForm SceneForm => SceneController.SceneForm;

        private ShaderEdit Form => SceneController.PropertyController.ShaderController.Editor;
        private Orientation Orientation { get => Splitter.Orientation; set => SetSplit(value); }
        private SplitContainer PrimarySplitter => Form.PrimarySplitter;
        private FastColoredTextBox PrimaryTextBox => Form.PrimaryTextBox;
        private SplitContainer SecondarySplitter => Form.SecondarySplitter;
        private FastColoredTextBox SecondaryTextBox => Form.SecondaryTextBox;
        private SplitContainer Splitter => Form.Splitter;

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
                Form.Refresh();
            }
        }

        private bool ShowRuler
        {
            get => Form.PrimaryRuler.Visible;
            set
            {
                Form.PrimaryRuler.Visible = Form.SecondaryRuler.Visible = value;
                Form.Refresh();
            }
        }

        #endregion

        #region Private Event Handlers

        private void BtnSplit_Click(object sender, EventArgs e) => ToggleSplit();
        private void BtnHelp_Click(object sender, EventArgs e) => HotkeysController.Show(SceneForm);

        private void FileExportHTML_Click(object sender, System.EventArgs e)
        {
            using (var dialog = new SaveFileDialog
            {
                Filter = "HTML with <PRE>|*.html|HTML without <PRE>|*.html",
                Title="Export as HTML"
            })
                if (dialog.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(dialog.FileName, GetHTML(dialog.FilterIndex));
        }

        private void FileExportRTF_Click(object sender, System.EventArgs e)
        {
            using (var dialog = new SaveFileDialog
            {
                Filter = "Rich Text Format|*.rtf",
                Title="Export As RTF"
            })
                if (dialog.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(dialog.FileName, PrimaryTextBox.Rtf);
        }

        private void FilePrint_Click(object sender, System.EventArgs e) =>
            PrimaryTextBox.Print(new PrintDialogSettings() { ShowPrintPreviewDialog = true });

        private void ViewDocumentMap_Click(object sender, System.EventArgs e) =>
            ShowDocumentMap = !ShowDocumentMap;

        private void ViewLineNumbers_Click(object sender, System.EventArgs e) =>
            ShowLineNumbers = !ShowLineNumbers;

        private void ViewMenu_DropDownOpening(object sender, System.EventArgs e)
        {
            Form.btnRuler.Checked = ShowRuler;
            Form.btnLineNumbers.Checked = ShowLineNumbers;
            Form.btnDocumentMap.Checked = ShowDocumentMap;
            Form.btnSplit.Checked = Orientation == Orientation.Vertical;
        }

        private void ViewRuler_Click(object sender, System.EventArgs e) =>
            ShowRuler = !ShowRuler;

        #endregion

        #region Private Methods

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

        private void LoadAll()
        {
            Text = Scene.GPUCode;
            SetBreaks(RenderController.Breaks);
        }

        private bool SaveAll()
        {
            var shaderTypes = RenderController.ShaderTypes;
            var shaderCount = shaderTypes.Count;
            var traceCount = Scene.Traces.Count;
            var ranges = PageController.GetUserRanges();
            var rangeCount = ranges.Count;
            if (rangeCount != (traceCount + 1) * shaderCount)
                throw new FormatException("GPU Code syntax error.");
            var rangeIndex = 0;
            foreach (var shaderType in shaderTypes)
            {
                SetSceneScript(shaderType, ranges[rangeIndex++]);
                for (var traceIndex = 0; traceIndex < traceCount; traceIndex++)
                    SetTraceScript(Scene.Traces[traceIndex], shaderType, ranges[rangeIndex++]);
            }
            return true;
        }

        private void SetBreaks(List<int> breaks)
        {
            for (var index = 0; index < breaks.Count; index += 2)
            {
                int a = breaks[index] - 1, b = breaks[index + 1] - 1;
                var range = new Range(PrimaryTextBox, 0, a, 0, b);
                PageController.AddSystemRange(range);
            }
        }

        private void SetSceneScript(ShaderType shaderType, Range range)
        {
            var text = range.Text.Trim();
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    Scene.Shader1Vertex = text;
                    break;
                case ShaderType.TessControlShader:
                    Scene.Shader2TessControl = text;
                    break;
                case ShaderType.TessEvaluationShader:
                    Scene.Shader3TessEvaluation = text;
                    break;
                case ShaderType.GeometryShader:
                    Scene.Shader4Geometry = text;
                    break;
                case ShaderType.FragmentShader:
                    Scene.Shader5Fragment = text;
                    break;
                case ShaderType.ComputeShader:
                    Scene.Shader6Compute = text;
                    break;
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

        private void SetTraceScript(Trace trace, ShaderType shaderType, Range range)
        {
            var text = range.Text.Trim();
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    trace.Shader1Vertex = text;
                    break;
                case ShaderType.TessControlShader:
                    trace.Shader2TessControl = text;
                    break;
                case ShaderType.TessEvaluationShader:
                    trace.Shader3TessEvaluation = text;
                    break;
                case ShaderType.GeometryShader:
                    trace.Shader4Geometry = text;
                    break;
                case ShaderType.FragmentShader:
                    trace.Shader5Fragment = text;
                    break;
                case ShaderType.ComputeShader:
                    trace.Shader6Compute = text;
                    break;
            }
        }

        private void ToggleSplit() =>
            SetSplit(Splitter.SplitterDistance == 0 || Orientation == Orientation.Vertical
                ? Orientation.Horizontal
                : Orientation.Vertical);

        #endregion
    }
}
