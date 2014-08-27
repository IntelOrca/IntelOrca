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
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace IntelOrca
{
	public static class AttributeHelpers
	{
		/// <summary>
		/// Gets the value of the description attribute on the specified object.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>A string of the type's description or null if there is no description attribute.</returns>
		public static string GetDescription(object value)
		{
			DescriptionAttribute descriptionAttribute = GetAttribute<DescriptionAttribute>(value);
			return descriptionAttribute == null ? null : descriptionAttribute.Description;
		}

		/// <summary>
		/// Gets an attribute from the given type or enum member.
		/// </summary>
		/// <typeparam name="T">The <see cref="Attribute"/> type.</typeparam>
		/// <param name="value">The type or enum member.</param>
		/// <returns>The attribute or null if there is no defined attribute.</returns>
		public static T GetAttribute<T>(object value) where T : Attribute
		{
			// Get type
			Type type = value as Type;
			if (type == null) {
				// Expecting an enum type
				type = value.GetType();
				if (!type.IsEnum)
					throw new ArgumentException("Value must be a Type or Enum value.", "value");

				return type.GetMember(value.ToString()).First().GetCustomAttribute<T>();
			} else {
				return type.GetCustomAttribute<T>();
			}
		}
	}
}