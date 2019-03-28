using System;
using Kooboo.Json;

namespace Cosmos.Kooboo
{
    public static class KoobooJsonHelper
    {
        public static string Serialize<T>(T o)
        {
            return JsonSerializer.ToJson(o);
        }

        public static string Serialize<T>(T o, JsonSerializerOption option)
        {
            return JsonSerializer.ToJson(o, option);
        }

        public static object Deserialize(string json, Type type)
        {
            return string.IsNullOrWhiteSpace(json) ? default : JsonSerializer.ToObject(json, type);
        }

        public static object Deserialize(string json, Type type, JsonDeserializeOption option)
        {
            return string.IsNullOrWhiteSpace(json) ? default : JsonSerializer.ToObject(json, type, option);
        }

        public static T Deserialize<T>(string json)
        {
            return string.IsNullOrWhiteSpace(json) ? default : JsonSerializer.ToObject<T>(json);
        }

        public static T Deserialize<T>(string json, JsonDeserializeOption option)
        {
            return string.IsNullOrWhiteSpace(json) ? default : JsonSerializer.ToObject<T>(json, option);
        }
    }
}
