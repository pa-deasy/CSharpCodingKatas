using System;
using System.Collections.Generic;
using System.Text;

namespace CircularLinkedListExamples
{
    public class CircularLinkedList
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

                if (position > 0 && currentNode == Head)
                    return null;
            }

            return currentNode;
        }

        public Node LastNode()
            => LastNode(Head);

        private Node LastNode(Node node)
        {
            if (node.Next == Head)
                return node;

            return LastNode(node.Next);
        }

        public Node SecondLastNode()
            => SecondLastNode(Head);

        private Node SecondLastNode(Node node)
        {
            if (node.Next.Next == Head)
                return node;

            return SecondLastNode(node.Next);
        }

        public void Push(Node node)
        {
            if (Head == null)
            {
                Head = node;
                Head.Next = Head;
                return;
            }

            var lastNode = LastNode();
            node.Next = Head;
            Head = node;
            lastNode.Next = Head;
        }

        public void SwapFirstAndLast()
        {
            var tmpNode = Head;
            var lastNode = LastNode();
            var secondLastNode = SecondLastNode();

            if(secondLastNode == Head)
            {
                Head = lastNode;
                Head.Next = tmpNode;
            }
            else
            {
                Head = lastNode;
                Head.Next = tmpNode.Next;
                secondLastNode.Next = tmpNode;
            }
            
            tmpNode.Next = Head;
        }
    }
}
