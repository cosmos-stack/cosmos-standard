using System;
using Cosmos.Json;

namespace Cosmos
{
    public class JsonObjectSerializer : IObjectSerializer
    {
        public string Serialize<T>(T o) => JsonHelper.Serialize(o);

        public T Deserialize<T>(string json) => JsonHelper.Deserialize<T>(json);

        public object Deserialize(string json, Type type) => JsonHelper.Deserialize(json, type);
    }
}
