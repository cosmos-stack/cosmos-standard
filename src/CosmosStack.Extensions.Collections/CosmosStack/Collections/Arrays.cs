using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CosmosStack.Collections
{
    /// <summary>
    /// Array utilities
    /// </summary>
    public static partial class Arrays
    {
#if NET452
        private static class Cache<T>
        {
            public static readonly T[] Empty = new T[0];
        }
#endif
        /// <summary>
        /// Gets empty array <br />
        /// 获取空数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] Empty<T>()
        {
#if NET452
            return Cache<T>.Empty;
#else
            return Array.Empty<T>();
#endif
        }

        /// <summary>
        /// To safe array <br />
        /// 安全地转换为数组
        /// </summary>
        /// <param name="src"></param>
        /// <param name="count"></param>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        public static TElement[] ToArraySafety<TElement>(IEnumerable<TElement> src, int count)
        {
            if (count <= 0)
                return Empty<TElement>();
            var elements = new TElement[count];
            if (src is null)
                return elements;
            var index = 0;
            foreach (var element in elements)
            {
                if (index == count) break;
                elements[index++] = element;
            }

            return elements;
        }

        /// <summary>
        /// To safe array <br />
        /// 安全地转换为数组
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TElement[] ToArraySafety<TElement>(IEnumerable<TElement> src)
        {
            if (src is null)
                return Empty<TElement>();
            return src as TElement[] ?? src.ToArray();
        }

        /// <summary>
        /// To safe array <br />
        /// 安全地转换为数组
        /// </summary>
        /// <param name="src"></param>
        /// <param name="count"></param>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        public static TElement[] ToArraySafety<TElement>(Array src, int count)
        {
            if (count <= 0)
                return Empty<TElement>();
            var elements = new TElement[count];
            if (src is null)
                return elements;
            var index = 0;
            foreach (var item in src)
            {
                if (index == count) break;
                elements[index++] = (TElement)item;
            }

            return elements;
        }

        /// <summary>
        /// To safe array <br />
        /// 安全地转换为数组
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        public static TElement[] ToArraySafety<TElement>(Array src)
        {
            if (src is null)
                return Empty<TElement>();

            var elements = new TElement[src.Length];
            var index = 0;
            foreach (var item in src)
                elements[index++] = (TElement)item;
            return elements;
        }
    }

    /// <summary>
    /// Array shortcut extensions <br />
    /// 数组捷径扩展
    /// </summary>
    public static partial class ArraysShortcutExtensions
    {
        /// <summary>
        /// Searches an entire one-dimensional sorted array for a specific element,
        /// using the <see cref="T:System.IComparable" /> interface implemented by each element of the array and by the specified object. <br />
        /// 在整个一维排序数组中搜索特定元素，使用由数组的每个元素和指定的对象实现的 <see cref="T:System.IComparable" /> 接口。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch(this Array array, object value)
        {
            return Array.BinarySearch(array, value);
        }

        /// <summary>
        /// Searches an entire one-dimensional sorted array for a value using the specified <see cref="T:System.Collections.IComparer" /> interface. <br />
        /// 使用指定的 <see cref="T:System.Collections.IComparer" /> 接口在整个一维排序数组中搜索值。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch(this Array array, int index, int length, object value)
        {
            return Array.BinarySearch(array, index, length, value);
        }

        /// <summary>Searches a range of elements in a one-dimensional sorted array for a value,
        /// using the <see cref="T:System.IComparable`1" /> generic interface implemented by each element of the <see cref="T:System.Array" /> and by the specified value. <br />
        /// 使用 <see cref="T:System.IComparable`1" /> 通用接口，由 <see cref="T:System.Array" /> 的每个元素和指定的值实现。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch(this Array array, object value, IComparer comparer)
        {
            return Array.BinarySearch(array, value, comparer);
        }

        /// <summary>
        /// Searches a range of elements in a one-dimensional sorted array for a value,
        /// using the specified <see cref="T:System.Collections.Generic.IComparer`1" /> generic interface. <br />
        /// 在一个一维排序数组的元素范围内搜索一个值，使用指定的 <see cref="T:System.Collections.Generic.IComparer`1" /> 通用接口。 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BinarySearch(this Array array, int index, int length, object value, IComparer comparer)
        {
            return Array.BinarySearch(array, index, length, value, comparer);
        }

        /// <summary>
        /// Sets a range of elements in an array to the default value of each element type. <br />
        /// 将数组中的元素范围设置为每个元素类型的默认值。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Clear(this Array array, int index, int length)
        {
            Array.Clear(array, index, length);
        }

        /// <summary>
        /// Sets all elements in an array to the default value of each element type. <br />
        /// 将数组中的所有元素设置为每种元素类型的默认值。
        /// </summary>
        /// <param name="array"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Clear(this Array array)
        {
            Array.Clear(array, 0, array.Length);
        }

        /// <summary>
        /// Retrieves all the elements that match the conditions defined by the specified predicate. <br />
        /// 检索与指定谓词定义的条件匹配的所有元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="me"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] FindAll<T>(this T[] me, Predicate<T> condition)
        {
            return Array.FindAll(me, condition);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of its first occurrence in a one-dimensional array. <br />
        /// 搜索指定的对象并返回其在一维数组中第一次出现的索引。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int IndexOf(this Array array, object value)
        {
            return Array.IndexOf(array, value);
        }

        /// <summary>
        /// Searches for the specified object in a range of elements of a one-dimensional array,
        /// and returns the index of its first occurrence. The range extends from a specified index
        /// to the end of the array. <br />
        /// 在一个一维数组的元素范围内搜索指定对象，并返回其第一次出现的索引。 范围从指定的索引扩展到数组的末尾。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int IndexOf(this Array array, object value, int startIndex)
        {
            return Array.IndexOf(array, value, startIndex);
        }

        /// <summary>
        /// Searches for the specified object in a range of elements of a one-dimensional array,
        /// and returns the index of ifs first occurrence. The range extends from a specified index
        /// for a specified number of elements. <br />
        /// 在一维数组的元素范围内搜索指定对象，并返回ifs第一次出现的索引。 范围从指定数量的元素的指定索引开始。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int IndexOf(this Array array, object value, int startIndex, int count)
        {
            return Array.IndexOf(array, value, startIndex, count);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the last occurrence within
        /// the entire one-dimensional <see cref="T:System.Array" />. <br />
        /// 搜索指定对象并返回整个一维 <see cref="T:System.Array" /> 中最后一次出现的索引。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LastIndexOf(this Array array, object value)
        {
            return Array.LastIndexOf(array, value);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the last occurrence within
        /// the range of elements in the one-dimensional <see cref="T:System.Array" /> that extends
        /// from the first element to the specified index. <br />
        /// 搜索指定对象并返回一维 <see cref="T:System.Array" /> 元素范围内最后一次出现的索引，该元素从第一个元素延伸到指定索引。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LastIndexOf(this Array array, object value, int startIndex)
        {
            return Array.LastIndexOf(array, value, startIndex);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the last occurrence within
        /// the range of elements in the one-dimensional <see cref="T:System.Array" /> that contains
        /// the specified number of elements and ends at the specified index. <br />
        /// 搜索指定对象并返回一维 <see cref="T:System.Array" /> 中元素范围内最后一次出现的索引，该元素包含指定数量的元素并在指定索引处结束。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LastIndexOf(this Array array, object value, int startIndex, int count)
        {
            return Array.LastIndexOf(array, value, startIndex, count);
        }

        /// <summary>
        /// Reverses the sequence of the elements in the entire one-dimensional <see cref="T:System.Array" />. <br />
        /// 反转整个一维<see cref="T:System.Array" />中元素的顺序。
        /// </summary>
        /// <param name="array"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Reverse(this Array array)
        {
            Array.Reverse(array);
        }

        /// <summary>
        /// Reverses the sequence of a subset of the elements in the one-dimensional <see cref="T:System.Array" />. <br />
        /// 反转一维 <see cref="T:System.Array" /> 中元素子集的顺序。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Reverse(this Array array, int index, int length)
        {
            Array.Reverse(array, index, length);
        }

        /// <summary>
        /// Sorts the elements in an entire one-dimensional <see cref="T:System.Array" /> using
        /// the <see cref="T:System.IComparable" /> implementation of each element of the <see cref="T:System.Array" />. <br />
        /// 使用 <see cref="T:System.Array" /> 的每个元素的 <see cref="T:System.IComparable" /> 实现对整个一维数组中的元素进行排序。
        /// </summary>
        /// <param name="array"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sort(this Array array)
        {
            Array.Sort(array);
        }

        /// <summary>
        /// Sorts a pair of one-dimensional <see cref="T:System.Array" /> objects (one contains
        /// the keys and the other contains the corresponding items) based on the keys in the first <see cref="T:System.Array" />
        /// using the <see cref="T:System.IComparable" /> implementation of each key. <br />
        /// 使用每个键的 <see cref="T:System.IComparable" /> 实现，基于第一个 Array 中的键对一对一维 Array 对象（一个包含键，另一个包含相应项）进行排序。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="items"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sort(this Array array, Array items)
        {
            Array.Sort(array, items);
        }

        /// <summary>
        /// Sorts a pair of one-dimensional <see cref="T:System.Array" /> objects (one contains
        /// the keys and the other contains the corresponding items) based on the keys in the first <see cref="T:System.Array" />
        /// using the specified <see cref="T:System.Collections.IComparer" />. <br />
        /// 使用指定的 <see cref="T:System.Collections.IComparer" /> 根据第一个 Array 中的键对一对一维 Array 对象（一个包含键，另一个包含相应项）进行排序。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sort(this Array array, int index, int length)
        {
            Array.Sort(array, index, length);
        }

        /// <summary>
        /// Sorts a range of elements in a pair of one-dimensional <see cref="T:System.Array" /> objects (one contains
        /// the keys and the other contains the corresponding items) based on the keys in the first <see cref="T:System.Array" />
        /// using the <see cref="T:System.IComparable" /> implementation of each key. <br />
        /// 使用 <see cref="T:System.IComparable" /> 根据第一个 Array 中的键对一对一维 Array 对象（一个包含键，另一个包含相应项）中的一系列元素进行排序 每个键的实现。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="items"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sort(this Array array, Array items, int index, int length)
        {
            Array.Sort(array, items, index, length);
        }

        /// <summary>
        /// Sorts the elements in a one-dimensional <see cref="T:System.Array" /> using the specified <see cref="T:System.Collections.IComparer" />. <br />
        /// 使用指定的 <see cref="T:System.Collections.IComparer" /> 对一维 <see cref="T:System.Array" /> 中的元素进行排序。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="comparer"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sort(this Array array, IComparer comparer)
        {
            Array.Sort(array, comparer);
        }

        /// <summary>
        /// Sorts a range of elements in a pair of one-dimensional <see cref="T:System.Array" /> objects
        /// (one contains the keys and the other contains the corresponding items) based on the keys in the first <see cref="T:System.Array" />
        /// using the specified <see cref="T:System.Collections.IComparer" />. <br />
        /// 使用指定的 IComparer 根据第一个 Array 中的键对一对一维 Array 对象（一个包含键，另一个包含相应项）中的一系列元素进行排序。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="items"></param>
        /// <param name="comparer"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sort(this Array array, Array items, IComparer comparer)
        {
            Array.Sort(array, items, comparer);
        }

        /// <summary>
        /// Sorts the elements in a one-dimensional <see cref="T:System.Array" /> using the specified <see cref="T:System.Collections.IComparer" />. <br />
        /// 使用指定的 <see cref="T:System.Collections.IComparer" /> 对一维 <see cref="T:System.Array" /> 中的元素进行排序。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="comparer"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sort(this Array array, int index, int length, IComparer comparer)
        {
            Array.Sort(array, index, length, comparer);
        }

        /// <summary>
        /// Sorts a range of elements in a pair of one-dimensional <see cref="T:System.Array" /> objects
        /// (one contains the keys and the other contains the corresponding items) based on the keys in
        /// the first <see cref="T:System.Array" /> using the specified <see cref="T:System.Collections.IComparer" />. <br />
        /// 使用指定的 IComparer 根据第一个 Array 中的键对一对一维 Array 对象（一个包含键，另一个包含相应项）中的一系列元素进行排序。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="items"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="comparer"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sort(this Array array, Array items, int index, int length, IComparer comparer)
        {
            Array.Sort(array, items, index, length, comparer);
        }

        /// <summary>
        /// Returns the number of bytes in the specified array. <br />
        /// 返回指定数组中的字节数。
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ByteLength(this Array array)
        {
            return Buffer.ByteLength(array);
        }

        /// <summary>
        /// Retrieves the byte at the specified location in the specified array. <br />
        /// 检索指定数组中指定位置的字节。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte GetByte(this Array array, int index)
        {
            return Buffer.GetByte(array, index);
        }

        ///<summary>
        /// Assigns a specified value to a byte at a particular location in a specified array. <br />
        /// 将指定值分配给指定数组中特定位置的字节。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetByte(this Array array, int index, byte value)
        {
            Buffer.SetByte(array, index, value);
        }
    }
}