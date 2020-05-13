namespace TabbyCat.Tests.Models
{
    using NUnit.Framework;
    using OpenTK;
    using TabbyCat.Models;
    using TabbyCat.Properties;
    using TabbyCat.Types;

    [TestFixture]
    public class ShapeTests
    {
        // Private fields

        private readonly Shape Shape = new Shape();

        // Public methods

        [Test]
        public void TestShapeDescription() => Assert.AreEqual(string.Empty, Shape.Description);

        [Test]
        public void TestShapeIndex() => Assert.AreEqual(-1, Shape.Index);

        [Test]
        public void TestShapeLocation() => Assert.AreEqual(Vector3.Zero, Shape.Location);

        [Test]
        public void TestShapeMaximum() => Assert.AreEqual(Vector3.Zero, Shape.Maximum);

        [Test]
        public void TestShapeMinimum() => Assert.AreEqual(Vector3.Zero, Shape.Minimum);

        [Test]
        public void TestShapeOrientation() => Assert.AreEqual(Vector3.Zero, Shape.Orientation);

        [Test]
        public void TestShapePattern() => Assert.AreEqual(Pattern.Fill, Shape.Pattern);

        [Test]
        public void TestShapeScale() => Assert.AreEqual(Vector3.One, Shape.Scale);

        [Test]
        public void TestShapeStripeCount() => Assert.AreEqual(new Vector3(100, 100, 0), Shape.StripeCount);

        [Test]
        public void TestShapeVisible() => Assert.AreEqual(true, Shape.Visible);

        // Shaders

        [Test]
        public void TestShapeVertexShader() => Assert.AreEqual(Resources.Shape_VertexShader, Shape.VertexShader);

        [Test]
        public void TestShapeTessControlShader() => Assert.AreEqual(Resources.Shape_TessControlShader, Shape.TessControlShader);

        [Test]
        public void TestShapeTessEvaluationShader() => Assert.AreEqual(Resources.Shape_TessEvaluationShader, Shape.TessEvaluationShader);

        [Test]
        public void TestShapeGeometryShader() => Assert.AreEqual(Resources.Shape_GeometryShader, Shape.GeometryShader);

        [Test]
        public void TestShapeFragmentShader() => Assert.AreEqual(Resources.Shape_FragmentShader, Shape.FragmentShader);

        [Test]
        public void TestShapeComputeShader() => Assert.AreEqual(Resources.Shape_ComputeShader, Shape.ComputeShader);
    }
}
