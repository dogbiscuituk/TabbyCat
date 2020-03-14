namespace TabbyCat.Models
{
    using OpenTK.Graphics.OpenGL;

    public interface IShaderSet
    {
        string GetScript(ShaderType shaderType);
        void SetScript(ShaderType shaderType, string value);
    }
}
