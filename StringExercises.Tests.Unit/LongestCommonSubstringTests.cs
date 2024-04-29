using NUnit.Framework;

namespace StringExercises.Tests.Unit
{
    [TestFixture]
    public class LongestCommonSubstringTests
    {
        [TestCase("ABCDGH", "AEDFHR", 3)]
        [TestCase("GXTXAYB", "AGGTAB", 4)]
        public void Given_TwoStrings_When_ContainingCommonSubstring_Then_ReturnsLongest(string first, string second, int expected)
        {
            Assert.AreEqual(expected, first.LongestCommonSubstringWith(second));
        }
    }
}
