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
using System.Linq;
using System.Xml;

namespace IntelOrca.Extensions
{
	public static class XmlExtensions
	{
		/// <summary>
		/// Gets the inner text of a node or a default value if the node doesn't exist.
		/// </summary>
		/// <param name="node">The parent node.</param>
		/// <param name="xpath">The target node path.</param>
		/// <param name="defaultValue">The default value.</param>
		/// <returns>The inner text or <paramref name="defaultValue">default value</paramref>.</returns>
		public static string GetNodeInnerText(this XmlNode node, string xpath, string defaultValue)
		{
			string value;
			if (!TryGetNodeInnerText(node, xpath, out value))
				value = defaultValue;
			return value;
		}

		/// <summary>
		/// Tries to get the inner text of a node.
		/// </summary>
		/// <param name="node">The parent node.</param>
		/// <param name="xpath">The target node path.</param>
		/// <param name="value">The output inner next.</param>
		/// <returns>True if the node existed and inner text could be retrieved, otherwise false.</returns>
		public static bool TryGetNodeInnerText(this XmlNode node, string xpath, out string value)
		{
			XmlNode child = node.SelectSingleNode(xpath);
			if (child == null) {
				value = default(string);
				return false;
			} else {
				value = child.InnerText;
				return true;
			}
		}

		/// <summary>
		/// Tries to get the value of an attribute.
		/// </summary>
		/// <param name="node">The node containing the attribute.</param>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="value">The output value of the attribute.</param>
		/// <returns>True if the attribute existed, otherwise false.</returns>
		public static bool TryGetAttributeValue(this XmlNode node, string name, out string value)
		{
			XmlAttribute attribute = node.Attributes[name];
			if (attribute == null) {
				value = null;
				return false;
			} else {
				value = attribute.Value;
				return true;
			}
		}
	}
}