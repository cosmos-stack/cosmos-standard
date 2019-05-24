using System;
using Cosmos.Judgments;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class StringExtensions
    {
        public static bool Contains(this string text, string[] values)
        {
            for (var i = 0; i < values.Length; i++)
            {
                if (text.Contains(values[i]))
                    return true;
            }

            return false;
        }

        public static bool Contains(this string text, char character)
        {
            for (var i = 0; i < text.Length; i++)
            {
                if (i == character)
                    return true;
            }

            return false;
        }

        public static bool Contains(this string text, char[] characters)
        {
            for (var i = 0; i < characters.Length; i++)
            {
                if (text.Contains(characters[i]))
                    return true;
            }

            return false;
        }
    }
}
