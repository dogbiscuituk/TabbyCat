namespace TabbyCat.Utils
{
    using OpenTK.Graphics.OpenGL;
    using Properties;
    using System.Collections.Generic;
    using System.Globalization;
    using Types;

    internal static class ShaderUtils
    {
        internal static IEnumerable<ShaderType> All { get; } = new[]
        {
            ShaderType.VertexShader,
            ShaderType.TessControlShader,
            ShaderType.TessEvaluationShader,
            ShaderType.GeometryShader,
            ShaderType.FragmentShader,
            ShaderType.ComputeShader
        };

        internal static ShaderType Next(this ShaderType shaderType)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    return ShaderType.TessControlShader;
                case ShaderType.TessControlShader:
                    return ShaderType.TessEvaluationShader;
                case ShaderType.TessEvaluationShader:
                    return ShaderType.GeometryShader;
                case ShaderType.GeometryShader:
                    return ShaderType.FragmentShader;
                case ShaderType.FragmentShader:
                    return ShaderType.ComputeShader;
                default:
                    return ShaderType.VertexShader;
            }
        }

        internal static Property SceneShader(this ShaderType shaderType) => shaderType.ShaderProperty() + (Property.SceneVertexShader - Property.VertexShader);

        internal static string SceneShaderName(this ShaderType shaderType) => shaderType.ShaderName(Resources.Property_Scene);

        internal static string ShaderName(this ShaderType shaderType) => shaderType.ShaderName(Resources.PropertyName_ShaderScope);

        internal static string ShaderName(this ShaderType shaderType, string scope) => string.Format(
            CultureInfo.CurrentCulture,
            Resources.PropertyName_ShaderFormat,
            scope,
            shaderType.ShaderTag(),
            Resources.PropertyName_Shader);

        internal static Property ShaderProperty(this ShaderType shaderType)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    return Property.VertexShader;
                case ShaderType.TessControlShader:
                    return Property.TessellationControlShader;
                case ShaderType.TessEvaluationShader:
                    return Property.TessellationEvaluationShader;
                case ShaderType.GeometryShader:
                    return Property.GeometryShader;
                case ShaderType.FragmentShader:
                    return Property.FragmentShader;
                case ShaderType.ComputeShader:
                    return Property.ComputeShader;
                default:
                    return 0;
            }
        }

        internal static string ShaderTag(this ShaderType shaderType)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    return "Vertex";
                case ShaderType.TessControlShader:
                    return "Tessellation Control";
                case ShaderType.TessEvaluationShader:
                    return "Tessellation Evaluation";
                case ShaderType.GeometryShader:
                    return "Geometry";
                case ShaderType.FragmentShader:
                    return "Fragment";
                case ShaderType.ComputeShader:
                    return "Compute";
                default:
                    return string.Empty;
            }
        }

        internal static Property TraceShader(this ShaderType shaderType) => shaderType.ShaderProperty() + (Property.TraceVertexShader - Property.VertexShader);

        internal static string TraceShaderName(this ShaderType shaderType) => shaderType.ShaderName(Resources.Property_Trace);
    }
}
