namespace IsBinarySearchTree
{
    public class Node
    {
        public int Value { get; set; }
        public Node Left { get; }
        public Node Right { get; }

        public bool IsMisplaced(int min, int max) => min > Value || Value > max;

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
