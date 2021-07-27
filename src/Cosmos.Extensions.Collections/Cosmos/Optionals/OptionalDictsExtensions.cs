using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cosmos.Collections;

namespace Cosmos.Optionals
{
    public static class OptionalDictsExtensions
    {
        /// <summary>
        /// Try get value
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue? GetOptionalValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) where TValue : struct
        {
            if (dictionary is null)
                throw new ArgumentNullException(nameof(dictionary));
            return dictionary.TryGetValue(key, out var value) ? value : (TValue?) null;
        }
        
        /// <summary>
        /// Try get value cascading
        /// </summary>
        /// <param name="dictionaryColl"></param>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue? GetOptionalValue<TKey, TValue>(this IEnumerable<IDictionary<TKey, TValue>> dictionaryColl, TKey key) where TValue : struct
        {
            return dictionaryColl.TryGetValueCascading(key, out var value) ? value : (TValue?) null;
        }
    }
}