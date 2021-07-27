using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cosmos.Collections.Internals;

namespace Cosmos.Collections
{
    public static class CollConv
    {
        #region ToEnumerable

        /// <summary>
        /// To Enumerable
        /// </summary>
        /// <param name="enumerator"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> ToEnumerable<T>(IEnumerator<T> enumerator)
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
        public static IEnumerable<T> ToEnumerableAfter<T>(IEnumerator<T> enumerator)
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

        #region ToIndexedSequence

        /// <summary>
        /// To index sequence
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<KeyValuePair<int, T>> ToIndexedSequence<T>(IEnumerable<T> source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return source.Select((t, i) => new KeyValuePair<int, T>(i, t));
        }

        #endregion

        #region ToSortedArray

        /// <summary>
        /// To sorted array
        /// </summary>
        /// <param name="source"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static TSource[] ToSortedArray<TSource>(IEnumerable<TSource> source, Comparison<TSource> comparer)
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
        public static TSource[] ToSortedArray<TSource>(IEnumerable<TSource> source) where TSource : IComparable<TSource>
        {
            var res = source.ToArray();
            Array.Sort(res);
            return res;
        }

        #endregion

        #region AsOptionals

        /// <summary>
        /// As Nullables
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T?> AsOptionals<T>(IEnumerable<T> source) where T : struct
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return source.Cast<T?>();
        }

        #endregion

        #region AsProxy

        /// <summary>
        /// As enumerable proxy
        /// </summary>
        /// <param name="enumerable"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static EnumerableProxy<T> AsEnumerableProxy<T>(IEnumerable<T> enumerable)
        {
            if (enumerable is null)
                throw new ArgumentNullException(nameof(enumerable));
            return new EnumerableProxy<T>(enumerable);
        }

        #endregion

        #region AsNullWhenEmpty

        /// <summary>
        /// Null if empty
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> AsNullWhenEmpty<T>(this IEnumerable<T> source)
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
    }

    public static class CollConvExtensions
    {
        #region ToEnumerable

        /// <summary>
        /// To Enumerable
        /// </summary>
        /// <param name="enumerator"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> ToEnumerable<T>(this IEnumerator<T> enumerator)
        {
            return CollConv.ToEnumerable(enumerator);
        }

        /// <summary>
        /// To Enumerable After
        /// </summary>
        /// <param name="enumerator"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> ToEnumerableAfter<T>(this IEnumerator<T> enumerator)
        {
            return CollConv.ToEnumerableAfter(enumerator);
        }

        #endregion
        
        #region ToIndexedSequence

        /// <summary>
        /// To index sequence
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<KeyValuePair<int, T>> ToIndexedSequence<T>(this IEnumerable<T> source)
        {
            return CollConv.ToIndexedSequence(source);
        }

        #endregion

        #region ToSortedArray

        /// <summary>
        /// To sorted array
        /// </summary>
        /// <param name="source"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToSortedArray<TSource>(this IEnumerable<TSource> source, Comparison<TSource> comparer)
        {
            return CollConv.ToSortedArray(source, comparer);
        }

        /// <summary>
        /// To sorted array
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToSortedArray<TSource>(this IEnumerable<TSource> source)
            where TSource : IComparable<TSource>
        {
            return CollConv.ToSortedArray(source);
        }

        #endregion
        
        #region ToHashSet

#if NETFRAMEWORK || NETSTANDARD2_0

#if !NET472 && !NET48
        
        /// <summary>
        /// To hashset
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source) where T : IComparable<T>
        {
            return source.ToHashSet(EqualityComparer<T>.Default);
        }
#endif

        /// <summary>
        /// To hashset
        /// </summary>
        /// <param name="source"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
            where T : IComparable<T>
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));
            return new HashSet<T>(source, comparer);
        }

#endif

        /// <summary>
        /// To HashSet
        /// </summary>
        /// <param name="source"></param>
        /// <param name="ignoreDup"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source, bool ignoreDup) where T : IComparable<T>
        {
            return ignoreDup
                ? source.Distinct().ToHashSet(EqualityComparer<T>.Default)
                : source.ToHashSet(EqualityComparer<T>.Default);
        }

        /// <summary>
        /// To HashSet
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keyFunc"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HashSet<TKey> ToHashSet<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keyFunc)
            where TKey : IComparable<TKey>
        {
            if (keyFunc is null) throw new ArgumentNullException(nameof(keyFunc));
            return source.Select(keyFunc).ToHashSet(EqualityComparer<TKey>.Default);
        }

        /// <summary>
        /// To HashSet ignore duplicates
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HashSet<T> ToHashSetIgnoringDuplicates<T>(this IEnumerable<T> source) where T : IComparable<T>
        {
            return source.ToHashSet(true);
        }

        #endregion
    }

    public static class CollConvShortcutExtensions
    {
        /// <summary>
        /// To string list
        /// </summary>
        /// <param name="source"></param>
        /// <param name="stringConverter"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<string> ToList<T>(this IEnumerable<T> source, Func<T, string> stringConverter)
        {
            return source.Select(stringConverter).ToList();
        }

        /// <summary>
        /// To list
        /// </summary>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<T> ToList<T>(this IEnumerable<T> source, Func<T, bool> func)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            return func is null ? source.ToList() : source.Where(func).ToList();
        }
    }
}