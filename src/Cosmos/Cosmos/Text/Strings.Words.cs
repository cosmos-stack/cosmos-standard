using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Cosmos.Text
{
    internal static class StringWordHelper
    {
        /// <summary>
        /// To all capitals
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllCapitals(string input)
        {
            return input.ToCharArray().All(char.IsUpper);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string AppendEndIfNeed(string text, string appendStr, Func<bool> condition)
        {
            if (condition?.Invoke() ?? false)
                return $"{text}{appendStr}";
            return text;
        }
    }

    /// <summary>
    /// String Utils<br />
    /// 字符串工具
    /// </summary>
    public static partial class Strings
    {
        /// <summary>
        /// To capital case
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToCapitalCase( string text)
        {
            var result = new List<string>();
            foreach (var word in text.SplitByWords())
            {
                if (word.Length == 0 ||StringWordHelper.AllCapitals(word))
                    result.Add(word);
                else if (word.Length == 1)
                    result.Add(word.ToUpper());
                else
                    result.Add(char.ToUpper(word[0]) + word.Remove(0, 1).ToLower());
            }

            return string.Join(" ", result)
                         .Replace(" Y ", " y ")
                         .Replace(" De ", " de ")
                         .Replace(" O ", " o ");
        }

        /// <summary>
        /// To camel case
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToCamelCase( string text)
        {
            if (text is null)
                return string.Empty;
            if (text.Length <= 1)
                return text.ToLower();
            return char.ToLower(text[0]) + text.Substring(1);
        }
        
        /// <summary>
        /// Count by words
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CountByWords(string text)
        {
            return string.IsNullOrWhiteSpace(text) ? 0 : SplitByWords(text).Count();
        }
        
        /// <summary>
        /// Split by words
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<string> SplitByWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new string[0];
            return text.Split(' ');
        }

        /// <summary>
        /// Truncate By Words
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxNumber"></param>
        /// <param name="placeholder"></param>
        /// <param name="extraSpace">额外的空格</param>
        /// <returns></returns>
        public static string TruncateByWords(string text, int maxNumber, string placeholder = "...", bool extraSpace=false)
        {
            if (string.IsNullOrEmpty(text) || maxNumber <= 0)
                return string.Empty;
            if (string.IsNullOrEmpty(placeholder))
                placeholder = "...";
            var result = new List<string>();
            var counter = 0;
            var touchBoundary = false;
            foreach (var word in text.SplitByWords())
            {
                if (counter++ == maxNumber)
                {
                    touchBoundary = true;
                    break;
                }
                
                result.Add(word);
            }

            return StringWordHelper.AppendEndIfNeed(
                string.Join(" ", result),
                extraSpace ? $" {placeholder}" : placeholder,
                () => touchBoundary);
        }
    }

    public static partial class StringsExtensions
    {
        /// <summary>
        /// To capital case
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToCapitalCase(this string text)
        {
            return Strings.ToCapitalCase(text);
        }

        /// <summary>
        /// To camel case
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToCamelCase(this string text)
        {
            return Strings.ToCamelCase(text);
        }

        /// <summary>
        /// Count by words
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CountByWords(this string text)
        {
            return Strings.CountByWords(text);
        }
        
        /// <summary>
        /// Split by words
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<string> SplitByWords(this string text)
        {
            return Strings.SplitByWords(text);
        }

        /// <summary>
        /// Truncate By Words
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxNumber"></param>
        /// <param name="placeholder"></param>
        /// <param name="extraSpace">额外的空格</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string TruncateByWords(this string text, int maxNumber, string placeholder = "...", bool extraSpace = false)
        {
            return Strings.TruncateByWords(text, maxNumber, placeholder, extraSpace);
        }
    }
}