﻿namespace TabbyCat.Controllers
{
    using Commands;
    using Common.Types;
    using Common.Utils;
    using Jmk.Common;
    using Properties;
    using System.Windows.Forms;

    internal class TraceCodeCon : CodeCon
    {
        internal TraceCodeCon(WorldCon worldCon) : base(worldCon) { }

        protected override string ShaderName => ShaderType.TraceShaderName();

        protected override IScript ShaderSet => Selection;

        protected override string GetRegion() => Resources.ShaderRegion_Trace;

        protected override void RunShaderCommand(string text) => Selection.ForEach(p => Run(new TraceShaderCommand(p.Index, ShaderType, text)));

        protected override void UpdateUI()
        {
            base.UpdateUI();
            ToolStripUtils.EnableControls(
                !Selection.IsEmpty,
                new Control[]
                {
                    CodeEdit.HorizontalToolbar,
                    CodeEdit.VerticalToolbar,
                    CodeEdit.PrimaryTextBox,
                    CodeEdit.SecondaryTextBox
                });
        }

        internal string GetFormula()
        {
            var script = GetScript();
            var first = script.FindFirstTokenLine(Tokens.BeginFormula);
            var last = script.FindFirstTokenLine(Tokens.EndFormula);
            return 0 <= first && first < last ? script.GetLines(first, last - first) : string.Empty;
        }

        internal void SetFormula(string formula)
        {
            foreach (var trace in Selection.Traces)
            {
                var script = trace.GetScript(ShaderType);
                var beginLine = script.FindFirstTokenLine(Tokens.BeginFormula) + 1;
                var endLine = script.FindFirstTokenLine(Tokens.EndFormula);
                if (0 <= beginLine && beginLine < endLine)
                {
                    script = $"{script.GetLines(0, beginLine)}{formula}{script.GetLines(endLine, script.GetLineCount() - endLine)}";
                    Run(new TraceShaderCommand(trace.Index, ShaderType, script));
                }
            }
        }
    }
}