using System;

namespace LowestCommonAncestor
{
    public static class BinaryTreeExtensions
    {
        public static Node BstLca(this BinaryTree binaryTree, int node1, int node2)
        {
            if (binaryTree.Root == null)
                return null;

            binaryTree.Root.Validate(node1, node2);

            return binaryTree.Root.BstLca(node1, node2);            
        }

        private static Node BstLca(this Node node, int node1, int node2)
        {
            //if both nodes are small than root, then LCA is to the left
            if (node1 < node.Value && node.Value > node2)
                return node.Left.BstLca(node1, node2);

            //if both nodes are greater than root, then LCA is to the right
            if (node1 > node.Value && node.Value < node2)
                return node.Right.BstLca(node1, node2);

            return node;
        }

        public static Node Lca(this BinaryTree binaryTree, int node1, int node2)
            => Lca(binaryTree.Root, node1, node2, new LcaSearch(false, null)).Lca;

        private static LcaSearch Lca(Node node, int node1, int node2, LcaSearch state)
        {
            if (node == null)
                return state;

            if (node.Value == node1 || node.Value == node2)
                return new LcaSearch(true, state.Lca);

            var left = Lca(node.Left, node1, node2, state);
            var right = Lca(node.Right, node1, node2, state);

            if (left.Lca != null)
                return left;

            if (right.Lca != null)
                return right;

            if (left.PathContainsNode && right.PathContainsNode)
                return new LcaSearch(true, node);

            if (left.PathContainsNode || right.PathContainsNode)
                return new LcaSearch(true, state.Lca);

            return state;
        }

        private static void Validate(this Node node, int node1, int node2)
        {
            if (!node.Contains(node1))
                throw new ApplicationException($"Node not found {node1}");

            if (!node.Contains(node2))
                throw new ApplicationException($"Node not found {node2}");
        }

        private static bool Contains(this Node node, int nodeToCheck)
        {
            if (node == null)
                return false;

            if (node.Value == nodeToCheck)
                return true;

            if (node.Value > nodeToCheck)
                return node.Left.Contains(nodeToCheck);

            if (node.Value < nodeToCheck)
                return node.Right.Contains(nodeToCheck);

            return false;
        }
    }

    public class LcaSearch
    {
        public bool PathContainsNode { get; }
        public Node Lca { get; }

        public LcaSearch(bool pathContainsNode, Node lca)
        {
            PathContainsNode = pathContainsNode;
            Lca = lca;
        }
    }
}
