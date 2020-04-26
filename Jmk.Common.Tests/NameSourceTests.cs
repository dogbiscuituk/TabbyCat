namespace Jmk.Common.Tests
{
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class NameSourceTests
    {
        [Test, Sequential]
        public void TestNames(
            [Values(0, 26 - 1, 26, 2 * 26 - 1, 2 * 26,
            (26 + 1) * 26 - 1, // 701 = "ZZ"
            (26 + 1) * 26, // 702 = "AAA"
            ((26 + 1) * 26 + 1) * 26, // 18,278 = "AAAA"
            (((26 + 1) * 26 + 1) * 26 + 1) * 26 // 475,254 = "AAAAA"
            )]int index,
            [Values("A", "Z", "AA", "AZ", "BA", "ZZ", "AAA", "AAAA", "AAAAA"
            )]string expected) =>
            Assert.AreEqual(expected, NameSource.Names.Skip(index).First());
    }
}
