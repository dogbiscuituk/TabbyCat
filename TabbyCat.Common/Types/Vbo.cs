namespace TabbyCat.Common.Types
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class representing a reference counted OpenTK Vertex Buffer Object.
    /// </summary>
    internal class Vbo
    {
        internal Vbo(ITrace trace, VboType vboType)
        {
            Pattern = trace.Pattern;
            StripeCount = trace.StripeCount;
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

        internal readonly int 
            BufferID,
            ElementsCount;

        private readonly Pattern Pattern;
        private readonly Vector3 StripeCount;
        private readonly VboType VboType;

        private int RefCount;

        private BufferTarget BufferTarget => VboType == VboType.Vertex
            ? BufferTarget.ArrayBuffer
            : BufferTarget.ElementArrayBuffer;

        internal void AddRef() => RefCount++;

        internal bool Matches(ITrace trace, VboType vboType) =>
            VboType == vboType &&
            StripeCount == trace.StripeCount &&
            (VboType != VboType.Index || Pattern == trace.Pattern);

        internal bool Release()
        {
            var result = --RefCount <= 0;
            if (result)
                GL.DeleteBuffer(BufferID);
            return result;
        }

        private void BufferData<T>(int byteCount, IEnumerable<T> data) where T : struct =>
            GL.BufferData(BufferTarget, byteCount, data.ToArray(), BufferUsageHint.StaticDraw);
    }
}
