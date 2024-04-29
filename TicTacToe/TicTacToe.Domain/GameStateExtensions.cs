using System.Collections.Generic;
using TicTacToe.Domain.Models;
using System.Linq;

namespace TicTacToe.Domain
{
    public static class GameStateExtensions
    {
        public static IList<Cell> AvailableCells(this GameState gameState) =>
            gameState.Cells.Where(c => c.PlayedBy == Player.Nobody).ToList();

        public static GameState PerformMove(this GameState gamestate, Position positionPlayed, Player playedBy) =>
            new GameState(
                gamestate.Cells.Where(c => c.Position != positionPlayed)
                    .Append(new Cell(positionPlayed, playedBy)).ToList(),
                playedBy == Player.X ? Player.O : Player.X);

        public static bool HasBeenWonBy(this GameState gameState, Player playedBy) =>
            GameState.WinningLines.Aggregate(false, (isWon, nextLine) =>
            gameState.Cells.Where(
                c => c.PlayedBy == playedBy && nextLine.Contains(c.Position))
            .Count() == nextLine.Count() || isWon);

        public static string PlayedAtPosition(this GameState gameState, Position position) =>
            gameState.Cells.Where(c => c.Position == position)
                .Select(c => c.PlayedBy == Player.Nobody ? "-" : c.PlayedBy.ToString())
            .Single();
    }
}
