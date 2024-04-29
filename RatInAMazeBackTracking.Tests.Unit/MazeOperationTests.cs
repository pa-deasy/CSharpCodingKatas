using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatInAMazeBackTracking.Tests.Unit
{
    [TestFixture]
    public class MazeOperationTests
    {
        [Test]
        public void Given_A_Maze_When_SolutionPathExists_Then_PathFound()
        {
            var solution = TestMaze.SolutionPath();

            solution[0, 0].Should().Be(1);
            solution[0, 1].Should().Be(1);
            solution[1, 1].Should().Be(1);
            solution[2, 1].Should().Be(1);
            solution[3, 1].Should().Be(1);
            solution[3, 2].Should().Be(1);
            solution[3, 3].Should().Be(1);
            solution[1, 0].Should().Be(0);
            solution[0, 2].Should().Be(0);
            solution[3, 0].Should().Be(0);
        }

        public Maze TestMaze =>
            new Maze(new int[,]
            {
                { 1, 1, 1, 1 },
                { 1, 1, 0, 1 },
                { 0, 1, 0, 0 },
                { 1, 1, 1, 1 }
            });

        public Maze TestMazeB =>
            new Maze(new int[,]
            {
                { 1, 0, 0, 0 },
                { 1, 1, 0, 1 },
                { 0, 1, 0, 0 },
                { 1, 1, 1, 1 }
            });
    }
}
