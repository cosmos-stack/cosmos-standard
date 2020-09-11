using System;
using System.Linq;

namespace Cosmos.Text
{
    public static class StringFilters
    {
        /// <summary>
        /// Filter chars
        /// </summary>
        /// <param name="text"></param>
        /// <param name="onlyThesePredicate"></param>
        /// <returns></returns>
        public static string FilterChars(string text, Func<char, bool> onlyThesePredicate)
        {
            return text.ToCharArray().Where(onlyThesePredicate).ToArray().ToString();
        }
    }
}