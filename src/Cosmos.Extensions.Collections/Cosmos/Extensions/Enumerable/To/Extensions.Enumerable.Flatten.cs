using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Enumerable extensions
    /// </summary>
    public static partial class EnumerableExtensions {

        /// <summary>
        /// 将多层的集合展开并整理为单层集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src">   </param>
        /// <param name="enumerate"></param>
        /// <returns></returns>
        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> src, Func<T, IEnumerable<T>> enumerate) {
            if (src != null) {
                var stack = new Stack<T>(src);
                while (stack.Count > 0) {
                    var current = stack.Pop();
                    if (current == null) continue;
                    yield return current;
                    var enumerable = enumerate?.Invoke(current);

                    if (enumerable != null) {
                        foreach (var child in enumerable) stack.Push(child);
                    }
                }
            }
        }

        /// <summary>
        /// 将多层的集合展开并整理为单层集合
        /// </summary>
        /// <param name="src"></param>
        /// <param name="enumerate"></param>
        /// <returns></returns>
        public static IEnumerable Flatten(this IEnumerable src, Func<object, IEnumerable> enumerate) {
            return Flatten(src.Cast<object>(), o => (enumerate(o) ?? new object[0]).Cast<object>());
        }
    }
}