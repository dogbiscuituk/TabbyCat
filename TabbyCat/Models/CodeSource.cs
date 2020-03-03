namespace TabbyCat.Models
{
    using Newtonsoft.Json;
    using OpenTK.Graphics.OpenGL;

    internal abstract class CodeSource
    {
        [JsonProperty]
        internal string _Shader1Vertex;
        internal string Shader1Vertex
        {
            get => _Shader1Vertex;
            set
            {
                if (Shader1Vertex != value)
                {
                    _Shader1Vertex = value;
                    OnPropertiesChanged(nameof(Shader1Vertex));
                }
            }
        }

        [JsonProperty]
        internal string _Shader2TessControl;
        internal string Shader2TessControl
        {
            get => _Shader2TessControl;
            set
            {
                if (Shader2TessControl != value)
                {
                    _Shader2TessControl = value;
                    OnPropertiesChanged(nameof(Shader2TessControl));
                }
            }
        }

        [JsonProperty]
        internal string _Shader3TessEvaluation;
        internal string Shader3TessEvaluation
        {
            get => _Shader3TessEvaluation;
            set
            {
                if (Shader3TessEvaluation != value)
                {
                    _Shader3TessEvaluation = value;
                    OnPropertiesChanged(nameof(Shader3TessEvaluation));
                }
            }
        }

        [JsonProperty]
        internal string _Shader4Geometry;
        internal string Shader4Geometry
        {
            get => _Shader4Geometry;
            set
            {
                if (Shader4Geometry != value)
                {
                    _Shader4Geometry = value;
                    OnPropertiesChanged(nameof(Shader4Geometry));
                }
            }
        }

        [JsonProperty]
        internal string _Shader5Fragment;
        internal string Shader5Fragment
        {
            get => _Shader5Fragment;
            set
            {
                if (Shader5Fragment != value)
                {
                    _Shader5Fragment = value;
                    OnPropertiesChanged(nameof(Shader5Fragment));
                }
            }
        }

        [JsonProperty]
        internal string _Shader6Compute;
        internal string Shader6Compute
        {
            get => _Shader6Compute;
            set
            {
                if (Shader6Compute != value)
                {
                    _Shader6Compute = value;
                    OnPropertiesChanged(nameof(Shader6Compute));
                }
            }
        }

        #region Protected Methods

        internal abstract void OnPropertiesChanged(params string[] propertyNames);

        #endregion

        internal string GetScript(ShaderType shaderType)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    return _Shader1Vertex;
                case ShaderType.TessControlShader:
                    return _Shader2TessControl;
                case ShaderType.TessEvaluationShader:
                    return _Shader3TessEvaluation;
                case ShaderType.GeometryShader:
                    return _Shader4Geometry;
                case ShaderType.FragmentShader:
                    return _Shader5Fragment;
                case ShaderType.ComputeShader:
                    return _Shader6Compute;
            }
            return string.Empty;
        }

        internal void SetScript(ShaderType shaderType, string script)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    _Shader1Vertex = script;
                    break;
                case ShaderType.TessControlShader:
                    _Shader2TessControl = script;
                    break;
                case ShaderType.TessEvaluationShader:
                    _Shader3TessEvaluation = script;
                    break;
                case ShaderType.GeometryShader:
                    _Shader4Geometry = script;
                    break;
                case ShaderType.FragmentShader:
                    _Shader5Fragment = script;
                    break;
                case ShaderType.ComputeShader:
                    _Shader6Compute = script;
                    break;
            }
        }

        public void CopyFrom(CodeSource source)
        {
            _Shader1Vertex = source.Shader1Vertex;
            _Shader2TessControl = source.Shader2TessControl;
            _Shader3TessEvaluation = source.Shader3TessEvaluation;
            _Shader4Geometry = source.Shader4Geometry;
            _Shader5Fragment = source.Shader5Fragment;
            _Shader6Compute = source.Shader6Compute;
        }
    }
}
