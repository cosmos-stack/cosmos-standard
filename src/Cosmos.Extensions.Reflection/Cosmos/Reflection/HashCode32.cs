﻿using System;
using System.Collections;
using System.Text;
using Cosmos.Conversions;
using Cosmos.Optionals;

namespace Cosmos.Reflection
{
    [Serializable]
    public struct HashCode32 : IEquatable<HashCode32>, IHashCode
    {
        public static readonly HashCode32 Zero = default;

        public int BitLength => 32;

        
        public HashCode32(uint hash)
        {
            UHash1 = (ushort) (hash >> 16);
            UHash2 = (ushort) (hash & 0x0000FFFF);

            HasCreatedByteArray = false;
            Hash = null;
        }

        
        public HashCode32(ushort hash1, ushort hash2)
        {
            UHash1 = hash1;
            UHash2 = hash2;

            HasCreatedByteArray = false;
            Hash = null;
        }

        public HashCode32(int hash)
            : this(unchecked((uint) hash)) { }

        public HashCode32(short hash1, short hash2)
            : this(unchecked((ushort) hash1), unchecked((ushort) hash2)) { }

        public short Hash1 => unchecked((short) UHash1);

        public short Hash2 => unchecked((short) UHash2);

         public ushort UHash1 { get; }

         public ushort UHash2 { get; }

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

        public static bool TryParseLoosely(string s, out HashCode32 result)
        {
            if (HashCodeUtil.InternalParser.TryParse(s, 32, out uint[] valColl, false) && valColl.Length == 1)
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

        public static HashCode32 ParseLoosely(string s)
        {
            if (s is null)
                throw new ArgumentNullException(nameof(s));
            if (!TryParseLoosely(s, out var ret))
                throw new FormatException("The string did not contain a 32-digit hexadecimal number.");

            return ret;
        }

        public static bool operator ==(HashCode32 x, HashCode32 y) => x.Equals(y);

        public static bool operator !=(HashCode32 x, HashCode32 y) => !x.Equals(y);

        public bool Equals(HashCode32 other) => UHash1 == other.UHash1 && UHash2 == other.UHash2;

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

        public override bool Equals(object obj) => obj is HashCode32 code32 && Equals(code32);

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
            var formatString = uppercase ? "X4" : "x4";
            return UHash1.ToString(formatString) + UHash2.ToString(formatString);
        }

        public string GetBigEndianHexString() => GetBigEndianHexString(false);

        public string GetBigEndianHexString(bool uppercase)
        {
            var formatString = uppercase ? "X4" : "x4";
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

            if (complementZero == false || result.Length == 32)
                return result;

            return result.PadLeft(32, '0');
        }

        private string GetBinStringFragments(ushort hashVal, bool firstFlag)
        {
            var fragment = ScaleConv.HexToBin(hashVal.ToString("x4"));

            if (firstFlag || fragment.Length == 16)
                return fragment;

            return fragment.PadLeft(16, '0');
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
                Hash = HashCodeUtil.InternalByteArrayConverter.ToBytes(32, UHash1, UHash2);
                HasCreatedByteArray = true;
            }
        }

        public byte[] GetByteArray()
        {
            CreateByteArray();
            var ret = new byte[32];
            Array.Copy(Hash, 0, ret, 0, 32);
            return ret;
        }

        #endregion

        #region AsBitArray

        public BitArray GetBitArray()
        {
            return new(GetByteArray()) {Length = 32};
        }

        #endregion
    }
}