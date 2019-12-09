using System.Text;
using Jil;

namespace Cosmos.Serialization.Json.Jil {
    /// <summary>
    /// Jil manager
    /// </summary>
    public static class JilManager {
        private static Encoding _encoding = Encoding.UTF8;

        private static Options _options = Options.Default;

        /// <summary>
        /// Gets or sets default encoding
        /// </summary>
        public static Encoding DefaultEncoding {
            get => _encoding;
            set => _encoding = value ?? _encoding;
        }


        /// <summary>
        /// Gets or sets default JilOptions
        /// </summary>
        public static Options DefaultOptions {
            get => _options;
            set => _options = value ?? _options;
        }
    }
}