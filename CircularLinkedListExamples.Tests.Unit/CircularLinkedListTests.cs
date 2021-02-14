using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircularLinkedListExamples.Tests.Unit
{
    [TestFixture]
    public class CircularLinkedListTests
    {
        [Test]
        public void Given_CircularLinkedList_When_PositionSearched_Then_ExpectedNodeReturned()
        {
            var circularLinkedList = new CircularLinkedList();

            var first = new Node(1);
            var second = new Node(2);
            var third = new Node(3);
            var fourth = new Node(4);

            circularLinkedList.Head = first;
            circularLinkedList.Head.Next = second;
            second.Next = third;
            third.Next = fourth;
            fourth.Next = circularLinkedList.Head;

            circularLinkedList.PositionAt(0).Value.Should().Be(1);
            circularLinkedList.PositionAt(3).Value.Should().Be(4);
            circularLinkedList.PositionAt(5).Should().BeNull();
        }

        [Test]
        public void Given_CircularLinkedList_When_LastNodeRetrieved_Then_ExpectedNode()
        {
            var circularLinkedList = new CircularLinkedList();

            var first = new Node(1);
            var second = new Node(2);
            var third = new Node(3);
            var fourth = new Node(4);

            circularLinkedList.Head = first;
            circularLinkedList.Head.Next = second;
            second.Next = third;
            third.Next = fourth;
            fourth.Next = circularLinkedList.Head;

            circularLinkedList.LastNode().Value.Should().Be(4);
        }

        [Test]
        public void Given_CircularLinkedListWithOneNode_When_LastNodeRetrieved_Then_ExpectedNode()
        {
            var circularLinkedList = new CircularLinkedList();

            var first = new Node(1);

            circularLinkedList.Head = first;
            circularLinkedList.Head.Next = circularLinkedList.Head;

            circularLinkedList.LastNode().Value.Should().Be(1);
        }

        [Test]
        public void Given_CircularList_When_NodesPushed_Then_PresentInListAsExpected()
        {
            var circularLinkedList = new CircularLinkedList();

            circularLinkedList.Push(new Node(3));
            circularLinkedList.Push(new Node(2));
            circularLinkedList.Push(new Node(1));

            circularLinkedList.PositionAt(0).Value.Should().Be(1);
            circularLinkedList.PositionAt(1).Value.Should().Be(2);
            circularLinkedList.PositionAt(2).Value.Should().Be(3);
        }

        [Test]
        public void Given_EmptyCircularList_When_SingleNodePushed_Then_ListIsAsExpected()
        {
            var circularLinkedList = new CircularLinkedList();

            circularLinkedList.Push(new Node(1));

            circularLinkedList.PositionAt(0).Value.Should().Be(1);
            circularLinkedList.PositionAt(1).Should().BeNull();
            circularLinkedList.LastNode().Value.Should().Be(1);
        }

        [Test]
        public void Given_CicularLinkedList_When_SecondLastNodeRetrieved_Then_AsExpected()
        {
            var circularLinkedList = new CircularLinkedList();

            circularLinkedList.Push(new Node(3));
            circularLinkedList.Push(new Node(2));
            circularLinkedList.Push(new Node(1));

            circularLinkedList.SecondLastNode().Value.Should().Be(2);
        }

        [Test]
        public void Given_CicularLinkedListWith2Node_When_SecondLastNodeRetrieved_Then_AsExpected()
        {
            var circularLinkedList = new CircularLinkedList();

            circularLinkedList.Push(new Node(2));
            circularLinkedList.Push(new Node(1));

            circularLinkedList.SecondLastNode().Value.Should().Be(1);
        }

        [Test]
        public void Given_CicularLinkedListWith1Node_When_SecondLastNodeRetrieved_Then_AsExpected()
        {
            var circularLinkedList = new CircularLinkedList();

            circularLinkedList.Push(new Node(1));

            circularLinkedList.SecondLastNode().Value.Should().Be(1);
        }

        [Test]
        public void Given_CircularLinkedList_When_FirstSwappedWithLast_Then_NodesAsExpected()
        {
            var circularLinkedList = new CircularLinkedList();

            circularLinkedList.Push(new Node(5));
            circularLinkedList.Push(new Node(4));
            circularLinkedList.Push(new Node(3));
            circularLinkedList.Push(new Node(2));
            circularLinkedList.Push(new Node(1));

            circularLinkedList.PositionAt(0).Value.Should().Be(1);
            circularLinkedList.PositionAt(4).Value.Should().Be(5);

            circularLinkedList.SwapFirstAndLast();

            circularLinkedList.PositionAt(0).Value.Should().Be(5);
            circularLinkedList.PositionAt(4).Value.Should().Be(1);
        }

        [Test]
        public void Given_CircularLinkedListWith2Node_When_FirstSwappedWithLast_Then_NodesAsExpected()
        {
            var circularLinkedList = new CircularLinkedList();

            circularLinkedList.Push(new Node(2));
            circularLinkedList.Push(new Node(1));

            circularLinkedList.PositionAt(0).Value.Should().Be(1);
            circularLinkedList.PositionAt(1).Value.Should().Be(2);

            circularLinkedList.SwapFirstAndLast();

            circularLinkedList.PositionAt(0).Value.Should().Be(2);
            circularLinkedList.PositionAt(1).Value.Should().Be(1);
        }

        [Test]
        public void Given_CircularLinkedListWith1Node_When_FirstSwappedWithLast_Then_NodesAsExpected()
        {
            var circularLinkedList = new CircularLinkedList();

            circularLinkedList.Push(new Node(1));

            circularLinkedList.PositionAt(0).Value.Should().Be(1);

            circularLinkedList.SwapFirstAndLast();

            circularLinkedList.PositionAt(0).Value.Should().Be(1);
        }
    }
}
