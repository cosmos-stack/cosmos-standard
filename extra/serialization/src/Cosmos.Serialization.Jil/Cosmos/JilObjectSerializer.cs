using System;
using Cosmos.Jil;

namespace Cosmos
{
    /// <summary>
    /// Jil serializer
    /// </summary>
    public class JilObjectSerializer : IObjectSerializer
    {
        /// <inheritdoc />
        public string Serialize<T>(T o) => JilHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(string json) => JilHelper.Deserialize<T>(json);

        /// <inheritdoc />
        public object Deserialize(string json, Type type) => JilHelper.Deserialize(json, type);
    }
}