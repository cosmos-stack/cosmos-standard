using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions
    {
        public static int TotalLetters(this string text)
        {
            return text.IsNullOrEmpty() ? 0 : text.ToCharArray().FindAll(char.IsLetter).Length;
        }

        public static int TotalLowerLetters(this string text)
        {
            return text.IsNullOrEmpty() ? 0 : text.ToCharArray().FindAll(x => char.IsLetter(x) && char.IsLower(x)).Length;
        }

        public static int TotalUpperLetters(this string text)
        {
            return text.IsNullOrEmpty() ? 0 : text.ToCharArray().FindAll(x => char.IsLetter(x) && char.IsUpper(x)).Length;
        }
    }
}
