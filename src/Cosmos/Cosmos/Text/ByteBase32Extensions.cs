using System.Text;
using Cosmos.Conversions;

namespace Cosmos.Text
{
    public static class ByteBase32Extensions
    {
        /// <summary>
        /// Convert normal byte normal to base32 byte array
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] ToBase32Bytes(this byte[] bytes, Encoding encoding = null)
        {
            return bytes.ToBase32String().ToBytes(encoding);
        }

        /// <summary>
        /// Convert byte[] to base32 string
        /// </summary>
        /// <param name="inArray"></param>
        /// <returns></returns>
        public static string ToBase32String(this byte[] inArray)
        {
            return Base32Conv.ToBase32String(inArray);
        }
    }
}