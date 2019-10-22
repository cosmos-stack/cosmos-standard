using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.Kooboo;

namespace Cosmos.Serialization
{
    /// <summary>
    /// Kooboo Serializer
    /// </summary>
    // ReSharper disable once IdentifierTypo
    public class KoobooObjectSerializer : IObjectSerializer
    {
        /// <inheritdoc />
        public string Serialize<T>(T o) => KoobooJsonHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(string json) => KoobooJsonHelper.Deserialize<T>(json);

        /// <inheritdoc />
        public object Deserialize(string json, Type type) => KoobooJsonHelper.Deserialize(json, type);
        
        /// <inheritdoc />
        public Task<string> SerializeAsync<T>(T o)=> KoobooJsonHelper.SerializeAsync(o);

        /// <inheritdoc />
        public Task<T> DeserializeAsync<T>(string data) => KoobooJsonHelper.DeserializeAsync<T>(data);

        /// <inheritdoc />
        public Task<object> DeserializeAsync(string data, Type type) => KoobooJsonHelper.DeserializeAsync(data, type);
    }
}