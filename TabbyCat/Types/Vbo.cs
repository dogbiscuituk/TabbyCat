namespace TabbyCat.Types
{
    using OpenTK.Graphics.OpenGL;
    using System.Collections.Generic;
    using System.Linq;
    using Utils;

    /// <summary>
    /// Class representing a reference counted OpenTK Vertex Buffer Object.
    /// </summary>
    public class Vbo
    {
        public Vbo(IShape shape, VboType vboType)
        {
            if (shape == null)
                return;
            _pattern = shape.Pattern;
            _stripeCount = shape.StripeCount;
            _vboType = vboType;
            GL.GenBuffers(1, out int buffer);
            BufferID = buffer;
            GL.BindBuffer(BufferTarget, BufferID);
            switch (_vboType)
            {
                case VboType.Vertex:
                    BufferData(shape.GetCoordsCount() * sizeof(float), shape.GetCoords());
                    break;
                case VboType.Index:
                    ElementsCount = shape.GetIndicesCount();
                    BufferData(ElementsCount * sizeof(int), shape.GetIndices());
                    break;
            }
        }

        public int BufferID { get; }

        public int ElementsCount { get; }

        private readonly Pattern _pattern;
        private readonly Vector3i _stripeCount;
        private readonly VboType _vboType;

        private int _refCount;

        private BufferTarget BufferTarget => _vboType == VboType.Vertex
            ? BufferTarget.ArrayBuffer
            : BufferTarget.ElementArrayBuffer;

        public void AddRef() => _refCount++;

        public bool Matches(IShape shape, VboType vboType) =>
            shape != null && _vboType == vboType &&
            _stripeCount.EquiAxial(shape.StripeCount) &&
            (_vboType != VboType.Index || _pattern == shape.Pattern);

        public bool Release()
        {
            var result = --_refCount <= 0;
            if (result)
                GL.DeleteBuffer(BufferID);
            return result;
        }

        private void BufferData<T>(int byteCount, IEnumerable<T> data) where T : struct =>
            GL.BufferData(BufferTarget, byteCount, data.ToArray(), BufferUsageHint.StaticDraw);
    }
}
