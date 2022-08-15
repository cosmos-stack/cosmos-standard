using System.Collections.ObjectModel;

namespace Cosmos.Collections;

internal static class ReadOnlyDictHelper
{
    /// <summary>
    /// Wrap in readonly dictionary
    /// </summary>
    /// <param name="dictionary"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static ReadOnlyDictionary<K, V> WrapInReadOnlyDictionary<K, V>(IDictionary<K, V> dictionary)
    {
        if (dictionary is null)
            throw new ArgumentNullException(nameof(dictionary));

        return new ReadOnlyDictionary<K, V>(dictionary);
    }
}

/// <summary>
/// ReadOnly Dictionary Utilities <br />
/// 只读字典工具
/// </summary>
public static class ReadOnlyDicts
{
    #region Empty

    /// <summary>
    /// Gets empty readonly dictionary <br />
    /// 获得一个空的只读字典
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlyDictionary<K, V> Empty<K, V>()
    {
        return EmptyReadOnlyDictionarySingleton<K, V>.OneInstance;
    }

    private static class EmptyReadOnlyDictionarySingleton<K, V>
    {
        internal static readonly ReadOnlyDictionary<K, V> OneInstance = new(new Dictionary<K, V>());
    }

    #endregion

    #region Get or Default

    /// <summary>
    /// Get value or default <br />
    /// 从字典中获取值或默认值
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="valueCalculator"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static V GetValueOrDefault<K, V>(IReadOnlyDictionary<K, V> dictionary, K key, Func<K, V> valueCalculator)
    {
        if (dictionary is not null && dictionary.TryGetValue(key, out var value))
            return value;

        if (valueCalculator is null)
            return default;

        return valueCalculator.Invoke(key);
    }

    /// <summary>
    /// Get value or default <br />
    /// 从字典中获取值或默认值
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static V GetValueOrDefault<K, V>(IReadOnlyDictionary<K, V> dictionary, K key, V defaultValue)
    {
        return dictionary is not null &&
               dictionary.TryGetValue(key, out var value)
            ? value
            : defaultValue;
    }

    /// <summary>
    /// Get value or default <br />
    /// 从字典中获取值或默认值
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static V GetValueOrDefault<K, V>(IReadOnlyDictionary<K, V> dictionary, K key)
    {
        return dictionary is not null &&
               dictionary.TryGetValue(key, out var value)
            ? value
            : default;
    }

    #endregion

    #region Get or Default Cascading

    /// <summary>
    /// Get value or default cascading <br />
    /// 级联地从字典中获取值或默认值
    /// </summary>
    /// <param name="dictionaryColl"></param>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static V GetValueOrDefaultCascading<K, V>(IEnumerable<IReadOnlyDictionary<K, V>> dictionaryColl, K key, V defaultValue)
    {
        if (dictionaryColl is null)
            throw new ArgumentNullException(nameof(dictionaryColl));
        return TryGetValueCascading(dictionaryColl, key, out var value) ? value : defaultValue;
    }

    /// <summary>
    /// Get value or default cascading <br />
    /// 级联地从字典中获取值或默认值
    /// </summary>
    /// <param name="dictionaryColl"></param>
    /// <param name="key"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static V GetValueOrDefaultCascading<K, V>(IEnumerable<IReadOnlyDictionary<K, V>> dictionaryColl, K key)
    {
        return GetValueOrDefaultCascading(dictionaryColl, key, default);
    }

    /// <summary>
    /// Try get value cascading <br />
    /// 级联地从字典中获取值
    /// </summary>
    /// <param name="dictionaryColl"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static bool TryGetValueCascading<K, V>(IEnumerable<IReadOnlyDictionary<K, V>> dictionaryColl, K key, out V value)
    {
        if (dictionaryColl is null)
            throw new ArgumentNullException(nameof(dictionaryColl));
        value = default;
        foreach (var dictionary in dictionaryColl)
            if (dictionary.TryGetValue(key, out value))
                return true;
        return false;
    }

    #endregion
}