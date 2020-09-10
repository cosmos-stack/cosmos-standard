using System.Collections.ObjectModel;
using System.Linq;
using Cosmos.Collections;

namespace System.Collections.Generic
{
    public static class SystemEnumerableExtensions
    {
        #region Linq-Select

        /// <summary>
        /// Select distinct sorted
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="valCalculator"></param>
        /// <typeparam name="TObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static IList<TResult> SelectDistinctSorted<TObj, TResult>(this IEnumerable<TObj> collection, Func<TObj, TResult> valCalculator)
        {
            var list = collection as TObj[] ?? collection.ToArray();
            var res = new SortedList<TResult, TResult>(list.Length);
            return SelectDistinctSortedInternal(list, res, valCalculator);
        }

        /// <summary>
        /// Select distinct sorted ignore case
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static IList<string> SelectDistinctSortedIgnoreCase(this IEnumerable<string> collection)
        {
            var list = collection as string[] ?? collection.ToArray();
            var res = new SortedList<string, string>(list.Length, StringComparer.OrdinalIgnoreCase);
            return SelectDistinctSortedInternal(list, res, str => str);
        }

        /// <summary>
        /// Select distinct sorted ignore case
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="valCalculator"></param>
        /// <returns></returns>
        public static IList<string> SelectDistinctSortedIgnoreCase(this IEnumerable<string> collection, Func<string, string> valCalculator)
        {
            var list = collection as string[] ?? collection.ToArray();
            var res = new SortedList<string, string>(list.Length, StringComparer.OrdinalIgnoreCase);
            return SelectDistinctSortedInternal(list, res, valCalculator);
        }

        private static IList<TResult> SelectDistinctSortedInternal<TObj, TResult>(IEnumerable<TObj> collection, SortedList<TResult, TResult> check,
            Func<TObj, TResult> valCalculator)
        {
            foreach (var item in collection)
            {
                var result = valCalculator(item);
                if (!check.ContainsKey(result))
                    check.Add(result, result);
            }

            return check.Values.ToList();
        }

        /// <summary>
        /// Select distinct un-sorted
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="valCalculator"></param>
        /// <typeparam name="TObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static IList<TResult> SelectDistinctUnsorted<TObj, TResult>(this IEnumerable<TObj> collection, Func<TObj, TResult> valCalculator)
        {
            var res = new List<TResult>();
            var check = new HashSet<TResult>();
            foreach (var item in collection)
            {
                var result = valCalculator(item);
                if (!check.Contains(result))
                {
                    check.Add(result);
                    res.Add(result);
                }
            }

            return res;
        }

        #endregion

        #region Linq-Take

        /// <summary>
        /// Take last
        /// </summary>
        /// <param name="src"></param>
        /// <param name="count"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> src, int count)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), count, $"The {nameof(count)} parameter must be a non-negative number.");

            // If the count is zero, return empty.
            if (count == 0)
                return Enumerable.Empty<T>();

            // Start sniffing.
            // Read-only collection.
            if (src is IReadOnlyCollection<T> ro)
                return ro.ReadOnlyCollectionTakeLast(count);

            // Collection.
            if (src is ICollection<T> c)
                return c.CollectionTakeLast(count);

            // Default.
            return src.EnumerableTakeLast(count);
        }

        private static IEnumerable<T> EnumerableTakeLast<T>(this IEnumerable<T> src, int count)
        {
            var window = new Queue<T>(count);

            foreach (T item in src)
            {
                window.Enqueue(item);
                if (window.Count > count)
                    window.Dequeue();
            }

            return window;
        }

        private static IEnumerable<T> CollectionTakeLast<T>(this ICollection<T> src, int count)
        {
            count = Math.Min(src.Count, count);

            if (count == 0)
                return Enumerable.Empty<T>();

            if (count == src.Count)
                return src;

            return src.Skip(src.Count - count);
        }

        private static IEnumerable<T> ReadOnlyCollectionTakeLast<T>(this IReadOnlyCollection<T> src, int count)
        {
            count = Math.Min(src.Count, count);

            if (count == 0)
                return Enumerable.Empty<T>();

            if (count == src.Count)
                return src;

            return src.Skip(src.Count - count);
        }

        #endregion

        #region ReadOnly

        /// <summary>
        /// To readonly collection
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> src)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            return src.ToList().WrapInReadOnlyCollection();
        }

        #endregion

        #region To List

        /// <summary>
        /// To string list
        /// </summary>
        /// <param name="me"></param>
        /// <param name="stringConverter"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<string> ToList<T>(this IEnumerable<T> me, Func<T, string> stringConverter)
            => me.Select(stringConverter).ToList();

        /// <summary>
        /// To list
        /// </summary>
        /// <param name="src"></param>
        /// <param name="func"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<T> ToList<T>(this IEnumerable<T> src, Func<T, bool> func)
        {
            if (src is null) throw new ArgumentNullException(nameof(src));
            return func is null ? src.ToList() : src.Where(func).ToList();
        }

        #endregion
    }
}