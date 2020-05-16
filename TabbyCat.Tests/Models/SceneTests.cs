namespace TabbyCat.Tests.Models
{
    using NUnit.Framework;
    using Properties;
    using System.Drawing;
    using TabbyCat.Models;
    using Types;

    [TestFixture]
    public class SceneTests
    {
        // Private fields

        private readonly Scene _scene = new Scene();

        // Public methods

        [Test]
        public void TestSceneBackgroundColour() => Assert.AreEqual(Color.White, _scene.BackgroundColour);

        [Test]
        public void TestSceneCamera() => Assert.AreEqual(Camera.Default, _scene.Camera);

        [Test]
        public void TestSceneGLTargetVersion() => Assert.AreEqual("330", _scene.GLTargetVersion);

        [Test]
        public void TestSceneGPULog() => Assert.AreEqual(string.Empty, _scene.GPULog);

        [Test]
        public void TestSceneGPUStatus() => Assert.AreEqual(GPUStatus.None, _scene.GPUStatus);

        [Test]
        public void TestSceneProjection() => Assert.AreEqual(Projection.Default, _scene.Projection);

        [Test]
        public void TestSceneSignals() => Assert.AreEqual(0, _scene.Signals.Count);

        [Test]
        public void TestSceneTargetFPS() => Assert.AreEqual(60, _scene.TargetFPS);

        [Test]
        public void TestSceneTitle() => Assert.AreEqual(string.Empty, _scene.Title);

        [Test]
        public void TestSceneShapes() => Assert.AreEqual(0, _scene.Shapes.Count);

        [Test]
        public void TestSceneVSync() => Assert.AreEqual(false, _scene.VSync);

        // Shaders

        [Test]
        public void TestSceneVertexShader() => Assert.AreEqual(Resources.Scene_VertexShader, _scene.VertexShader);

        [Test]
        public void TestSceneTessControlShader() => Assert.AreEqual(Resources.Scene_TessControlShader, _scene.TessControlShader);

        [Test]
        public void TestSceneTessEvaluationShader() => Assert.AreEqual(Resources.Scene_TessEvaluationShader, _scene.TessEvaluationShader);

        [Test]
        public void TestSceneGeometryShader() => Assert.AreEqual(Resources.Scene_GeometryShader, _scene.GeometryShader);

        [Test]
        public void TestSceneFragmentShader() => Assert.AreEqual(Resources.Scene_FragmentShader, _scene.FragmentShader);

        [Test]
        public void TestSceneComputeShader() => Assert.AreEqual(Resources.Scene_ComputeShader, _scene.ComputeShader);
    }
}
