using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Gojo.Core.Data.MultiValueDictionary
{
	/// <summary>
	/// Class which implements the IGrouping interface to return grouped results in a query
	/// </summary>
	/// <typeparam name="TKey">type of the grouping key</typeparam>
	/// <typeparam name="TElement">type of the elements grouped</typeparam>
	public class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
	{
		#region Class Member Declarations
		private readonly TKey _key;
		private readonly IEnumerable<TElement> _elements;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="Grouping&lt;TKey, TElement&gt;"/> class.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="elements">The grouped elements.</param>
		public Grouping(TKey key, IEnumerable<TElement> elements)
		{
			_key = key;
			_elements = elements;
		}


		/// <summary>
		/// Gets the key of the <see cref="T:System.Linq.IGrouping`2"/>.
		/// </summary>
		/// <returns>The key of the <see cref="T:System.Linq.IGrouping`2"/>.</returns>
		TKey IGrouping<TKey, TElement>.Key
		{
			get { return _key; }
		}
		
		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
		/// </returns>
		public IEnumerator<TElement> GetEnumerator()
		{
			if(_elements==null)
			{
				return null;
			}
			return _elements.GetEnumerator();
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}
