using System;
using System.Collections.Generic;

namespace Gojo.Core.Data.MultiValueDictionary
{
	/// <summary>
	/// Extension methods for classes defined in the GeneralDataStructures namespace
	/// </summary>
	public static class ExtensionMethods
	{
		/// <summary>
		/// Converts an enumerable into a MultiValueDictionary. Similar to ToDictionary however this time the returned type is a MultiValueDictionary.
		/// </summary>
		/// <typeparam name="TKey">The type of the key.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="source">The source.</param>
		/// <param name="keySelectorFunc">The key selector func.</param>
		/// <returns>MultiValueDictionary with the values of source stored under the keys retrieved by the keySelectorFunc which is applied to each
		/// value in source, or null if source is null</returns>
		public static MultiValueDictionary<TKey, TValue> ToMultiValueDictionary<TKey, TValue>(this IEnumerable<TValue> source, Func<TValue, TKey> keySelectorFunc)
		{
			if(source==null)
			{
				return null;
			}

			ArgumentVerifier.CantBeNull(keySelectorFunc, "keySelectorFunc");
			MultiValueDictionary<TKey, TValue> toReturn = new MultiValueDictionary<TKey, TValue>();
			foreach(TValue v in source)
			{
				toReturn.Add(keySelectorFunc(v), v);
			}
			return toReturn;
		}
	}
}
