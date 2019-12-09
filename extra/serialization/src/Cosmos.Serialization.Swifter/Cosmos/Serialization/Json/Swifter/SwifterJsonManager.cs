using System.Text;
using Swifter.Json;

namespace Cosmos.Serialization.Json.Swifter {
    /// <summary>
    /// SwifterJson manager
    /// </summary>
    public static class SwifterJsonManager {
        private static Encoding _encoding = Encoding.UTF8;

        private static JsonFormatterOptions _options1 = JsonFormatterOptions.Default;

        private static JsonFormatterOptions _options2 = JsonFormatterOptions.VerifiedDeserialize;

        /// <summary>
        /// Gets or sets default encoding
        /// </summary>
        public static Encoding DefaultEncoding {
            get => _encoding;
            set => _encoding = value ?? _encoding;
        }

        /// <summary>
        /// Gets or sets default json formatter options
        /// </summary>
        public static JsonFormatterOptions DefaultOptions {
            get => _options1;
            set => _options1 = value;
        }

        /// <summary>
        /// gets for sets default json deserialize formatter options
        /// </summary>
        public static JsonFormatterOptions DefaltDeserializeOptions {
            get => _options2;
            set => _options2 = value;
        }
    }
}