using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Domain.Models;

namespace TicTacToe.Domain.Tests.Unit
{
    [TestFixture]
    public class GameStateExtensionsTests
    {
        [Test]
        public void Given_GameState_When_CellsUnplayed_Then_ReturnsAvailaleCells()
        {
            var gameState =
                new GameState(
                    new List<Cell> {
                        new Cell(Position.TopLeft, Player.X), new Cell(Position.TopMiddle, Player.Nobody), new Cell(Position.TopRight, Player.Nobody),
                        new Cell(Position.MiddleLeft, Player.O), new Cell(Position.Middle, Player.O), new Cell(Position.MiddleRight, Player.Nobody),
                        new Cell(Position.BottomLeft, Player.X), new Cell(Position.BottomMiddle, Player.Nobody), new Cell(Position.BottomRight, Player.Nobody)
                    },
                    Player.X);

            var availableCells = gameState.AvailableCells();

            availableCells.Count().Should().Be(5);
            availableCells.Select(c => c.Position).Should().Contain(Position.TopMiddle);
            availableCells.Select(c => c.Position).Should().Contain(Position.TopRight);
            availableCells.Select(c => c.Position).Should().Contain(Position.MiddleRight);
            availableCells.Select(c => c.Position).Should().Contain(Position.BottomMiddle);
            availableCells.Select(c => c.Position).Should().Contain(Position.BottomRight);
        }

        [Test]
        public void Given_GameState_When_NoCellsUnplayed_Then_ReturnsEmptyListOfCells()
        {
            var gameState =
                new GameState(
                    new List<Cell> {
                        new Cell(Position.TopLeft, Player.X), new Cell(Position.TopMiddle, Player.X), new Cell(Position.TopRight, Player.O),
                        new Cell(Position.MiddleLeft, Player.O), new Cell(Position.Middle, Player.O), new Cell(Position.MiddleRight, Player.X),
                        new Cell(Position.BottomLeft, Player.X), new Cell(Position.BottomMiddle, Player.O), new Cell(Position.BottomRight, Player.X)
                    },
                    Player.O);

            var availableCells = gameState.AvailableCells();

            availableCells.Any().Should().BeFalse();
        }

        [Test]
        public void Given_GameState_When_MovePerformed_Then_NewGameStateCreatedWithUpdatedPosition()
        {
            var gameState = GameState.New;

            var topMiddleForX = gameState.PerformMove(Position.TopMiddle, Player.X);

            var topMiddleForXAndBottomRightForO = topMiddleForX.PerformMove(Position.BottomRight, Player.O);

            topMiddleForXAndBottomRightForO.Cells.Count().Should().Be(9);
            topMiddleForXAndBottomRightForO.Cells.Single(c => c.Position == Position.TopMiddle).PlayedBy.Should().Be(Player.X);
            topMiddleForXAndBottomRightForO.Cells.Single(c => c.Position == Position.BottomRight).PlayedBy.Should().Be(Player.O);
            topMiddleForXAndBottomRightForO.NextPlayer.Should().Be(Player.X);
        }

        [Test]
        public void Given_GameState_When_HorizontalWinForO_Then_ReturnsWon()
        {
            var gameState =
                new GameState(
                    new List<Cell> {
                        new Cell(Position.TopLeft, Player.X), new Cell(Position.TopMiddle, Player.X), new Cell(Position.TopRight, Player.Nobody),
                        new Cell(Position.MiddleLeft, Player.Nobody), new Cell(Position.Middle, Player.X), new Cell(Position.MiddleRight, Player.Nobody),
                        new Cell(Position.BottomLeft, Player.O), new Cell(Position.BottomMiddle, Player.O), new Cell(Position.BottomRight, Player.O)
                    },
                    Player.X);

            gameState.HasBeenWonBy(Player.O).Should().BeTrue();
        }

        [Test]
        public void Given_GameState_When_VerticalWinForX_Then_ReturnsWon()
        {
            var gameState =
                new GameState(
                    new List<Cell> {
                        new Cell(Position.TopLeft, Player.X), new Cell(Position.TopMiddle, Player.O), new Cell(Position.TopRight, Player.Nobody),
                        new Cell(Position.MiddleLeft, Player.X), new Cell(Position.Middle, Player.O), new Cell(Position.MiddleRight, Player.Nobody),
                        new Cell(Position.BottomLeft, Player.X), new Cell(Position.BottomMiddle, Player.Nobody), new Cell(Position.BottomRight, Player.Nobody)
                    },
                    Player.O);

            gameState.HasBeenWonBy(Player.X).Should().BeTrue();
        }

        [Test]
        public void Given_GameState_When_DiagonalWinForX_Then_ReturnsWon()
        {
            var gameState =
                new GameState(
                    new List<Cell> {
                        new Cell(Position.TopLeft, Player.O), new Cell(Position.TopMiddle, Player.O), new Cell(Position.TopRight, Player.X),
                        new Cell(Position.MiddleLeft, Player.Nobody), new Cell(Position.Middle, Player.X), new Cell(Position.MiddleRight, Player.Nobody),
                        new Cell(Position.BottomLeft, Player.X), new Cell(Position.BottomMiddle, Player.O), new Cell(Position.BottomRight, Player.X)
                    },
                    Player.O);

            gameState.HasBeenWonBy(Player.X).Should().BeTrue();
        }

        [Test]
        public void Given_GameState_When_NoWinner_Then_ReturnsNotWon()
        {
            var gameState =
                new GameState(
                    new List<Cell> {
                        new Cell(Position.TopLeft, Player.X), new Cell(Position.TopMiddle, Player.X), new Cell(Position.TopRight, Player.O),
                        new Cell(Position.MiddleLeft, Player.O), new Cell(Position.Middle, Player.O), new Cell(Position.MiddleRight, Player.X),
                        new Cell(Position.BottomLeft, Player.X), new Cell(Position.BottomMiddle, Player.O), new Cell(Position.BottomRight, Player.X)
                    },
                    Player.O);

            gameState.HasBeenWonBy(Player.X).Should().BeFalse();
            gameState.HasBeenWonBy(Player.O).Should().BeFalse();
        }

        [Test]
        public void Given_GameState_When_PositionPlayed_Then_ReturnsExpectedPlayer()
        {
            var gameState =
                new GameState(
                    new List<Cell> {
                        new Cell(Position.TopLeft, Player.X), new Cell(Position.TopMiddle, Player.X), new Cell(Position.TopRight, Player.O),
                        new Cell(Position.MiddleLeft, Player.O), new Cell(Position.Middle, Player.Nobody), new Cell(Position.MiddleRight, Player.X),
                        new Cell(Position.BottomLeft, Player.X), new Cell(Position.BottomMiddle, Player.O), new Cell(Position.BottomRight, Player.Nobody)
                    },
                    Player.O);

            gameState.PlayedAtPosition(Position.TopLeft).Should().Be("X");
            gameState.PlayedAtPosition(Position.TopRight).Should().Be("O");
            gameState.PlayedAtPosition(Position.BottomRight).Should().Be("-");
        }
    }
}
