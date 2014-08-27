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
using System.IO;
using System.Text;

namespace IntelOrca.Extensions
{
	public static class IOExtensions
	{
		/// <summary>
		/// Reads a null terminated ascii string.
		/// </summary>
		/// <param name="br">The binary reader.</param>
		/// <returns>A string representing the contents read in. Never null.</returns>
		public static string ReadNullTerminatedString(this BinaryReader br)
		{
			var sb = new StringBuilder();
			byte b;
			while ((b = br.ReadByte()) != 0) {
				sb.Append((char)b);
			}
			return sb.ToString();
		}

		/// <summary>
		/// Writes a null terminated ascii string.
		/// </summary>
		/// <param name="bw">The binary writer.</param>
		/// <param name="s">The string to write.</param>
		public static void WriteNullTerminatedString(this BinaryWriter bw, string s)
		{
			if (!String.IsNullOrEmpty(s))
				bw.Write(Encoding.ASCII.GetBytes(s));
			bw.Write((byte)0);
		}
	}
}