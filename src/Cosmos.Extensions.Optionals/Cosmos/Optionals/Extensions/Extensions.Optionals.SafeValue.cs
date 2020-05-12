using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos.Optionals {
    /// <summary>
    /// Optionals extensions
    /// </summary>
    public static partial class OptionalsExtensions {
        /// <summary>
        /// Return a safe value<br />
        /// 安全返回值
        /// </summary>
        /// <param name="value"> 可空值 </param>
        public static T SafeValue<T>(this T? value) where T : struct => value.GetValueOrDefault();

        /// <summary>
        /// Return a safe value<br />
        /// 安全返回值
        /// <para>如果可空值真为空，则返回默认值</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T SafeValue<T>(this T? value, T defaultValue) where T : struct => value.GetValueOrDefault(defaultValue);

        /// <summary>
        /// Return a safe <see cref="string"/> value.
        /// 获取 Null安全 的字符串
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static string SafeValue(this string @string) => (@string ?? string.Empty).Trim();
        
        /// <summary>
        /// Return a safe <see cref="Encoding"/> value.<br />
        /// 返回一个 <see cref="Encoding"/> 安全值。
        /// </summary>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static Encoding SafeValue(this Encoding encoding) => encoding ?? Encoding.UTF8;

        /// <summary>
        /// Return a safe <see cref="Encoding"/> value.<br />
        /// 返回一个 <see cref="Encoding"/> 安全值。
        /// </summary>
        /// <param name="encoding"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Encoding SafeValue(this Encoding encoding, Encoding defaultVal) => encoding ?? defaultVal ?? Encoding.UTF8;
    }
}