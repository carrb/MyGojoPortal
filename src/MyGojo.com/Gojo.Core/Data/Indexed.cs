using System;
using System.Linq;
using System.Text;

namespace Gojo.Core.Data.Collections
{
    // See http://www.kodefuguru.com/post/2011/04/17/Indexed-Sequences.aspx
    // and http://haacked.com/archive/2011/04/14/a-better-razor-foreach-loop.aspx

    public class Indexed<T>
    {
        public int Index { get; private set; }
        public T Value { get; private set; }

        public Indexed(int index, T value)
        {
            Index = index;
            Value = value;
        }

        public Indexed<TU> Select<TU>(Func<T, TU> selector)
        {
            return Indexed.Create(Index, selector(Value));
        }
    }

    public static class Indexed
    {
        public static Indexed<T> Create<T>(int index, T item)
        {
            return new Indexed<T>(index, item);
        }
    }
}
