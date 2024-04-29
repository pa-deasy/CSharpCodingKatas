using System.Collections.Generic;
using System.Linq;

namespace BinaryTreePathSums
{
    public class BinaryTree
    {
        public Node Root { get; private set; }

        public BinaryTree(Node root)
        {
            Root = root;
        }

        public IList<List<int>> PathsFromRootSummingTo(int sum)
            => SumOfPathsFrom(Root, sum, SumState.New).SuccessfulPaths;

        public IList<List<int>> AllPathsSummingTo(int sum)
            => SumOfAllPaths(Root, sum, new List<List<int>>());

        private List<List<int>> SumOfAllPaths(Node node, int targetSum, List<List<int>> allSuccessfulPaths)
        {
            if (node == null)
                return allSuccessfulPaths;

            allSuccessfulPaths.AddRange(SumOfPathsFrom(node, targetSum, SumState.New).SuccessfulPaths);

            if (node.Left != null)
                SumOfAllPaths(node.Left, targetSum, allSuccessfulPaths);

            if (node.Right != null)
                SumOfAllPaths(node.Right, targetSum, allSuccessfulPaths);

            return allSuccessfulPaths;
        }

        private SumState SumOfPathsFrom(Node node, int targetSum, SumState sumState)
        {
            if (node == null || sumState.CurrentPath.Sum() + node.Value > targetSum)
                return sumState;

            var currentPath = new List<int> (sumState.CurrentPath);
            var currentSum = currentPath.Sum();
            var successfulPaths = sumState.SuccessfulPaths;

            currentSum += node.Value;
            currentPath.Add(node.Value);

            if (currentSum == targetSum)
            {
                successfulPaths.Add(currentPath);
                return new SumState(sumState.CurrentPath, successfulPaths);
            }

            if (node.Left != null)
                successfulPaths = SumOfPathsFrom(node.Left, targetSum, new SumState(currentPath, successfulPaths)).SuccessfulPaths;

            if (node.Right != null)
                successfulPaths = SumOfPathsFrom(node.Right, targetSum, new SumState(currentPath, successfulPaths)).SuccessfulPaths;

            return new SumState(sumState.CurrentPath, successfulPaths);
        }

        public Dictionary<int, int> VerticalSums()
        {
            var verticalSums = new Dictionary<int, int>();
            var queue = new Queue<HorizontalNode>();
            queue.Enqueue(new HorizontalNode(Root, 0));

            while (queue.Any())
            {
                var dequeuedNode = queue.Dequeue();

                if (verticalSums.ContainsKey(dequeuedNode.Position))
                    verticalSums[dequeuedNode.Position] = verticalSums[dequeuedNode.Position] + dequeuedNode.Node.Value;

                else
                    verticalSums.Add(dequeuedNode.Position, dequeuedNode.Node.Value);

                if (dequeuedNode.Node.Left != null)
                    queue.Enqueue(new HorizontalNode(dequeuedNode.Node.Left, dequeuedNode.Position - 1));

                if (dequeuedNode.Node.Right != null)
                    queue.Enqueue(new HorizontalNode(dequeuedNode.Node.Right, dequeuedNode.Position + 1));
            }

            return verticalSums;
        }
    }

    public class SumState
    {
        public List<int> CurrentPath { get; private set; }
        public List<List<int>> SuccessfulPaths { get; private set; }

        public SumState(List<int> currentPath, List<List<int>> successfulPaths)
        {
            CurrentPath = currentPath;
            SuccessfulPaths = successfulPaths;
        }

        public static SumState New => new SumState(new List<int>(), new List<List<int>>());
    }
}
