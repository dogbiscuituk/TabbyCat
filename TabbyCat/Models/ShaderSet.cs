namespace TabbyCat.Models
{
    using OpenTK.Graphics.OpenGL;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class ShaderSet : IShaderSet
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

        public int GetActiveShaderCount() =>
            GetAllShaders().Count(p => !string.IsNullOrWhiteSpace(p));

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

        #region Private

        private IEnumerable<string> GetAllShaders() => new List<string>
        {
            Shader1Vertex,
            Shader2TessControl,
            Shader3TessEvaluation,
            Shader4Geometry,
            Shader5Fragment,
            Shader6Compute
        };

        #endregion
    }
}
