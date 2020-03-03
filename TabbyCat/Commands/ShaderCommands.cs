namespace TabbyCat.Commands
{
    using OpenTK.Graphics.OpenGL;
    using TabbyCat.Models;

    internal class SceneShaderCommand : ScenePropertyCommand<string>
    {
        internal SceneShaderCommand(ShaderType shaderType, string value) : base(shaderType.GetName(),
            value, s => s.GetScript(shaderType), (s, v) => s.SetScript(shaderType, v))
        { }
    }

    internal class SceneComputeShaderCommand : SceneShaderCommand
    {
        internal SceneComputeShaderCommand(string value) : base(ShaderType.ComputeShader, value) { }
    }

    internal class SceneFragmentShaderCommand : SceneShaderCommand
    {
        internal SceneFragmentShaderCommand(string value) : base(ShaderType.FragmentShader, value) { }
    }

    internal class SceneGeometryShaderCommand : SceneShaderCommand
    {
        internal SceneGeometryShaderCommand(string value) : base(ShaderType.GeometryShader, value) { }
    }

    internal class SceneTessControlShaderCommand : SceneShaderCommand
    {
        internal SceneTessControlShaderCommand(string value) : base(ShaderType.TessControlShader, value) { }
    }

    internal class SceneTessEvaluationShaderCommand : SceneShaderCommand
    {
        internal SceneTessEvaluationShaderCommand(string value) : base(ShaderType.TessEvaluationShader, value) { }
    }

    internal class SceneVertexShaderCommand : SceneShaderCommand
    {
        internal SceneVertexShaderCommand(string value) : base(ShaderType.VertexShader, value) { }
    }

    internal class TraceShaderCommand : TracePropertyCommand<string>
    {
        internal TraceShaderCommand(int index, ShaderType shaderType, string value) : base(index, shaderType.GetName(),
            value, t => t.GetScript(shaderType), (t, v) => t.SetScript(shaderType, v))
        { }
    }

    internal class TraceComputeShaderCommand : TraceShaderCommand
    {
        internal TraceComputeShaderCommand(int index, string value) : base(index, ShaderType.ComputeShader, value) { }
    }

    internal class TraceFragmentShaderCommand : TraceShaderCommand
    {
        internal TraceFragmentShaderCommand(int index, string value) : base(index, ShaderType.FragmentShader, value) { }
    }

    internal class TraceGeometryShaderCommand : TraceShaderCommand
    {
        internal TraceGeometryShaderCommand(int index, string value) : base(index, ShaderType.GeometryShader, value) { }
    }

    internal class TraceTessControlShaderCommand : TraceShaderCommand
    {
        internal TraceTessControlShaderCommand(int index, string value) : base(index, ShaderType.TessControlShader, value) { }
    }

    internal class TraceTessEvaluationShaderCommand : TraceShaderCommand
    {
        internal TraceTessEvaluationShaderCommand(int index, string value) : base(index, ShaderType.TessEvaluationShader, value) { }
    }

    internal class TraceVertexShaderCommand : TraceShaderCommand
    {
        internal TraceVertexShaderCommand(int index, string value) : base(index, ShaderType.VertexShader, value) { }
    }

    internal static class ShaderNames
    {
        internal static string GetName(this ShaderType shaderType)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader: return DisplayNames.Shader1Vertex;
                case ShaderType.TessControlShader: return DisplayNames.Shader2TessControl;
                case ShaderType.TessEvaluationShader: return DisplayNames.Shader3TessEvaluation;
                case ShaderType.GeometryShader: return DisplayNames.Shader4Geometry;
                case ShaderType.FragmentShader: return DisplayNames.Shader5Fragment;
                case ShaderType.ComputeShader: return DisplayNames.Shader6Compute;
                default: return string.Empty;
            }
        }

        internal static string GetTag(this ShaderType shaderType)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader: return "Vertex";
                case ShaderType.TessControlShader: return "Tessellation Control";
                case ShaderType.TessEvaluationShader: return "Tessellation Evaluation";
                case ShaderType.GeometryShader: return "Geometry";
                case ShaderType.FragmentShader: return "Fragment";
                case ShaderType.ComputeShader: return "Compute";
                default: return string.Empty;
            }
        }
    }
}
