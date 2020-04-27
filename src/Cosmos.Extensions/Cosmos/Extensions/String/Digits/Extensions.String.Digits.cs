using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions {
        /// <summary>
        /// Only Digits
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string OnlyDigits(this string text) => text.OnlyDigits(null);

        /// <summary>
        /// Only Digits
        /// </summary>
        /// <param name="text"></param>
        /// <param name="exceptions"></param>
        /// <returns></returns>
        public static string OnlyDigits(this string text, IEnumerable<char> exceptions) {
            var res = new StringBuilder();
            foreach (var car in text) {
                if (char.IsDigit(car) || exceptions.Contains(car))
                    res.Append(car);
            }

            return res.ToString();
        }

        /// <summary>
        /// Total digits
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int TotalDigits(this string text) => text.IsNullOrEmpty() ? 0 : text.ToCharArray().FindAll(char.IsDigit).Length;
    }
}