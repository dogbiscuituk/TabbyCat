namespace TabbyCat.Commands
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utils;

    internal class DescriptionCommand : TracePropertyCommand<string>
    {
        internal DescriptionCommand(int index, string value) : base(
            index,
            PropertyNames.Description,
            value,
            t => t.Description,
            (t, v) => t.Description = v)
        { }
    }

    internal class LocationCommand : TracePropertyCommand<Vector3>
    {
        internal LocationCommand(int index, Vector3 value) : base(
            index,
            PropertyNames.Location,
            value,
            e => e.Location,
            (e, v) => e.Location = v)
        { }
    }

    internal class MaximumCommand : TracePropertyCommand<Vector3>
    {
        internal MaximumCommand(int index, Vector3 value) : base(
            index,
            PropertyNames.Maximum,
            value,
            t => t.Maximum,
            (t, v) => t.Maximum = v)
        { }
    }

    internal class MinimumCommand : TracePropertyCommand<Vector3>
    {
        internal MinimumCommand(int index, Vector3 value) : base(
            index,
            PropertyNames.Minimum,
            value,
            t => t.Minimum,
            (t, v) => t.Minimum = v)
        { }
    }

    internal class OrientationCommand : TracePropertyCommand<Vector3>
    {
        internal OrientationCommand(int index, Vector3 value) : base(
            index,
            PropertyNames.Orientation,
            value,
            e => e.Orientation,
            (e, v) => e.Orientation = v)
        { }
    }

    internal class PatternCommand : TracePropertyCommand<Pattern>
    {
        internal PatternCommand(int index, Pattern value) : base(
            index,
            PropertyNames.Pattern,
            value,
            t => t.Pattern,
            (t, v) => t.Pattern = v)
        { }
    }

    internal class ScaleCommand : TracePropertyCommand<Vector3>
    {
        internal ScaleCommand(int index, Vector3 value) : base(
            index,
            PropertyNames.Scale,
            value,
            e => e.Scale,
            (e, v) => e.Scale = v)
        { }
    }

    internal class StripeCountCommand : TracePropertyCommand<Vector3>
    {
        internal StripeCountCommand(int index, Vector3 value) : base(
            index,
            PropertyNames.StripeCount,
            value,
            t => t.StripeCount,
            (t, v) => t.StripeCount = v)
        { }
    }

    internal class TraceShaderCommand : TracePropertyCommand<string>
    {
        internal TraceShaderCommand(int index, ShaderType shaderType, string value) : base(
            index,
            shaderType.TraceShaderName(),
            value,
            t => t.GetScript(shaderType),
            (t, v) => t.SetScript(shaderType, v))
        { }
    }

    internal class VisibleCommand : TracePropertyCommand<bool>
    {
        internal VisibleCommand(int index, bool value) : base(
            index,
            PropertyNames.Visible,
            value,
            t => t.Visible,
            (t, v) => t.Visible = v)
        { }
    }
}
