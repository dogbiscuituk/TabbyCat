namespace TabbyCat.Models
{
    using System.ComponentModel;

    public enum ProjectionType
    {
        [Description("Orthographic")]
        Orthographic,
        [Description("Orthographic (Offset)")]
        OrthographicOffset,
        [Description("Perspective")]
        Perspective,
        [Description("Perspective (Offset)")]
        PerspectiveOffset
    }
}
