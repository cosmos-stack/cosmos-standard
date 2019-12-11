using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Cosmos.Serialization.Yaml.YamlDotNet {
    /// <summary>
    /// YamlDotNet manager
    /// </summary>
    public static class YamlManager {
        private static Encoding _encoding = Encoding.UTF8;
        private static SerializerBuilder _serializerBuilder;
        private static DeserializerBuilder _deserializerBuilder;

        static YamlManager() {
            _serializerBuilder = new SerializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance);
            _deserializerBuilder = new DeserializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance);
        }

        /// <summary>
        /// Gets or sets YamlDotNet serializer builder
        /// </summary>
        public static SerializerBuilder DefaultSerializerBuilder {
            get => _serializerBuilder;
            set => _serializerBuilder = value ?? _serializerBuilder;
        }

        /// <summary>
        /// Gets or sets YamlDotNet deserializer builder
        /// </summary>
        public static DeserializerBuilder DefaultDeserializerBuilder {
            get => _deserializerBuilder;
            set => _deserializerBuilder = value ?? _deserializerBuilder;
        }


        /// <summary>
        /// Gets default YamlDotNet serializer
        /// </summary>
        public static ISerializer DefaultSerializer {
            get => _serializerBuilder.Build();
        }

        /// <summary>
        /// Gets default YamlDotNet deserializer
        /// </summary>
        public static IDeserializer DefaultDeserializer {
            get => _deserializerBuilder.Build();
        }

        /// <summary>
        /// Gets or sets default encoding
        /// </summary>
        public static Encoding DefaultEncoding {
            get => _encoding;
            set => _encoding = value ?? _encoding;
        }
    }
}