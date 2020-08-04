using MonopolyRunner.Domains.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyRunner.Domains
{
    public class GameSquare : IGameSquare
    {
        public GameSquare(string name, string description, long value, GameSquareType type)
        {
            Name = name;
            Description = description;
            Value = value;
            Type = type;
        }

        public string Name { get; }

        public string Description { get; }

        public long Value { get; }

        public GameSquareType Type { get; }

        public static bool operator ==(GameSquare originalGameSquare, GameSquare gameSquare)
        {
            return originalGameSquare.Equals(gameSquare);
        }

        public static bool operator !=(GameSquare originalGameSquare, GameSquare gameSquare)
        {
            return !originalGameSquare.Equals(gameSquare);
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

            if (obj == null || !(obj is IGameSquare gameSquare) )
            {
                return false;
            }

            // TODO: write your implementation of Equals() here
            return gameSquare.Name.Equals(Name)
                && gameSquare.Description.Equals(Description)
                && gameSquare.Type.Equals(Type)
                && gameSquare.Value.Equals(Value);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            
            return HashCode.Combine(Name, Description, Value, Type);
        }

    }
}
