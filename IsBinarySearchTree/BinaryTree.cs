namespace IsBinarySearchTree
{
    public class BinaryTree
    {
        public Node Root { get; }
        
        private Node MisplacedNode { get; set; }

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

        public void FixSingleSwappedTree() => FixSingleSwappedTree(Root, int.MinValue, int.MaxValue);

        private void FixSingleSwappedTree(Node node, int min, int max)
        {
            if (node == null)
                return;

            if (node.IsMisplaced(min, max) && MisplacedNode != null)
                SwapValues(node, MisplacedNode);

            if (node.IsMisplaced(min, max) && MisplacedNode == null)
                MisplacedNode = node;

            FixSingleSwappedTree(node.Left, min, node.Value);
            FixSingleSwappedTree(node.Right, node.Value, max);
        }

        private void SwapValues(Node first, Node second)
        {
            var temp = first.Value;
            first.Value = second.Value;
            second.Value = temp;
        }
    }
}
