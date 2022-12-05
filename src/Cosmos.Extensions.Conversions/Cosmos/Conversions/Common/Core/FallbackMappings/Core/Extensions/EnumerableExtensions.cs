using System.Collections;
using Cosmos.Conversions.Common.Core.FallbackMappings.Core.DataStructures;

namespace Cosmos.Conversions.Common.Core.FallbackMappings.Core.Extensions;

internal static class EnumerableExtensions
{
    public static List<TResult> ConvertAll<TFrom, TResult>(
        this IEnumerable<TFrom> value,
        Func<TFrom, TResult> converter)
    {
        return value.Select(converter).ToList();
    }

    public static int Count(this IEnumerable source)
    {
        if (source is ICollection collection)
        {
            return collection.Count;
        }

        var count = 0;
        // ReSharper disable once UnusedVariable
        foreach (var item in source)
        {
            count++;
        }

        return count;
    }

    public static bool IsNullOrEmpty<T>(this IEnumerable<T> value)
    {
        return value.IsNull() || !value.Any();
    }

    /// <summary>
    ///     Apply the given function to each element of the collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">Input collection</param>
    /// <param name="action">Given function</param>
    public static void Iter<T>(this IEnumerable<T> value, Action<T> action)
    {
        foreach (var item in value)
        {
            action(item);
        }
    }

    /// <summary>
    ///     Apply the given function to each element of the collection.
    ///     The integer passed to the function indicates the index of element.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">Input collection</param>
    /// <param name="action">Given function</param>
    public static void IterI<T>(this IEnumerable<T> value, Action<int, T> action)
    {
        var i = 0;
        foreach (var item in value)
        {
            action(i++, item);
        }
    }

    /// <summary>
    ///     Apply the given function to each element of the collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">Input collection</param>
    /// <param name="action">Given function</param>
    /// <param name="exceptionHandler">Exception handler action</param>
    public static void IterSafe<T>(
        this IEnumerable<T> value,
        Action<T> action,
        Action<Exception> exceptionHandler = null)
    {
        foreach (var item in value)
        {
            try
            {
                action(item);
            }
            catch (Exception ex)
            {
                exceptionHandler?.Invoke(ex);
            }
        }
    }

    public static IEnumerable<T> ToValue<T>(this IEnumerable<Option<T>> value)
    {
        return value.Where(x => x.HasValue)
                    .Select(x => x.Value);
    }
}