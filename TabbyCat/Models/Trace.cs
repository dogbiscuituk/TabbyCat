namespace TabbyCat.Models
{
    using Converters;
    using Newtonsoft.Json;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using Properties;
    using System.ComponentModel;
    using Types;
    using Utils;

    public class Trace : Shaders, ITrace
    {
        // Constructors

        public Trace() : base() => Init();

        public Trace(Scene scene) : this() => Scene = scene;

        public Trace(Trace trace) : base(trace) => CopyFrom(trace ?? null);

        // Private fields

        private int _Index;

        // Public properties

        [DefaultValue("")]
        public string Description { get; set; }

        public Pattern Pattern { get; set; }

        [DefaultValue(true)]
        public bool Visible { get; set; } = true;

        [JsonConverter(typeof(Vector3Converter))]
        public Vector3 Location { get; set; }

        [JsonConverter(typeof(Vector3Converter))]
        public Vector3 Maximum { get; set; }

        [JsonConverter(typeof(Vector3Converter))]
        public Vector3 Minimum { get; set; }

        [JsonConverter(typeof(Vector3Converter))]
        public Vector3 Orientation { get; set; }

        [JsonConverter(typeof(Vector3Converter))]
        public Vector3 Scale { get; set; }

        [JsonConverter(typeof(Vector3Converter))]
        public Vector3 StripeCount { get; set; }

        [JsonIgnore]
        public int Index
        {
            get => Scene?.Traces.IndexOf(this) ?? _Index;
            private set => _Index = value;
        }

        /// <summary>
        /// The Scene object which owns this Trace.
        /// </summary>
        [JsonIgnore]
        public Scene Scene { get; set; }

        /// <summary>
        /// The Video Array Object associated with this Trace.
        /// </summary>
        [JsonIgnore]
        public Vao Vao { get; set; }

        // Public methods

        public override string ToString() => !string.IsNullOrWhiteSpace(Description)
            ? Description
            : Index >= 0
            ? $"Trace #{Index + 1}"
            : "New trace";

        public Matrix4 GetTransform() => MathUtils.CreateTransformation(Location, Orientation, Scale);

        public string PreviewShader(ShaderType shaderType, string formula)
        {
            var script = GetScript(shaderType);
            var beginLine = script.FindFirstTokenLine(Tokens.BeginFormula) + 1;
            var endLine = script.FindFirstTokenLine(Tokens.EndFormula);
            if (0 <= beginLine && beginLine < endLine)
            {
                string
                    head = script.GetLines(0, beginLine),
                    tail = script.GetLines(endLine, script.GetLineCount() - endLine);
                return $"{head}\r\n\r\n{formula}\r\n\r\n{tail}";
            }
            return string.Empty;
        }

        public void SetLocation(Vector3 location) => Location = location;

        public void SetOrientation(Vector3 orientation) => Orientation = orientation;

        public void SetScale(Vector3 scale) => Scale = scale;

        // Protected methods

        protected void SetFormula(ShaderType shaderType, string formula) => SetScript(shaderType, PreviewShader(shaderType, formula));

        // Private methods

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
            StripeCount = new Vector3(trace.StripeCount);
            Visible = trace.Visible;
        }

        private void Init()
        {
            Description = string.Empty;
            Index = -1;
            Location = Vector3.Zero;
            Maximum = Vector3.Zero;
            Minimum = Vector3.Zero;
            Orientation = Vector3.Zero;
            Pattern = Pattern.Fill;
            Scale = Vector3.One;
            StripeCount = new Vector3(100, 100, 0);
            Visible = true;
            InitShaders();
        }

        private void InitShaders()
        {
            VertexShader = Resources.Trace_VertexShader;
            TessControlShader = Resources.Trace_TessControlShader;
            TessEvaluationShader = Resources.Trace_TessEvaluationShader;
            GeometryShader = Resources.Trace_GeometryShader;
            FragmentShader = Resources.Trace_FragmentShader;
            ComputeShader = Resources.Trace_ComputeShader;
        }
    }
}
