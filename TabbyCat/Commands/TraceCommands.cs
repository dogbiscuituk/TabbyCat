namespace TabbyCat.Commands
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using Types;
    using Utils;

    public class DescriptionCommand : TracePropertyCommand<string>
    {
        public DescriptionCommand(int index, string value) : base(
            index,
            Property.TraceDescription,
            value,
            t => t.Description,
            (t, v) => t.Description = v)
        { }
    }

    public class LocationCommand : TracePropertyCommand<Vector3>
    {
        public LocationCommand(int index, Vector3 value) : base(
            index,
            Property.TraceLocation,
            value,
            e => e.Location,
            (e, v) => e.Location = v)
        { }
    }

    public class MaximumCommand : TracePropertyCommand<Vector3>
    {
        public MaximumCommand(int index, Vector3 value) : base(
            index,
            Property.TraceMaximum,
            value,
            t => t.Maximum,
            (t, v) => t.Maximum = v)
        { }
    }

    public class MinimumCommand : TracePropertyCommand<Vector3>
    {
        public MinimumCommand(int index, Vector3 value) : base(
            index,
            Property.TraceMinimum,
            value,
            t => t.Minimum,
            (t, v) => t.Minimum = v)
        { }
    }

    public class OrientationCommand : TracePropertyCommand<Vector3>
    {
        public OrientationCommand(int index, Vector3 value) : base(
            index,
            Property.TraceOrientation,
            value,
            e => e.Orientation,
            (e, v) => e.Orientation = v)
        { }
    }

    public class PatternCommand : TracePropertyCommand<Pattern>
    {
        public PatternCommand(int index, Pattern value) : base(
            index,
            Property.TracePattern,
            value,
            t => t.Pattern,
            (t, v) => t.Pattern = v)
        { }
    }

    public class ScaleCommand : TracePropertyCommand<Vector3>
    {
        public ScaleCommand(int index, Vector3 value) : base(
            index,
            Property.TraceScale,
            value,
            e => e.Scale,
            (e, v) => e.Scale = v)
        { }
    }

    public class StripeCountCommand : TracePropertyCommand<Vector3>
    {
        public StripeCountCommand(int index, Vector3 value) : base(
            index,
            Property.TraceStripeCount,
            value,
            t => t.StripeCount,
            (t, v) => t.StripeCount = v)
        { }
    }

    public class TraceShaderCommand : TracePropertyCommand<string>
    {
        public TraceShaderCommand(int index, ShaderType shaderType, string value) : base(
            index,
            shaderType.TraceShader(),
            value,
            t => t.GetScript(shaderType),
            (t, v) => t.SetScript(shaderType, v))
        { }
    }

    public class VisibleCommand : TracePropertyCommand<bool>
    {
        public VisibleCommand(int index, bool value) : base(
            index,
            Property.TraceVisible,
            value,
            t => t.Visible,
            (t, v) => t.Visible = v)
        { }
    }
}
