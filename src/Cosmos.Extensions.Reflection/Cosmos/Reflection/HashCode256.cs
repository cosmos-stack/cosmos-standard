using System;

namespace Cosmos.Reflection
{
    [Serializable]
    public struct HashCode256 : IEquatable<HashCode256>
    {
        public static readonly HashCode256 Zero = default;

        [CLSCompliant(false)]
        public HashCode256(ulong hash1, ulong hash2, ulong hash3, ulong hash4)
        {
            UHash1 = hash1;
            UHash2 = hash2;
            UHash3 = hash3;
            UHash4 = hash4;
        }

        public HashCode256(long hash1, long hash2, long hash3, long hash4)
            : this(unchecked((ulong) hash1), unchecked((ulong) hash2), unchecked((ulong) hash3), unchecked((ulong) hash4)) { }

        public HashCode256(HashCode128 hash1, HashCode128 hash2)
            : this(hash1.UHash1, hash1.UHash2, hash2.UHash1, hash2.UHash2) { }

        public long Hash1 => unchecked((long) UHash1);

        public long Hash2 => unchecked((long) UHash2);

        public long Hash3 => unchecked((long) UHash3);

        public long Hash4 => unchecked((long) UHash4);

        [CLSCompliant(false)] public ulong UHash1 { get; }

        [CLSCompliant(false)] public ulong UHash2 { get; }

        [CLSCompliant(false)] public ulong UHash3 { get; }

        [CLSCompliant(false)] public ulong UHash4 { get; }

        public static bool TryParse(string s, out HashCode256 result)
        {
            if (HashCodeUtil.InternalParser.TryParse(s, 256, out ulong[] valColl, true) && valColl.Length == 4)
            {
                result = new HashCode256(valColl[0], valColl[1], valColl[2], valColl[3]);
                return true;
            }

            result = default;
            return false;
        }

        public static HashCode256 Parse(string s)
        {
            if (s is null)
                throw new ArgumentNullException(nameof(s));
            if (!TryParse(s, out var ret))
                throw new FormatException("The string did not contain a 32-digit hexadecimal number.");

            return ret;
        }

        public static bool operator ==(HashCode256 x, HashCode256 y) => x.Equals(y);

        public static bool operator !=(HashCode256 x, HashCode256 y) => !x.Equals(y);

        public bool Equals(HashCode256 other) =>
            UHash1 == other.UHash1 &&
            UHash2 == other.UHash2 &&
            UHash3 == other.UHash3 &&
            UHash4 == other.UHash4;

        // ironically not really true if you create this struct any way other than as the result
        // of a good hash operation in the first place.
        public override int GetHashCode() => unchecked((int) UHash1);

        public override bool Equals(object obj) => obj is HashCode256 code256 && Equals(code256);
        
        public override string ToString() => AsHexString(true);

        public string AsHexString() => AsHexString(false);

        public string AsHexString(bool uppercase) => BitConverter.IsLittleEndian ? AsLittleEndianHexString(uppercase) : AsBigEndianHexString(uppercase);

        public string AsLittleEndianHexString() => AsLittleEndianHexString(false);

        public string AsLittleEndianHexString(bool uppercase)
        {
            var formatString = uppercase ? "X16" : "x16";
            return UHash1.ToString(formatString) +
                   UHash2.ToString(formatString) +
                   UHash3.ToString(formatString) +
                   UHash4.ToString(formatString);
        }

        public string AsBigEndianHexString() => AsBigEndianHexString(false);

        public string AsBigEndianHexString(bool uppercase)
        {
            var formatString = uppercase ? "X16" : "x16";
            return   UHash4.ToString(formatString) +
                     UHash3.ToString(formatString) +
                     UHash2.ToString(formatString) +
                     UHash1.ToString(formatString);
        }
        
        public (HashCode128, HashCode128) ToHashCode128Tuple()
        {
            return (
                new HashCode128(UHash1, UHash2),
                new HashCode128(UHash3, UHash4)
            );
        }
    }
}