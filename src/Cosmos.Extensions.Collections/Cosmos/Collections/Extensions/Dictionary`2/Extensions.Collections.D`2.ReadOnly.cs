using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    /// <summary>
    /// Collection extensions
    /// </summary>
    public static partial class CollectionExtensions
    {
        /// <summary>
        /// Wrap in readonly dictionary
        /// </summary>
        /// <param name="dictionary"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> WrapInReadOnlyDictionary<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary is null)
                throw new ArgumentNullException(nameof(dictionary));

            return new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }
    }
}