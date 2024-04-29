using FluentAssertions;
using LowestCommonAncestor;
using NUnit.Framework;
using System;

namespace LowestCommonAncestorTests
{
    [TestFixture]
    public class BinaryTreeExtensionsTests
    {
        [TestCase(10, 14, 12)]
        [TestCase(8, 14, 8)]
        [TestCase(10, 22, 20)]
        public void Given_BinarySearchTree_When_TwoNodesExist_Then_ReturnsLca(int node1, int node2, int lca)
        {
            TestBinarySearchTree.BstLca(node1, node2).Value.Should().Be(lca);
        }

        [Test]
        public void Given_BinaryTree_When_TwoNodesExist_Then_ReturnsLca()
        {
            TestBinaryTree.Lca(9, 14).Value.Should().Be(8);
        }

        [TestCase(1, 14)]
        [TestCase(13, 14)]
        [TestCase(90, 22)]
        public void Given_BinaryTree_When_LeftNodeDoesNotExist_Then_ThrowsException(int node1, int node2)
        {
            Func<Node> lca = () => TestBinarySearchTree.BstLca(node1, node2);

            lca.Should().Throw<ApplicationException>()
                .Where(a => a.Message.Contains(node1.ToString()));
        }

        [TestCase(10, 1)]
        [TestCase(8, 13)]
        [TestCase(10, 90)]
        public void Given_BinaryTree_When_RightNodeDoesNotExist_Then_ThrowsException(int node1, int node2)
        {
            Func<Node> lca = () => TestBinarySearchTree.BstLca(node1, node2);

            lca.Should().Throw<ApplicationException>()
                .Where(a => a.Message.Contains(node2.ToString()));
        }

        private static BinaryTree TestBinarySearchTree =>
            new BinaryTree(
                                                             new Node(20,
                           left: new Node(8, 
        left: new Node(4),              right: new Node(12, 
                               left: new Node(10), right: new Node(14))), 
                                                                                                   right: new Node(22)));

        private static BinaryTree TestBinaryTree =>
            new BinaryTree(
                                                             new Node(4,
                             left: new Node(8,
        left: new Node(9),             right: new Node(12,
                               left: new Node(30), right: new Node(14))),
                                                                                                   right: new Node(22)));
    }
}
