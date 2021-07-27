using System.Runtime.CompilerServices;
using Cosmos.Conversions.Helpers;

namespace Cosmos.Conversions
{
    /// <summary>
    /// Bin utilities.
    /// </summary>
    public static class Bin
    {
        /// <summary>
        /// Reverse high and low positions.
        /// </summary>
        /// <param name="bin"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Reverse(string bin)
        {
            return ScaleRevHelper.Reverse(bin, 8);
        }
    }
}