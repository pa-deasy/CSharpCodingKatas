namespace ArbitraryLinkedListExamples
{
    public class LinkedList
    {
        public Node Head { get; set; }

        public LinkedList Clone()
        {
            AddClonedNodes(Head);
            AddClonedArbitraryPointers(Head);

            var clonedHead = Head.Next;
            SeparateClonedList(Head);

            return new LinkedList { Head = clonedHead };
        }

        public void AddClonedNodes(Node node)
        {
            if (node == null)
                return;

            var newNode = new Node { Value = node.Value, Next = node.Next };
            node.Next = newNode;

            AddClonedNodes(node.Next?.Next);
        }

        public void AddClonedArbitraryPointers(Node node)
        {
            if (node == null)
                return;

            var arbitrary = node.Arbitrary;
            node.Next.Arbitrary = arbitrary.Next;

            AddClonedArbitraryPointers(node.Next.Next);
        }

        public void SeparateClonedList(Node node)
        {
            if (node == null)
                return;

            var next = node.Next;
            node.Next = node.Next?.Next;
            next.Next = next.Next?.Next;

            SeparateClonedList(node.Next);
        }

        public Node NodeAtPosition(int position)
        {
            int currentPosition = 0;
            var currentNode = Head;

            while (currentPosition < position)
            {
                currentNode = currentNode.Next;
                currentPosition++;
            }

            return currentNode;
        }
    }
}
