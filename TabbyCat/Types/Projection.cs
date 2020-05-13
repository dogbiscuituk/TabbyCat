namespace TabbyCat.Types
{
    using Converters;
    using Newtonsoft.Json;
    using OpenTK;

    public class Projection
    {
        public Projection(float width, float height, float near, float far)
        {
            ProjectionType = ProjectionType.Orthographic;
            FrustumMin = new Vector3(-width / 2, -height / 2, near);
            FrustumMax = new Vector3(width / 2, height / 2, far);
        }

        public Projection(float fieldOfView, float width, float height, float near, float far)
        {
            ProjectionType = ProjectionType.Perspective;
            FieldOfView = fieldOfView;
            FrustumMin = new Vector3(-width / 2, -height / 2, near);
            FrustumMax = new Vector3(width / 2, height / 2, far);
        }

        public Projection(ProjectionType projectionType, float left, float right, float bottom, float top, float near, float far)
        {
            ProjectionType = projectionType;
            FrustumMin = new Vector3(left, bottom, near);
            FrustumMax = new Vector3(right, top, far);
        }

        public float FieldOfView { get; set; }

        public ProjectionType ProjectionType { get; set; }

        [JsonConverter(typeof(Vector3Converter))]
        public Vector3 FrustumMax { get; set; }

        [JsonConverter(typeof(Vector3Converter))]
        public Vector3 FrustumMin { get; set; }

        [JsonIgnore]
        public float Bottom => FrustumMin.Y;

        [JsonIgnore]
        public float Depth => Far - Near;

        [JsonIgnore]
        public float Far => FrustumMax.Z;

        [JsonIgnore]
        public float Height => Top - Bottom;

        [JsonIgnore]
        public float Left => FrustumMin.X;

        [JsonIgnore]
        public float Near => FrustumMin.Z;

        [JsonIgnore]
        public float Right => FrustumMax.X;

        [JsonIgnore]
        public float Top => FrustumMax.Y;

        [JsonIgnore]
        public float Width => Right - Left;

        public static Projection Default => new Projection(75, 16, 9, 0.1f, 1000);

        public static bool operator ==(Projection a, Projection b) =>
            a?.ProjectionType == b?.ProjectionType &&
            a?.FieldOfView == b?.FieldOfView &&
            a?.FrustumMin == b?.FrustumMin &&
            a?.FrustumMax == b?.FrustumMax;

        public static bool operator !=(Projection a, Projection b) => !(a == b);

        public override bool Equals(object obj) => obj is Projection projection && projection == this;

        public override int GetHashCode() => (int)ProjectionType ^ FieldOfView.GetHashCode() ^ FrustumMin.GetHashCode() ^ FrustumMax.GetHashCode();

    }
}
