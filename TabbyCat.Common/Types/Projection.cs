namespace TabbyCat.Common.Types
{
    using Newtonsoft.Json;
    using OpenTK;
    using TabbyCat.Common.Converters;

    public class Projection
    {
        public Projection(ProjectionType projectionType, float fieldOfView, Vector3 frustumMin, Vector3 frustumMax)
        {
            ProjectionType = projectionType;
            FieldOfView = fieldOfView;
            FrustumMin = frustumMin;
            FrustumMax = frustumMax;
        }

        public Projection(Projection projection)
        {
            if (projection == null)
                return;
            ProjectionType = projection.ProjectionType;
            FieldOfView = projection.FieldOfView;
            FrustumMin = projection.FrustumMin;
            FrustumMax = projection.FrustumMax;
    }

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

        public Projection(Projection projection, string field, object value) : this(projection)
        {
            switch (field)
            {
                case nameof(ProjectionType):
                    ProjectionType = (ProjectionType)value;
                    return;
                case nameof(FieldOfView):
                    FieldOfView = (float)value;
                    return;
                case nameof(FrustumMin):
                    FrustumMin = (Vector3)value;
                    return;
                case nameof(FrustumMax):
                    FrustumMax = (Vector3)value;
                    return;
            }
        }

        public float FieldOfView { get; set; }
        public ProjectionType ProjectionType { get; set; }

        [JsonConverter(typeof(Vector3Converter))] public Vector3 FrustumMax { get; set; }
        [JsonConverter(typeof(Vector3Converter))] public Vector3 FrustumMin { get; set; }

        [JsonIgnore] public float Bottom => FrustumMin.Y;
        [JsonIgnore] public float Depth => Far - Near;
        [JsonIgnore] public float Far => FrustumMax.Z;
        [JsonIgnore] public float Height => Top - Bottom;
        [JsonIgnore] public float Left => FrustumMin.X;
        [JsonIgnore] public float Near => FrustumMin.Z;
        [JsonIgnore] public float Right => FrustumMax.X;
        [JsonIgnore] public float Top => FrustumMax.Y;
        [JsonIgnore] public float Width => Right - Left;
    }
}
