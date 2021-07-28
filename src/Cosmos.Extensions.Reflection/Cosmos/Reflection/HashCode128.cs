﻿using System;
using System.Collections;
using System.Text;
using Cosmos.Conversions;
using Cosmos.Optionals;

namespace Cosmos.Reflection
{
    [Serializable]
    public struct HashCode128 : IEquatable<HashCode128>, IHashCode
    {
        public static readonly HashCode128 Zero = default;

        public int BitLength => 128;

        
        public HashCode128(ulong hash1, ulong hash2)
        {
            UHash1 = hash1;
            UHash2 = hash2;

            HasCreatedByteArray = false;
            Hash = null;
        }

        public HashCode128(long hash1, long hash2)
            : this(unchecked((ulong) hash1), unchecked((ulong) hash2)) { }

        public long Hash1 => unchecked((long) UHash1);

        public long Hash2 => unchecked((long) UHash2);

         public ulong UHash1 { get; }

         public ulong UHash2 { get; }

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

        public static bool TryParseLoosely(string s, out HashCode128 result)
        {
            if (HashCodeUtil.InternalParser.TryParse(s, 128, out ulong[] valColl, false) && valColl.Length == 2)
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

        public static HashCode128 ParseLoosely(string s)
        {
            if (s is null)
                throw new ArgumentNullException(nameof(s));
            if (!TryParseLoosely(s, out var ret))
                throw new FormatException("The string did not contain a 32-digit hexadecimal number.");

            return ret;
        }

        public static bool operator ==(HashCode128 x, HashCode128 y) => x.Equals(y);

        public static bool operator !=(HashCode128 x, HashCode128 y) => !x.Equals(y);

        public bool Equals(HashCode128 other) => UHash1 == other.UHash1 && UHash2 == other.UHash2;

        public override int GetHashCode()
        {
            unchecked
            {
                if (UHash1 == 0 && UHash2 == 0)
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

        public override bool Equals(object obj) => obj is HashCode128 code128 && Equals(code128);

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
            return UHash1.ToString(formatString) + UHash2.ToString(formatString);
        }

        public string GetBigEndianHexString() => GetBigEndianHexString(false);

        public string GetBigEndianHexString(bool uppercase)
        {
            var formatString = uppercase ? "X16" : "x16";
            return UHash2.ToString(formatString) + UHash1.ToString(formatString);
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
            var fragment2 = GetBinStringFragments(UHash2, littleEndian == false);

            var result = littleEndian
                ? $"{fragment1}{fragment2}"
                : $"{fragment2}{fragment1}";

            if (complementZero == false || result.Length == 128)
                return result;

            return result.PadLeft(128, '0');
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
                Hash = HashCodeUtil.InternalByteArrayConverter.ToBytes(128, UHash1, UHash2);
                HasCreatedByteArray = true;
            }
        }

        public byte[] GetByteArray()
        {
            CreateByteArray();
            var ret = new byte[128];
            Array.Copy(Hash, 0, ret, 0, 128);
            return ret;
        }

        #endregion

        #region AsBitArray

        public BitArray GetBitArray()
        {
            return new(GetByteArray()) {Length = 128};
        }

        #endregion

        #region Convert to other HashCode

        public (HashCode64, HashCode64) ToHashCode64Tuple()
        {
            return (
                new HashCode64(UHash1),
                new HashCode64(UHash2)
            );
        }

        #endregion
    }
}