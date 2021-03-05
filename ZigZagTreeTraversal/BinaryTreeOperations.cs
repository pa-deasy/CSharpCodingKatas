using System.Collections.Generic;
using System.Linq;

namespace ZigZagTreeTraversal
{
    public static class BinaryTreeOperations
    {
        public static IList<int> ZigZagOrder(this BinaryTree binaryTree)
            => ZigZagOrder(ZigZagState.New(binaryTree.Root)).CurrentZigZagOrder;

        private static ZigZagState ZigZagOrder(ZigZagState state)
        {
            if (!state.NodesOnCurrentLevel.Any())
                return state;

            var nodesOnNextLevel = new Queue<Node>();
            var valuesOnCurrentLevel = new List<int>();

            while (state.NodesOnCurrentLevel.Any())
            {
                var node = state.NodesOnCurrentLevel.Dequeue();

                valuesOnCurrentLevel.Add(node.Value);

                if (node.Left != null)
                    nodesOnNextLevel.Enqueue(node.Left);

                if (node.Right != null)
                    nodesOnNextLevel.Enqueue(node.Right);
            }

            if (!state.TraverseLeftToRight)
                valuesOnCurrentLevel.Reverse();

            return ZigZagOrder(new ZigZagState(
                state.CurrentZigZagOrder.WithRange(valuesOnCurrentLevel),
                state.TraverseLeftToRight ? false : true,
                nodesOnNextLevel));
        }
    }

    public class ZigZagState
    {
        public List<int> CurrentZigZagOrder { get; private set; }
        public bool TraverseLeftToRight { get; private set; }
        public Queue<Node> NodesOnCurrentLevel { get; set; }

        public ZigZagState(List<int> currentZigZagOrder, bool traverseLeftToRight, Queue<Node> nodesOnCurrentLevel)
        {
            CurrentZigZagOrder = currentZigZagOrder;
            TraverseLeftToRight = traverseLeftToRight;
            NodesOnCurrentLevel = nodesOnCurrentLevel;
        }

        public static ZigZagState New(Node root) => new ZigZagState(new List<int>(), true, new Queue<Node>( new [] { root } )); 
    }
}
