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
	/// Represents a complex number, a number expressed with a real and imaginary component.
	/// </summary>
	public struct ComplexNumber : IEquatable<ComplexNumber>
	{
		/// <summary>
		/// Gets the real component of the complex number.
		/// </summary>
		public double Real { get; set; }

		/// <summary>
		/// Gets the imaginary component of the complex number.
		/// </summary>
		public double Imaginary { get; set; }

		/// <summary>
		/// Gets the magnitude of the complex number, where real, imaginary are X and Y respectively.
		/// </summary>
		public double Magnitude { get { return Math.Sqrt(Real * Real + Imaginary * Imaginary); } }

		/// <summary>
		/// Initialises a new instance of the <see cref="ComplexNumber"/> struct.
		/// </summary>
		/// <param name="real">The real.</param>
		/// <param name="imaginary">The imaginary.</param>
		public ComplexNumber(double real, double imaginary) : this()
		{
			Real = real;
			Imaginary = imaginary;
		}

		/// <summary>
		/// Determines whether the specified <see cref="System.Object" }, is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
		/// <returns>
		///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		public override bool Equals(object obj)
		{
			return Equals((ComplexNumber)obj);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
		public bool Equals(ComplexNumber other)
		{
			return Real == other.Real && Imaginary == other.Imaginary;
		}

		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		public override int GetHashCode()
		{
			int hash = 13;
			hash = (hash * 7) + Real.GetHashCode();
			hash = (hash * 7) + Imaginary.GetHashCode();
			return hash;
		}

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>A <see cref="System.String" /> that represents this instance.</returns>
		public override string ToString()
		{
			return String.Format("{0} + {1}i", Real, Imaginary);
		}
	}
}
