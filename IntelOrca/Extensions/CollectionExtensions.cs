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
using System.Linq;

namespace IntelOrca.Extensions
{
	public static class CollectionExtensions
	{
		public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
		{
			foreach (T item in items)
				collection.Add(item);
		}

        /// <summary>
        /// Removes multiple items from the collection.
        /// </summary>
        /// <typeparam name="T">The item type.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="items">The items to remove.</param>
        public static void RemoveRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (T item in items)
                collection.Remove(item);
        }

		/// <summary>
		/// Removes all the elements that match the conditions defined by the specified predicate.
		/// </summary>
		/// <typeparam name="T">The element type.</typeparam>
		/// <param name="collection">The collection.</param>
		/// <param name="match">The predicate delegate that defines the conditions of the elements to remove.</param>
		/// <returns>The number of elements removed from the collection.</returns>
		public static int RemoveAll<T>(this ICollection<T> collection, Predicate<T> match)
		{
			T[] elementsToRemove = collection.Where(x => match(x)).ToArray();
			foreach (T item in elementsToRemove)
				collection.Remove(item);
			return elementsToRemove.Length;
		}
	}
}