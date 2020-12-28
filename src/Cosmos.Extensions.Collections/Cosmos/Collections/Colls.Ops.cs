using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable MemberHidesStaticFromOuterClass

namespace Cosmos.Collections
{
    /// <summary>
    /// Collections utilities
    /// </summary>
    public static partial class Colls
    {
        #region Add

        public static IEnumerable<T> AddRange<T>(IEnumerable<T> source, IEnumerable<T> collection)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            foreach (var item in source)
                yield return item;
            foreach (var item in collection)
                yield return item;
        }

        public static IEnumerable<T> AddRange<T>(IEnumerable<T> source, IEnumerable<T> collection, int limit)
        {
            var counter = 0;
            return limit <= 0
                ? AddRange(source, collection)
                : AddRange(source, collection.TakeWhile(_ => counter++ < limit));
        }

        public static IEnumerable<T> AddIf<T>(IEnumerable<T> source, T value, bool flag)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            foreach (var item in source)
                yield return item;
            if (flag)
                yield return value;
        }

        public static IEnumerable<T> AddIf<T>(IEnumerable<T> source, T value, Func<bool> condition)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            foreach (var item in source)
                yield return item;
            if (condition())
                yield return value;
        }

        public static IEnumerable<T> AddIf<T>(IEnumerable<T> source, T value, Func<T, bool> condition)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            foreach (var item in source)
                yield return item;
            if (condition?.Invoke(value) ?? false)
                yield return value;
        }

        #endregion

        #region Get or Add

        public static T GetOrAdd<T>(ICollection<T> source, Func<T, bool> selector, Func<T> factory)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            var item = source.FirstOrDefault(selector);

            if (item is null)
                source.Add(item = factory());

            return item;
        }

        #endregion

        #region Remove

        /// <summary>
        /// Remove deplicates
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TSource> RemoveDuplicates<TSource>(IList<TSource> source)
        {
            var duplicateCheck = new HashSet<TSource>();

            return RemoveIf(source,item =>
            {
                if (duplicateCheck.Contains(item))
                    return true;

                duplicateCheck.Add(item);
                return false;
            });
        }

        /// <summary>
        /// Remove buplicates
        /// </summary>
        /// <param name="source"></param>
        /// <param name="duplicatePredicate"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCheck"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TSource> RemoveDuplicates<TSource, TCheck>(IList<TSource> source, Func<TSource, TCheck> duplicatePredicate)
        {
            if (duplicatePredicate is null)
                throw new ArgumentNullException(nameof(duplicatePredicate));

            var duplicateCheck = new HashSet<TCheck>();

            return RemoveIf(source,item =>
            {
                var val = duplicatePredicate(item);

                if (duplicateCheck.Contains(val))
                    return true;

                duplicateCheck.Add(val);
                return false;
            });
        }

        /// <summary>
        /// Remove duplicates ignore case
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<string> RemoveDuplicatesIgnoreCase(IList<string> source)
        {
            var duplicateCheck = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            return RemoveIf(source,item =>
            {
                if (duplicateCheck.Contains(item))
                    return true;

                duplicateCheck.Add(item);
                return false;
            });
        }

        /// <summary>
        /// Remove where...<br />
        /// 移除满足条件的成员，并最终返回筛选后的结果
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> RemoveIf<T>(IList<T> source, Func<T, bool> predicate)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            for (var i = source.Count - 1; i >= 0; --i)
            {
                var item = source[i];

                if (!predicate.Invoke(item))
                    continue;

                source.RemoveAt(i);
            }

            return source;
        }

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
        public static IEnumerable<T> RemoveRangeSafety<T>(List<T> source, int index, int count)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (index < 0 || count <= 0)
                return source;

            if (index >= source.Count)
                return source;

            count = Math.Min(count, source.Count) - index;

            source.RemoveRange(index, count);

            return source;
        }

        #endregion

        #region Merge

        /// <summary>
        /// Merge
        /// </summary>
        /// <param name="first"></param>
        /// <param name="right"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> Merge<T>(T first, IEnumerator<T> right)
        {
            yield return first;
            while (right.MoveNext()) yield return right.Current;
        }

        /// <summary>
        /// 将两个具有相同种类的元素的集合合并
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="left"> </param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static IEnumerable<T> Merge<T>(IEnumerator<T> left, IEnumerator<T> right)
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
        public static IEnumerable<T> Merge<T>(IEnumerator<T> left, T last)
        {
            while (left.MoveNext()) yield return left.Current;
            yield return last;
        }

        /// <summary>
        /// Merge<br />
        /// 合并集合
        /// </summary>
        /// <param name="source"></param>
        /// <param name="right"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Merge<T>(IEnumerable<T> source, IEnumerable<T> right)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            foreach (var item in source)
                yield return item;
            if (right is null)
                yield break;
            foreach (var item in right)
                yield return item;
        }

        /// <summary>
        /// Merge<br />
        /// 合并集合
        /// </summary>
        /// <param name="source"></param>
        /// <param name="right"></param>
        /// <param name="limit"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Merge<T>(IEnumerable<T> source, IEnumerable<T> right, int limit)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            foreach (var item in source)
                yield return item;
            if (right is null)
                yield break;
            if (limit <= 0)
            {
                foreach (var item in right)
                    yield return item;
            }
            else
            {
                var counter = 0;
                foreach (var item in right)
                {
                    if (counter++ >= limit)
                        yield break;
                    yield return item;
                }
            }
        }

        #endregion
    }

    public static partial class CollsExtensions
    {
        #region Add
        
        public static IEnumerable<T> AddRange<T>(this IEnumerable<T> source, IEnumerable<T> collection, int limit)
        {
            return Colls.AddRange(source, collection, limit);
        }

        public static IEnumerable<T> AddIf<T>(this IEnumerable<T> source, T value, bool flag)
        {
            return Colls.AddIf(source, value, flag);
        }

        public static IEnumerable<T> AddIf<T>(this IEnumerable<T> source, T value, Func<bool> condition)
        {
            return Colls.AddIf(source, value, condition);
        }

        public static IEnumerable<T> AddIf<T>(this IEnumerable<T> source, T value, Func<T, bool> condition)
        {
            return Colls.AddIf(source, value, condition);
        }

        public static IEnumerable<T> AddIfNotExist<T>(this IEnumerable<T> source, T value, Func<T, bool> existFunc = null)
        {
            Func<T, bool> condition = t => !source.Contains(t);
            return Colls.AddIf(source, value, v => existFunc?.Invoke(v) ?? condition(v));
        }

        public static IEnumerable<T> AddIfNotNull<T>(this IEnumerable<T> source, T value)
        {
            return Colls.AddIf(source, value, v => v is not null);
        }

        #endregion

        #region Get or Add

        public static T GetOrAdd<T>(this ICollection<T> source, Func<T, bool> selector, Func<T> factory)
        {
            return Colls.GetOrAdd(source, selector, factory);
        }

        #endregion

        #region Remove

        /// <summary>
        /// Remove duplicates
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TSource> RemoveDuplicates<TSource>(this IList<TSource> source)
        {
            return Colls.RemoveDuplicates(source);
        }

        /// <summary>
        /// Remove duplicates
        /// </summary>
        /// <param name="source"></param>
        /// <param name="duplicatePredicate"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCheck"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TSource> RemoveDuplicates<TSource, TCheck>(this IList<TSource> source, Func<TSource, TCheck> duplicatePredicate)
        {
            return Colls.RemoveDuplicates(source, duplicatePredicate);
        }

        /// <summary>
        /// Remove duplicates ignore case
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<string> RemoveDuplicatesIgnoreCase(this IList<string> source)
        {
            return Colls.RemoveDuplicatesIgnoreCase(source);
        }
        
        /// <summary>
        /// Remove where...<br />
        /// 移除满足条件的成员，并最终返回筛选后的结果
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> RemoveIf<T>(this IList<T> source, Func<T, bool> predicate)
        {
            return Colls.RemoveIf(source, predicate);
        }

        #endregion

        #region Merge

        /// <summary>
        /// Merge<br />
        /// 合并集合
        /// </summary>
        /// <param name="source"></param>
        /// <param name="right"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Merge<T>(this IEnumerable<T> source, IEnumerable<T> right)
        {
            return Colls.Merge(source, right);
        }

        /// <summary>
        /// Merge<br />
        /// 合并集合
        /// </summary>
        /// <param name="source"></param>
        /// <param name="right"></param>
        /// <param name="limit"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Merge<T>(this IEnumerable<T> source, IEnumerable<T> right, int limit)
        {
            return Colls.Merge(source, right, limit);
        }

        #endregion
    }
}