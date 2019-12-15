using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.MicrosoftJson;

namespace Cosmos.Serialization {
    /// <summary>
    /// Microsoft System.Text.Json object serializer
    /// </summary>
    public class MicrosoftJsonObjectSerializer : IJsonSerializer {
        /// <inheritdoc />
        public string Serialize<T>(T o) => MicrosoftJsonHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(string json) => MicrosoftJsonHelper.Deserialize<T>(json);

        /// <inheritdoc />
        public object Deserialize(string json, Type type) => MicrosoftJsonHelper.Deserialize(json, type);

        /// <inheritdoc />
        public Task<string> SerializeAsync<T>(T o) => MicrosoftJsonHelper.SerializeAsync(o);

        /// <inheritdoc />
        public Task<T> DeserializeAsync<T>(string data) => MicrosoftJsonHelper.DeserializeAsync<T>(data);

        /// <inheritdoc />
        public Task<object> DeserializeAsync(string data, Type type) => MicrosoftJsonHelper.DeserializeAsync(data, type);
    }
}