using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyRunner.Domains.Constants;
using MonopolyRunner.Domains.Contracts;
using MonopolyRunner.Domains.Extensions;

namespace MonopolyRunner.Domains
{
    public class Board
    {
        public static Board Setup(params IGameSquare[] gameSquares)
        {
            return new Board(gameSquares);
        }

        private Board(IEnumerable<IGameSquare> gameSquares)
        {
            GameSquares = gameSquares;
            Players = new List<Player>();
        }

        public IEnumerable<IGameSquare> GameSquares { get; }

        public int TotalGameSquares => GameSquares.Count();
        
        public int TotalPlayers => Players.Count();

        public IEnumerable<Player> Players { get; private set; }

        public Player CurrentPlayer => GetPlayer(CurrentPlayerIndex);

        public Player AddPlayer(string name, long amount = default)
        {
            if(amount == default)
            { 
                amount = GameRules.PlayerStartingAmount;
            }

            var player = new Player(this, name, amount);
            
            Players = Players.Append(player);
            return player;
        }

        public Player GetPlayer(int playerId)
        {
            return Players.GetByIndex(playerId);
        }

        public Player GetNextPlayer()
        {
            if(CurrentPlayerIndex + 1 > TotalPlayers - 1)
            {
                CurrentPlayerIndex = 0;
            }
            else
            {
                CurrentPlayerIndex++;
            }

            return GetPlayer(CurrentPlayerIndex);
        }

        public IGameSquare GetGameSquare(int squareId)
        {
            return GameSquares.GetByIndex(squareId);
        }

        public int CurrentPlayerIndex { get; private set; }
    }
}
