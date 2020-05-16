namespace TabbyCat.Utils
{
    using Types;

    public static class StripeCountUtils
    {
        // Public methods

        /// <summary>
        /// Get the number of "used" axes in a stripe count, i.e. those for which the count is nonzero.
        /// </summary>
        /// <param name="v">The Vector3i representing the stripe count to measure.</param>
        /// <returns>The number of "used" axes in the stripe count, i.e. those for which the count is nonzero.</returns>
        public static int AxesCount(this Vector3i v)
        {
            switch (v.AxesUsed())
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

        /// <summary>
        /// Get the axes "used" in a stripe count, i.e. those for which the count is nonzero.
        /// </summary>
        /// <param name="v">The Vector3i representing the stripe count to measure.</param>
        /// <returns>The "used" axes in the stripe count, i.e. those for which the count is nonzero.</returns>
        public static Axes AxesUsed(this Vector3i v) => v == null
            ? Axes.None
            : (v.X != 0 ? Axes.X : 0) |
              (v.Y != 0 ? Axes.Y : 0) |
              (v.Z != 0 ? Axes.Z : 0);

        /// <summary>
        /// Determine whether two stripe counts will result in the same Vbo data shape, once "empty" dimensions are removed.
        /// </summary>
        /// <param name="u">The first stripe count object.</param>
        /// <param name="v">The second stripe count object.</param>
        /// <returns>True if the two stripe counts will result in the same Vbo data shape, once "empty" dimensions are removed,
        /// otherwise false.</returns>
        public static bool EquiAxial(this Vector3i u, Vector3i v) => u.DataFormat() == v.DataFormat();

        // Private methods

        /// <summary>
        /// Compress a stripe count object so that its nonempty dimensions appear first in axis order.
        /// </summary>
        /// <param name="v">The source stripe count object.</param>
        /// <returns>A stripe count object with its nonempty dimensions appearing first in axis order, padded out with zeros if any.</returns>
        private static Vector3i DataFormat(this Vector3i v) =>
            v == null
                ? Vector3i.Zero
                : v.X == 0
                    ? v.Y == 0
                        ? new Vector3i(v.Z, 0, 0)
                        : new Vector3i(v.Y, v.Z, 0)
                    : v.Y == 0
                        ? new Vector3i(v.X, v.Z, 0)
                        : new Vector3i(v);
    }
}
