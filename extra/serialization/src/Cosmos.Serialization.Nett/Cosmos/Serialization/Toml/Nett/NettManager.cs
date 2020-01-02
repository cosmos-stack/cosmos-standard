using System.Text;
using Nett;

namespace Cosmos.Serialization.Toml.Nett {
    /// <summary>
    /// Nett TOML manager
    /// </summary>
    public static class NettManager {
        private static Encoding _encoding = Encoding.UTF8;
        private static TomlSettings _settings = TomlSettings.Create();

        /// <summary>
        /// Gets or sets default TomlSettings
        /// </summary>
        public static TomlSettings DefaultSettings {
            get => _settings;
            set => _settings = value ?? _settings;
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