using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyRunner.Domains
{
    public class RollAttempt
    {
        public RollAttempt(int firstDieValue, int secondDieValue)
            : this(Convert.ToUInt16(firstDieValue), Convert.ToUInt16(secondDieValue))
        {

        }

        public RollAttempt(ushort firstDieValue, ushort secondDieValue)
        {
            FirstDieValue = firstDieValue;
            SecondDieValue = secondDieValue;
        }

        public ushort FirstDieValue { get; }
        public ushort SecondDieValue { get; }

        public ushort TotalValue => Convert.ToUInt16(FirstDieValue + SecondDieValue);
    }
}
