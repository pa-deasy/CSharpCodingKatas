namespace BinaryTreePathSums
{
    public class HorizontalNode
    {
        public Node Node { get; }
        public int Position { get; }

        public HorizontalNode(Node node, int position)
        {
            Node = node;
            Position = position;
        }
    }
}
