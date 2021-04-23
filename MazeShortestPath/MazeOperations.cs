using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeShortestPath
{
    public static class MazeOperations
    {
        public static int ShortestPath(this int[,] maze)
        {
            var cellsToProcess = new Queue<Cell>();
            var visitedCells = new List<Cell>();
            var targetCell = new Cell(maze.GetLength(0) - 1, maze.GetLength(1) - 1, new List<Cell>(), maze);

            cellsToProcess.Enqueue(new Cell(0, 0, new List<Cell>(), maze));

            while (cellsToProcess.Any())
            {
                var cell = cellsToProcess.Dequeue();

                if (cell.MatchesWith(targetCell))
                {
                    cell.PrintSuccess();
                    return cell.CellsTraveled.Count();
                }

                if (visitedCells.Where(c => c.MatchesWith(cell)).Any())
                    continue;

                var cellsTraveled = new List<Cell>(cell.CellsTraveled);
                cellsTraveled.Add(cell);

                if (cell.CanMoveUp)
                    cellsToProcess.Enqueue(new Cell(cell.Y - 1, cell.X, cellsTraveled, maze));

                if (cell.CanMoveDown)
                    cellsToProcess.Enqueue(new Cell(cell.Y + 1, cell.X, cellsTraveled, maze));

                if (cell.CanMoveLeft)
                    cellsToProcess.Enqueue(new Cell(cell.Y, cell.X - 1, cellsTraveled, maze));

                if (cell.CanMoveRight)
                    cellsToProcess.Enqueue(new Cell(cell.Y, cell.X + 1, cellsTraveled, maze));

                visitedCells.Add(cell);
            }

            Console.WriteLine("Longest path not found");
            return 0;
        }

        private static void PrintSuccess(this Cell cell)
        {
            Console.WriteLine($"Longest path is: {cell.CellsTraveled.Count()}");
            Console.WriteLine("Path traveled is:");
            cell.CellsTraveled.ForEach(c => Console.WriteLine($"({c.Y},{c.X})"));
        }
    }
}
