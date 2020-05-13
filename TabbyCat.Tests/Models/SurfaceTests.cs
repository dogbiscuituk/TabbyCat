namespace TabbyCat.Tests.Models
{
    using NUnit.Framework;
    using OpenTK;
    using Properties;
    using TabbyCat.Models;
    using Types;

    [TestFixture]
    public class SurfaceTests
    {
        // Private fields

        private readonly Surface _surface = new Surface();

        // Public methods

        [Test]
        public void TestSurfaceDescription() => Assert.AreEqual(Resources.Property_Surface, _surface.Description);

        [Test]
        public void TestSurfacePattern() => Assert.AreEqual(Pattern.Quads, _surface.Pattern);

        [Test]
        public void TestSurfaceStripeCount() => Assert.AreEqual(new Vector3(30, 30, 0), _surface.StripeCount);
    }
}
