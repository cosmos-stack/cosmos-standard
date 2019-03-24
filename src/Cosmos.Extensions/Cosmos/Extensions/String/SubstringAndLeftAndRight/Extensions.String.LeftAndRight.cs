using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class StringExtensions
    {
        public static string Right(this string text, int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Length > 0", nameof(length));
            }
            if ((length == 0) || (text == null))
            {
                return "";
            }
            var strLength = text.Length;
            return length >= strLength ? text : text.Substring(strLength - length, length);
        }

        public static string Left(this string text, int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Length > 0", nameof(length));
            }
            if ((length == 0) || (text == null))
            {
                return "";
            }
            return length >= text.Length ? text : text.Substring(0, length);
        }
    }
}
