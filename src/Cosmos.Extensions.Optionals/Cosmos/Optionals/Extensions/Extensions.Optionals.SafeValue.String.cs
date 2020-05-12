// ReSharper disable once CheckNamespace
namespace Cosmos.Optionals {
    /// <summary>
    /// Optionals extensions
    /// </summary>
    public static partial class OptionalsExtensions {
        /// <summary>
        /// Return a safe <see cref="string"/> value.<br />
        /// 安全获取字符串类型
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static string SafeString(this object @object) {
            return @object switch {
                string str => str.SafeValue(),
                null       => string.Empty,
                _          => @object.ToString()
            };
        }

        /// <summary>
        /// Return a safe <see cref="string"/> value.<br />
        /// 安全获取字符串类型
        /// </summary>
        /// <param name="object"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string SafeString(this object @object, string defaultVal) {
            var @string = @object.SafeString();
            return string.IsNullOrWhiteSpace(@string) ? defaultVal : @string;
        }

        /// <summary>
        /// To remove space and return a safe <see cref="string"/> value.<br />
        /// 安全移除空白字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SafeTrim(this string str) => str?.Trim();
    }
}