using NUnit.Framework;

namespace LongestIncreasingSubsequence.Tests.Unit
{
    [TestFixture]
    public class NumbersArrayOperationsTests
    {
        [Test]
        public void Given_NumbersSetA_When_LongestSubsequenceObtained_Then_IsAsExpected()
        {
            var numbers = new int[] { 3, 10, 2, 1, 20 };

            Assert.AreEqual(3, numbers.LongestSubsequence());
        }

        [Test]
        public void Given_NumbersSetB_When_LongestSubsequenceObtained_Then_IsAsExpected()
        {
            var numbers = new int[] { 3, 2 };

            Assert.AreEqual(1, numbers.LongestSubsequence());
        }

        [Test]
        public void Given_NumbersSetC_When_LongestSubsequenceObtained_Then_IsAsExpected()
        {
            var numbers = new int[] { 50, 3, 10, 7, 40, 80 };

            Assert.AreEqual(4, numbers.LongestSubsequence());
        }
    }
}
