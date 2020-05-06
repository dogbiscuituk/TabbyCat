namespace TabbyCat.Tests
{
    using NUnit.Framework;
    using System;
    using Types;
    using Utils;

    [TestFixture]
    public class PropertyTests
    {
        [Test]
        public void TestPropertyAsString()
        {
            foreach (Property property in Enum.GetValues(typeof(Property)))
                Assert.DoesNotThrow(() => property.AsString(), $"Test failed for value Property.{property}");
        }
    }
}
