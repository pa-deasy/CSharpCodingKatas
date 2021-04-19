using FluentAssertions;
using NUnit.Framework;

namespace ArbitraryLinkedListExamples.Tests.Unit
{
    [TestFixture]
    public class ArbitraryLinkedListTests
    {
        [Test]
        public void Given_LinkedList_When_Cloned_Then_CloneIsDeconnected()
        {
            var linkedList = new LinkedList();

            var first = new Node { Value = 1 };
            var second = new Node { Value = 2 };
            var third = new Node { Value = 3 };
            var fourth = new Node { Value = 4 };
            var fifth = new Node { Value = 5 };

            first.Arbitrary = third;
            second.Arbitrary = first;
            third.Arbitrary = fifth;
            fourth.Arbitrary = fifth;
            fifth.Arbitrary = second;

            linkedList.Head = first;
            linkedList.Head.Next = second;
            second.Next = third;
            third.Next = fourth;
            fourth.Next = fifth;

            var clonedList = linkedList.Clone();

            clonedList.NodeAtPosition(0).Value.Should().Be(1);
            clonedList.NodeAtPosition(1).Value.Should().Be(2);
            clonedList.NodeAtPosition(2).Value.Should().Be(3);
            clonedList.NodeAtPosition(3).Value.Should().Be(4);
            clonedList.NodeAtPosition(4).Value.Should().Be(5);

            clonedList.NodeAtPosition(0).Next.Value.Should().Be(2);
            clonedList.NodeAtPosition(1).Next.Value.Should().Be(3);
            clonedList.NodeAtPosition(2).Next.Value.Should().Be(4);
            clonedList.NodeAtPosition(3).Next.Value.Should().Be(5);
            clonedList.NodeAtPosition(4).Next.Should().BeNull();

            clonedList.NodeAtPosition(0).Arbitrary.Value.Should().Be(3);
            clonedList.NodeAtPosition(1).Arbitrary.Value.Should().Be(1);
            clonedList.NodeAtPosition(2).Arbitrary.Value.Should().Be(5);
            clonedList.NodeAtPosition(3).Arbitrary.Value.Should().Be(5);
            clonedList.NodeAtPosition(4).Arbitrary.Value.Should().Be(2);
        }
    }
}
