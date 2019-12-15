using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Yaml.YamlDotNet;

namespace Cosmos.Serialization {
    /// <summary>
    /// Yaml Serializer
    /// </summary>
    public class YamlSerializer : IYamlSerializer {

        /// <inheritdoc />
        public string Serialize<T>(T o) => YamlHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(string data) => YamlHelper.Deserialize<T>(data);

        /// <inheritdoc />
        public object Deserialize(string data, Type type) => YamlHelper.Deserialize(data, type);

        /// <inheritdoc />
        public Task<string> SerializeAsync<T>(T o) => YamlHelper.SerializeAsync(o);

        /// <inheritdoc />
        public Task<T> DeserializeAsync<T>(string data) => YamlHelper.DeserializeAsync<T>(data);

        /// <inheritdoc />
        public Task<object> DeserializeAsync(string data, Type type) => YamlHelper.DeserializeAsync(data, type);
    }
}