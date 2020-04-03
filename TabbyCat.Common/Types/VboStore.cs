namespace TabbyCat.Common.Types
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Static class for maintaining a list of currently active VBOs.
    /// </summary>
    internal static class VboStore
    {
        #region Internal Methods

        internal static Vbo AcquireVbo(this ITrace trace, VboType vboType)
        {
            var vbo = Vbos.FirstOrDefault(p => p.Matches(trace, vboType));
            if (vbo == null)
                Vbos.Add(vbo = new Vbo(trace, vboType));
            vbo.AddRef();
            return vbo;
        }

        internal static void ReleaseVbo(this Vbo vbo)
        {
            if (vbo != null && vbo.Release())
                Vbos.Remove(vbo);
        }

        #endregion

        #region Private Fields

        private static readonly List<Vbo> Vbos = new List<Vbo>();

        #endregion
    }
}
