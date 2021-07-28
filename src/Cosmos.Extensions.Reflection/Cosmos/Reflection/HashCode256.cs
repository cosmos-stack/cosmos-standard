﻿using System;
using System.Collections;
using System.Text;
using Cosmos.Conversions;
using Cosmos.Optionals;

namespace Cosmos.Reflection
{
    [Serializable]
    public struct HashCode256 : IEquatable<HashCode256>, IHashCode
    {
        public static readonly HashCode256 Zero = default;

        public int BitLength => 256;

        
        public HashCode256(ulong hash1, ulong hash2, ulong hash3, ulong hash4)
        {
            UHash1 = hash1;
            UHash2 = hash2;
            UHash3 = hash3;
            UHash4 = hash4;

            HasCreatedByteArray = false;
            Hash = null;
        }

        public HashCode256(long hash1, long hash2, long hash3, long hash4)
            : this(unchecked((ulong) hash1), unchecked((ulong) hash2), unchecked((ulong) hash3), unchecked((ulong) hash4)) { }

        public HashCode256(HashCode128 hash1, HashCode128 hash2)
            : this(hash1.UHash1, hash1.UHash2, hash2.UHash1, hash2.UHash2) { }

        public long Hash1 => unchecked((long) UHash1);

        public long Hash2 => unchecked((long) UHash2);

        public long Hash3 => unchecked((long) UHash3);

        public long Hash4 => unchecked((long) UHash4);

         public ulong UHash1 { get; }

         public ulong UHash2 { get; }

         public ulong UHash3 { get; }

         public ulong UHash4 { get; }

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

        public static bool TryParseLoosely(string s, out HashCode256 result)
        {
            if (HashCodeUtil.InternalParser.TryParse(s, 256, out ulong[] valColl, false) && valColl.Length == 4)
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

        public static HashCode256 ParseLoosely(string s)
        {
            if (s is null)
                throw new ArgumentNullException(nameof(s));
            if (!TryParseLoosely(s, out var ret))
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

        public override int GetHashCode()
        {
            unchecked
            {
                if (UHash1 == 0 && UHash2 == 0 && UHash3 == 0 && UHash4 == 0)
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

        public override bool Equals(object obj) => obj is HashCode256 code256 && Equals(code256);

        public override string ToString() => GetHexString(true);

        #region AsString

        public string GetString()
        {
            return GetString(Encoding.UTF8);
        }

        public string GetString(Encoding encoding)
        {
            return encoding.SafeEncodingValue().GetString(GetByteArray());
        }

        #endregion

        #region AsHexString

        public string GetHexString() => GetHexString(false);

        public string GetHexString(bool uppercase) => BitConverter.IsLittleEndian ? GetLittleEndianHexString(uppercase) : GetBigEndianHexString(uppercase);

        public string GetLittleEndianHexString() => GetLittleEndianHexString(false);

        public string GetLittleEndianHexString(bool uppercase)
        {
            var formatString = uppercase ? "X16" : "x16";
            return UHash1.ToString(formatString) +
                   UHash2.ToString(formatString) +
                   UHash3.ToString(formatString) +
                   UHash4.ToString(formatString);
        }

        public string GetBigEndianHexString() => GetBigEndianHexString(false);

        public string GetBigEndianHexString(bool uppercase)
        {
            var formatString = uppercase ? "X16" : "x16";
            return UHash4.ToString(formatString) +
                   UHash3.ToString(formatString) +
                   UHash2.ToString(formatString) +
                   UHash1.ToString(formatString);
        }

        #endregion

        #region AsBinString

        public string GetBinString()
        {
            return GetBinString(false);
        }

        public string GetBinString(bool complementZero)
        {
            var littleEndian = BitConverter.IsLittleEndian;
            var fragment1 = GetBinStringFragments(UHash1, littleEndian == true);
            var fragment2 = GetBinStringFragments(UHash2, false);
            var fragment3 = GetBinStringFragments(UHash3, false);
            var fragment4 = GetBinStringFragments(UHash4, littleEndian == false);

            var result = littleEndian
                ? $"{fragment1}{fragment2}{fragment3}{fragment4}"
                : $"{fragment4}{fragment3}{fragment2}{fragment1}";

            if (complementZero == false || result.Length == 256)
                return result;

            return result.PadLeft(256, '0');
        }

        private string GetBinStringFragments(ulong hashVal, bool firstFlag)
        {
            var fragment = ScaleConv.HexToBin(hashVal.ToString("x16"));

            if (firstFlag || fragment.Length == 64)
                return fragment;

            return fragment.PadLeft(64, '0');
        }

        #endregion

        #region AsBase64Sting

        public string GetBase64String()
        {
            return BaseConv.ToBase64(GetByteArray());
        }

        #endregion

        #region AsByteArray

        private bool HasCreatedByteArray { get; set; }
        private byte[] Hash { get; set; }

        private void CreateByteArray()
        {
            if (!HasCreatedByteArray)
            {
                Hash = HashCodeUtil.InternalByteArrayConverter.ToBytes(256, UHash1, UHash2, UHash3, UHash4);
                HasCreatedByteArray = true;
            }
        }

        public byte[] GetByteArray()
        {
            CreateByteArray();
            var ret = new byte[256];
            Array.Copy(Hash, 0, ret, 0, 256);
            return ret;
        }

        #endregion

        #region AsBitArray

        public BitArray GetBitArray()
        {
            return new(GetByteArray()) {Length = 256};
        }

        #endregion

        #region Convert to other HashCode

        public (HashCode128, HashCode128) ToHashCode128Tuple()
        {
            return (
                new HashCode128(UHash1, UHash2),
                new HashCode128(UHash3, UHash4)
            );
        }

        public (HashCode64, HashCode64, HashCode64, HashCode64) ToHashCode64Tuple()
        {
            return (
                new HashCode64(UHash1),
                new HashCode64(UHash2),
                new HashCode64(UHash3),
                new HashCode64(UHash4)
            );
        }

        #endregion
    }
}