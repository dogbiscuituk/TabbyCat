namespace TabbyCat.Commands
{
    using OpenTK;
    using TabbyCat.Common.Types;
    using TabbyCat.Models;

    internal class DescriptionCommand : TracePropertyCommand<string>
    {
        internal DescriptionCommand(int index, string value) : base(index, "Description",
            value, t => t._Description, (t, v) => t._Description = v)
        { }
    }

    internal class LocationCommand : TracePropertyCommand<Vector3d>
    {
        internal LocationCommand(int index, Vector3d value) : base(index, "Location",
            value, e => e._Location, (e, v) => e._Location = v)
        { }
    }

    internal class MaximumCommand : TracePropertyCommand<Vector3d>
    {
        internal MaximumCommand(int index, Vector3d value) : base(index, "Maximum",
            value, t => t._Maximum, (t, v) => t._Maximum = v)
        { }
    }

    internal class MinimumCommand : TracePropertyCommand<Vector3d>
    {
        internal MinimumCommand(int index, Vector3d value) : base(index, "Minimum",
            value, t => t._Minimum, (t, v) => t._Minimum = v)
        { }
    }

    internal class OrientationCommand : TracePropertyCommand<Vector3d>
    {
        internal OrientationCommand(int index, Vector3d value) : base(index, "Orientation",
            value, e => e._Orientation, (e, v) => e._Orientation = v)
        { }
    }

    internal class PatternCommand : TracePropertyCommand<Pattern>
    {
        internal PatternCommand(int index, Pattern value) : base(index, "Pattern",
            value, t => t._Pattern, (t, v) => t._Pattern = v)
        { }
    }

    internal class ScaleCommand : TracePropertyCommand<Vector3d>
    {
        internal ScaleCommand(int index, Vector3d value) : base(index, "Scale",
            value, e => e._Scale, (e, v) => e._Scale = v)
        { }
    }

    internal class StripCountCommand : TracePropertyCommand<Vector3>
    {
        internal StripCountCommand(int index, Vector3 value) : base(index, "StripCount",
            value, t => t._StripCount, (t, v) => t._StripCount = v)
        { }
    }

    internal class TransformCommand : TracePropertyCommand<Matrix4>
    {
        internal TransformCommand(int index, Matrix4 value) : base(index, "Transform",
            value, e => e.GetTransform(), (e, v) => e.SetTransform(v))
        { }
    }

    internal class VisibleCommand : TracePropertyCommand<bool>
    {
        internal VisibleCommand(int index, bool value) : base(index, "Visible",
            value, t => t._Visible, (t, v) => t._Visible = v)
        { }
    }
}
