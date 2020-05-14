using System.Collections.Generic;
using TinyMapper.Core.DataStructures;

namespace TinyMapper.Core.Extensions {
    internal static class DictionaryExtensions {
        public static Option<TValue> GetValue<TKey, TValue>(this IDictionary<TKey, TValue> value, TKey key) {
            var exists = value.TryGetValue(key, out var result);
            return new Option<TValue>(result, exists);
        }
    }
}