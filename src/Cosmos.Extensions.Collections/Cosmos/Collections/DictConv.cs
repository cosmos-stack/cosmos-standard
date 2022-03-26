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
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        return new CastingReadOnlyDictionaryWrapper<TFromKey, TFromValue, TToKey, TToValue>(source);
    }

    #endregion

    #region To Dictionary

    /// <summary>
    /// To dictionary <br />
    /// 转换为字典
    /// </summary>
    /// <param name="hash"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(Hashtable hash)
    {
        var dictionary = new Dictionary<TKey, TValue>(hash.Count);
        foreach (var item in hash.Keys)
            dictionary.Add((TKey) item, (TValue) hash[item]);
        return dictionary;
    }

    /// <summary>
    /// To dictionary <br />
    /// 转换为字典
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> source)
    {
        return ToDictionary(source, EqualityComparer<TKey>.Default);
    }

    /// <summary>
    /// To dictionary <br />
    /// 转换为字典
    /// </summary>
    /// <param name="source"></param>
    /// <param name="equalityComparer"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey> equalityComparer)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (equalityComparer is null)
            throw new ArgumentNullException(nameof(equalityComparer));
        return source.ToDictionary(p => p.Key, p => p.Value, equalityComparer);
    }

    #endregion

    #region To Tuple

    /// <summary>
    /// To tuple... <br />
    /// 转换为元组
    /// </summary>
    /// <param name="dictionary"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static IEnumerable<Tuple<TKey, TValue>> ToTuple<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
    {
#if NETFRAMEWORK || NETSTANDARD2_0
            return dictionary.Select(pair => Tuple.Create(pair.Key, pair.Value));
#else
        foreach (var (key, value) in dictionary)
        {
            yield return Tuple.Create(key, value);
        }
#endif
    }

    #endregion

    #region To Sorted Array

    /// <summary>
    /// To sorted array by value <br />
    /// 转换为有序集合
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="asc"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <returns></returns>
    public static List<KeyValuePair<TKey, int>> ToSortedArrayByValue<TKey>(Dictionary<TKey, int> dictionary, bool asc = true)
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
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static List<KeyValuePair<TKey, TValue>> ToSortedArrayByKey<TKey, TValue>(Dictionary<TKey, TValue> dictionary) where TKey : IComparable<TKey>
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
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this Hashtable hash)
    {
        return DictConv.ToDictionary<TKey, TValue>(hash);
    }

    /// <summary>
    /// To dictionary <br />
    /// 转换为字典
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source)
    {
        return DictConv.ToDictionary(source);
    }

    /// <summary>
    /// To dictionary <br />
    /// 转换为字典
    /// </summary>
    /// <param name="source"></param>
    /// <param name="equalityComparer"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey> equalityComparer)
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
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<Tuple<TKey, TValue>> ToTuple<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
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
    /// <typeparam name="TKey"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<KeyValuePair<TKey, int>> ToSortedArrayByValue<TKey>(this Dictionary<TKey, int> dictionary, bool asc = true)
    {
        return DictConv.ToSortedArrayByValue(dictionary, asc);
    }

    /// <summary>
    /// To sorted array by key <br />
    /// 转换为有序集合
    /// </summary>
    /// <param name="dictionary"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<KeyValuePair<TKey, TValue>> ToSortedArrayByKey<TKey, TValue>(this Dictionary<TKey, TValue> dictionary) where TKey : IComparable<TKey>
    {
        return DictConv.ToSortedArrayByKey(dictionary);
    }

    #endregion
}