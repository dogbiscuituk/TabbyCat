namespace TabbyCat.Models
{
    using OpenTK;
    using TabbyCat.Common.Types;

    public interface ITrace : IShaderSet
    {
        string Description { get; set; }
        Vector3 Location { get; set; }
        Vector3 Maximum { get; set; }
        Vector3 Minimum { get; set; }
        Vector3 Orientation { get; set; }
        Pattern Pattern { get; set; }
        Vector3 Scale { get; set; }
        Vector3 StripCount { get; set; }
        bool? Visible { get; set; }
    }
}
