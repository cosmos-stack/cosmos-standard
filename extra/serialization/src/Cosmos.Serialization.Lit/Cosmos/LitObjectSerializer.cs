using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Lit;

namespace Cosmos
{
    public class LitObjectSerializer : IObjectSerializer
    {
        public string Serialize<T>(T o) => LitHelper.Serialize(o);

        public T Deserialize<T>(string json) => LitHelper.Deserialize<T>(json);

        public object Deserialize(string json, Type type) => LitHelper.Deserialize(json, type);
    }
}
