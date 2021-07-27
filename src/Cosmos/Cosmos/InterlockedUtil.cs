using System.Runtime.CompilerServices;
using System.Threading;

namespace Cosmos
{
    /// <summary>
    /// Interlocked util
    /// </summary>
    public static class InterlockedUtil
    {
        /// <summary>
        /// Read
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Read(ref int value) => Interlocked.CompareExchange(ref value, 0, 0);

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Read<T>(ref T value) where T : class => Interlocked.CompareExchange(ref value, null, null);
    }
}