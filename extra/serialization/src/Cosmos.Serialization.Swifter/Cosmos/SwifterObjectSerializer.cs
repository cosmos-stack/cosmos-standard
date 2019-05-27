using System;
using Cosmos.Swifter;

namespace Cosmos
{
    public class SwifterObjectSerializer : IObjectSerializer
    {
        public string Serialize<T>(T o) => SwifterHelper.Serialize(o);

        public T Deserialize<T>(string json) => SwifterHelper.Deserialize<T>(json);

        public object Deserialize(string json, Type type) => SwifterHelper.Deserialize(json, type);
    }
}
