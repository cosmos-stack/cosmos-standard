using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cosmos.Collections;
using Arrays = CosmosStack.Collections.Arrays;
using Colls = CosmosStack.Collections.Colls;

namespace CosmosStack.Optionals
{
    /// <summary>
    /// Optional collections extensions <br />
    /// 可选集合扩展
    /// </summary>
    public static class OptionalCollsExtensions
    {
        /// <summary>
        /// Safe remove range<br />
        /// 安全地移除指定范围内的成员
        /// </summary>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> RemoveRangeSafety<T>(this List<T> source, int index, int count)
        {
            return Colls.RemoveRangeSafety(source, index, count);
        }
        
        /// <summary>
        /// To safe array <br />
        /// 安全地转换为数组
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TElement[] ToArraySafety<TElement>(this IEnumerable<TElement> src)
        {
            return Arrays.ToArraySafety(src);
        }
        
        /// <summary>
        /// To safe array <br />
        /// 安全地转换为数组
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TElement[] ToArraySafety<TElement>(this Array src)
        {
            return Arrays.ToArraySafety<TElement>(src);
        }
    }
}