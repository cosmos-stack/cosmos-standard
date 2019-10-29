using System.Text;
using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;

namespace Cosmos.Serialization.Json.Newtonsoft
{
    /// <summary>
    /// Newtonsoft Json manager
    /// </summary>
    public static class JsonManager
    {
        private static Encoding _encoding = Encoding.UTF8;

        private static JsonSerializerSettings _settings = new JsonSerializerSettings();

        private static JsonSerializerSettings _settingsWithNodaTime = new JsonSerializerSettings().ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);

        /// <summary>
        /// Gets or sets default encoding
        /// </summary>
        public static Encoding DefaultEncoding
        {
            get => _encoding;
            set => _encoding = value ?? _encoding;
        }

        /// <summary>
        /// Gets or sets default Newtonsoft Json serializer settings
        /// </summary>
        public static JsonSerializerSettings DefaultSettings
        {
            get => _settings;
            set => _settings = value ?? _settings;
        }

        /// <summary>
        /// Getsor sets default Newtonsoft Json serializer settings with NodaTime
        /// </summary>
        public static JsonSerializerSettings DefaultSettingsWithNodaTime
        {
            get => _settingsWithNodaTime;
            set => _settingsWithNodaTime = value ?? _settingsWithNodaTime;
        }
    }
}