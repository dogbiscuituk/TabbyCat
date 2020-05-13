namespace TabbyCat.Models
{
    using Properties;
    using Types;

    public class Axes : Shape
    {
        public Axes()
        {
            Description = Resources.Property_Curve;
            Pattern = Pattern.Lines;
        }
    }
}
