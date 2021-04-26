using NUnit.Framework;

namespace IsBinarySearchTree.Tests.Unit
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [Test]
        public void Given_BinaryTree_When_IsSearchTree_Then_ReturnsTrue()
        {
            Assert.IsTrue(Bst.IsBst());
        }

        [Test]
        public void Given_BinaryTree_When_IsNotSearchTree_Then_ReturnsFalse()
        {
            Assert.IsFalse(NotBst.IsBst());
        }

        [Test]
        public void Given_BiggerBinaryTree_When_IsNotSearchTree_Then_ReturnsFalse()
        {
            Assert.IsFalse(BiggerNotBst.IsBst());
        }

        private static BinaryTree Bst =>
                        new BinaryTree(
                                          new Node(4,
                          new Node(2,
                    new Node(1), new Node(3)),      new Node(5)));

        private static BinaryTree NotBst =>
                        new BinaryTree(
                                          new Node(3,
                          new Node(2,
                    new Node(1), new Node(4)), new Node(5)));

        private static BinaryTree BiggerNotBst =>
                        new BinaryTree(
                                          new Node(10,
                          new Node(7,
                    new Node(3), new Node(8)),       new Node(15, 
                                               new Node(9), new Node(17))));
    }
}
