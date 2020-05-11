namespace TabbyCat.Controllers
{
    using Commands;
    using FastColoredTextBoxNS;
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Types;
    using Utils;

    public class ShaderCodeCon : CodeCon
    {
        // Constructors

        public ShaderCodeCon(WorldCon worldCon) : base(worldCon) { }

        // Private fields

        private readonly List<int> _breaks = new List<int>();

        // Protected properties

        protected override Property Shader => ShaderType.ShaderProperty();

        protected override IScript ShaderSet => RenderCon;

        // Public methods

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
                WorldForm.ViewShaderCode.Click += ViewShaderCode_Click;
            else
                WorldForm.ViewShaderCode.Click -= ViewShaderCode_Click;
        }

        // Protected methods

        protected override bool CodeChanged(Property property) => property.InvalidatesProgram();

        protected override string GetRegion() => Resources.ShaderRegion_All;

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
            if (!_breaks.Any())
                return;
            for (var traceNumber = 0; traceNumber <= Scene.Traces.Count; traceNumber++)
            {
                string
                    oldScript = traceNumber == 0 ? Scene.GetScript(ShaderType) : Scene.Traces[traceNumber - 1].GetScript(ShaderType),
                    newScript = ExtractScript(text, traceNumber).Outdent("  ");
                if (newScript == oldScript)
                    continue;
                if (traceNumber == 0)
                    Run(new SceneShaderCommand(ShaderType, newScript));
                else
                    Run(new TraceShaderCommand(traceNumber - 1, ShaderType, newScript));
            }
        }

        // Private methods

        private bool AddBreak(int b)
        {
            var ok = !_breaks.Any() || b > _breaks.Last();
            if (ok)
                _breaks.Add(b);
            return ok;
        }

        private string ExtractScript(string text, int traceNumber)
        {
            var breakIndex = 2 * traceNumber + 1;
            int start = _breaks[breakIndex], end = _breaks[breakIndex + 1];
            return text.GetLines(start, end - start);
        }

        private void FindBreaks(string script)
        {
            _breaks.Clear();
            if (string.IsNullOrWhiteSpace(script))
                return;
            var ok = AddBreak(0) && AddBreak(script.FindFirstTokenLine(Tokens.BeginScene) + 2) && AddBreak(script.FindFirstTokenLine(Tokens.EndScene) - 1);
            for (var index = 0; index < Scene.Traces.Count; index++)
                ok &= AddBreak(script.FindFirstTokenLine(Tokens.BeginTrace(index)) + 2) & AddBreak(script.FindFirstTokenLine(Tokens.EndTrace(index)) - 1);
            ok &= AddBreak(script.GetLineCount());
            if (!ok)
                _breaks.Clear();
            for (var index = 0; index < _breaks.Count; index += 2)
                PrimaryCon.AddSystemRange(new Range(PrimaryTextBox, 0, _breaks[index], 0, _breaks[index + 1]));
        }

        private void ViewShaderCode_Click(object sender, EventArgs e) => ToggleVisibility();
    }
}
