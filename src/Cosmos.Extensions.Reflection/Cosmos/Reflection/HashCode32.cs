using System;

namespace Cosmos.Reflection
{
    [Serializable]
    public struct HashCode32 : IEquatable<HashCode32>
    {
        public static readonly HashCode32 Zero = default;

        [CLSCompliant(false)]
        public HashCode32(uint hash)
        {
            UHash1 = (ushort) (hash >> 16);
            UHash2 = (ushort) (hash & 0x0000FFFF);
        }

        [CLSCompliant(false)]
        public HashCode32(ushort hash1, ushort hash2)
        {
            UHash1 = hash1;
            UHash2 = hash2;
        }

        public HashCode32(int hash)
            : this(unchecked((uint) hash)) { }

        public HashCode32(short hash1, short hash2)
            : this(unchecked((ushort) hash1), unchecked((ushort) hash2)) { }

        public short Hash1 => unchecked((short) UHash1);

        public short Hash2 => unchecked((short) UHash2);

        [CLSCompliant(false)] public ushort UHash1 { get; }

        [CLSCompliant(false)] public ushort UHash2 { get; }

        public static bool TryParse(string s, out HashCode32 result)
        {
            if (HashCodeUtil.InternalParser.TryParse(s, 32, out uint[] valColl, true) && valColl.Length == 1)
            {
                result = new HashCode32(valColl[0]);
                return true;
            }

            result = default;
            return false;
        }

        public static HashCode32 Parse(string s)
        {
            if (s is null)
                throw new ArgumentNullException(nameof(s));
            if (!TryParse(s, out var ret))
                throw new FormatException("The string did not contain a 32-digit hexadecimal number.");

            return ret;
        }

        public static bool operator ==(HashCode32 x, HashCode32 y) => x.Equals(y);

        public static bool operator !=(HashCode32 x, HashCode32 y) => !x.Equals(y);

        public bool Equals(HashCode32 other) => UHash1 == other.UHash1 && UHash2 == other.UHash2;

        // ironically not really true if you create this struct any way other than as the result
        // of a good hash operation in the first place.
        public override int GetHashCode() => unchecked((int) (UHash1 << 16 | UHash2));

        public override bool Equals(object obj) => obj is HashCode32 code32 && Equals(code32);

        public override string ToString() => AsHexString(true);

        public string AsHexString() => AsHexString(false);

        public string AsHexString(bool uppercase) => BitConverter.IsLittleEndian ? AsLittleEndianHexString(uppercase) : AsBigEndianHexString(uppercase);

        public string AsLittleEndianHexString() => AsLittleEndianHexString(false);

        public string AsLittleEndianHexString(bool uppercase)
        {
            var formatString = uppercase ? "X4" : "x4";
            return UHash1.ToString(formatString) + UHash2.ToString(formatString);
        }

        public string AsBigEndianHexString() => AsBigEndianHexString(false);

        public string AsBigEndianHexString(bool uppercase)
        {
            var formatString = uppercase ? "X4" : "x4";
            return UHash2.ToString(formatString) + UHash1.ToString(formatString);
        }
    }
}