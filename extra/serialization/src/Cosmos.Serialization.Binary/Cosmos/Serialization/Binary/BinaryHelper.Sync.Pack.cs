using System.IO;

namespace Cosmos.Serialization.Binary
{
    /// <summary>
    /// Binary helper
    /// </summary>
    public static partial class BinaryHelper
    {
        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Stream Pack(object obj)
        {
            var ms = new MemoryStream();

            if (obj != null)
                Pack(obj, ms);

            return ms;
        }

        /// <summary>
        /// Pack
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        public static void Pack(object obj, Stream stream)
        {
            if (obj is null)
                return;
            BinaryManager.GetBinaryFormatter().Serialize(stream, obj);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Unpack<T>(Stream stream)
        {
            return (T) Unpack(stream);
        }

        /// <summary>
        /// Unpack
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static object Unpack(Stream stream)
        {
            if (stream is null || stream.Length is 0)
                return null;

            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;

            return BinaryManager.GetBinaryFormatter().Deserialize(stream);
        }

        private static byte[] StreamToBytes(Stream stream)
        {
            var bytes = new byte[stream.Length];

            if (stream.CanSeek && stream.Position > 0)
                stream.Seek(0, SeekOrigin.Begin);

            stream.Read(bytes, 0, bytes.Length);

            if (stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);

            return bytes;
        }
    }
}