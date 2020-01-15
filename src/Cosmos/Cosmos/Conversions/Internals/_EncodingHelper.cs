using System.Text;

namespace Cosmos.Conversions.Internals {
    /// <summary>
    /// Encoding helper
    /// </summary>
    internal static class EncodingHelper {
        public static Encoding Fixed(this Encoding encoding) {
            return encoding ?? Encoding.UTF8;
        }
    }
}