namespace TabbyCat.Tests.Models
{
    using NUnit.Framework;
    using OpenTK;
    using TabbyCat.Models;
    using TabbyCat.Types;

    [TestFixture]
    public class SurfaceTests
    {
        // Private fields

        private readonly Surface Surface = new Surface();

        // Public methods

        [Test]
        public void TestSurfacePattern() => Assert.AreEqual(Pattern.Quads, Surface.Pattern);

        [Test]
        public void TestSurfaceStripeCount() => Assert.AreEqual(new Vector3(30, 30, 0), Surface.StripeCount);
    }
}
