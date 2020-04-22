namespace TabbyCat.Models
{
    using Common.Types;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using Properties;

    public class Volume : Trace
    {
        public Volume() : base() => Init();

        private void Init()
        {
            Description = "Volume";
            Pattern = Pattern.Quads;
            StripeCount = new Vector3(10, 10, 10);
            SetFormula(ShaderType.VertexShader, Resources.Volume_VertexFormula);
        }
    }
}
