namespace TabbyCat.Models
{
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.ComponentModel;
    using System.Linq;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;

    /// <summary>
    /// Base class for Scene and Trace (but not TraceSelection).
    /// Provides concrete string properties for shader code.
    /// </summary>
    public abstract class Code : ICode
    {
        protected Code() { }

        protected Code(Code code) => CopyFrom(code);

        public abstract string GetScript(ShaderType shaderType);

        public abstract void SetScript(ShaderType shaderType, string value);

        public abstract string VertexShader { get; set; }
        public abstract string TessControlShader { get; set; }
        public abstract string TessEvaluationShader { get; set; }
        public abstract string GeometryShader { get; set; }
        public abstract string FragmentShader { get; set; }
        public abstract string ComputeShader { get; set; }

        private void CopyFrom(IShaderSet source) => Array.ForEach(
            Shaders.All.ToArray(),
            p => SetScript(p, source.GetScript(p)));
    }
}
