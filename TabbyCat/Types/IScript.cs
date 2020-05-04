namespace TabbyCat.Types
{
    using OpenTK.Graphics.OpenGL;

    public interface IScript
    {
        string GetScript(ShaderType shaderType);
        void SetScript(ShaderType shaderType, string value);
    }
}
