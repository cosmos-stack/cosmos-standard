using System;
using Cosmos.Json;

namespace Cosmos
{
    /// <summary>
    /// Newtonsoft Json Serializer
    /// </summary>
    public class JsonObjectSerializer : IObjectSerializer
    {
        /// <inheritdoc />
        public string Serialize<T>(T o) => JsonHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(string json) => JsonHelper.Deserialize<T>(json);

        /// <inheritdoc />
        public object Deserialize(string json, Type type) => JsonHelper.Deserialize(json, type);
    }
}