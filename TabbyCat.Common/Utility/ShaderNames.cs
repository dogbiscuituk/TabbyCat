namespace TabbyCat.Common.Utility
{
    using OpenTK.Graphics.OpenGL;

    public static class ShaderNames
    {
        public static string GetName(this ShaderType shaderType)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    return "Shader 1: Vertex (mandatory)";
                case ShaderType.TessControlShader:
                    return "Shader 2: Tessellation Control";
                case ShaderType.TessEvaluationShader:
                    return "Shader 3: Tessellation Evaluation";
                case ShaderType.GeometryShader:
                    return "Shader 4: Geometry";
                case ShaderType.FragmentShader:
                    return "Shader 5: Fragment (mandatory)";
                case ShaderType.ComputeShader:
                    return "Shader 6: Compute";
                default:
                    return string.Empty;
            }
        }
    }
}
