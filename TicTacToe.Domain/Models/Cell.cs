namespace TicTacToe.Domain.Models
{
    public class Cell
    {
        public Position Position { get; private set; }
        public Player PlayedBy { get; private set; }

        public Cell(Position position, Player playedBy)
        {
            Position = position;
            PlayedBy = playedBy;
        }
    }
}
