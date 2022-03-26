using System.Collections.ObjectModel;

namespace Cosmos.Collections;

/// <summary>
/// ReadOnly Dictionary Convertor <br />
/// 只读字典转换器
/// </summary>
public static class ReadOnlyDictConv
{
    #region To Dictionary

    /// <summary>
    /// To readonly dictionary <br />
    /// 转换为只读字典
    /// </summary>
    /// <param name="src"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
        IEnumerable<KeyValuePair<TKey, TValue>> src)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));

        return new ReadOnlyDictionary<TKey, TValue>(src.ToDictionary(p => p.Key, p => p.Value, EqualityComparer<TKey>.Default));
    }

    /// <summary>
    /// To readonly dictionary <br />
    /// 转换为只读字典
    /// </summary>
    /// <param name="src"></param>
    /// <param name="comparer"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
        IEnumerable<KeyValuePair<TKey, TValue>> src, IEqualityComparer<TKey> comparer)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (comparer is null)
            throw new ArgumentNullException(nameof(comparer));

        return new ReadOnlyDictionary<TKey, TValue>(src.ToDictionary(p => p.Key, p => p.Value, comparer));
    }

    /// <summary>
    /// To readonly dictionary <br />
    /// 转换为只读字典
    /// </summary>
    /// <param name="source"></param>
    /// <param name="keySelector"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
        IEnumerable<TValue> source, Func<TValue, TKey> keySelector)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (keySelector is null)
            throw new ArgumentNullException(nameof(keySelector));

        return ReadOnlyDictsHelper.WrapInReadOnlyDictionary(source.ToDictionary(keySelector));
    }

    /// <summary>
    /// To readonly dictionary <br />
    /// 转换为只读字典
    /// </summary>
    /// <param name="source"></param>
    /// <param name="keySelector"></param>
    /// <param name="comparer"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
        IEnumerable<TValue> source, Func<TValue, TKey> keySelector, IEqualityComparer<TKey> comparer)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (keySelector is null)
            throw new ArgumentNullException(nameof(keySelector));
        if (comparer is null)
            throw new ArgumentNullException(nameof(comparer));

        return ReadOnlyDictsHelper.WrapInReadOnlyDictionary(source.ToDictionary(keySelector, comparer));
    }

    /// <summary>
    /// To readonly dictionary <br />
    /// 转换为只读字典
    /// </summary>
    /// <param name="source"></param>
    /// <param name="keySelector"></param>
    /// <param name="elementSelector"></param>
    /// <param name="comparer"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TSource, TKey, TValue>(
        IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector, IEqualityComparer<TKey> comparer)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (keySelector is null)
            throw new ArgumentNullException(nameof(keySelector));
        if (elementSelector is null)
            throw new ArgumentNullException(nameof(elementSelector));
        if (comparer is null)
            throw new ArgumentNullException(nameof(comparer));

        return ReadOnlyDictsHelper.WrapInReadOnlyDictionary(source.ToDictionary(keySelector, elementSelector, comparer));
    }

    /// <summary>
    /// To readonly dictionary <br />
    /// 转换为只读字典
    /// </summary>
    /// <param name="source"></param>
    /// <param name="keySelector"></param>
    /// <param name="elementSelector"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TSource, TKey, TValue>(
        IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (keySelector is null)
            throw new ArgumentNullException(nameof(keySelector));
        if (elementSelector is null)
            throw new ArgumentNullException(nameof(elementSelector));

        return ReadOnlyDictsHelper.WrapInReadOnlyDictionary(source.ToDictionary(keySelector, elementSelector));
    }

    #endregion
}

/// <summary>
/// ReadOnly Dictionary Convertor Extensions  <br />
/// 只读字典转换器扩展
/// </summary>
public static class ReadOnlyDictConvExtensions
{
    #region To Dictionary

    /// <summary>
    /// To readonly dictionary <br />
    /// 转换为只读字典
    /// </summary>
    /// <param name="src"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyDictionary<TKey, TValue> AsReadOnlyDictionary<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> src)
    {
        return ReadOnlyDictConv.ToDictionary(src);
    }

    /// <summary>
    /// To readonly dictionary <br />
    /// 转换为只读字典
    /// </summary>
    /// <param name="src"></param>
    /// <param name="comparer"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyDictionary<TKey, TValue> AsReadOnlyDictionary<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> src, IEqualityComparer<TKey> comparer)
    {
        return ReadOnlyDictConv.ToDictionary(src, comparer);
    }

    /// <summary>
    /// To readonly dictionary <br />
    /// 转换为只读字典
    /// </summary>
    /// <param name="src"></param>
    /// <param name="keySelector"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyDictionary<TKey, TValue> AsReadOnlyDictionary<TKey, TValue>(
        this IEnumerable<TValue> src, Func<TValue, TKey> keySelector)
    {
        return ReadOnlyDictConv.ToDictionary(src, keySelector);
    }

    /// <summary>
    /// To readonly dictionary <br />
    /// 转换为只读字典
    /// </summary>
    /// <param name="src"></param>
    /// <param name="keySelector"></param>
    /// <param name="comparer"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyDictionary<TKey, TValue> AsReadOnlyDictionary<TKey, TValue>(
        this IEnumerable<TValue> src, Func<TValue, TKey> keySelector, IEqualityComparer<TKey> comparer)
    {
        return ReadOnlyDictConv.ToDictionary(src, keySelector, comparer);
    }

    /// <summary>
    /// To readonly dictionary <br />
    /// 转换为只读字典
    /// </summary>
    /// <param name="src"></param>
    /// <param name="keySelector"></param>
    /// <param name="elementSelector"></param>
    /// <param name="comparer"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyDictionary<TKey, TValue> AsReadOnlyDictionary<TSource, TKey, TValue>(
        this IEnumerable<TSource> src, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector, IEqualityComparer<TKey> comparer)
    {
        return ReadOnlyDictConv.ToDictionary(src, keySelector, elementSelector, comparer);
    }

    /// <summary>
    /// To readonly dictionary <br />
    /// 转换为只读字典
    /// </summary>
    /// <param name="src"></param>
    /// <param name="keySelector"></param>
    /// <param name="elementSelector"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyDictionary<TKey, TValue> AsReadOnlyDictionary<TSource, TKey, TValue>(
        this IEnumerable<TSource> src, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector)
    {
        return ReadOnlyDictConv.ToDictionary(src, keySelector, elementSelector);
    }

    #endregion
}