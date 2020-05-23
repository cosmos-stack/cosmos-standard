using System;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    /// <summary>
    /// String determiner extensions
    /// </summary>
    public static partial class StringDeterminerExtensions
    {
        /// <summary>
        /// One Absent Char
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool OneAbsentChar(this string text, string toCheck)
        {
            //the lengths must differ by 1, and both must be greater than 1
            if (text.Length > 1 && toCheck.Length > 1 && Math.Abs(text.Length - toCheck.Length) != 1)
                return false;

            var textWithChar = text.Length > toCheck.Length ? text : toCheck;
            var textNoChar = text.Length > toCheck.Length ? toCheck : text;

            //check if it is the last
            if (IsTheLastOne(textWithChar, textNoChar))
                return textWithChar.Substring(0, textWithChar.Length - 1).EqualsIgnoreCase(textNoChar);

            for (var i = 0; i < textNoChar.Length; i++)
            {
                if (textWithChar[i] != textNoChar[i])
                {
                    //from the different char, the rest must match
                    return textWithChar.Substring(i + 1).EqualsIgnoreCase(textNoChar.Substring(i));
                }
            }

            return false;
        }

        /// <summary>
        /// To check if it is the last
        /// </summary>
        /// <returns></returns>
        private static bool IsTheLastOne(string textWithChar, string textNoChar)
        {
#if NETSTANDARD2_1
            return textWithChar[^1] != textNoChar[^1];
#else
            return textWithChar[textWithChar.Length - 1] != textNoChar[textNoChar.Length - 1];
#endif
        }
    }
}