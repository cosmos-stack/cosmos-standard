using Cosmos.Collections.Internals;

namespace Cosmos.Collections;

/// <summary>
/// Collection Convertor <br />
/// 集合转换器
/// </summary>
public static class CollConv
{
    #region ToEnumerable

    /// <summary>
    /// To Enumerable <br />
    /// 转换为 <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <param name="enumerator"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IEnumerable<T> ToEnumerable<T>(IEnumerator<T> enumerator)
    {
        ArgumentNullException.ThrowIfNull(enumerator);

        IEnumerable<T> Implementation()
        {
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }

        return Implementation();
    }

    /// <summary>
    /// To Enumerable After <br />
    /// 转换为 <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <param name="enumerator"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IEnumerable<T> ToEnumerableAfter<T>(IEnumerator<T> enumerator)
    {
        ArgumentNullException.ThrowIfNull(enumerator);

        IEnumerable<T> Implementation()
        {
            do
            {
                yield return enumerator.Current;
            } while (enumerator.MoveNext());
        }

        return Implementation();
    }

    #endregion

    #region ToIndexedSequence

    /// <summary>
    /// To index sequence <br />
    /// 转换为具有索引的序列
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IEnumerable<KeyValuePair<int, T>> ToIndexedSequence<T>(IEnumerable<T> source)
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select((t, i) => new KeyValuePair<int, T>(i, t));
    }

    #endregion

    #region ToSortedArray

    /// <summary>
    /// To sorted array <br />
    /// 转换为有序数组
    /// </summary>
    /// <param name="source"></param>
    /// <param name="comparer"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    public static TSource[] ToSortedArray<TSource>(IEnumerable<TSource> source, Comparison<TSource> comparer)
    {
        var res = source.ToArray();
        Array.Sort(res, comparer);
        return res;
    }

    /// <summary>
    /// To sorted array <br />
    /// 转换为有序数组
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    public static TSource[] ToSortedArray<TSource>(IEnumerable<TSource> source) where TSource : IComparable<TSource>
    {
        var res = source.ToArray();
        Array.Sort(res);
        return res;
    }

    #endregion

    #region AsOptionals

    /// <summary>
    /// As Nullables <br />
    /// 转换为可空成员集合
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IEnumerable<T?> AsOptionals<T>(IEnumerable<T> source) where T : struct
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Cast<T?>();
    }

    #endregion

    #region AsProxy

    /// <summary>
    /// As enumerable proxy <br />
    /// 转换为 <see cref="EnumerableProxy{T}"/>
    /// </summary>
    /// <param name="enumerable"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static EnumerableProxy<T> AsEnumerableProxy<T>(IEnumerable<T> enumerable)
    {
        ArgumentNullException.ThrowIfNull(enumerable);
        return new EnumerableProxy<T>(enumerable);
    }

    #endregion

    #region AsNullWhenEmpty

    /// <summary>
    /// Null if empty <br />
    /// 如果为空，则返回 Null
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<T> AsNullWhenEmpty<T>(this IEnumerable<T> source)
    {
        // Get the enumerator in a releasable disposable.
        using var disposable = new InternalReleasableDisposable<IEnumerator<T>>(source.GetEnumerator());
        // Get the enumerator.
        var enumerator = disposable.Disposable;

        // Move to the next item.  If there are no elements, then return null.
        if (!enumerator.MoveNext()) return null;

        // Release the disposable.
        disposable.Release();

        // Create an enumerator that skips the first move next.
        var wrapper = new InternalNullIfEmptySkipFirstMoveNextEnumeratorWrapper<T>(enumerator);

        // Wrap in a single use enumerator, return that.
        return new InternalSingleUseEnumerable<T>(wrapper);
    }

    #endregion
}

/// <summary>
/// Collection Convertor Extensions <br />
/// 集合转换器扩展
/// </summary>
public static class CollConvExtensions
{
    #region ToEnumerable

    /// <summary>
    /// To Enumerable <br />
    /// 转换为 <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <param name="enumerator"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T> ToEnumerable<T>(this IEnumerator<T> enumerator)
    {
        return CollConv.ToEnumerable(enumerator);
    }

    /// <summary>
    /// To Enumerable After <br />
    /// 转换为 <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <param name="enumerator"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T> ToEnumerableAfter<T>(this IEnumerator<T> enumerator)
    {
        return CollConv.ToEnumerableAfter(enumerator);
    }

    #endregion

    #region ToIndexedSequence

    /// <summary>
    /// To index sequence <br />
    /// 转换为具有索引的序列
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<KeyValuePair<int, T>> ToIndexedSequence<T>(this IEnumerable<T> source)
    {
        return CollConv.ToIndexedSequence(source);
    }

    #endregion

    #region ToSortedArray

    /// <summary>
    /// To sorted array <br />
    /// 转换为有序数组
    /// </summary>
    /// <param name="source"></param>
    /// <param name="comparer"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource[] ToSortedArray<TSource>(this IEnumerable<TSource> source, Comparison<TSource> comparer)
    {
        return CollConv.ToSortedArray(source, comparer);
    }

    /// <summary>
    /// To sorted array <br />
    /// 转换为有序数组
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TSource[] ToSortedArray<TSource>(this IEnumerable<TSource> source)
        where TSource : IComparable<TSource>
    {
        return CollConv.ToSortedArray(source);
    }

    #endregion

    #region ToHashSet

    /// <summary>
    /// To HashSet <br />
    /// 转换为 <see cref="HashSet{T}"/>
    /// </summary>
    /// <param name="source"></param>
    /// <param name="ignoreDup"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source, bool ignoreDup) where T : IComparable<T>
    {
        return ignoreDup
            ? source.Distinct().ToHashSet(EqualityComparer<T>.Default)
            : source.ToHashSet(EqualityComparer<T>.Default);
    }

    /// <summary>
    /// To HashSet <br />
    /// 转换为 <see cref="HashSet{T}"/>
    /// </summary>
    /// <param name="source"></param>
    /// <param name="keyFunc"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HashSet<TKey> ToHashSet<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keyFunc)
        where TKey : IComparable<TKey>
    {
        ArgumentNullException.ThrowIfNull(keyFunc);
        return source.Select(keyFunc).ToHashSet(EqualityComparer<TKey>.Default);
    }

    /// <summary>
    /// To HashSet ignore duplicates <br />
    /// 转换为 <see cref="HashSet{T}"/>，并忽视重复的值
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HashSet<T> ToHashSetIgnoringDuplicates<T>(this IEnumerable<T> source) where T : IComparable<T>
    {
        return source.ToHashSet(true);
    }

    #endregion
}

/// <summary>
/// Collection Convertor Shortcut Extensions <br />
/// 集合转换器捷径扩展
/// </summary>
public static class CollConvShortcutExtensions
{
    /// <summary>
    /// To string list <br />
    /// 转换为字符串列表
    /// </summary>
    /// <param name="source"></param>
    /// <param name="stringConverter"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<string> ToList<T>(this IEnumerable<T> source, Func<T, string> stringConverter)
    {
        return source.Select(stringConverter).ToList();
    }

    /// <summary>
    /// To list <br />
    /// 转换为列表
    /// </summary>
    /// <param name="source"></param>
    /// <param name="func"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IList<T> ToList<T>(this IEnumerable<T> source, Func<T, bool> func)
    {
        ArgumentNullException.ThrowIfNull(source);
        return func is null ? source.ToList() : source.Where(func).ToList();
    }
}