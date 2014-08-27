#region Copyright (c) Ted John. 2014. All rights reserved.

// Copyright (c) Ted John. 2014. All rights reserved.
//
// This source is subject to a License.
// Please see the license.txt file for more information.
// All other rights reserved.
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY 
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.

#endregion

using System;
using System.Collections.Generic;

namespace IntelOrca.Extensions
{
	public static class DictionaryExtensions
	{
		/// <summary>
		/// Gets the value for a given key and returns a default value if not found.
		/// </summary>
		/// <typeparam name="Tkey">The key type.</typeparam>
		/// <typeparam name="Tvalue">The value type.</typeparam>
		/// <param name="dictionary">The dictionary.</param>
		/// <param name="key">The key.</param>
		/// <returns>
		/// The <typeparamref name="Tvalue"/> represented by <paramref name="key"/> or its default value if it was not found in
		/// the dictionary.
		/// </returns>
		public static Tvalue GetValueOrDefault<Tkey, Tvalue>(this IDictionary<Tkey, Tvalue> dictionary, Tkey key)
		{
			Tvalue value;
			return dictionary.TryGetValue(key, out value) ? value : default(Tvalue);
		}

		/// <summary>
		/// Gets the value for a given key and returns a default value if not found.
		/// </summary>
		/// <typeparam name="Tkey">The key type.</typeparam>
		/// <typeparam name="Tvalue">The value type.</typeparam>
		/// <param name="dictionary">The dictionary.</param>
		/// <param name="key">The key.</param>
		/// <returns>
		/// The <typeparamref name="Tvalue"/> represented by <paramref name="key"/> or its default value if it was not found in
		/// the dictionary.
		/// </returns>
		public static Tvalue GetValueOrDefault<Tkey, Tvalue>(this IDictionary<Tkey, Tvalue> dictionary, Tkey key,
			Tvalue defaultValue)
		{
			Tvalue value;
			return dictionary.TryGetValue(key, out value) ? value : defaultValue;
		}
	}
}