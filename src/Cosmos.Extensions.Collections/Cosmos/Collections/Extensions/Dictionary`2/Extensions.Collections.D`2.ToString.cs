using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    /// <summary>
    /// Extensions for dictionary
    /// </summary>
    public static partial class DictionaryExtensions
    {
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
            foreach (var (key, value) in dictionary)
            {
                sb.Append($"{key}{linker}{value}{separator}");
            }

            return sb.ToString();
        }
    }
}