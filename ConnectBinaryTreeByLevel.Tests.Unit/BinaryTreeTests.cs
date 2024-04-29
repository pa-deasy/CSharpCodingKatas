using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectBinaryTreeByLevel.Tests.Unit
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [Test]
        public void Given_BinaryTree_When_NodesOfSameLevelSearched_Then_OrderedNodesReturned()
        {
            var binaryTree = TestBinaryTree;
            binaryTree.ConnectNodesByLevel();

            binaryTree.Root.NextRight.Should().BeNull();
            binaryTree.Root.Left.NextRight.Value.Should().Be(2);
            binaryTree.Root.Right.NextRight.Should().BeNull();
            binaryTree.Root.Left.Left.NextRight.Should().BeNull();
        }

        public static BinaryTree TestBinaryTree =>
            new BinaryTree(
                            new Node(10,
                    new Node(8,
               new Node(3, null, null), null),    new Node(2, null, null)));
    }
}
