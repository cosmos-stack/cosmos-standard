using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Cosmos.Collections
{
    /// <summary>
    /// Cosmos collection extensions
    /// </summary>
    public static partial class CollectionExtensions
    {
        #region Find

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<T>(this IList<T> list, T value) =>
            list.BinarySearch(t => t, value);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="map"></param>
        /// <param name="value"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<TSource, TValue>(this IList<TSource> list, Func<TSource, TValue> map, TValue value) =>
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
        public static int BinarySearch<T>(this IList<T> list, int index, int length, T value) =>
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
        public static int BinarySearch<TSource, TValue>(this IList<TSource> list, int index, int length, Func<TSource, TValue> map, TValue value) =>
            list.BinarySearch(index, length, map, value, Comparer<TValue>.Default);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<T>(this IList<T> list, T value, IComparer<T> comparer) =>
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
        public static int BinarySearch<TSource, TValue>(this IList<TSource> list, Func<TSource, TValue> map, TValue value, IComparer<TValue> comparer) =>
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
        public static int BinarySearch<T>(this IList<T> list, int index, int length, T value, IComparer<T> comparer) =>
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
        public static int BinarySearch<TSource, TValue>(this IList<TSource> list, int index, int length, Func<TSource, TValue> map, TValue value, IComparer<TValue> comparer)
        {
            if (list is null)
                throw new ArgumentNullException(nameof(list));
            if (map is null)
                throw new ArgumentNullException(nameof(map));
            if (comparer is null)
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
            var low = index;
            var high = index + length - 1;

            // While low < high.
            while (low <= high)
            {
                // The midpoint.
                var midpoint = low + ((high - low) >> 1);

                // Compare.
                var order = comparer.Compare(map(list[midpoint]), value);

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

        #region Move

        /// <summary>
        /// Move to first
        /// </summary>
        /// <param name="source"></param>
        /// <param name="element"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static List<TSource> MoveToFirst<TSource>(this List<TSource> source, TSource element)
        {
            if (!source.Contains(element))
                return source;

            source.Remove(element);
            source.Insert(0, element);
            return source;
        }

        #endregion

        #region ReadOnly

        /// <summary>
        /// Wrap in readonly connection
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyCollection<T> WrapInReadOnlyCollection<T>(this IList<T> source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return new ReadOnlyCollection<T>(source);
        }

        #endregion

        #region Shuffle

        /// <summary>
        /// Shuffle in place
        /// </summary>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        public static void ShuffleInPlace<T>(this IList<T> items) => ShuffleInPlace(items, 4);

        /// <summary>
        /// Shuffle in place
        /// </summary>
        /// <param name="items"></param>
        /// <param name="times"></param>
        /// <typeparam name="T"></typeparam>
        public static void ShuffleInPlace<T>(this IList<T> items, int times)
        {
            for (var j = 0; j < times; j++)
            {
                var rnd = new Random((int) (DateTime.Now.Ticks % int.MaxValue) - j);

                for (var i = 0; i < items.Count; i++)
                {
                    var index = rnd.Next(items.Count - 1);
                    var temp = items[index];
                    items[index] = items[i];
                    items[i] = temp;
                }
            }
        }

        /// <summary>
        /// Shuffle to new list
        /// </summary>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> ShuffleToNewList<T>(this IList<T> items) => ShuffleToNewList(items, 4);

        /// <summary>
        /// Shuffle to new list
        /// </summary>
        /// <param name="items"></param>
        /// <param name="times"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> ShuffleToNewList<T>(this IList<T> items, int times)
        {
            var res = new List<T>(items);
            res.ShuffleInPlace(times);
            return res;
        }

        #endregion
    }
}