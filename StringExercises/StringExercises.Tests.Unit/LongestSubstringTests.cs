using NUnit.Framework;

namespace StringExercises.Tests.Unit
{
    [TestFixture]
    public class LongestSubstringTests
    {
        [Test]
        public void Given_Word_When_LongestSubstringWith2_Then_ReturnsExpected()
        {
            var word = "aaccbbaaaabcbcbcccccccccc";
            var expected = "bcbcbcccccccccc";

            Assert.AreEqual(expected, word.LongestSubstringForCharCountOf());
        }
    }
}
