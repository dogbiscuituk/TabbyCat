namespace Jmk.Common.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class StringUtilsTests
    {
        [Test]
        public void TestAmpersandEscapeUnescape()
        {
            string
                original = "&File",
                escaped = "&&File";
            Assert.AreEqual(expected: escaped, actual: original.AmpersandEscape());
            Assert.AreEqual(expected: original, actual: escaped.AmpersandUnescape());
        }

        [Test]
        public void TestFindFirstTokenLine()
        {
            const string basicProgram = "10 PRINT \"Hello World\"\n20 GOTO 10";
            int
                expected = 1,
                actual = basicProgram.FindFirstTokenLine("GOTO");
            Assert.AreEqual(expected, actual);
        }

        [Test, Sequential]
        public void TestGetCharCount(
            [Values(null, "", " ", "123", "222", "23\n123\n123\n123\n12")] string s,
            [Values(0, 0, 0, 1, 3, 5)] int expected) => Assert.AreEqual(expected, s.GetCharCount('2'));

        [Test, Sequential]
        public void TestGetCharPos(
            [Values(-1, 0, 1, 2, 3, 4)] int index,
            [Values(-1, 0, 2, 9, 13, -1)] int expected) => Assert.AreEqual(expected, "even as we speak".GetCharPos('e', index));

        [Test, Sequential]
        public void TestGetLineCount(
            [Values(null, "", " ", "123", "123\n456\n789", "\n123\n456\n789\n")] string s,
            [Values(0, 0, 1, 1, 3, 5)] int expected) => Assert.AreEqual(expected, s.GetLineCount());

        [Test, Sequential]
        public void TestGetLinePos(
            [Values(-1, 0, 1, 2, 3, 4)] int index,
            [Values(-1, 0, 1, 5, 9, -1)] int expected) => Assert.AreEqual(expected, "\n123\n456\n".GetLinePos(index));

        [Test, Sequential]
        public void TestGetOneLine(
            [Values(null, "", " ", "123", "123\n456\n789", "123\n234\n345\n456\n567")] string s,
            [Values(null, "", "", "", "456", "234")] string expected) => Assert.AreEqual(expected, s.GetLines(1, 1));

        [Test, Sequential]
        public void TestGetTwoLines(
            [Values(null, "", " ", "123", "123\n456\n789", "123\n234\n345\n456\n567")] string s,
            [Values(null, "", "", "", "456\n789", "234\n345")] string expected) => Assert.AreEqual(expected, s.GetLines(1, 2));

        [Test]
        public void TestIndentOutdent([Values("  ", "\t", "/* comment */")] string pad)
        {
            string
                original = "int\n  x=1,\n  y=2;",
                indented = $"{pad}int\n{pad}  x=1,\n{pad}  y=2;";
            Assert.AreEqual(expected: indented, actual: original.Indent(pad));
            Assert.AreEqual(expected: original, actual: indented.Outdent(pad));
        }
    }
}
