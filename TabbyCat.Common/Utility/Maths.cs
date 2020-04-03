namespace TabbyCat.Common.Utility
{
    using OpenTK;
    using System.Drawing;
    using TabbyCat.Common.Types;

    public static class Maths
    {
        public static Matrix4 CreateCameraView(SimpleCamera camera) => CreateCameraView(camera.Position, camera.Focus);

        public static Matrix4 CreateCameraView(Vector3 position, Vector3 focus) =>
            Matrix4.LookAt(position, focus, Vector3.UnitY);

        public static Matrix4 CreateProjection(Projection p) => CreateProjection(p, new Size(16, 9));

        public static Matrix4 CreateProjection(Projection p, Size s)
        {
            switch (p.ProjectionType)
            {
                case ProjectionType.Orthographic:
                    return Matrix4.CreateOrthographic(p.Width, p.Height, p.Near, p.Far);
                case ProjectionType.OrthographicOffset:
                    return Matrix4.CreateOrthographicOffCenter(p.Left, p.Right, p.Bottom, p.Top, p.Near, p.Far);
                case ProjectionType.Perspective:
                    return Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(p.FieldOfView), (float)s.Width / s.Height, p.Near, p.Far);
                case ProjectionType.PerspectiveOffset:
                    return Matrix4.CreatePerspectiveOffCenter(p.Left, p.Right, p.Bottom, p.Top, p.Near, p.Far);
            }
            return Matrix4.Identity;
        }

        public static Matrix4 CreateTransformation(Vector3 location, Vector3 orientation, Vector3 scale) =>
            Matrix4.CreateScale(scale.X, scale.Y, scale.Z) *
            Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(orientation.Z)) *
            Matrix4.CreateRotationY(MathHelper.DegreesToRadians(orientation.Y)) *
            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(orientation.X)) *
            Matrix4.CreateTranslation(location);

        public static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);
    }
}
