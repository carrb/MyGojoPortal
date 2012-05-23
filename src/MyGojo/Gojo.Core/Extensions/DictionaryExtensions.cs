using System;
using System.Collections.Generic;
using System.Linq;

namespace Gojo.Core.Extensions
{
    public static class DictionaryExtensions
    {
        /// Execute action inside a dictionary when the key is present. When key is not present do nothing.
        /// Returns:    TRUE when action was found
        ///             FALSE otherwise
        ///         
        public static bool OnValue<T>(this Dictionary<T, Action> dict, T key) where T : class
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            Action acc;

            if (dict.TryGetValue(key, out acc))
            {
                acc();
                return true;
            }

            return false;
        }


        /// Execute action inside a dictionary with given parameter. When key is not present do nothing.
        /// Returns:    TRUE if action was found. 
        ///             FALSE when parameter was null. 
        ///             NULL when no action for given key was found
        /// 
        /// When the parameter is null the action will NOT be called since we expect some data to work with.
        /// Besides this it makes error handling in the actions easier when they can rely on a non-null input argument.
        /// 
        public static bool? OnValueAndParameterNotNull<T>(this Dictionary<T, Action<T>> dict, T key, T parameter) where T : class
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            Action<T> acc;

            if (dict.TryGetValue(key, out acc))
            {
                if (parameter == null)
                {
                    return false;
                }

                acc(parameter);
                return true;
            }

            return null;
        }


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
        public static Dictionary<TFirstKey, Dictionary<TSecondKey, TValue>> Pivot<TSource, TFirstKey, TSecondKey, TValue>(this IEnumerable<TSource> source,
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
