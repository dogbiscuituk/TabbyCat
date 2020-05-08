namespace TabbyCat.Models
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using Properties;
    using Types;

    public class Surface : Trace
    {
        public Surface() : base() => Init();

        private void Init()
        {
            Description = Resources.Property_Surface;
            Pattern = Pattern.Quads;
            StripeCount = new Vector3(30, 30, 0);
            SetFormula(ShaderType.VertexShader, Resources.Surface_VertexFormula);
        }
    }
}
