using System.Collections;
using System.Collections.Generic;

namespace Cosmos.Collections
{
    public static class CollectionGuardExtensions
    {
        /// <summary>
        /// Check if the collection is empty or null. <br />
        /// If the collection is empty or null, an exception is thrown. <br />
        /// 检查集合是否为空。 <br />
        /// 如果集合为空，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckNull(this IEnumerable argument, string argumentName, string message = null)
        {
            CollectionGuard.NotNull(argument, argumentName, message);
        }

        /// <summary>
        /// Check if the collection is empty. <br />
        /// If the collection is empty, an exception is thrown. <br />
        /// 检查集合是否为空。 <br />
        /// 如果集合为空，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckNullOrEmpty(this IEnumerable argument, string argumentName, string message = null)
        {
            CollectionGuard.NotEmpty(argument, argumentName, message);
        }

        /// <summary>
        /// Check whether the set contains at least the specified number of elements. <br />
        /// If the set is less than the specified number of elements, an exception is thrown. <br />
        /// 检查集合是否包含至少指定个数的元素。 <br />
        /// 如果集合少于指定数目的元素，则抛出异常。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="number"></param>
        /// <param name="message"></param>
        public static void CheckAtLeast<T>(this ICollection<T> argument, int number, string argumentName, string message = null)
        {
            CollectionGuard.ContainsAtLeast(argument, number, argumentName, message);
        }

        /// <summary>
        /// Check if the collection is empty or null. <br />
        /// If the collection is empty or null, an exception is thrown. <br />
        /// 检查集合是否为空。 <br />
        /// 如果集合为空，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Require(this IEnumerable argument, string argumentName, string message = null)
        {
            CollectionGuard.NotNull(argument, argumentName, message);
        }

        /// <summary>
        /// Check if the key/value pair is empty or null. <br />
        /// If the key/value pair is empty or null, an exception is thrown. <br />
        /// 检查键值对是否为空。 <br />
        /// 如果键值对为空，则抛出异常。
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckNull<TKey, TValue>(this KeyValuePair<TKey, TValue> argument, string argumentName, string message = null)
        {
            CollectionGuard.NotNull(argument, argumentName, message);
        }

        /// <summary>
        /// Check if the key/value pair is empty or null. <br />
        /// If the key/value pair is empty or null, an exception is thrown. <br />
        /// 检查键值对是否为空。 <br />
        /// 如果键值对为空，则抛出异常。
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void Require<TKey, TValue>(this KeyValuePair<TKey, TValue> argument, string argumentName, string message = null)
        {
            CollectionGuard.NotNull(argument, argumentName, message);
        }
    }
}