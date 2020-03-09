namespace TabbyCat.Models
{
    using OpenTK;
    using TabbyCat.Common.Types;

    public interface ITrace : IShaders
    {
        string Description { get; set; }
        Vector3d Location { get; set; }
        Vector3d Maximum { get; set; }
        Vector3d Minimum { get; set; }
        Vector3d Orientation { get; set; }
        Pattern Pattern { get; set; }
        Vector3d Scale { get; set; }
        Vector3 StripCount { get; set; }
        bool? Visible { get; set; }
    }
}
