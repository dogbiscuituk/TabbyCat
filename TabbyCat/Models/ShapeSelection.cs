﻿namespace TabbyCat.Models
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Types;

    public partial class ShapeSelection : Selection<Shape>
    {
        // Public properties

        public string Description => GetProperty(p => p.Description);

        public Vector3 Location => GetVector3(p => p.Location);

        public Vector3 Maximum => GetVector3(p => p.Maximum);

        public Vector3 Minimum => GetVector3(p => p.Minimum);

        public Vector3 Orientation => GetVector3(p => p.Orientation);

        public Pattern Pattern => (Pattern)GetProperty(p => (int)p.Pattern);

        public Vector3 Scale => GetVector3(p => p.Scale);

        public Vector3i StripeCount => GetVector3i(p => p.StripeCount);

        public IEnumerable<Shape> Shapes => Items.OrderBy(p => p.Index);

        public bool? Visible => GetBool(p => p.Visible);

        // Public methods

        public IEnumerable<int> GetShapeIndices() => Items.Select(p => p.Index);

        // Private methods

        private Vector3 GetVector3(Func<Shape, Vector3> f) => new Vector3(
            GetProperty(p => f(p).X),
            GetProperty(p => f(p).Y),
            GetProperty(p => f(p).Z));

        private Vector3i GetVector3i(Func<Shape, Vector3i> f) => new Vector3i(
            GetProperty(p => f(p).X),
            GetProperty(p => f(p).Y),
            GetProperty(p => f(p).Z));
    }

    partial class ShapeSelection : Selection<Shape>, IScript
    {
        public string GetScript(ShaderType shaderType) => GetProperty(p => p.GetScript(shaderType)) ?? string.Empty;

        public void SetScript(ShaderType shaderType, string value) => SetProperty(p => p.SetScript(shaderType, value));
    }
}
