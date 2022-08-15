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
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IReadOnlyDictionary<K, V> ToDictionary<K, V>(
        IEnumerable<KeyValuePair<K, V>> src)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));

        return new ReadOnlyDictionary<K, V>(src.ToDictionary(p => p.Key, p => p.Value, EqualityComparer<K>.Default));
    }

    /// <summary>
    /// To readonly dictionary <br />
    /// 转换为只读字典
    /// </summary>
    /// <param name="src"></param>
    /// <param name="comparer"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IReadOnlyDictionary<K, V> ToDictionary<K, V>(
        IEnumerable<KeyValuePair<K, V>> src, IEqualityComparer<K> comparer)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (comparer is null)
            throw new ArgumentNullException(nameof(comparer));

        return new ReadOnlyDictionary<K, V>(src.ToDictionary(p => p.Key, p => p.Value, comparer));
    }

    /// <summary>
    /// To readonly dictionary <br />
    /// 转换为只读字典
    /// </summary>
    /// <param name="source"></param>
    /// <param name="keySelector"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IReadOnlyDictionary<K, V> ToDictionary<K, V>(
        IEnumerable<V> source, Func<V, K> keySelector)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (keySelector is null)
            throw new ArgumentNullException(nameof(keySelector));

        return ReadOnlyDictHelper.WrapInReadOnlyDictionary(source.ToDictionary(keySelector));
    }

    /// <summary>
    /// To readonly dictionary <br />
    /// 转换为只读字典
    /// </summary>
    /// <param name="source"></param>
    /// <param name="keySelector"></param>
    /// <param name="comparer"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IReadOnlyDictionary<K, V> ToDictionary<K, V>(
        IEnumerable<V> source, Func<V, K> keySelector, IEqualityComparer<K> comparer)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (keySelector is null)
            throw new ArgumentNullException(nameof(keySelector));
        if (comparer is null)
            throw new ArgumentNullException(nameof(comparer));

        return ReadOnlyDictHelper.WrapInReadOnlyDictionary(source.ToDictionary(keySelector, comparer));
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
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IReadOnlyDictionary<K, V> ToDictionary<TSource, K, V>(
        IEnumerable<TSource> source, Func<TSource, K> keySelector, Func<TSource, V> elementSelector, IEqualityComparer<K> comparer)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (keySelector is null)
            throw new ArgumentNullException(nameof(keySelector));
        if (elementSelector is null)
            throw new ArgumentNullException(nameof(elementSelector));
        if (comparer is null)
            throw new ArgumentNullException(nameof(comparer));

        return ReadOnlyDictHelper.WrapInReadOnlyDictionary(source.ToDictionary(keySelector, elementSelector, comparer));
    }

    /// <summary>
    /// To readonly dictionary <br />
    /// 转换为只读字典
    /// </summary>
    /// <param name="source"></param>
    /// <param name="keySelector"></param>
    /// <param name="elementSelector"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IReadOnlyDictionary<K, V> ToDictionary<TSource, K, V>(
        IEnumerable<TSource> source, Func<TSource, K> keySelector, Func<TSource, V> elementSelector)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (keySelector is null)
            throw new ArgumentNullException(nameof(keySelector));
        if (elementSelector is null)
            throw new ArgumentNullException(nameof(elementSelector));

        return ReadOnlyDictHelper.WrapInReadOnlyDictionary(source.ToDictionary(keySelector, elementSelector));
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
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyDictionary<K, V> AsReadOnlyDictionary<K, V>(
        this IEnumerable<KeyValuePair<K, V>> src)
    {
        return ReadOnlyDictConv.ToDictionary(src);
    }

    /// <summary>
    /// To readonly dictionary <br />
    /// 转换为只读字典
    /// </summary>
    /// <param name="src"></param>
    /// <param name="comparer"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyDictionary<K, V> AsReadOnlyDictionary<K, V>(
        this IEnumerable<KeyValuePair<K, V>> src, IEqualityComparer<K> comparer)
    {
        return ReadOnlyDictConv.ToDictionary(src, comparer);
    }

    /// <summary>
    /// To readonly dictionary <br />
    /// 转换为只读字典
    /// </summary>
    /// <param name="src"></param>
    /// <param name="keySelector"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyDictionary<K, V> AsReadOnlyDictionary<K, V>(
        this IEnumerable<V> src, Func<V, K> keySelector)
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
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyDictionary<K, V> AsReadOnlyDictionary<K, V>(
        this IEnumerable<V> src, Func<V, K> keySelector, IEqualityComparer<K> comparer)
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
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyDictionary<K, V> AsReadOnlyDictionary<TSource, K, V>(
        this IEnumerable<TSource> src, Func<TSource, K> keySelector, Func<TSource, V> elementSelector, IEqualityComparer<K> comparer)
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
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyDictionary<K, V> AsReadOnlyDictionary<TSource, K, V>(
        this IEnumerable<TSource> src, Func<TSource, K> keySelector, Func<TSource, V> elementSelector)
    {
        return ReadOnlyDictConv.ToDictionary(src, keySelector, elementSelector);
    }

    #endregion
}