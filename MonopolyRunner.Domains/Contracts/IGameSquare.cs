using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyRunner.Domains.Contracts
{
    public interface IGameSquare
    {
        string Name { get; }
        string Description { get; }
        long Value { get; }
        GameSquareType Type { get; }
    }
}
