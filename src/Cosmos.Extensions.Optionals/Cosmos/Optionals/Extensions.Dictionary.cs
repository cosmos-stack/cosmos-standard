using System.Collections.Generic;

namespace Cosmos.Optionals {
    /// <summary>
    /// Extensions for Dictionary
    /// </summary>
    public static class DictionaryExtensions {
        /// <summary>
        /// TryGetValue wrapper with option types.
        /// It returns Some of the value when a value for the give key is present
        /// or None other-side
        /// </summary>
        /// <param name="source"></param>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static Maybe<TValue> TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key) {
            return source.TryGetValue(key, out var result)
                ? Optional.Some(result)
                : Optional.None<TValue>();
        }
    }
}