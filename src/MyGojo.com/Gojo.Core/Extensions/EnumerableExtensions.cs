using System;
using System.Collections.Generic;
using Gojo.Core.Data.Collections;

namespace Gojo.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<Indexed<T>> ToIndexed<T>(this IEnumerable<T> source)
        {
            var index = 0;

            foreach (T t in source)
            {
                yield return Indexed.Create(index, t);
                index++;
            }
        }

        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }
    }
}
