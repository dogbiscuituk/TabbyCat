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
            GL.GenBuffers(1, out BufferID);
            GL.BindBuffer(BufferTarget, BufferID);
            switch (VboType = vboType)
            {
                case VboType.Vertex:
                    ElementCount = trace.GetCoordsCount();
                    BufferData(ElementCount * sizeof(float), trace.GetCoords());
                    break;
                case VboType.Index:
                    ElementCount = trace.GetIndicesCount();
                    BufferData(ElementCount * sizeof(int), trace.GetIndices());
                    break;
            }
        }

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
            ? BufferTarget.ElementArrayBuffer
            : BufferTarget.ArrayBuffer;

        #endregion

        #region Private Methods

        private void BufferData<T>(int byteCount, IEnumerable<T> data) where T : struct =>
            GL.BufferData(BufferTarget, byteCount, data.ToArray(), BufferUsageHint.StaticDraw);

        #endregion

        #region Private Fields

        private readonly int BufferID;
        private readonly int ElementCount;
        private readonly Pattern Pattern;
        private readonly Vector3 StripCount;
        private readonly VboType VboType;

        private int RefCount;

        #endregion
    }
}
