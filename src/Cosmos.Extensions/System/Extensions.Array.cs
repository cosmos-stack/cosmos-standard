using System.Collections;

namespace System {
    /// <summary>
    /// Base Type Extensions
    /// </summary>
    public static partial class BaseTypeExtensions {
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <param name="destinationArray"></param>
        /// <param name="length"></param>
        public static void Copy(this Array sourceArray, Array destinationArray, int length) {
            Array.Copy(sourceArray, destinationArray, length);
        }

        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <param name="sourceIndex"></param>
        /// <param name="destinationArray"></param>
        /// <param name="destinationIndex"></param>
        /// <param name="length"></param>
        public static void Copy(this Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length) {
            Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
        }

        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <param name="destinationArray"></param>
        /// <param name="length"></param>
        public static void Copy(this Array sourceArray, Array destinationArray, long length) {
            Array.Copy(sourceArray, destinationArray, length);
        }

        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <param name="sourceIndex"></param>
        /// <param name="destinationArray"></param>
        /// <param name="destinationIndex"></param>
        /// <param name="length"></param>
        public static void Copy(this Array sourceArray, long sourceIndex, Array destinationArray, long destinationIndex, long length) {
            Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
        }

        /// <summary>
        /// Contained copy
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <param name="sourceIndex"></param>
        /// <param name="destinationArray"></param>
        /// <param name="destinationIndex"></param>
        /// <param name="length"></param>
        public static void ConstrainedCopy(this Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length) {
            Array.ConstrainedCopy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
        }

        /// <summary>
        /// Clear
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        public static void Clear(this Array array, int index, int length) {
            Array.Clear(array, index, length);
        }

        /// <summary>
        /// Clear all
        /// </summary>
        /// <param name="array"></param>
        public static void ClearAll(this Array array) {
            Array.Clear(array, 0, array.Length);
        }

        /// <summary>
        /// Index of
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int IndexOf(this Array array, object value) {
            return Array.IndexOf(array, value);
        }

        /// <summary>
        /// Index of
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static int IndexOf(this Array array, object value, int startIndex) {
            return Array.IndexOf(array, value, startIndex);
        }

        /// <summary>
        /// Index of
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int IndexOf(this Array array, object value, int startIndex, int count) {
            return Array.IndexOf(array, value, startIndex, count);
        }

        /// <summary>
        /// Last index of
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int LastIndexOf(this Array array, object value) {
            return Array.LastIndexOf(array, value);
        }

        /// <summary>
        /// Last index of
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static int LastIndexOf(this Array array, object value, int startIndex) {
            return Array.LastIndexOf(array, value, startIndex);
        }

        /// <summary>
        /// Last index of
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int LastIndexOf(this Array array, object value, int startIndex, int count) {
            return Array.LastIndexOf(array, value, startIndex, count);
        }

        /// <summary>
        /// Within index
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool WithinIndex(this Array array, int index) {
            return index >= 0 && index < array.Length;
        }

        /// <summary>
        /// Within index
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="dimension"></param>
        /// <returns></returns>
        public static bool WithinIndex(this Array array, int index, int dimension) {
            if (dimension <= 0) throw new ArgumentOutOfRangeException(nameof(dimension));
            return index >= array.GetLowerBound(dimension) && index <= array.GetUpperBound(dimension);
        }

        /// <summary>
        /// Reverse
        /// </summary>
        /// <param name="array"></param>
        public static void Reverse(this Array array) {
            Array.Reverse(array);
        }

        /// <summary>
        /// Reverse
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        public static void Reverse(this Array array, int index, int length) {
            Array.Reverse(array, index, length);
        }

        /// <summary>
        /// Sort
        /// </summary>
        /// <param name="array"></param>
        public static void Sort(this Array array) {
            Array.Sort(array);
        }

        /// <summary>
        /// Sort
        /// </summary>
        /// <param name="array"></param>
        /// <param name="items"></param>
        public static void Sort(this Array array, Array items) {
            Array.Sort(array, items);
        }

        /// <summary>
        /// Sort
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        public static void Sort(this Array array, int index, int length) {
            Array.Sort(array, index, length);
        }

        /// <summary>
        /// Sort
        /// </summary>
        /// <param name="array"></param>
        /// <param name="items"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        public static void Sort(this Array array, Array items, int index, int length) {
            Array.Sort(array, items, index, length);
        }

        /// <summary>
        /// Sort
        /// </summary>
        /// <param name="array"></param>
        /// <param name="comparer"></param>
        public static void Sort(this Array array, IComparer comparer) {
            Array.Sort(array, comparer);
        }

        /// <summary>
        /// Sort
        /// </summary>
        /// <param name="array"></param>
        /// <param name="items"></param>
        /// <param name="comparer"></param>
        public static void Sort(this Array array, Array items, IComparer comparer) {
            Array.Sort(array, items, comparer);
        }

        /// <summary>
        /// Sort
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="comparer"></param>
        public static void Sort(this Array array, int index, int length, IComparer comparer) {
            Array.Sort(array, index, length, comparer);
        }

        /// <summary>
        /// Sort
        /// </summary>
        /// <param name="array"></param>
        /// <param name="items"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="comparer"></param>
        public static void Sort(this Array array, Array items, int index, int length, IComparer comparer) {
            Array.Sort(array, items, index, length, comparer);
        }

        /// <summary>
        /// Binary Search
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int BinarySearch(this Array array, object value) {
            return Array.BinarySearch(array, value);
        }

        /// <summary>
        /// Binary Search
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int BinarySearch(this Array array, int index, int length, object value) {
            return Array.BinarySearch(array, index, length, value);
        }


        /// <summary>
        /// Binary Search
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static int BinarySearch(this Array array, object value, IComparer comparer) {
            return Array.BinarySearch(array, value, comparer);
        }

        /// <summary>
        /// Binary Search
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static int BinarySearch(this Array array, int index, int length, object value, IComparer comparer) {
            return Array.BinarySearch(array, index, length, value, comparer);
        }

        /// <summary>
        /// Find all
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="me"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static T[] FindAll<T>(this T[] me, Predicate<T> condition) {
            return Array.FindAll(me, condition);
        }
    }
}