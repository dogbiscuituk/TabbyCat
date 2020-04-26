namespace Jmk.Common.Tests
{
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class NameSourceTests
    {
        [Test, Sequential]
        public void TestFirstName(
            [Values(0, 25, 26, 51, 52, 701, 702, 18277)]int index,
            [Values("A", "Z", "AA", "AZ", "BA", "ZZ", "AAA", "ZZZ")]string expected) =>
            Assert.AreEqual(expected, NameSource.Names.Skip(index).First());
    }
}
