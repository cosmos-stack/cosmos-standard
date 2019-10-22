using System.Text;
using Kooboo.Json;

namespace Cosmos.Serialization.Json.Kooboo
{
    /// <summary>
    /// KoobooJson helper
    /// </summary>
    public static class KoobooManager
    {
        private static Encoding _encoding = Encoding.UTF8;

        private static JsonSerializerOption _option1 = new JsonSerializerOption();

        private static JsonDeserializeOption _option2 = new JsonDeserializeOption();

        /// <summary>
        /// Gets or sets default encoding
        /// </summary>
        public static Encoding DefaultEncoding
        {
            get => _encoding;
            set => _encoding = value ?? _encoding;
        }

        /// <summary>
        /// Gets or sets default json serializer options
        /// </summary>
        public static JsonSerializerOption DefaultSerializerOptions
        {
            get => _option1;
            set => _option1 = value ?? _option1;
        }

        /// <summary>
        /// Gets or sets default json deserializer options
        /// </summary>
        public static JsonDeserializeOption DefaultDeserializeOptions
        {
            get => _option2;
            set => _option2 = value ?? _option2;
        }
    }
}