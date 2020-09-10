using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Cosmos.Collections.Internals;

namespace Cosmos.Collections
{
    public static partial class EnumerableExtensions
    {
        #region Append

        /// <summary>
        /// Append
        /// </summary>
        /// <param name="source"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, params T[] items)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return items is null ? source : source.Concat(items);
        }

        #endregion

        #region As

        /// <summary>
        /// 将集合转换为只读集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static ReadOnlyCollection<T> AsReadOnly<T>(this IEnumerable<T> enumerable)
        {
            return new ReadOnlyCollection<T>(new List<T>(enumerable));
        }

        /// <summary>
        /// As enumerable proxy
        /// </summary>
        /// <param name="enumerable"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static EnumerableProxy<T> AsEnumerableProxy<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable is null)
                throw new ArgumentNullException(nameof(enumerable));
            return new EnumerableProxy<T>(enumerable);
        }

        /// <summary>
        /// As Nullables
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T?> AsNullables<T>(this IEnumerable<T> source) where T : struct
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return source.Cast<T?>();
        }

        #endregion

        #region Chunk

        /// <summary>
        /// Chunk
        /// </summary>
        /// <param name="source"></param>
        /// <param name="size"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int size)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size), size, $"The {nameof(size)} parameter must be a positive value.");

            using (var enumerator = source.GetEnumerator())
            {
                do
                {
                    if (!enumerator.MoveNext())
                        yield break;

                    yield return ChunkSequence(enumerator, size);
                } while (true);
            }
        }

        private static IEnumerable<T> ChunkSequence<T>(IEnumerator<T> enumerator, int size)
        {
            if (enumerator is null)
                throw new ArgumentNullException(nameof(enumerator));

            var count = 0;

            do
            {
                yield return enumerator.Current;
            } while (++count < size && enumerator.MoveNext());
        }

        #endregion

        #region Count

        /// <summary>
        /// Count distinct
        /// </summary>
        /// <param name="list"></param>
        /// <param name="valCalculator"></param>
        /// <typeparam name="TObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static int CountDistinct<TObj, TResult>(this IList<TObj> list, Func<TObj, TResult> valCalculator)
        {
            var check = new HashSet<TResult>();

            foreach (var item in list)
            {
                var result = valCalculator(item);
                if (!check.Contains(result))
                    check.Add(result);
            }

            return check.Count;
        }

        #endregion

        #region Flatten

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

        #endregion

        #region ForEach

        /// <summary>
        /// Do action for each item
        /// </summary>
        /// <param name="src"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ForEach<T>(this IEnumerable<T> src, Action<T> action)
        {
            if (src is null) throw new ArgumentNullException(nameof(src));
            if (action is null) return;
            foreach (var i in src) action(i);
        }

        /// <summary>
        /// Do action for each item, and returns the result.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> ForEachItem<T>(this IEnumerable<T> src, Action<T> action)
        {
            if (src is null) throw new ArgumentNullException(nameof(src));
            if (action is null) return src;

            return src.Select(i =>
            {
                action(i);
                return i;
            });
        }

        #endregion

        #region Get

        /// <summary>
        /// Null if empty
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> NullIfEmpty<T>(this IEnumerable<T> source)
        {
            // Get the enumerator in a releasable disposable.
            using var disposable = new InternalReleasableDisposable<IEnumerator<T>>(source.GetEnumerator());
            // Get the enumerator.
            var enumerator = disposable.Disposable;

            // Move to the next item.  If there are no elements, then return null.
            if (!enumerator.MoveNext()) return null;

            // Release the disposable.
            disposable.Release();

            // Create an enumerator that skips the first move next.
            var wrapper = new InternalNullIfEmptySkipFirstMoveNextEnumeratorWrapper<T>(enumerator);

            // Wrap in a single use enumerator, return that.
            return new InternalSingleUseEnumerable<T>(wrapper);
        }

        #endregion

        #region Harvest

        /// <summary>
        /// Harvest
        /// </summary>
        /// <param name="source"></param>
        /// <param name="harvester"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Harvest<T>(this IEnumerable<T> source, ICollection<T> harvester)
            => source.Harvest(null, harvester);

        /// <summary>
        /// Harvest
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="harvester"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Harvest<T>(this IEnumerable<T> source, Func<T, bool> predicate, ICollection<T> harvester)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (harvester is null)
                throw new ArgumentNullException(nameof(harvester));
            if (predicate is null)
                predicate = t => true;

            foreach (var item in source)
            {
                if (!predicate(item))
                    continue;

                harvester.Add(item);
                yield return item;
            }
        }

        #endregion

        #region BasedOn

        /// <summary>
        /// First based on...
        /// </summary>
        /// <param name="list"></param>
        /// <param name="order"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public static TItem FirstBasedOn<TItem>(this IList<TItem> list, Func<TItem, IComparable> order) where TItem : class
        {
            if (!list.Any()) return default;
            var first = default(TItem);
            IComparable valueFirst = null;

            foreach (var item in list)
            {
                var actual = order(item);
                if (valueFirst is null || actual.CompareTo(valueFirst) < 0)
                {
                    valueFirst = actual;
                    first = item;
                }
            }

            return first;
        }

        /// <summary>
        /// Last based on...
        /// </summary>
        /// <param name="list"></param>
        /// <param name="order"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public static TItem LastBasedOn<TItem>(this List<TItem> list, Func<TItem, IComparable> order)
        {
            if (!list.Any()) return default;
            var last = default(TItem);
            IComparable valueLast = null;

            foreach (var item in list)
            {
                var actual = order(item);
                if (valueLast is null || actual.CompareTo(valueLast) >= 0)
                {
                    valueLast = actual;
                    last = item;
                }
            }

            return last;
        }

        #endregion

        #region Index

        /// <summary>
        /// Index of
        /// </summary>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int? IndexOf<T>(this IEnumerable<T> source, T item) => source.IndexOf(item, EqualityComparer<T>.Default);

        /// <summary>
        /// Index of
        /// </summary>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <param name="equalityComparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static int? IndexOf<T>(this IEnumerable<T> source, T item, IEqualityComparer<T> equalityComparer)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (equalityComparer is null)
                throw new ArgumentNullException(nameof(equalityComparer));

            return source.Select((i, index) => new {Item = i, Index = index})
                         .FirstOrDefault(p => equalityComparer.Equals(p.Item, item))
                         ?.Index;
        }

        #endregion

        #region Intercept

        /// <summary>
        /// Intercept
        /// </summary>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Intercept<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (action is null)
                throw new ArgumentNullException(nameof(action));

            return source.Select(t =>
            {
                action(t);
                return t;
            });
        }

        #endregion

        #region Contains

        /// <summary>
        /// Contains<br />
        /// 包含
        /// </summary>
        /// <param name="me"></param>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool Contains<T>(this IEnumerable<T> me, Predicate<T> condition) =>
            me.Any(val => condition(val));

        #endregion

        #region In

        /// <summary>
        /// In
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool In<T>(this T item, params T[] items) => item.In((IEnumerable<T>) items);

        /// <summary>
        /// In
        /// </summary>
        /// <param name="item"></param>
        /// <param name="equalityComparer"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool In<T>(this T item, IEqualityComparer<T> equalityComparer, params T[] items) => item.In(items, equalityComparer);

        /// <summary>
        /// In
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool In<T>(this T item, IEnumerable<T> items) => item.In(items, EqualityComparer<T>.Default);

        /// <summary>
        /// In
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <param name="equalityComparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool In<T>(this T item, IEnumerable<T> items, IEqualityComparer<T> equalityComparer)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));
            if (equalityComparer is null)
                throw new ArgumentNullException(nameof(equalityComparer));

            return items.Contains(item, equalityComparer);
        }

        #endregion

        #region Merge

        /// <summary>
        /// Merge<br />
        /// 合并集合
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Merge<T>(this IEnumerable<T> left, IEnumerable<T> right)
        {
            if (left is null) throw new ArgumentNullException(nameof(left));
            foreach (var item in left)
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
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="limit"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Merge<T>(this IEnumerable<T> left, IEnumerable<T> right, int limit)
        {
            if (left is null) throw new ArgumentNullException(nameof(left));
            foreach (var item in left)
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

        #region Sort

        /// <summary>
        /// Make the collection random order<br />
        /// 打乱一个集合的顺序
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> RandomOrder<TSource>(this IEnumerable<TSource> source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return source.OrderBy(o => Guid.NewGuid());
        }

        #endregion

        #region Split

        /// <summary>
        /// Split in groups
        /// </summary>
        /// <param name="values"></param>
        /// <param name="groupSize"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IEnumerable<List<TSource>> SplitInGroups<TSource>(this IEnumerable<TSource> values, int groupSize)
        {
            if (values is List<TSource> asList && asList.Count <= groupSize)
            {
                yield return asList;
                yield break;
            }

            var currentList = new List<TSource>(groupSize);

            foreach (var value in values)
            {
                if (currentList.Count >= groupSize)
                {
                    yield return currentList;
                    currentList = new List<TSource>(groupSize);
                }

                currentList.Add(value);
            }

            if (currentList.Count > 0)
                yield return currentList;
        }

        /// <summary>
        /// Split in groups remove duplicates
        /// </summary>
        /// <param name="values"></param>
        /// <param name="groupSize"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static List<List<TSource>> SplitInGroupsAndRemoveDuplicate<TSource>(this IEnumerable<TSource> values, int groupSize)
        {
            var res = new List<List<TSource>>();

            var duplicateCheck = new HashSet<TSource>();
            var currentList = new List<TSource>(groupSize);

            foreach (var value in values)
            {
                if (duplicateCheck.Contains(value))
                    continue;

                duplicateCheck.Add(value);

                if (currentList.Count >= groupSize)
                {
                    res.Add(currentList);
                    currentList = new List<TSource>(groupSize);
                }

                currentList.Add(value);
            }

            if (currentList.Count > 0)
                res.Add(currentList);

            return res;
        }

        #endregion

        #region To

        /// <summary>
        /// To index sequence
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<KeyValuePair<int, T>> ToIndexedSequence<T>(this IEnumerable<T> src)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            return src.Select((t, i) => new KeyValuePair<int, T>(i, t));
        }

        /// <summary>
        /// To safe array
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        public static TElement[] ToSafeArray<TElement>(this IEnumerable<TElement> src) =>
            src as TElement[] ?? src.ToArray();

        #endregion

        #region To Dictionary

        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> src) =>
            src.ToDictionary(EqualityComparer<TKey>.Default);

        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <param name="equalityComparer"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> src, IEqualityComparer<TKey> equalityComparer)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (equalityComparer is null)
                throw new ArgumentNullException(nameof(equalityComparer));
            return src.ToDictionary(p => p.Key, p => p.Value, equalityComparer);
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <param name="keySelector"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<TValue> src, Func<TValue, TKey> keySelector)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));

            return src.ToDictionary(keySelector).WrapInReadOnlyDictionary();
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <param name="keySelector"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<TValue> src, Func<TValue, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return src.ToDictionary(keySelector, comparer).WrapInReadOnlyDictionary();
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TSource, TKey, TValue>(
            this IEnumerable<TSource> src, Func<TSource, TKey> keySelector,
            Func<TSource, TValue> elementSelector,
            IEqualityComparer<TKey> comparer)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector is null)
                throw new ArgumentNullException(nameof(elementSelector));
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return src.ToDictionary(keySelector, elementSelector, comparer).WrapInReadOnlyDictionary();
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TSource, TKey, TValue>(
            this IEnumerable<TSource> src, Func<TSource, TKey> keySelector,
            Func<TSource, TValue> elementSelector)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector is null)
                throw new ArgumentNullException(nameof(elementSelector));

            return src.ToDictionary(keySelector, elementSelector).WrapInReadOnlyDictionary();
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> src)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));

            return new ReadOnlyDictionary<TKey, TValue>(src.ToDictionary(p => p.Key, p => p.Value, EqualityComparer<TKey>.Default));
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> src, IEqualityComparer<TKey> comparer)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new ReadOnlyDictionary<TKey, TValue>(src.ToDictionary(p => p.Key, p => p.Value, comparer));
        }

        #endregion

        #region To SortedArray

        /// <summary>
        /// To sorted array
        /// </summary>
        /// <param name="source"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static TSource[] ToSortedArray<TSource>(this IEnumerable<TSource> source, Comparison<TSource> comparer)
        {
            var res = source.ToArray();
            Array.Sort(res, comparer);
            return res;
        }

        /// <summary>
        /// To sorted array
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static TSource[] ToSortedArray<TSource>(this IEnumerable<TSource> source) where TSource : IComparable<TSource>
        {
            var res = source.ToArray();
            Array.Sort(res);
            return res;
        }

        #endregion
    }
}