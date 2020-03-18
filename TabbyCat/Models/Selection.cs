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
            get => GetProperty(p => p.Description);
            set => SetProperty(p => p.Description = value);
        }

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

        #region Public Methods

        public string GetScript(ShaderType shaderType) =>
            GetProperty(p => p.GetScript(shaderType)) ?? string.Empty;

        public void SetScript(ShaderType shaderType, string value) =>
            SetProperty(p => p.SetScript(shaderType, value));

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

        #region Private Fields

        //private readonly List<Trace> _Traces = new List<Trace>();

        #endregion

        #region Private Methods

        private Pattern GetPattern()
        {
            if (!this.Any())
                return default;
            Pattern first = this.First().Pattern;
            return this.FirstOrDefault(p => p.Pattern == first) == null
                ? default
                : first;
        }

        private T GetProperty<T>(Func<Trace, T> getProperty) where T : IEquatable<T>
        {
            if (!this.Any())
                return default;
            T first = getProperty(this.First());
            return this.FirstOrDefault(p => getProperty(p).Equals(first)) == null
                ? default
                : first;
        }

        private void SetProperty(Action<Trace> setProperty)
        {
            if (!this.Any())
                return;
            foreach (var trace in this)
                setProperty(trace);
        }

        internal new void ForEach(Action<Trace> action)
        {
            foreach (var trace in this)
                action(trace);
        }

        #endregion
    }
}
