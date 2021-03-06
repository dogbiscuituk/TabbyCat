﻿namespace TabbyCat.Utils
{
    using OpenTK;
    using System.Drawing;
    using Types;

    public static class MathUtils
    {
        public static Matrix4 CreateCameraView(Camera camera) => camera != null ? CreateCameraView(camera.Position, camera.Focus) : Matrix4.Identity;

        public static Matrix4 CreateCameraView(Vector3 position, Vector3 focus) => Matrix4.LookAt(position, focus, new Vector3(0, 1, 0));

        public static Matrix4 CreateProjection(Projection p) => CreateProjection(p, new Size(16, 9));

        public static Matrix4 CreateProjection(Projection p, Size s)
        {
            switch (p?.ProjectionType)
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
