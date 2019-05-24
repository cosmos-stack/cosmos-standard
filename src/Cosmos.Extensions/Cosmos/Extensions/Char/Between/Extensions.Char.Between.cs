// ReSharper disable once CheckNamespace

namespace Cosmos
{
    public static partial class CharExtensions
    {
        public static bool IsBetween(this char @char, char min, char max)
        {
            var (xiao, da) = Fix(min, max);
            return @char >= xiao && @char <= da;
        }

        private static (char min, char max) Fix(char min, char max)
        {
            if (min >= max)
                return (max, min);
            return (min, max);
        }
    }
}