using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.Swifter;

namespace Cosmos.Serialization {
    /// <summary>
    /// SwiftJson Serializer
    /// </summary>
    public class SwifterObjectSerializer : IJsonSerializer {
        /// <inheritdoc />
        public string Serialize<T>(T o) => SwifterHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(string json) => SwifterHelper.Deserialize<T>(json);

        /// <inheritdoc />
        public object Deserialize(string json, Type type) => SwifterHelper.Deserialize(json, type);

        /// <inheritdoc />
        public Task<string> SerializeAsync<T>(T o) => SwifterHelper.SerializeAsync(o);

        /// <inheritdoc />
        public Task<T> DeserializeAsync<T>(string data) => SwifterHelper.DeserializeAsync<T>(data);

        /// <inheritdoc />
        public Task<object> DeserializeAsync(string data, Type type) => SwifterHelper.DeserializeAsync(data, type);
    }
}