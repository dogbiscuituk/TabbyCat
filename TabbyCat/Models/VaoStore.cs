namespace TabbyCat.Models
{
    using System.Collections.Generic;
    using System.Linq;

    internal static class VaoStore
    {
        #region Internal Methods

        internal static Vao AcquireVao(this Trace trace)
        {
            var vao = Vaos.FirstOrDefault(p => p.Matches(trace));
            if (vao == null)
                Vaos.Add(vao = new Vao(trace));
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
