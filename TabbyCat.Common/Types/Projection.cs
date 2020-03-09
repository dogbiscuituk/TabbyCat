namespace TabbyCat.Common.Types
{
    using Newtonsoft.Json;
    using OpenTK;
    using TabbyCat.Common.Converters;

    public class Projection
    {
        #region Constructors

        public Projection(ProjectionType projectionType, double fieldOfView, Vector3d frustumMin, Vector3d frustumMax)
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

        public Projection(double width, double height, double near, double far)
        {
            ProjectionType = ProjectionType.Orthographic;
            FrustumMin = new Vector3d(-width / 2, -height / 2, near);
            FrustumMax = new Vector3d(width / 2, height / 2, far);
        }

        public Projection(double fieldOfView, double width, double height, double near, double far)
        {
            ProjectionType = ProjectionType.Perspective;
            FieldOfView = fieldOfView;
            FrustumMin = new Vector3d(-width / 2, -height / 2, near);
            FrustumMax = new Vector3d(width / 2, height / 2, far);
        }

        public Projection(ProjectionType projectionType, double left, double right, double bottom, double top, double near, double far)
        {
            ProjectionType = projectionType;
            FrustumMin = new Vector3d(left, bottom, near);
            FrustumMax = new Vector3d(right, top, far);
        }

        public Projection(Projection projection, string field, object value) : this(projection)
        {
            switch (field)
            {
                case nameof(ProjectionType):
                    ProjectionType = (ProjectionType)value;
                    return;
                case nameof(FieldOfView):
                    FieldOfView = (double)value;
                    return;
                case nameof(FrustumMin):
                    FrustumMin = (Vector3d)value;
                    return;
                case nameof(FrustumMax):
                    FrustumMax = (Vector3d)value;
                    return;
            }
        }

        #endregion

        public double FieldOfView { get; set; }
        public ProjectionType ProjectionType { get; set; }

        [JsonConverter(typeof(Vector3dConverter))] public Vector3d FrustumMax { get; set; }
        [JsonConverter(typeof(Vector3dConverter))] public Vector3d FrustumMin { get; set; }

        public double Bottom => FrustumMin.Y;
        public double Depth => Far - Near;
        public double Far => FrustumMax.Z;
        public double Height => Top - Bottom;
        public double Left => FrustumMin.X;
        public double Near => FrustumMin.Z;
        public double Right => FrustumMax.X;
        public double Top => FrustumMax.Y;
        public double Width => Right - Left;
    }
}
