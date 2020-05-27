// ReSharper disable once CheckNamespace

namespace Cosmos.Optionals
{
    /// <summary>
    /// Extensions for string
    /// </summary>
    public static partial class OptionalsExtensions
    {
        /// <summary>
        /// None if empty
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Maybe<string> NoneIfEmpty(this string str) =>
            string.IsNullOrEmpty(str)
                ? Optional.None<string>()
                : Optional.Some(str);

        /// <summary>
        /// None if whitespace
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Maybe<string> NoneIfWhitespace(this string str) =>
            string.IsNullOrWhiteSpace(str)
                ? Optional.None<string>()
                : Optional.Some(str);
    }
}