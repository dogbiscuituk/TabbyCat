namespace TabbyCat.Tests.Models
{
    using NUnit.Framework;
    using OpenTK;
    using TabbyCat.Models;
    using TabbyCat.Properties;
    using TabbyCat.Types;

    [TestFixture]
    public class TraceTests
    {
        // Private fields

        private readonly Trace Trace = new Trace();

        // Public methods

        [Test]
        public void TestTraceDescription() => Assert.AreEqual(string.Empty, Trace.Description);

        [Test]
        public void TestTraceIndex() => Assert.AreEqual(-1, Trace.Index);

        [Test]
        public void TestTraceLocation() => Assert.AreEqual(Vector3.Zero, Trace.Location);

        [Test]
        public void TestTraceMaximum() => Assert.AreEqual(Vector3.Zero, Trace.Maximum);

        [Test]
        public void TestTraceMinimum() => Assert.AreEqual(Vector3.Zero, Trace.Minimum);

        [Test]
        public void TestTraceOrientation() => Assert.AreEqual(Vector3.Zero, Trace.Orientation);

        [Test]
        public void TestTracePattern() => Assert.AreEqual(Pattern.Fill, Trace.Pattern);

        [Test]
        public void TestTraceScale() => Assert.AreEqual(Vector3.One, Trace.Scale);

        [Test]
        public void TestTraceStripeCount() => Assert.AreEqual(new Vector3(100, 100, 0), Trace.StripeCount);

        [Test]
        public void TestTraceVisible() => Assert.AreEqual(true, Trace.Visible);

        // Shaders

        [Test]
        public void TestTraceVertexShader() => Assert.AreEqual(Resources.Trace_VertexShader, Trace.VertexShader);

        [Test]
        public void TestTraceTessControlShader() => Assert.AreEqual(Resources.Trace_TessControlShader, Trace.TessControlShader);

        [Test]
        public void TestTraceTessEvaluationShader() => Assert.AreEqual(Resources.Trace_TessEvaluationShader, Trace.TessEvaluationShader);

        [Test]
        public void TestTraceGeometryShader() => Assert.AreEqual(Resources.Trace_GeometryShader, Trace.GeometryShader);

        [Test]
        public void TestTraceFragmentShader() => Assert.AreEqual(Resources.Trace_FragmentShader, Trace.FragmentShader);

        [Test]
        public void TestTraceComputeShader() => Assert.AreEqual(Resources.Trace_ComputeShader, Trace.ComputeShader);
    }
}
