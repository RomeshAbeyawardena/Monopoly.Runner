using MonopolyRunner.Domains.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyRunner.Domains
{
    public class Player
    {
        public Player(Board board, string name, long balance)
        {
            Board = board;
            Name = name;
            Balance = balance;
        }

        public string Name { get; }
        public IGameSquare CurrentGameSquare => Board.GetGameSquare(CurrentTileIndex);
        public ushort CurrentTileIndex { get; private set; }
        public long Balance { get; private set; }
        public Board Board { get; }
        public bool PassedGo { get; private set; }

        public static bool operator ==(Player player, Player otherPlayer)
        {
            return player.Equals(otherPlayer);
        }

        public static bool operator !=(Player player, Player otherPlayer)
        {
            return !player.Equals(otherPlayer);
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || !(obj is Player player))
            {
                return false;
            }

            // TODO: write your implementation of Equals() here
            return Name.Equals(player.Name);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            return HashCode.Combine(Name);
        }

        public IEnumerable<PropertyGameSquare> OwnedProperties { get; private set; }

        public ushort SetPosition(ushort newPosition)
        {
            var newTileIndex = CurrentTileIndex + newPosition;
            if(newTileIndex >= Board.TotalGameSquares)
            { 
                //calculate difference
                var difference =  newTileIndex - Board.TotalGameSquares;
                PassedGo = true;
                return CurrentTileIndex = Convert.ToUInt16(difference);
            }
            PassedGo = false;
            return CurrentTileIndex += newPosition;
        }

        public long Pay (
            long amount, 
            Player recipient = default, 
            PropertyGameSquare property = default)
        {
            if(recipient != default)
            {
                recipient.Pay(amount);
                return Balance -= amount;
            }

            if(property != default)
            {
                if(property.Value > Balance)
                    throw new Exception($"Player {Name} can't afford this property ({property.Name})");

                var ownedPropertyList = new List<PropertyGameSquare>(OwnedProperties)
                {
                    property
                };

                OwnedProperties = ownedPropertyList;

                return Balance -= amount;
            }

            return Balance += amount;
        }
    }
}
