using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Toml.Nett;

namespace Cosmos.Serialization {
    /// <summary>
    /// Nett TOML Serializer
    /// </summary>
    public class NettSerializer : ITomlSerializer {

        /// <inheritdoc />
        public string Serialize<T>(T o) => NettHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(string data) => NettHelper.Deserialize<T>(data);

        /// <inheritdoc />
        public object Deserialize(string data, Type type) => NettHelper.Deserialize(data, type);

        /// <inheritdoc />
        public Task<string> SerializeAsync<T>(T o) => NettHelper.SerializeAsync(o);

        /// <inheritdoc />
        public Task<T> DeserializeAsync<T>(string data) => NettHelper.DeserializeAsync<T>(data);

        /// <inheritdoc />
        public Task<object> DeserializeAsync(string data, Type type) => NettHelper.DeserializeAsync(data, type);
    }
}