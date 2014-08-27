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
using System.Threading.Tasks;

namespace IntelOrca.Extensions
{
	public static class TaskExtensions
	{
		/// <summary>
		/// Waits for the task to finish.
		/// </summary>
		/// <param name="task">The task.</param>
		public static void RunSync(this Task task)
		{
			task.Wait();
		}

		/// <summary>
		/// Waits for the task to finish and returns its result.
		/// </summary>
		/// <typeparam name="T">The result type.</typeparam>
		/// <param name="task">The task.</param>
		/// <returns>The result of the task.</returns>
		public static T RunSync<T>(this Task<T> task)
		{
			task.Wait();
			return task.Result;
		}
	}
}