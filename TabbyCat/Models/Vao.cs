namespace TabbyCat.Models
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System.Collections.Generic;
    using System.Linq;
    using TabbyCat.Common.Types;

    internal class Vao
    {
        #region Constructors

        internal Vao(Trace trace)
        {
            Pattern = trace.Pattern;
            StripCount = trace.StripCount;
            ElementCount = trace.GetIndicesCount();
            var coordsBytes = sizeof(float) * trace.GetCoordinatesCount();
            var indicesBytes = sizeof(int) * ElementCount;
            GL.GenVertexArrays(1, out ID);
            GL.BindVertexArray(ID);
            IndexBufferID = BufferData(BufferTarget.ElementArrayBuffer, indicesBytes, trace.GetIndices());
            VertexBufferID = BufferData(BufferTarget.ArrayBuffer, coordsBytes, trace.GetCoordinates());
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        #endregion

        #region Internal Fields

        internal readonly int ElementCount, ID;
        internal readonly Pattern Pattern;
        internal readonly Vector3 StripCount;

        #endregion

        #region Internal Methods

        internal void AddRef() => _RefCount++;

        internal bool Matches(Trace trace) =>
            Pattern == trace.Pattern && StripCount == trace.StripCount;

        internal bool Release()
        {
            if (--_RefCount > 0)
                return false;
            GL.DeleteBuffer(VertexBufferID);
            GL.DeleteBuffer(IndexBufferID);
            GL.DeleteVertexArray(ID);
            return true;
        }

        #endregion

        #region Private Methods

        private int BufferData<T>(BufferTarget bufferTarget, int byteCount, IEnumerable<T> data)
            where T : struct
        {
            GL.GenBuffers(1, out int vboID);
            GL.BindBuffer(bufferTarget, vboID);
            GL.BufferData(bufferTarget, byteCount, data.ToArray(), BufferUsageHint.StaticDraw);
            return vboID;
        }

        #endregion

        #region Private Fields

        private int _RefCount;

        private readonly int
            IndexBufferID,
            VertexBufferID;

        #endregion
    }
}