using System;
using Swifter.Json;

namespace Cosmos.Swifter
{
    public static class SwifterHelper
    {
        public static string Serialize<T>(T o, string dateTimeFormat = null)
        {
            return Serialize(o, JsonFormatterOptions.Default, dateTimeFormat);
        }

        public static string Serialize<T>(T o, JsonFormatterOptions options, string dateTimeFormat = null)
        {
            var jsonFormatter = new JsonFormatter(options);
            if (!string.IsNullOrWhiteSpace(dateTimeFormat))
                jsonFormatter.SetDateTimeFormat(dateTimeFormat);
            return jsonFormatter.Serialize(o);
        }

        public static T Deserialize<T>(string json)
        {
            var jsonFormatter = new JsonFormatter();
            return string.IsNullOrWhiteSpace(json) ? default(T) : jsonFormatter.Deserialize<T>(json);
        }

        public static object Deserialize(string json, Type type)
        {
            var jsonFormatter = new JsonFormatter();
            return string.IsNullOrWhiteSpace(json) ? null : jsonFormatter.Deserialize(json, type);
        }
    }
}
