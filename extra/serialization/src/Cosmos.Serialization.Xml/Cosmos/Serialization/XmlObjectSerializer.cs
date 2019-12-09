using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Xml;

namespace Cosmos.Serialization {
    /// <summary>
    /// Xml Serializer
    /// </summary>
    public class XmlObjectSerializer : IXmlSerializer {
        /// <inheritdoc />
        public string Serialize<T>(T o) => XmlHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(string data) => XmlHelper.Deserialize<T>(data);

        /// <inheritdoc />
        public object Deserialize(string data, Type type) => XmlHelper.Deserialize(data, type);

        /// <inheritdoc />
        public Task<string> SerializeAsync<T>(T o) => XmlHelper.SerializeAsync(o);

        /// <inheritdoc />
        public Task<T> DeserializeAsync<T>(string data) => XmlHelper.DeserializeAsync<T>(data);

        /// <inheritdoc />
        public Task<object> DeserializeAsync(string data, Type type) => XmlHelper.DeserializeAsync(data, type);
    }
}