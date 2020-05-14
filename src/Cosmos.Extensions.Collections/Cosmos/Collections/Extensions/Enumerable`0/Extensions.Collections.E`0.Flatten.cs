using System;
using System.Collections;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Collection extensions
    /// </summary>
    public static partial class CollectionExtensions {
        /// <summary>
        /// 将多层的集合展开并整理为单层集合
        /// </summary>
        /// <param name="src"></param>
        /// <param name="enumerate"></param>
        /// <returns></returns>
        public static IEnumerable Flatten(this IEnumerable src, Func<object, IEnumerable> enumerate) =>
            Flatten(src.Cast<object>(), o => (enumerate(o) ?? new object[0]).Cast<object>());
    }
}