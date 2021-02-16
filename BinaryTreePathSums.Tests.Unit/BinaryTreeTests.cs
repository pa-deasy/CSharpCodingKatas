using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BinaryTreePathSums.Tests.Unit
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [Test]
        public void Given_BinaryTree_When_OnePathSumsToNumber_Then_PathIsFound()
        {
            var paths = TestBinaryTreeA.PathsFromRootSummingTo(8);

            paths.Single()[0].Should().Be(1);
            paths.Single()[1].Should().Be(3);
            paths.Single()[2].Should().Be(4);
        }

        [Test]
        public void Given_BinaryTree_WhenTwoPathsSumsToNumber_Then_PathsAreFound()
        {
            var paths = TestBinaryTreeB.PathsFromRootSummingTo(38);

            paths.Count.Should().Be(2);

            paths.First()[0].Should().Be(10);
            paths.First()[1].Should().Be(28);

            paths.Last()[0].Should().Be(10);
            paths.Last()[1].Should().Be(13);
            paths.Last()[2].Should().Be(15);
        }

        private BinaryTree TestBinaryTreeA =>
            new BinaryTree(
                           new Node(1,
            new Node(20),             new Node(3,
                                  new Node(4, 
                          new Node(6), new Node(7)),        new Node(15, 
                                                      new Node(8), new Node(9)))));

        private BinaryTree TestBinaryTreeB =>
            new BinaryTree(
                           new Node(10,
            new Node(28),            new Node(13,
                               new Node(14,
                       new Node(21), new Node(22)),         new Node(15,
                                                      new Node(23), new Node(24)))));
    }
}
