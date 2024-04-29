namespace RatInAMazeBackTracking
{
    public static class MazeOperations
    {
        public static int[,] SolutionPath(this Maze maze)
            => SolutionPath(maze.Layout, SolutionState.New(maze.Layout.GetLength(0))).CurrentPath;

        private static SolutionState SolutionPath(int[,] layout, SolutionState state)
        {
            var isSuccessful = state.IsSuccessful;
            var currentPath = state.CurrentPath;

            if (layout[state.CurrentYPosition, state.CurrentXPosition] == 0 || state.IsSuccessful)
                return state;

            if (state.ReachedDestination)
            {
                currentPath[state.CurrentYPosition, state.CurrentXPosition] = 1;
                return new SolutionState(currentPath, state.CurrentYPosition, state.CurrentXPosition, true);
            }

            if (state.CanMoveRight)            
                isSuccessful = SolutionPath(layout, new SolutionState(currentPath, state.CurrentYPosition, state.CurrentXPosition + 1, state.IsSuccessful)).IsSuccessful;

            if (state.CanMoveDown)
                isSuccessful = SolutionPath(layout, new SolutionState(currentPath, state.CurrentYPosition + 1, state.CurrentXPosition, isSuccessful)).IsSuccessful;

            if(isSuccessful)
                currentPath[state.CurrentYPosition, state.CurrentXPosition] = 1;

            return new SolutionState(currentPath, state.CurrentYPosition, state.CurrentXPosition, isSuccessful);
        }
    }

    public class SolutionState
    {
        public int[,] CurrentPath { get; private set; }
        public int CurrentYPosition { get; private set; }
        public int CurrentXPosition { get; private set; }
        public bool IsSuccessful { get; private set; }

        public bool CanMoveRight => CurrentXPosition + 1 <= CurrentPath.GetLength(0) - 1;
        public bool CanMoveDown => CurrentYPosition + 1 <= CurrentPath.GetLength(0) - 1;
        public bool ReachedDestination => CurrentYPosition == CurrentPath.GetLength(0) - 1 && CurrentXPosition == CurrentPath.GetLength(0) - 1;

        public SolutionState(int[,] currentPath, int currentYPosition, int currentXPosition, bool isSuccessful)
        {
            CurrentPath = currentPath;
            CurrentYPosition = currentYPosition;
            CurrentXPosition = currentXPosition;
            IsSuccessful = isSuccessful;
        }

        public static SolutionState New(int layoutLength) => new SolutionState(new int[layoutLength, layoutLength], 0, 0, false);
    }
}
