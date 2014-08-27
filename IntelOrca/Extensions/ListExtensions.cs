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
	public static class ListExtensions
	{
		/// <summary>
		/// Gets the index of the first item that matches a predicate.
		/// </summary>
		/// <typeparam name="T">The item type.</typeparam>
		/// <param name="list">The list.</param>
		/// <param name="startIndex">The start index.</param>
		/// <param name="match">The predicate.</param>
		/// <returns>The index of the first match or -1 if no match was found.</returns>
		public static int IndexOf<T>(this IReadOnlyList<T> list, Predicate<T> match)
		{
			return IndexOf(list, 0, match);
		}

		/// <summary>
		/// Gets the index of the first item that matches a predicate.
		/// </summary>
		/// <typeparam name="T">The item type.</typeparam>
		/// <param name="list">The list.</param>
		/// <param name="startIndex">The start index.</param>
		/// <param name="match">The predicate.</param>
		/// <returns>The index of the first match or -1 if no match was found.</returns>
		public static int IndexOf<T>(this IReadOnlyList<T> list, int startIndex, Predicate<T> match)
		{
			for (int i = startIndex; i < list.Count; i++)
				if (match(list[i]))
					return i;
			return -1;
		}
	}
}