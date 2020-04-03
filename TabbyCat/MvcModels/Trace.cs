namespace TabbyCat.MvcModels
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
        #region Constructors

        public Trace() => Init();

        internal Trace(Scene scene) : this() => Scene = scene;

        internal Trace(Trace trace) : base(trace) => CopyFrom(trace);

        #endregion

        #region Public Properties

        [DefaultValue("")]
        public string Description { get; set; } = "";

        public Pattern Pattern { get; set; }

        [DefaultValue(true)]
        public bool Visible { get; set; } = true;

        [JsonConverter(typeof(Vector3Converter))] public Vector3 Location { get; set; }
        [JsonConverter(typeof(Vector3Converter))] public Vector3 Maximum { get; set; }
        [JsonConverter(typeof(Vector3Converter))] public Vector3 Minimum { get; set; }
        [JsonConverter(typeof(Vector3Converter))] public Vector3 Orientation { get; set; }
        [JsonConverter(typeof(Vector3Converter))] public Vector3 Scale { get; set; }
        [JsonConverter(typeof(Vector3Converter))] public Vector3 StripCount { get; set; }

        #endregion

        #region Public Methods

        public override string ToString() =>
            !string.IsNullOrWhiteSpace(Description)
            ? Description
            : Index >= 0
            ? $"Trace #{Index + 1}"
            : "New trace";

        #endregion

        #region Internal Properties

        private int _Index;
        internal int Index
        {
            get => Scene?.Traces.IndexOf(this) ?? _Index;
            set => _Index = value;
        }

        internal Scene Scene;

        internal Vao Vao;

        #endregion

        #region Internal Methods

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

        #endregion

        #region Private Classes

        private class Defaults
        {
            internal const Pattern
                Pattern = Common.Types.Pattern.Fill;

            internal const bool
                Visible = true;

            internal const int
                Index = -1;

            internal static Vector3
                Location = Vector3.Zero,
                Maximum = Vector3.Zero,
                Minimum = Vector3.Zero,
                Orientation = Vector3.Zero,
                Scale = Vector3.One,
                StripCount = new Vector3(100, 100, 0);
        }

        #endregion

        #region Private Methods

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

        private void Init()
        {
            Index = Defaults.Index;
            Location = Defaults.Location;
            Maximum = Defaults.Maximum;
            Minimum = Defaults.Maximum;
            Orientation = Defaults.Orientation;
            Pattern = Defaults.Pattern;
            Scale = Defaults.Scale;
            Shader1Vertex = Resources.Trace_Shader1Vertex;
            Shader2TessControl = Resources.Trace_Shader2TessControl;
            Shader3TessEvaluation = Resources.Trace_Shader3TessEvaluation;
            Shader4Geometry = Resources.Trace_Shader4Geometry;
            Shader5Fragment = Resources.Trace_Shader5Fragment;
            Shader6Compute = Resources.Trace_Shader6Compute;
            StripCount = Defaults.StripCount;
        }

        #endregion
    }
}
