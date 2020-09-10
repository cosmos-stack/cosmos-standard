using System.Linq;

namespace System.Collections.Generic
{
    /// <summary>
    /// Cosmos List extensions
    /// </summary>
    public static class SystemListExtensions
    {
        #region Add

        /// <summary>
        /// Add range
        /// </summary>
        /// <param name="source"></param>
        /// <param name="collection"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<T> AddRange<T>(this IList<T> source, IList<T> collection)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            foreach (var item in collection)
                source.Add(item);
            return source;
        }

        /// <summary>
        /// Add range
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="collection"></param>
        /// <param name="limit"></param>
        public static void AddRange<T>(this List<T> source, IEnumerable<T> collection, int limit)
        {
            if (limit <= 0)
            {
                source.AddRange(collection);
                return;
            }

            var counter = 0;
            source.AddRange(collection.TakeWhile(item => counter++ < limit));
        }

        /// <summary>
        /// Add into
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<T> AddRangeInto<T>(this IList<T> source, IList<T> target)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (target is null)
                throw new ArgumentNullException(nameof(target));
            target.AddRange(source);
            return target;
        }

        #endregion

        #region Remove

        /// <summary>
        /// Remove deplicates
        /// </summary>
        /// <param name="values"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TSource> RemoveDuplicates<TSource>(this IList<TSource> values)
        {
            var duplicateCheck = new HashSet<TSource>();

            return values.RemoveIf(item =>
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
        /// <param name="values"></param>
        /// <param name="duplicatePredicate"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCheck"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TSource> RemoveDuplicates<TSource, TCheck>(this IList<TSource> values, Func<TSource, TCheck> duplicatePredicate)
        {
            if (duplicatePredicate is null)
                throw new ArgumentNullException(nameof(duplicatePredicate));

            var duplicateCheck = new HashSet<TCheck>();

            return values.RemoveIf(item =>
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
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<string> RemoveDuplicatesIgnoreCase(this IList<string> values)
        {
            var duplicateCheck = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            return values.RemoveIf(item =>
            {
                if (duplicateCheck.Contains(item))
                    return true;

                duplicateCheck.Add(item);
                return false;
            });
        }

        #endregion
        
        #region Remove If

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

        #endregion

        #region ToDictionary

        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="list"></param>
        /// <param name="keyFunc"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, TItem> ToDictionary<TKey, TItem>(this IList<TItem> list, Func<TItem, TKey> keyFunc)
        {
            return ToDictionary(list, keyFunc, x => x);
        }

        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="list"></param>
        /// <param name="keyFunc"></param>
        /// <param name="valueFunc"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> ToDictionary<TItem, TKey, TValue>(this IList<TItem> list, Func<TItem, TKey> keyFunc, Func<TItem, TValue> valueFunc)
        {
            var res = new Dictionary<TKey, TValue>(list.Count);
            foreach (var item in list)
            {
                res.Add(keyFunc(item), valueFunc(item));
            }

            return res;
        }

        #endregion
    }
}