using System;
using System.IO;
using Jil;

/*
 * Reference to:
 *      Mutuduxf/Zaabee.Serializers
 *          Author: Mutuduxf
 *          Url:    https://github.com/Mutuduxf/Zaabee.Serializers
 *          MIT
 */

namespace Cosmos.Jil
{
    public static class JilHelper
    {
        public static string Serialize<T>(T o, Options options = null)
        {
            return JSON.Serialize(o, options);
        }

        public static T Deserialize<T>(string json, Options options = null)
        {
            return string.IsNullOrWhiteSpace(json) ? default(T) : JSON.Deserialize<T>(json, options);
        }

        public static object Deserialize(string json, Type type, Options options = null)
        {
            if (string.IsNullOrWhiteSpace(json))
                return null;
            using (var reader = new StringReader(json))
            {
                return Deserialize(reader, type, options);
            }
        }

        public static object Deserialize(TextReader reader, Type type, Options options = null)
        {
            return reader == null ? null : JSON.Deserialize(reader, type, options);
        }
    }
}
