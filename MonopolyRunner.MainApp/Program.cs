using MonopolyRunner.Domains;
using MonopolyRunner.Domains.Constants;
using MonopolyRunner.Domains.Contracts;
using System;
using System.Linq;

namespace MonopolyRunner.App
{
    class Program
    {
        static Board gameBoard = Board
            .Setup(GameSquares.TraditionalGame.ToArray());
        static Random randomiser = new Random();
        static void Main(string[] args)
        {
            var key = default(ConsoleKeyInfo);
            Console.WriteLine("Hello World!");
            gameBoard.AddPlayer("Romesh");
            gameBoard.AddPlayer("Krish");

            while (key == default || key.Key != ConsoleKey.Escape)
            {
                var currentPlayer = gameBoard.GetNextPlayer();
                var roll = Roll();
                Console.WriteLine("({0:C0}):{1} has rolled a {2} and a {3}",
                    currentPlayer.Balance,
                    currentPlayer.Name,
                    roll.FirstDieValue,
                    roll.SecondDieValue);
                var currentSquare = SetPiece(gameBoard, currentPlayer, roll);

                Player owedPlayer = default;

                if (IsPurchaseable(gameBoard, currentSquare, out var propertyGameSquare))
                {
                    Console.WriteLine("Would you like to purchase {0}? Y/N", currentSquare.Name);


                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        currentPlayer.Pay(
                            currentSquare.Value, 
                            property: propertyGameSquare);
                    }
                }
                else if(propertyGameSquare != default 
                    && IsPropertySquareOwned(gameBoard, propertyGameSquare)
                    && (owedPlayer = GetOwner(gameBoard, propertyGameSquare)) != currentPlayer)
                {
                    currentPlayer.Pay(propertyGameSquare.CalculateRent(), owedPlayer);
                }

                Console.WriteLine("{0} has landed on {1} ({2})",
                    currentPlayer.Name,
                    currentSquare.Name,
                    currentSquare.Type);

                key = Console.ReadKey();
            }
        }

        static RollAttempt Roll(int minumumValue = 1, int maximumValue = 6)
        {
            return new RollAttempt(
                randomiser.Next(minumumValue, maximumValue),
                randomiser.Next(minumumValue, maximumValue));
        }

        static bool IsPurchaseable(Board board, IGameSquare gameSquare, out PropertyGameSquare propertyGameSquare)
        {
            propertyGameSquare = default;

            if (gameSquare is PropertyGameSquare propGameSquare)
            {
                propertyGameSquare = propGameSquare;
                return !IsPropertySquareOwned(board, propertyGameSquare);
            }

            return false;
        }

        public static bool IsPropertySquareOwned(Board board, PropertyGameSquare propertyGameSquare)
        {
            return board.Players.Any(player => player.OwnedProperties.Any(property => property == propertyGameSquare));
        }

        public static Player GetOwner(Board board, PropertyGameSquare propertyGameSquare)
        {
            return board.Players.FirstOrDefault(player => player.OwnedProperties.Any(property => property == propertyGameSquare));
        }

        static IGameSquare SetPiece(Board gameBoard, Player player, RollAttempt rollAttempt)
        {
            ushort newPosition = player.SetPosition(rollAttempt.TotalValue);

            if (player.PassedGo)
            {
                player.Pay(GameRules.AmountRecievedWhenPassedGo);
            }

            return gameBoard.GetGameSquare(newPosition);
        }

        static IGameSquare SetPiece(Board gameBoard, int playerId, RollAttempt rollAttempt)
        {
            return SetPiece(gameBoard, gameBoard.GetPlayer(playerId), rollAttempt);
        }
    }
}
