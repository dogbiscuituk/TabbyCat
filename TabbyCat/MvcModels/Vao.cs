namespace TabbyCat.MvcModels
{
    using OpenTK.Graphics.OpenGL;

    internal class Vao
    {
        #region Constructors

        internal Vao(Trace trace)
        {
            GL.GenVertexArrays(1, out VaoID);
            GL.BindVertexArray(VaoID);
            VertexVbo = VboStore.AcquireVbo(trace, VboType.Vertex);
            IndexVbo = VboStore.AcquireVbo(trace, VboType.Index);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexVbo.BufferID);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndexVbo.BufferID);
            GL.BindVertexArray(0);
        }

        #endregion

        #region Fields, Properties

        internal int ElementCount => IndexVbo.ElementsCount;

        internal readonly int VaoID;

        private readonly Vbo
            IndexVbo,
            VertexVbo;

        #endregion

        #region Internal Methods

        internal bool ReleaseBuffers()
        {
            VboStore.ReleaseVbo(IndexVbo);
            VboStore.ReleaseVbo(VertexVbo);
            GL.DeleteVertexArray(VaoID);
            return true;
        }

        #endregion
    }
}