using System.Collections.Generic;

namespace TicTacToe.Domain.Models
{
    public class GameState
    {
        public IList<Cell> Cells { get; private set; }
        public Player NextPlayer { get; private set; }

        public GameState(IList<Cell> cells, Player nextPlayer)
        {
            Cells = cells;
            NextPlayer = nextPlayer;
        }

        public static GameState New =>
            new GameState(
                new List<Cell> {
                    new Cell(Position.TopLeft, Player.Nobody), new Cell(Position.TopMiddle, Player.Nobody), new Cell(Position.TopRight, Player.Nobody),
                    new Cell(Position.MiddleLeft, Player.Nobody), new Cell(Position.Middle, Player.Nobody), new Cell(Position.MiddleRight, Player.Nobody),
                    new Cell(Position.BottomLeft, Player.Nobody), new Cell(Position.BottomMiddle, Player.Nobody), new Cell(Position.BottomRight, Player.Nobody)
                },
                Player.X);

        public static IList<IList<Position>> WinningLines =>
            new List<IList<Position>>
            {
                new List<Position>{ Position.TopLeft, Position.TopMiddle, Position.TopRight },
                new List<Position>{ Position.MiddleLeft, Position.Middle, Position.MiddleRight },
                new List<Position>{ Position.BottomLeft, Position.BottomMiddle, Position.BottomRight },
                new List<Position>{ Position.TopLeft, Position.MiddleLeft, Position.BottomLeft },
                new List<Position>{ Position.TopMiddle, Position.Middle, Position.BottomMiddle },
                new List<Position>{ Position.TopRight, Position.MiddleRight, Position.BottomRight },
                new List<Position>{ Position.TopLeft, Position.Middle, Position.BottomRight },
                new List<Position>{ Position.TopRight, Position.Middle, Position.BottomLeft },
            };
    }
}
