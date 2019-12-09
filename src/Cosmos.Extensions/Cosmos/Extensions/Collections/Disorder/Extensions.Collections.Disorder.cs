using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    public static partial class CollectionExtensions {
        /// <summary>
        /// 打乱一个集合的顺序
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Disorder<TSource>(this IEnumerable<TSource> source) {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            return source.OrderBy(o => Guid.NewGuid());
        }
    }
}