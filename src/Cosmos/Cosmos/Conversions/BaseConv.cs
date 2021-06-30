using System.Text;
using Cosmos.Text.Internal;

namespace Cosmos.Conversions
{
    /// <summary>
    /// BASE Conv
    /// </summary>
    public static class BaseConv
    {
        /// <summary>
        /// Convert byte array to base32.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToBase32(byte[] data)
        {
            var base32 = new Base32();
            return base32.Encode(data);
        }

        /// <summary>
        /// Convert base32 to byte array.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] FromBase32(string data)
        {
            var base32 = new Base32();
            return base32.Decode(data);
        }

        /// <summary>
        /// Convert string to base32.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToBase32String(string data, Encoding encoding = null)
        {
            var base32 = new Base32(textEncoding: encoding);
            return base32.EncodeString(data);
        }

        /// <summary>
        /// Convert base32 to string.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string FromBase32String(string data, Encoding encoding = null)
        {
            var base32 = new Base32(textEncoding: encoding);
            return base32.DecodeToString(data);
        }

        /// <summary>
        /// Convert byte array to ZBase32.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToZBase32(byte[] data)
        {
            var base32 = new ZBase32();
            return base32.Encode(data);
        }

        /// <summary>
        /// Convert ZBase32 to byte array.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] FromZBase32(string data)
        {
            var base32 = new ZBase32();
            return base32.Decode(data);
        }

        /// <summary>
        /// Convert string to ZBase32.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToZBase32String(string data, Encoding encoding = null)
        {
            var base32 = new ZBase32(textEncoding: encoding);
            return base32.EncodeString(data);
        }

        /// <summary>
        /// Convert ZBase32 to string.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string FromZBase32String(string data, Encoding encoding = null)
        {
            var base32 = new ZBase32(textEncoding: encoding);
            return base32.DecodeToString(data);
        }

        /// <summary>
        /// Convert byte array to base64.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToBase64(byte[] data)
        {
            var base64 = new Base64();
            return base64.Encode(data);
        }

        /// <summary>
        /// Convert base64 to byte array.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] FromBase64(string data)
        {
            var base64 = new Base64();
            return base64.Decode(data);
        }

        /// <summary>
        /// Convert string to base64.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToBase64String(string data, Encoding encoding = null)
        {
            var base64 = new Base64(textEncoding: encoding);
            return base64.EncodeString(data);
        }

        /// <summary>
        /// Convert base64 to string.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string FromBase64String(string data, Encoding encoding = null)
        {
            var base64 = new Base64(textEncoding: encoding);
            return base64.DecodeToString(data);
        }

        /// <summary>
        /// Convert byte array to base91.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToBase91(byte[] data)
        {
            var base91 = new Base91();
            return base91.Encode(data);
        }

        /// <summary>
        /// Convert base91 to byte array.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] FromBase91(string data)
        {
            var base91 = new Base91();
            return base91.Decode(data);
        }

        /// <summary>
        /// Convert string to base91.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToBase91String(string data, Encoding encoding = null)
        {
            var base91 = new Base91(textEncoding: encoding);
            return base91.EncodeString(data);
        }

        /// <summary>
        /// Convert base91 to string.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string FromBase91String(string data, Encoding encoding = null)
        {
            var base91 = new Base91(textEncoding: encoding);
            return base91.DecodeToString(data);
        }

        /// <summary>
        /// Convert byte array to base256.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToBase256(byte[] data)
        {
            var base256 = new Base256();
            return base256.Encode(data);
        }

        /// <summary>
        /// Convert base256 to byte array.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] FromBase256(string data)
        {
            var base256 = new Base256();
            return base256.Decode(data);
        }

        /// <summary>
        /// Convert string to base256.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToBase256String(string data, Encoding encoding = null)
        {
            var base256 = new Base256(textEncoding: encoding);
            return base256.EncodeString(data);
        }

        /// <summary>
        /// Convert base256 to string.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string FromBase256String(string data, Encoding encoding = null)
        {
            var base256 = new Base256(textEncoding: encoding);
            return base256.DecodeToString(data);
        }
    }

    /// <summary>
    /// BASE Conv extensions.
    /// </summary>
    public static class BaseConvExtensions
    {
        /// <summary>
        /// Convert byte array to base32.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToBase32String(this byte[] data)
        {
            return BaseConv.ToBase32(data);
        }

        /// <summary>
        /// Convert string to base32.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToBase32String(this string data, Encoding encoding = null)
        {
            return BaseConv.ToBase32String(data, encoding);
        }

        /// <summary>
        /// Convert string to base32.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string FromBase32String(this string data, Encoding encoding = null)
        {
            return BaseConv.FromBase32String(data, encoding);
        }

        /// <summary>
        /// Convert byte array to ZBase32.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToZBase32String(this byte[] data)
        {
            return BaseConv.ToZBase32(data);
        }

        /// <summary>
        /// Convert string to ZBase32.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToZBase32String(this string data, Encoding encoding = null)
        {
            return BaseConv.ToZBase32String(data, encoding);
        }

        /// <summary>
        /// Convert ZBase32 to string.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string FromZBase32String(this string data, Encoding encoding = null)
        {
            return BaseConv.FromZBase32String(data, encoding);
        }

        /// <summary>
        /// Convert byte array to base64.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToBase64String(this byte[] data)
        {
            return BaseConv.ToBase64(data);
        }

        /// <summary>
        /// Convert string to base64.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToBase64String(this string data, Encoding encoding = null)
        {
            return BaseConv.ToBase64String(data, encoding);
        }

        /// <summary>
        /// Convert base64 to string.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string FromBase64String(this string data, Encoding encoding = null)
        {
            return BaseConv.FromBase64String(data, encoding);
        }

        /// <summary>
        /// Convert byte array to base91.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToBase91String(this byte[] data)
        {
            return BaseConv.ToBase91(data);
        }

        /// <summary>
        /// Convert string to base91.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToBase91String(this string data, Encoding encoding = null)
        {
            return BaseConv.ToBase91String(data, encoding);
        }

        /// <summary>
        /// Convert base91 to string.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string FromBase91String(this string data, Encoding encoding = null)
        {
            return BaseConv.FromBase91String(data, encoding);
        }

        /// <summary>
        /// Convert byte array to base256.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToBase256String(this byte[] data)
        {
            return BaseConv.ToBase256(data);
        }

        /// <summary>
        /// Convert string to base256.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToBase256String(this string data, Encoding encoding = null)
        {
            return BaseConv.ToBase256String(data, encoding);
        }

        /// <summary>
        /// Convert base256 to string.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string FromBase256String(this string data, Encoding encoding = null)
        {
            return BaseConv.FromBase256String(data, encoding);
        }
    }
}