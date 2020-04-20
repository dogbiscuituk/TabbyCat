namespace TabbyCat.Models
{
    using Common.Types;
    using OpenTK;

    public class Curve : Trace
    {
        public Curve() : base()
        {
            Pattern = Pattern.Lines;
            StripeCount = new Vector3(10000, 0, 0);
        }
    }
}
