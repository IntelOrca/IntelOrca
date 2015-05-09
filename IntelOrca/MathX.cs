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
	/// Provides extra mathematical functions that <see cref="System.Math"/> doesn't provide.
	/// </summary>
	public static class MathX
	{
		public const double TWOPI = Math.PI * 2.0;
		public const double PI_2 = Math.PI / 2.0;
		public const double PI_4 = Math.PI / 4.0;

		/// <summary>
		/// Returns a linear interpolation between two values by the specified ratio.
		/// </summary>
		/// <param name="a">Left value.</param>
		/// <param name="b">Right value.</param>
		/// <param name="t">
		/// The ratio to interpolate between <paramref name="a"/> and <paramref name="b"/>. 0 will return <paramref name="a"/>,
		/// 1 will return <paramref name="b"/>.
		/// </param>
		/// <returns>The linear interpolation between <paramref name="a"/> and <paramref name="b"/>.</returns>
		public static double Lerp(double a, double b, double t)
		{
			return (1 - t) * a + t * b;
		}

		/// <summary>
		/// Linear interpolation with minimum increment
		/// </summary>
		/// <param name="from">The starting value.</param>
		/// <param name="to">The target value.</param>
		/// <param name="amount">The amount of change.</param>
		/// <param name="minChange">The minimum increment.</param>
		/// <returns>The new value.</returns>
		public static double Lerp(double from, double to, double amount, double minChange)
		{
			double inc = (to - from) * amount;

			if (to > from) {
				from += (inc < minChange) ? minChange : inc;
				return (from > to) ? to : from;
			} else {
				from += (inc > -minChange) ? -minChange : inc;
				return (from < to) ? to : from;
			}
		}

		/// <summary>
		/// Wrapped linear interpolation
		/// </summary>
		/// <param name="from">The starting value.</param>
		/// <param name="to">The target value.</param>
		/// <param name="amount">The amount of change.</param>
		/// <param name="minValue">The minimum bound.</param>
		/// <param name="maxValue">The maximum bound.</param>
		/// <param name="minChange">The minimum increment.</param>
		/// <returns>The new value.</returns>
		public static double LerpWrap(double from, double to, double amount, double minValue, double maxValue,
			double minChange = 0)
		{
			double range = maxValue - minValue;
			double half = range / 2.0;

			from %= range;
			to %= range;

			while (to < from - half)
				to += range;
			while (to > from + half)
				to -= range;

			from = Lerp(from, to, amount, minChange);

			if (from < minValue)
				return from + range;
			if (from > maxValue)
				return from - range;
			return from;
		}

		/// <summary>
		/// Snaps a given value to a certain precision.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="precision">The precision.</param>
		/// <returns>The snapped value.</returns>
		public static double Snap(double value, double precision)
		{
			return Math.Round(value / precision) * precision;
		}

		/// <summary>
		/// Quick and easy method to determine if a value is between two other values, inclusive.
		/// </summary>
		/// <param name="a">The lower bound.</param>
		/// <param name="b">The variable.</param>
		/// <param name="c">The upper bound.</param>
		/// <returns>True if the <see cref="b"/> is between <see cref="a"/> and <see cref="c"/>, otherwise false.</returns>
		public static bool IsBetween(double a, double b, double c)
		{
			return a <= b && b <= c;
		}

		/// <summary>
		/// Clamp a value between two bounds.
		/// </summary>
		/// <param name="low">The lower bound.</param>
		/// <param name="value">The value to clamp.</param>
		/// <param name="high">The upper bound.</param>
		/// <returns>The clamped value.</returns>
		public static int Clamp(int low, int value, int high)
		{
			if (value < low)
				return low;
			if (value > high)
				return high;
			return value;
		}

		/// <summary>
		/// Clamp a value between a negative and positive bound.
		/// </summary>
		/// <param name="value">The value to clamp.</param>
		/// <param name="high">The upper (postive) bound which will be used for a negative lower bound.</param>
		/// <returns>The clamped value.</returns>
		public static int Clamp(int value, int high)
		{
			return Clamp(-high, value, high);
		}

		/// <summary>
		/// Clamp a value between two bounds.
		/// </summary>
		/// <param name="low">The lower bound.</param>
		/// <param name="value">The value to clamp.</param>
		/// <param name="high">The upper bound.</param>
		/// <returns>The clamped value.</returns>
		public static double Clamp(double low, double value, double high)
		{
			if (value < low)
				return low;
			if (value > high)
				return high;
			return value;
		}

		/// <summary>
		/// Clamp a value between a negative and positive bound.
		/// </summary>
		/// <param name="value">The value to clamp.</param>
		/// <param name="high">The upper (postive) bound which will be used for a negative lower bound.</param>
		/// <returns>The clamped value.</returns>
		public static double Clamp(double value, double high)
		{
			return Clamp(-high, value, high);
		}

		/// <summary>
		/// Increases or decreases the velocity of a value without crossing 0.
		/// </summary>
		/// <param name="x">The value.</param>
		/// <param name="amount">The amount to increase / decrease.</param>
		/// <returns>The new velocity.</returns>
		public static double ChangeSpeed(double x, double amount)
		{
			if (x < 0) {
				x -= amount;
				if (x > 0)
					x = 0;
			} else {
				x += amount;
				if (x < 0)
					x = 0;
			}
			return x;
		}

		/// <summary>
		/// Wraps a value between a minimum and maximum bound.
		/// </summary>
		/// <param name="x">The value.</param>
		/// <param name="max">The maximum bound.</param>
		/// <param name="min">The minimum bound.</param>
		/// <returns>The wrapped value.</returns>
		public static int Wrap(int x, int max, int min = 0)
		{
			int range = max - min;
			while (x < min)
				x += range;
			while (x > max)
				x -= range;
			return x;
		}

		/// <summary>
		/// Wraps a value between a minimum and maximum bound.
		/// </summary>
		/// <param name="x">The value.</param>
		/// <param name="max">The maximum bound.</param>
		/// <param name="min">The minimum bound.</param>
		/// <returns>The wrapped value.</returns>
		public static double Wrap(double x, double max, double min = 0)
		{
			double range = max - min;
			while (x < min)
				x += range;
			while (x > max)
				x -= range;
			return x;
		}

		/// <summary>
		/// Wraps an angle between -PI and +PI.
		/// </summary>
		/// <param name="x">The angle.</param>
		/// <returns>The wrapped angle.</returns>
		public static double WrapRadians(double radians)
		{
			if (radians < Math.PI)
				radians += Math.PI * 2.0;
			if (radians > Math.PI)
				radians -= Math.PI * 2.0;
			return radians;
		}

		/// <summary>
		/// Increases / decreases a value by the amount necessary to get to the destination value but no more than the maximum
		/// amount it can change by.
		/// </summary>
		/// <param name="x">The value.</param>
		/// <param name="dest">The destination value.</param>
		/// <param name="maxChange">The maximum increase / decrease amount.</param>
		/// <returns>The new value.</returns>
		public static int GoTowards(int x, int dest, int maxChange)
		{
			if (x < dest)
				return Math.Min(x + maxChange, dest);
			if (x > dest)
				return Math.Max(x - maxChange, dest);
			return x;
		}

		/// <summary>
		/// Increases / decreases a value by the amount necessary to get to the destination value but no more than the maximum
		/// amount it can change by.
		/// </summary>
		/// <param name="x">The value.</param>
		/// <param name="dest">The destination value.</param>
		/// <param name="maxChange">The maximum increase / decrease amount.</param>
		/// <returns>The new value.</returns>
		public static double GoTowards(double x, double dest, double maxChange)
		{
			if (x < dest)
				return Math.Min(x + maxChange, dest);
			if (x > dest)
				return Math.Max(x - maxChange, dest);
			return x;
		}

		/// <summary>
		/// Increases / decreases a value by the amount necessary to get to the destination value but no more than the maximum
		/// amount it can change by. Keeps the value wrapped between two bounds.
		/// </summary>
		/// <param name="x">The value.</param>
		/// <param name="dest">The destination value.</param>
		/// <param name="maxChange">The maximum increase / decrease amount.</param>
		/// <param name="minValue">The minimum bound.</param>
		/// <param name="maxValue">The maximum bound.</param>
		/// <returns>The new value.</returns>
		public static double GoTowardsWrap(double x, double dest, double maxChange, double minValue, double maxValue)
		{
			x = Wrap(x, maxValue, minValue);
			dest = Wrap(dest, maxValue, minValue);

			if (x == dest)
				return x;

			if (x < dest) {
				double leftDelta = (x - minValue) + (maxValue - dest);
				double rightDelta = dest - x;
				if (leftDelta < rightDelta)
					return Wrap(x - Math.Min(leftDelta, maxChange), maxValue, minValue);
				else
					return Math.Min(x + maxChange, dest);
			} else {
				double leftDelta = x - dest;
				double rightDelta = (maxValue - x) + (dest - minValue);
				if (leftDelta < rightDelta)
					return Math.Max(x - maxChange, dest);
				else
					return Wrap(x + Math.Min(rightDelta, maxChange), maxValue, minValue);
			}
		}

		/// <summary>
		/// Gets the smallest difference of two values in a cyclic fashion.
		/// </summary>
		/// <param name="a">A value.</param>
		/// <param name="b">A value.</param>
		/// <param name="minValue">The mininum bounds.</param>
		/// <param name="maxValue">The maximum bounds.</param>
		/// <returns>The shortest difference between <see cref="a"/> and <see cref="b"/>.</returns>
		public static double WrapDifference(double a, double b, double minValue, double maxValue)
		{
			if (a == b)
				return 0;
			if (a < b) {
				double leftDelta = (a - minValue) + (maxValue - b);
				double rightDelta = b - a;
				if (leftDelta < rightDelta)
					return -leftDelta;
				else
					return rightDelta;
			} else {
				double left_delta = a - b;
				double right_delta = (maxValue - a) + (b - minValue);
				if (left_delta < right_delta)
					return -left_delta;
				else
					return right_delta;
			}
		}

		/// <summary>
		/// Converts degrees to radians.
		/// </summary>
		/// <param name="degrees">The value in degrees.</param>
		/// <returns>The value in radians.</returns>
		public static double ToRadians(double degrees)
		{
			return degrees * (Math.PI / 180.0);
		}

		/// <summary>
		/// Converts radians to degrees.
		/// </summary>
		/// <param name="radians">The value in radians.</param>
		/// <returns>The value in degrees.</returns>
		public static double ToDegrees(double radians)
		{
			return radians * (180.0 / Math.PI);
		}

		public static double DifferenceRadians(double a, double b)
		{
			return WrapDifference(a, b, -Math.PI, Math.PI);
		}
	}
}