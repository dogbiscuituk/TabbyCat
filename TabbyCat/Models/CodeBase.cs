﻿namespace TabbyCat.Models
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
    public abstract class CodeBase : ICodeBase
    {
        protected CodeBase() { }

        protected CodeBase(CodeBase codeBase) => CopyFrom(codeBase);

        [DefaultValue("")] public string VertexShader { get; set; }
        [DefaultValue("")] public string TessControlShader { get; set; }
        [DefaultValue("")] public string TessEvaluationShader { get; set; }
        [DefaultValue("")] public string GeometryShader { get; set; }
        [DefaultValue("")] public string FragmentShader { get; set; }
        [DefaultValue("")] public string ComputeShader { get; set; }

        public string GetScript(ShaderType shaderType)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    return VertexShader;
                case ShaderType.TessControlShader:
                    return TessControlShader;
                case ShaderType.TessEvaluationShader:
                    return TessEvaluationShader;
                case ShaderType.GeometryShader:
                    return GeometryShader;
                case ShaderType.FragmentShader:
                    return FragmentShader;
                case ShaderType.ComputeShader:
                    return ComputeShader;
                default:
                    return string.Empty;
            }
        }

        public void SetScript(ShaderType shaderType, string value)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    VertexShader = value;
                    break;
                case ShaderType.TessControlShader:
                    TessControlShader = value;
                    break;
                case ShaderType.TessEvaluationShader:
                    TessEvaluationShader = value;
                    break;
                case ShaderType.GeometryShader:
                    GeometryShader = value;
                    break;
                case ShaderType.FragmentShader:
                    FragmentShader = value;
                    break;
                case ShaderType.ComputeShader:
                    ComputeShader = value;
                    break;
            }
        }

        private void CopyFrom(IScript source) => Array.ForEach(ShaderUtils.All.ToArray(), p => SetScript(p, source.GetScript(p)));
    }
}
