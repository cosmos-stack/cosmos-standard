using System;
using System.Collections;
using System.Linq;

namespace Cosmos.Collections
{
    public static partial class EnumerableExtensions
    {
        #region Flatten

        /// <summary>
        /// 将多层的集合展开并整理为单层集合
        /// </summary>
        /// <param name="src"></param>
        /// <param name="enumerate"></param>
        /// <returns></returns>
        // ReSharper disable once FunctionRecursiveOnAllPaths
        public static IEnumerable Flatten(this IEnumerable src, Func<object, IEnumerable> enumerate) =>
            Flatten(src.Cast<object>(), o => (enumerate(o) ?? new object[0]).Cast<object>());

        #endregion
    }
}