using System.Collections;
using System.Text;

namespace Cosmos.Reflection
{
    public interface IHashCode
    {
        int BitLength { get; }

        public string GetString();

        public string GetString(Encoding encoding);

        string GetHexString();

        string GetHexString(bool uppercase);

        string GetLittleEndianHexString();

        string GetLittleEndianHexString(bool uppercase);

        string GetBigEndianHexString();

        string GetBigEndianHexString(bool uppercase);

        string GetBinString();

        string GetBinString(bool complementZero);

        string GetBase64String();

        byte[] GetByteArray();

        BitArray GetBitArray();
    }
}