namespace TabbyCat.Types
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Static class for maintaining a list of currently active VBOs.
    /// </summary>
    public static class VboStore
    {
        private static readonly List<Vbo> Vbos = new List<Vbo>();

        public static Vbo AcquireVbo(this IShape shape, VboType vboType)
        {
            var vbo = Vbos.FirstOrDefault(p => p.Matches(shape, vboType));
            if (vbo == null)
                Vbos.Add(vbo = new Vbo(shape, vboType));
            vbo.AddRef();
            return vbo;
        }

        public static void Release(this Vbo vbo)
        {
            if (vbo != null && vbo.Release())
                Vbos.Remove(vbo);
        }
    }
}
