using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Collections
{
    /// <summary>
    /// Array utilities
    /// </summary>
    public static partial class Arrays
    {
        public static T[] Empty<T>()
        {
#if NET452
            return new T[0];
#else
            return Array.Empty<T>();
#endif
        }

        /// <summary>
        /// To safe array
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        public static TElement[] ToArraySafety<TElement>(IEnumerable<TElement> src)
        {
            return src as TElement[] ?? src?.ToArray() ?? Empty<TElement>();
        }

        /// <summary>
        /// To safe array
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        public static TElement[] ToArraySafety<TElement>(Array src)
        {
            if (src is null)
                return Empty<TElement>();

            var val = new TElement[src.Length];
            var index = 0;
            foreach (var item in src)
                val[index++] = (TElement) item;
            return val;
        }
    }

    public static partial class ArraysExtensions { }

    public static partial class ArraysShortcutExtensions
    {
        /// <summary>
        /// Searches an entire one-dimensional sorted array for a specific element,
        /// using the <see cref="T:System.IComparable" /> interface implemented by each element of the array and by the specified object.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int BinarySearch(this Array array, object value)
        {
            return Array.BinarySearch(array, value);
        }

        /// <summary>
        /// Searches an entire one-dimensional sorted array for a value using the specified <see cref="T:System.Collections.IComparer" /> interface.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int BinarySearch(this Array array, int index, int length, object value)
        {
            return Array.BinarySearch(array, index, length, value);
        }

        /// <summary>Searches a range of elements in a one-dimensional sorted array for a value,
        /// using the <see cref="T:System.IComparable`1" /> generic interface implemented by each element of the <see cref="T:System.Array" /> and by the specified value.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static int BinarySearch(this Array array, object value, IComparer comparer)
        {
            return Array.BinarySearch(array, value, comparer);
        }

        /// <summary>
        /// Searches a range of elements in a one-dimensional sorted array for a value,
        /// using the specified <see cref="T:System.Collections.Generic.IComparer`1" /> generic interface.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static int BinarySearch(this Array array, int index, int length, object value, IComparer comparer)
        {
            return Array.BinarySearch(array, index, length, value, comparer);
        }

        /// <summary>
        /// Sets a range of elements in an array to the default value of each element type.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        public static void Clear(this Array array, int index, int length)
        {
            Array.Clear(array, index, length);
        }

        /// <summary>
        /// Sets all elements in an array to the default value of each element type.
        /// </summary>
        /// <param name="array"></param>
        public static void Clear(this Array array)
        {
            Array.Clear(array, 0, array.Length);
        }

        /// <summary>
        /// Retrieves all the elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="me"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static T[] FindAll<T>(this T[] me, Predicate<T> condition)
        {
            return Array.FindAll(me, condition);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of its first occurrence in a one-dimensional array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int IndexOf(this Array array, object value)
        {
            return Array.IndexOf(array, value);
        }

        /// <summary>
        /// Searches for the specified object in a range of elements of a one-dimensional array,
        /// and returns the index of its first occurrence. The range extends from a specified index
        /// to the end of the array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static int IndexOf(this Array array, object value, int startIndex)
        {
            return Array.IndexOf(array, value, startIndex);
        }

        /// <summary>
        /// Searches for the specified object in a range of elements of a one-dimensional array,
        /// and returns the index of ifs first occurrence. The range extends from a specified index
        /// for a specified number of elements.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int IndexOf(this Array array, object value, int startIndex, int count)
        {
            return Array.IndexOf(array, value, startIndex, count);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the last occurrence within
        /// the entire one-dimensional <see cref="T:System.Array" />.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int LastIndexOf(this Array array, object value)
        {
            return Array.LastIndexOf(array, value);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the last occurrence within
        /// the range of elements in the one-dimensional <see cref="T:System.Array" /> that extends
        /// from the first element to the specified index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static int LastIndexOf(this Array array, object value, int startIndex)
        {
            return Array.LastIndexOf(array, value, startIndex);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the last occurrence within
        /// the range of elements in the one-dimensional <see cref="T:System.Array" /> that contains
        /// the specified number of elements and ends at the specified index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int LastIndexOf(this Array array, object value, int startIndex, int count)
        {
            return Array.LastIndexOf(array, value, startIndex, count);
        }

        /// <summary>
        /// Reverses the sequence of the elements in the entire one-dimensional <see cref="T:System.Array" />.
        /// </summary>
        /// <param name="array"></param>
        public static void Reverse(this Array array)
        {
            Array.Reverse(array);
        }

        /// <summary>
        /// Reverses the sequence of a subset of the elements in the one-dimensional <see cref="T:System.Array" />.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        public static void Reverse(this Array array, int index, int length)
        {
            Array.Reverse(array, index, length);
        }

        /// <summary>
        /// Sorts the elements in an entire one-dimensional <see cref="T:System.Array" /> using
        /// the <see cref="T:System.IComparable" /> implementation of each element of the <see cref="T:System.Array" />.
        /// </summary>
        /// <param name="array"></param>
        public static void Sort(this Array array)
        {
            Array.Sort(array);
        }

        /// <summary>
        /// Sorts a pair of one-dimensional <see cref="T:System.Array" /> objects (one contains
        /// the keys and the other contains the corresponding items) based on the keys in the first <see cref="T:System.Array" />
        /// using the <see cref="T:System.IComparable" /> implementation of each key.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="items"></param>
        public static void Sort(this Array array, Array items)
        {
            Array.Sort(array, items);
        }

        /// <summary>
        /// Sorts a pair of one-dimensional <see cref="T:System.Array" /> objects (one contains
        /// the keys and the other contains the corresponding items) based on the keys in the first <see cref="T:System.Array" />
        /// using the specified <see cref="T:System.Collections.IComparer" />.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        public static void Sort(this Array array, int index, int length)
        {
            Array.Sort(array, index, length);
        }

        /// <summary>
        /// Sorts a range of elements in a pair of one-dimensional <see cref="T:System.Array" /> objects (one contains
        /// the keys and the other contains the corresponding items) based on the keys in the first <see cref="T:System.Array" />
        /// using the <see cref="T:System.IComparable" /> implementation of each key.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="items"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        public static void Sort(this Array array, Array items, int index, int length)
        {
            Array.Sort(array, items, index, length);
        }

        /// <summary>
        /// Sorts the elements in a one-dimensional <see cref="T:System.Array" /> using the specified <see cref="T:System.Collections.IComparer" />.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="comparer"></param>
        public static void Sort(this Array array, IComparer comparer)
        {
            Array.Sort(array, comparer);
        }

        /// <summary>
        /// Sorts a range of elements in a pair of one-dimensional <see cref="T:System.Array" /> objects
        /// (one contains the keys and the other contains the corresponding items) based on the keys in the first <see cref="T:System.Array" />
        /// using the specified <see cref="T:System.Collections.IComparer" />.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="items"></param>
        /// <param name="comparer"></param>
        public static void Sort(this Array array, Array items, IComparer comparer)
        {
            Array.Sort(array, items, comparer);
        }

        /// <summary>
        /// Sorts the elements in a one-dimensional <see cref="T:System.Array" /> using the specified <see cref="T:System.Collections.IComparer" />.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="comparer"></param>
        public static void Sort(this Array array, int index, int length, IComparer comparer)
        {
            Array.Sort(array, index, length, comparer);
        }

        /// <summary>
        /// Sorts a range of elements in a pair of one-dimensional <see cref="T:System.Array" /> objects
        /// (one contains the keys and the other contains the corresponding items) based on the keys in
        /// the first <see cref="T:System.Array" /> using the specified <see cref="T:System.Collections.IComparer" />.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="items"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="comparer"></param>
        public static void Sort(this Array array, Array items, int index, int length, IComparer comparer)
        {
            Array.Sort(array, items, index, length, comparer);
        }

        /// <summary>
        /// Returns the number of bytes in the specified array.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int ByteLength(this Array array)
        {
            return Buffer.ByteLength(array);
        }

        /// <summary>
        /// Retrieves the byte at the specified location in the specified array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static byte GetByte(this Array array, int index)
        {
            return Buffer.GetByte(array, index);
        }

        ///<summary>
        /// Assigns a specified value to a byte at a particular location in a specified array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public static void SetByte(this Array array, int index, byte value)
        {
            Buffer.SetByte(array, index, value);
        }
    }
}