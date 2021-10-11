using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

// ReSharper disable MemberHidesStaticFromOuterClass

namespace CosmosStack.Collections
{
    /// <summary>
    /// Linq Collection Helper
    /// </summary>
    internal static class LinqCollsHelper
    {
        public static IEnumerable<T> EnumerableTakeLast<T>(IEnumerable<T> source, int count)
        {
            var window = new Queue<T>(count);

            foreach (T item in source)
            {
                window.Enqueue(item);
                if (window.Count > count)
                    window.Dequeue();
            }

            return window;
        }

        public static IEnumerable<T> CollectionTakeLast<T>(ICollection<T> source, int count)
        {
            count = Math.Min(source.Count, count);

            if (count == 0)
                return Enumerable.Empty<T>();

            if (count == source.Count)
                return source;

            return source.Skip(source.Count - count);
        }

        public static IEnumerable<T> ReadOnlyCollectionTakeLast<T>(IReadOnlyCollection<T> source, int count)
        {
            count = Math.Min(source.Count, count);

            if (count == 0)
                return Enumerable.Empty<T>();

            if (count == source.Count)
                return source;

            return source.Skip(source.Count - count);
        }
    }

    /// <summary>
    /// Collections Utilities <br />
    /// 集合工具
    /// </summary>
    public static partial class Colls
    {
        #region BeContainedIn

        /// <summary>
        /// In <br />
        /// 判断元素是否包含在给定的集合内
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool BeContainedIn<T>(T item, IEnumerable<T> items)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            return items.Contains(item, EqualityComparer<T>.Default);
        }

        /// <summary>
        /// In <br />
        /// 判断元素是否包含在给定的集合内
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <param name="equalityComparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool BeContainedIn<T>(T item, IEnumerable<T> items, IEqualityComparer<T> equalityComparer)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));
            if (equalityComparer is null)
                throw new ArgumentNullException(nameof(equalityComparer));

            return items.Contains(item, equalityComparer);
        }

        /// <summary>
        /// In <br />
        /// 判断元素是否包含在给定的集合内
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool BeContainedIn<T>(T item, IEnumerable<T> items, Expression<Func<T, bool>> condition)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            return items.Where(condition.Compile()).Contains(item, EqualityComparer<T>.Default);
        }

        /// <summary>
        /// In <br />
        /// 判断元素是否包含在给定的集合内
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <param name="condition"></param>
        /// <param name="equalityComparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool BeContainedIn<T>(T item, IEnumerable<T> items, Expression<Func<T, bool>> condition, IEqualityComparer<T> equalityComparer)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));
            if (equalityComparer is null)
                throw new ArgumentNullException(nameof(equalityComparer));

            return items.Where(condition.Compile()).Contains(item, equalityComparer);
        }

        #endregion

        #region Contains

        /// <summary>
        /// Check whether the set contains members of the given condition.<br />
        /// 检查集合中是否包含给定条件的成员。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool Contains<T>(IEnumerable<T> source, Expression<Func<T, bool>> condition)
        {
            if (condition is null)
                throw new ArgumentNullException(nameof(condition));
            var func = condition.Compile();
            return source.Any(item => func.Invoke(item));
        }

        /// <summary>
        /// Check if a set has a specified number of members. <br />
        /// 检查一个集合是否拥有指定数量的成员
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAtLeast<T>(ICollection<T> source, int count)
        {
            return source?.Count >= count;
        }

        /// <summary>
        /// Check if a set has a specified number of members. <br />
        /// 检查一个集合是否拥有指定数量的成员
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAtLeast<T>(IEnumerable<T> source, Expression<Func<T, bool>> condition, int count)
        {
            return source?.Where(condition.Compile()).Count() >= count;
        }

        /// <summary>
        /// Check if a set has a specified number of members. <br />
        /// 检查一个集合是否拥有指定数量的成员
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool ContainsAtLeast<T>(IQueryable<T> source, int count)
        {
            if (source is null)
                return false;
            return source.Take(count).Count() >= count;
        }

        #endregion

        #region Empty

        /// <summary>
        /// Create an empty list instance of the specified type T. <br />
        /// 创建一个指定类型 T 的空列表实例。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<T> Empty<T>() => CosmosStack.Collections.Arrays.Empty<T>().ToList();

        #endregion

        #region IndexOf

        /// <summary>
        /// Index of <br />
        /// 获取给定元素在集合中的索引值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int IndexOf<T>(IEnumerable<T> source, T item)
        {
            return IndexOf(source, item, EqualityComparer<T>.Default);
        }

        /// <summary>
        /// Index of <br />
        /// 获取给定元素在集合中的索引值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <param name="equalityComparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static int IndexOf<T>(IEnumerable<T> source, T item, IEqualityComparer<T> equalityComparer)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (equalityComparer is null)
                throw new ArgumentNullException(nameof(equalityComparer));

            return source.Select((i, index) => new { Item = i, Index = index })
                         .FirstOrDefault(p => equalityComparer.Equals(p.Item, item))
                         ?.Index ?? -1;
        }

        #endregion

        #region Move

        /// <summary>
        /// Move to first <br />
        /// 移动到首位
        /// </summary>
        /// <param name="source"></param>
        /// <param name="element"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static List<TSource> MoveToFirst<TSource>(List<TSource> source, TSource element)
        {
            if (!source.Contains(element))
                return source;
            source.Remove(element);
            source.Insert(0, element);
            return source;
        }

        #endregion

        #region OrderByRandom

        /// <summary>
        /// Make the collection random order<br />
        /// 打乱一个集合的顺序
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TSource> OrderByRandom<TSource>(IEnumerable<TSource> source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return source.OrderBy(_ => Guid.NewGuid());
        }

        #endregion

        #region OrderByShuffle

        /// <summary>
        /// Shuffle in place <br />
        /// 原地打乱
        /// </summary>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void OrderByShuffle<T>(IList<T> items)
        {
            OrderByShuffle(items, 4);
        }

        /// <summary>
        /// Shuffle in place <br />
        /// 原地打乱
        /// </summary>
        /// <param name="items"></param>
        /// <param name="times"></param>
        /// <typeparam name="T"></typeparam>
        public static void OrderByShuffle<T>(IList<T> items, int times)
        {
            for (var j = 0; j < times; j++)
            {
                var rnd = new Random((int)(DateTime.Now.Ticks % int.MaxValue) - j);

                for (var i = 0; i < items.Count; i++)
                {
                    var index = rnd.Next(items.Count - 1);
                    (items[index], items[i]) = (items[i], items[index]);
                }
            }
        }

        /// <summary>
        /// Shuffle to new list <br />
        /// 原地打乱并返回一个新列表
        /// </summary>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<T> OrderByShuffleAndNewInstance<T>(IList<T> items)
        {
            return OrderByShuffleAndNewInstance(items, 4);
        }

        /// <summary>
        /// Shuffle to new list <br />
        /// 原地打乱并返回一个新列表
        /// </summary>
        /// <param name="items"></param>
        /// <param name="times"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> OrderByShuffleAndNewInstance<T>(IList<T> items, int times)
        {
            var res = new List<T>(items);
            OrderByShuffle(res, times);
            return res;
        }

        #endregion

        #region Unique Count

        /// <summary>
        /// Unique Count <br />
        /// 不重复元素的数量
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="TObj"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UniqueCount<TObj>(IEnumerable<TObj> source)
        {
            return UniqueCount(source, val => val);
        }

        /// <summary>
        /// Unique Count <br />
        /// 不重复元素的数量
        /// </summary>
        /// <param name="source"></param>
        /// <param name="valCalculator"></param>
        /// <typeparam name="TObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static int UniqueCount<TObj, TResult>(IEnumerable<TObj> source, Func<TObj, TResult> valCalculator)
        {
            var check = new HashSet<TResult>();

            foreach (var item in source)
            {
                var result = valCalculator(item);
                if (!check.Contains(result))
                    check.Add(result);
            }

            return check.Count;
        }

        #endregion
    }

    /// <summary>
    /// Collection Utilities Extensions <br />
    /// 集合工具扩展
    /// </summary>
    public static partial class CollsExtensions
    {
        #region BeContainedIn

        /// <summary>
        /// In <br />
        /// 判断元素是否包含在给定的集合内
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BeContainedIn<T>(this T item, params T[] items)
        {
            return Colls.BeContainedIn(item, items, EqualityComparer<T>.Default);
        }

        /// <summary>
        /// In <br />
        /// 判断元素是否包含在给定的集合内
        /// </summary>
        /// <param name="item"></param>
        /// <param name="equalityComparer"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BeContainedIn<T>(this T item, IEqualityComparer<T> equalityComparer, params T[] items)
        {
            return Colls.BeContainedIn(item, items, equalityComparer);
        }

        /// <summary>
        /// In <br />
        /// 判断元素是否包含在给定的集合内
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BeContainedIn<T>(this T item, IEnumerable<T> items)
        {
            return Colls.BeContainedIn(item, items, EqualityComparer<T>.Default);
        }

        /// <summary>
        /// In <br />
        /// 判断元素是否包含在给定的集合内
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <param name="equalityComparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BeContainedIn<T>(this T item, IEnumerable<T> items, IEqualityComparer<T> equalityComparer)
        {
            return Colls.BeContainedIn(item, items, equalityComparer);
        }

        /// <summary>
        /// In <br />
        /// 判断元素是否包含在给定的集合内
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BeContainedIn<T>(this T item, IEnumerable<T> items, Expression<Func<T, bool>> condition)
        {
            return Colls.BeContainedIn(item, items, condition);
        }

        /// <summary>
        /// In <br />
        /// 判断元素是否包含在给定的集合内
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <param name="condition"></param>
        /// <param name="equalityComparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool BeContainedIn<T>(this T item, IEnumerable<T> items, Expression<Func<T, bool>> condition, IEqualityComparer<T> equalityComparer)
        {
            return Colls.BeContainedIn(item, items, condition, equalityComparer);
        }

        #endregion

        #region Contains

        /// <summary>
        /// Check whether the set contains members of the given condition.<br />
        /// 检查集合中是否包含给定条件的成员。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this IEnumerable<T> source, Expression<Func<T, bool>> condition)
        {
            return Colls.Contains(source, condition);
        }

        /// <summary>
        /// Check if a set has a specified number of members. <br />
        /// 检查一个集合是否拥有指定数量的成员
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAtLeast<T>(this ICollection<T> source, int count)
        {
            return Colls.ContainsAtLeast(source, count);
        }

        /// <summary>
        /// Check if a set has a specified number of members. <br />
        /// 检查一个集合是否拥有指定数量的成员
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAtLeast<T>(this IEnumerable<T> source, Expression<Func<T, bool>> condition, int count)
        {
            return Colls.ContainsAtLeast(source, condition, count);
        }

        /// <summary>
        /// Check if a set has a specified number of members. <br />
        /// 检查一个集合是否拥有指定数量的成员
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsAtLeast<T>(this IQueryable<T> source, int count)
        {
            return Colls.ContainsAtLeast(source, count);
        }

        #endregion

        #region IndexOf

        /// <summary>
        /// Index of <br />
        /// 获取给定元素在集合中的索引值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int IndexOf<T>(this IEnumerable<T> source, T item)
        {
            return Colls.IndexOf(source, item, EqualityComparer<T>.Default);
        }

        /// <summary>
        /// Index of <br />
        /// 获取给定元素在集合中的索引值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <param name="equalityComparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int IndexOf<T>(this IEnumerable<T> source, T item, IEqualityComparer<T> equalityComparer)
        {
            return Colls.IndexOf(source, item, equalityComparer);
        }

        #endregion

        #region OrderByRandom

        /// <summary>
        /// Make the collection random order<br />
        /// 打乱一个集合的顺序
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TSource> OrderByRandom<TSource>(this IEnumerable<TSource> source)
        {
            return Colls.OrderByRandom(source);
        }

        #endregion

        #region OrderByShuffle

        /// <summary>
        /// Shuffle in place <br />
        /// 原地打乱
        /// </summary>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void OrderByShuffle<T>(this IList<T> items)
        {
            Colls.OrderByShuffle(items);
        }

        /// <summary>
        /// Shuffle in place <br />
        /// 原地打乱
        /// </summary>
        /// <param name="items"></param>
        /// <param name="times"></param>
        /// <typeparam name="T"></typeparam>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void OrderByShuffle<T>(this IList<T> items, int times)
        {
            Colls.OrderByShuffle(items, times);
        }

        /// <summary>
        /// Shuffle to new list <br />
        /// 原地打乱，并返回一个新列表
        /// </summary>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<T> OrderByShuffleAndNewInstance<T>(this IList<T> items)
        {
            return Colls.OrderByShuffleAndNewInstance(items);
        }

        /// <summary>
        /// Shuffle to new list <br />
        /// 原地打乱，并返回一个新列表
        /// </summary>
        /// <param name="items"></param>
        /// <param name="times"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<T> OrderByShuffleAndNewInstance<T>(this IList<T> items, int times)
        {
            return Colls.OrderByShuffleAndNewInstance(items, times);
        }

        #endregion

        #region Unique Count

        /// <summary>
        /// Unique Count <br />
        /// 不重复元素的数量
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="TObj"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UniqueCount<TObj>(this IEnumerable<TObj> source)
        {
            return Colls.UniqueCount(source);
        }

        /// <summary>
        /// Unique Count <br />
        /// 不重复元素的数量
        /// </summary>
        /// <param name="source"></param>
        /// <param name="valCalculator"></param>
        /// <typeparam name="TObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int UniqueCount<TObj, TResult>(this IEnumerable<TObj> source, Func<TObj, TResult> valCalculator)
        {
            return Colls.UniqueCount(source, valCalculator);
        }

        #endregion
    }
}