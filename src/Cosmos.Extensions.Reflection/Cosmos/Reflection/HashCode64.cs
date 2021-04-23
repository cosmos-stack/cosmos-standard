using System;

namespace Cosmos.Reflection
{
    [Serializable]
    public struct HashCode64 : IEquatable<HashCode64>
    {
        public static readonly HashCode64 Zero = default;

        [CLSCompliant(false)]
        public HashCode64(ulong hash)
        {
            UHash1 = (uint) (hash >> 32);
            UHash2 = (uint) (hash & 0x00000000FFFFFFFF);
        }

        [CLSCompliant(false)]
        public HashCode64(uint hash1, uint hash2)
        {
            UHash1 = hash1;
            UHash2 = hash2;
        }

        public HashCode64(long hash)
            : this(unchecked((ulong) hash)) { }

        public HashCode64(int hash1, int hash2)
            : this(unchecked((uint) hash1), unchecked((uint) hash2)) { }

        public int Hash1 => unchecked((int) UHash1);

        public int Hash2 => unchecked((int) UHash2);

        [CLSCompliant(false)] public uint UHash1 { get; }

        [CLSCompliant(false)] public uint UHash2 { get; }

        public static bool TryParse(string s, out HashCode64 result)
        {
            if (HashCodeUtil.InternalParser.TryParse(s, 64, out uint[] valColl, true) && valColl.Length == 2)
            {
                result = new HashCode64(valColl[0], valColl[1]);
                return true;
            }

            result = default;
            return false;
        }

        public static HashCode64 Parse(string s)
        {
            if (s is null)
                throw new ArgumentNullException(nameof(s));
            if (!TryParse(s, out var ret))
                throw new FormatException("The string did not contain a 32-digit hexadecimal number.");

            return ret;
        }

        public static bool operator ==(HashCode64 x, HashCode64 y) => x.Equals(y);

        public static bool operator !=(HashCode64 x, HashCode64 y) => !x.Equals(y);

        public bool Equals(HashCode64 other) => UHash1 == other.UHash1 && UHash2 == other.UHash2;

        // ironically not really true if you create this struct any way other than as the result
        // of a good hash operation in the first place.
        public override int GetHashCode() => unchecked((int) UHash1);

        public override bool Equals(object obj) => obj is HashCode64 code64 && Equals(code64);
        
        public override string ToString() => AsHexString(true);

        public string AsHexString() => AsHexString(false);

        public string AsHexString(bool uppercase) => BitConverter.IsLittleEndian ? AsLittleEndianHexString(uppercase) : AsBigEndianHexString(uppercase);

        public string AsLittleEndianHexString() => AsLittleEndianHexString(false);

        public string AsLittleEndianHexString(bool uppercase)
        {
            var formatString = uppercase ? "X8" : "x8";
            return UHash1.ToString(formatString) + UHash2.ToString(formatString);
        }

        public string AsBigEndianHexString() => AsBigEndianHexString(false);

        public string AsBigEndianHexString(bool uppercase)
        {
            var formatString = uppercase ? "X8" : "x8";
            return UHash2.ToString(formatString) + UHash1.ToString(formatString);
        }
    }
}