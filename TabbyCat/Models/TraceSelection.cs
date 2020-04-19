namespace TabbyCat.Models
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TabbyCat.Common.Types;

    public class TraceSelection : IShaderSet
    {
        private readonly List<Trace> _Traces = new List<Trace>();
        private bool Updated;
        private int UpdateCount;

        public string Description
        {
            get => GetProperty(p => p.Description);
            set => SetProperty(p => p.Description = value);
        }

        public Vector3 Location
        {
            get => GetVector3(p => p.Location);
            set => SetProperty(p => p.Location = value);
        }

        public Vector3 Maximum
        {
            get => GetVector3(p => p.Maximum);
            set => SetProperty(p => p.Maximum = value);
        }

        public Vector3 Minimum
        {
            get => GetVector3(p => p.Minimum);
            set => SetProperty(p => p.Minimum = value);
        }

        public Vector3 Orientation
        {
            get => GetVector3(p => p.Orientation);
            set => SetProperty(p => p.Orientation = value);
        }

        public Pattern Pattern
        {
            get => (Pattern)GetProperty(p => (int)p.Pattern);
            set => SetProperty(p => p.Pattern = value);
        }

        public Vector3 Scale
        {
            get => GetVector3(p => p.Scale);
            set => SetProperty(p => p.Scale = value);
        }

        public Vector3 StripeCount
        {
            get => GetVector3(p => p.StripeCount);
            set => SetProperty(p => p.StripeCount = value);
        }

        public bool? Visible
        {
            get => GetBool(p => p.Visible);
            set => SetProperty(p => p.Visible = value == true);
        }

        public string GetScript(ShaderType shaderType) =>
            GetProperty(p => p.GetScript(shaderType)) ?? string.Empty;

        public void SetScript(ShaderType shaderType, string value) =>
            SetProperty(p => p.SetScript(shaderType, value));

        public override string ToString() => IsEmpty
            ? string.Empty
            : _Traces.Select(p => p.ToString()).Aggregate((s, t) => $"{s}, {t}");

        internal bool IsEmpty => !_Traces.Any();

        internal IEnumerable<Trace> Traces => _Traces.OrderBy(p => p.Index);

        internal event EventHandler Changed;

        internal void Add(Trace trace)
        {
            if (_Traces.Contains(trace))
                return;
            _Traces.Add(trace);
            OnChanged();
        }

        internal void AddRange(IEnumerable<Trace> traces)
        {
            traces = traces.Where(p => !_Traces.Contains(p)).ToList();
            if (IsEmpty)
                return;
            _Traces.AddRange(traces);
            OnChanged();
        }

        internal void BeginUpdate() => UpdateCount++;

        internal void Clear()
        {
            if (IsEmpty)
                return;
            _Traces.Clear();
            OnChanged();
        }

        internal void EndUpdate()
        {
            if (--UpdateCount > 0 || !Updated)
                return;
            Updated = false;
            OnChanged();
        }

        internal void ForEach(Action<Trace> action)
        {
            foreach (var trace in _Traces)
                action(trace);
        }

        internal IEnumerable<int> GetTraceIndices() =>
            _Traces.Select(p => p.Index);

        internal void Remove(Trace trace)
        {
            if (!_Traces.Contains(trace))
                return;
            _Traces.Remove(trace);
            OnChanged();
        }

        internal void Set(IEnumerable<Trace> traces)
        {
            _Traces.Clear();
            _Traces.AddRange(traces);
            OnChanged();
        }

        protected virtual void OnChanged()
        {
            if (UpdateCount > 0)
                Updated = true;
            else
                Changed?.Invoke(this, EventArgs.Empty);
        }

        private bool? GetBool(Func<Trace, bool> f)
        {
            if (IsEmpty)
                return default;
            bool first = f(_Traces.First());
            return _Traces.FirstOrDefault(p => !Equals(f(p), first)) != null
                ? (bool?)null
                : first;
        }

        private T GetProperty<T>(Func<Trace, T> f) where T : IEquatable<T>
        {
            if (IsEmpty)
                return default;
            T first = f(_Traces.First());
            return _Traces.FirstOrDefault(p => !Equals(f(p), first)) != null
                ? default
                : first;
        }

        private Vector3 GetVector3(Func<Trace, Vector3> f) => new Vector3(
            GetProperty(p => f(p).X),
            GetProperty(p => f(p).Y),
            GetProperty(p => f(p).Z));

        private void SetProperty(Action<Trace> set) => ForEach(p => set(p));
    }
}