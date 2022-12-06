using System.Web;

namespace Cosmos.Text;

/// <summary>
/// String Utils<br />
/// 字符串工具
/// </summary>
public static partial class Strings
{
    #region As or From Url/Html Value

    public static string AsUrlValue(string value) => HttpUtility.UrlEncode(value);

    public static string AsUrlValue(string value, Encoding encoding) => HttpUtility.UrlEncode(value, encoding ?? Encoding.UTF8);

    public static string AsHtmlValue(string value) => HttpUtility.HtmlEncode(value);

    public static string FromUrlValue(string value) => HttpUtility.UrlDecode(value);

    public static string FromUrlValue(string value, Encoding encoding) => HttpUtility.UrlDecode(value, encoding ?? Encoding.UTF8);

    public static string FromHtmlValue(string value) => HttpUtility.HtmlDecode(value);

    #endregion
}

/// <summary>
/// String extensions <br />
/// 字符串扩展
/// </summary>
public static partial class StringsExtensions
{
    #region As or From Url/Html Value

    public static string AsUrlValue(this string value) => Strings.AsUrlValue(value);

    public static string AsUrlValue(this string value, Encoding encoding) => Strings.AsUrlValue(value, encoding ?? Encoding.UTF8);

    public static string AsHtmlValue(this string value) => Strings.AsHtmlValue(value);

    public static string FromUrlValue(this string value) => Strings.FromUrlValue(value);

    public static string FromUrlValue(this string value, Encoding encoding) => Strings.FromUrlValue(value, encoding ?? Encoding.UTF8);

    public static string FromHtmlValue(this string value) => Strings.FromHtmlValue(value);

    #endregion
}