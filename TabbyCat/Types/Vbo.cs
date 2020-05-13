namespace TabbyCat.Types
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class representing a reference counted OpenTK Vertex Buffer Object.
    /// </summary>
    public class Vbo
    {
        public Vbo(IShape shape, VboType vboType)
        {
            if (shape == null)
                return;
            Pattern = shape.Pattern;
            StripeCount = shape.StripeCount;
            VboType = vboType;
            GL.GenBuffers(1, out int bufferID);
            BufferID = bufferID;
            GL.BindBuffer(BufferTarget, BufferID);
            switch (VboType)
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

        private readonly Pattern Pattern;
        private readonly Vector3 StripeCount;
        private readonly VboType VboType;

        private int RefCount;

        private BufferTarget BufferTarget => VboType == VboType.Vertex
            ? BufferTarget.ArrayBuffer
            : BufferTarget.ElementArrayBuffer;

        public void AddRef() => RefCount++;

        public bool Matches(IShape shape, VboType vboType) => shape == null
            ? false
            : VboType == vboType &&
            StripeCount == shape.StripeCount &&
            (VboType != VboType.Index || Pattern == shape.Pattern);

        public bool Release()
        {
            var result = --RefCount <= 0;
            if (result)
                GL.DeleteBuffer(BufferID);
            return result;
        }

        private void BufferData<T>(int byteCount, IEnumerable<T> data) where T : struct => GL.BufferData(BufferTarget, byteCount, data.ToArray(), BufferUsageHint.StaticDraw);
    }
}
