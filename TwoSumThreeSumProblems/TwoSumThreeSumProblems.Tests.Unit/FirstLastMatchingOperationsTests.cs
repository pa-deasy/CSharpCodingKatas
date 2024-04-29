using NUnit.Framework;

namespace TwoSumThreeSumProblems.Tests.Unit
{
    [TestFixture]
    public class FirstLastMatchingOperationsTests
    {
        [TestCase(7, 20, 4)]
        [TestCase(7, 68, 9)]
        [TestCase(5, 40, 8)]
        public void Given_SimpleNumberRange_When_MatchingFirstAndLastSought_Then_ReturnsCountOfMatches(int start, int end, int expected)
        {
            Assert.AreEqual(expected, FirstLastMatchingOperations.FirstLastMatchingInRange(start, end));
        }
    }
}
