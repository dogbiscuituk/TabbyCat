namespace TabbyCat.Models
{
    using OpenTK;

    public class Projection
    {
        public double FieldOfView { get; set; }
        public Vector3d FrustumMax { get; set; }
        public Vector3d FrustumMin { get; set; }
        public ProjectionType ProjectionType { get; set; }
    }
}
