namespace TabbyCat.MvcModels
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System.Collections.Generic;
    using System.Linq;
    using TabbyCat.Common.Types;

    internal class Vbo
    {
        #region Constructors

        internal Vbo(Trace trace, VboType vboType)
        {
            Pattern = trace.Pattern;
            StripCount = trace.StripCount;
            VboType = vboType;
            GL.GenBuffers(1, out BufferID);
            GL.BindBuffer(BufferTarget, BufferID);
            switch (VboType)
            {
                case VboType.Vertex:
                    BufferData(trace.GetCoordsCount() * sizeof(float), trace.GetCoords());
                    break;
                case VboType.Index:
                    ElementsCount = trace.GetIndicesCount();
                    BufferData(ElementsCount * sizeof(int), trace.GetIndices());
                    break;
            }
        }

        #endregion

        #region Internal Fields

        internal readonly int ElementsCount;

        #endregion

        #region Internal Methods

        internal void AddRef() => RefCount++;

        internal bool Matches(Trace trace, VboType vboType) =>
            VboType == vboType &&
            StripCount == trace.StripCount &&
            (VboType != VboType.Index || Pattern == trace.Pattern);

        internal bool Release()
        {
            var result = --RefCount <= 0;
            if (result)
                GL.DeleteBuffer(BufferID);
            return result;
        }

        #endregion

        #region Private Properties

        private BufferTarget BufferTarget => VboType == VboType.Vertex
            ? BufferTarget.ArrayBuffer
            : BufferTarget.ElementArrayBuffer;

        #endregion

        #region Private Methods

        private void BufferData<T>(int byteCount, IEnumerable<T> data) where T : struct =>
            GL.BufferData(BufferTarget, byteCount, data.ToArray(), BufferUsageHint.StaticDraw);

        #endregion

        #region Internal Fields

        internal readonly int BufferID;

        #endregion

        #region Private Fields

        private readonly Pattern Pattern;
        private readonly Vector3 StripCount;
        private readonly VboType VboType;

        private int RefCount;

        #endregion
    }
}
