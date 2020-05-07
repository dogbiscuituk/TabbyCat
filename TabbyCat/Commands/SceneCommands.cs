namespace TabbyCat.Commands
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System.Drawing;
    using Types;
    using Utils;

    internal class BackgroundColourCommand : ScenePropertyCommand<Color>
    {
        internal BackgroundColourCommand(Color value) : base(
            Property.Background,
            value,
            r => r.BackgroundColour,
            (r, v) => r.BackgroundColour = v)
        { }
    }

    internal class CameraCommand : ScenePropertyCommand<Camera>
    {
        internal CameraCommand(Camera value) : base(
            Property.Camera,
            value,
            p => p.Camera,
            (p, v) => p.Camera = v)
        { }
    }

    internal class CameraFocusCommand : ScenePropertyCommand<Vector3>
    {
        internal CameraFocusCommand(Vector3 value) : base(
            Property.CameraFocus,
            value,
            s => s.Camera.Focus,
            (s, v) => s.Camera.Focus = v)
        { }
    }

    internal class CameraPositionCommand : ScenePropertyCommand<Vector3>
    {
        internal CameraPositionCommand(Vector3 value) : base(
            Property.CameraPosition,
            value,
            s => s.Camera.Position,
            (s, v) => s.Camera.Position = v)
        { }
    }

    internal class FieldOfViewCommand : ScenePropertyCommand<float>
    {
        internal FieldOfViewCommand(float value) : base(
            Property.FieldOfView,
            value,
            s => s.Projection.FieldOfView,
            (s, v) => s.Projection.FieldOfView = v)
        { }
    }

    internal class FpsCommand : ScenePropertyCommand<float>
    {
        internal FpsCommand(float value) : base(
            Property.TargetFPS,
            value,
            s => s.TargetFPS,
            (s, v) => s.TargetFPS = v)
        { }
    }

    internal class FrustumMaxCommand : ScenePropertyCommand<Vector3>
    {
        internal FrustumMaxCommand(Vector3 value) : base(
            Property.FarPlane,
            value,
            s => s.Projection.FrustumMax,
            (s, v) => s.Projection.FrustumMax = v)
        { }
    }

    internal class FrustumMinCommand : ScenePropertyCommand<Vector3>
    {
        internal FrustumMinCommand(Vector3 value) : base(
            Property.NearPlane,
            value,
            s => s.Projection.FrustumMin,
            (s, v) => s.Projection.FrustumMin = v)
        { }
    }

    internal class GLTargetVersionCommand : ScenePropertyCommand<string>
    {
        internal GLTargetVersionCommand(string value) : base(
            Property.GLTargetVersion,
            value,
            s => s.GLTargetVersion,
            (s, v) => s.GLTargetVersion = v)
        { }
    }

    internal class ProjectionTypeCommand : ScenePropertyCommand<ProjectionType>
    {
        internal ProjectionTypeCommand(ProjectionType value) : base(
            Property.ProjectionType,
            value,
            s => s.Projection.ProjectionType,
            (s, v) => s.Projection.ProjectionType = v)
        { }
    }

    internal class SamplesCommand : ScenePropertyCommand<int>
    {
        internal SamplesCommand(int value) : base(
            Property.Samples,
            value,
            s => s.Samples,
            (s, v) => s.Samples = v)
        { }
    }

    internal class SceneShaderCommand : ScenePropertyCommand<string>
    {
        internal SceneShaderCommand(ShaderType shaderType, string value) : base(
            shaderType.SceneShader(),
            value,
            s => s.GetScript(shaderType),
            (s, v) => s.SetScript(shaderType, v))
        { }
    }

    internal class StereoCommand : ScenePropertyCommand<bool>
    {
        internal StereoCommand(bool value) : base(
            Property.Stereo,
            value,
            s => s.Stereo,
            (s, v) => s.Stereo = v)
        { }
    }

    internal class TitleCommand : ScenePropertyCommand<string>
    {
        internal TitleCommand(string value) : base(
            Property.SceneTitle,
            value,
            s => s.Title,
            (s, v) => s.Title = v)
        { }
    }

    internal class VSyncCommand : ScenePropertyCommand<bool>
    {
        internal VSyncCommand(bool value) : base(
            Property.VSync,
            value,
            s => s.VSync,
            (s, v) => s.VSync = v)
        { }
    }
}
