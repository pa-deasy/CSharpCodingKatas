namespace IsBinarySearchTree
{
    public class BinaryTree
    {
        public Node Root { get; }

        public BinaryTree(Node root)
        {
            Root = root;
        }

        public bool IsBst() => IsBst(Root, int.MinValue, int.MaxValue);

        private bool IsBst(Node node, int min, int max)
        {
            if (node == null)
                return true;

            if (min > node.Value || node.Value > max)
                return false;

            return IsBst(node.Left, min, node.Value) && IsBst(node.Right, node.Value, max);
        }
    }
}
