using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool Contains(this string text, string value, params string[] values)
        {
            return YieldReturnStrings().Any(text.Contains);

            IEnumerable<string> YieldReturnStrings()
            {
                yield return value;
                if (value is null)
                    yield break;
                foreach (var val in values)
                    yield return val;
            }
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="text"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        public static bool Contains(this string text, char character) => 
            text.Any(c => c == character);

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="text"></param>
        /// <param name="character"></param>
        /// <param name="characters"></param>
        /// <returns></returns>
        public static bool Contains(this string text, char character, params char[] characters)
        {
            return YieldReturnCharacters().Any(text.Contains);

            IEnumerable<char> YieldReturnCharacters()
            {
                yield return character;
                if (characters is null)
                    yield break;
                foreach (var @char in characters)
                    yield return @char;
            }
        }
    }
}