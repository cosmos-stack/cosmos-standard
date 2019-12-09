using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.Utf8Json;

namespace Cosmos.Serialization {
    /// <summary>
    /// Utf8Json object serializer
    /// </summary>
    public class Utf8JsonObjectSerializer : IJsonSerializer {
        /// <inheritdoc />
        public string Serialize<T>(T o) => Utf8JsonHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(string json) => Utf8JsonHelper.Deserialize<T>(json);

        /// <inheritdoc />
        public object Deserialize(string json, Type type) => Utf8JsonHelper.Deserialize(json, type);

        /// <inheritdoc />
        public Task<string> SerializeAsync<T>(T o) => Utf8JsonHelper.SerializeAsync(o);

        /// <inheritdoc />
        public Task<T> DeserializeAsync<T>(string data) => Utf8JsonHelper.DeserializeAsync<T>(data);

        /// <inheritdoc />
        public Task<object> DeserializeAsync(string data, Type type) => Utf8JsonHelper.DeserializeAsync(data, type);
    }
}