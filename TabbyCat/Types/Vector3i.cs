namespace TabbyCat.Types
{
    public class Vector3i
    {
        // Constructors

        public Vector3i(Vector3i v)
        {
            if (v == null)
                return;
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        public Vector3i(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // Public properties

        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public static readonly Vector3i
            UnitX = new Vector3i(1, 0, 0),
            UnitY = new Vector3i(0, 1, 0),
            UnitZ = new Vector3i(0, 0, 1),
            Zero = new Vector3i(0, 0, 0);

        // Public operators

        public static bool operator ==(Vector3i u, Vector3i v) =>
            u is null
                ? v is null
                : !(v is null) && u.X == v.X && u.Y == v.Y && u.Z == v.Z;

        public static bool operator !=(Vector3i u, Vector3i v) => !(u == v);

        // Public methods

        public override bool Equals(object obj) => obj is Vector3i v && v == this;

        public override int GetHashCode() => X ^ Y ^ Z;

        public override string ToString() => $"({X}, {Y}, {Z})";
    }
}