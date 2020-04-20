namespace TabbyCat.Models
{
    using OpenTK;

    public class Surface : Trace
    {
        public Surface() : base()
        {
            StripeCount = new Vector3(1000, 1000, 0);
        }
    }
}
