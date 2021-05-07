using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListExamples.Tests.Unit
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void Given_LinkedList_When_NodesAdded_Then_LinkedSuccessfully()
        {
            var linkedList = new LinkedList();

            linkedList.Head = new Node(1);
            var second = new Node(2);
            var third = new Node(3);

            linkedList.Head.Next = second;
            second.Next = third;

            linkedList.Head.Value.Should().Be(1);
            linkedList.Head.Next.Value.Should().Be(2);
            linkedList.Head.Next.Next.Value.Should().Be(3);
        }

        [Test]
        public void Given_LinkedList_When_RetrievedFromPosition_Then_ExpectedNode()
        {
            var linkedList = new LinkedList();

            var first = new Node(1);
            var second = new Node(10);
            var third = new Node(30);
            var fourth = new Node(14);

            linkedList.Head = first;
            linkedList.Head.Next = second;
            second.Next = third;
            third.Next = fourth;

            linkedList.NodeAtPosition(2).Value.Should().Be(30);
        }

        [Test]
        public void Given_LinkedList_When_NewNodeAdded_Then_PlacesToFrontSuccessfully()
        {
            var linkedList = new LinkedList();

            var first = new Node(1);
            var second = new Node(10);

            linkedList.Head = first;
            linkedList.Head.Next = second;

            linkedList.Push(new Node(9));

            linkedList.NodeAtPosition(0).Value.Should().Be(9);
            linkedList.NodeAtPosition(1).Value.Should().Be(1);
        }

        [Test]
        public void Given_LinkedList_When_NodeExists_Then_True()
        {
            var linkedList = new LinkedList();

            var first = new Node(1);
            var second = new Node(10);

            linkedList.Head = first;
            linkedList.Head.Next = second;

            linkedList.ValueExists(1).Should().BeTrue();
        }

        [Test]
        public void Given_LinkedList_When_NodeDoesNotExist_Then_False()
        {
            var linkedList = new LinkedList();

            var first = new Node(1);
            var second = new Node(10);

            linkedList.Head = first;
            linkedList.Head.Next = second;

            linkedList.ValueExists(4).Should().BeFalse();
        }

        [Test]
        public void Given_LinkedList_When_PairWiseSwapPerformed_Then_NodeValuesAsExpected()
        {
            var linkedList = new LinkedList();

            var first = new Node(1);
            var second = new Node(2);
            var third = new Node(3);
            var fourth = new Node(4);
            var fifth = new Node(5);

            linkedList.Head = first;
            linkedList.Head.Next = second;
            second.Next = third;
            third.Next = fourth;
            fourth.Next = fifth;

            linkedList.PairWiseSwap();

            linkedList.NodeAtPosition(0).Value.Should().Be(2);
            linkedList.NodeAtPosition(1).Value.Should().Be(1);
            linkedList.NodeAtPosition(2).Value.Should().Be(4);
            linkedList.NodeAtPosition(3).Value.Should().Be(3);
            linkedList.NodeAtPosition(4).Value.Should().Be(5);
        }

        [Test]
        public void Given_LinkedList_When_LastNodeIsMovedToFront_Then_FirstAndLastAreAsExpected()
        {
            var linkedList = new LinkedList();

            var first = new Node(1);
            var second = new Node(2);
            var third = new Node(3);
            var fourth = new Node(4);
            var fifth = new Node(5);

            linkedList.Head = first;
            linkedList.Head.Next = second;
            second.Next = third;
            third.Next = fourth;
            fourth.Next = fifth;

            linkedList.MoveLastNodeToFront();

            linkedList.NodeAtPosition(0).Value.Should().Be(5);
            linkedList.NodeAtPosition(1).Value.Should().Be(1);
            linkedList.NodeAtPosition(4).Value.Should().Be(4);
        }

        [Test]
        public void Given_LinkedList_When_Reversed_Then_NodeValuesAsExpected()
        {
            var linkedList = new LinkedList();

            var first = new Node(1);
            var second = new Node(2);
            var third = new Node(3);
            var fourth = new Node(4);
            var fifth = new Node(5);

            linkedList.Head = first;
            linkedList.Head.Next = second;
            second.Next = third;
            third.Next = fourth;
            fourth.Next = fifth;

            linkedList.Reverse();
            linkedList.NodeAtPosition(0).Value.Should().Be(5);
            linkedList.NodeAtPosition(1).Value.Should().Be(4);
            linkedList.NodeAtPosition(2).Value.Should().Be(3);
            linkedList.NodeAtPosition(3).Value.Should().Be(2);
            linkedList.NodeAtPosition(4).Value.Should().Be(1);
        }

        [Test]
        public void Given_LinkedList_When_Popped_Then_ValueAsExpected()
        {
            var linkedList = new LinkedList();

            linkedList.Push(new Node(2));
            linkedList.Push(new Node(4));
            linkedList.Push(new Node(5));
            linkedList.Pop().Value.Should().Be(5);
            linkedList.Push(new Node(9));
            linkedList.Pop().Value.Should().Be(9);
            linkedList.NodeAtPosition(1).Value.Should().Be(2);
        }

        [Test]
        public void Given_LinkedList_When_LoopExists_Then_ReturnsTrue()
        {
            var linkedList = new LinkedList();

            var first = new Node(1);
            var second = new Node(2);
            var third = new Node(3);
            var fourth = new Node(4);
            var fifth = new Node(5);

            linkedList.Head = first;
            linkedList.Head.Next = second;
            second.Next = third;
            third.Next = fourth;
            fourth.Next = fifth;
            fifth.Next = second;

            linkedList.LoopExists().Should().BeTrue();
        }

        [Test]
        public void Given_LinkedList_When_LoopDoesNotExist_Then_ReturnsFalse()
        {
            var linkedList = new LinkedList();

            var first = new Node(1);
            var second = new Node(2);
            var third = new Node(3);
            var fourth = new Node(4);
            var fifth = new Node(5);

            linkedList.Head = first;
            linkedList.Head.Next = second;
            second.Next = third;
            third.Next = fourth;
            fourth.Next = fifth;

            linkedList.LoopExists().Should().BeFalse();
        }
    }
}
