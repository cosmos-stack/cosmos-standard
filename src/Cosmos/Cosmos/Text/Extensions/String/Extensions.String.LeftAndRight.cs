using System;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    public static partial class BaseTypeExtensions
    {
        /// <summary>
        /// Cut off from right to left.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Right(this string text, int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Length > 0", nameof(length));
            }

            if (length == 0 || text is null)
            {
                return "";
            }

            var strLength = text.Length;
            return length >= strLength ? text : text.Substring(strLength - length, length);
        }

        /// <summary>
        /// Cut off from left to right
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Left(this string text, int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Length > 0", nameof(length));
            }

            if (length == 0 || text is null)
            {
                return "";
            }

            return length >= text.Length ? text : text.Substring(0, length);
        }
    }
}