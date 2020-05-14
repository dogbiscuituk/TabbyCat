namespace TabbyCat.Models
{
    using Converters;
    using Newtonsoft.Json;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using Properties;
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using Types;
    using Utils;

    public class Shape : Shaders, IShape
    {
        // Constructors

        public Shape() => Init();

        public Shape(Scene scene) : this() => Scene = scene;

        // Private fields

        private int _index;

        // Public properties

        public int AxesCount
        {
            get
            {
                switch (AxesUsed)
                {
                    case Axes.None:
                        return 0;
                    case Axes.X:
                    case Axes.Y:
                    case Axes.Z:
                        return 1;
                    case Axes.XYZ:
                        return 3;
                    default:
                        return 2;
                }
            }
        }

        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public Axes AxesUsed =>
            (StripeCount.X != 0 ? Axes.X : 0) |
            (StripeCount.Y != 0 ? Axes.Y : 0) |
            (StripeCount.Z != 0 ? Axes.Z : 0);

        [DefaultValue("")]
        public string Description { get; set; }

        [JsonIgnore]
        public int Index
        {
            get => Scene?.Shapes.IndexOf(this) ?? _index;
            private set => _index = value;
        }

        [JsonConverter(typeof(Vector3Converter))]
        public Vector3 Location { get; set; }

        [JsonConverter(typeof(Vector3Converter))]
        public Vector3 Maximum { get; set; }

        [JsonConverter(typeof(Vector3Converter))]
        public Vector3 Minimum { get; set; }

        [JsonConverter(typeof(Vector3Converter))]
        public Vector3 Orientation { get; set; }

        public Pattern Pattern { get; set; }

        [JsonConverter(typeof(Vector3Converter))]
        public Vector3 Scale { get; set; }

        /// <summary>
        /// The Scene object which owns this Shape.
        /// </summary>
        [JsonIgnore]
        public Scene Scene { get; set; }

        [JsonConverter(typeof(Vector3Converter))]
        public Vector3 StripeCount { get; set; }

        /// <summary>
        /// The Video Array Object associated with this Shape.
        /// </summary>
        [JsonIgnore]
        public Vao Vao { get; set; }

        [DefaultValue(true)]
        public bool Visible { get; set; } = true;

        // Public methods

        public Matrix4 GetTransform() => MathUtils.CreateTransformation(Location, Orientation, Scale);

        public override string ToString() => !string.IsNullOrWhiteSpace(Description)
            ? Description
            : Index >= 0
            ? $"Shape #{Index + 1}"
            : "New shape";

        // Protected methods

        protected void SetFormula(ShaderType shaderType, string formula) => SetScript(shaderType, PreviewShader(shaderType, formula));

        // Private methods

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
            VertexShader = Resources.Shape_VertexShader;
            TessControlShader = Resources.Shape_TessControlShader;
            TessEvaluationShader = Resources.Shape_TessEvaluationShader;
            GeometryShader = Resources.Shape_GeometryShader;
            FragmentShader = Resources.Shape_FragmentShader;
            ComputeShader = Resources.Shape_ComputeShader;
        }

        private string PreviewShader(ShaderType shaderType, string formula)
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
    }
}
