namespace TabbyCat.Controllers
{
    using Commands;
    using Properties;
    using System;
    using System.Windows.Forms;
    using Types;
    using Utils;

    public class TraceCodeCon : CodeCon
    {
        // Constructors

        public TraceCodeCon(WorldCon worldCon) : base(worldCon) { }

        // Protected properties

        protected override Property Shader => ShaderType.TraceShader();

        protected override IScript ShaderSet => TraceSelection;

        protected override string GetRegion() => Resources.ShaderRegion_Trace;

        // Public methods

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
                WorldForm.ViewTraceCode.Click += ViewTraceCode_Click;
            else
                WorldForm.ViewTraceCode.Click -= ViewTraceCode_Click;
        }

        // Protected methods

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.WorldForm_ViewTraceCode, WorldForm.ViewTraceCode);
        }

        protected override void RunShaderCommand(string text) => TraceSelection.ForEach(p => Run(new TraceShaderCommand(p.Index, ShaderType, text)));

        protected override void UpdateUI()
        {
            base.UpdateUI();
            ToolStripUtils.EnableControls(
                !TraceSelection.IsEmpty,
                new Control[]
                {
                    CodeEdit.HorizontalToolbar,
                    CodeEdit.VerticalToolbar,
                    CodeEdit.PrimaryTextBox,
                    CodeEdit.SecondaryTextBox
                });
        }

        // Public methods

        public string GetFormula()
        {
            var script = GetScript();
            var first = script.FindFirstTokenLine(Tokens.BeginFormula);
            var last = script.FindFirstTokenLine(Tokens.EndFormula);
            return 0 <= first && first < last ? script.GetLines(first, last - first) : string.Empty;
        }

        public void SetFormula(string formula)
        {
            foreach (var trace in TraceSelection.Traces)
            {
                var script = trace.GetScript(ShaderType);
                var beginLine = script.FindFirstTokenLine(Tokens.BeginFormula) + 1;
                var endLine = script.FindFirstTokenLine(Tokens.EndFormula);
                if (0 > beginLine || beginLine >= endLine)
                    continue;
                script = $"{script.GetLines(0, beginLine)}{formula}{script.GetLines(endLine, script.GetLineCount() - endLine)}";
                Run(new TraceShaderCommand(trace.Index, ShaderType, script));
            }
        }

        private void ViewTraceCode_Click(object sender, EventArgs e) => ToggleVisibility();
    }
}