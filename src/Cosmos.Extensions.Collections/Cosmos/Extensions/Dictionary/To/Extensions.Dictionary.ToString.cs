using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class DictionaryExtensions
    {
        public static string ToString<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, string linker, string separator)
        {
            if (dictionary == null) return string.Empty;
            var sb = new StringBuilder();
            foreach (var item in dictionary)
            {
                sb.Append($"{item.Key}{linker}{item.Value}{separator}");
            }

            return sb.ToString();
        }
    }
}
