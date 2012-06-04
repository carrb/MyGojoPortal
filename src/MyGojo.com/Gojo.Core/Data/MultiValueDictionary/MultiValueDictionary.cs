using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Gojo.Core.Data.MultiValueDictionary
{
	/// <summary>
	/// Extension to the normal Dictionary. This class can store more than one value for every key. It keeps a HashSet for every Key value.
	/// Calling Add with the same Key and multiple values will store each value under the same Key in the Dictionary. Obtaining the values
	/// for a Key will return the HashSet with the Values of the Key. 
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TValue">The type of the value.</typeparam>
	public class MultiValueDictionary<TKey, TValue> : Dictionary<TKey, HashSet<TValue>>, ILookup<TKey, TValue>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MultiValueDictionary&lt;TKey, TValue&gt;"/> class.
		/// </summary>
		public MultiValueDictionary()
			: base()
		{
		}


		/// <summary>
		/// Adds the specified value under the specified key
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		public void Add(TKey key, TValue value)
		{
			ArgumentVerifier.CantBeNull(key, "key");

			HashSet<TValue> container;
			if(!TryGetValue(key, out container))
			{
				container = new HashSet<TValue>();
				Add(key, container);
			}
			container.Add(value);
		}


		/// <summary>
		/// Adds the range of values under the key specified.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="values">The values.</param>
		public void AddRange(TKey key, IEnumerable<TValue> values)
		{
			if(values==null)
			{
				return;
			}

			foreach(TValue value in values)
			{
				Add(key, value);
			}
		}


		/// <summary>
		/// Determines whether this dictionary contains the specified value for the specified key 
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		/// <returns>true if the value is stored for the specified key in this dictionary, false otherwise</returns>
		public bool ContainsValue(TKey key, TValue value)
		{
			ArgumentVerifier.CantBeNull(key, "key");
			bool toReturn = false;
			HashSet<TValue> values;
			if(TryGetValue(key, out values))
			{
				toReturn = values.Contains(value);
			}
			return toReturn;
		}


		/// <summary>
		/// Removes the specified value for the specified key. It will leave the key in the dictionary.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		public void Remove(TKey key, TValue value)
		{
			ArgumentVerifier.CantBeNull(key, "key");

			HashSet<TValue> container;
			if(TryGetValue(key, out container))
			{
				container.Remove(value);
				if(container.Count <= 0)
				{
					Remove(key);
				}
			}
		}


		/// <summary>
		/// Merges the specified multivaluedictionary into this instance.
		/// </summary>
		/// <param name="toMergeWith">To merge with.</param>
		public void Merge(MultiValueDictionary<TKey, TValue> toMergeWith)
		{ 
			if(toMergeWith==null)
			{
				return;
			}

			foreach(KeyValuePair<TKey, HashSet<TValue>> pair in toMergeWith)
			{
				foreach(TValue value in pair.Value)
				{
					Add(pair.Key, value);
				}
			}
		}


		/// <summary>
		/// Gets the values for the key specified. This method is useful if you want to avoid an exception for key value retrieval and you can't use TryGetValue
		/// (e.g. in lambdas)
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="returnEmptySet">if set to true and the key isn't found, an empty hashset is returned, otherwise, if the key isn't found, null is returned</param>
		/// <returns>
		/// This method will return null (or an empty set if returnEmptySet is true) if the key wasn't found, or
		/// the values if key was found.
		/// </returns>
		public HashSet<TValue> GetValues(TKey key, bool returnEmptySet)
		{
			HashSet<TValue> toReturn;
			if(!TryGetValue(key, out toReturn) && returnEmptySet)
			{
				toReturn = new HashSet<TValue>();
			}
			return toReturn;
		}


		#region ILookup<TKey,TValue> Members
		/// <summary>
		/// Determines whether a specified key exists in the <see cref="T:System.Linq.ILookup`2"/>.
		/// </summary>
		/// <param name="key">The key to search for in the <see cref="T:System.Linq.ILookup`2"/>.</param>
		/// <returns>
		/// true if <paramref name="key"/> is in the <see cref="T:System.Linq.ILookup`2"/>; otherwise, false.
		/// </returns>
		bool ILookup<TKey, TValue>.Contains(TKey key)
		{
			return ContainsKey(key);
		}


		/// <summary>
		/// Gets the number of key/value pairs contained in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </summary>
		/// <value></value>
		/// <returns>
		/// The number of key/value pairs contained in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </returns>
		int ILookup<TKey, TValue>.Count
		{
			get { return Count; }
		}


		/// <summary>
		/// Gets the <see cref="System.Collections.Generic.IEnumerable&lt;TValue&gt;"/> with the specified key.
		/// </summary>
		/// <value></value>
		IEnumerable<TValue> ILookup<TKey, TValue>.this[TKey key]
		{
			get { return GetValues(key, true); }
		}
		#endregion


		#region IEnumerable<IGrouping<TKey,TValue>> Members
		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
		/// </returns>
		IEnumerator<IGrouping<TKey, TValue>> IEnumerable<IGrouping<TKey, TValue>>.GetEnumerator()
		{
			foreach(KeyValuePair<TKey, HashSet<TValue>> pair in this)
			{
				yield return new Grouping<TKey, TValue>(pair.Key, pair.Value);
			}
		}
		#endregion

		#region IEnumerable Members
		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		#endregion
	}
}
