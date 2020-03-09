namespace TabbyCat.Models
{
    using OpenTK.Graphics.OpenGL;

    public abstract class Code : Shaders
    {
        #region Constructors

        public Code() => Init();

        protected Code(Code code) => CopyFrom(code);

        #endregion

        #region Public Properties

        public override string Shader1Vertex { get; set; }
        public override string Shader2TessControl { get; set; }
        public override string Shader3TessEvaluation { get; set; }
        public override string Shader4Geometry { get; set; }
        public override string Shader5Fragment { get; set; }
        public override string Shader6Compute { get; set; }

        #endregion

        #region Private Methods

        private void CopyFrom(Code code)
        {
            Shader1Vertex = code.Shader1Vertex;
            Shader2TessControl = code.Shader2TessControl;
            Shader3TessEvaluation = code.Shader3TessEvaluation;
            Shader4Geometry = code.Shader4Geometry;
            Shader5Fragment = code.Shader5Fragment;
            Shader6Compute = code.Shader6Compute;
        }

        private void Init()
        {
            Shader1Vertex = string.Empty;
            Shader2TessControl = string.Empty;
            Shader3TessEvaluation = string.Empty;
            Shader4Geometry = string.Empty;
            Shader5Fragment = string.Empty;
            Shader6Compute = string.Empty;
        }

        #endregion
    }
}
