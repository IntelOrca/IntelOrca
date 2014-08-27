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

namespace IntelOrca
{
	public static class EquatableHelpers
	{
		/// <summary>
		/// Checks if two objects are equal by reference before checking if they are equal by value.
		/// </summary>
		/// <typeparam name="T">The object type.</typeparam>
		/// <param name="a">An object.</param>
		/// <param name="b">An object.</param>
		/// <returns>True if the two objects are equal by reference or by value, otherwise false.</returns>
		public static bool ReferenceThenValueEquals<T>(T a, T b) where T : IEquatable<T>
		{
			if (ReferenceEquals(a, b))
				return true;

			if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
				return false;

			return a.Equals(b);
		}
	}
}