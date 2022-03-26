using System.Collections.Concurrent;
using System.ComponentModel;

namespace Cosmos.Reflection;

internal static class TypeConvertersManager
{
    private static readonly ConcurrentDictionary<TypePairInfo, bool> TypeConvertersCache = new();

    public static bool HasTypeConverter(TypePairInfo typePair)
    {
        return TypeConvertersCache.GetOrAdd(typePair, tp => HasTypeConverterImpl(tp.Source, tp.Target));
    }

    private static bool HasTypeConverterImpl(Type s, Type t)
    {
        var fromConverter = TypeDescriptor.GetConverter(s);
        if (fromConverter.CanConvertTo(t))
        {
            return true;
        }

        var toConverter = TypeDescriptor.GetConverter(t);
        if (toConverter.CanConvertFrom(s))
        {
            return true;
        }

        return false;
    }
}