using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Xml;

namespace Cosmos
{
    /// <summary>
    /// Xml Serializer
    /// </summary>
    public class XmlObjectSerializer : IObjectSerializer
    {
        /// <inheritdoc />
        public string Serialize<T>(T o) => XmlHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(string json) => XmlHelper.Deserialize<T>(json);

        /// <inheritdoc />
        public object Deserialize(string json, Type type) => XmlHelper.Deserialize(json, type);
    }
}