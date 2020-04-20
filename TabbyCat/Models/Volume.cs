namespace TabbyCat.Models
{
    using OpenTK;

    public class Volume : Trace
    {
        public Volume() : base()
        {
            StripeCount = new Vector3(100, 100, 100);
        }
    }
}
