namespace TabbyCat.Models
{
    using Newtonsoft.Json;
    using OpenTK;
    using System.ComponentModel;
    using TabbyCat.Common.Converters;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.Properties;

    public class Trace : Code, ITrace
    {
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
            Shader1Vertex = Resources.Trace_Shader1Vertex;
            Shader2TessControl = Resources.Trace_Shader2TessControl;
            Shader3TessEvaluation = Resources.Trace_Shader3TessEvaluation;
            Shader4Geometry = Resources.Trace_Shader4Geometry;
            Shader5Fragment = Resources.Trace_Shader5Fragment;
            Shader6Compute = Resources.Trace_Shader6Compute;
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
