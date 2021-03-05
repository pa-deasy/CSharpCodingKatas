using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ZigZagTreeTraversal.Tests.Unit
{
    [TestFixture]
    public class ListExtensionTests
    {
        [Test]
        public void Given_List_When_RangeOfNewListAdded_Then_OriginalListIntactAndNewListProduced()
        {
            var apples = new List<string> { "apple", "apple", "apple" };
            var oranges = new List<string> { "orange", "orange", "orange" };

            var applesAndOranges = apples.WithRange(oranges);

            apples.Count.Should().Be(3);
            apples.First().Should().Be("apple");
            oranges.Count.Should().Be(3);
            oranges.First().Should().Be("orange");
            applesAndOranges.Count.Should().Be(6);
            applesAndOranges.First().Should().Be("apple");
            applesAndOranges.Last().Should().Be("orange");
        }
    }
}
