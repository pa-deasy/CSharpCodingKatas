using FluentAssertions;
using NUnit.Framework;

namespace RecursiveSums.Tests.Unit
{
    [TestFixture]
    public class ArrayExtensionsTests
    {
        [Test]
        public void Given_IntArray_When_Summed_Then_ReturnsSum()
        {
            var numbers = new int[] { 2, 4, 6 };

            numbers.Sum().Should().Be(12);
        }

        [Test]
        public void Given_CharArray_When_Counted_Then_ReturnsCount()
        {
            var chars = new char[] { 'a', 'b', 'c', 'd' };

            chars.Count().Should().Be(4);
        }

        [Test]
        public void Given_IntArray_When_MaxSought_Then_ReturnsMax()
        {
            var numbers = new int[] { 5, 9, 56, 1, 75, 4 };

            numbers.Max().Should().Be(75);
        }
    }
}
