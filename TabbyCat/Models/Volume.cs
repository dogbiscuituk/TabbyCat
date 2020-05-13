namespace TabbyCat.Models
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using Properties;
    using Types;

    public class Volume : Shape
    {
        public Volume()
        {
            Description = Resources.Property_Volume;
            Pattern = Pattern.Quads;
            StripeCount = new Vector3(10, 10, 10);
            SetFormula(ShaderType.VertexShader, Resources.Volume_VertexFormula);
        }
    }
}
