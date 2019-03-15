using MessagePack;

namespace Cosmos.MessagePack
{
    public static class MessagePackHelper
    {
        public static byte[] Serialize<T>(T o)
        {
            return MessagePackSerializer.Serialize(o);
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            return MessagePackSerializer.Deserialize<T>(bytes);
        }

        public static string JsonBytesToString(byte[] json)
        {
            return MessagePackSerializer.ToJson(json);
        }

        public static byte[] JsonStringToBytes(string json)
        {
            return MessagePackSerializer.FromJson(json);
        }

        public static string JsonObjectToString<T>(T o)
        {
            return MessagePackSerializer.ToJson(o);
        }

        public static byte[] JsonObjectToBytes<T>(T o)
        {
            return JsonStringToBytes(JsonObjectToString(o));
        }

        public static T JsonStringToObject<T>(string json)
        {
            return Deserialize<T>(JsonStringToBytes(json));
        }
    }
}
