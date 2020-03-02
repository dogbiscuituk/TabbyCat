namespace TabbyCat.Models
{
    using Newtonsoft.Json;
    using OpenTK.Graphics.OpenGL;

    internal class Foo
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
                    OnPropertyChanged(nameof(Shader1Vertex));
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
                    OnPropertyChanged(nameof(Shader2TessControl));
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
                    OnPropertyChanged(nameof(Shader3TessEvaluation));
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
                    OnPropertyChanged(nameof(Shader4Geometry));
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
                    OnPropertyChanged(nameof(Shader5Fragment));
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
                    OnPropertyChanged(nameof(Shader6Compute));
                }
            }
        }

        #region Protected Methods

        internal virtual void OnPropertyChanged(string propertyName)
        {
        }

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
    }
}
