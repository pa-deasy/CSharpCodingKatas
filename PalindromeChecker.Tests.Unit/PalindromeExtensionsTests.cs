using FluentAssertions;
using NUnit.Framework;

namespace PalindromeChecker.Tests.Unit
{
    [TestFixture]
    public class PalindromeExtensionsTests
    {
        [TestCase("aba")]
        [TestCase("aa")]
        [TestCase("baab")]
        public void Given_String_When_IsAPalindrome_Then_ReturnsTrue(string input)
        {
            input.IsAPalindrome().Should().BeTrue();
        }

        [TestCase("iop")]
        [TestCase("na")]
        public void Given_String_When_IsNotAPalindrome_Then_ReturnsFalse(string input)
        {
            input.IsAPalindrome().Should().BeFalse();
        }

        [TestCase("aa", 1)]
        [TestCase("aaa", 3)]
        [TestCase("abaab", 3)]
        [TestCase("abbaeae", 4)]
        public void Given_String_When_PalindromesExist_Then_ReturnsCorrectCount(string input, int expectedCount)
        {
            input.CountOfPalindromes().Should().Be(expectedCount);
        }
    }
}
