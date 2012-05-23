using System;

namespace Gojo.Core.Data.MultiValueDictionary
{
	/// <summary>
	/// Class which contains argument verification logic and which can throw exceptions if necessary. This code makes it easier to verify input arguments. 
	/// </summary>
	public static class ArgumentVerifier
	{
		/// <summary>
		/// Checks the argument passed in. if it's null, it throws an ArgumentNullException
		/// </summary>
		/// <param name="argument">The argument.</param>
		/// <param name="name">The name.</param>
		public static void CantBeNull(object argument, string name)
		{
			if(argument == null)
			{
				throw new ArgumentNullException(name);
			}
		}


		/// <summary>
		/// Checks if the argument returns true with the func passed in. If not, it throws an ArgumentException with the error message specified. 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="checkFunc">The check func.</param>
		/// <param name="argument">The argument.</param>
		/// <param name="formattedError">The formatted error message.</param>
		public static void ShouldBeTrue<T>(Func<T, bool> checkFunc, T argument, string formattedError)
		{
			CantBeNull(checkFunc, "checkFunc");
			if(!checkFunc(argument))
			{
				throw new ArgumentException(formattedError);
			}
		}
	}
}
