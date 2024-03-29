﻿using System.Collections;
using System.Text;
using Cosmos.Conversions;
using Cosmos.Optionals;

namespace Cosmos.Reflection;

/// <summary>
/// HashCode 1024
/// </summary>
[Serializable]
public struct HashCode1024 : IEquatable<HashCode1024>, IHashCode
{
    /// <summary>
    /// Zero<br />零值
    /// </summary>
    public static readonly HashCode1024 Zero = default;

    /// <inheritdoc />
    public int BitLength => 1024;

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

        HasCreatedByteArray = false;
        Hash = null;
    }

    public HashCode1024(
        long hash1, long hash2, long hash3, long hash4, long hash5, long hash6, long hash7, long hash8,
        long hash9, long hash10, long hash11, long hash12, long hash13, long hash14, long hash15, long hash16) : this(
        unchecked((ulong)hash1), unchecked((ulong)hash2), unchecked((ulong)hash3), unchecked((ulong)hash4),
        unchecked((ulong)hash5), unchecked((ulong)hash6), unchecked((ulong)hash7), unchecked((ulong)hash8),
        unchecked((ulong)hash9), unchecked((ulong)hash10), unchecked((ulong)hash11), unchecked((ulong)hash12),
        unchecked((ulong)hash13), unchecked((ulong)hash14), unchecked((ulong)hash15), unchecked((ulong)hash16)) { }

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

    /// <summary>
    /// Hash 1
    /// </summary>
    public long Hash1 => unchecked((long)UHash1);

    /// <summary>
    /// Hash 2
    /// </summary>
    public long Hash2 => unchecked((long)UHash2);

    /// <summary>
    /// Hash 3
    /// </summary>
    public long Hash3 => unchecked((long)UHash3);

    /// <summary>
    /// Hash 4
    /// </summary>
    public long Hash4 => unchecked((long)UHash4);

    /// <summary>
    /// Hash 5
    /// </summary>
    public long Hash5 => unchecked((long)UHash5);

    /// <summary>
    /// Hash 6
    /// </summary>
    public long Hash6 => unchecked((long)UHash6);

    /// <summary>
    /// Hash 7
    /// </summary>
    public long Hash7 => unchecked((long)UHash7);

    /// <summary>
    /// Hash 8
    /// </summary>
    public long Hash8 => unchecked((long)UHash8);

    /// <summary>
    /// Hash 9
    /// </summary>
    public long Hash9 => unchecked((long)UHash9);

    /// <summary>
    /// Hash 10
    /// </summary>
    public long Hash10 => unchecked((long)UHash10);

    /// <summary>
    /// Hash 11
    /// </summary>
    public long Hash11 => unchecked((long)UHash11);

    /// <summary>
    /// Hash 12
    /// </summary>
    public long Hash12 => unchecked((long)UHash12);

    /// <summary>
    /// Hash 13
    /// </summary>
    public long Hash13 => unchecked((long)UHash13);

    /// <summary>
    /// Hash 14
    /// </summary>
    public long Hash14 => unchecked((long)UHash14);

    /// <summary>
    /// Hash 15
    /// </summary>
    public long Hash15 => unchecked((long)UHash15);

    /// <summary>
    /// Hash 16
    /// </summary>
    public long Hash16 => unchecked((long)UHash16);

    /// <summary>
    /// Hash 1 in UInt64
    /// </summary>
    public ulong UHash1 { get; }

    /// <summary>
    /// Hash 2 in UInt64
    /// </summary>
    public ulong UHash2 { get; }

    /// <summary>
    /// Hash 3 in UInt64
    /// </summary>
    public ulong UHash3 { get; }

    /// <summary>
    /// Hash 4 in UInt64
    /// </summary>
    public ulong UHash4 { get; }

    /// <summary>
    /// Hash 5 in UInt64
    /// </summary>
    public ulong UHash5 { get; }

    /// <summary>
    /// Hash 6 in UInt64
    /// </summary>
    public ulong UHash6 { get; }

    /// <summary>
    /// Hash 7 in UInt64
    /// </summary>
    public ulong UHash7 { get; }

    /// <summary>
    /// Hash 8 in UInt64
    /// </summary>
    public ulong UHash8 { get; }

    /// <summary>
    /// Hash 9 in UInt64
    /// </summary>
    public ulong UHash9 { get; }

    /// <summary>
    /// Hash 10 in UInt64
    /// </summary>
    public ulong UHash10 { get; }

    /// <summary>
    /// Hash 11 in UInt64
    /// </summary>
    public ulong UHash11 { get; }

    /// <summary>
    /// Hash 12 in UInt64
    /// </summary>
    public ulong UHash12 { get; }

    /// <summary>
    /// Hash 13 in UInt64
    /// </summary>
    public ulong UHash13 { get; }

    /// <summary>
    /// Hash 14 in UInt64
    /// </summary>
    public ulong UHash14 { get; }

    /// <summary>
    /// Hash 15 in UInt64
    /// </summary>
    public ulong UHash15 { get; }

    /// <summary>
    /// Hash 16 in UInt64
    /// </summary>
    public ulong UHash16 { get; }

    /// <summary>
    /// Try parse strictly<br />
    /// 尝试转换，严格模式
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Try parse loosely<br />
    /// 尝试转换，宽松模式
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParseLoosely(string s, out HashCode1024 result)
    {
        if (HashCodeUtil.InternalParser.TryParse(s, 1024, out ulong[] valColl, false) && valColl.Length == 16)
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

    /// <summary>
    /// Parse strictly<br />
    /// 转换，严格模式
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="FormatException"></exception>
    public static HashCode1024 Parse(string s)
    {
        if (s is null)
            throw new ArgumentNullException(nameof(s));
        if (!TryParse(s, out var ret))
            throw new FormatException("The string did not contain a 32-digit hexadecimal number.");

        return ret;
    }

    /// <summary>
    /// Parse loosely <br />
    /// 转换，宽松模式
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="FormatException"></exception>
    public static HashCode1024 ParseLoosely(string s)
    {
        if (s is null)
            throw new ArgumentNullException(nameof(s));
        if (!TryParseLoosely(s, out var ret))
            throw new FormatException("The string did not contain a 32-digit hexadecimal number.");

        return ret;
    }

    public static bool operator ==(HashCode1024 x, HashCode1024 y) => x.Equals(y);

    public static bool operator !=(HashCode1024 x, HashCode1024 y) => !x.Equals(y);

    /// <inheritdoc />
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

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            if (UHash1 == 0 && UHash2 == 0 && UHash3 == 0 && UHash4 == 0 &&
                UHash5 == 0 && UHash6 == 0 && UHash7 == 0 && UHash8 == 0 &&
                UHash9 == 0 && UHash10 == 0 && UHash11 == 0 && UHash12 == 0 &&
                UHash13 == 0 && UHash14 == 0 && UHash15 == 0 && UHash16 == 0)
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

    /// <inheritdoc />
    public override bool Equals(object obj) => obj is HashCode1024 code1024 && Equals(code1024);

    /// <inheritdoc />
    public override string ToString() => GetHexString(true);

    #region AsString

    /// <inheritdoc />
    public string GetString()
    {
        return GetString(Encoding.UTF8);
    }

    /// <inheritdoc />
    public string GetString(Encoding encoding)
    {
        return encoding.SafeEncodingValue().GetString(GetByteArray());
    }

    #endregion

    #region AsHexString

    /// <inheritdoc />
    public string GetHexString() => GetHexString(false);

    /// <inheritdoc />
    public string GetHexString(bool uppercase) => BitConverter.IsLittleEndian ? GetLittleEndianHexString(uppercase) : GetBigEndianHexString(uppercase);

    /// <inheritdoc />
    public string GetLittleEndianHexString() => GetLittleEndianHexString(false);

    /// <inheritdoc />
    public string GetLittleEndianHexString(bool uppercase)
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

    /// <inheritdoc />
    public string GetBigEndianHexString() => GetBigEndianHexString(false);

    /// <inheritdoc />
    public string GetBigEndianHexString(bool uppercase)
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

    #endregion

    #region AsBinString

    /// <inheritdoc />
    public string GetBinString()
    {
        return GetBinString(false);
    }

    /// <inheritdoc />
    public string GetBinString(bool complementZero)
    {
        var littleEndian = BitConverter.IsLittleEndian;
        var fragment1 = GetBinStringFragments(UHash1, littleEndian == true);
        var fragment2 = GetBinStringFragments(UHash2, false);
        var fragment3 = GetBinStringFragments(UHash3, false);
        var fragment4 = GetBinStringFragments(UHash4, false);
        var fragment5 = GetBinStringFragments(UHash5, false);
        var fragment6 = GetBinStringFragments(UHash6, false);
        var fragment7 = GetBinStringFragments(UHash7, false);
        var fragment8 = GetBinStringFragments(UHash8, false);
        var fragment9 = GetBinStringFragments(UHash9, false);
        var fragment10 = GetBinStringFragments(UHash10, false);
        var fragment11 = GetBinStringFragments(UHash11, false);
        var fragment12 = GetBinStringFragments(UHash12, false);
        var fragment13 = GetBinStringFragments(UHash13, false);
        var fragment14 = GetBinStringFragments(UHash14, false);
        var fragment15 = GetBinStringFragments(UHash15, false);
        var fragment16 = GetBinStringFragments(UHash16, littleEndian == false);

        var result = littleEndian
            ? $"{fragment1}{fragment2}{fragment3}{fragment4}{fragment5}{fragment6}{fragment7}{fragment8}{fragment9}{fragment10}{fragment11}{fragment12}{fragment13}{fragment14}{fragment15}{fragment16}"
            : $"{fragment16}{fragment15}{fragment14}{fragment13}{fragment12}{fragment11}{fragment10}{fragment9}{fragment8}{fragment7}{fragment6}{fragment5}{fragment4}{fragment3}{fragment2}{fragment1}";

        if (complementZero == false || result.Length == 1024)
            return result;

        return result.PadLeft(1024, '0');
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

    /// <inheritdoc />
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
            Hash = HashCodeUtil.InternalByteArrayConverter.ToBytes(1024, UHash1, UHash2, UHash3, UHash4, UHash5, UHash6, UHash7, UHash8, UHash9, UHash10, UHash11, UHash12, UHash13, UHash14, UHash15, UHash16);
            HasCreatedByteArray = true;
        }
    }

    /// <inheritdoc />
    public byte[] GetByteArray()
    {
        CreateByteArray();
        var ret = new byte[1024];
        Array.Copy(Hash, 0, ret, 0, 1024);
        return ret;
    }

    #endregion

    #region AsBitArray

    /// <inheritdoc />
    public BitArray GetBitArray()
    {
        return new(GetByteArray()) { Length = 1024 };
    }

    #endregion

    #region Convert to other HashCode

    /// <summary>
    /// Convert to sixteen <see cref="HashCode64"/> in a tuple. <br />
    /// 在元组中返回十六个 <see cref="HashCode64"/> 实例。
    /// </summary>
    /// <returns></returns>
    public (HashCode64, HashCode64, HashCode64, HashCode64, HashCode64, HashCode64, HashCode64, HashCode64, HashCode64, HashCode64, HashCode64, HashCode64, HashCode64, HashCode64, HashCode64, HashCode64) ToHashCode64Tuple()
    {
        return (
            new HashCode64(UHash1),
            new HashCode64(UHash2),
            new HashCode64(UHash3),
            new HashCode64(UHash4),
            new HashCode64(UHash5),
            new HashCode64(UHash6),
            new HashCode64(UHash7),
            new HashCode64(UHash8),
            new HashCode64(UHash9),
            new HashCode64(UHash10),
            new HashCode64(UHash11),
            new HashCode64(UHash12),
            new HashCode64(UHash13),
            new HashCode64(UHash14),
            new HashCode64(UHash15),
            new HashCode64(UHash16)
        );
    }

    /// <summary>
    /// Convert to eight <see cref="HashCode128"/> in a tuple. <br />
    /// 在元组中返回八个 <see cref="HashCode128"/> 实例。
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Convert to four <see cref="HashCode256"/> in a tuple. <br />
    /// 在元组中返回四个 <see cref="HashCode256"/> 实例。
    /// </summary>
    /// <returns></returns>
    public (HashCode256, HashCode256, HashCode256, HashCode256) ToHashCode256Tuple()
    {
        return (
            new HashCode256(UHash1, UHash2, UHash3, UHash4),
            new HashCode256(UHash5, UHash6, UHash7, UHash8),
            new HashCode256(UHash9, UHash10, UHash11, UHash12),
            new HashCode256(UHash13, UHash14, UHash15, UHash16)
        );
    }

    /// <summary>
    /// Convert to two <see cref="HashCode512"/> in a tuple. <br />
    /// 在元组中返回两个 <see cref="HashCode512"/> 实例。
    /// </summary>
    /// <returns></returns>
    public (HashCode512, HashCode512) ToHashCode512Tuple()
    {
        return (
            new HashCode512(UHash1, UHash2, UHash3, UHash4, UHash5, UHash6, UHash7, UHash8),
            new HashCode512(UHash9, UHash10, UHash11, UHash12, UHash13, UHash14, UHash15, UHash16)
        );
    }

    #endregion
}