using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    /// <summary>
    /// Enumerable extensions
    /// </summary>
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// 将两个具有相同种类的元素的集合合并
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="left"> </param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static IEnumerable<T> Merge<T>(this IEnumerator<T> left, IEnumerator<T> right)
        {
            while (left.MoveNext()) yield return left.Current;
            while (right.MoveNext()) yield return right.Current;
        }

        /// <summary>
        /// 将一个元素添加到一个具有相同种类的元素的集合内
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="left"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public static IEnumerable<T> Merge<T>(this IEnumerator<T> left, T last)
        {
            while (left.MoveNext()) yield return left.Current;
            yield return last;
        }
    }
}