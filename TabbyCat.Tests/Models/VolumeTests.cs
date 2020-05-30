namespace TabbyCat.Tests.Models
{
    using NUnit.Framework;
    using Properties;
    using TabbyCat.Models;
    using Types;

    [TestFixture]
    public class VolumeTests
    {
        // Private fields

        private readonly Volume _volume = new Volume();

        // Public methods

        [Test]
        public void TestVolumeDescription() => Assert.AreEqual(Resources.Property_Volume, _volume.Description);

        [Test]
        public void TestVolumePattern() => Assert.AreEqual(Pattern.Quads, _volume.Pattern);

        [Test]
        public void TestVolumeStripeCount() =>Assert.AreEqual(new Vector3i(10, 10, 10), _volume.StripeCount);
    }
}
