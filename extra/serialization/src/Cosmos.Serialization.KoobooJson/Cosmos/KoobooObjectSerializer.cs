using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Kooboo;

namespace Cosmos
{
    // ReSharper disable once IdentifierTypo
    public class KoobooObjectSerializer : IObjectSerializer
    {
        public string Serialize<T>(T o) => KoobooJsonHelper.Serialize(o);

        public T Deserialize<T>(string json) => KoobooJsonHelper.Deserialize<T>(json);

        public object Deserialize(string json, Type type) => KoobooJsonHelper.Deserialize(json, type);
    }
}
