using System;
using System.Collections.Generic;
using Cosmos.Collections.Internals;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    /// <summary>
    /// ReadOnly dictionary extensions
    /// </summary>
    public static partial class ReadOnlyDictionaryExtensions
    {
        /// <summary>
        /// Cast
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="TFromKey"></typeparam>
        /// <typeparam name="TFromValue"></typeparam>
        /// <typeparam name="TToKey"></typeparam>
        /// <typeparam name="TToValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IReadOnlyDictionary<TToKey, TToValue> Cast<TFromKey, TFromValue, TToKey, TToValue>(
            this IReadOnlyDictionary<TFromKey, TFromValue> source)
        where TFromKey : TToKey
        where TFromValue : TToValue
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return new CastingReadOnlyDictionaryWrapper<TFromKey, TFromValue, TToKey, TToValue>(source);
        }
    }
}