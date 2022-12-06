using System.Diagnostics.Contracts;

namespace Cosmos.Text;

/// <summary>
/// String Utils<br />
/// 字符串工具
/// </summary>
public static partial class Strings
{
    #region Reverse

    /// <summary>
    /// Reverse <br />
    /// 反转字符串
    /// </summary>
    /// <param name="builder"></param>
    public static void Reverse(StringBuilder builder)
    {
        if (builder is null || builder.Length == 0)
            return;

        var destination = new char[builder.Length];
        builder.CopyTo(0, destination, 0, builder.Length);
        Array.Reverse(destination);

        builder.Clear();
        builder.Append(destination);
    }

    /// <summary>
    /// Reverse <see cref="StringBuilder"/> <br />
    /// 反转字符串，并返回一个新的 <see cref="StringBuilder"/> 实例。
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static StringBuilder ReverseAndReturnNewInstance(StringBuilder builder)
    {
        if (builder is null)
            return new StringBuilder();
        if (builder.Length == 0)
            return new StringBuilder();

        var destination = new char[builder.Length];
        builder.CopyTo(0, destination, 0, builder.Length);
        Array.Reverse(destination);
        return new StringBuilder().Append(destination);
    }

    /// <summary>
    /// Reverse string <br />
    /// 反转字符串
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static string ReverseAndToString(StringBuilder builder)
    {
        if (builder is null || builder.Length == 0)
            return string.Empty;

        var destination = new char[builder.Length];
        builder.CopyTo(0, destination, 0, builder.Length);
        Array.Reverse(destination);
        return string.Join(null, destination);
    }

    #endregion
}

/// <summary>
/// String extensions <br />
/// 字符串扩展
/// </summary>
public static partial class StringsExtensions
{
    #region Append

    /// <summary>
    /// Shortcut for adding an array of values to a StringBuilder. <br />
    /// 将一组值添加到 StringBuilder 中。
    /// </summary>
    public static StringBuilder AppendAll<T>(this StringBuilder target, IEnumerable<T> values, string separator = null)
    {
        if (target is null)
            throw new NullReferenceException();

        Contract.EndContractBlock();

        if (values is not null)
        {
            if (string.IsNullOrEmpty(separator))
            {
                foreach (var value in values)
                    target.Append(value);
            }
            else
            {
                foreach (var value in values)
                    target.AppendWithSeparator(separator, value);
            }
        }

        return target;
    }

    /// <summary>
    /// Shortcut for adding an array of values to a StringBuilder. <br />
    /// 将一组值添加到 StringBuilder 中。
    /// </summary>
    public static StringBuilder AppendAll<T>(this StringBuilder target, IEnumerable<T> values, in char separator)
    {
        if (target is null)
            throw new NullReferenceException();

        Contract.EndContractBlock();

        if (values != null)
            foreach (var value in values)
                target.AppendWithSeparator(in separator, value);

        return target;
    }

    /// <summary>
    /// Appends values to StringBuilder prefixing the provided separator. <br />
    /// 将值附加到 StringBuilder 以提供的分隔符为前缀。
    /// </summary>
    public static StringBuilder AppendWithSeparator<T>(this StringBuilder target, string separator, params T[] values)
    {
        if (target is null)
            throw new NullReferenceException();
        if (values is null || values.Length == 0)
            throw new ArgumentException("Parameters missing.");

        Contract.EndContractBlock();

        if (!string.IsNullOrEmpty(separator) && target.Length != 0)
            target.Append(separator);

        target.AppendAll(values);

        return target;
    }

    /// <summary>
    /// Appends values to StringBuilder prefixing the provided separator. <br />
    /// 将值附加到 StringBuilder 以提供的分隔符为前缀。
    /// </summary>
    public static StringBuilder AppendWithSeparator<T>(this StringBuilder target, in char separator, params T[] values)
    {
        if (target is null)
            throw new NullReferenceException();
        if (values is null || values.Length == 0)
            throw new ArgumentException("Parameters missing.");

        Contract.EndContractBlock();

        if (target.Length != 0)
            target.Append(separator);

        target.AppendAll(values);

        return target;
    }

    /// <summary>
    /// Appends a key/value pair to StringBuilder using the provided separators. <br />
    /// 将键值对附加到 StringBuilder 以提供的分隔符为前缀。
    /// </summary>
    public static void AppendWithSeparator<T>(this StringBuilder target, IDictionary<string, T> source, string key, string itemSeparator, string keyValueSeparator)
    {
        if (target is null)
            throw new NullReferenceException();
        if (source is null)
            throw new ArgumentNullException(nameof(source));
        if (key is null)
            throw new ArgumentNullException(nameof(key));
        if (itemSeparator is null)
            throw new ArgumentNullException(nameof(itemSeparator));
        if (keyValueSeparator is null)
            throw new ArgumentNullException(nameof(keyValueSeparator));

        Contract.EndContractBlock();

        if (source.TryGetValue(key, out var result))
            target
                .AppendWithSeparator(itemSeparator, key)
                .Append(keyValueSeparator)
                .Append(result);
    }

    #endregion

    #region Reverse

    /// <summary>
    /// Reverse <br />
    /// 反转字符串
    /// </summary>
    /// <param name="builder"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Reverse(this StringBuilder builder)
    {
        Strings.Reverse(builder);
    }

    /// <summary>
    /// Reverse <see cref="StringBuilder"/> <br />
    /// 反转字符串，并返回一个新的 <see cref="StringBuilder"/> 实例。
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder ReverseAndReturnNewInstance(this StringBuilder builder)
    {
        return Strings.ReverseAndReturnNewInstance(builder);
    }

    /// <summary>
    /// Reverse string <br />
    /// 反转字符串
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ReverseAndToString(this StringBuilder builder)
    {
        return Strings.ReverseAndToString(builder);
    }

    #endregion

    #region To Char Array

    /// <summary>
    /// To char array <br />
    /// 将 <see cref="StringBuilder"/> 转换为字符数组
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static char[] ToCharArray(this StringBuilder builder)
    {
        var results = new char[builder.Length];
        builder.CopyTo(0, results, 0, builder.Length);
        return results;
    }

    #endregion

    #region To StringBuilder

    /// <summary>
    /// To StringBuilder <br />
    /// 将一组只读的连续内存的值转换为 <see cref="StringBuilder"/>。
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static StringBuilder ToStringBuilder<T>(this in ReadOnlySpan<T> source)
    {
        var len = source.Length;
        var sb = new StringBuilder(len);

        for (var i = 0; i < len; i++)
            sb.Append(source[i]);

        return sb;
    }

    /// <summary>
    /// To StringBuilder <br />
    /// 将一组对象转换为 <see cref="StringBuilder"/>。
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static StringBuilder ToStringBuilder<T>(this IEnumerable<T> source)
    {
        var sb = new StringBuilder();
        foreach (var s in source)
            sb.Append(s);

        return sb;
    }

    /// <summary>
    /// To StringBuilder <br />
    /// 将一组只读的连续内存的值转换为 <see cref="StringBuilder"/>。
    /// </summary>
    /// <param name="source"></param>
    /// <param name="separator"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static StringBuilder ToStringBuilder<T>(this in ReadOnlySpan<T> source, in string separator)
    {
        var len = source.Length;
        if (len < 2 || string.IsNullOrEmpty(separator))
            return ToStringBuilder(source);

        var sb = new StringBuilder(2 * len - 1);

        sb.Append(source[0]);
        for (var i = 1; i < len; i++)
        {
            sb.Append(separator);
            sb.Append(source[i]);
        }

        return sb;
    }

    /// <summary>
    /// To StringBuilder <br />
    /// 将一组对象转换为 <see cref="StringBuilder"/>。
    /// </summary>
    /// <param name="source"></param>
    /// <param name="separator"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static StringBuilder ToStringBuilder<T>(this in ReadOnlySpan<T> source, in char separator)
    {
        var len = source.Length;
        if (len < 2)
            return ToStringBuilder(source);

        var sb = new StringBuilder(2 * len - 1);

        sb.Append(source[0]);
        for (var i = 1; i < len; i++)
        {
            sb.Append(separator);
            sb.Append(source[i]);
        }

        return sb;
    }

    /// <summary>
    /// To StringBuilder <br />
    /// 将一组对象转换为 <see cref="StringBuilder"/>。
    /// </summary>
    /// <param name="source"></param>
    /// <param name="separator"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static StringBuilder ToStringBuilder<T>(this IEnumerable<T> source, in string separator)
    {
        var sb = new StringBuilder();
        var first = true;
        foreach (var s in source)
        {
            if (first) first = false;
            else sb.Append(separator);
            sb.Append(s);
        }

        return sb;
    }

    /// <summary>
    /// To StringBuilder <br />
    /// 将一组对象转换为 <see cref="StringBuilder"/>。
    /// </summary>
    /// <param name="source"></param>
    /// <param name="separator"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static StringBuilder ToStringBuilder<T>(this IEnumerable<T> source, in char separator)
    {
        var sb = new StringBuilder();
        var first = true;
        foreach (var s in source)
        {
            if (first) first = false;
            else sb.Append(separator);
            sb.Append(s);
        }

        return sb;
    }

    #endregion
}