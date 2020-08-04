using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyRunner.Domains.Extensions
{
    public static class EnumerableExtensions
    {
        public static TItem GetByIndex<TItem>(this IEnumerable<TItem> items, int index)
        {
            var itemArray = items.ToArray(); 
            return itemArray[index];
        }
    }
}
