using System.Collections.Generic;

namespace BinaryTreePathSums
{
    public class BinaryTree
    {
        public Node Root { get; private set; }

        public BinaryTree(Node root)
        {
            Root = root;
        }

        public List<List<int>> PathsFromRootSummingTo(int sum)
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
            if (node == null || sumState.CurrentSum + node.Value > targetSum)
                return sumState;

            var currentPath = new List<int> (sumState.CurrentPath);
            var currentSum = sumState.CurrentSum;
            var successfulPaths = sumState.SuccessfulPaths;

            currentSum += node.Value;
            currentPath.Add(node.Value);

            if (currentSum == targetSum)
            {
                successfulPaths.Add(currentPath);
                return new SumState(sumState.CurrentSum, sumState.CurrentPath, successfulPaths);
            }

            if (node.Left != null)
                successfulPaths = SumOfPathsFrom(node.Left, targetSum, new SumState(currentSum, currentPath, successfulPaths)).SuccessfulPaths;

            if (node.Right != null)
                successfulPaths = SumOfPathsFrom(node.Right, targetSum, new SumState(currentSum, currentPath, successfulPaths)).SuccessfulPaths;

            return new SumState(sumState.CurrentSum, sumState.CurrentPath, successfulPaths);
        }
    }

    public class SumState
    {
        public int CurrentSum { get; private set; }
        public List<int> CurrentPath { get; private set; }
        public List<List<int>> SuccessfulPaths { get; private set; }

        public SumState(int currentSum, List<int> currentPath, List<List<int>> successfulPaths)
        {
            CurrentSum = currentSum;
            CurrentPath = currentPath;
            SuccessfulPaths = successfulPaths;
        }

        public static SumState New => new SumState(0, new List<int>(), new List<List<int>>());
    }
}
