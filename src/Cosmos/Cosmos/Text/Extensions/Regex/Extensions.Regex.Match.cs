using System;
using System.Text.RegularExpressions;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    /// <summary>
    /// Regex extensons
    /// </summary>
    public static class RegexExtensions
    {
        /// <summary>
        /// Get group value
        /// </summary>
        /// <param name="match"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static string GetGroupValue(this Match match, string group)
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
}