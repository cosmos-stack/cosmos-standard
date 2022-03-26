using Cosmos.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos;

/// <summary>
/// Object extensions <br />
/// 对象扩展
/// </summary>
public static class ObjectExtensions
{
    #region As

    /// <summary>
    /// As <br />
    /// 将 <see cref="object"/> 转换为 <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="this"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T As<T>(this object @this) => (T)@this;

    /// <summary>
    /// As or... <br />
    /// 将 <see cref="object"/> 转换为 <typeparamref name="T"/> 或给定的默认值
    /// </summary>
    /// <param name="this"></param>
    /// <param name="defaultVal"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T AsOr<T>(this object @this, T defaultVal) => @this.AsOrDefault(defaultVal);

    /// <summary>
    /// As or default <br />
    /// 将 <see cref="object"/> 转换为 <typeparamref name="T"/> 或默认值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="this"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T AsOrDefault<T>(this object @this)
    {
        try
        {
            return (T)@this;
        }
        catch (Exception)
        {
            return default;
        }
    }

    /// <summary>
    /// As or default <br />
    /// 将 <see cref="object"/> 转换为 <typeparamref name="T"/> 或给定的默认值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="this"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T AsOrDefault<T>(this object @this, T defaultValue)
    {
        try
        {
            return (T)@this;
        }
        catch (Exception)
        {
            return defaultValue;
        }
    }

    /// <summary>
    /// As or default <br />
    /// 将 <see cref="object"/> 转换为 <typeparamref name="T"/> 或根据给定的默认值工厂方法获得默认值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="this"></param>
    /// <param name="defaultValueFactory"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T AsOrDefault<T>(this object @this, Func<T> defaultValueFactory)
    {
        try
        {
            return (T)@this;
        }
        catch (Exception)
        {
            return defaultValueFactory();
        }
    }

    /// <summary>
    /// As or default <br />
    /// 将 <see cref="object"/> 转换为 <typeparamref name="T"/> 或根据给定的默认值工厂方法获得默认值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="this"></param>
    /// <param name="defaultValueFactory"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T AsOrDefault<T>(this object @this, Func<object, T> defaultValueFactory)
    {
        try
        {
            return (T)@this;
        }
        catch (Exception)
        {
            return defaultValueFactory(@this);
        }
    }

    #endregion

    #region Try As

    /// <summary>
    /// Try as <br />
    /// 尝试将 <see cref="object"/> 转换为 <typeparamref name="T"/>
    /// </summary>
    /// <param name="this"></param>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryAs<T>(this object @this, out T value)
    {
        try
        {
            value = @this.As<T>();
            return true;
        }
        catch
        {
            value = default;
            return false;
        }
    }

    /// <summary>
    /// Try as or <br />
    /// 尝试将 <see cref="object"/> 转换为 <typeparamref name="T"/> 或给定的默认值
    /// </summary>
    /// <param name="this"></param>
    /// <param name="defaultVal"></param>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryAsOr<T>(this object @this, T defaultVal, out T value) => @this.TryAsOrDefault(defaultVal, out value);

    /// <summary>
    /// Try as or default <br />
    /// 尝试将 <see cref="object"/> 转换为 <typeparamref name="T"/> 或给定的默认值
    /// </summary>
    /// <param name="this"></param>
    /// <param name="defaultValue"></param>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryAsOrDefault<T>(this object @this, T defaultValue, out T value)
    {
        try
        {
            value = @this.As<T>();
        }
        catch
        {
            value = defaultValue;
        }

        return true;
    }

    /// <summary>
    /// Try as or default <br />
    /// 尝试将 <see cref="object"/> 转换为 <typeparamref name="T"/> 或根据给定的默认值工厂方法获得默认值
    /// </summary>
    /// <param name="this"></param>
    /// <param name="defaultValueFactory"></param>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryAsOrDefault<T>(this object @this, Func<T> defaultValueFactory, out T value)
    {
        try
        {
            value = @this.As<T>();
        }
        catch
        {
            value = defaultValueFactory();
        }

        return true;
    }

    /// <summary>
    /// Try as or default <br />
    /// 尝试将 <see cref="object"/> 转换为 <typeparamref name="T"/> 或根据给定的默认值工厂方法获得默认值
    /// </summary>
    /// <param name="this"></param>
    /// <param name="defaultValueFactory"></param>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryAsOrDefault<T>(this object @this, Func<object, T> defaultValueFactory, out T value)
    {
        try
        {
            value = @this.As<T>();
        }
        catch
        {
            value = defaultValueFactory(@this);
        }

        return true;
    }

    #endregion

    #region Is On

    /// <summary>
    /// Is On
    /// </summary>
    /// <param name="source"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsOn(this byte source, params byte[] list) => IsOn<byte>(source, list);

    /// <summary>
    /// Is On <br />
    /// 判断对象是否存在于给定的 <paramref name="list"/> 内
    /// </summary>
    /// <param name="source"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsOn(this short source, params short[] list) => IsOn<short>(source, list);

    /// <summary>
    /// Is On <br />
    /// 判断对象是否存在于给定的 <paramref name="list"/> 内
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsOn<T>(this T source, params T[] list) where T : IComparable => list.Any(t => t.CompareTo(source) == 0);

    /// <summary>
    /// Is On <br />
    /// 判断对象是否存在于给定的 <paramref name="list"/> 内
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsOn<T>(this T source, IEnumerable<T> list) where T : IComparable => list.Any(item => item.CompareTo(source) == 0);

    /// <summary>
    /// Is On <br />
    /// 判断对象是否存在于给定的 <paramref name="list"/> 内
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsOn<T>(this T source, HashSet<T> list) where T : IComparable => list.Contains(source);

    /// <summary>
    /// Is On and ignore case <br />
    /// 判断字符串是否存在于给定的列表内（或略大小写）
    /// </summary>
    /// <param name="source"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsOnIgnoreCase(this string source, params string[] list) => list.Any(source.EqualsIgnoreCase);

    #endregion
}