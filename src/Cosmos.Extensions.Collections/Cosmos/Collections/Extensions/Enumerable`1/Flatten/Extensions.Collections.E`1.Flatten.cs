using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    /// <summary>
    /// Collection extensions
    /// </summary>
    public static partial class CollectionExtensions
    {
        /// <summary>
        /// 将多层的集合展开并整理为单层集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src">   </param>
        /// <param name="enumerate"></param>
        /// <returns></returns>
        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> src, Func<T, IEnumerable<T>> enumerate)
        {
            if (src != null)
            {
                var stack = new Stack<T>(src);

                while (stack.Count > 0)
                {
                    var current = stack.Pop();

                    if (current is null)
                        continue;
                    yield return current;

                    var enumerable = enumerate?.Invoke(current);

                    if (enumerable is null)
                        continue;
                    foreach (var child in enumerable)
                        stack.Push(child);
                }
            }
        }
    }
}