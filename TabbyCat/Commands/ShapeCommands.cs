namespace TabbyCat.Commands
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using Types;
    using Utils;

    public class DescriptionCommand : ShapePropertyCommand<string>
    {
        public DescriptionCommand(int index, string value) : base(
            index,
            Property.ShapeDescription,
            value,
            t => t.Description,
            (t, v) => t.Description = v)
        { }
    }

    public class LocationCommand : ShapePropertyCommand<Vector3>
    {
        public LocationCommand(int index, Vector3 value) : base(
            index,
            Property.ShapeLocation,
            value,
            e => e.Location,
            (e, v) => e.Location = v)
        { }
    }

    public class MaximumCommand : ShapePropertyCommand<Vector3>
    {
        public MaximumCommand(int index, Vector3 value) : base(
            index,
            Property.ShapeMaximum,
            value,
            t => t.Maximum,
            (t, v) => t.Maximum = v)
        { }
    }

    public class MinimumCommand : ShapePropertyCommand<Vector3>
    {
        public MinimumCommand(int index, Vector3 value) : base(
            index,
            Property.ShapeMinimum,
            value,
            t => t.Minimum,
            (t, v) => t.Minimum = v)
        { }
    }

    public class OrientationCommand : ShapePropertyCommand<Vector3>
    {
        public OrientationCommand(int index, Vector3 value) : base(
            index,
            Property.ShapeOrientation,
            value,
            e => e.Orientation,
            (e, v) => e.Orientation = v)
        { }
    }

    public class PatternCommand : ShapePropertyCommand<Pattern>
    {
        public PatternCommand(int index, Pattern value) : base(
            index,
            Property.ShapePattern,
            value,
            t => t.Pattern,
            (t, v) => t.Pattern = v)
        { }
    }

    public class ScaleCommand : ShapePropertyCommand<Vector3>
    {
        public ScaleCommand(int index, Vector3 value) : base(
            index,
            Property.ShapeScale,
            value,
            e => e.Scale,
            (e, v) => e.Scale = v)
        { }
    }

    public class StripeCountCommand : ShapePropertyCommand<Vector3i>
    {
        public StripeCountCommand(int index, Vector3i value) : base(
            index,
            Property.ShapeStripeCount,
            value,
            t => t.StripeCount,
            (t, v) => t.StripeCount = v)
        { }
    }

    public class ShapeShaderCommand : ShapePropertyCommand<string>
    {
        public ShapeShaderCommand(int index, ShaderType shaderType, string value) : base(
            index,
            shaderType.ShapeShader(),
            value,
            t => t.GetScript(shaderType),
            (t, v) => t.SetScript(shaderType, v))
        { }
    }

    public class VisibleCommand : ShapePropertyCommand<bool>
    {
        public VisibleCommand(int index, bool value) : base(
            index,
            Property.ShapeVisible,
            value,
            t => t.Visible,
            (t, v) => t.Visible = v)
        { }
    }
}
