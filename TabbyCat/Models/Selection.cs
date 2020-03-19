namespace TabbyCat.Models
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TabbyCat.Common.Types;

    public class Selection : List<Trace>, IShaderSet
    {
        #region Public Properties

        public string Description
        {
            get => Get(p => p.Description);
            set => Set(p => p.Description = value);
        }

        public Vector3 Location
        {
            get => Get(p => p.Location);
            set => Set(p => p.Location = value);
        }

        public Vector3 Maximum
        {
            get => Get(p => p.Maximum);
            set => Set(p => p.Maximum = value);
        }

        public Vector3 Minimum
        {
            get => Get(p => p.Minimum);
            set => Set(p => p.Minimum = value);
        }

        public Vector3 Orientation
        {
            get => Get(p => p.Orientation);
            set => Set(p => p.Orientation = value);
        }

        public Pattern Pattern
        {
            get => (Pattern)Get(p => (int)p.Pattern);
            set => Set(p => p.Pattern = value);
        }

        public Vector3 Scale
        {
            get => Get(p => p.Scale);
            set => Set(p => p.Scale = value);
        }

        public Vector3 StripCount
        {
            get => Get(p => p.StripCount);
            set => Set(p => p.StripCount = value);
        }

        public bool? Visible
        {
            get => Get(p => p.Visible);
            set => Set(p => p.Visible = value == true);
        }

        #endregion

        #region Public Events

        public event EventHandler Changed;

        #endregion

        #region Public Methods

        public string GetScript(ShaderType shaderType) =>
            Get(p => p.GetScript(shaderType)) ?? string.Empty;

        public void SetScript(ShaderType shaderType, string value) =>
            Set(p => p.SetScript(shaderType, value));

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

        #endregion

        #region Protected Methods

        protected virtual void OnChanged() => Changed?.Invoke(this, EventArgs.Empty);

        #endregion

        #region Private Methods

        private T Get<T>(Func<Trace, T> f) where T : IEquatable<T>
        {
            if (!this.Any())
                return default;
            T first = f(this.First());
            return this.FirstOrDefault(p => !Equals(f(p), first)) != null
                ? default
                : first;
        }

        private Vector3 Get(Func<Trace, Vector3> f) => new Vector3(
            Get(p => f(p).X),
            Get(p => f(p).Y),
            Get(p => f(p).Z));

        private void Set(Action<Trace> set) => ForEach(p => set(p));

        #endregion
    }
}
