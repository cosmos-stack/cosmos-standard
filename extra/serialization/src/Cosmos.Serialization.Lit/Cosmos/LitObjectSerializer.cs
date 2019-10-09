using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Lit;

namespace Cosmos
{
    /// <summary>
    /// LitJson Serializer
    /// </summary>
    public class LitObjectSerializer : IObjectSerializer
    {
        /// <inheritdoc />
        public string Serialize<T>(T o) => LitHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(string json) => LitHelper.Deserialize<T>(json);

        /// <inheritdoc />
        public object Deserialize(string json, Type type) => LitHelper.Deserialize(json, type);
    }
}