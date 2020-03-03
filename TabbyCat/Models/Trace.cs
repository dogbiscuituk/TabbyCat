namespace TabbyCat.Models
{
    using Newtonsoft.Json;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;

    internal class Trace : CodeContainer
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
                    OnPropertyChanged(nameof(Description));
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
                    OnPropertyChanged(nameof(Location));
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
                    OnPropertyChanged(nameof(Maximum));
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
                    OnPropertyChanged(nameof(Minimum));
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
                    OnPropertyChanged(nameof(Orientation));
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
                    OnPropertyChanged(nameof(Pattern));
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
                    OnPropertyChanged(nameof(Scale));
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
                    OnPropertyChanged(nameof(StripCount));
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
                    OnPropertyChanged(nameof(Visible));
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

        #region Protected Internal Methods

        internal override void OnPropertyChanged(string propertyName)
        {
            Scene.OnPropertyChanged($"Traces[{Index}].{propertyName}");
        }

        internal Matrix4d GetTransform() => Maths.CreateTransformation(Location, Orientation, Scale);

        #endregion

        internal void Init(Scene scene) => Scene = scene;

        internal void SetLocation(Vector3d location) => Location = location;

        internal void SetOrientation(Vector3d orientation) => Orientation = orientation;

        internal void SetScale(Vector3d scale) => Scale = scale;

        public void CopyFrom(Trace trace)
        {
            _Description = trace.Description;
            _Index = trace.Index;
            _Location = new Vector3f(trace.Location);
            _Maximum = new Vector3f(trace.Maximum);
            _Minimum = new Vector3f(trace.Minimum);
            _Orientation = new Euler3f(trace.Orientation);
            _Pattern = trace.Pattern;
            _Scale = new Vector3f(trace.Scale);
            _StripCount = new Vector3i(trace.StripCount);
            _Visible = trace.Visible;
        }
    }
}
