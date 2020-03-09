namespace TabbyCat.Common.Utility
{
    using OpenTK.Graphics.OpenGL;

    public static class ShaderNames
    {
        public static string SceneShaderName(this ShaderType shaderType) =>
            $"Scene {shaderType.ShaderTag()} Shader";

        public static string ShaderName(this ShaderType shaderType) =>
            $"{shaderType.ShaderTag()} Shader";

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

        public static string TraceShaderName(this ShaderType shaderType) =>
            $"Trace {shaderType.ShaderTag()} Shader";
    }
}
