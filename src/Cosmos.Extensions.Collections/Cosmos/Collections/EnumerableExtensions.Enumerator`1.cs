using System;
using System.Collections.Generic;

namespace Cosmos.Collections
{
    public static partial class EnumerableExtensions
    {
        #region Merge

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

        #endregion

        #region To

        /// <summary>
        /// To Enumerable
        /// </summary>
        /// <param name="enumerator"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> ToEnumerable<T>(this IEnumerator<T> enumerator)
        {
            if (enumerator is null)
                throw new ArgumentNullException(nameof(enumerator));

            IEnumerable<T> Implementation()
            {
                while (enumerator.MoveNext())
                    yield return enumerator.Current;
            }

            return Implementation();
        }

        /// <summary>
        /// To Enumerable After
        /// </summary>
        /// <param name="enumerator"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> ToEnumerableAfter<T>(this IEnumerator<T> enumerator)
        {
            if (enumerator is null)
                throw new ArgumentNullException(nameof(enumerator));

            IEnumerable<T> Implementation()
            {
                do
                {
                    yield return enumerator.Current;
                } while (enumerator.MoveNext());
            }

            return Implementation();
        }

        #endregion
    }
}