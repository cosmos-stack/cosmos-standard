using System;
using System.Collections;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    public static partial class CollectionExtensions
    {
        /// <summary>
        /// Binary Search
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int BinarySearch(this Array array, object value)
            => Array.BinarySearch(array, value);

        /// <summary>
        /// Binary Search
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int BinarySearch(this Array array, int index, int length, object value)
            => Array.BinarySearch(array, index, length, value);

        /// <summary>
        /// Binary Search
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static int BinarySearch(this Array array, object value, IComparer comparer)
            => Array.BinarySearch(array, value, comparer);

        /// <summary>
        /// Binary Search
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static int BinarySearch(this Array array, int index, int length, object value, IComparer comparer)
            => Array.BinarySearch(array, index, length, value, comparer);
    }
}