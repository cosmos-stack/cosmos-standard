using System;

namespace Cosmos.Reflection
{
    [Serializable]
    public struct HashCode1024 : IEquatable<HashCode1024>
    {
        public static readonly HashCode1024 Zero = default;

        [CLSCompliant(false)]
        public HashCode1024(
            ulong hash1, ulong hash2, ulong hash3, ulong hash4, ulong hash5, ulong hash6, ulong hash7, ulong hash8,
            ulong hash9, ulong hash10, ulong hash11, ulong hash12, ulong hash13, ulong hash14, ulong hash15, ulong hash16)
        {
            UHash1 = hash1;
            UHash2 = hash2;
            UHash3 = hash3;
            UHash4 = hash4;
            UHash5 = hash5;
            UHash6 = hash6;
            UHash7 = hash7;
            UHash8 = hash8;
            UHash9 = hash9;
            UHash10 = hash10;
            UHash11 = hash11;
            UHash12 = hash12;
            UHash13 = hash13;
            UHash14 = hash14;
            UHash15 = hash15;
            UHash16 = hash16;
        }

        public HashCode1024(
            long hash1, long hash2, long hash3, long hash4, long hash5, long hash6, long hash7, long hash8,
            long hash9, long hash10, long hash11, long hash12, long hash13, long hash14, long hash15, long hash16) : this(
            unchecked((ulong) hash1), unchecked((ulong) hash2), unchecked((ulong) hash3), unchecked((ulong) hash4),
            unchecked((ulong) hash5), unchecked((ulong) hash6), unchecked((ulong) hash7), unchecked((ulong) hash8),
            unchecked((ulong) hash9), unchecked((ulong) hash10), unchecked((ulong) hash11), unchecked((ulong) hash12),
            unchecked((ulong) hash13), unchecked((ulong) hash14), unchecked((ulong) hash15), unchecked((ulong) hash16)) { }

        public HashCode1024(HashCode512 hash1, HashCode512 hash2) : this(
            hash1.UHash1, hash1.UHash2, hash1.UHash3, hash1.UHash4, hash1.UHash5, hash1.UHash6, hash1.UHash7, hash1.UHash8,
            hash2.UHash1, hash2.UHash2, hash2.UHash3, hash2.UHash4, hash2.UHash5, hash2.UHash6, hash2.UHash7, hash2.UHash8) { }

        public HashCode1024(HashCode256 hash1, HashCode256 hash2, HashCode256 hash3, HashCode256 hash4) : this(
            hash1.UHash1, hash1.UHash2, hash1.UHash3, hash1.UHash4,
            hash2.UHash1, hash2.UHash2, hash2.UHash3, hash2.UHash4,
            hash3.UHash1, hash3.UHash2, hash3.UHash3, hash3.UHash4,
            hash4.UHash1, hash4.UHash2, hash4.UHash3, hash4.UHash4) { }

        public HashCode1024(
            HashCode128 hash1, HashCode128 hash2, HashCode128 hash3, HashCode128 hash4,
            HashCode128 hash5, HashCode128 hash6, HashCode128 hash7, HashCode128 hash8) : this(
            hash1.UHash1, hash1.UHash2,
            hash2.UHash1, hash2.UHash2,
            hash3.UHash1, hash3.UHash2,
            hash4.UHash1, hash4.UHash2,
            hash5.UHash1, hash5.UHash2,
            hash6.UHash1, hash6.UHash2,
            hash7.UHash1, hash7.UHash2,
            hash8.UHash1, hash8.UHash2) { }

        public long Hash1 => unchecked((long) UHash1);

        public long Hash2 => unchecked((long) UHash2);

        public long Hash3 => unchecked((long) UHash3);

        public long Hash4 => unchecked((long) UHash4);

        public long Hash5 => unchecked((long) UHash5);

        public long Hash6 => unchecked((long) UHash6);

        public long Hash7 => unchecked((long) UHash7);

        public long Hash8 => unchecked((long) UHash8);

        public long Hash9 => unchecked((long) UHash9);

        public long Hash10 => unchecked((long) UHash10);

        public long Hash11 => unchecked((long) UHash11);

        public long Hash12 => unchecked((long) UHash12);

        public long Hash13 => unchecked((long) UHash13);

        public long Hash14 => unchecked((long) UHash14);

        public long Hash15 => unchecked((long) UHash15);

        public long Hash16 => unchecked((long) UHash16);

        [CLSCompliant(false)] public ulong UHash1 { get; }

        [CLSCompliant(false)] public ulong UHash2 { get; }

        [CLSCompliant(false)] public ulong UHash3 { get; }

        [CLSCompliant(false)] public ulong UHash4 { get; }

        [CLSCompliant(false)] public ulong UHash5 { get; }

        [CLSCompliant(false)] public ulong UHash6 { get; }

        [CLSCompliant(false)] public ulong UHash7 { get; }

        [CLSCompliant(false)] public ulong UHash8 { get; }

        [CLSCompliant(false)] public ulong UHash9 { get; }

        [CLSCompliant(false)] public ulong UHash10 { get; }

        [CLSCompliant(false)] public ulong UHash11 { get; }

        [CLSCompliant(false)] public ulong UHash12 { get; }

        [CLSCompliant(false)] public ulong UHash13 { get; }

        [CLSCompliant(false)] public ulong UHash14 { get; }

        [CLSCompliant(false)] public ulong UHash15 { get; }

        [CLSCompliant(false)] public ulong UHash16 { get; }

        public static bool TryParse(string s, out HashCode1024 result)
        {
            if (HashCodeUtil.InternalParser.TryParse(s, 1024, out ulong[] valColl, true) && valColl.Length == 16)
            {
                result = new HashCode1024(
                    valColl[0], valColl[1], valColl[2], valColl[3],
                    valColl[4], valColl[5], valColl[6], valColl[7],
                    valColl[8], valColl[9], valColl[10], valColl[11],
                    valColl[12], valColl[13], valColl[14], valColl[15]);
                return true;
            }

            result = default;
            return false;
        }

        public static HashCode1024 Parse(string s)
        {
            if (s is null)
                throw new ArgumentNullException(nameof(s));
            if (!TryParse(s, out var ret))
                throw new FormatException("The string did not contain a 32-digit hexadecimal number.");

            return ret;
        }

        public static bool operator ==(HashCode1024 x, HashCode1024 y) => x.Equals(y);

        public static bool operator !=(HashCode1024 x, HashCode1024 y) => !x.Equals(y);

        public bool Equals(HashCode1024 other) =>
            UHash1 == other.UHash1 &&
            UHash2 == other.UHash2 &&
            UHash3 == other.UHash3 &&
            UHash4 == other.UHash4 &&
            UHash5 == other.UHash5 &&
            UHash6 == other.UHash6 &&
            UHash7 == other.UHash7 &&
            UHash8 == other.UHash8 &&
            UHash9 == other.UHash1 &&
            UHash10 == other.UHash10 &&
            UHash11 == other.UHash11 &&
            UHash12 == other.UHash12 &&
            UHash13 == other.UHash13 &&
            UHash14 == other.UHash14 &&
            UHash15 == other.UHash15 &&
            UHash16 == other.UHash16;

        // ironically not really true if you create this struct any way other than as the result
        // of a good hash operation in the first place.
        public override int GetHashCode() => unchecked((int) UHash1);

        public override bool Equals(object obj) => obj is HashCode1024 code1024 && Equals(code1024);

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
                   UHash4.ToString(formatString) +
                   UHash5.ToString(formatString) +
                   UHash6.ToString(formatString) +
                   UHash7.ToString(formatString) +
                   UHash8.ToString(formatString) +
                   UHash9.ToString(formatString) +
                   UHash10.ToString(formatString) +
                   UHash11.ToString(formatString) +
                   UHash12.ToString(formatString) +
                   UHash13.ToString(formatString) +
                   UHash14.ToString(formatString) +
                   UHash15.ToString(formatString) +
                   UHash16.ToString(formatString);
        }

        public string AsBigEndianHexString() => AsBigEndianHexString(false);

        public string AsBigEndianHexString(bool uppercase)
        {
            var formatString = uppercase ? "X16" : "x16";
            return
                UHash16.ToString(formatString) +
                UHash15.ToString(formatString) +
                UHash14.ToString(formatString) +
                UHash13.ToString(formatString) +
                UHash12.ToString(formatString) +
                UHash11.ToString(formatString) +
                UHash10.ToString(formatString) +
                UHash9.ToString(formatString) +
                UHash8.ToString(formatString) +
                UHash7.ToString(formatString) +
                UHash6.ToString(formatString) +
                UHash5.ToString(formatString) +
                UHash4.ToString(formatString) +
                UHash3.ToString(formatString) +
                UHash2.ToString(formatString) +
                UHash1.ToString(formatString);
        }

        public (HashCode128, HashCode128, HashCode128, HashCode128, HashCode128, HashCode128, HashCode128, HashCode128) ToHashCode128Tuple()
        {
            return (
                new HashCode128(UHash1, UHash2),
                new HashCode128(UHash3, UHash4),
                new HashCode128(UHash5, UHash6),
                new HashCode128(UHash7, UHash8),
                new HashCode128(UHash9, UHash10),
                new HashCode128(UHash11, UHash12),
                new HashCode128(UHash13, UHash14),
                new HashCode128(UHash15, UHash16)
            );
        }

        public (HashCode256, HashCode256, HashCode256, HashCode256) ToHashCode256Tuple()
        {
            return (
                new HashCode256(UHash1, UHash2, UHash3, UHash4),
                new HashCode256(UHash5, UHash6, UHash7, UHash8),
                new HashCode256(UHash9, UHash10, UHash11, UHash12),
                new HashCode256(UHash13, UHash14, UHash15, UHash16)
            );
        }

        public (HashCode512, HashCode512) ToHashCode512Tuple()
        {
            return (
                new HashCode512(UHash1, UHash2, UHash3, UHash4, UHash5, UHash6, UHash7, UHash8),
                new HashCode512(UHash9, UHash10, UHash11, UHash12, UHash13, UHash14, UHash15, UHash16)
            );
        }
    }
}