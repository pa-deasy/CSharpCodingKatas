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

        [TestCase("Geeks", 1)]
        [TestCase("abaab", 3)]
        [TestCase("abbaeae", 4)]
        public void Given_Word_When_PalindromesExist_Then_ReturnsCountOfPalindrome(string word, int palindromeCount)
        {
            word.PalindromeCount().Should().Be(palindromeCount);
        }
    }
}
