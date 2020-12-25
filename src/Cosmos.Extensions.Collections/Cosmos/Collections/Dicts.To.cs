using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Cosmos.Collections
{
    public static partial class Dicts
    {
        #region To Dictionary

        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="hash"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(Hashtable hash)
        {
            var dictionary = new Dictionary<TKey, TValue>(hash.Count);
            foreach (var item in hash.Keys)
                dictionary.Add((TKey) item, (TValue) hash[item]);
            return dictionary;
        }
        
        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> source)
        {
            return ToDictionary(source, EqualityComparer<TKey>.Default);
        }

        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <param name="equalityComparer"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey> equalityComparer)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (equalityComparer is null)
                throw new ArgumentNullException(nameof(equalityComparer));
            return source.ToDictionary(p => p.Key, p => p.Value, equalityComparer);
        }

        #endregion

        #region To Tuple

        /// <summary>
        /// To tuple...
        /// </summary>
        /// <param name="dictionary"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Tuple<TKey, TValue>> ToTuple<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
#if NETFRAMEWORK || NETSTANDARD2_0
            return dictionary.Select(pair => Tuple.Create(pair.Key, pair.Value));
#else
            foreach (var (key, value) in dictionary)
            {
                yield return Tuple.Create(key, value);
            }
#endif
        }

        #endregion
        
        #region To Sorted Array
        
        /// <summary>
        /// To sorted array by value
        /// </summary>
        /// <param name="dictionary"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static List<KeyValuePair<TKey, int>> ToSortedArrayByValue<TKey>(Dictionary<TKey, int> dictionary)
        {
            var val = dictionary.ToList();

            val.Sort((x, y) => -x.Value.CompareTo(y.Value));

            return val;
        }

        /// <summary>
        /// To sorted array by key
        /// </summary>
        /// <param name="dictionary"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static List<KeyValuePair<TKey, TValue>> ToSortedArrayByKey<TKey, TValue>(Dictionary<TKey, TValue> dictionary) where TKey : IComparable<TKey>
        {
            var val = dictionary.ToList();

            val.Sort((x, y) => x.Key.CompareTo(y.Key));

            return val;
        }

        #endregion
        
        /// <summary>
        /// ReadOnly Collection
        /// </summary>
        public static partial class ReadOnly
        {
            /// <summary>
            /// To readonly dictionary
            /// </summary>
            /// <param name="src"></param>
            /// <typeparam name="TKey"></typeparam>
            /// <typeparam name="TValue"></typeparam>
            /// <returns></returns>
            /// <exception cref="ArgumentNullException"></exception>
            public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
                IEnumerable<KeyValuePair<TKey, TValue>> src)
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
            public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
                IEnumerable<KeyValuePair<TKey, TValue>> src, IEqualityComparer<TKey> comparer)
            {
                if (src is null)
                    throw new ArgumentNullException(nameof(src));
                if (comparer is null)
                    throw new ArgumentNullException(nameof(comparer));

                return new ReadOnlyDictionary<TKey, TValue>(src.ToDictionary(p => p.Key, p => p.Value, comparer));
            }
            
            /// <summary>
            /// To readonly dictionary
            /// </summary>
            /// <param name="source"></param>
            /// <param name="keySelector"></param>
            /// <typeparam name="TKey"></typeparam>
            /// <typeparam name="TValue"></typeparam>
            /// <returns></returns>
            /// <exception cref="ArgumentNullException"></exception>
            public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
                IEnumerable<TValue> source, Func<TValue, TKey> keySelector)
            {
                if (source is null)
                    throw new ArgumentNullException(nameof(source));
                if (keySelector is null)
                    throw new ArgumentNullException(nameof(keySelector));

                return ReadOnlyDictsHelper.WrapInReadOnlyDictionary(source.ToDictionary(keySelector));
            }

            /// <summary>
            /// To readonly dictionary
            /// </summary>
            /// <param name="source"></param>
            /// <param name="keySelector"></param>
            /// <param name="comparer"></param>
            /// <typeparam name="TKey"></typeparam>
            /// <typeparam name="TValue"></typeparam>
            /// <returns></returns>
            /// <exception cref="ArgumentNullException"></exception>
            public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
                IEnumerable<TValue> source, Func<TValue, TKey> keySelector, IEqualityComparer<TKey> comparer)
            {
                if (source is null)
                    throw new ArgumentNullException(nameof(source));
                if (keySelector is null)
                    throw new ArgumentNullException(nameof(keySelector));
                if (comparer is null)
                    throw new ArgumentNullException(nameof(comparer));

                return ReadOnlyDictsHelper.WrapInReadOnlyDictionary(source.ToDictionary(keySelector, comparer));
            }

            /// <summary>
            /// To readonly dictionary
            /// </summary>
            /// <param name="source"></param>
            /// <param name="keySelector"></param>
            /// <param name="elementSelector"></param>
            /// <param name="comparer"></param>
            /// <typeparam name="TSource"></typeparam>
            /// <typeparam name="TKey"></typeparam>
            /// <typeparam name="TValue"></typeparam>
            /// <returns></returns>
            /// <exception cref="ArgumentNullException"></exception>
            public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TSource, TKey, TValue>(
                IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector, IEqualityComparer<TKey> comparer)
            {
                if (source is null)
                    throw new ArgumentNullException(nameof(source));
                if (keySelector is null)
                    throw new ArgumentNullException(nameof(keySelector));
                if (elementSelector is null)
                    throw new ArgumentNullException(nameof(elementSelector));
                if (comparer is null)
                    throw new ArgumentNullException(nameof(comparer));

                return ReadOnlyDictsHelper.WrapInReadOnlyDictionary(source.ToDictionary(keySelector, elementSelector, comparer));
            }

            /// <summary>
            /// To readonly dictionary
            /// </summary>
            /// <param name="source"></param>
            /// <param name="keySelector"></param>
            /// <param name="elementSelector"></param>
            /// <typeparam name="TSource"></typeparam>
            /// <typeparam name="TKey"></typeparam>
            /// <typeparam name="TValue"></typeparam>
            /// <returns></returns>
            /// <exception cref="ArgumentNullException"></exception>
            public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TSource, TKey, TValue>(
                IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector)
            {
                if (source is null)
                    throw new ArgumentNullException(nameof(source));
                if (keySelector is null)
                    throw new ArgumentNullException(nameof(keySelector));
                if (elementSelector is null)
                    throw new ArgumentNullException(nameof(elementSelector));

                return ReadOnlyDictsHelper.WrapInReadOnlyDictionary(source.ToDictionary(keySelector, elementSelector));
            }
        }
    }

    public static partial class DictsExtensions
    {
        #region To Dictionary
        
        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="hash"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this Hashtable hash)
        {
            return Dicts.ToDictionary<TKey, TValue>(hash);
        }

        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source)
        {
            return Dicts.ToDictionary(source);
        }

        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <param name="equalityComparer"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey> equalityComparer)
        {
            return Dicts.ToDictionary(source, equalityComparer);
        }

        #endregion

        #region To ReadOnly Dictionary

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
            return Dicts.ReadOnly.ToDictionary(src);
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
            return Dicts.ReadOnly.ToDictionary(src, comparer);
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
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<TValue> src, Func<TValue, TKey> keySelector)
        {
            return Dicts.ReadOnly.ToDictionary(src, keySelector);
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
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<TValue> src, Func<TValue, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return Dicts.ReadOnly.ToDictionary(src, keySelector, comparer);
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
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TSource, TKey, TValue>(
            this IEnumerable<TSource> src, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector, IEqualityComparer<TKey> comparer)
        {
            return Dicts.ReadOnly.ToDictionary(src, keySelector, elementSelector, comparer);
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
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TSource, TKey, TValue>(
            this IEnumerable<TSource> src, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector)
        {
            return Dicts.ReadOnly.ToDictionary(src, keySelector, elementSelector);
        }
        
        #endregion
        
        #region To Tuple

        /// <summary>
        /// To tuple...
        /// </summary>
        /// <param name="dictionary"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Tuple<TKey, TValue>> ToTuple<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return Dicts.ToTuple(dictionary);
        }

        #endregion
        
        #region To Sorted Array
        
        /// <summary>
        /// To sorted array by value
        /// </summary>
        /// <param name="dictionary"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static List<KeyValuePair<TKey, int>> ToSortedArrayByValue<TKey>(this Dictionary<TKey, int> dictionary)
        {
            return Dicts.ToSortedArrayByValue(dictionary);
        }

        /// <summary>
        /// To sorted array by key
        /// </summary>
        /// <param name="dictionary"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static List<KeyValuePair<TKey, TValue>> ToSortedArrayByKey<TKey, TValue>(this Dictionary<TKey, TValue> dictionary) where TKey : IComparable<TKey>
        {
            return Dicts.ToSortedArrayByKey(dictionary);
        }

        #endregion
    }
}