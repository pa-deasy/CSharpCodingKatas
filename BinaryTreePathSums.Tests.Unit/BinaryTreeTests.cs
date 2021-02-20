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
        public void Given_BinaryTree_When_OnePathSumsToNumber_Then_RootPathIsFound()
        {
            var paths = TestBinaryTreeA.PathsFromRootSummingTo(8);

            paths.Single()[0].Should().Be(1);
            paths.Single()[1].Should().Be(3);
            paths.Single()[2].Should().Be(4);
        }

        [Test]
        public void Given_BinaryTree_WhenTwoPathsSumsToNumber_Then_RootPathsAreFound()
        {
            var paths = TestBinaryTreeB.PathsFromRootSummingTo(38);

            paths.Count.Should().Be(2);

            paths.First()[0].Should().Be(10);
            paths.First()[1].Should().Be(28);

            paths.Last()[0].Should().Be(10);
            paths.Last()[1].Should().Be(13);
            paths.Last()[2].Should().Be(15);
        }

        [Test]
        public void Given_BinaryTree_WhenManyPathsSumToNumber_ThenAllPathsAreFound()
        {
            var paths = TestBinaryTreeC.AllPathsSummingTo(5);

            paths.Count.Should().Be(8);

            paths[0].Should().Match(p => p.ToArray()[0] == 1 && p.ToArray()[1] == 3 && p.ToArray()[2] == 1);
            paths[1].Should().Match(p => p.ToArray()[0] == 1 && p.ToArray()[1] == -1 && p.ToArray()[2] == 4 && p.ToArray()[3] == 1);
            paths[2].Should().Match(p => p.ToArray()[0] == 1 && p.ToArray()[1] == -1 && p.ToArray()[2] == 5);
            paths[3].Should().Match(p => p.ToArray()[0] == 3 && p.ToArray()[1] == 2);
            paths[4].Should().Match(p => p.ToArray()[0] == 3 && p.ToArray()[1] == 1 && p.ToArray()[2] == 1);
            paths[5].Should().Match(p => p.ToArray()[0] == -1 && p.ToArray()[1] == 4 && p.ToArray()[2] == 2);
            paths[6].Should().Match(p => p.ToArray()[0] == 4 && p.ToArray()[1] == 1);
            paths[7].Should().Match(p => p.ToArray()[0] == 5);
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
        private BinaryTree TestBinaryTreeC =>
            new BinaryTree(
                                      new Node(1,
                       new Node(3,
            new Node(2),     new Node(1, 
                         new Node(1), null)),                  new Node(-1, 
                                                      new Node(4,
                                             new Node(1),   new Node(2)),      new Node(5,
                                                                           null,     new Node(6)))));
    }
}
