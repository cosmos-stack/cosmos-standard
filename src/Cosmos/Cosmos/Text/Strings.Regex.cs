using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Cosmos.Text
{
    /// <summary>
    /// String Utils<br />
    /// 字符串工具
    /// </summary>
    public static partial class Strings
    {
        /// <summary>
        /// Get group value
        /// </summary>
        /// <param name="match"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static string GetGroupValue(Match match, string group)
        {
            if (match is null)
                throw new ArgumentNullException(nameof(match));

            if (string.IsNullOrWhiteSpace(group))
                throw new ArgumentNullException(nameof(group));

            var g = match.Groups[group];

            if (!match.Success || !g.Success)
                throw new InvalidOperationException($"The group ({group}) was not successfully matched on the match.");

            return g.Value;
        }
    }

    public static partial class StringsExtensions
    {
        /// <summary>
        /// Get group value
        /// </summary>
        /// <param name="match"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetGroupValue(this Match match, string group)
        {
            return Strings.GetGroupValue(match, group);
        }
    }
}