using System;
using System.Collections;
using System.Collections.Generic;
using Cosmos.Validation.Internals;

namespace Cosmos.Collections
{
    public static class CollectionGuard
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
        public static void NotNull(IEnumerable argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentNullException>(
                argument != null,
                argumentName, message ?? $"{nameof(argument)} can not be null.");
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
        public static void NotEmpty(IEnumerable argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentNullException>(
                !CollectionJudge.IsNullOrEmpty(argument),
                argumentName, message ?? $"{nameof(argument)} can not be null or empty.");
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
        public static void ContainsAtLeast<T>(ICollection<T> argument, int number, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument.Count >= number,
                argumentName, argument.Count, message ?? $"{nameof(argument)} should has {number} items at least.");
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
        public static void NotNull<TKey, TValue>(KeyValuePair<TKey, TValue> argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentNullException>(
                !string.IsNullOrWhiteSpace(argument.ToString()),
                argumentName, message ?? $"{nameof(argument)} contains nothing.");
        }
    }
}