using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListExamples
{
    public class LinkedList
    {
        public Node Head { get; set; }

        public Node NodeAtPosition(int position)
        {
            int currentPosition = 0;
            var currentNode = Head;

            while(currentPosition < position)
            {
                currentNode = currentNode.Next;
                currentPosition++;
            }

            return currentNode;
        }

        public void Push(Node node)
        {
            node.Next = Head;
            Head = node;
        }

        public Node Pop()
        {
            var toPop = Head;

            if (Head.Next != null)
                Head = Head.Next;

            return toPop;
        }

        public bool ValueExists(int value)
            => Exists(Head, value);

        private bool Exists(Node node, int value)
        {
            if (node == null)
                return false;

            if (node.Value == value)
                return true;

            return Exists(node.Next, value);
        }

        public void PairWiseSwap()
        {
            var currentNode = Head;

            while(currentNode != null && currentNode.Next != null)
            {
                var tmpValue = currentNode.Value;
                currentNode.Value = currentNode.Next.Value;
                currentNode.Next.Value = tmpValue;

                currentNode = currentNode.Next.Next;
            }
        }

        public void MoveLastNodeToFront()
        {
            var secondLastNode = SecondLastNode(Head);

            secondLastNode.Next = null;

            Push(secondLastNode);
        }

        private Node SecondLastNode(Node node)
        {
            if (node == null)
                return node;

            if (node.Next == null)
                return node;

            return SecondLastNode(node.Next);
        }

        public void Reverse()
            => Reverse(Head);

        private void Reverse(Node node)
        {
            if (node == null || node.Next == null)
                return;

            var nextNext = node.Next.Next;
            node.Next.Next = null;
            Push(node.Next);
            node.Next = nextNext;

            Reverse(node);
        }
    }
}
