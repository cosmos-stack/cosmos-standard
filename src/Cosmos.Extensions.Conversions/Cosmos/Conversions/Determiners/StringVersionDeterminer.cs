using System;
using System.Collections.Generic;
using Cosmos.Conversions.Common;

namespace Cosmos.Conversions.Determiners
{
    /// <summary>
    /// Internal core conversion helper from string to version
    /// </summary>
    public static class StringVersionDeterminer
    {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="versionAct"></param>
        /// <returns></returns>
        public static bool Is(string str, Action<Version> versionAct = null)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;
            var result = Version.TryParse(str, out var n);
            if (result)
                versionAct?.Invoke(n);
            return result;
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tries"></param>
        /// <param name="versionAct"></param>
        /// <returns></returns>
        public static bool Is(string str, IEnumerable<IConversionTry<string, Version>> tries, Action<Version> versionAct = null) =>
            ValueDeterminer.IsXXX(str, string.IsNullOrWhiteSpace, Is, tries, versionAct);

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Version To(string str, Version defaultVal = default)
        {
            if (string.IsNullOrWhiteSpace(str))
                return defaultVal;
            return Version.TryParse(str, out var result) ? result : defaultVal;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static Version To(string str, IEnumerable<IConversionImpl<string, Version>> impls) =>
            ValueConverter.ToXxx(str, Is, impls);
    }
}