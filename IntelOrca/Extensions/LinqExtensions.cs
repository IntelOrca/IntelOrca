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
	public static class LinqExtensions
	{
		public static T[] AsArray<T>(this IEnumerable<T> items)
		{
			T[] result = items as T[];
			if (result == null)
				result = items.ToArray();
			return result;
		}
		
		/// <summary>
		/// Calculates a hash code from multiple items such as a collection.
		/// </summary>
		/// <param name="e">The items.</param>
		/// <returns>A hash code for the input <see cref="IEnumerable"/>.</returns>
		public static int GetCollectionHashCode<T>(this IEnumerable<T> e)
		{
			IEnumerator<T> enumerator = e.GetEnumerator();
			int hash = 27;

			// First item
			if (enumerator.MoveNext()) {
				hash *= enumerator.Current == null ? -1.GetHashCode() : enumerator.Current.GetHashCode();
			}
			
			// Successive items
			while (enumerator.MoveNext())
				hash = (13 * hash) + (enumerator.Current == null ? -1.GetHashCode() : enumerator.Current.GetHashCode());
			
			return hash;
		}

		/// <summary>
		/// Calculates a hash code from multiple items.
		/// </summary>
		/// <param name="items">The items.</param>
		/// <returns>A hash code.</returns>
		public static int GetCollectionHashCode(params object[] items)
		{
			return GetCollectionHashCode((IEnumerable<object>)items);
		}

		/// <summary>
		/// Checks if an enumerable contains the same collection of elements as another enumerable.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="first"></param>
		/// <param name="second"></param>
		/// <returns>True if it has exactly and no more than the same elements in both sequences.</returns>
		public static bool HasSameElementsAs<T>(this IEnumerable<T> first, IEnumerable<T> second)
		{
			var firstMap = first
				.GroupBy(x => x)
				.ToDictionary(x => x.Key, x => x.Count());
			var secondMap = second
				.GroupBy(x => x)
				.ToDictionary(x => x.Key, x => x.Count());
			return
				firstMap.Keys.All(x =>
					secondMap.Keys.Contains(x) && firstMap[x] == secondMap[x]
				) &&
				secondMap.Keys.All(x =>
					firstMap.Keys.Contains(x) && secondMap[x] == firstMap[x]
				);
		}

		/// <summary>
		/// Concatenates multiple strings together using commas and 'and'.
		/// </summary>
		/// <param name="strings"></param>
		/// <returns>A comma / and seperated string of input strings or empty string if there are no input strings.</returns>
		public static string CommaAndConcatenation<T>(this IEnumerable<T> strings)
		{
			var stringsArray = strings.ToArray();
			if (stringsArray.Length == 0)
				return String.Empty;
			if (stringsArray.Length == 1)
				return stringsArray[0].ToString();
			if (stringsArray.Length == 2)
				return String.Format("{0} and {1}", stringsArray[0], stringsArray[1]);

			/**
			 * Return a comma seperated sequence of names with the exception of the last name
			 * which is glued together with 'and'
			 */
			return String.Format("{0} and {1}",
				String.Join(", ", stringsArray.Take(stringsArray.Length - 1)),
				stringsArray.Last()
			);
		}

		public static IEnumerable<T> TakeAllButLast<T>(this IEnumerable<T> source)
		{
			var it = source.GetEnumerator();
			bool hasRemainingItems = false;
			bool isFirst = true;
			T item = default(T);

			do {
				hasRemainingItems = it.MoveNext();
				if (hasRemainingItems) {
					if (!isFirst) yield return item;
					item = it.Current;
					isFirst = false;
				}
			} while (hasRemainingItems);
		}

		public static IEnumerable<T> Intersperse<T>(this IEnumerable<T> source, T separator)
		{
			bool first = true;
			foreach (T value in source) {
				if (!first)
					yield return separator;
				yield return value;
				first = false;
			}
		}

		public static IEnumerable<IEnumerable<T>> SplitWhen<T>(this IEnumerable<T> source, Func<T, bool> shouldSplit)
		{
			var currentGroup = new List<T>();
			foreach (T item in source) {
				if (shouldSplit(item) && currentGroup.Count > 0) {
					yield return currentGroup.ToArray();
					currentGroup.Clear();
				}
				currentGroup.Add(item);
			}
			if (currentGroup.Count > 0)
				yield return currentGroup.ToArray();
		}

		public static bool Contains(this IEnumerable<string> items, string query, bool ignoreCase = false)
		{
			return items.Any(x => String.Compare(x, query, ignoreCase) == 0);
		}

		public static string FirstOrDefault(this IEnumerable<string> items, string query, bool ignoreCase = false)
		{
			return items.FirstOrDefault(x => String.Compare(x, query, ignoreCase) == 0);
		}

		public static IEnumerable<string> Surround(this IEnumerable<string> strings, string surrounder)
		{
			return strings.Select(x => surrounder + x + surrounder);
		}
	}
}