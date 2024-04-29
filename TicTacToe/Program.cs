using System;
using TicTacToe.Domain;
using TicTacToe.Domain.Models;
using System.Linq;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tack Toe!");

            var gameState = GameState.New;

            while(true)
            {
                PrintOverviewFrom(gameState);

                var currentPlayer = gameState.NextPlayer;
                var inputPosition = Console.ReadLine();

                gameState = PlayInput(gameState, inputPosition);

                if (gameState.HasBeenWonBy(currentPlayer))
                {
                    PrintVictoryFor(currentPlayer);
                    break;
                }

                if (!gameState.AvailableCells().Any())
                {
                    PrintTie();
                    break;
                }
            };
        }

        private static GameState PlayInput(GameState gameState, string inputPosition)
        {
            if (!Enum.IsDefined(typeof(Position), inputPosition))
            {
                Console.WriteLine($"Position {inputPosition} does not exist");
                return gameState;
            }

            if (!gameState.AvailableCells().Where(c => c.Position == Enum.Parse<Position>(inputPosition, true)).Any())
                Console.WriteLine($"Position {inputPosition} is already played");

            return gameState.PerformMove(Enum.Parse<Position>(inputPosition, true), gameState.NextPlayer);
        }

        private static void PrintOverviewFrom(GameState gameState)
        {
            Console.WriteLine("");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("");
            Console.WriteLine($"It's Player {gameState.NextPlayer}'s turn");
            Console.WriteLine("");
            PrintGameFrom(gameState);
            Console.WriteLine("");
            Console.WriteLine($"Available moves are:");
            Console.WriteLine("");
            gameState.AvailableCells().ToList().ForEach(c => Console.WriteLine(c.Position));
            Console.WriteLine("");
            Console.WriteLine($"Please enter position for {gameState.NextPlayer}:");
        }

        private static void PrintGameFrom(GameState gameState)
        {
            Console.WriteLine($"{gameState.PlayedAtPosition(Position.TopLeft)} | {gameState.PlayedAtPosition(Position.TopMiddle)} | {gameState.PlayedAtPosition(Position.TopRight)}");
            Console.WriteLine($"---------");
            Console.WriteLine($"{gameState.PlayedAtPosition(Position.MiddleLeft)} | {gameState.PlayedAtPosition(Position.Middle)} | {gameState.PlayedAtPosition(Position.MiddleRight)}");
            Console.WriteLine($"---------");
            Console.WriteLine($"{gameState.PlayedAtPosition(Position.BottomLeft)} | {gameState.PlayedAtPosition(Position.BottomMiddle)} | {gameState.PlayedAtPosition(Position.BottomRight)}");
        }

        private static void PrintVictoryFor(Player player)
        {
            Console.WriteLine("");
            Console.WriteLine($"Player {player} wins!");
            Console.WriteLine("Salutation!");
            Console.WriteLine($"Player {player} wins!");
            Console.WriteLine("Salutations!");
        }

        private static void PrintTie()
        {
            Console.WriteLine("");
            Console.WriteLine($"It's a tie");
            Console.WriteLine("Please play again!");
        }
    }
}
