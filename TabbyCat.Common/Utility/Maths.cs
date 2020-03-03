namespace TabbyCat.Common.Utility
{
    using OpenTK;
    using System.Drawing;
    using TabbyCat.Common.Types;

    public static class Maths
    {
        public static Matrix4d CreateCameraView(Camera camera) => CreateCameraView(camera.Position, camera.Focus);

        public static Matrix4d CreateCameraView(Vector3d position, Vector3d focus) =>
            Matrix4d.LookAt(position, focus, new Vector3d(0, 1, 0));

        public static Matrix4d CreateProjection(Projection p) => CreateProjection(p, new Size(16, 9));

        public static Matrix4d CreateProjection(Projection p, Size s)
        {
            switch (p.ProjectionType)
            {
                case ProjectionType.Orthographic:
                    return Matrix4d.CreateOrthographic(p.Width, p.Height, p.Near, p.Far);
                case ProjectionType.OrthographicOffset:
                    return Matrix4d.CreateOrthographicOffCenter(p.Left, p.Right, p.Bottom, p.Top, p.Near, p.Far);
                case ProjectionType.Perspective:
                    return Matrix4d.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(p.FieldOfView), (float)s.Width / s.Height, p.Near, p.Far);
                case ProjectionType.PerspectiveOffset:
                    return Matrix4d.CreatePerspectiveOffCenter(p.Left, p.Right, p.Bottom, p.Top, p.Near, p.Far);
            }
            return Matrix4d.Identity;
        }

        public static Matrix4d CreateTransformation(Vector3d location, Vector3d orientation, Vector3d scale) =>
            Matrix4d.Scale(scale.X, scale.Y, scale.Z) *
            Matrix4d.CreateRotationZ(MathHelper.DegreesToRadians(orientation.Z)) *
            Matrix4d.CreateRotationY(MathHelper.DegreesToRadians(orientation.Y)) *
            Matrix4d.CreateRotationX(MathHelper.DegreesToRadians(orientation.X)) *
            Matrix4d.CreateTranslation(location);

        public static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);
    }
}
