using System.Text;

namespace Cosmos {
    /// <summary>
    /// Encoding helper
    /// </summary>
    public static class EncodingExtensions {
        /// <summary>
        /// Fixed
        /// </summary>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static Encoding Fixed(this Encoding encoding) {
            return encoding ?? Encoding.UTF8;
        }

        /// <summary>
        /// Fixed
        /// </summary>
        /// <param name="encoding"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Encoding Fixed(this Encoding encoding, Encoding defaultVal) {
            return encoding ?? defaultVal ?? Encoding.UTF8;
        }
    }
}