using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleLinkedListExamples
{
    public class DoubleLinkedList
    {
        public Node Head { get; set; }

        public Node PositionAt(int position)
        {
            var currentPosition = 0;
            var currentNode = Head;

            while(currentPosition < position)
            {
                currentNode = currentNode.Next;
                currentPosition++;
            }

            return currentNode;
        }

        public void Reverse()
            => Reverse(Head);

        private void Reverse(Node node)
        {
            if (node == null || node.Next == null)
                return;

            var nextNext = node.Next.Next;

            node.Next.Next = Head;
            Head.Previous = node.Next;
            Head = node.Next;

            node.Next = nextNext;

            Reverse(node);
        }
    }
}
