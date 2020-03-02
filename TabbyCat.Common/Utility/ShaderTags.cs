namespace TabbyCat.Common.Utility
{
    using OpenTK.Graphics.OpenGL;

    public static class ShaderTags
    {
        public static string GetTag(this ShaderType shaderType)
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
    }
}
