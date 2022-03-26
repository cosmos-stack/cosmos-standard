namespace Cosmos;

/// <summary>
/// Boolean value wrapper <br />
/// 带上下文的布尔值
/// </summary>
/// <typeparam name="T"></typeparam>
public struct BooleanVal<T>
{
    public BooleanVal(bool value, T obj)
    {
        Value = value;
        Object = obj;
    }

    /// <summary>
    /// Gets value <br />
    /// 获得布尔封装值的具体值
    /// </summary>
    public bool Value { get; }

    /// <summary>
    /// Gets context <br />
    /// 获得布尔封装值的上下文
    /// </summary>
    public T Object { get; }

    public static implicit operator (bool Value, T Object)(BooleanVal<T> val)
    {
        return (val.Value, val.Object);
    }

    public static implicit operator BooleanVal<T>((bool Value, T Object) tuple)
    {
        return new(tuple.Value, tuple.Object);
    }

    public static implicit operator bool(BooleanVal<T> val)
    {
        return val.Value;
    }

    public static implicit operator BooleanVal<T>(bool value)
    {
        return new(value, default);
    }

    /// <summary>
    /// Of <br />
    /// 创建一个布尔封装值
    /// </summary>
    /// <param name="value"></param>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static BooleanVal<T> Of(bool value, T obj) => new(value, obj);
}

/// <summary>
/// BooleanVal extensions <br />
/// 布尔封装值扩展
/// </summary>
public static class BooleanValExtensions
{
    /// <summary>
    /// Convert boolean to Wrapped-Context Boolean <br />
    /// 将普通布尔值转换为布尔封装值
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static BooleanVal<T> ToBooleanVal<T>(this bool value) => value;

    /// <summary>
    /// Convert boolean to Wrapped-Context Boolean <br />
    /// 将普通布尔值转换为布尔封装值
    /// </summary>
    /// <param name="value"></param>
    /// <param name="packagedValue"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static BooleanVal<T> ToBooleanVal<T>(this bool value, T packagedValue) => new(value, packagedValue);

    /// <summary>
    /// Convert boolean to Wrapped-Context Boolean <br />
    /// 将普通布尔值转换为布尔封装值
    /// </summary>
    /// <param name="tuple"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static BooleanVal<T> ToBooleanVal<T>(this (bool, T) tuple) => tuple;
}