namespace LowestCommonAncestor
{
    public class Node
    {
        public int Root { get; private set; }
        public Node Left { get; private set;}
        public Node Right { get; private set; }

        public Node(int root, Node left, Node right)
        {
            Root = root;
            Left = left;
            Right = right;
        }
    }
}
