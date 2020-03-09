namespace TabbyCat.Models
{
    using OpenTK.Graphics.OpenGL;

    public interface IShaders
    {
        string Shader1Vertex { get; set; }
        string Shader2TessControl { get; set; }
        string Shader3TessEvaluation { get; set; }
        string Shader4Geometry { get; set; }
        string Shader5Fragment { get; set; }
        string Shader6Compute { get; set; }

        string GetScript(ShaderType shaderType);
        void SetScript(ShaderType shaderType, string script);
    }
}
