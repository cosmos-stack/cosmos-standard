namespace System.Collections.Generic
{
    /// <summary>
    /// Cosmos Dictionary extensions
    /// </summary>
    public static class SystemDictionaryExtensions
    {
        #region Add

        /// <summary>
        /// Add dictionary into another dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dict"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TVal"></typeparam>
        public static void Add<TKey, TVal>(this Dictionary<TKey, TVal> source, Dictionary<TKey, TVal> dict)
        {
            foreach (var pair in dict)
            {
                source.Add(pair);
            }
        }

        /// <summary>
        /// Add key-value pair into another dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pair"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TVal"></typeparam>
        public static void Add<TKey, TVal>(this Dictionary<TKey, TVal> source, KeyValuePair<TKey, TVal> pair)
        {
            source.Add(pair.Key, pair.Value);
        }

        #endregion
    }
}