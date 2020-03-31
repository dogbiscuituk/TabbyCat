namespace TabbyCat.Models
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TabbyCat.Common.Types;

    internal class Vao
    {
        #region Constructors

        internal Vao(Pattern pattern, Vector3 stripCount)
        {
            Pattern = pattern;
            StripCount = stripCount;
            GL.GenVertexArrays(1, out ID);
            GL.BindVertexArray(ID);
            GL.GenBuffers(1, out IndexBufferID);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndexBufferID);
            var indicesCount = Entity.GetIndicesCount(pattern, stripCount);
            BufferData(indicesCount * sizeof(int), Entity.GetIndices(pattern, stripCount));
            GL.GenBuffers(1, out VertexBufferID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferID);
            var floatsCount = Entity.GetCoordinatesCount(stripCount);
            BufferData(floatsCount * sizeof(float), Entity.GetCoordinates(stripCount));
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            ElementCount = indicesCount;
        }

        const int TargetCount = (int)1e6;

        private void BufferData(int byteCount, IEnumerable<int> data)
        {
            GL.BufferData(BufferTarget.ArrayBuffer, byteCount, data.ToArray(), BufferUsageHint.StaticDraw);
            return;

            GL.BufferData(BufferTarget.ArrayBuffer, byteCount, IntPtr.Zero, BufferUsageHint.StaticDraw);
            int actualCount;
            int[] chunk;
            for (int byteOffset = 0; byteOffset < byteCount; byteOffset += actualCount * sizeof(int))
            {
                chunk = data.Take(TargetCount).ToArray();
                actualCount = chunk.Length;
                GL.BufferSubData(BufferTarget.ArrayBuffer, (IntPtr)byteOffset, actualCount * sizeof(int), chunk);
            }
        }

        private void BufferData(int byteCount, IEnumerable<float> data)
        {
            GL.BufferData(BufferTarget.ArrayBuffer, byteCount, data.ToArray(), BufferUsageHint.StaticDraw);
            return;

            GL.BufferData(BufferTarget.ArrayBuffer, byteCount, IntPtr.Zero, BufferUsageHint.StaticDraw);
            int actualCount;
            float[] chunk;
            for (int byteOffset = 0; byteOffset < byteCount; byteOffset += actualCount * sizeof(float))
            {
                chunk = data.Take(TargetCount).ToArray();
                actualCount = chunk.Length;
                GL.BufferSubData(BufferTarget.ArrayBuffer, (IntPtr)byteOffset, actualCount * sizeof(float), chunk);
            }
        }

        #endregion

        #region Internal Fields

        internal readonly int ElementCount, ID;
        internal readonly Pattern Pattern;
        internal readonly Vector3 StripCount;

        #endregion

        #region Internal Methods

        internal void AddRef() => _RefCount++;

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

        #region Private Fields

        private int _RefCount;

        private readonly int
            IndexBufferID,
            VertexBufferID;

        #endregion
    }
}
