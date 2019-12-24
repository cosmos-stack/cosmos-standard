namespace Cosmos.Optionals {
    /// <summary>
    /// Extensions for string
    /// </summary>
    public static class StringExtensions {
        /// <summary>
        /// None if empty
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Maybe<string> NoneIfEmpty(this string str) {
            return string.IsNullOrEmpty(str)
                ? Optional.None<string>()
                : Optional.Some(str);
        }

        /// <summary>
        /// None if whitespace
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Maybe<string> NoneIfWhitespace(this string str) {
            return string.IsNullOrWhiteSpace(str)
                ? Optional.None<string>()
                : Optional.Some(str);
        }
    }
}