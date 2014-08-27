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
	/// <summary>
	/// Disposable helper class.
	/// </summary>
	public class Disposable : IDisposable
	{
		private readonly Action _action;

		/// <summary>
		/// Prevents a default instance of the <see cref="Disposable"/> class from being created.
		/// </summary>
		/// <param name="action">The action.</param>
		private Disposable(Action action)
		{
			_action = action;
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			if (_action != null)
				_action();
		}

		/// <summary>
		/// Creates a new object which when disposed, invokes the specified action.
		/// </summary>
		/// <param name="action">The action to call when disposed.</param>
		/// <returns>A disposable object.</returns>
		public static IDisposable FromAction(Action action)
		{
			return new Disposable(action);
		}
	}
}
