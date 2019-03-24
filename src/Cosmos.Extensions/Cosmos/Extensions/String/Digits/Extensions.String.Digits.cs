using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions
    {
        public static string OnlyDigits(this string text) //ver
        {
            return text.OnlyDigits(null);
        }

        public static string OnlyDigits(this string text, IEnumerable<char> exceptions)
        {
            var res = new StringBuilder();
            foreach (char car in text)
            {
                if (char.IsDigit(car) || exceptions.Contains(car))
                    res.Append(car);
            }

            return res.ToString();
        }

        public static int TotalDigits(this string text)
        {
            if (text.IsNullOrEmpty())
                return 0;

            return text.ToCharArray().FindAll(char.IsDigit).Length;
        }
    }
}
