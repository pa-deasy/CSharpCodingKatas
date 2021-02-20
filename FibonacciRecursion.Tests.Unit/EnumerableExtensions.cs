using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace FibonacciRecursion.Tests.Unit
{
    [TestFixture]
    public class EnumerableExtensions
    {
        [Test]
        public void Given_Enumerable_When_SecondLastRetrieved_Then_IsExpected()
        {
            var numbers = new List<int> { 1, 2, 3, 4 };
            numbers.SecondLast().Should().Be(3);
        }
    }
}
