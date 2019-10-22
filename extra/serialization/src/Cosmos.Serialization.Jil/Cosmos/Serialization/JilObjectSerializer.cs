using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.Jil;

namespace Cosmos.Serialization
{
    /// <summary>
    /// Jil serializer
    /// </summary>
    public class JilObjectSerializer : IObjectSerializer
    {
        /// <inheritdoc />
        public string Serialize<T>(T o) => JilHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(string json) => JilHelper.Deserialize<T>(json);

        /// <inheritdoc />
        public object Deserialize(string json, Type type) => JilHelper.Deserialize(json, type);

        /// <inheritdoc />
        public Task<string> SerializeAsync<T>(T o)=> JilHelper.SerializeAsync(o);

        /// <inheritdoc />
        public Task<T> DeserializeAsync<T>(string data) => JilHelper.DeserializeAsync<T>(data);

        /// <inheritdoc />
        public Task<object> DeserializeAsync(string data, Type type) => JilHelper.DeserializeAsync(data, type);
    }
}