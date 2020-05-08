namespace TabbyCat.Tests.Models
{
    using NUnit.Framework;
    using OpenTK;
    using TabbyCat.Models;
    using TabbyCat.Types;

    [TestFixture]
    public class CurveTests
    {
        // Private fields

        private readonly Curve Curve = new Curve();

        // Public methods

        [Test]
        public void TestCurvePattern() => Assert.AreEqual(Pattern.Lines, Curve.Pattern);

        [Test]
        public void TestCurveStripeCount() => Assert.AreEqual(new Vector3(1000, 0, 0), Curve.StripeCount);
    }
}
