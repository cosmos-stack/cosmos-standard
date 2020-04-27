using System;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    public static partial class StringExtensions {
        /// <summary>
        /// Equals ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string text, string toCheck) =>
            string.Equals(text, toCheck, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Equals to any ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool EqualsToAnyIgnoreCase(this string text, params string[] toCheck) =>
            toCheck != null && toCheck.Any(t => string.Equals(text, t, StringComparison.OrdinalIgnoreCase));
    }
}