using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace RatInAMazeAllPossibleDirections.Tests.Unit
{
    [TestFixture]
    public class ListExtensionsTests
    {
        [Test]
        public void Given_ListOfListOfChars_When_NewCharListAdded_Then_NewListOfListReturnedWithAdditionalChars()
        {
            var originalList = new List<List<char>>
            {
                new List<char>{ 'U', 'U', 'U'},
                new List<char>{ 'D', 'D', 'D'}
            };

            var newList = originalList.With(new List<char> { 'L', 'L', 'L' });

            originalList.Count.Should().Be(2);
            newList.Count.Should().Be(3);
            newList.Last().Should().Match(c => c.First() == 'L');
        }
    }
}
