using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.Collections;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        /// Only Digits
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string OnlyDigits(this string text) => 
            text.OnlyDigits(null);

        /// <summary>
        /// Only Digits
        /// </summary>
        /// <param name="text"></param>
        /// <param name="exceptions"></param>
        /// <returns></returns>
        public static string OnlyDigits(this string text, IEnumerable<char> exceptions)
        {
            var res = new StringBuilder();
            foreach (var car in text)
            {
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
        public static int TotalDigits(this string text) =>
            text.IsNullOrEmpty()
                ? 0
                : text.ToCharArray().FindAll(char.IsDigit).Length;

        /// <summary>
        /// Contains only digits
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool ContainsOnlyDigits(this string text) =>
            text.All(char.IsDigit);

        /// <summary>
        /// Not Contains Digits
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool NotContainsDigits(this string text) =>
            text.All(car => !char.IsDigit(car));

        /// <summary>
        /// Contains digit
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool ContainsDigit(this string text) => 
            text.Any(char.IsDigit);

        /// <summary>
        /// Include digits
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IncludeDigits(this string text) =>
            text.IncludeDigits(0);

        /// <summary>
        /// Include digits
        /// </summary>
        /// <param name="text"></param>
        /// <param name="minCount"></param>
        /// <returns></returns>
        public static bool IncludeDigits(this string text, int minCount)
        {
            var count = 0;
            foreach (var car in text)
            {
                if (char.IsDigit(car))
                    count++;

                if (count >= minCount)
                    return true;
            }

            return false;
        }
    }
}