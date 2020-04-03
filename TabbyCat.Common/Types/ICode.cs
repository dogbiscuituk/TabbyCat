namespace TabbyCat.Common.Types
{
    public interface ICode : IShaderSet
    {
        string Shader1Vertex { get; set; }
        string Shader2TessControl { get; set; }
        string Shader3TessEvaluation { get; set; }
        string Shader4Geometry { get; set; }
        string Shader5Fragment { get; set; }
        string Shader6Compute { get; set; }
    }
}
