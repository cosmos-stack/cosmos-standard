using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Xml;

namespace Cosmos
{
    public class XmlObjectSerializer : IObjectSerializer
    {
        public string Serialize<T>(T o) => XmlHelper.Serialize(o);

        public T Deserialize<T>(string json) => XmlHelper.Deserialize<T>(json);

        public object Deserialize(string json, Type type) => XmlHelper.Deserialize(json, type);
    }
}
