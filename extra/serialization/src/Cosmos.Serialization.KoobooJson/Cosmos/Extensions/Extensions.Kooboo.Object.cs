using Cosmos.Kooboo;
using Kooboo.Json;

namespace Cosmos.Extensions
{
    public static partial class Extensions
    {
        public static string ToKoobooJson<T>(this T obj)
        {
            return KoobooJsonHelper.Serialize(obj);
        }

        public static string ToKoobooJson<T>(this T obj, JsonSerializerOption option)
        {
            return KoobooJsonHelper.Serialize(obj, option);
        }
    }
}
