namespace TabbyCat.Models
{
    using OpenTK.Graphics.OpenGL;
    using System;
    using TabbyCat.Common.Utility;

    /// <summary>
    /// Base class for Scene and Trace (but not Selection).
    /// Provides concrete string properties for shader code.
    /// </summary>
    public abstract class Code : IShaderSet
    {
        #region Constructors

        protected Code() { }

        protected Code(Code code) => CopyFrom(code);

        #endregion

        #region Public Properties

        public string Shader1Vertex { get; set; } = string.Empty;
        public string Shader2TessControl { get; set; } = string.Empty;
        public string Shader3TessEvaluation { get; set; } = string.Empty;
        public string Shader4Geometry { get; set; } = string.Empty;
        public string Shader5Fragment { get; set; } = string.Empty;
        public string Shader6Compute { get; set; } = string.Empty;

        #endregion

        #region Public Methods

        public string GetScript(ShaderType shaderType)
        {
            switch(shaderType)
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

        #region Private Methods

        private void CopyFrom(IShaderSet source) => Array.ForEach(
            Shaders.All,
            p => SetScript(p, source.GetScript(p)));

        #endregion
    }
}
