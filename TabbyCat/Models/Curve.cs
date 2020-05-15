namespace TabbyCat.Models
{
    using OpenTK.Graphics.OpenGL;
    using Properties;
    using Types;

    public class Curve : Shape
    {
        public Curve()
        {
            Description = Resources.Property_Curve;
            Pattern = Pattern.Lines;
            StripeCount = new Vector3i(1000, 0, 0);
            SetFormula(ShaderType.VertexShader, Resources.Curve_VertexFormula);
        }
    }
}
