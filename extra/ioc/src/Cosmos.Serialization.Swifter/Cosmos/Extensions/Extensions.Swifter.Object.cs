using Cosmos.Swifter;
using Swifter.Json;

namespace Cosmos.Extensions
{
    public static partial class Extensions
    {
        public static string ToSwifterJson<T>(this T obj, string dateTimeFormat = null)
        {
            return SwifterHelper.Serialize(obj, dateTimeFormat);
        }

        public static string ToSwifterJson<T>(this T obj, JsonFormatterOptions options, string dateTimeFormat = null)
        {
            return SwifterHelper.Serialize(obj, options, dateTimeFormat);
        }
    }
}
