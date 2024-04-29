using NUnit.Framework;

namespace TwoSumThreeSumProblems.Tests.Unit
{
    [TestFixture]
    public class PairsLessThanOperationsTests
    {
        [Test]
        public void Given_SimpleSortedArray_When_CountOfPairsLessThanTargetSought_Then_ReturnsAsExpected()
        {
            var numbers = new int[] { 1, 2, 3, 4, 6, 7, 8 };
            Assert.AreEqual(5, numbers.CountOfPairsLessThan(7));
        }

        [Test]
        public void Given_SortedArray_When_CountOfPairsLessThanTargetSought_Then_ReturnsAsExpected()
        {
            var numbers = new int[] { 2, 4, 6, 8, 9 };
            Assert.AreEqual(7, numbers.CountOfPairsLessThan(14));
        }
    }
}
