namespace TabbyCat.Models
{
    using Newtonsoft.Json;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;

    internal class Trace : Foo
    {
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

        internal Matrix4 GetTransform() => Maths.CreateTransformation(Location, Orientation, Scale);

        #endregion

        internal void Init(Scene scene) => Scene = scene;
    }
}
