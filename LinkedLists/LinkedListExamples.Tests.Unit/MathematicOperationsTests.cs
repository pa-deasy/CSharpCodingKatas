using NUnit.Framework;

namespace LinkedListExamples.Tests.Unit
{
    [TestFixture]
    public class MathematicOperationsTests
    {
        [Test]
        public void Given_TwoLinkedLists_WhenAdded_Then_ProducesExpectedLinkedList()
        {
            var firstFirst = new Node(9);
            var firstSecond = new Node(2);
            var firstThird = new Node(1);
            firstFirst.Next = firstSecond;
            firstSecond.Next = firstThird;
            var firstLinkedList = new LinkedList { Head = firstFirst };

            var secondFirst = new Node(8);
            var secondSecond = new Node(5);
            var secondThird = new Node(9);
            secondFirst.Next = secondSecond;
            secondSecond.Next = secondThird;
            var secondLinkedList = new LinkedList { Head = secondFirst };

            var addedLinkedList = firstLinkedList.AddWith(secondLinkedList);

            Assert.AreEqual(1, addedLinkedList.Head.Value);
            Assert.AreEqual(7, addedLinkedList.Head.Next.Value);
            Assert.AreEqual(8, addedLinkedList.Head.Next.Next.Value);
            Assert.AreEqual(0, addedLinkedList.Head.Next.Next.Next.Value);
        }
    }
}
