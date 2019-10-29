using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.Lit;

namespace Cosmos.Serialization
{
    /// <summary>
    /// LitJson Serializer
    /// </summary>
    public class LitObjectSerializer : IJsonSerializer
    {
        /// <inheritdoc />
        public string Serialize<T>(T o) => LitHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(string json) => LitHelper.Deserialize<T>(json);

        /// <inheritdoc />
        public object Deserialize(string json, Type type) => LitHelper.Deserialize(json, type);
        
        /// <inheritdoc />
        public Task<string> SerializeAsync<T>(T o)=> LitHelper.SerializeAsync(o);

        /// <inheritdoc />
        public Task<T> DeserializeAsync<T>(string data) => LitHelper.DeserializeAsync<T>(data);

        /// <inheritdoc />
        public Task<object> DeserializeAsync(string data, Type type) => LitHelper.DeserializeAsync(data, type);
    }
}