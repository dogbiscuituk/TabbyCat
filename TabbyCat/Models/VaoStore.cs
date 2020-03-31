namespace TabbyCat.Models
{
    using OpenTK;
    using System.Collections.Generic;
    using System.Linq;
    using TabbyCat.Common.Types;

    internal static class VaoStore
    {
        #region Internal Methods

        internal static Vao AcquireVao(Pattern pattern, Vector3 stripCount)
        {
            var vao = Vaos.FirstOrDefault(p => p.Pattern == pattern && p.StripCount == stripCount);
            if (vao == null)
                Vaos.Add(vao = new Vao(pattern, stripCount));
            vao.AddRef();
            return vao;
        }

        internal static void ReleaseVao(this Trace trace)
        {
            var vao = trace.Vao;
            if (vao != null && vao.Release())
                Vaos.Remove(vao);
            trace.Vao = null;
        }

        #endregion

        #region Private Fields

        private static readonly List<Vao> Vaos = new List<Vao>();

        #endregion
    }
}
