namespace TabbyCat.Tests.Models
{
    using NUnit.Framework;
    using OpenTK;
    using Properties;
    using TabbyCat.Models;
    using Types;

    [TestFixture]
    public class CurveTests
    {
        // Private fields

        private readonly Curve _curve = new Curve();

        // Public methods

        [Test]
        public void TestCurveDescription() => Assert.AreEqual(Resources.Property_Curve, _curve.Description);

        [Test]
        public void TestCurvePattern() => Assert.AreEqual(Pattern.Lines, _curve.Pattern);

        [Test]
        public void TestCurveStripeCount() => Assert.AreEqual(new Vector3(1000, 0, 0), _curve.StripeCount);
    }
}
