using System.Collections.Generic;
using System;
using System.Collections;
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

        public static TColl AddRange<TColl, T>(TColl source, IEnumerable<T> collection)
            where TColl : IList<T>
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            foreach (var item in collection)
                source.Add(item);
            return source;
        }

        public static TColl AddRange<TColl, T>(TColl source, IEnumerable<T> collection, int limit)
            where TColl : IList<T>
        {
            var counter = 0;
            return limit <= 0
                ? AddRange(source, collection)
                : AddRange(source, collection.TakeWhile(val => counter++ < limit));
        }

        public static TColl AddIf<TColl, T>(TColl source, T value, bool flag)
            where TColl : ICollection<T>
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (flag)
                source.Add(value);
            return source;
        }

        public static TColl AddIf<TColl, T>(TColl source, T value, Func<bool> condition)
            where TColl : ICollection<T>
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (condition())
                source.Add(value);
            return source;
        }

        public static TColl AddIf<TColl, T>(TColl source, T value, Func<T, bool> condition)
            where TColl : ICollection<T>
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (condition?.Invoke(value) ?? false)
                source.Add(value);
            return source;
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

            return source.RemoveIf(item =>
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

            return source.RemoveIf(item =>
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

            return source.RemoveIf(item =>
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

                yield return item;
            }
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

        #region Flatten

        /// <summary>
        /// 将多层的集合展开并整理为单层集合
        /// </summary>
        /// <param name="src"></param>
        /// <param name="enumerate"></param>
        /// <returns></returns>
        // ReSharper disable once FunctionRecursiveOnAllPaths
        public static IEnumerable Flatten(IEnumerable src, Func<object, IEnumerable> enumerate)
        {
            return Flatten(src.Cast<object>(), o => (enumerate(o) ?? Arrays.Empty<object>()).Cast<object>());
        }
        
        /// <summary>
        /// 将多层的集合展开并整理为单层集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">   </param>
        /// <param name="enumerate"></param>
        /// <returns></returns>
        public static IEnumerable<T> Flatten<T>(IEnumerable<T> source, Func<T, IEnumerable<T>> enumerate)
        {
            if (source is null) 
                yield break;
            
            var stack = new Stack<T>(source);

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

        #endregion

        /// <summary>
        /// ReadOnly Collection
        /// </summary>
        public static partial class ReadOnly
        {
            #region AddRange

            /// <summary>
            /// Add range
            /// </summary>
            /// <param name="set"></param>
            /// <param name="items"></param>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            /// <exception cref="ArgumentNullException"></exception>
            public static IReadOnlyCollection<SetAddRangeResult<T>> AddRange<T>(ISet<T> set, IEnumerable<T> items)
            {
                if (set is null)
                    throw new ArgumentNullException(nameof(set));
                if (items is null)
                    throw new ArgumentNullException(nameof(items));

                var added = new List<SetAddRangeResult<T>>(items is ICollection<T> collection ? collection.Count : 1);

                added.AddRange(items.Select(i => new SetAddRangeResult<T>(i, set.Add(i))));

                return ReadOnlyCollsHelper.WrapInReadOnlyCollection(added);
            }

            #endregion
        }
    }

    public static partial class CollsExtensions
    {
        #region Add

        public static TColl AddRange<TColl, T>(this TColl source, IEnumerable<T> collection)
            where TColl : IList<T>
        {
            return Colls.AddRange(source, collection);
        }

        public static TColl AddRange<TColl, T>(this TColl source, IEnumerable<T> collection, int limit)
            where TColl : IList<T>
        {
            return Colls.AddRange(source, collection, limit);
        }

        public static TColl AddIf<TColl, T>(this TColl source, T value, bool flag)
            where TColl : ICollection<T>
        {
            return Colls.AddIf(source, value, flag);
        }

        public static TColl AddIf<TColl, T>(this TColl source, T value, Func<bool> condition)
            where TColl : ICollection<T>
        {
            return Colls.AddIf(source, value, condition);
        }

        public static TColl AddIf<TColl, T>(this TColl source, T value, Func<T, bool> condition)
            where TColl : ICollection<T>
        {
            return Colls.AddIf(source, value, condition);
        }

        public static TColl AddIfNotExist<TColl, T>(this TColl source, T value, Func<T, bool> existFunc = null)
            where TColl : ICollection<T>
        {
            return Colls.AddIf(source, value, v => existFunc?.Invoke(v) ?? source.Contains(v));
        }

        public static TColl AddIfNotNull<TColl, T>(this TColl source, T value)
            where T : class
            where TColl : ICollection<T>
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

        #region Flatten

        /// <summary>
        /// 将多层的集合展开并整理为单层集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">   </param>
        /// <param name="enumerate"></param>
        /// <returns></returns>
        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> enumerate)
        {
            return Colls.Flatten(source, enumerate);
        }

        #endregion
    }
    
    /// <summary>
    /// Set and range result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SetAddRangeResult<T>
    {
        /// <summary>
        /// Create a new instance of <see cref="SetAddRangeResult{T}"/>
        /// </summary>
        /// <param name="item"></param>
        /// <param name="added"></param>
        public SetAddRangeResult(T item, bool added)
        {
            // Set values.
            Item = item;
            Added = added;
        }

        /// <summary>
        /// Gets item
        /// </summary>
        public T Item { get; }

        /// <summary>
        /// Addod or not...
        /// </summary>
        public bool Added { get; }
    }
}