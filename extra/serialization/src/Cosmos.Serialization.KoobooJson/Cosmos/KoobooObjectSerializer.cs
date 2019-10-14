using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Kooboo;

namespace Cosmos
{
    /// <summary>
    /// Kooboo Serializer
    /// </summary>
    // ReSharper disable once IdentifierTypo
    public class KoobooObjectSerializer : IObjectSerializer
    {
        /// <inheritdoc />
        public string Serialize<T>(T o) => KoobooJsonHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(string json) => KoobooJsonHelper.Deserialize<T>(json);

        /// <inheritdoc />
        public object Deserialize(string json, Type type) => KoobooJsonHelper.Deserialize(json, type);
    }
}