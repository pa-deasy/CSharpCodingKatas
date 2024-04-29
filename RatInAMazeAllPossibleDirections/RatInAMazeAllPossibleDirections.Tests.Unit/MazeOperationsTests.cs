using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace RatInAMazeAllPossibleDirections.Tests.Unit
{
    [TestFixture]
    public class MazeOperationsTests
    {
        [Test]
        public void Given_Maze_When_OneSuccessfulPathExists_Then_DirectionsAreReturned()
        {
            var directions = SimpleMaze.AllPossibleDirectionsToSolution();

            directions.Single()[0].Should().Be(Direction.Down);
            directions.Single()[1].Should().Be(Direction.Right);
            directions.Single()[2].Should().Be(Direction.Down);
            directions.Single()[3].Should().Be(Direction.Down);
            directions.Single()[4].Should().Be(Direction.Right);
            directions.Single()[5].Should().Be(Direction.Right);
        }

        [Test]
        public void Given_Maze_When_SuccessfulPathsExist_Then_AllDirectionsAreReturned()
        {
            var directions = ComplexMaze.AllPossibleDirectionsToSolution();

            directions.Count.Should().Be(2);

            directions.First()[0].Should().Be(Direction.Down);
            directions.First()[1].Should().Be(Direction.Right);
            directions.First()[2].Should().Be(Direction.Down);
            directions.First()[3].Should().Be(Direction.Down);
            directions.First()[4].Should().Be(Direction.Right);
            directions.First()[5].Should().Be(Direction.Right);

            directions.Last()[0].Should().Be(Direction.Down);
            directions.Last()[1].Should().Be(Direction.Down);
            directions.Last()[2].Should().Be(Direction.Right);
            directions.Last()[3].Should().Be(Direction.Down);
            directions.Last()[4].Should().Be(Direction.Right);
            directions.Last()[5].Should().Be(Direction.Right);
        }

        private Maze SimpleMaze =>
            new Maze(new int[,] 
                {
                    { 1, 0, 0, 0 },
                    { 1, 1, 0, 1 },
                    { 0, 1, 0, 0 },
                    { 0, 1, 1, 1 }
                });

        private Maze ComplexMaze =>
            new Maze(new int[,]
                {
                    { 1, 0, 0, 0 },
                    { 1, 1, 0, 1 },
                    { 1, 1, 0, 0 },
                    { 0, 1, 1, 1 }
                });
    }
}
