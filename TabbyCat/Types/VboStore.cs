namespace TabbyCat.Types
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Static class for maintaining a list of currently active VBOs.
    /// </summary>
    internal static class VboStore
    {
        private static readonly List<Vbo> Vbos = new List<Vbo>();

        internal static Vbo AcquireVbo(this ITrace trace, VboType vboType)
        {
            Vbo vbo = Vbos.FirstOrDefault(p => p.Matches(trace, vboType));
            if (vbo == null)
            {
                Vbos.Add(vbo = new Vbo(trace, vboType));
            }

            vbo.AddRef();
            return vbo;
        }

        internal static void ReleaseVbo(this Vbo vbo)
        {
            if (vbo != null && vbo.Release())
            {
                Vbos.Remove(vbo);
            }
        }
    }
}
