using System;
using LitJson;

namespace Cosmos.Lit
{
    public static class LitHelper
    {
        public static string Serialize<T>(T o)
        {
            return JsonMapper.ToJson(o);
        }

        public static T Deserialize<T>(string json)
        {
            return string.IsNullOrWhiteSpace(json) ? default(T) : JsonMapper.ToObject<T>(json);
        }

        public static object Deserialize(string json, Type type)
        {
            return string.IsNullOrWhiteSpace(json) ? null : JsonMapper.ToObject(json, type);
        }
    }
}
