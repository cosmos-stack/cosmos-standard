using System;
using System.Collections.Generic;
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

namespace Cosmos.Json
{
    public static class JsonHelper
    {
        public static string Serialize<T>(T o, IEnumerable<string> serializeFields = null,
            bool toLowerCamel = false, string dateTimeFormat = null, bool withNodaTime = false)
        {
            var settings = new JsonSerializerSettings();
            settings.UseNodaTimeIfNeed(withNodaTime);
            return Serialize(o, settings, serializeFields, toLowerCamel, dateTimeFormat);
        }

        public static string Serialize<T>(T o, JsonSerializerSettings settings, IEnumerable<string> serializeFields = null,
            bool toLowerCamel = false, string dateTimeFormat = null, bool withNodaTime = false)
        {
            settings = settings ?? new JsonSerializerSettings();
            if (serializeFields != null || toLowerCamel)
                settings.ContractResolver = new JsonContractResolver(serializeFields, toLowerCamel);
            if (!string.IsNullOrWhiteSpace(dateTimeFormat))
                settings.DateFormatString = dateTimeFormat;
            settings.UseNodaTimeIfNeed(withNodaTime);
            return JsonConvert.SerializeObject(o, settings);
        }

        public static T Deserialize<T>(string json, bool withNodaTime = false)
        {
            var settings = new JsonSerializerSettings();
            settings.UseNodaTimeIfNeed(withNodaTime);
            return string.IsNullOrWhiteSpace(json) ? default(T) : JsonConvert.DeserializeObject<T>(json, settings);
        }

        public static object Deserialize(string json, Type type, bool withNodaTime = false)
        {
            var settings = new JsonSerializerSettings();
            settings.UseNodaTimeIfNeed(withNodaTime);
            return string.IsNullOrWhiteSpace(json) ? null : JsonConvert.DeserializeObject(json, settings);
        }

        public static T Deserialize<T>(string json, JsonSerializerSettings settings, bool withNodaTime = false)
        {
            settings = settings ?? new JsonSerializerSettings();
            settings.UseNodaTimeIfNeed(withNodaTime);
            return string.IsNullOrWhiteSpace(json) ? default(T) : JsonConvert.DeserializeObject<T>(json, settings);
        }

        public static object Deserialize(string json, JsonSerializerSettings settings, Type type, bool withNodaTime = false)
        {
            settings = settings ?? new JsonSerializerSettings();
            settings.UseNodaTimeIfNeed(withNodaTime);
            return string.IsNullOrWhiteSpace(json) ? null : JsonConvert.DeserializeObject(json, settings);
        }

        private static void UseNodaTimeIfNeed(this JsonSerializerSettings settings, bool withNodaTime)
        {
            if (withNodaTime)
            {
                settings.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
            }
        }
    }
}
