using NUnit.Framework;

namespace ForLoopToAggregation.Tests.Unit
{
    [TestFixture]
    public class ObjectOrientatedTests
    {
        [Test]
        public void Given_Something_When_Something_Then_Something()
        {
            Assert.AreEqual(1, ObjectOrientated.countingValleys(9, "UDDDUDUU"));
        }
    }
}
