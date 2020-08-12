using System.Collections.Generic;

namespace System.Collections
{
    /// <summary>
    /// Cosmos Hashtable extensions
    /// </summary>
    public static class CosmosHashtableExtensions
    {
        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="hash"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this Hashtable hash)
        {
            var res = new Dictionary<TKey, TValue>(hash.Count);
            foreach (var item in hash.Keys)
            {
                res.Add((TKey) item, (TValue) hash[item]);
            }

            return res;
        }
    }
}