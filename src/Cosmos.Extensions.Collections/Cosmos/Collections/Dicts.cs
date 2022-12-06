namespace Cosmos.Collections;

/// <summary>
/// Dictionary Utilities <br />
/// 字典工具
/// </summary>
public static class Dicts
{
    #region Empty

    /// <summary>
    /// Create an empty dictionary instance of the specified type K and V. <br />
    /// 创建一个指定键值对 K-V 的空字典实例。
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Dictionary<K, V> Empty<K, V>() => Empty<Dictionary<K, V>, K, V>();

    /// <summary>
    /// Create an empty dictionary instance of the specified type K and V. <br />
    /// 创建一个指定键值对 K-V 的空字典实例。
    /// </summary>
    /// <typeparam name="D"></typeparam>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static D Empty<D, K, V>() where D : IDictionary<K, V>, new() => InternalDictionary.ForEmpty<D, K, V>();

    #endregion

    #region Add

    /// <summary>
    /// Add or override <br />
    /// 添加或覆盖
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void AddValueOrOverride<K, V>(Dictionary<K, V> dictionary, K key, V value)
    {
        dictionary[key] = value;
    }

    /// <summary>
    /// Add or update <br />
    /// 添加或更新
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="insertFunc"></param>
    /// <param name="updateFunc"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public static void AddValueOrUpdate<K, V>(Dictionary<K, V> dictionary, K key, Func<K, V> insertFunc, Func<K, V, V> updateFunc)
    {
        ArgumentNullException.ThrowIfNull(insertFunc);
        ArgumentNullException.ThrowIfNull(updateFunc);

        var newVal = dictionary.ContainsKey(key)
            ? updateFunc(key, dictionary[key])
            : insertFunc(key);

        AddValueOrOverride(dictionary, key, newVal);
    }

    /// <summary>
    /// Add or update <br />
    /// 添加或更新
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="insertFunc"></param>
    /// <param name="doAct"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    public static void AddValueOrDo<K, V>(Dictionary<K, V> dictionary, K key, Func<K, V> insertFunc, Action<K, V> doAct)
    {
        ArgumentNullException.ThrowIfNull(insertFunc);
        ArgumentNullException.ThrowIfNull(doAct);

        if (dictionary.ContainsKey(key))
        {
            doAct(key, dictionary[key]);
        }
        else
        {
            AddValueOrOverride(dictionary, key, insertFunc(key));
        }
    }

    /// <summary>
    /// Add if not exist <br />
    /// 如果不存在则添加
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    public static void AddValueIfNotExist<K, V>(Dictionary<K, V> dictionary, K key, V value)
    {
        if (dictionary.ContainsKey(key)) return;
        dictionary[key] = value;
    }

    /// <summary>
    /// Merge the second dictionary into the first one <br />
    /// 合并字典到第一个
    /// </summary>
    /// <param name="source"></param>
    /// <param name="dict"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public static void Add<K, V>(Dictionary<K, V> source, Dictionary<K, V> dict)
    {
        foreach (var pair in dict)
            source.Add(pair.Key, pair.Value);
    }

    #endregion

    #region Get or Default

    /// <summary>
    /// Get value or default <br />
    /// 获取值或默认值
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="valueCalculator"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static V GetValueOrDefault<K, V>(IDictionary<K, V> dictionary, K key, Func<K, V> valueCalculator)
    {
        if (dictionary is not null && dictionary.TryGetValue(key, out var value))
            return value;

        if (valueCalculator is null)
            return default;

        return valueCalculator.Invoke(key);
    }

    /// <summary>
    /// Get value or default <br />
    /// 获取值或默认值
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static V GetValueOrDefault<K, V>(IDictionary<K, V> dictionary, K key, V defaultValue)
    {
        return dictionary is not null &&
               dictionary.TryGetValue(key, out var value)
            ? value
            : defaultValue;
    }

    /// <summary>
    /// Get value or default <br />
    /// 获取值或默认值
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static V GetValueOrDefault<K, V>(IDictionary<K, V> dictionary, K key)
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
    /// 级联地尝试获取一个值或默认值，该值为值类型的
    /// </summary>
    /// <param name="dictionaryColl"></param>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static V GetValueOrDefaultCascading<K, V>(IEnumerable<IDictionary<K, V>> dictionaryColl, K key, V defaultValue)
    {
        ArgumentNullException.ThrowIfNull(dictionaryColl);
        return TryGetValueCascading(dictionaryColl, key, out var value) ? value : defaultValue;
    }

    /// <summary>
    /// Get value or default cascading <br />
    /// 级联地尝试获取一个值或默认值，该值为值类型的
    /// </summary>
    /// <param name="dictionaryColl"></param>
    /// <param name="key"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    public static V GetValueOrDefaultCascading<K, V>(IEnumerable<IDictionary<K, V>> dictionaryColl, K key)
    {
        return GetValueOrDefaultCascading(dictionaryColl, key, default);
    }

    /// <summary>
    /// Try get value cascading <br />
    /// 级联地尝试获取一个可选地值，该值为值类型的
    /// </summary>
    /// <param name="dictionaryColl"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static bool TryGetValueCascading<K, V>(IEnumerable<IDictionary<K, V>> dictionaryColl, K key, out V value)
    {
        ArgumentNullException.ThrowIfNull(dictionaryColl);
        value = default;
        foreach (var dictionary in dictionaryColl)
            if (dictionary.TryGetValue(key, out value))
                return true;
        return false;
    }

    #endregion

    #region Get or Add

    /// <summary>
    /// Get or add <br />
    /// 获取或添加
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static V GetValueOrAdd<K, V>(Dictionary<K, V> dictionary, K key, V value)
    {
        if (dictionary.TryGetValue(key, out var res))
            return res;

        return dictionary[key] = value;
    }

    /// <summary>
    /// Get or add <br />
    /// 获取或添加
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="newValueCreator"></param>
    /// <returns></returns>
    public static V GetValueOrAdd<K, V>(Dictionary<K, V> dictionary, K key, Func<K, V> newValueCreator)
    {
        ArgumentNullException.ThrowIfNull(newValueCreator);

        if (dictionary.TryGetValue(key, out var res))
            return res;

        return dictionary[key] = newValueCreator(key);
    }

    /// <summary>
    /// Get or add new default instance <br />
    /// 获取或添加一个默认新实例
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static V GetValueOrAddNewInstance<K, V>(Dictionary<K, V> dictionary, K key) where V : new()
    {
        return GetValueOrAdd(dictionary, key, _ => new V());
    }

    #endregion

    #region GroupBy

    /// <summary>
    /// Group by as dictionary <br />
    /// 分组为字典
    /// </summary>
    /// <param name="list"></param>
    /// <param name="keyFunc"></param>
    /// <typeparam name="TItem"></typeparam>
    /// <typeparam name="K"></typeparam>
    /// <returns></returns>
    public static Dictionary<K, List<TItem>> GroupByAsDictionary<TItem, K>(
        IEnumerable<TItem> list, Func<TItem, K> keyFunc)
    {
        return GroupByAsDictionary(list, keyFunc, x => x);
    }

    /// <summary>
    /// Group by as dictionary <br />
    /// 分组为字典
    /// </summary>
    /// <param name="list"></param>
    /// <param name="keyFunc"></param>
    /// <param name="valueFunc"></param>
    /// <typeparam name="TItem"></typeparam>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    public static Dictionary<K, List<V>> GroupByAsDictionary<TItem, K, V>(
        IEnumerable<TItem> list, Func<TItem, K> keyFunc, Func<TItem, V> valueFunc)
    {
        var res = new Dictionary<K, List<V>>();

        foreach (var item in list)
        {
            var key = keyFunc(item);
            var value = valueFunc(item);

            if (!res.TryGetValue(key, out var valuesList))
            {
                valuesList = new List<V>();
                res.Add(key, valuesList);
            }

            valuesList.Add(value);
        }

        return res;
    }

    #endregion

    #region Set Value

    /// <summary>
    /// Set value <br />
    /// 设置值
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public static void SetValue<K, V>(Dictionary<K, V> dictionary, K key, V value)
    {
        if (dictionary.ContainsKey(key))
            dictionary[key] = value;
        else
            dictionary.Add(key, value);
    }

    #endregion
}

/// <summary>
/// Dictionary Utilities <br />
/// 字典工具
/// </summary>
/// <typeparam name="K"></typeparam>
/// <typeparam name="V"></typeparam>
public static class Dicts<K, V>
{
    #region Empty

    /// <summary>
    /// Create an empty dictionary instance of the specified type K and V. <br />
    /// 创建一个指定键值对 K-V 的空字典实例。
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Dictionary<K, V> Empty() => Empty<Dictionary<K, V>>();

    /// <summary>
    /// Create an empty dictionary instance of the specified type K and V. <br />
    /// 创建一个指定键值对 K-V 的空字典实例。
    /// </summary>
    /// <typeparam name="D"></typeparam>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static D Empty<D>() where D : IDictionary<K, V>, new() => InternalDictionary.ForEmpty<D, K, V>();

    #endregion
}

/// <summary>
/// Dictionary Utilities Extensions<br />
/// 字典工具扩展
/// </summary>
public static class DictsExtensions
{
    #region Add

    /// <summary>
    /// Add one dictionary into another one. <br />
    /// 将一个字典添加到另一个
    /// </summary>
    /// <param name="source"></param>
    /// <param name="dict"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add<K, V>(this Dictionary<K, V> source, Dictionary<K, V> dict)
    {
        Dicts.Add(source, dict);
    }

    /// <summary>
    /// Add one key-value-pair into the given dictionary. <br />
    /// 添加一组键值对到给定字典
    /// </summary>
    /// <param name="source"></param>
    /// <param name="pair"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Add<K, V>(this Dictionary<K, V> source, KeyValuePair<K, V> pair)
    {
        source.Add(pair.Key, pair.Value);
    }

    /// <summary>
    /// Add or override <br />
    /// 添加或覆盖
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddValueOrOverride<K, V>(this Dictionary<K, V> dictionary, K key, V value)
    {
        Dicts.AddValueOrOverride(dictionary, key, value);
    }

    /// <summary>
    /// Add or update <br />
    /// 添加或更新
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="insertFunc"></param>
    /// <param name="updateFunc"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddValueOrUpdate<K, V>(this Dictionary<K, V> dictionary, K key, Func<K, V> insertFunc, Func<K, V, V> updateFunc)
    {
        Dicts.AddValueOrUpdate(dictionary, key, insertFunc, updateFunc);
    }

    /// <summary>
    /// Add or update <br />
    /// 添加或更新
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="insertFunc"></param>
    /// <param name="doAct"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddValueOrDo<K, V>(this Dictionary<K, V> dictionary, K key, Func<K, V> insertFunc, Action<K, V> doAct)
    {
        Dicts.AddValueOrDo(dictionary, key, insertFunc, doAct);
    }

    /// <summary>
    /// Add if not exist <br />
    /// 如果不存在则添加
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddValueIfNotExist<K, V>(this Dictionary<K, V> dictionary, K key, V value)
    {
        Dicts.AddValueIfNotExist(dictionary, key, value);
    }

    #endregion

    #region Get or Default

    /// <summary>
    /// Get value or default <br />
    /// 获取值或默认值
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="valueCalculator"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static V GetValueOrDefault<K, V>(this IDictionary<K, V> dictionary, K key, Func<K, V> valueCalculator)
    {
        return Dicts.GetValueOrDefault(dictionary, key, valueCalculator);
    }

#if NETFRAMEWORK || NETSTANDARD2_0
    /// <summary>
    /// Get value or default <br />
    /// 获取值或默认值
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static V GetValueOrDefault<K, V>(this IDictionary<K, V> dictionary, K key, V defaultValue)
    {
        return Dicts.GetValueOrDefault(dictionary, key, defaultValue);
    }

    /// <summary>
    /// Get value or default <br />
    /// 获取值或默认值
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static V GetValueOrDefault<K, V>(this IDictionary<K, V> dictionary, K key)
    {
        return Dicts.GetValueOrDefault(dictionary, key);
    }
#endif

    #endregion

    #region Get or Default Cascading

    /// <summary>
    /// Get value or default cascading <br />
    /// 级联地尝试获取一个值或默认值，该值为值类型的
    /// </summary>
    /// <param name="dictionaryColl"></param>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static V GetValueOrDefaultCascading<K, V>(this IEnumerable<IDictionary<K, V>> dictionaryColl, K key, V defaultValue)
    {
        return Dicts.GetValueOrDefaultCascading(dictionaryColl, key, defaultValue);
    }

    /// <summary>
    /// Get value or default cascading <br />
    /// 级联地尝试获取一个值或默认值，该值为值类型的
    /// </summary>
    /// <param name="dictionaryColl"></param>
    /// <param name="key"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static V GetValueOrDefaultCascading<K, V>(this IEnumerable<IDictionary<K, V>> dictionaryColl, K key)
    {
        return Dicts.GetValueOrDefaultCascading(dictionaryColl, key, default);
    }

    /// <summary>
    /// Try get value cascading <br />
    /// 级联地尝试获取一个可选地值，该值为值类型的
    /// </summary>
    /// <param name="dictionaryColl"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryGetValueCascading<K, V>(this IEnumerable<IDictionary<K, V>> dictionaryColl, K key, out V value)
    {
        return Dicts.TryGetValueCascading(dictionaryColl, key, out value);
    }

    #endregion

    #region Get or Add

    /// <summary>
    /// Get or add <br />
    /// 获取或添加
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static V GetValueOrAdd<K, V>(this Dictionary<K, V> dictionary, K key, V value)
    {
        return Dicts.GetValueOrAdd(dictionary, key, value);
    }

    /// <summary>
    /// Get or add <br />
    /// 获取或添加
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="newValueCreator"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static V GetValueOrAdd<K, V>(this Dictionary<K, V> dictionary, K key, Func<K, V> newValueCreator)
    {
        return Dicts.GetValueOrAdd(dictionary, key, newValueCreator);
    }

    /// <summary>
    /// Get or add new default instance <br />
    /// 获取或添加一个新的默认实例
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static V GetValueOrAddNewInstance<K, V>(this Dictionary<K, V> dictionary, K key) where V : new()
    {
        return Dicts.GetValueOrAddNewInstance(dictionary, key);
    }

    #endregion

    #region Set Value

    /// <summary>
    /// Set value <br />
    /// 设置值
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetValue<K, V>(this Dictionary<K, V> dictionary, K key, V value)
    {
        Dicts.SetValue(dictionary, key, value);
    }

    #endregion
}