using FluentAssertions;
using NUnit.Framework;

namespace PalindromeChecker.Tests.Unit
{
    [TestFixture]
    public class DynamicPalindromeExtensionsTests
    {
        [TestCase("forgeeksskeegfor", "geeksskeeg")]
        [TestCase("Geeks", "ee")]
        public void Given_Word_When_PalindromeExists_Then_ReturnsLongestPalindrome(string word, string expectedString)
        {
            word.LongestPalindrome().Should().Be(expectedString);
        }
    }
}
