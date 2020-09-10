using System.Text;

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
        /// <param name="me"></param>
        /// <param name="other"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TVal"></typeparam>
        public static void Add<TKey, TVal>(this Dictionary<TKey, TVal> me, Dictionary<TKey, TVal> other)
        {
#if NETSTANDARD2_0
            foreach (var pair in other)
            {
                me.Add(pair.Key, pair.Value);
            }
#else
            foreach (var (key, value) in other)
            {
                me.Add(key, value);
            }
#endif
        }

        #endregion

        #region ToString

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="linker"></param>
        /// <param name="separator"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static string ToString<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, string linker, string separator)
        {
            if (dictionary is null) return string.Empty;
            var sb = new StringBuilder();
#if NETSTANDARD2_0
            foreach (var pair in dictionary)
            {
                sb.Append($"{pair.Key}{linker}{pair.Value}{separator}");
            }
#else
            foreach (var (key, value) in dictionary)
            {
                sb.Append($"{key}{linker}{value}{separator}");
            }
#endif

            return sb.ToString();
        }

        #endregion
    }
}