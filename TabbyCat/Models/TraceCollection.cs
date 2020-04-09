namespace TabbyCat.Models
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TabbyCat.Common.Types;

    public class TraceCollection : List<Trace>, IShaderSet
    {
        #region Public Properties

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

        public Vector3 StripCount
        {
            get => GetVector3(p => p.StripCount);
            set => SetProperty(p => p.StripCount = value);
        }

        public bool? Visible
        {
            get => GetBool(p => p.Visible);
            set => SetProperty(p => p.Visible = value == true);
        }

        #endregion

        #region Public Methods

        private bool Updated;
        private int UpdateCount;

        public void BeginUpdate() => UpdateCount++;

        public void EndUpdate()
        {
            if (--UpdateCount > 0 || !Updated)
                return;
            Updated = false;
            OnChanged();
        }

        public string GetScript(ShaderType shaderType) =>
            GetProperty(p => p.GetScript(shaderType)) ?? string.Empty;

        public void SetScript(ShaderType shaderType, string value) =>
            SetProperty(p => p.SetScript(shaderType, value));

        public override string ToString() => Count < 1
            ? string.Empty
            : this.Select(p => p.ToString()).Aggregate((s, t) => $"{s}, {t}");

        #endregion

        #region Internal Events

        internal event EventHandler Changed;

        #endregion

        #region Internal Methods

        internal new void Add(Trace trace)
        {
            if (Contains(trace))
                return;
            base.Add(trace);
            OnChanged();
        }

        internal new void AddRange(IEnumerable<Trace> traces)
        {
            traces = traces.Where(p => !Contains(p)).ToList();
            if (!traces.Any())
                return;
            base.AddRange(traces);
            OnChanged();
        }

        internal new void Clear()
        {
            if (!this.Any())
                return;
            base.Clear();
            OnChanged();
        }

        internal new void ForEach(Action<Trace> action)
        {
            foreach (var trace in this)
                action(trace);
        }

        internal new void Remove(Trace trace)
        {
            if (!Contains(trace))
                return;
            base.Remove(trace);
            OnChanged();
        }

        internal void Set(IEnumerable<Trace> traces)
        {
            base.Clear();
            base.AddRange(traces);
            OnChanged();
        }

        #endregion

        #region Protected Methods

        protected virtual void OnChanged()
        {
            if (UpdateCount > 0)
                Updated = true;
            else
                Changed?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Private Methods

        private bool? GetBool(Func<Trace, bool> f)
        {
            if (!this.Any())
                return default;
            bool first = f(this.First());
            return this.FirstOrDefault(p => !Equals(f(p), first)) != null
                ? (bool?)null
                : first;
        }

        private T GetProperty<T>(Func<Trace, T> f) where T : IEquatable<T>
        {
            if (!this.Any())
                return default;
            T first = f(this.First());
            return this.FirstOrDefault(p => !Equals(f(p), first)) != null
                ? default
                : first;
        }

        private Vector3 GetVector3(Func<Trace, Vector3> f) => new Vector3(
            GetProperty(p => f(p).X),
            GetProperty(p => f(p).Y),
            GetProperty(p => f(p).Z));

        private void SetProperty(Action<Trace> set) => ForEach(p => set(p));

        #endregion
    }
}