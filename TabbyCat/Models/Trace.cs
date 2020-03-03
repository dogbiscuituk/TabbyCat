namespace TabbyCat.Models
{
    using Newtonsoft.Json;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System.Linq;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.Properties;

    internal class Trace : CodeSource
    {
        #region Constructors

        public Trace() => RestoreDefaults();
        public Trace(Scene scene) : this() => Init(scene);
        public Trace(Trace trace) : this() => CopyFrom(trace);

        #endregion

        [JsonProperty]
        internal string _Description;
        internal string Description
        {
            get => _Description;
            set
            {
                if (Description != value)
                {
                    _Description = value;
                    OnPropertiesChanged(nameof(Description));
                }
            }
        }

        [JsonProperty]
        internal Vector3d _Location;
        internal Vector3d Location
        {
            get => _Location;
            set
            {
                if (Location != value)
                {
                    _Location = value;
                    OnPropertiesChanged(nameof(Location));
                }
            }
        }

        [JsonProperty]
        internal Vector3d _Maximum;
        internal Vector3d Maximum
        {
            get => _Maximum;
            set
            {
                if (Maximum != value)
                {
                    _Maximum = value;
                    OnPropertiesChanged(nameof(Maximum));
                }
            }
        }

        [JsonProperty]
        internal Vector3d _Minimum;
        internal Vector3d Minimum
        {
            get => _Minimum;
            set
            {
                if (Minimum != value)
                {
                    _Minimum = value;
                    OnPropertiesChanged(nameof(Minimum));
                }
            }
        }

        [JsonProperty]
        internal Vector3d _Orientation;
        internal Vector3d Orientation
        {
            get => _Orientation;
            set
            {
                if (Orientation != value)
                {
                    _Orientation = value;
                    OnPropertiesChanged(nameof(Orientation));
                }
            }
        }

        [JsonProperty]
        internal Pattern _Pattern;
        internal Pattern Pattern
        {
            get => _Pattern;
            set
            {
                if (Pattern != value)
                {
                    _Pattern = value;
                    OnPropertiesChanged(nameof(Pattern));
                }
            }
        }

        [JsonProperty]
        internal Vector3d _Scale;
        internal Vector3d Scale
        {
            get => _Scale;
            set
            {
                if (Scale != value)
                {
                    _Scale = value;
                    OnPropertiesChanged(nameof(Scale));
                }
            }
        }

        [JsonProperty]
        internal Vector3 _StripCount;
        internal Vector3 StripCount
        {
            get => _StripCount;
            set
            {
                if (StripCount != value)
                {
                    _StripCount = value;
                    OnPropertiesChanged(nameof(StripCount));
                }
            }
        }

        [JsonProperty]
        internal bool _Visible;
        internal bool Visible
        {
            get => _Visible;
            set
            {
                if (Visible != value)
                {
                    _Visible = value;
                    OnPropertiesChanged(nameof(Visible));
                }
            }
        }

        #region Internal Properties

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

        private int _Index;

        private void RestoreDefaults()
        {
            _Index = Defaults.Index;
            _Location = Defaults.Location;
            _Maximum = Defaults.Maximum;
            _Minimum = Defaults.Maximum;
            _Orientation = Defaults.Orientation;
            _Pattern = Defaults.Pattern;
            _Scale = Defaults.Scale;
            _Shader1Vertex = Resources.VertexBody;
            _Shader2TessControl = Defaults.Shader2TessControl;
            _Shader3TessEvaluation = Defaults.Shader3TessEvaluation;
            _Shader4Geometry = Defaults.Shader4Geometry;
            _Shader5Fragment = Resources.FragmentBody;
            _Shader6Compute = Defaults.Shader6Compute;
            _StripCount = Defaults.StripCount;
            _Description = Defaults.Description;
            _Visible = Defaults.Visible;
        }

        #region Protected Internal Methods

        internal override void OnPropertiesChanged(params string[] propertyNames) =>
            Scene.OnPropertiesChanged(propertyNames.Select(p => $"Traces[{Index}].{p}").ToArray());

        internal Matrix4d GetTransform() => Maths.CreateTransformation(Location, Orientation, Scale);

        #endregion

        #region Private Classes

        public class Defaults
        {
            public const Pattern
                Pattern = Common.Types.Pattern.Fill;

            public const bool
                Visible = true;

            public const int
                Index = -1;

            public static Vector3
                StripCount = new Vector3(100, 100, 0);

            public static Vector3d
                Location = new Vector3d(),
                Maximum = new Vector3d(),
                Minimum = new Vector3d(),
                Orientation = new Vector3d(),
                Scale = new Vector3d(1, 1, 1);

            public const string
                Description = "",
                Shader2TessControl = "",
                Shader3TessEvaluation = "",
                Shader4Geometry = "",
                Shader6Compute = "";

            internal const string
                LocationString = "0, 0, 0",
                MaximumString = "0, 0, 0",
                MinimumString = "0, 0, 0",
                OrientationString = "0, 0, 0",
                PatternString = "TriangleStrip",
                ScaleString = "1, 1, 1",
                StripCountString = "100, 100, 0";
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

        public void CopyFrom(Trace trace)
        {
            _Description = trace.Description;
            _Index = trace.Index;
            _Location = new Vector3d(trace.Location);
            _Maximum = new Vector3d(trace.Maximum);
            _Minimum = new Vector3d(trace.Minimum);
            _Orientation = new Vector3d(trace.Orientation);
            _Pattern = trace.Pattern;
            _Scale = new Vector3d(trace.Scale);
            _StripCount = new Vector3(trace.StripCount);
            _Visible = trace.Visible;
        }
    }
}
