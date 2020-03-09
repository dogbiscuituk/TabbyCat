namespace TabbyCat.Models
{
    using OpenTK.Graphics.OpenGL;

    public abstract class Shaders : IShaders
    {
        #region Public Properties

        public abstract string Shader1Vertex { get; set; }
        public abstract string Shader2TessControl { get; set; }
        public abstract string Shader3TessEvaluation { get; set; }
        public abstract string Shader4Geometry { get; set; }
        public abstract string Shader5Fragment { get; set; }
        public abstract string Shader6Compute { get; set; }

        #endregion

        #region Public Methods

        public string GetScript(ShaderType shaderType)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    return Shader1Vertex;
                case ShaderType.TessControlShader:
                    return Shader2TessControl;
                case ShaderType.TessEvaluationShader:
                    return Shader3TessEvaluation;
                case ShaderType.GeometryShader:
                    return Shader4Geometry;
                case ShaderType.FragmentShader:
                    return Shader5Fragment;
                case ShaderType.ComputeShader:
                    return Shader6Compute;
                default:
                    return string.Empty;
            }
        }

        public void SetScript(ShaderType shaderType, string value)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    Shader1Vertex = value;
                    break;
                case ShaderType.TessControlShader:
                    Shader2TessControl = value;
                    break;
                case ShaderType.TessEvaluationShader:
                    Shader3TessEvaluation = value;
                    break;
                case ShaderType.GeometryShader:
                    Shader4Geometry = value;
                    break;
                case ShaderType.FragmentShader:
                    Shader5Fragment = value;
                    break;
                case ShaderType.ComputeShader:
                    Shader6Compute = value;
                    break;
            }
        }

        #endregion
    }
}
