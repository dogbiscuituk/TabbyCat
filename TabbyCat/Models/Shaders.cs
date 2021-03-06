﻿namespace TabbyCat.Models
{
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.ComponentModel;
    using System.Linq;
    using Types;
    using Utils;

    /// <summary>
    /// Base class for Scene and Shape (but not ShapeSelection).
    /// Provides concrete string properties for shader code.
    /// </summary>
    public abstract class Shaders : IShaders
    {
        // Constructors

        protected Shaders() { }

        protected Shaders(IScript shaders) => CopyFrom(shaders);

        // Public properties

        [DefaultValue("")]
        public string VertexShader { get; set; }

        [DefaultValue("")]
        public string TessControlShader { get; set; }

        [DefaultValue("")]
        public string TessEvaluationShader { get; set; }

        [DefaultValue("")]
        public string GeometryShader { get; set; }

        [DefaultValue("")]
        public string FragmentShader { get; set; }

        [DefaultValue("")]
        public string ComputeShader { get; set; }

        // Public methods

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

        // Private methods

        private void CopyFrom(IScript source) => Array.ForEach(ShaderUtils.All.ToArray(), p => SetScript(p, source.GetScript(p)));
    }
}
