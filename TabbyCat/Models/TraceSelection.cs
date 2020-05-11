namespace TabbyCat.Models
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Types;

    public class TraceSelection : Selection<Trace>, IScript
    {
        // Public properties

        public string Description => GetProperty(p => p.Description);

        public Vector3 Location => GetVector3(p => p.Location);

        public Vector3 Maximum => GetVector3(p => p.Maximum);

        public Vector3 Minimum => GetVector3(p => p.Minimum);

        public Vector3 Orientation => GetVector3(p => p.Orientation);

        public Pattern Pattern => (Pattern)GetProperty(p => (int)p.Pattern);

        public Vector3 Scale => GetVector3(p => p.Scale);

        public Vector3 StripeCount => GetVector3(p => p.StripeCount);

        public IEnumerable<Trace> Traces => Items.OrderBy(p => p.Index);

        public bool? Visible => GetBool(p => p.Visible);

        // Public methods

        public string GetScript(ShaderType shaderType) => GetProperty(p => p.GetScript(shaderType)) ?? string.Empty;

        public IEnumerable<int> GetTraceIndices() => Items.Select(p => p.Index);

        public void SetScript(ShaderType shaderType, string value) => SetProperty(p => p.SetScript(shaderType, value));

        // Private methods

        private Vector3 GetVector3(Func<Trace, Vector3> f) => new Vector3(
            GetProperty(p => f(p).X),
            GetProperty(p => f(p).Y),
            GetProperty(p => f(p).Z));
    }
}
