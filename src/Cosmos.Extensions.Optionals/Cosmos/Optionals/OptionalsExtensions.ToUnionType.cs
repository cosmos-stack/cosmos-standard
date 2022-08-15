namespace Cosmos.Optionals;

/// <summary>
/// Extensions for optional
/// </summary>
public static partial class OptionalsExtensions
{
    /// <summary>
    /// To Union Type <br />
    /// 转换为联合类型
    /// </summary>
    /// <returns></returns>
    public static UnionType<T> ToUnionType<T>(this Maybe<T> maybe)
    {
        if (maybe.HasValue)
            return UnionType.Of(maybe.ValueOr(default(T)));
        return UnionType<T>.FromNull();
    }

    /// <summary>
    /// To Union Type <br />
    /// 转换为联合类型
    /// </summary>
    /// <returns></returns>
    public static UnionType<T1, T2> ToUnionType<T1, T2>(this Maybe<T1, T2> maybe)
    {
        if (maybe._o1.HasValue)
            return UnionType.Of<T1, T2>(maybe._o1.ValueOr(default(T1)));
        if (maybe._o2.HasValue)
            return UnionType.Of<T1, T2>(maybe._o2.ValueOr(default(T2)));
        return UnionType<T1, T2>.FromNull();
    }

    /// <summary>
    /// To Union Type <br />
    /// 转换为联合类型
    /// </summary>
    /// <returns></returns>
    public static UnionType<T1, T2, T3> ToUnionType<T1, T2, T3>(this Maybe<T1, T2, T3> maybe)
    {
        if (maybe._o1.HasValue)
            return UnionType.Of<T1, T2, T3>(maybe._o1.ValueOr(default(T1)));
        if (maybe._o2.HasValue)
            return UnionType.Of<T1, T2, T3>(maybe._o2.ValueOr(default(T2)));
        if (maybe._o3.HasValue)
            return UnionType.Of<T1, T2, T3>(maybe._o3.ValueOr(default(T3)));
        return UnionType<T1, T2, T3>.FromNull();
    }

    /// <summary>
    /// To Union Type <br />
    /// 转换为联合类型
    /// </summary>
    /// <returns></returns>
    public static UnionType<T1, T2, T3, T4> ToUnionType<T1, T2, T3, T4>(
        this Maybe<T1, T2, T3, T4> maybe)
    {
        if (maybe._o1.HasValue)
            return UnionType.Of<T1, T2, T3, T4>(maybe._o1.ValueOr(default(T1)));
        if (maybe._o2.HasValue)
            return UnionType.Of<T1, T2, T3, T4>(maybe._o2.ValueOr(default(T2)));
        if (maybe._o3.HasValue)
            return UnionType.Of<T1, T2, T3, T4>(maybe._o3.ValueOr(default(T3)));
        if (maybe._o4.HasValue)
            return UnionType.Of<T1, T2, T3, T4>(maybe._o4.ValueOr(default(T4)));
        return UnionType<T1, T2, T3, T4>.FromNull();
    }

    /// <summary>
    /// To Union Type <br />
    /// 转换为联合类型
    /// </summary>
    /// <returns></returns>
    public static UnionType<T1, T2, T3, T4, T5> ToUnionType<T1, T2, T3, T4, T5>(
        this Maybe<T1, T2, T3, T4, T5> maybe)
    {
        if (maybe._o1.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5>(maybe._o1.ValueOr(default(T1)));
        if (maybe._o2.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5>(maybe._o2.ValueOr(default(T2)));
        if (maybe._o3.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5>(maybe._o3.ValueOr(default(T3)));
        if (maybe._o4.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5>(maybe._o4.ValueOr(default(T4)));
        if (maybe._o5.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5>(maybe._o5.ValueOr(default(T5)));
        return UnionType<T1, T2, T3, T4, T5>.FromNull();
    }

    /// <summary>
    /// To Union Type <br />
    /// 转换为联合类型
    /// </summary>
    /// <returns></returns>
    public static UnionType<T1, T2, T3, T4, T5, T6> ToUnionType<T1, T2, T3, T4, T5, T6>(
        this Maybe<T1, T2, T3, T4, T5, T6> maybe)
    {
        if (maybe._o1.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6>(maybe._o1.ValueOr(default(T1)));
        if (maybe._o2.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6>(maybe._o2.ValueOr(default(T2)));
        if (maybe._o3.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6>(maybe._o3.ValueOr(default(T3)));
        if (maybe._o4.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6>(maybe._o4.ValueOr(default(T4)));
        if (maybe._o5.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6>(maybe._o5.ValueOr(default(T5)));
        if (maybe._o6.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6>(maybe._o6.ValueOr(default(T6)));
        return UnionType<T1, T2, T3, T4, T5, T6>.FromNull();
    }

    /// <summary>
    /// To Union Type <br />
    /// 转换为联合类型
    /// </summary>
    /// <returns></returns>
    public static UnionType<T1, T2, T3, T4, T5, T6, T7> ToUnionType<T1, T2, T3, T4, T5, T6, T7>(
        this Maybe<T1, T2, T3, T4, T5, T6, T7> maybe)
    {
        if (maybe._o1.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7>(maybe._o1.ValueOr(default(T1)));
        if (maybe._o2.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7>(maybe._o2.ValueOr(default(T2)));
        if (maybe._o3.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7>(maybe._o3.ValueOr(default(T3)));
        if (maybe._o4.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7>(maybe._o4.ValueOr(default(T4)));
        if (maybe._o5.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7>(maybe._o5.ValueOr(default(T5)));
        if (maybe._o6.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7>(maybe._o6.ValueOr(default(T6)));
        if (maybe._o7.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7>(maybe._o7.ValueOr(default(T7)));
        return UnionType<T1, T2, T3, T4, T5, T6, T7>.FromNull();
    }

    /// <summary>
    /// To Union Type <br />
    /// 转换为联合类型
    /// </summary>
    /// <returns></returns>
    public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8> ToUnionType<T1, T2, T3, T4, T5, T6, T7, T8>(
        this Maybe<T1, T2, T3, T4, T5, T6, T7, T8> maybe)
    {
        if (maybe._o1.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8>(maybe._o1.ValueOr(default(T1)));
        if (maybe._o2.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8>(maybe._o2.ValueOr(default(T2)));
        if (maybe._o3.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8>(maybe._o3.ValueOr(default(T3)));
        if (maybe._o4.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8>(maybe._o4.ValueOr(default(T4)));
        if (maybe._o5.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8>(maybe._o5.ValueOr(default(T5)));
        if (maybe._o6.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8>(maybe._o6.ValueOr(default(T6)));
        if (maybe._o7.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8>(maybe._o7.ValueOr(default(T7)));
        if (maybe._o8.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8>(maybe._o8.ValueOr(default(T8)));
        return UnionType<T1, T2, T3, T4, T5, T6, T7, T8>.FromNull();
    }

    /// <summary>
    /// To Union Type <br />
    /// 转换为联合类型
    /// </summary>
    /// <returns></returns>
    public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9> ToUnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        this Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9> maybe)
    {
        if (maybe._o1.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9>(maybe._o1.ValueOr(default(T1)));
        if (maybe._o2.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9>(maybe._o2.ValueOr(default(T2)));
        if (maybe._o3.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9>(maybe._o3.ValueOr(default(T3)));
        if (maybe._o4.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9>(maybe._o4.ValueOr(default(T4)));
        if (maybe._o5.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9>(maybe._o5.ValueOr(default(T5)));
        if (maybe._o6.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9>(maybe._o6.ValueOr(default(T6)));
        if (maybe._o7.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9>(maybe._o7.ValueOr(default(T7)));
        if (maybe._o8.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9>(maybe._o8.ValueOr(default(T8)));
        if (maybe._o9.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9>(maybe._o9.ValueOr(default(T9)));
        return UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9>.FromNull();
    }

    /// <summary>
    /// To Union Type <br />
    /// 转换为联合类型
    /// </summary>
    /// <returns></returns>
    public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> ToUnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
        this Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> maybe)
    {
        if (maybe._o1.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(maybe._o1.ValueOr(default(T1)));
        if (maybe._o2.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(maybe._o2.ValueOr(default(T2)));
        if (maybe._o3.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(maybe._o3.ValueOr(default(T3)));
        if (maybe._o4.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(maybe._o4.ValueOr(default(T4)));
        if (maybe._o5.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(maybe._o5.ValueOr(default(T5)));
        if (maybe._o6.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(maybe._o6.ValueOr(default(T6)));
        if (maybe._o7.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(maybe._o7.ValueOr(default(T7)));
        if (maybe._o8.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(maybe._o8.ValueOr(default(T8)));
        if (maybe._o9.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(maybe._o9.ValueOr(default(T9)));
        if (maybe._o10.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(maybe._o10.ValueOr(default(T10)));
        return UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.FromNull();
    }

    /// <summary>
    /// To Union Type <br />
    /// 转换为联合类型
    /// </summary>
    /// <returns></returns>
    public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> ToUnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
        this Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> maybe)
    {
        if (maybe._o1.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(maybe._o1.ValueOr(default(T1)));
        if (maybe._o2.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(maybe._o2.ValueOr(default(T2)));
        if (maybe._o3.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(maybe._o3.ValueOr(default(T3)));
        if (maybe._o4.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(maybe._o4.ValueOr(default(T4)));
        if (maybe._o5.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(maybe._o5.ValueOr(default(T5)));
        if (maybe._o6.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(maybe._o6.ValueOr(default(T6)));
        if (maybe._o7.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(maybe._o7.ValueOr(default(T7)));
        if (maybe._o8.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(maybe._o8.ValueOr(default(T8)));
        if (maybe._o9.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(maybe._o9.ValueOr(default(T9)));
        if (maybe._o10.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(maybe._o10.ValueOr(default(T10)));
        if (maybe._o11.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(maybe._o11.ValueOr(default(T11)));
        return UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.FromNull();
    }

    /// <summary>
    /// To Union Type <br />
    /// 转换为联合类型
    /// </summary>
    /// <returns></returns>
    public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> ToUnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
        this Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> maybe)
    {
        if (maybe._o1.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(maybe._o1.ValueOr(default(T1)));
        if (maybe._o2.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(maybe._o2.ValueOr(default(T2)));
        if (maybe._o3.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(maybe._o3.ValueOr(default(T3)));
        if (maybe._o4.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(maybe._o4.ValueOr(default(T4)));
        if (maybe._o5.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(maybe._o5.ValueOr(default(T5)));
        if (maybe._o6.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(maybe._o6.ValueOr(default(T6)));
        if (maybe._o7.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(maybe._o7.ValueOr(default(T7)));
        if (maybe._o8.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(maybe._o8.ValueOr(default(T8)));
        if (maybe._o9.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(maybe._o9.ValueOr(default(T9)));
        if (maybe._o10.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(maybe._o10.ValueOr(default(T10)));
        if (maybe._o11.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(maybe._o11.ValueOr(default(T11)));
        if (maybe._o12.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(maybe._o12.ValueOr(default(T12)));
        return UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.FromNull();
    }

    /// <summary>
    /// To Union Type <br />
    /// 转换为联合类型
    /// </summary>
    /// <returns></returns>
    public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> ToUnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
        this Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> maybe)
    {
        if (maybe._o1.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(maybe._o1.ValueOr(default(T1)));
        if (maybe._o2.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(maybe._o2.ValueOr(default(T2)));
        if (maybe._o3.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(maybe._o3.ValueOr(default(T3)));
        if (maybe._o4.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(maybe._o4.ValueOr(default(T4)));
        if (maybe._o5.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(maybe._o5.ValueOr(default(T5)));
        if (maybe._o6.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(maybe._o6.ValueOr(default(T6)));
        if (maybe._o7.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(maybe._o7.ValueOr(default(T7)));
        if (maybe._o8.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(maybe._o8.ValueOr(default(T8)));
        if (maybe._o9.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(maybe._o9.ValueOr(default(T9)));
        if (maybe._o10.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(maybe._o10.ValueOr(default(T10)));
        if (maybe._o11.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(maybe._o11.ValueOr(default(T11)));
        if (maybe._o12.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(maybe._o12.ValueOr(default(T12)));
        if (maybe._o13.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(maybe._o13.ValueOr(default(T13)));
        return UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.FromNull();
    }

    /// <summary>
    /// To Union Type <br />
    /// 转换为联合类型
    /// </summary>
    /// <returns></returns>
    public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> ToUnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
        this Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> maybe)
    {
        if (maybe._o1.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(maybe._o1.ValueOr(default(T1)));
        if (maybe._o2.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(maybe._o2.ValueOr(default(T2)));
        if (maybe._o3.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(maybe._o3.ValueOr(default(T3)));
        if (maybe._o4.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(maybe._o4.ValueOr(default(T4)));
        if (maybe._o5.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(maybe._o5.ValueOr(default(T5)));
        if (maybe._o6.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(maybe._o6.ValueOr(default(T6)));
        if (maybe._o7.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(maybe._o7.ValueOr(default(T7)));
        if (maybe._o8.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(maybe._o8.ValueOr(default(T8)));
        if (maybe._o9.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(maybe._o9.ValueOr(default(T9)));
        if (maybe._o10.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(maybe._o10.ValueOr(default(T10)));
        if (maybe._o11.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(maybe._o11.ValueOr(default(T11)));
        if (maybe._o12.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(maybe._o12.ValueOr(default(T12)));
        if (maybe._o13.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(maybe._o13.ValueOr(default(T13)));
        if (maybe._o14.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(maybe._o14.ValueOr(default(T14)));
        return UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.FromNull();
    }

    /// <summary>
    /// To Union Type <br />
    /// 转换为联合类型
    /// </summary>
    /// <returns></returns>
    public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> ToUnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
        this Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> maybe)
    {
        if (maybe._o1.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(maybe._o1.ValueOr(default(T1)));
        if (maybe._o2.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(maybe._o2.ValueOr(default(T2)));
        if (maybe._o3.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(maybe._o3.ValueOr(default(T3)));
        if (maybe._o4.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(maybe._o4.ValueOr(default(T4)));
        if (maybe._o5.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(maybe._o5.ValueOr(default(T5)));
        if (maybe._o6.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(maybe._o6.ValueOr(default(T6)));
        if (maybe._o7.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(maybe._o7.ValueOr(default(T7)));
        if (maybe._o8.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(maybe._o8.ValueOr(default(T8)));
        if (maybe._o9.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(maybe._o9.ValueOr(default(T9)));
        if (maybe._o10.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(maybe._o10.ValueOr(default(T10)));
        if (maybe._o11.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(maybe._o11.ValueOr(default(T11)));
        if (maybe._o12.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(maybe._o12.ValueOr(default(T12)));
        if (maybe._o13.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(maybe._o13.ValueOr(default(T13)));
        if (maybe._o14.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(maybe._o14.ValueOr(default(T14)));
        if (maybe._o15.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(maybe._o15.ValueOr(default(T15)));
        return UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.FromNull();
    }

    /// <summary>
    /// To Union Type <br />
    /// 转换为联合类型
    /// </summary>
    /// <returns></returns>
    public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> ToUnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
        this Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> maybe)
    {
        if (maybe._o1.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(maybe._o1.ValueOr(default(T1)));
        if (maybe._o2.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(maybe._o2.ValueOr(default(T2)));
        if (maybe._o3.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(maybe._o3.ValueOr(default(T3)));
        if (maybe._o4.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(maybe._o4.ValueOr(default(T4)));
        if (maybe._o5.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(maybe._o5.ValueOr(default(T5)));
        if (maybe._o6.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(maybe._o6.ValueOr(default(T6)));
        if (maybe._o7.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(maybe._o7.ValueOr(default(T7)));
        if (maybe._o8.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(maybe._o8.ValueOr(default(T8)));
        if (maybe._o9.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(maybe._o9.ValueOr(default(T9)));
        if (maybe._o10.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(maybe._o10.ValueOr(default(T10)));
        if (maybe._o11.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(maybe._o11.ValueOr(default(T11)));
        if (maybe._o12.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(maybe._o12.ValueOr(default(T12)));
        if (maybe._o13.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(maybe._o13.ValueOr(default(T13)));
        if (maybe._o14.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(maybe._o14.ValueOr(default(T14)));
        if (maybe._o15.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(maybe._o15.ValueOr(default(T15)));
        if (maybe._o16.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(maybe._o16.ValueOr(default(T16)));
        return UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.FromNull();
    }

    /// <summary>
    /// To Union Type <br />
    /// 转换为联合类型
    /// </summary>
    /// <returns></returns>
    public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> ToUnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
        this Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> maybe)
    {
        if (maybe._o1.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(maybe._o1.ValueOr(default(T1)));
        if (maybe._o2.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(maybe._o2.ValueOr(default(T2)));
        if (maybe._o3.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(maybe._o3.ValueOr(default(T3)));
        if (maybe._o4.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(maybe._o4.ValueOr(default(T4)));
        if (maybe._o5.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(maybe._o5.ValueOr(default(T5)));
        if (maybe._o6.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(maybe._o6.ValueOr(default(T6)));
        if (maybe._o7.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(maybe._o7.ValueOr(default(T7)));
        if (maybe._o8.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(maybe._o8.ValueOr(default(T8)));
        if (maybe._o9.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(maybe._o9.ValueOr(default(T9)));
        if (maybe._o10.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(maybe._o10.ValueOr(default(T10)));
        if (maybe._o11.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(maybe._o11.ValueOr(default(T11)));
        if (maybe._o12.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(maybe._o12.ValueOr(default(T12)));
        if (maybe._o13.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(maybe._o13.ValueOr(default(T13)));
        if (maybe._o14.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(maybe._o14.ValueOr(default(T14)));
        if (maybe._o15.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(maybe._o15.ValueOr(default(T15)));
        if (maybe._o16.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(maybe._o16.ValueOr(default(T16)));
        if (maybe._o17.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(maybe._o17.ValueOr(default(T17)));
        return UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>.FromNull();
    }

    /// <summary>
    /// To Union Type <br />
    /// 转换为联合类型
    /// </summary>
    /// <returns></returns>
    public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> ToUnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
        this Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18> maybe)
    {
        if (maybe._o1.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(maybe._o1.ValueOr(default(T1)));
        if (maybe._o2.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(maybe._o2.ValueOr(default(T2)));
        if (maybe._o3.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(maybe._o3.ValueOr(default(T3)));
        if (maybe._o4.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(maybe._o4.ValueOr(default(T4)));
        if (maybe._o5.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(maybe._o5.ValueOr(default(T5)));
        if (maybe._o6.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(maybe._o6.ValueOr(default(T6)));
        if (maybe._o7.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(maybe._o7.ValueOr(default(T7)));
        if (maybe._o8.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(maybe._o8.ValueOr(default(T8)));
        if (maybe._o9.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(maybe._o9.ValueOr(default(T9)));
        if (maybe._o10.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(maybe._o10.ValueOr(default(T10)));
        if (maybe._o11.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(maybe._o11.ValueOr(default(T11)));
        if (maybe._o12.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(maybe._o12.ValueOr(default(T12)));
        if (maybe._o13.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(maybe._o13.ValueOr(default(T13)));
        if (maybe._o14.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(maybe._o14.ValueOr(default(T14)));
        if (maybe._o15.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(maybe._o15.ValueOr(default(T15)));
        if (maybe._o16.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(maybe._o16.ValueOr(default(T16)));
        if (maybe._o17.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(maybe._o17.ValueOr(default(T17)));
        if (maybe._o18.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(maybe._o18.ValueOr(default(T18)));
        return UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>.FromNull();
    }

    /// <summary>
    /// To Union Type <br />
    /// 转换为联合类型
    /// </summary>
    /// <returns></returns>
    public static UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> ToUnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
        this Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> maybe)
    {
        if (maybe._o1.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(maybe._o1.ValueOr(default(T1)));
        if (maybe._o2.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(maybe._o2.ValueOr(default(T2)));
        if (maybe._o3.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(maybe._o3.ValueOr(default(T3)));
        if (maybe._o4.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(maybe._o4.ValueOr(default(T4)));
        if (maybe._o5.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(maybe._o5.ValueOr(default(T5)));
        if (maybe._o6.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(maybe._o6.ValueOr(default(T6)));
        if (maybe._o7.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(maybe._o7.ValueOr(default(T7)));
        if (maybe._o8.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(maybe._o8.ValueOr(default(T8)));
        if (maybe._o9.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(maybe._o9.ValueOr(default(T9)));
        if (maybe._o10.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(maybe._o10.ValueOr(default(T10)));
        if (maybe._o11.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(maybe._o11.ValueOr(default(T11)));
        if (maybe._o12.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(maybe._o12.ValueOr(default(T12)));
        if (maybe._o13.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(maybe._o13.ValueOr(default(T13)));
        if (maybe._o14.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(maybe._o14.ValueOr(default(T14)));
        if (maybe._o15.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(maybe._o15.ValueOr(default(T15)));
        if (maybe._o16.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(maybe._o16.ValueOr(default(T16)));
        if (maybe._o17.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(maybe._o17.ValueOr(default(T17)));
        if (maybe._o18.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(maybe._o18.ValueOr(default(T18)));
        if (maybe._o19.HasValue)
            return UnionType.Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(maybe._o19.ValueOr(default(T19)));
        return UnionType<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>.FromNull();
    }
}