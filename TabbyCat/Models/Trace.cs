namespace TabbyCat.Models
{
    using OpenTK;

    public class Trace
    {
        public string Description { get; set; }
        public Vector3d Location { get; set; }
        public Vector3d Maximum { get; set; }
        public Vector3d Minimum { get; set; }
        public Vector3d Orientation { get; set; }
        public Pattern Pattern { get; set; }
        public Vector3 StripCount { get; set; }
    }
}
