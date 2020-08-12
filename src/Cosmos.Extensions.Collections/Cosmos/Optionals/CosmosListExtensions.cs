using System;
using System.Collections.Generic;

namespace Cosmos.Optionals
{
    /// <summary>
    /// Cosmos List extensions
    /// </summary>
    public static class CosmosListExtensions
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
        public static IEnumerable<T> SafeRemoveRange<T>(this List<T> source, int index, int count)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (index < 0 || count < 0)
                return source;

            if (index >= source.Count)
                return source;

            count = Math.Min(count, source.Count) - index;

            source.RemoveRange(index, count);

            return source;
        }
    }
}