using System.Drawing;

namespace RatInAMazeBackTracking
{
    public class Maze
    {
        public int[,] Layout { get; private set; }

        public Maze(int [,] layout)
        {
            Layout = layout;
        }
    }
}
