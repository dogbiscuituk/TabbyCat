namespace TabbyCat.Models
{
    using Newtonsoft.Json;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System.ComponentModel;
    using TabbyCat.Common.Converters;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.Properties;

    public class Trace : Code, ITrace
    {
        public override string GetScript(ShaderType shaderType)
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

        public override void SetScript(ShaderType shaderType, string value)
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

        [DefaultValue("")] public override string VertexShader { get; set; }
        [DefaultValue("")] public override string TessControlShader { get; set; }
        [DefaultValue("")] public override string TessEvaluationShader { get; set; }
        [DefaultValue("")] public override string GeometryShader { get; set; }
        [DefaultValue("")] public override string FragmentShader { get; set; }
        [DefaultValue("")] public override string ComputeShader { get; set; }

        public Trace()
        {
            Description = string.Empty;
            Index = -1;
            Location = Vector3.Zero;
            Maximum = Vector3.Zero;
            Minimum = Vector3.Zero;
            Orientation = Vector3.Zero;
            Pattern = Pattern.Fill;
            Scale = Vector3.One;
            VertexShader = Resources.Trace_VertexShader;
            TessControlShader = Resources.Trace_TessControlShader;
            TessEvaluationShader = Resources.Trace_TessEvaluationShader;
            GeometryShader = Resources.Trace_GeometryShader;
            FragmentShader = Resources.Trace_FragmentShader;
            ComputeShader = Resources.Trace_ComputeShader;
            StripCount = new Vector3(100, 100, 0);
            Visible = true;
        }

        internal Trace(Scene scene) : this() => Scene = scene;

        internal Trace(Trace trace) : base(trace) => CopyFrom(trace);

        private int _Index;

        [DefaultValue("")]
        public string Description { get; set; }

        public Pattern Pattern { get; set; }

        [DefaultValue(true)]
        public bool Visible { get; set; } = true;

        [JsonConverter(typeof(Vector3Converter))] public Vector3 Location { get; set; }
        [JsonConverter(typeof(Vector3Converter))] public Vector3 Maximum { get; set; }
        [JsonConverter(typeof(Vector3Converter))] public Vector3 Minimum { get; set; }
        [JsonConverter(typeof(Vector3Converter))] public Vector3 Orientation { get; set; }
        [JsonConverter(typeof(Vector3Converter))] public Vector3 Scale { get; set; }
        [JsonConverter(typeof(Vector3Converter))] public Vector3 StripCount { get; set; }

        internal int Index
        {
            get => Scene?.Traces.IndexOf(this) ?? _Index;
            set => _Index = value;
        }

        internal Scene Scene;

        internal Vao Vao;

        public override string ToString() =>
            !string.IsNullOrWhiteSpace(Description)
            ? Description
            : Index >= 0
            ? $"Trace #{Index + 1}"
            : "New trace";

        internal Matrix4 GetTransform() => Maths.CreateTransformation(Location, Orientation, Scale);

        internal void SetLocation(Vector3 location) => Location = location;

        internal void SetOrientation(Vector3 orientation) => Orientation = orientation;

        internal void SetScale(Vector3 scale) => Scale = scale;

        /*internal void SetTransform(Matrix4 transform)
        {
            SetLocation(transform.ExtractTranslation());
            SetOrientation(transform.ExtractRotation());
            SetScale(transform.ExtractScale());
        }*/

        private void CopyFrom(Trace trace)
        {
            Description = trace.Description;
            Index = trace.Index;
            Location = new Vector3(trace.Location);
            Maximum = new Vector3(trace.Maximum);
            Minimum = new Vector3(trace.Minimum);
            Orientation = new Vector3(trace.Orientation);
            Pattern = trace.Pattern;
            Scale = new Vector3(trace.Scale);
            StripCount = new Vector3(trace.StripCount);
            Visible = trace.Visible;
        }
    }
}
