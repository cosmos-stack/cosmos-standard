using System;
using System.Collections.Generic;

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
        public static TValue? GetOptionalValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) where TValue : struct
        {
            if (dictionary is null)
                throw new ArgumentNullException(nameof(dictionary));
            return dictionary.TryGetValue(key, out var value) ? value : (TValue?) null;
        }
    }
}