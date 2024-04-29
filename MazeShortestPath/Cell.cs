using System.Collections.Generic;

namespace MazeShortestPath
{
    public class Cell
    {
        public int Y { get; }
        public int X { get; }
        public List<Cell> CellsTraveled { get; }
        public int[,] Maze { get; }

        public Cell(int y, int x, List<Cell> cellsTraveled, int[,] maze)
        {
            Y = y;
            X = x;
            CellsTraveled = cellsTraveled;
            Maze = maze;
        }

        public bool CanMoveUp => Y - 1 >= 0 && Maze[Y - 1, X] == 1;
        public bool CanMoveDown => Y + 1 <= Maze.GetLength(0) - 1 && Maze[Y + 1, X] == 1;
        public bool CanMoveLeft => X - 1 >= 0 && Maze[Y, X - 1] == 1;
        public bool CanMoveRight => X + 1 <= Maze.GetLength(1) - 1 && Maze[Y, X + 1] == 1;

        public bool MatchesWith(Cell otherCell)
            => X == otherCell.X && Y == otherCell.Y;
    }
}
