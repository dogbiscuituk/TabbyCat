namespace TabbyCat.Controllers
{
    using Commands;
    using FastColoredTextBoxNS;
    using Jmk.Common;
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Types;
    using Utils;

    internal class ShaderCodeCon : CodeCon
    {
        internal ShaderCodeCon(WorldCon worldCon) : base(worldCon) { }

        private readonly List<int> Breaks = new List<int>();

        protected override Property Shader => ShaderType.ShaderProperty();

        protected override IScript ShaderSet => RenderCon;

        protected override string GetRegion() => Resources.ShaderRegion_All;

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                WorldForm.ViewShaderCode.Click += ViewShaderCode_Click;
            }
            else
            {
                WorldForm.ViewShaderCode.Click -= ViewShaderCode_Click;
            }
        }

        protected override void LoadScript()
        {
            base.LoadScript();
            FindBreaks(GetScript());
        }

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.WorldForm_ViewShaderCode, WorldForm.ViewShaderCode);
        }

        protected override void RunShaderCommand(string text)
        {
            FindBreaks(text);
            if (Breaks.Any())
            {
                for (var traceNumber = 0; traceNumber <= Scene.Traces.Count; traceNumber++)
                {
                    string
                        oldScript = traceNumber == 0 ? Scene.GetScript(ShaderType) : Scene.Traces[traceNumber - 1].GetScript(ShaderType),
                        newScript = ExtractScript(text, traceNumber).Outdent("  ");
                    if (newScript != oldScript)
                        if (traceNumber == 0)
                            Run(new SceneShaderCommand(ShaderType, newScript));
                        else
                            Run(new TraceShaderCommand(traceNumber - 1, ShaderType, newScript));
                }
            }
        }

        protected override bool CodeChanged(Property property)
        {
            switch (property)
            {
                case Property.GLTargetVersion:
                case Property.Traces:
                    return true;
                default:
                    return
                        property == Shader ||
                        property == ShaderType.SceneShader() ||
                        property == ShaderType.TraceShader();
            }
        }

        private bool AddBreak(int b)
        {
            var ok = !Breaks.Any() || b > Breaks.Last();
            if (ok)
                Breaks.Add(b);
            return ok;
        }

        private string ExtractScript(string text, int traceNumber)
        {
            var breakIndex = 2 * traceNumber + 1;
            int start = Breaks[breakIndex], end = Breaks[breakIndex + 1];
            return text.GetLines(start, end - start);
        }

        private void FindBreaks(string script)
        {
            Breaks.Clear();
            if (string.IsNullOrWhiteSpace(script))
                return;
            var ok = AddBreak(0) && AddBreak(script.FindFirstTokenLine(Tokens.BeginScene) + 2) && AddBreak(script.FindFirstTokenLine(Tokens.EndScene) - 1);
            for (var index = 0; index < Scene.Traces.Count; index++)
                ok &= AddBreak(script.FindFirstTokenLine(Tokens.BeginTrace(index)) + 2) & AddBreak(script.FindFirstTokenLine(Tokens.EndTrace(index)) - 1);
            ok &= AddBreak(script.GetLineCount());
            if (!ok)
                Breaks.Clear();
            for (var index = 0; index < Breaks.Count; index += 2)
                PrimaryCon.AddSystemRange(new Range(PrimaryTextBox, 0, Breaks[index], 0, Breaks[index + 1]));
        }

        private void ViewShaderCode_Click(object sender, EventArgs e) => ToggleVisibility();
    }
}
