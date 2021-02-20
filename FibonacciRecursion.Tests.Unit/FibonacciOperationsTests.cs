using NUnit.Framework;
using FluentAssertions;

namespace FibonacciRecursion.Tests.Unit
{
    [TestFixture]
    public class FibonacciOperationsTests
    {
        [TestCase(2, 1)]
        [TestCase(9, 34)]
        public void Given_SequenceLengthN_When_FibonacciTheoryApplied_Then_ReturnsListOfFibonacciElementsToN(int n, int fibonacciElement)
        {
            FibonacciOperations.SequenceUpTo(n).Should().Be(fibonacciElement);
        }
    }
}
