namespace TabbyCat.Models
{
    using Common.Types;
    using OpenTK;

    public class Surface : Trace
    {
        public Surface() : base()
        {
            Pattern = Pattern.Fill;
            StripeCount = new Vector3(1000, 1000, 0);
        }
    }
}
