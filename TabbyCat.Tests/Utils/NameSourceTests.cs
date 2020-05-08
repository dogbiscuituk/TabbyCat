namespace TabbyCat.Tests.Utils
{
    using NUnit.Framework;
    using System.Linq;
    using TabbyCat.Utils;

    [TestFixture]
    public class NameSourceTests
    {
        private const int n = 26;

        [Test, Sequential]
        public void TestNames([Values(0 // 0 = "A"
            , n - 1 // 25 = "Z"
            , n // 26 = "AA"
            , 2 * n - 1 // 51 = "AZ"
            , 2 * n // 52 = "BA"
            , (n + 1) * n - 1 // 26^2 + 26 - 1 = 701 = "ZZ"
            , (n + 1) * n // 26^2 + 26 = 702 = "AAA"
            , ((n + 1) * n + 1) * n // 26^3 + 26^2 + 26 = 18,278 = "AAAA"
            // NB: ~500ms test case upcoming; comment out the next line if not worth it (see also "NB" below).
            , (((n + 1) * n + 1) * n + 1) * n // 26^4 + 26^3 + 26^2 + 26 = 475,254 = "AAAAA"
            )] int index,
            [Values("A"
            , "Z"
            , "AA"
            , "AZ"
            , "BA"
            , "ZZ"
            , "AAA"
            , "AAAA"
            // NB: ~500ms test case upcoming; comment out the next line if not worth it (see also "NB" above).
            , "AAAAA"
            )] string expected) => Assert.AreEqual(expected, NameSource.Names.Skip(index).First());
    }
}
