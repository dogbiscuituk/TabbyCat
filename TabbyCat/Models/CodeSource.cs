namespace TabbyCat.Models
{
    using OpenTK.Graphics.OpenGL;
    using TabbyCat.Properties;

    public abstract class CodeSource
    {
        #region Public Properties

        internal string Shader1Vertex { get; set; }
        internal string Shader2TessControl { get; set; }
        internal string Shader3TessEvaluation { get; set; }
        internal string Shader4Geometry { get; set; }
        internal string Shader5Fragment { get; set; }
        internal string Shader6Compute { get; set; }

        #endregion

        #region Public Methods

        protected virtual void CopyFrom(CodeSource source)
        {
            Shader1Vertex = source.Shader1Vertex;
            Shader2TessControl = source.Shader2TessControl;
            Shader3TessEvaluation = source.Shader3TessEvaluation;
            Shader4Geometry = source.Shader4Geometry;
            Shader5Fragment = source.Shader5Fragment;
            Shader6Compute = source.Shader6Compute;
        }

        protected virtual void RestoreDefaults()
        {
            Shader1Vertex = Resources.VertexHead;
            Shader2TessControl = Defaults.Shader2TessControl;
            Shader3TessEvaluation = Defaults.Shader3TessEvaluation;
            Shader4Geometry = Defaults.Shader4Geometry;
            Shader5Fragment = Resources.FragmentHead;
            Shader6Compute = Defaults.Shader6Compute;
        }

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

        #region Private Classes

        private class Defaults
        {
            internal const string
                Shader2TessControl = "",
                Shader3TessEvaluation = "",
                Shader4Geometry = "",
                Shader6Compute = "";
        }

        #endregion
    }
}
