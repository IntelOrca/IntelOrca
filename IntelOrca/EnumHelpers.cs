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
	public static class EnumHelpers
	{
		/// <summary>
		/// Gets the total number of enumerations in a enumeration type.
		/// </summary>
		/// <param name="enumeration">The enumeration type.</param>
		/// <returns>The number of enumeration entries in the enumeration type.</returns>
		public static int GetEnumCount(Type enumeration)
		{
			return Enum.GetNames(enumeration).Length;
		}
	}
}