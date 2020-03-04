namespace TabbyCat.Models
{
    using OpenTK.Graphics.OpenGL;

    public abstract class Code
    {
        #region Constructors

        public Code() => Init();

        protected Code(Code code) => CopyFrom(code);

        #endregion

        #region Public Properties

        public string Shader1Vertex { get; set; }
        public string Shader2TessControl { get; set; }
        public string Shader3TessEvaluation { get; set; }
        public string Shader4Geometry { get; set; }
        public string Shader5Fragment { get; set; }
        public string Shader6Compute { get; set; }

        #endregion

        #region Internal Methods

        internal string GetScript(ShaderType shaderType)
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
            }
            return string.Empty;
        }

        internal void SetScript(ShaderType shaderType, string script)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    Shader1Vertex = script;
                    break;
                case ShaderType.TessControlShader:
                    Shader2TessControl = script;
                    break;
                case ShaderType.TessEvaluationShader:
                    Shader3TessEvaluation = script;
                    break;
                case ShaderType.GeometryShader:
                    Shader4Geometry = script;
                    break;
                case ShaderType.FragmentShader:
                    Shader5Fragment = script;
                    break;
                case ShaderType.ComputeShader:
                    Shader6Compute = script;
                    break;
            }
        }

        #endregion

        #region Private Methods

        private void CopyFrom(Code code)
        {
            Shader1Vertex = code.Shader1Vertex;
            Shader2TessControl = code.Shader2TessControl;
            Shader3TessEvaluation = code.Shader3TessEvaluation;
            Shader4Geometry = code.Shader4Geometry;
            Shader5Fragment = code.Shader5Fragment;
            Shader6Compute = code.Shader6Compute;
        }

        private void Init()
        {
            Shader1Vertex = string.Empty;
            Shader2TessControl = string.Empty;
            Shader3TessEvaluation = string.Empty;
            Shader4Geometry = string.Empty;
            Shader5Fragment = string.Empty;
            Shader6Compute = string.Empty;
        }

        #endregion
    }
}
