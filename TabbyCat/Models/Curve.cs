namespace TabbyCat.Models
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using Properties;
    using Types;

    public class Curve : Trace
    {
        public Curve() : base()
        {
            Init();
        }

        private void Init()
        {
            Description = "Curve";
            Pattern = Pattern.Lines;
            StripeCount = new Vector3(1000, 0, 0);
            SetFormula(ShaderType.VertexShader, Resources.Curve_VertexFormula);
        }
    }
}
