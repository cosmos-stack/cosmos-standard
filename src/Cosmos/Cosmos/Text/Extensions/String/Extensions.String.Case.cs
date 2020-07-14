using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Is upper
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsUpper(this string text) => 
            text.All(ch => char.IsLetter(ch) && !char.IsLower(ch));

        /// <summary>
        /// Is lower
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsLower(this string text) =>
            text.All(ch => !char.IsLetter(ch) || !char.IsUpper(ch));

        /// <summary>
        /// To capital case
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static string ToCapitalCase(this string original)
        {
            var words = original.Split(' ');
            var result = new List<string>();
            foreach (var word in words)
            {
                if (word.Length == 0 || AllCapitals(word))
                    result.Add(word);
                else if (word.Length == 1)
                    result.Add(word.ToUpper());
                else
                    result.Add(char.ToUpper(word[0]) + word.Remove(0, 1).ToLower());
            }

            return string.Join(" ", result).Replace(" Y ", " y ")
               .Replace(" De ", " de ")
               .Replace(" O ", " o ");
        }

        /// <summary>
        /// To all capitals
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static bool AllCapitals(string input) =>
            input.ToCharArray().All(char.IsUpper);

        /// <summary>
        /// To camel case
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static string ToCamelCase(this string original)
        {
            if (original.Length <= 1)
                return original.ToLower();
            return char.ToLower(original[0]) + original.Substring(1);
        }
    }
}