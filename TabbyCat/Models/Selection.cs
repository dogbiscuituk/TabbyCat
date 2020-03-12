namespace TabbyCat.Models
{
    using OpenTK;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TabbyCat.Common.Types;

    public class Selection : ShaderSet
    {
        #region Public Properties

        public string Description
        {
            get => GetProperty(p => p.Description);
            set => SetProperty(p => p.Description = value);
        }

        public bool IsEmpty => !_Traces.Any();

        public Vector3 Location
        {
            get => GetProperty(p => p.Location);
            set => SetProperty(p => p.Location = value);
        }

        public Vector3 Maximum
        {
            get => GetProperty(p => p.Maximum);
            set => SetProperty(p => p.Maximum = value);
        }

        public Vector3 Minimum
        {
            get => GetProperty(p => p.Minimum);
            set => SetProperty(p => p.Minimum = value);
        }

        public Vector3 Orientation
        {
            get => GetProperty(p => p.Orientation);
            set => SetProperty(p => p.Orientation = value);
        }

        public Pattern Pattern
        {
            get => GetPattern();
            set => SetProperty(p => p.Pattern = value);
        }

        public Vector3 Scale
        {
            get => GetProperty(p => p.Scale);
            set => SetProperty(p => p.Scale = value);
        }

        public override string Shader1Vertex
        {
            get => GetProperty(p => p.Shader1Vertex);
            set => SetProperty(p => p.Shader1Vertex = value);
        }

        public override string Shader2TessControl
        {
            get => GetProperty(p => p.Shader2TessControl);
            set => SetProperty(p => p.Shader2TessControl = value);
        }

        public override string Shader3TessEvaluation
        {
            get => GetProperty(p => p.Shader3TessEvaluation);
            set => SetProperty(p => p.Shader3TessEvaluation = value);
        }

        public override string Shader4Geometry
        {
            get => GetProperty(p => p.Shader4Geometry);
            set => SetProperty(p => p.Shader4Geometry = value);
        }

        public override string Shader5Fragment
        {
            get => GetProperty(p => p.Shader5Fragment);
            set => SetProperty(p => p.Shader5Fragment = value);
        }

        public override string Shader6Compute
        {
            get => GetProperty(p => p.Shader6Compute);
            set => SetProperty(p => p.Shader6Compute = value);
        }

        public Vector3 StripCount
        {
            get => GetProperty(p => p.StripCount);
            set => SetProperty(p => p.StripCount = value);
        }

        public bool? Visible
        {
            get => GetProperty(p => p.Visible);
            set => SetProperty(p => p.Visible = value == true);
        }

        #endregion

        #region Public Events

        public event EventHandler Changed;

        #endregion

        #region Internal Methods

        internal void Add(Trace trace)
        {
            if (_Traces.Contains(trace))
                return;
            _Traces.Add(trace);
            OnChanged();
        }

        internal void Clear()
        {
            if (IsEmpty)
                return;
            _Traces.Clear();
            OnChanged();
        }

        internal void Remove(Trace trace)
        {
            if (!_Traces.Contains(trace))
                return;
            _Traces.Remove(trace);
            OnChanged();
        }

        #endregion

        #region Protected Methods

        protected virtual void OnChanged() => Changed?.Invoke(this, EventArgs.Empty);

        #endregion

        #region Private Fields

        private readonly List<Trace> _Traces = new List<Trace>();

        #endregion

        #region Private Methods

        private Pattern GetPattern()
        {
            if (IsEmpty)
                return default;
            Pattern first = _Traces.First().Pattern;
            return _Traces.FirstOrDefault(p => p.Pattern == first) == null
                ? default
                : first;
        }

        private T GetProperty<T>(Func<Trace, T> getProperty) where T: IEquatable<T>
        {
            if (IsEmpty)
                return default;
            T first = getProperty(_Traces.First());
            return _Traces.FirstOrDefault(p => getProperty(p).Equals(first)) == null
                ? default
                : first;
        }

        private void SetProperty(Action<Trace> setProperty)
        {
            if (IsEmpty)
                return;
            foreach (var trace in _Traces)
                setProperty(trace);
        }

        internal void ForEach(Action<Trace> action)
        {
            foreach (var trace in _Traces)
                action(trace);
        }

        #endregion
    }
}
