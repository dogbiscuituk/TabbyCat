namespace TabbyCat.Common.Types
{
    using OpenTK.Graphics.OpenGL;

    public interface IShaderSet
    {
        string GetScript(ShaderType shaderType);
        void SetScript(ShaderType shaderType, string value);
    }
}
