namespace TabbyCat.Tests.Models
{
    using NUnit.Framework;
    using OpenTK;
    using Properties;
    using TabbyCat.Models;
    using Types;

    [TestFixture]
    public class ShapeTests
    {
        // Private fields

        private readonly Shape _shape = new Shape();

        // Public methods

        [Test]
        public void TestShapeDescription() => Assert.AreEqual(string.Empty, _shape.Description);

        [Test]
        public void TestShapeIndex() => Assert.AreEqual(-1, _shape.Index);

        [Test]
        public void TestShapeLocation() => Assert.AreEqual(Vector3.Zero, _shape.Location);

        [Test]
        public void TestShapeMaximum() => Assert.AreEqual(Vector3.Zero, _shape.Maximum);

        [Test]
        public void TestShapeMinimum() => Assert.AreEqual(Vector3.Zero, _shape.Minimum);

        [Test]
        public void TestShapeOrientation() => Assert.AreEqual(Vector3.Zero, _shape.Orientation);

        [Test]
        public void TestShapePattern() => Assert.AreEqual(Pattern.Fill, _shape.Pattern);

        [Test]
        public void TestShapeScale() => Assert.AreEqual(Vector3.One, _shape.Scale);

        [Test]
        public void TestShapeStripeCount() => Assert.AreEqual(new Vector3i(100, 100, 0), _shape.StripeCount);

        [Test]
        public void TestShapeVisible() => Assert.AreEqual(true, _shape.Visible);

        // Shaders

        [Test]
        public void TestShapeVertexShader() => Assert.AreEqual(Resources.Shape_VertexShader, _shape.VertexShader);

        [Test]
        public void TestShapeTessControlShader() => Assert.AreEqual(Resources.Shape_TessControlShader, _shape.TessControlShader);

        [Test]
        public void TestShapeTessEvaluationShader() => Assert.AreEqual(Resources.Shape_TessEvaluationShader, _shape.TessEvaluationShader);

        [Test]
        public void TestShapeGeometryShader() => Assert.AreEqual(Resources.Shape_GeometryShader, _shape.GeometryShader);

        [Test]
        public void TestShapeFragmentShader() => Assert.AreEqual(Resources.Shape_FragmentShader, _shape.FragmentShader);

        [Test]
        public void TestShapeComputeShader() => Assert.AreEqual(Resources.Shape_ComputeShader, _shape.ComputeShader);
    }
}
