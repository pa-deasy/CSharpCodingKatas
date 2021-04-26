namespace IsBinarySearchTree
{
    public class Node
    {
        public int Value { get; }
        public Node Left { get; }
        public Node Right { get; }

        public Node(int value, Node left, Node right)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public Node(int value)
        {
            Value = value;
        }
    }
}
