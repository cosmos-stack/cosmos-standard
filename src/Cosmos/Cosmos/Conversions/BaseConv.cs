using System.Text;
using Cosmos.Text.Internal;

namespace Cosmos.Conversions
{
    public static class BaseConv
    {
        public static string ToBase32( byte[] data)
        {
            var base32 = new Base32();
            return base32.Encode(data);
        }
        
        public static  byte[] FromBase32(string data)
        {
            var base32 = new Base32();
            return base32.Decode(data);
        }
        
        public static string ToBase32String(string data, Encoding encoding = null)
        {
            var base32 = new Base32(textEncoding: encoding);
            return base32.EncodeString(data);
        }
        
        public static string FromBase32String(string data, Encoding encoding = null)
        {
            var base32 = new Base32(textEncoding: encoding);
            return base32.DecodeToString(data);
        }
        
        public static string ToZBase32( byte[] data)
        {
            var base32 = new ZBase32();
            return base32.Encode(data);
        }
        
        public static  byte[] FromZBase32(string data)
        {
            var base32 = new ZBase32();
            return base32.Decode(data);
        }
        
        public static string ToZBase32String(string data, Encoding encoding = null)
        {
            var base32 = new ZBase32(textEncoding: encoding);
            return base32.EncodeString(data);
        }
        
        public static string FromZBase32String(string data, Encoding encoding = null)
        {
            var base32 = new ZBase32(textEncoding: encoding);
            return base32.DecodeToString(data);
        }
        
        public static string ToBase64( byte[] data)
        {
            var base64 = new Base64();
            return base64.Encode(data);
        }
        
        public static  byte[] FromBase64(string data)
        {
            var base64 = new Base64();
            return base64.Decode(data);
        }
        
        public static string ToBase64String(string data, Encoding encoding = null)
        {
            var base64 = new Base64(textEncoding: encoding);
            return base64.EncodeString(data);
        }

        public static string FromBase64String(string data, Encoding encoding = null)
        {
            var base64 = new Base64(textEncoding: encoding);
            return base64.DecodeToString(data);
        }
        
        public static string ToBase91( byte[] data)
        {
            var base91 = new Base91();
            return base91.Encode(data);
        }
        
        public static  byte[] FromBase91(string data)
        {
            var base91 = new Base91();
            return base91.Decode(data);
        }
        
        public static string ToBase91String(string data, Encoding encoding = null)
        {
            var base91 = new Base91(textEncoding: encoding);
            return base91.EncodeString(data);
        }

        public static string FromBase91String(string data, Encoding encoding = null)
        {
            var base91 = new Base91(textEncoding: encoding);
            return base91.DecodeToString(data);
        }
        
        public static string ToBase256( byte[] data)
        {
            var base256 = new Base256();
            return base256.Encode(data);
        }
        
        public static  byte[] FromBase256(string data)
        {
            var base256 = new Base256();
            return base256.Decode(data);
        }
        
        public static string ToBase256String(string data, Encoding encoding = null)
        {
            var base256 = new Base256(textEncoding: encoding);
            return base256.EncodeString(data);
        }

        public static string FromBase256String(string data, Encoding encoding = null)
        {
            var base256 = new Base256(textEncoding: encoding);
            return base256.DecodeToString(data);
        }
    }
}