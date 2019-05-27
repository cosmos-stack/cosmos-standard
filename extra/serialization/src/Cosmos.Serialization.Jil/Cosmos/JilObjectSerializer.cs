using System;
using Cosmos.Jil;

namespace Cosmos
{
    public class JilObjectSerializer : IObjectSerializer
    {
        public string Serialize<T>(T o) => JilHelper.Serialize(o);

        public T Deserialize<T>(string json) => JilHelper.Deserialize<T>(json);

        public object Deserialize(string json, Type type) => JilHelper.Deserialize(json, type);
    }
}
