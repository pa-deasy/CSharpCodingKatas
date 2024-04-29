using NUnit.Framework;

namespace MazeShortestPath.Tests.Unit
{
    [TestFixture]
    public class MazeOperationsTests
    {
        [Test]
        public void Given_Maze_When_ShortestPathExists_Then_CorrectPathIsReturned()
        {
            var shortestPath = TestMaze.ShortestPath();

            Assert.AreEqual(17, shortestPath);
        }

        private static int[,] TestMaze => 
            new int[,]
            {
                {1, 0, 1, 1, 1, 1, 0, 1, 1, 1 },
                {1, 0, 1, 0, 1, 1, 1, 0, 1, 1 },
                {1, 1, 1, 0, 1, 1, 1, 1, 1, 1 },
                {1, 0, 0, 0, 1, 0, 0, 0, 1, 1 },
                {1, 1, 1, 0, 1, 1, 1, 0, 1, 0 },
                {1, 0, 1, 1, 1, 1, 0, 1, 1, 0 },
                {1, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
                {1, 0, 0, 0, 0, 1, 0, 1, 1, 1 },
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            };
    }
}
