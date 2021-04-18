using NUnit.Framework;

namespace BallArrangementProblem.Tests.Unit
{
    [TestFixture]
    public class BallsSortOperationsTests
    {
        [TestCase(1, 1, 0, 2)]
        [TestCase(1, 1, 1, 6)]
        [TestCase(2, 1, 1, 6)]
        public void Given_Balls_When_SortedCorrectly_Then_ReturnsCountOfPossibilities(int reds, int greens, int blues, int expectedCount)
        {
            Assert.AreEqual(expectedCount, BallsSortOperations.NumberOfArrangementsFor(reds, greens, blues));
        }
    }
}
