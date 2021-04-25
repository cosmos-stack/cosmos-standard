using System;
using System.Collections;
using System.Text;
using Cosmos.Conversions;
using Cosmos.Optionals;

namespace Cosmos.Reflection
{
    [Serializable]
    public struct HashCode512 : IEquatable<HashCode512>, IHashCode
    {
        public static readonly HashCode512 Zero = default;

        public int BitLength => 512;

        [CLSCompliant(false)]
        public HashCode512(ulong hash1, ulong hash2, ulong hash3, ulong hash4, ulong hash5, ulong hash6, ulong hash7, ulong hash8)
        {
            UHash1 = hash1;
            UHash2 = hash2;
            UHash3 = hash3;
            UHash4 = hash4;
            UHash5 = hash5;
            UHash6 = hash6;
            UHash7 = hash7;
            UHash8 = hash8;

            HasCreatedByteArray = false;
            Hash = null;
        }

        public HashCode512(long hash1, long hash2, long hash3, long hash4, long hash5, long hash6, long hash7, long hash8) : this(
            unchecked((ulong) hash1), unchecked((ulong) hash2), unchecked((ulong) hash3), unchecked((ulong) hash4),
            unchecked((ulong) hash5), unchecked((ulong) hash6), unchecked((ulong) hash7), unchecked((ulong) hash8)) { }

        public HashCode512(HashCode256 hash1, HashCode256 hash2) : this(
            hash1.UHash1, hash1.UHash2, hash1.UHash3, hash1.UHash4,
            hash2.UHash1, hash2.UHash2, hash2.UHash3, hash2.UHash4) { }

        public HashCode512(
            HashCode128 hash1, HashCode128 hash2, HashCode128 hash3, HashCode128 hash4) : this(
            hash1.UHash1, hash1.UHash2,
            hash2.UHash1, hash2.UHash2,
            hash3.UHash1, hash3.UHash2,
            hash4.UHash1, hash4.UHash2) { }

        public long Hash1 => unchecked((long) UHash1);

        public long Hash2 => unchecked((long) UHash2);

        public long Hash3 => unchecked((long) UHash3);

        public long Hash4 => unchecked((long) UHash4);

        public long Hash5 => unchecked((long) UHash5);

        public long Hash6 => unchecked((long) UHash6);

        public long Hash7 => unchecked((long) UHash7);

        public long Hash8 => unchecked((long) UHash8);

        [CLSCompliant(false)] public ulong UHash1 { get; }

        [CLSCompliant(false)] public ulong UHash2 { get; }

        [CLSCompliant(false)] public ulong UHash3 { get; }

        [CLSCompliant(false)] public ulong UHash4 { get; }

        [CLSCompliant(false)] public ulong UHash5 { get; }

        [CLSCompliant(false)] public ulong UHash6 { get; }

        [CLSCompliant(false)] public ulong UHash7 { get; }

        [CLSCompliant(false)] public ulong UHash8 { get; }

        public static bool TryParse(string s, out HashCode512 result)
        {
            if (HashCodeUtil.InternalParser.TryParse(s, 512, out ulong[] valColl, true) && valColl.Length == 8)
            {
                result = new HashCode512(valColl[0], valColl[1], valColl[2], valColl[3], valColl[4], valColl[5], valColl[6], valColl[7]);
                return true;
            }

            result = default;
            return false;
        }

        public static bool TryParseLoosely(string s, out HashCode512 result)
        {
            if (HashCodeUtil.InternalParser.TryParse(s, 512, out ulong[] valColl, false) && valColl.Length == 8)
            {
                result = new HashCode512(valColl[0], valColl[1], valColl[2], valColl[3], valColl[4], valColl[5], valColl[6], valColl[7]);
                return true;
            }

            result = default;
            return false;
        }

        public static HashCode512 Parse(string s)
        {
            if (s is null)
                throw new ArgumentNullException(nameof(s));
            if (!TryParse(s, out var ret))
                throw new FormatException("The string did not contain a 32-digit hexadecimal number.");

            return ret;
        }

        public static HashCode512 ParseLoosely(string s)
        {
            if (s is null)
                throw new ArgumentNullException(nameof(s));
            if (!TryParseLoosely(s, out var ret))
                throw new FormatException("The string did not contain a 32-digit hexadecimal number.");

            return ret;
        }

        public static bool operator ==(HashCode512 x, HashCode512 y) => x.Equals(y);

        public static bool operator !=(HashCode512 x, HashCode512 y) => !x.Equals(y);

        public bool Equals(HashCode512 other) =>
            UHash1 == other.UHash1 &&
            UHash2 == other.UHash2 &&
            UHash3 == other.UHash3 &&
            UHash4 == other.UHash4 &&
            UHash5 == other.UHash5 &&
            UHash6 == other.UHash6 &&
            UHash7 == other.UHash7 &&
            UHash8 == other.UHash8;

        public override int GetHashCode()
        {
            unchecked
            {
                if (UHash1 == 0 && UHash2 == 0 && UHash3 == 0 && UHash4 == 0 &&
                    UHash5 == 0 && UHash6 == 0 && UHash7 == 0 && UHash8 == 0)
                    return 0;

                var hashCode = 17;
                CreateByteArray();

                hashCode = (hashCode * 31) ^ BitLength.GetHashCode();

                // ReSharper disable once NonReadonlyMemberInGetHashCode
                foreach (var value in Hash)
                    hashCode = (hashCode * 31) ^ value.GetHashCode();

                return hashCode;
            }
        }

        public override bool Equals(object obj) => obj is HashCode512 code512 && Equals(code512);

        public override string ToString() => AsHexString(true);

        #region AsString

        public string AsString()
        {
            return AsString(Encoding.UTF8);
        }

        public string AsString(Encoding encoding)
        {
            return encoding.SafeEncodingValue().GetString(AsByteArray());
        }

        #endregion

        #region AsHexString

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
                   UHash8.ToString(formatString);
        }

        public string AsBigEndianHexString() => AsBigEndianHexString(false);

        public string AsBigEndianHexString(bool uppercase)
        {
            var formatString = uppercase ? "X16" : "x16";
            return UHash8.ToString(formatString) +
                   UHash7.ToString(formatString) +
                   UHash6.ToString(formatString) +
                   UHash5.ToString(formatString) +
                   UHash4.ToString(formatString) +
                   UHash3.ToString(formatString) +
                   UHash2.ToString(formatString) +
                   UHash1.ToString(formatString);
        }

        #endregion

        #region AsBinString

        public string AsBinString()
        {
            return AsBinString(false);
        }

        public string AsBinString(bool complementZero)
        {
            var littleEndian = BitConverter.IsLittleEndian;
            var fragment1 = AsBinStringFragments(UHash1, littleEndian == true);
            var fragment2 = AsBinStringFragments(UHash2, false);
            var fragment3 = AsBinStringFragments(UHash3, false);
            var fragment4 = AsBinStringFragments(UHash4, false);
            var fragment5 = AsBinStringFragments(UHash5, false);
            var fragment6 = AsBinStringFragments(UHash6, false);
            var fragment7 = AsBinStringFragments(UHash7, false);
            var fragment8 = AsBinStringFragments(UHash8, littleEndian == false);

            var result = littleEndian
                ? $"{fragment1}{fragment2}{fragment3}{fragment4}{fragment5}{fragment6}{fragment7}{fragment8}"
                : $"{fragment8}{fragment7}{fragment6}{fragment5}{fragment4}{fragment3}{fragment2}{fragment1}";

            if (complementZero == false || result.Length == 512)
                return result;

            return result.PadLeft(512, '0');
        }

        private string AsBinStringFragments(ulong hashVal, bool firstFlag)
        {
            var fragment = ScaleConv.HexToBin(hashVal.ToString("x16"));

            if (firstFlag || fragment.Length == 64)
                return fragment;

            return fragment.PadLeft(64, '0');
        }

        #endregion

        #region AsBase64Sting

        public string AsBase64String()
        {
            return BaseConv.ToBase64(AsByteArray());
        }

        #endregion

        #region AsByteArray

        private bool HasCreatedByteArray { get; set; }
        private byte[] Hash { get; set; }

        private void CreateByteArray()
        {
            if (!HasCreatedByteArray)
            {
                Hash = HashCodeUtil.InternalByteArrayConverter.ToBytes(512, UHash1, UHash2, UHash3, UHash4, UHash5, UHash6, UHash7, UHash8);
                HasCreatedByteArray = true;
            }
        }

        public byte[] AsByteArray()
        {
            CreateByteArray();
            var ret = new byte[512];
            Array.Copy(Hash, 0, ret, 0, 512);
            return ret;
        }

        #endregion

        #region AsBitArray

        public BitArray AsBitArray()
        {
            return new(AsByteArray()) {Length = 512};
        }

        #endregion

        #region Convert to other HashCode

        public (HashCode128, HashCode128, HashCode128, HashCode128) ToHashCode128Tuple()
        {
            return (
                new HashCode128(UHash1, UHash2),
                new HashCode128(UHash3, UHash4),
                new HashCode128(UHash5, UHash6),
                new HashCode128(UHash7, UHash8)
            );
        }

        public (HashCode256, HashCode256) ToHashCode256Tuple()
        {
            return (
                new HashCode256(UHash1, UHash2, UHash3, UHash4),
                new HashCode256(UHash5, UHash6, UHash7, UHash8)
            );
        }

        public (HashCode64, HashCode64, HashCode64, HashCode64, HashCode64, HashCode64, HashCode64, HashCode64) ToHashCode64Tuple()
        {
            return (
                new HashCode64(UHash1),
                new HashCode64(UHash2),
                new HashCode64(UHash3),
                new HashCode64(UHash4),
                new HashCode64(UHash5),
                new HashCode64(UHash6),
                new HashCode64(UHash7),
                new HashCode64(UHash8)
            );
        }

        #endregion
    }
}