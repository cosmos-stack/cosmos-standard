using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    /// <summary>
    /// ReadOnly list extensions
    /// </summary>
    public static partial class ReadOnlyListExtensions
    {
        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<T>(this IReadOnlyList<T> list, T value) => list.BinarySearch(t => t, value);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="map"></param>
        /// <param name="value"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<TSource, TValue>(this IReadOnlyList<TSource> list, Func<TSource, TValue> map, TValue value) =>
            list.BinarySearch(map, value, Comparer<TValue>.Default);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<T>(this IReadOnlyList<T> list, int index, int length, T value) =>
            list.BinarySearch(index, length, t => t, value);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="map"></param>
        /// <param name="value"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<TSource, TValue>(this IReadOnlyList<TSource> list, int index, int length, Func<TSource, TValue> map, TValue value) =>
            list.BinarySearch(index, length, map, value, Comparer<TValue>.Default);


        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<T>(this IReadOnlyList<T> list, T value, IComparer<T> comparer) =>
            list.BinarySearch(0, list.Count, t => t, value, comparer);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="map"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<TSource, TValue>(this IReadOnlyList<TSource> list, Func<TSource, TValue> map, TValue value, IComparer<TValue> comparer) =>
            list.BinarySearch(0, list.Count, map, value, comparer);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<T>(this IReadOnlyList<T> list, int index, int length, T value, IComparer<T> comparer) =>
            list.BinarySearch(index, length, t => t, value, comparer);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="map"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static int BinarySearch<TSource, TValue>(this IReadOnlyList<TSource> list, int index, int length, Func<TSource, TValue> map, TValue value,
            IComparer<TValue> comparer)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            if (map == null)
                throw new ArgumentNullException(nameof(map));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), index, $"The {nameof(index)} parameter must be a non-negative value.");
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), length, $"The {nameof(length)} parmeter must be a non-negative value.");
            if (index + length > list.Count)
                throw new InvalidOperationException(
                    $"The value of {nameof(index)} plus {nameof(length)} must be less than or equal to the value of the number of items in the {nameof(list)}.");

            // Do work.
            // Taken from https://github.com/dotnet/coreclr/blob/cdff8b0babe5d82737058ccdae8b14d8ae90160d/src/mscorlib/src/System/Collections/Generic/ArraySortHelper.cs#L156
            // The lo and high bounds.
            int low = index;
            int high = index + length - 1;

            // While low < high.
            while (low <= high)
            {
                // The midpoint.
                int midpoint = low + ((high - low) >> 1);

                // Compare.
                int order = comparer.Compare(map(list[midpoint]), value);

                // If they are equal, return.
                if (order == 0) return midpoint;

                // If less than zero, reset low, otherwise, reset high.
                if (order < 0)
                    low = midpoint + 1;
                else
                    high = midpoint - 1;
            }

            // Nothing matched, return inverse of the low bound.
            return ~low;
        }
    }
}