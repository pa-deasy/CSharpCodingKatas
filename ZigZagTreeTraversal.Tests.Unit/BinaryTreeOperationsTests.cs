using FluentAssertions;
using NUnit.Framework;

namespace ZigZagTreeTraversal.Tests.Unit
{
    [TestFixture]
    public class BinaryTreeOperationsTests
    {
        [Test]
        public void Given_BinaryTree_When_ZigZag_Then_ReturnsListOrderedAsExpected()
        {
            var zigZagOrder = TestBinaryTreeA.ZigZagOrder();

            zigZagOrder.Count.Should().Be(7);

            zigZagOrder[0].Should().Be(1);
            zigZagOrder[1].Should().Be(3);
            zigZagOrder[2].Should().Be(2);
            zigZagOrder[3].Should().Be(7);
            zigZagOrder[4].Should().Be(6);
            zigZagOrder[5].Should().Be(5);
            zigZagOrder[6].Should().Be(4);
        }

        private BinaryTree TestBinaryTreeA =>
            new BinaryTree(
                            new Node(1,
                   new Node(2,
            new Node(7), new Node(6)),
                                           new Node(3,
                                      new Node(5), new Node(4))));
    }
}
