using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Yaml.SharpYaml;

namespace Cosmos.Serialization {
    /// <summary>
    /// SharpYaml Serializer
    /// </summary>
    public class SharpYamlSerializer : IYamlSerializer {

        /// <inheritdoc />
        public string Serialize<T>(T o) => SharpYamlHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(string data) => SharpYamlHelper.Deserialize<T>(data);

        /// <inheritdoc />
        public object Deserialize(string data, Type type) => SharpYamlHelper.Deserialize(data, type);

        /// <inheritdoc />
        public Task<string> SerializeAsync<T>(T o) => SharpYamlHelper.SerializeAsync(o);

        /// <inheritdoc />
        public Task<T> DeserializeAsync<T>(string data) => SharpYamlHelper.DeserializeAsync<T>(data);

        /// <inheritdoc />
        public Task<object> DeserializeAsync(string data, Type type) => SharpYamlHelper.DeserializeAsync(data, type);
    }
}