namespace TabbyCat.Controllers
{
    using Commands;
    using Properties;
    using System;
    using System.Windows.Forms;
    using Types;
    using Utils;

    public class ShapeCodeCon : CodeCon
    {
        // Constructors

        public ShapeCodeCon(WorldCon worldCon) : base(worldCon) { }

        // Protected properties

        protected override Property Shader => ShaderType.ShapeShader();

        protected override IScript ShaderSet => ShapeSelection;

        protected override string GetRegion() => Resources.ShaderRegion_Shape;

        // Public methods

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
                WorldForm.ViewShapeCode.Click += ViewShapeCode_Click;
            else
                WorldForm.ViewShapeCode.Click -= ViewShapeCode_Click;
        }

        // Protected methods

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.WorldForm_ViewShapeCode, WorldForm.ViewShapeCode);
        }

        protected override void RunShaderCommand(string text) => ShapeSelection.ForEach(p => Run(new ShapeShaderCommand(p.Index, ShaderType, text)));

        protected override void UpdateUI()
        {
            base.UpdateUI();
            ToolStripUtils.EnableControls(
                !ShapeSelection.IsEmpty,
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
            foreach (var shape in ShapeSelection.Shapes)
            {
                var script = shape.GetScript(ShaderType);
                var beginLine = script.FindFirstTokenLine(Tokens.BeginFormula) + 1;
                var endLine = script.FindFirstTokenLine(Tokens.EndFormula);
                if (0 > beginLine || beginLine >= endLine)
                    continue;
                script = $"{script.GetLines(0, beginLine)}{formula}{script.GetLines(endLine, script.GetLineCount() - endLine)}";
                Run(new ShapeShaderCommand(shape.Index, ShaderType, script));
            }
        }

        private void ViewShapeCode_Click(object sender, EventArgs e) => ToggleVisibility();
    }
}