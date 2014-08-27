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

namespace IntelOrca.Extensions
{
	public static class RandomExtensions
	{
		public static double NextSignedDouble(this Random random)
		{
			return (random.NextDouble() * 2.0) - 1.0;
		}

		public static double NextRadians(this Random random)
		{
			return NextSignedDouble(random) * Math.PI;
		}
	}
}