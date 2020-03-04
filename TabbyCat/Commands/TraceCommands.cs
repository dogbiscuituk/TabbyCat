namespace TabbyCat.Commands
{
    using OpenTK;
    using TabbyCat.Common.Types;
    using TabbyCat.Models;

    internal class DescriptionCommand : TracePropertyCommand<string>
    {
        internal DescriptionCommand(int index, string value) : base(index, "Description",
            value, t => t.Description, (t, v) => t.Description = v)
        { }
    }

    internal class LocationCommand : TracePropertyCommand<Vector3d>
    {
        internal LocationCommand(int index, Vector3d value) : base(index, "Location",
            value, e => e.Location, (e, v) => e.Location = v)
        { }
    }

    internal class MaximumCommand : TracePropertyCommand<Vector3d>
    {
        internal MaximumCommand(int index, Vector3d value) : base(index, "Maximum",
            value, t => t.Maximum, (t, v) => t.Maximum = v)
        { }
    }

    internal class MinimumCommand : TracePropertyCommand<Vector3d>
    {
        internal MinimumCommand(int index, Vector3d value) : base(index, "Minimum",
            value, t => t.Minimum, (t, v) => t.Minimum = v)
        { }
    }

    internal class OrientationCommand : TracePropertyCommand<Vector3d>
    {
        internal OrientationCommand(int index, Vector3d value) : base(index, "Orientation",
            value, e => e.Orientation, (e, v) => e.Orientation = v)
        { }
    }

    internal class PatternCommand : TracePropertyCommand<Pattern>
    {
        internal PatternCommand(int index, Pattern value) : base(index, "Pattern",
            value, t => t.Pattern, (t, v) => t.Pattern = v)
        { }
    }

    internal class ScaleCommand : TracePropertyCommand<Vector3d>
    {
        internal ScaleCommand(int index, Vector3d value) : base(index, "Scale",
            value, e => e.Scale, (e, v) => e.Scale = v)
        { }
    }

    internal class StripCountCommand : TracePropertyCommand<Vector3>
    {
        internal StripCountCommand(int index, Vector3 value) : base(index, "StripCount",
            value, t => t.StripCount, (t, v) => t.StripCount = v)
        { }
    }

    internal class VisibleCommand : TracePropertyCommand<bool>
    {
        internal VisibleCommand(int index, bool value) : base(index, "Visible",
            value, t => t.Visible, (t, v) => t.Visible = v)
        { }
    }
}
