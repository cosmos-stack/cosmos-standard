using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CosmosStack.Collections
{
    /// <summary>
    /// Collections Utilities <br />
    /// 集合工具
    /// </summary>
    public static partial class Colls
    {
        #region BinarySearch

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<T>(IList<T> source, T value)
        {
            return BinarySearch(source, t => t, value);
        }

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="source"></param>
        /// <param name="map"></param>
        /// <param name="value"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<TSource, TValue>(IList<TSource> source, Func<TSource, TValue> map, TValue value)
        {
            return BinarySearch(source, map, value, Comparer<TValue>.Default);
        }

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<T>(IList<T> source, int index, int length, T value)
        {
            return BinarySearch(source, index, length, t => t, value);
        }

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="map"></param>
        /// <param name="value"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<TSource, TValue>(IList<TSource> source, int index, int length, Func<TSource, TValue> map, TValue value)
        {
            return BinarySearch(source, index, length, map, value, Comparer<TValue>.Default);
        }

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<T>(IList<T> source, T value, IComparer<T> comparer)
        {
            return BinarySearch(source, 0, source.Count, t => t, value, comparer);
        }

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="source"></param>
        /// <param name="map"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<TSource, TValue>(IList<TSource> source, Func<TSource, TValue> map, TValue value, IComparer<TValue> comparer)
        {
            return BinarySearch(source, 0, source.Count, map, value, comparer);
        }

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<T>(IList<T> source, int index, int length, T value, IComparer<T> comparer)
        {
            return BinarySearch(source, index, length, t => t, value, comparer);
        }

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="source"></param>
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
        public static int BinarySearch<TSource, TValue>(IList<TSource> source, int index, int length, Func<TSource, TValue> map, TValue value, IComparer<TValue> comparer)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (map is null)
                throw new ArgumentNullException(nameof(map));
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), index, $"The {nameof(index)} parameter must be a non-negative value.");
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), length, $"The {nameof(length)} parmeter must be a non-negative value.");
            if (index + length > source.Count)
                throw new InvalidOperationException(
                    $"The value of {nameof(index)} plus {nameof(length)} must be less than or equal to the value of the number of items in the {nameof(source)}.");

            // Do work.
            // Taken from https://github.com/dotnet/coreclr/blob/cdff8b0babe5d82737058ccdae8b14d8ae90160d/src/mscorlib/src/System/Collections/Generic/ArraySortHelper.cs#L156
            // The lo and high bounds.
            var low = index;
            var high = index + length - 1;

            // While low < high.
            while (low <= high)
            {
                // The midpoint.
                var midpoint = low + ((high - low) >> 1);

                // Compare.
                var order = comparer.Compare(map(source[midpoint]), value);

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

        #endregion
    }

    /// <summary>
    /// Collection Utilities Extensions <br />
    /// 集合工具扩展
    /// </summary>
    public static partial class CollsExtensions
    {
        #region BinarySearch

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch<T>(this IList<T> source, T value)
        {
            return Colls.BinarySearch(source, t => t, value);
        }

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="source"></param>
        /// <param name="map"></param>
        /// <param name="value"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch<TSource, TValue>(this IList<TSource> source, Func<TSource, TValue> map, TValue value)
        {
            return Colls.BinarySearch(source, map, value, Comparer<TValue>.Default);
        }

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch<T>(this IList<T> source, int index, int length, T value)
        {
            return Colls.BinarySearch(source, index, length, t => t, value);
        }

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="map"></param>
        /// <param name="value"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch<TSource, TValue>(this IList<TSource> source, int index, int length, Func<TSource, TValue> map, TValue value)
        {
            return Colls.BinarySearch(source, index, length, map, value, Comparer<TValue>.Default);
        }

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch<T>(this IList<T> source, T value, IComparer<T> comparer)
        {
            return Colls.BinarySearch(source, 0, source.Count, t => t, value, comparer);
        }

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="source"></param>
        /// <param name="map"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch<TSource, TValue>(this IList<TSource> source, Func<TSource, TValue> map, TValue value, IComparer<TValue> comparer)
        {
            return Colls.BinarySearch(source, 0, source.Count, map, value, comparer);
        }

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch<T>(this IList<T> source, int index, int length, T value, IComparer<T> comparer)
        {
            return Colls.BinarySearch(source, index, length, t => t, value, comparer);
        }

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="source"></param>
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch<TSource, TValue>(this IList<TSource> source, int index, int length, Func<TSource, TValue> map, TValue value, IComparer<TValue> comparer)
        {
            return Colls.BinarySearch(source, index, length, map, value, comparer);
        }

        #endregion
    }
}