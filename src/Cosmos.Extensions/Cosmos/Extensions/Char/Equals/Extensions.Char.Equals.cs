// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class CharExtensions
    {
        public static bool EqualsIgnoreCase(this char text, char toCheck)
        {
            return char.ToUpper(text) == char.ToUpper(toCheck);
        }

        public static bool EqualsIgnoreCase(this char? text, char toCheck)
        {
            if (text == null)
                return false;

            return char.ToUpper(text.Value) == char.ToUpper(toCheck);
        }
    }
}
