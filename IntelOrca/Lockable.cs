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

namespace IntelOrca
{
	/// <summary>
	/// Class to keep an object to lock and its sync object that is actually locked together.
	/// </summary>
	/// <example>
	/// <code>
	/// <![CDATA[
	/// Lockable<List<int>> someList = new Lockable<List<int>>(new List<int>());
	/// lock (someList.Sync) {
	///     List<int> list = someList;
	///     list.Add(2);
	///     list.Add(5);
	///     list.Add(9);
	/// }
	/// ]]>
	/// </code>
	/// </example>
	public sealed class Lockable<T> where T : class
	{
		private readonly T _instance;
		private readonly object _sync;

		/// <summary>
		/// Initialises a new instance of the <see cref="Lockable{T}"/> class.
		/// </summary>
		/// <param name="instance">The instance.</param>
		public Lockable(T instance)
		{
			_instance = instance;
			_sync = new object();
		}

		/// <summary>
		/// Gets the instance of the object to synchronise access to.
		/// </summary>
		public T Instance { get { return _instance; } }

		/// <summary>
		/// Gets the object to lock.
		/// </summary>
		public object Sync { get { return _sync; } }

		public static implicit operator T(Lockable<T> lockable) { return lockable.Instance; }
	}
}
