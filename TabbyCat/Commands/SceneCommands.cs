namespace TabbyCat.Commands
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System.Drawing;
    using Types;
    using Utils;

    public class BackgroundColourCommand : ScenePropertyCommand<Color>
    {
        public BackgroundColourCommand(Color value) : base(
            Property.Background,
            value,
            r => r.BackgroundColour,
            (r, v) => r.BackgroundColour = v)
        { }
    }

    public class CameraCommand : ScenePropertyCommand<Camera>
    {
        public CameraCommand(Camera value) : base(
            Property.Camera,
            value,
            p => p.Camera,
            (p, v) => p.Camera = v)
        { }
    }

    public class CameraFocusCommand : ScenePropertyCommand<Vector3>
    {
        public CameraFocusCommand(Vector3 value) : base(
            Property.CameraFocus,
            value,
            s => s.Camera.Focus,
            (s, v) => s.Camera.Focus = v)
        { }
    }

    public class CameraPositionCommand : ScenePropertyCommand<Vector3>
    {
        public CameraPositionCommand(Vector3 value) : base(
            Property.CameraPosition,
            value,
            s => s.Camera.Position,
            (s, v) => s.Camera.Position = v)
        { }
    }

    public class FieldOfViewCommand : ScenePropertyCommand<float>
    {
        public FieldOfViewCommand(float value) : base(
            Property.FieldOfView,
            value,
            s => s.Projection.FieldOfView,
            (s, v) => s.Projection.FieldOfView = v)
        { }
    }

    public class FpsCommand : ScenePropertyCommand<float>
    {
        public FpsCommand(float value) : base(
            Property.TargetFps,
            value,
            s => s.TargetFPS,
            (s, v) => s.TargetFPS = v)
        { }
    }

    public class FrustumMaxCommand : ScenePropertyCommand<Vector3>
    {
        public FrustumMaxCommand(Vector3 value) : base(
            Property.FarPlane,
            value,
            s => s.Projection.FrustumMax,
            (s, v) => s.Projection.FrustumMax = v)
        { }
    }

    public class FrustumMinCommand : ScenePropertyCommand<Vector3>
    {
        public FrustumMinCommand(Vector3 value) : base(
            Property.NearPlane,
            value,
            s => s.Projection.FrustumMin,
            (s, v) => s.Projection.FrustumMin = v)
        { }
    }

    public class GLTargetVersionCommand : ScenePropertyCommand<string>
    {
        public GLTargetVersionCommand(string value) : base(
            Property.GlslTargetVersion,
            value,
            s => s.GLTargetVersion,
            (s, v) => s.GLTargetVersion = v)
        { }
    }

    public class ProjectionTypeCommand : ScenePropertyCommand<ProjectionType>
    {
        public ProjectionTypeCommand(ProjectionType value) : base(
            Property.ProjectionType,
            value,
            s => s.Projection.ProjectionType,
            (s, v) => s.Projection.ProjectionType = v)
        { }
    }

    public class SamplesCommand : ScenePropertyCommand<int>
    {
        public SamplesCommand(int value) : base(
            Property.Samples,
            value,
            s => s.Samples,
            (s, v) => s.Samples = v)
        { }
    }

    public class SceneShaderCommand : ScenePropertyCommand<string>
    {
        public SceneShaderCommand(ShaderType shaderType, string value) : base(
            shaderType.SceneShader(),
            value,
            s => s.GetScript(shaderType),
            (s, v) => s.SetScript(shaderType, v))
        { }
    }

    public class StereoCommand : ScenePropertyCommand<bool>
    {
        public StereoCommand(bool value) : base(
            Property.Stereo,
            value,
            s => s.Stereo,
            (s, v) => s.Stereo = v)
        { }
    }

    public class TitleCommand : ScenePropertyCommand<string>
    {
        public TitleCommand(string value) : base(
            Property.SceneTitle,
            value,
            s => s.Title,
            (s, v) => s.Title = v)
        { }
    }

    public class VSyncCommand : ScenePropertyCommand<bool>
    {
        public VSyncCommand(bool value) : base(
            Property.VSync,
            value,
            s => s.VSync,
            (s, v) => s.VSync = v)
        { }
    }
}
