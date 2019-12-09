using System;
using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;

/*
 * Reference to:
 *      Mutuduxf/Zaabee.Serializers
 *          Author: Mutuduxf
 *          Url:    https://github.com/Mutuduxf/Zaabee.Serializers
 *          MIT
 *
 * Changed and updated by Alex LEWIS
 */

namespace Cosmos.Serialization.Json.Newtonsoft {
    /// <summary>
    /// Newtonsoft Json Helper
    /// </summary>
    public static partial class JsonHelper {
        /// <summary>
        /// Serialize to bytes
        /// </summary>
        /// <param name="o"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static byte[] SerializeToBytes(object o, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return o is null
                ? new byte[0]
                : JsonManager.DefaultEncoding.GetBytes(Serialize(o, settings, withNodaTime));
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static string Serialize(object o, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return o is null
                ? string.Empty
                : JsonConvert.SerializeObject(o, TouchSettings(settings, withNodaTime));
        }

        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T DeserializeFromBytes<T>(byte[] data, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return data is null || data.Length is 0
                ? default
                : Deserialize<T>(JsonManager.DefaultEncoding.GetString(data), settings, withNodaTime);
        }

        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static object DeserializeFromBytes(byte[] data, Type type, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return data is null || data.Length is 0
                ? default
                : Deserialize(JsonManager.DefaultEncoding.GetString(data), type, settings, withNodaTime);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string json, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return string.IsNullOrWhiteSpace(json)
                ? default
                : JsonConvert.DeserializeObject<T>(json, TouchSettings(settings, withNodaTime));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="settings"></param>
        /// <param name="type"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return string.IsNullOrWhiteSpace(json)
                ? default
                : JsonConvert.DeserializeObject(json, type, TouchSettings(settings, withNodaTime));
        }

        private static JsonSerializerSettings TouchSettings(JsonSerializerSettings settings, bool nodatime) {
            if (settings == null) {
                return nodatime
                    ? JsonManager.DefaultSettingsWithNodaTime
                    : JsonManager.DefaultSettings;
            }

            UseNodaTimeIfNeed(settings, nodatime);

            return settings;
        }

        private static void UseNodaTimeIfNeed(this JsonSerializerSettings settings, bool withNodaTime) {
            if (withNodaTime) {
                settings.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
            }
        }
    }
}