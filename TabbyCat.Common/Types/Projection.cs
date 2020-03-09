namespace TabbyCat.Common.Types
{
    using Newtonsoft.Json;
    using OpenTK;
    using TabbyCat.Common.Converters;

    public class Projection
    {
        #region Constructors

        public Projection(ProjectionType projectionType, float fieldOfView, Vector3 frustumMin, Vector3 frustumMax)
        {
            ProjectionType = projectionType;
            FieldOfView = fieldOfView;
            FrustumMin = frustumMin;
            FrustumMax = frustumMax;
        }

        public Projection(Projection projection) :
            this(projection.ProjectionType, projection.FieldOfView, projection.FrustumMin, projection.FrustumMax)
        {
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

        #endregion

        public float FieldOfView { get; set; }
        public ProjectionType ProjectionType { get; set; }

        [JsonConverter(typeof(Vector3Converter))] public Vector3 FrustumMax { get; set; }
        [JsonConverter(typeof(Vector3Converter))] public Vector3 FrustumMin { get; set; }

        public float Bottom => FrustumMin.Y;
        public float Depth => Far - Near;
        public float Far => FrustumMax.Z;
        public float Height => Top - Bottom;
        public float Left => FrustumMin.X;
        public float Near => FrustumMin.Z;
        public float Right => FrustumMax.X;
        public float Top => FrustumMax.Y;
        public float Width => Right - Left;
    }
}
