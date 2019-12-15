using System.Text;

namespace Cosmos.Serialization.Json.Lit {
    /// <summary>
    /// LitJson manager
    /// </summary>
    public static class LitManager {
        private static Encoding _encoding = Encoding.UTF8;

        /// <summary>
        /// Gets or sets default encoding
        /// </summary>
        public static Encoding DefaultEncoding {
            get => _encoding;
            set => _encoding = value ?? _encoding;
        }
    }
}