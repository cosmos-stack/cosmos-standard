using System;

namespace Cosmos.Reflection
{
    [Serializable]
    public struct HashCode128 : IEquatable<HashCode128>
    {
        public static readonly HashCode128 Zero = default;

        [CLSCompliant(false)]
        public HashCode128(ulong hash1, ulong hash2)
        {
            UHash1 = hash1;
            UHash2 = hash2;
        }

        public HashCode128(long hash1, long hash2)
            : this(unchecked((ulong) hash1), unchecked((ulong) hash2)) { }

        public long Hash1 => unchecked((long) UHash1);

        public long Hash2 => unchecked((long) UHash2);

        [CLSCompliant(false)] public ulong UHash1 { get; }

        [CLSCompliant(false)] public ulong UHash2 { get; }

        public static bool TryParse(string s, out HashCode128 result)
        {
            if (HashCodeUtil.InternalParser.TryParse(s, 128, out ulong[] valColl, true) && valColl.Length == 2)
            {
                result = new HashCode128(valColl[0], valColl[1]);
                return true;
            }

            result = default;
            return false;
        }

        public static HashCode128 Parse(string s)
        {
            if (s is null)
                throw new ArgumentNullException(nameof(s));
            if (!TryParse(s, out var ret))
                throw new FormatException("The string did not contain a 32-digit hexadecimal number.");

            return ret;
        }

        public static bool operator ==(HashCode128 x, HashCode128 y) => x.Equals(y);

        public static bool operator !=(HashCode128 x, HashCode128 y) => !x.Equals(y);

        public bool Equals(HashCode128 other) => UHash1 == other.UHash1 && UHash2 == other.UHash2;

        // ironically not really true if you create this struct any way other than as the result
        // of a good hash operation in the first place.
        public override int GetHashCode() => unchecked((int) UHash1);

        public override bool Equals(object obj) => obj is HashCode128 code128 && Equals(code128);

        public override string ToString() => AsHexString(true);

        public string AsHexString() => AsHexString(false);

        public string AsHexString(bool uppercase) => BitConverter.IsLittleEndian ? AsLittleEndianHexString(uppercase) : AsBigEndianHexString(uppercase);

        public string AsLittleEndianHexString() => AsLittleEndianHexString(false);

        public string AsLittleEndianHexString(bool uppercase)
        {
            var formatString = uppercase ? "X16" : "x16";
            return UHash1.ToString(formatString) + UHash2.ToString(formatString);
        }

        public string AsBigEndianHexString() => AsBigEndianHexString(false);

        public string AsBigEndianHexString(bool uppercase)
        {
            var formatString = uppercase ? "X16" : "x16";
            return UHash2.ToString(formatString) + UHash1.ToString(formatString);
        }
    }
}