using System.Threading;

namespace Cosmos {
    /// <summary>
    /// Interlocked util
    /// </summary>
    public static class InterlockedUtil {
        /// <summary>
        /// Read
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Read(ref int value) {
            return Interlocked.CompareExchange(ref value, 0, 0);
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Read<T>(ref T value) where T : class {
            return Interlocked.CompareExchange(ref value, null, null);
        }
    }
}