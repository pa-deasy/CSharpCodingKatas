using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalindromeChecker.Tests.Unit
{
    [TestFixture]
    public class EfficientPalindromeExtensionsTests
    {
        [TestCase("aa", 1)]
        [TestCase("aaa", 3)]
        [TestCase("abaab", 3)]
        [TestCase("abbaeae", 4)]
        [TestCase("geeks", 1)]
        public void Given_String_When_PalindromesExist_Then_ReturnsCorrectCount(string input, int expectedCount)
        {
            input.EfficientCountOfPalindromes().Should().Be(expectedCount);
        }
    }
}
