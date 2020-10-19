using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Cosmos.Collections
{
    /// <summary>
    /// Enumerable factory
    /// </summary>
    public static class EnumerableFactory
    {
        /// <summary>
        /// Create list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> OfList<T>() => new List<T>();

        /// <summary>
        /// Create list
        /// </summary>
        /// <param name="listParams"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> OfList<T>(params IEnumerable<T>[] listParams)
        {
            var ret = OfList<T>();
            if (listParams != null)
            {
                foreach (var list in listParams)
                {
                    ret.AddRange(list);
                }
            }

            return ret;
        }

        /// <summary>
        /// ReadOnly Collection
        /// </summary>
        public static class ReadOnly
        {
            /// <summary>
            /// Create readonly list
            /// </summary>
            /// <param name="listParams"></param>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            // ReSharper disable once MemberHidesStaticFromOuterClass
            public static IReadOnlyList<T> OfList<T>(params IEnumerable<T>[] listParams) => EnumerableFactory.OfList(listParams);

            /// <summary>
            /// Gets empty readonly collection.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            public static ReadOnlyCollection<T> EmptyCollection<T>() => EmptyReadOnlyCollectionSingleton<T>.Instance;

            private static class EmptyReadOnlyCollectionSingleton<T>
            {
                internal static readonly ReadOnlyCollection<T> Instance = new ReadOnlyCollection<T>(new T[0]);
            }

            /// <summary>
            /// Gets empty readonly dictionary
            /// </summary>
            /// <typeparam name="TKey"></typeparam>
            /// <typeparam name="TValue"></typeparam>
            /// <returns></returns>
            public static ReadOnlyDictionary<TKey, TValue> EmptyDictionary<TKey, TValue>() => EmptyReadOnlyDictionarySingleton<TKey, TValue>.Instance;

            private static class EmptyReadOnlyDictionarySingleton<TKey, TValue>
            {
                internal static readonly ReadOnlyDictionary<TKey, TValue> Instance = new ReadOnlyDictionary<TKey, TValue>(new Dictionary<TKey, TValue>());
            }
        }
    }
}