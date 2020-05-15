namespace TabbyCat.Models
{
    using OpenTK;
    using Properties;
    using Types;

    public class Axis : Shape
    {
        protected Axis(string description, Vector3i stripeCount)
        {
            Description = description;
            Pattern = Pattern.Lines;
            Scale = new Vector3(8);
            StripeCount = stripeCount;
        }
    }

    public class XAxis : Axis
    {
        public XAxis() : base(Resources.Property_Xaxis, Vector3i.UnitX) { }
    }

    public class YAxis : Axis
    {
        public YAxis() : base(Resources.Property_Yaxis, Vector3i.UnitY) { }
    }

    public class ZAxis : Axis
    {
        public ZAxis() : base(Resources.Property_Zaxis, Vector3i.UnitZ) { }
    }
}
