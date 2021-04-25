using System.Collections;
using System.Text;

namespace Cosmos.Reflection
{
    public interface IHashCode
    {
        int HashSizeInBits { get; }

        public string AsString();

        public string AsString(Encoding encoding);

        string AsHexString();

        string AsHexString(bool uppercase);

        string AsLittleEndianHexString();

        string AsLittleEndianHexString(bool uppercase);

        string AsBigEndianHexString();

        string AsBigEndianHexString(bool uppercase);

        string AsBinString();

        string AsBinString(bool complementZero);

        string AsBase64String();

        byte[] AsByteArray();

        BitArray AsBitArray();
    }
}