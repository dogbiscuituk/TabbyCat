namespace TabbyCat.Models
{
    using Newtonsoft.Json;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System.Linq;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.Properties;

    public class Trace : CodeSource
    {
        #region Constructors

        public Trace() => RestoreDefaults();
        public Trace(Scene scene) : this() => Init(scene);
        public Trace(Trace trace) : this() => CopyFrom(trace);

        #endregion

        #region Public Properties

        public string Description { get; set; }
        public Vector3d Location { get; set; }
        public Vector3d Maximum { get; set; }
        public Vector3d Minimum { get; set; }
        public Vector3d Orientation { get; set; }
        public Pattern Pattern { get; set; }
        public Vector3d Scale { get; set; }
        public Vector3 StripCount { get; set; }
        public bool Visible { get; set; }

        #endregion

        #region Public Methods

        public void CopyFrom(Trace trace)
        {
            Description = trace.Description;
            Index = trace.Index;
            Location = new Vector3d(trace.Location);
            Maximum = new Vector3d(trace.Maximum);
            Minimum = new Vector3d(trace.Minimum);
            Orientation = new Vector3d(trace.Orientation);
            Pattern = trace.Pattern;
            Scale = new Vector3d(trace.Scale);
            StripCount = new Vector3(trace.StripCount);
            Visible = trace.Visible;
        }

        #endregion

        #region Internal Properties

        private int _Index;
        internal int Index
        {
            get => Scene?.Traces.IndexOf(this) ?? _Index;
            set => _Index = value;
        }

        internal Scene Scene;

        internal int
            _VaoID,
            _VaoVertexCount,
            _VboVertexID,
            _VboIndexID;

        internal bool _VaoValid;

        #endregion

        private void RestoreDefaults()
        {
            Index = Defaults.Index;
            Location = Defaults.Location;
            Maximum = Defaults.Maximum;
            Minimum = Defaults.Maximum;
            Orientation = Defaults.Orientation;
            Pattern = Defaults.Pattern;
            Scale = Defaults.Scale;
            Shader1Vertex = Resources.VertexBody;
            Shader5Fragment = Resources.FragmentBody;
            StripCount = Defaults.StripCount;
            Description = Defaults.Description;
            Visible = Defaults.Visible;
        }

        #region Protected Internal Methods

        internal Matrix4d GetTransform() => Maths.CreateTransformation(Location, Orientation, Scale);

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
                StripCount = new Vector3(100, 100, 0);

            internal static Vector3d
                Location = new Vector3d(),
                Maximum = new Vector3d(),
                Minimum = new Vector3d(),
                Orientation = new Vector3d(),
                Scale = new Vector3d(1, 1, 1);

            internal const string
                Description = "";
        }

        #endregion

        internal void Init(Scene scene) => Scene = scene;

        internal void SetLocation(Vector3d location) => Location = location;

        internal void SetOrientation(Vector3d orientation) => Orientation = orientation;

        internal void SetScale(Vector3d scale) => Scale = scale;

        /*internal void SetTransform(Matrix4d transform)
        {
            SetLocation(transform.ExtractTranslation());
            SetOrientation(transform.ExtractRotation());
            SetScale(transform.ExtractScale());
        }*/
    }
}
