namespace TabbyCat.Common.Utils
{
    using OpenTK.Graphics.OpenGL;
    using System.Collections.Generic;

    public static class ShaderUtils
    {
        public static IEnumerable<ShaderType> All { get; } = new[]
        {
            ShaderType.VertexShader,
            ShaderType.TessControlShader,
            ShaderType.TessEvaluationShader,
            ShaderType.GeometryShader,
            ShaderType.FragmentShader,
            ShaderType.ComputeShader
        };

        public static ShaderType Next(this ShaderType shaderType)
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

        public static string SceneShaderName(this ShaderType shaderType) => $"Scene {shaderType.ShaderTag()} Shader";

        public static string ShaderName(this ShaderType shaderType) => $"{shaderType.ShaderTag()} Shader";

        public static string ShaderTag(this ShaderType shaderType)
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

        public static string TraceShaderName(this ShaderType shaderType) => $"Trace {shaderType.ShaderTag()} Shader";
    }
}
