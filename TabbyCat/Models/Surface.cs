namespace TabbyCat.Models
{
    using Common.Types;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using Properties;

    public class Surface : Trace
    {
        public Surface() : base() => Init();

        private void Init()
        {
            Description = "Surface";
            Pattern = Pattern.Quads;
            StripeCount = new Vector3(30, 30, 0);
            SetFormula(ShaderType.VertexShader, Resources.Surface_VertexFormula);
        }
    }
}
