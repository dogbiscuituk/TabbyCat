namespace TabbyCat.Common.Types
{
    public interface IShaders : IScript
    {
        string VertexShader { get; set; }
        string TessControlShader { get; set; }
        string TessEvaluationShader { get; set; }
        string GeometryShader { get; set; }
        string FragmentShader { get; set; }
        string ComputeShader { get; set; }
    }
}
