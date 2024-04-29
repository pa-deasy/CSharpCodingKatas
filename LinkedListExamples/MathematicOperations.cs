namespace LinkedListExamples
{
    public static class MathematicOperations
    {
        public static LinkedList AddWith(this LinkedList firstLinkedList, LinkedList secondLinkedList)
        {
            var addedAndCarry = Add(firstLinkedList.Head, secondLinkedList.Head);
            var added = addedAndCarry.Node;

            if(addedAndCarry.Carry == 1)
            {
                var finalCarry = new Node(1);
                finalCarry.Next = added;
                added = finalCarry;
            }    

            return new LinkedList { Head = added };
        }

        private static CarriedNode Add(Node first, Node second)
        {
            CarriedNode nextNode = new CarriedNode(null, 0);

            if (first.Next != null)
                nextNode = Add(first.Next, second.Next);

            var sum = first.Value + second.Value + nextNode.Carry;

            var carry = 0;
            if (sum >= 10)
            {
                carry = 1;
                sum = sum - 10;
            }

            var node = new Node(sum);
            node.Next = nextNode.Node;

            return new CarriedNode(node, carry);
        }
    }

    public class CarriedNode
    {
        public Node Node { get; }
        public int Carry { get; }

        public CarriedNode(Node node, int carry)
        {
            Node = node;
            Carry = carry;
        }
    }
}
