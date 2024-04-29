using System.Collections.Generic;

namespace RatInAMazeAllPossibleDirections
{
    public static class MazeOperations
    {
        public static IList<List<char>> AllPossibleDirectionsToSolution(this Maze maze)
            => AllPossibleDirections(maze.Layout, SolutionState.New(maze.Layout.GetLength(0))).SuccessfulDirections;

        private static SolutionState AllPossibleDirections(int[,] layout, SolutionState state)
        {
            var successfulDirections = state.SuccessfulDirections;

            if (layout[state.CurrentYPosition, state.CurrentXPosition] == 0)
                return state;

            if (state.ReachedDestination)
                return new SolutionState(state.CurrentPath, state.CurrentYPosition, state.CurrentXPosition, state.CurrentDirections, state.SuccessfulDirections.With(state.CurrentDirections));

            var path = (int[,]) state.CurrentPath.Clone();
            path[state.CurrentYPosition, state.CurrentXPosition] = 1;

            if (state.CanMoveLeft)
                successfulDirections = AllPossibleDirections(layout, new SolutionState(path, state.CurrentYPosition, state.CurrentXPosition - 1, state.CurrentDirections.With(Direction.Left), successfulDirections)).SuccessfulDirections;

            if (state.CanMoveRight)
                successfulDirections = AllPossibleDirections(layout, new SolutionState(path, state.CurrentYPosition, state.CurrentXPosition + 1, state.CurrentDirections.With(Direction.Right), successfulDirections)).SuccessfulDirections;

            if (state.CanMoveDown)
                successfulDirections = AllPossibleDirections(layout, new SolutionState(path, state.CurrentYPosition + 1, state.CurrentXPosition, state.CurrentDirections.With(Direction.Down), successfulDirections)).SuccessfulDirections;

            if (state.CanMoveUp)
                successfulDirections = AllPossibleDirections(layout, new SolutionState(path, state.CurrentYPosition - 1, state.CurrentXPosition, state.CurrentDirections.With(Direction.Up), successfulDirections)).SuccessfulDirections;

            return new SolutionState(state.CurrentPath, state.CurrentYPosition, state.CurrentXPosition, state.CurrentDirections, successfulDirections);
        }
    }

    public class SolutionState
    {
        public int[,] CurrentPath { get; private set; }
        public int CurrentYPosition { get; private set; }
        public int CurrentXPosition { get; private set; }
        public List<char> CurrentDirections { get; set; }
        public List<List<char>> SuccessfulDirections { get; set; }

        public bool CanMoveLeft => CurrentXPosition - 1 >= 0 && PathNotTaken(CurrentYPosition, CurrentXPosition - 1);
        public bool CanMoveRight => CurrentXPosition + 1 <= CurrentPath.GetLength(0) - 1 && PathNotTaken(CurrentYPosition, CurrentXPosition + 1);
        public bool CanMoveDown => CurrentYPosition + 1 <= CurrentPath.GetLength(0) - 1 && PathNotTaken(CurrentYPosition + 1, CurrentXPosition);
        public bool CanMoveUp => CurrentYPosition - 1 >= 0 && PathNotTaken(CurrentYPosition - 1, CurrentXPosition);
        public bool ReachedDestination => CurrentYPosition == CurrentPath.GetLength(0) - 1 && CurrentXPosition == CurrentPath.GetLength(0) - 1;

        private bool PathNotTaken(int y, int x) => CurrentPath[y, x] == 0;

        public SolutionState(int[,] currentPath, int currentYPosition, int currentXPosition, List<char> currentDirections, List<List<char>> successfulDirections)
        {
            CurrentPath = currentPath;
            CurrentYPosition = currentYPosition;
            CurrentXPosition = currentXPosition;
            CurrentDirections = currentDirections;
            SuccessfulDirections = successfulDirections;
        }

        public static SolutionState New(int layoutLength) => new SolutionState(new int[layoutLength, layoutLength], 0, 0, new List<char>(), new List<List<char>>());
    }
}
