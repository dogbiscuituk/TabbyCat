namespace TabbyCat.Models
{
    using OpenTK;
    using TabbyCat.Common.Types;

    public interface ITrace
    {
        string Description { get; set; }
        Vector3d Location { get; set; }
        Vector3d Maximum { get; set; }
        Vector3d Minimum { get; set; }
        Vector3d Orientation { get; set; }
        Pattern Pattern { get; set; }
        Vector3d Scale { get; set; }
        string Shader1Vertex { get; set; }
        string Shader2TessControl { get; set; }
        string Shader3TessEvaluation { get; set; }
        string Shader4Geometry { get; set; }
        string Shader5Fragment { get; set; }
        string Shader6Compute { get; set; }
        Vector3 StripCount { get; set; }
        bool? Visible { get; set; }
    }
}
