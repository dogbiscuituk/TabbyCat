namespace TabbyCat.Types
{
    public class Vector3i
    {
        // Constructors

        public Vector3i(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        private Vector3i() : this(0, 0, 0) { }

        // Public properties

        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public static readonly Vector3i
            UnitX = new Vector3i(1, 0, 0),
            UnitY = new Vector3i(0, 1, 0),
            UnitZ = new Vector3i(0, 0, 1),
            Zero = new Vector3i();
    }
}
