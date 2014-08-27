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
	public static class ArrayExtensions
	{
		/// <summary>
		/// Gets a generic IEnumerator from an array as .NET seems to lack this.
		/// </summary>
		/// <typeparam name="T">The array type.</typeparam>
		/// <param name="array">The array.</param>
		/// <returns>The array's enumerator.</returns>
		public static IEnumerator<T> GetGenericEnumerator<T>(this T[] array)
		{
			return ((IEnumerable<T>)array).GetEnumerator();
		}

		/// <summary>
		/// Creates a new array containing a subset of elements from the current array.
		/// </summary>
		/// <typeparam name="T">Array element type.</typeparam>
		/// <param name="data">Current array.</param>
		/// <param name="index">Start index.</param>
		/// <param name="length">Number of elements to copy.</param>
		/// <returns>The new array.</returns>
		public static T[] GetRange<T>(this T[] data, int index, int length)
		{
			T[] result = new T[length];
			Array.Copy(data, index, result, 0, length);
			return result;
		}
	}
}