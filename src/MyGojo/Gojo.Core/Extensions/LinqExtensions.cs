using System;
using System.Collections.Generic;
using System.Linq;

namespace Gojo.Core.Extensions
{

    public static class LinqExtenions
    {
        /// <summary>
        /// Groups the elements of a sequence according to a specified firstKey selector function and 
        /// rotates the unique values from the secondKey selector function into multiple values in the output, 
        /// and performs aggregations. 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TFirstKey"></typeparam>
        /// <typeparam name="TSecondKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="source"></param>
        /// <param name="firstKeySelector"></param>
        /// <param name="secondKeySelector"></param>
        /// <param name="aggregate"></param>
        /// <returns></returns>
        /// 
        /// SomeList<>().Pivot( ... )
        /// 
        /// See: http://www.extensionmethod.net/Details.aspx?ID=147
        public static Dictionary<TFirstKey, Dictionary<TSecondKey, TValue>>  Pivot<TSource, TFirstKey, TSecondKey, TValue>(this IEnumerable<TSource> source, 
                                                                                                                            Func<TSource, TFirstKey> firstKeySelector, 
                                                                                                                            Func<TSource, TSecondKey> secondKeySelector, 
                                                                                                                            Func<IEnumerable<TSource>, TValue> aggregate)
        {
            var retVal = new Dictionary<TFirstKey, Dictionary<TSecondKey, TValue>>();

            var l = source.ToLookup(firstKeySelector);
            foreach (var item in l)
            {
                var dict = new Dictionary<TSecondKey, TValue>();
                retVal.Add(item.Key, dict);
                var subdict = item.ToLookup(secondKeySelector);
                foreach (var subitem in subdict)
                {
                    dict.Add(subitem.Key, aggregate(subitem));
                }
            }

            return retVal;
        }

    }
}