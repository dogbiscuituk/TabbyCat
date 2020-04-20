namespace TabbyCat.Models
{
    using Common.Types;
    using OpenTK;

    public class Volume : Trace
    {
        public Volume() : base()
        {
            Pattern = Pattern.Points;
            StripeCount = new Vector3(100, 100, 100);
        }
    }
}
