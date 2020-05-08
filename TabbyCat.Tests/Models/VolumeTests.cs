namespace TabbyCat.Tests.Models
{
    using NUnit.Framework;
    using OpenTK;
    using TabbyCat.Models;
    using TabbyCat.Types;

    [TestFixture]
    public class VolumeTests
    {
        // Private fields

        private readonly Volume Volume = new Volume();

        // Public methods

        [Test]
        public void TestVolumePattern() => Assert.AreEqual(Pattern.Quads, Volume.Pattern);

        [Test]
        public void TestVolumeStripeCount() => Assert.AreEqual(new Vector3(10, 10, 10), Volume.StripeCount);
    }
}
