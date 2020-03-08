namespace TabbyCat.Models
{
    using OpenTK;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TabbyCat.Common.Types;

    public class Selection : ITrace
    {
        public string Description
        {
            get => GetProperty(p => p.Description);
            set => SetProperty(p => p.Description = value);
        }

        public Vector3d Location
        {
            get => GetProperty(p => p.Location);
            set => SetProperty(p => p.Location = value);
        }

        public Vector3d Maximum
        {
            get => GetProperty(p => p.Maximum);
            set => SetProperty(p => p.Maximum = value);
        }

        public Vector3d Minimum
        {
            get => GetProperty(p => p.Minimum);
            set => SetProperty(p => p.Minimum = value);
        }

        public Vector3d Orientation
        {
            get => GetProperty(p => p.Orientation);
            set => SetProperty(p => p.Orientation = value);
        }

        public Pattern Pattern
        {
            get => throw new NotImplementedException();
            set => SetProperty(p => p.Pattern = value);
        }

        public Vector3d Scale
        {
            get => GetProperty(p => p.Scale);
            set => SetProperty(p => p.Scale = value);
        }

        public string Shader1Vertex
        {
            get => GetProperty(p => p.Shader1Vertex);
            set => SetProperty(p => p.Shader1Vertex = value);
        }

        public string Shader2TessControl
        {
            get => GetProperty(p => p.Shader2TessControl);
            set => SetProperty(p => p.Shader2TessControl = value);
        }

        public string Shader3TessEvaluation
        {
            get => GetProperty(p => p.Shader3TessEvaluation);
            set => SetProperty(p => p.Shader3TessEvaluation = value);
        }

        public string Shader4Geometry
        {
            get => GetProperty(p => p.Shader4Geometry);
            set => SetProperty(p => p.Shader4Geometry = value);
        }

        public string Shader5Fragment
        {
            get => GetProperty(p => p.Shader5Fragment);
            set => SetProperty(p => p.Shader5Fragment = value);
        }

        public string Shader6Compute
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

        internal IEnumerable<Trace> Traces { get; } = new List<Trace>();

        private T GetProperty<T>(Func<Trace, T> getProperty) where T: IEquatable<T>
        {
            if (Traces == null || !Traces.Any())
                return default;
            T first = getProperty(Traces.First());
            return Traces.FirstOrDefault(p => getProperty(p).Equals(first)) == null
                ? default
                : first;
        }

        private void SetProperty(Action<Trace> setProperty)
        {
            if (Traces == null || !Traces.Any())
                return;
            foreach (var trace in Traces)
                setProperty(trace);
        }
    }
}
