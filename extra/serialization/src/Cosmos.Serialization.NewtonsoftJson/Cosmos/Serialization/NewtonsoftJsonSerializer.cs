using System;
using System.Threading.Tasks;
using JsonHelper = Cosmos.Serialization.Json.Newtonsoft.JsonHelper;

namespace Cosmos.Serialization {
    /// <summary>
    /// Newtonsoft Json Serializer
    /// </summary>
    public class NewtonsoftJsonSerializer : IJsonSerializer {
        /// <inheritdoc />
        public string Serialize<T>(T o) => JsonHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(string json) => JsonHelper.Deserialize<T>(json);

        /// <inheritdoc />
        public object Deserialize(string json, Type type) => JsonHelper.Deserialize(json, type);

        /// <inheritdoc />
        public Task<string> SerializeAsync<T>(T o) => JsonHelper.SerializeAsync(o);

        /// <inheritdoc />
        public Task<T> DeserializeAsync<T>(string data) => JsonHelper.DeserializeAsync<T>(data);

        /// <inheritdoc />
        public Task<object> DeserializeAsync(string data, Type type) => JsonHelper.DeserializeAsync(data, type);
    }
}