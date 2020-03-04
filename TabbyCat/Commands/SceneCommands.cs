namespace TabbyCat.Commands
{
    using OpenTK;
    using System.Drawing;
    using TabbyCat.Common.Types;
    using TabbyCat.Models;

    internal class BackgroundColourCommand : ScenePropertyCommand<Color>
    {
        internal BackgroundColourCommand(Color value) : base("BackgroundColour",
            value, r => r.BackgroundColour, (r, v) => r.BackgroundColour = v)
        { }
    }

    internal class CameraCommand : ScenePropertyCommand<Camera>
    {
        internal CameraCommand(Camera value) : base("Camera",
            value, s => s.Camera, (s, v) => s.Camera = v)
        { }
    }

    internal class CameraViewCommand : ScenePropertyCommand<Matrix4d>
    {
        internal CameraViewCommand(Matrix4d value) : base("CameraView",
            value, s => s.GetCameraView(), (s, v) => s.SetCameraView(v))
        { }
    }

    internal class FpsCommand : ScenePropertyCommand<double>
    {
        internal FpsCommand(double value) : base("FPS",
            value, s => s.FPS, (s, v) => s.FPS = v)
        { }
    }

    internal class GLModeCommand : ScenePropertyCommand<GLMode>
    {
        internal GLModeCommand(GLMode value) : base("GLMode",
            value, s => s.GetGLMode(), (s, v) => s.SetGLMode(v))
        { }
    }

    internal class ProjectionCommand : ScenePropertyCommand<Projection>
    {
        internal ProjectionCommand(Projection value) : base("Projection",
            value, s => s.Projection, (s, v) => s.Projection = v)
        { }
    }

    internal class ProjectionMatrixCommand : ScenePropertyCommand<Matrix4d>
    {
        internal ProjectionMatrixCommand(Matrix4d value) : base("ProjectionMatrix",
            value, s => s.GetProjection(), (s, v) => s.SetProjection(v))
        { }
    }

    internal class GLTargetVersionCommand : ScenePropertyCommand<string>
    {
        internal GLTargetVersionCommand(string value) : base("GLTargetVersion",
            value, s => s.GLTargetVersion, (s, v) => s.GLTargetVersion = v)
        { }
    }

    internal class TitleCommand : ScenePropertyCommand<string>
    {
        internal TitleCommand(string value) : base("Title",
            value, s => s.Title, (s, v) => s.Title = v)
        { }
    }

    internal class TraceInsertCommand : TracesCommand
    {
        internal TraceInsertCommand(int index) : base(index, true) { }
    }

    internal class TraceDeleteCommand : TracesCommand
    {
        internal TraceDeleteCommand(int index) : base(index, false) { }
    }

    internal class VSyncCommand : ScenePropertyCommand<bool>
    {
        internal VSyncCommand(bool value) : base("VSync",
            value, s => s.VSync, (s, v) => s.VSync = v)
        { }
    }
}
