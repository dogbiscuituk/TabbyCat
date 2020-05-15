namespace TabbyCat.Utils
{
    using Types;

    public static class StripeCountUtils
    {
        public static int AxesCount(this Vector3i stripeCount)
        {
            switch (stripeCount.AxesUsed())
            {
                case Axes.None:
                    return 0;
                case Axes.X:
                case Axes.Y:
                case Axes.Z:
                    return 1;
                case Axes.XYZ:
                    return 3;
                default:
                    return 2;
            }
        }

        public static Axes AxesUsed(this Vector3i stripeCount) => stripeCount == null
            ? Axes.None
            : (stripeCount.X != 0 ? Axes.X : 0) |
              (stripeCount.Y != 0 ? Axes.Y : 0) |
              (stripeCount.Z != 0 ? Axes.Z : 0);

        public static bool EquiAxial(this Vector3i stripeCount1, Vector3i stripeCount2) => stripeCount1 == stripeCount2;
    }
}
