// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions
    {
        public static bool IncludeLetters(this string text) //ver
        {
            return text.IncludeLetters(0);
        }

        public static bool IncludeLetters(this string text, int minCount) //ver
        {
            var count = 0;
            foreach (var car in text)
            {
                if (char.IsLetter(car))
                    count++;

                if (count >= minCount)
                    return true;
            }

            return false;
        }

    }
}
