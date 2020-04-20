namespace TabbyCat.Models
{
    using OpenTK;

    public class Curve : Trace
    {
        public Curve() : base()
        {
            StripeCount = new Vector3(10000, 0, 0);
        }
    }
}
