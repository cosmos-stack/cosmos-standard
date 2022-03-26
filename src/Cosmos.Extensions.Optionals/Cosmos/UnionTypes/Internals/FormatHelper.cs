namespace Cosmos.UnionTypes.Internals;

internal static class FormatHelper
{
    internal static string FormatValue<T>(T value)
    {
        return $"{typeof(T).FullName}: {value?.ToString()}";
    }

    internal static string FormatValue<T>(object @this, object @base, T value)
    {
        return ReferenceEquals(@this, value)
            ? @base.ToString()
            : $"{typeof(T).FullName}: {value?.ToString()}";
    }
}