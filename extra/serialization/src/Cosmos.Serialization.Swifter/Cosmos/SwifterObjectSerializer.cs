using System;
using Cosmos.Swifter;

namespace Cosmos
{
    /// <summary>
    /// SwiftJson Serializer
    /// </summary>
    public class SwifterObjectSerializer : IObjectSerializer
    {
        /// <inheritdoc />
        public string Serialize<T>(T o) => SwifterHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(string json) => SwifterHelper.Deserialize<T>(json);

        /// <inheritdoc />
        public object Deserialize(string json, Type type) => SwifterHelper.Deserialize(json, type);
    }
}