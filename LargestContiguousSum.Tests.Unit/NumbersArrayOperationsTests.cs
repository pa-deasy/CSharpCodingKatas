using NUnit.Framework;

namespace LargestContiguousSum.Tests.Unit
{
    [TestFixture]
    public class NumbersArrayOperationsTests
    {
        [Test]
        public void Given_NumbersSetA_When_LargestConiguousSumSought_Then_ReturnedSuccessfully()
        {
            var numbers = new int[] { -2, -3, 4, -1, -2, 1, 5, -3 };

            Assert.AreEqual(7, numbers.LargestContiguousSum());
        }

        [Test]
        public void Given_NumbersSetB_When_LargestConiguousSumSought_Then_ReturnedSuccessfully()
        {
            var numbers = new int[] { 1, 2, 3, -2, 5 };

            Assert.AreEqual(9, numbers.LargestContiguousSum());
        }

        [Test]
        public void Given_NumbersSetC_When_LargestConiguousSumSought_Then_ReturnedSuccessfully()
        {
            var numbers = new int[] { -1, -2, -3, -4 };

            Assert.AreEqual(-1, numbers.LargestContiguousSum());
        }
    }
}
