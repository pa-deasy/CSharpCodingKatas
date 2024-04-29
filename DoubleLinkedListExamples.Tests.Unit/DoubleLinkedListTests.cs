using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleLinkedListExamples.Tests.Unit
{
    [TestFixture]
    public class DoubleLinkedListTests
    {
        [Test]
        public void Given_DoubleLinkedList_When_PositionSearched_Then_CorrectNodeReturned()
        {
            var doubleLinkedList = new DoubleLinkedList();

            var first = new Node(1);
            var second = new Node(2);
            var third = new Node(3);
            var fourth = new Node(4);

            doubleLinkedList.Head = first;
            first.Next = second;
            second.Previous = first;
            second.Next = third;
            third.Previous = second;
            third.Next = fourth;
            fourth.Previous = third;

            doubleLinkedList.PositionAt(0).Value.Should().Be(1);
            doubleLinkedList.PositionAt(1).Value.Should().Be(2);
            doubleLinkedList.PositionAt(2).Value.Should().Be(3);
            doubleLinkedList.PositionAt(3).Value.Should().Be(4);
        }

        [Test]
        public void Given_DoubleLinkedList_When_Reversed_Then_NodesAreAsExpected()
        {
            var doubleLinkedList = new DoubleLinkedList();

            var first = new Node(1);
            var second = new Node(2);
            var third = new Node(3);
            var fourth = new Node(4);
            var fifth = new Node(5);

            doubleLinkedList.Head = first;
            first.Next = second;
            second.Previous = first;
            second.Next = third;
            third.Previous = second;
            third.Next = fourth;
            fourth.Previous = third;
            fourth.Next = fifth;
            fifth.Previous = fourth;

            doubleLinkedList.Reverse();

            doubleLinkedList.PositionAt(0).Value.Should().Be(5);
            doubleLinkedList.PositionAt(1).Value.Should().Be(4);
            doubleLinkedList.PositionAt(2).Value.Should().Be(3);
            doubleLinkedList.PositionAt(3).Value.Should().Be(2);
            doubleLinkedList.PositionAt(4).Value.Should().Be(1);
        }
    }
}
