using Cosmos.Conversions.Common.Core.FallbackMappings.Core.DataStructures;

namespace Cosmos.Conversions.Common.Core.FallbackMappings.Core.Extensions;

internal static class DictionaryExtensions
{
    public static Option<TValue> GetValue<TKey, TValue>(this IDictionary<TKey, TValue> value, TKey key)
    {
        var exists = value.TryGetValue(key, out var result);
        return new Option<TValue>(result, exists);
    }
}