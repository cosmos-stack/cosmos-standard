using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Extensions for dictionary
    /// </summary>
    public static partial class DictionaryExtensions {
        /// <summary>
        /// Add dictionary into another dictionary
        /// </summary>
        /// <param name="me"></param>
        /// <param name="other"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TVal"></typeparam>
        public static void AddDictionary<TKey, TVal>(this Dictionary<TKey, TVal> me, Dictionary<TKey, TVal> other) {
            foreach (var src in other) {
                me.Add(src.Key, src.Value);
            }
        }
    }
}