using System;
using System.Collections.Generic;

namespace MonopolyRunner.Domains
{
    public static class ArrayBuilder
    {
        public static ArrayBuilder<T> Build<T>(params T[] values)
        {
            return new ArrayBuilder<T>(values);
        }
    }

    public class ArrayBuilder<T>
    {
        public ArrayBuilder(params T[] values)
        {
            Result = values;
        }

        public IEnumerable<T> Result { get; }
    }
}
