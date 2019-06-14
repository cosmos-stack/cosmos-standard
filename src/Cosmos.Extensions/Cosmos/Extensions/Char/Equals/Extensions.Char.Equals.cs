// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class CharExtensions
    {
        /// <summary>
        /// Equals ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this char text, char toCheck)
        {
            return char.ToUpper(text) == char.ToUpper(toCheck);
        }

        /// <summary>
        /// Equals ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this char? text, char toCheck)
        {
            if (text == null)
                return false;

            return char.ToUpper(text.Value) == char.ToUpper(toCheck);
        }
    }
}
