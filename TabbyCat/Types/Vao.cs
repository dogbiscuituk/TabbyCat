namespace TabbyCat.Types
{
    using OpenTK.Graphics.OpenGL;

    /// <summary>
    /// Class representing an OpenTK Vertex Array Object.
    /// </summary>
    public class Vao
    {
        public Vao(IShape shape)
        {
            if (shape == null)
                return;
            GL.GenVertexArrays(1, out _vao);
            GL.BindVertexArray(VaoID);
            _vertexVbo = shape.AcquireVbo(VboType.Vertex);
            _indexVbo = shape.AcquireVbo(VboType.Index);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexVbo.BufferID);
            GL.EnableVertexAttribArray(0);
            var size = shape.DimensionCount;
            GL.VertexAttribPointer(0, size, VertexAttribPointerType.Float, false, 0, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _indexVbo.BufferID);
            GL.BindVertexArray(0);
        }

        private readonly int _vao;

        private readonly Vbo
            _indexVbo,
            _vertexVbo;

        public int ElementCount => _indexVbo.ElementsCount;

        public int VaoID => _vao;

        public void ReleaseBuffers()
        {
            VboStore.Release(_indexVbo);
            VboStore.Release(_vertexVbo);
            GL.DeleteVertexArray(VaoID);
        }
    }
}