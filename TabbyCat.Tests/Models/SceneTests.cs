namespace TabbyCat.Tests.Models
{
    using NUnit.Framework;
    using System.Drawing;
    using TabbyCat.Models;
    using TabbyCat.Properties;
    using TabbyCat.Types;

    [TestFixture]
    public class SceneTests
    {
        private readonly Scene Scene = new Scene();

        // Public methods

        [Test]
        public void TestSceneBackgroundColour() => Assert.AreEqual(Color.White, Scene.BackgroundColour);

        [Test]
        public void TestSceneCamera() => Assert.AreEqual(Camera.Default, Scene.Camera);

        [Test]
        public void TestSceneGLTargetVersion() => Assert.AreEqual("330", Scene.GLTargetVersion);

        [Test]
        public void TestSceneGPULog() => Assert.AreEqual(string.Empty, Scene.GPULog);

        [Test]
        public void TestSceneGPUStatus() => Assert.AreEqual(GPUStatus.None, Scene.GPUStatus);

        [Test]
        public void TestSceneProjection() => Assert.AreEqual(Projection.Default, Scene.Projection);

        [Test]
        public void TestSceneSignals() => Assert.AreEqual(0, Scene.Signals.Count);

        [Test]
        public void TestSceneTargetFPS() => Assert.AreEqual(60, Scene.TargetFPS);

        [Test]
        public void TestSceneTitle() => Assert.AreEqual(string.Empty, Scene.Title);

        [Test]
        public void TestSceneTraces() => Assert.AreEqual(0, Scene.Traces.Count);

        [Test]
        public void TestSceneVSync() => Assert.AreEqual(false, Scene.VSync);

        // Shaders

        [Test]
        public void TestSceneVertexShader() => Assert.AreEqual(Resources.Scene_VertexShader, Scene.VertexShader);

        [Test]
        public void TestSceneTessControlShader() => Assert.AreEqual(Resources.Scene_TessControlShader, Scene.TessControlShader);

        [Test]
        public void TestSceneTessEvaluationShader() => Assert.AreEqual(Resources.Scene_TessEvaluationShader, Scene.TessEvaluationShader);

        [Test]
        public void TestSceneGeometryShader() => Assert.AreEqual(Resources.Scene_GeometryShader, Scene.GeometryShader);

        [Test]
        public void TestSceneFragmentShader() => Assert.AreEqual(Resources.Scene_FragmentShader, Scene.FragmentShader);

        [Test]
        public void TestSceneComputeShader() => Assert.AreEqual(Resources.Scene_ComputeShader, Scene.ComputeShader);
    }
}
