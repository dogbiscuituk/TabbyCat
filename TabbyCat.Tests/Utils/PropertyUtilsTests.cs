namespace TabbyCat.Tests.Utils
{
    using NUnit.Framework;
    using System;
    using TabbyCat.Types;
    using TabbyCat.Utils;

    [TestFixture]
    public class PropertyUtilsTests
    {
        [Test]
        public void TestPropertyAsString()
        {
            foreach (Property property in Enum.GetValues(typeof(Property)))
                Assert.DoesNotThrow(() => property.AsString(), $"Test failed for value Property.{property}");
        }
    }
}
