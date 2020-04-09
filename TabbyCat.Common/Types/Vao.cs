namespace TabbyCat.Common.Types
{
    using OpenTK.Graphics.OpenGL;

    /// <summary>
    /// Class representing an OpenTK Vertex Array Object.
    /// </summary>
    public class Vao
    {
        public Vao(ITrace trace)
        {
            GL.GenVertexArrays(1, out _VaoID);
            GL.BindVertexArray(VaoID);
            VertexVbo = VboStore.AcquireVbo(trace, VboType.Vertex);
            IndexVbo = VboStore.AcquireVbo(trace, VboType.Index);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexVbo.BufferID);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndexVbo.BufferID);
            GL.BindVertexArray(0);
        }

        private readonly int _VaoID;

        private readonly Vbo
            IndexVbo,
            VertexVbo;

        public int ElementCount => IndexVbo.ElementsCount;

        public int VaoID => _VaoID;

        public void ReleaseBuffers()
        {
            VboStore.ReleaseVbo(IndexVbo);
            VboStore.ReleaseVbo(VertexVbo);
            GL.DeleteVertexArray(VaoID);
        }
    }
}