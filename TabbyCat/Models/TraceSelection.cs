namespace TabbyCat.Models
{
    using Jmk.Common;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Types;

    public partial class TraceSelection : Selection<Trace>
    {
        // Public properties

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

        // Internal properties

        internal IEnumerable<Trace> Traces => Items.OrderBy(p => p.Index);

        internal IEnumerable<int> GetTraceIndices() => Items.Select(p => p.Index);

        // Private methods

        private Vector3 GetVector3(Func<Trace, Vector3> f) => new Vector3(
GetProperty(p => f(p).X),
GetProperty(p => f(p).Y),
GetProperty(p => f(p).Z));
    }

    public partial class TraceSelection : IScript
    {
        public string GetScript(ShaderType shaderType) => GetProperty(p => p.GetScript(shaderType)) ?? string.Empty;

        public void SetScript(ShaderType shaderType, string value) => SetProperty(p => p.SetScript(shaderType, value));
    }
}