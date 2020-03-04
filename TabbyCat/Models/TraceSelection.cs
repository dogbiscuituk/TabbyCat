namespace TabbyCat.Models
{
    using OpenTK;
    using System.Collections.Generic;
    using System.Linq;
    using TabbyCat.Common.Types;

    public class TraceSelection : ITrace
    {
        public string Description
        {
            get => throw new System.NotImplementedException();
            set
            {
                if (Traces != null && Traces.Any())
                    foreach (var trace in Traces)
                        trace.Description = value;
            }
        }

        public Vector3d Location { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Vector3d Maximum { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Vector3d Minimum { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Vector3d Orientation { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Pattern Pattern { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Vector3d Scale { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public string Shader1Vertex { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public string Shader2TessControl { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public string Shader3TessEvaluation { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public string Shader4Geometry { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public string Shader5Fragment { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public string Shader6Compute { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Vector3 StripCount { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public bool? Visible { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        private IEnumerable<Trace> Traces;
    }
}
