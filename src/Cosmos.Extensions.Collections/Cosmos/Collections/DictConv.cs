using Cosmos.Collections.Internals;

namespace Cosmos.Collections;

/// <summary>
/// Dictionary Convertor <br />
/// 字典转换器
/// </summary>
public static class DictConv
{
    #region Dictionary Cast

    /// <summary>
    /// Cast <br />
    /// 转换
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="TFromKey"></typeparam>
    /// <typeparam name="TFromValue"></typeparam>
    /// <typeparam name="TToKey"></typeparam>
    /// <typeparam name="TToValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IReadOnlyDictionary<TToKey, TToValue> Cast<TFromKey, TFromValue, TToKey, TToValue>(
        IReadOnlyDictionary<TFromKey, TFromValue> source)
        where TFromKey : TToKey
        where TFromValue : TToValue
    {
        ArgumentNullException.ThrowIfNull(source);
        return new CastingReadOnlyDictionaryWrapper<TFromKey, TFromValue, TToKey, TToValue>(source);
    }

    #endregion

    #region To Dictionary

    /// <summary>
    /// To dictionary <br />
    /// 转换为字典
    /// </summary>
    /// <param name="hash"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    public static Dictionary<K, V> ToDictionary<K, V>(Hashtable hash)
    {
        var dictionary = new Dictionary<K, V>(hash.Count);
        foreach (var item in hash.Keys)
            dictionary.Add((K) item, (V) hash[item]);
        return dictionary;
    }

    /// <summary>
    /// To dictionary <br />
    /// 转换为字典
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    public static IDictionary<K, V> ToDictionary<K, V>(IEnumerable<KeyValuePair<K, V>> source)
    {
        return ToDictionary(source, EqualityComparer<K>.Default);
    }

    /// <summary>
    /// To dictionary <br />
    /// 转换为字典
    /// </summary>
    /// <param name="source"></param>
    /// <param name="equalityComparer"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IDictionary<K, V> ToDictionary<K, V>(IEnumerable<KeyValuePair<K, V>> source, IEqualityComparer<K> equalityComparer)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(equalityComparer);
        return source.ToDictionary(p => p.Key, p => p.Value, equalityComparer);
    }

    #endregion

    #region To Tuple

    /// <summary>
    /// To tuple... <br />
    /// 转换为元组
    /// </summary>
    /// <param name="dictionary"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    public static IEnumerable<Tuple<K, V>> ToTuple<K, V>(IDictionary<K, V> dictionary)
    {
        foreach (var (key, value) in dictionary)
        {
            yield return Tuple.Create(key, value);
        }
    }

    #endregion

    #region To Sorted Array

    /// <summary>
    /// To sorted array by value <br />
    /// 转换为有序集合
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="asc"></param>
    /// <typeparam name="K"></typeparam>
    /// <returns></returns>
    public static List<KeyValuePair<K, int>> ToSortedArrayByValue<K>(Dictionary<K, int> dictionary, bool asc = true)
    {
        var val = dictionary.ToList();
        var i = asc ? 1 : -1;

        val.Sort((x, y) => x.Value.CompareTo(y.Value) * i);

        return val;
    }

    /// <summary>
    /// To sorted array by key <br />
    /// 转换为有序集合
    /// </summary>
    /// <param name="dictionary"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    public static List<KeyValuePair<K, V>> ToSortedArrayByKey<K, V>(Dictionary<K, V> dictionary) where K : IComparable<K>
    {
        var val = dictionary.ToList();

        val.Sort((x, y) => x.Key.CompareTo(y.Key));

        return val;
    }

    #endregion
}

/// <summary>
/// Dictionary Convertor Extensions <br />
/// 字典转换器扩展
/// </summary>
public static class DictConvExtensions
{
    #region Dictionary Cast

    /// <summary>
    /// Cast <br />
    /// 转换
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="TFromKey"></typeparam>
    /// <typeparam name="TFromValue"></typeparam>
    /// <typeparam name="TToKey"></typeparam>
    /// <typeparam name="TToValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyDictionary<TToKey, TToValue> Cast<TFromKey, TFromValue, TToKey, TToValue>(
        this IReadOnlyDictionary<TFromKey, TFromValue> source)
        where TFromKey : TToKey
        where TFromValue : TToValue
    {
        return DictConv.Cast<TFromKey, TFromValue, TToKey, TToValue>(source);
    }

    #endregion

    #region To Dictionary

    /// <summary>
    /// To dictionary <br />
    /// 转换为字典
    /// </summary>
    /// <param name="hash"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Dictionary<K, V> ToDictionary<K, V>(this Hashtable hash)
    {
        return DictConv.ToDictionary<K, V>(hash);
    }

    /// <summary>
    /// To dictionary <br />
    /// 转换为字典
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IDictionary<K, V> ToDictionary<K, V>(this IEnumerable<KeyValuePair<K, V>> source)
    {
        return DictConv.ToDictionary(source);
    }

    /// <summary>
    /// To dictionary <br />
    /// 转换为字典
    /// </summary>
    /// <param name="source"></param>
    /// <param name="equalityComparer"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IDictionary<K, V> ToDictionary<K, V>(this IEnumerable<KeyValuePair<K, V>> source, IEqualityComparer<K> equalityComparer)
    {
        return DictConv.ToDictionary(source, equalityComparer);
    }

    #endregion

    #region To Tuple

    /// <summary>
    /// To tuple... <br />
    /// 转换为元组
    /// </summary>
    /// <param name="dictionary"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<Tuple<K, V>> ToTuple<K, V>(this IDictionary<K, V> dictionary)
    {
        return DictConv.ToTuple(dictionary);
    }

    #endregion

    #region To Sorted Array

    /// <summary>
    /// To sorted array by value <br />
    /// 转换为有序集合
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="asc"></param>
    /// <typeparam name="K"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<KeyValuePair<K, int>> ToSortedArrayByValue<K>(this Dictionary<K, int> dictionary, bool asc = true)
    {
        return DictConv.ToSortedArrayByValue(dictionary, asc);
    }

    /// <summary>
    /// To sorted array by key <br />
    /// 转换为有序集合
    /// </summary>
    /// <param name="dictionary"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<KeyValuePair<K, V>> ToSortedArrayByKey<K, V>(this Dictionary<K, V> dictionary) where K : IComparable<K>
    {
        return DictConv.ToSortedArrayByKey(dictionary);
    }

    #endregion
}