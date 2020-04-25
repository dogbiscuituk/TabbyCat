namespace TabbyCat.Commands
{
    using Common.Types;
    using Common.Utils;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System.Drawing;
    using Models;

    internal class BackgroundColourCommand : ScenePropertyCommand<Color>
    {
        internal BackgroundColourCommand(Color value) : base(
            PropertyNames.Background,
            value,
            r => r.BackgroundColour,
            (r, v) => r.BackgroundColour = v)
        { }
    }

    internal class CameraCommand : ScenePropertyCommand<Camera>
    {
        internal CameraCommand(Camera value) : base(
            PropertyNames.Camera,
            value,
            p => p.Camera,
            (p, v) => p.Camera = v)
        { }
    }

    internal class CameraFocusCommand : ScenePropertyCommand<Vector3>
    {
        internal CameraFocusCommand(Vector3 value) : base(
            PropertyNames.CameraFocus,
            value,
            s => s.Camera.Focus,
            (s, v) => s.Camera.Focus = v)
        { }
    }

    internal class CameraPositionCommand : ScenePropertyCommand<Vector3>
    {
        internal CameraPositionCommand(Vector3 value) : base(
            PropertyNames.CameraPosition,
            value,
            s => s.Camera.Position,
            (s, v) => s.Camera.Position = v)
        { }
    }

    internal class FieldOfViewCommand : ScenePropertyCommand<float>
    {
        internal FieldOfViewCommand(float value) : base(
            PropertyNames.FieldOfView,
            value,
            s => s.Projection.FieldOfView,
            (s, v) => s.Projection.FieldOfView = v)
        { }
    }

    internal class FpsCommand : ScenePropertyCommand<float>
    {
        internal FpsCommand(float value) : base(
            PropertyNames.FPS,
            value,
            s => s.FPS,
            (s, v) => s.FPS = v)
        { }
    }

    internal class FrustumMaxCommand : ScenePropertyCommand<Vector3>
    {
        internal FrustumMaxCommand(Vector3 value) : base(
            PropertyNames.FarPlane,
            value,
            s => s.Projection.FrustumMax,
            (s, v) => s.Projection.FrustumMax = v)
        { }
    }

    internal class FrustumMinCommand : ScenePropertyCommand<Vector3>
    {
        internal FrustumMinCommand(Vector3 value) : base(
            PropertyNames.NearPlane,
            value,
            s => s.Projection.FrustumMin,
            (s, v) => s.Projection.FrustumMin = v)
        { }
    }

    internal class GLTargetVersionCommand : ScenePropertyCommand<string>
    {
        internal GLTargetVersionCommand(string value) : base(
            PropertyNames.GLTargetVersion,
            value,
            s => s.GLTargetVersion,
            (s, v) => s.GLTargetVersion = v)
        { }
    }

    internal class ProjectionTypeCommand : ScenePropertyCommand<ProjectionType>
    {
        internal ProjectionTypeCommand(ProjectionType value) : base(
            PropertyNames.ProjectionType,
            value,
            s => s.Projection.ProjectionType,
            (s, v) => s.Projection.ProjectionType = v)
        { }
    }

    internal class SamplesCommand : ScenePropertyCommand<int>
    {
        internal SamplesCommand(int value) : base(
            PropertyNames.Samples,
            value,
            s => s.Samples,
            (s, v) => s.Samples = v)
        { }
    }

    internal class SceneShaderCommand : ScenePropertyCommand<string>
    {
        internal SceneShaderCommand(ShaderType shaderType, string value) : base(
            shaderType.SceneShaderName(),
            value,
            s => s.GetScript(shaderType),
            (s, v) => s.SetScript(shaderType, v))
        { }
    }

    internal class SignalDeleteCommand : SignalsCommand
    {
        internal SignalDeleteCommand(int index) : base(index, false) { }
    }

    internal class SignalInsertCommand : SignalsCommand
    {
        internal SignalInsertCommand(int index, Signal signal) : base(index, true) { Value = signal; }
    }

    internal class StereoCommand : ScenePropertyCommand<bool>
    {
        internal StereoCommand(bool value) : base(
            PropertyNames.Stereo,
            value,
            s => s.Stereo,
            (s, v) => s.Stereo = v)
        { }
    }

    internal class TitleCommand : ScenePropertyCommand<string>
    {
        internal TitleCommand(string value) : base(
            PropertyNames.SceneTitle,
            value,
            s => s.Title,
            (s, v) => s.Title = v)
        { }
    }

    internal class TraceDeleteCommand : TracesCommand
    {
        internal TraceDeleteCommand(int index) : base(index, false) { }
    }

    internal class TraceInsertCommand : TracesCommand
    {
        internal TraceInsertCommand(int index, Trace trace) : base(index, true) { Value = trace; }
    }

    internal class VSyncCommand : ScenePropertyCommand<bool>
    {
        internal VSyncCommand(bool value) : base(
            PropertyNames.VSync,
            value,
            s => s.VSync,
            (s, v) => s.VSync = v)
        { }
    }
}
