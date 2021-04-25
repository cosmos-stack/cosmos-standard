﻿using System;
using System.Collections;
using System.Text;
using Cosmos.Conversions;
using Cosmos.Optionals;

namespace Cosmos.Reflection
{
    [Serializable]
    public struct HashCode64 : IEquatable<HashCode64>, IHashCode
    {
        public static readonly HashCode64 Zero = default;

        public int HashSizeInBits => 64;

        [CLSCompliant(false)]
        public HashCode64(ulong hash)
        {
            UHash1 = (uint) (hash >> 32);
            UHash2 = (uint) (hash & 0x00000000FFFFFFFF);

            HasCreatedByteArray = false;
            Hash = null;
        }

        [CLSCompliant(false)]
        public HashCode64(uint hash1, uint hash2)
        {
            UHash1 = hash1;
            UHash2 = hash2;

            HasCreatedByteArray = false;
            Hash = null;
        }

        public HashCode64(long hash)
            : this(unchecked((ulong) hash)) { }

        public HashCode64(int hash1, int hash2)
            : this(unchecked((uint) hash1), unchecked((uint) hash2)) { }

        public HashCode64(HashCode32 hash1, HashCode32 hash2) : this(
            unchecked(((uint) hash1.Hash1 << 16) | (ushort) hash1.Hash2),
            unchecked((uint) (hash2.Hash1 << 16) | (ushort) hash2.Hash2)) { }

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

        public static bool TryParseLoosely(string s, out HashCode64 result)
        {
            if (HashCodeUtil.InternalParser.TryParse(s, 64, out uint[] valColl, false) && valColl.Length == 2)
            {
                result = new HashCode64(valColl[0], valColl[1]);
                return true;
            }

            result = default;
            return false;
        }

        public static HashCode64 ParseLoosely(string s)
        {
            if (s is null)
                throw new ArgumentNullException(nameof(s));
            if (!TryParseLoosely(s, out var ret))
                throw new FormatException("The string did not contain a 32-digit hexadecimal number.");

            return ret;
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
            var formatString = uppercase ? "X8" : "x8";
            return UHash1.ToString(formatString) + UHash2.ToString(formatString);
        }

        public string AsBigEndianHexString() => AsBigEndianHexString(false);

        public string AsBigEndianHexString(bool uppercase)
        {
            var formatString = uppercase ? "X8" : "x8";
            return UHash2.ToString(formatString) + UHash1.ToString(formatString);
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
            var fragment2 = AsBinStringFragments(UHash2, littleEndian == false);

            var result = littleEndian
                ? $"{fragment1}{fragment2}"
                : $"{fragment2}{fragment1}";

            if (complementZero == false || result.Length == 64)
                return result;

            return result.PadLeft(64, '0');
        }

        private string AsBinStringFragments(uint hashVal, bool firstFlag)
        {
            var fragment = ScaleConv.HexToBin(hashVal.ToString("x8"));

            if (firstFlag || fragment.Length == 32)
                return fragment;

            return fragment.PadLeft(32, '0');
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
                Hash = HashCodeUtil.InternalByteArrayConverter.ToBytes(64, UHash1, UHash2);
                HasCreatedByteArray = true;
            }
        }

        public byte[] AsByteArray()
        {
            CreateByteArray();
            var ret = new byte[64];
            Array.Copy(Hash, 0, ret, 0, 64);
            return ret;
        }

        #endregion

        #region AsBitArray

        public BitArray AsBitArray()
        {
            return new(AsByteArray()) {Length = 64};
        }

        #endregion

        #region Convert to other HashCode

        public (HashCode32, HashCode32) ToHashCode32Tuple()
        {
            return (
                new HashCode32(UHash1),
                new HashCode32(UHash2)
            );
        }

        #endregion
    }
}