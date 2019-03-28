using Cosmos.Kooboo;
using Kooboo.Json;

namespace Cosmos.Extensions
{
    public static partial class Extensions
    {
        public static T FromKoobooJson<T>(this string json)
        {
            return KoobooJsonHelper.Deserialize<T>(json);
        }

        public static T FromKoobooJson<T>(this string json, JsonDeserializeOption option)
        {
            return KoobooJsonHelper.Deserialize<T>(json, option);
        }
    }
}
