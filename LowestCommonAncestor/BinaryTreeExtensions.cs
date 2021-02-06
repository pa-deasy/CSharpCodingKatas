using System;

namespace LowestCommonAncestor
{
    public static class BinaryTreeExtensions
    {
        public static Node LCA(this BinaryTree binaryTree, int node1, int node2)
        {
            if (binaryTree.SourceNode == null)
                return null;

            binaryTree.SourceNode.Validate(node1, node2);

            return binaryTree.SourceNode.LCA(node1, node2);            
        }

        private static Node LCA(this Node node, int node1, int node2)
        {
            //if both nodes are small than root, then LCA is to the left
            if (node1 < node.Root && node.Root > node2)
                return node.Left.LCA(node1, node2);

            //if both nodes are greater than root, then LCA is to the right
            if (node1 > node.Root && node.Root < node2)
                return node.Right.LCA(node1, node2);

            return node;
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

            if (node.Root == nodeToCheck)
                return true;

            if (node.Root > nodeToCheck)
                return node.Left.Contains(nodeToCheck);

            if (node.Root < nodeToCheck)
                return node.Right.Contains(nodeToCheck);

            return false;
        }
    }
}
