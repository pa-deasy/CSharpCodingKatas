using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ForLoopToAggregation.Tests.Unit
{
    [TestFixture]
    public class FunctionalTests
    {
        [Test]
        public void Given_Something_When_Something_Then_Something()
        {
            Assert.AreEqual(1, Functional.countingValleys(9, "UDDDUDUU"));
        }

        [Test]
        public void Given_NumList_When_Added_Then_ExpectedSum()
        {
            var numbersToSum = new List<int> { 1, 4, 5, 8 };

            var sum = numbersToSum.Aggregate(0, (sum, next) => Functional.Add(sum, next));

            Assert.AreEqual(18, sum);
        }
    }
}
