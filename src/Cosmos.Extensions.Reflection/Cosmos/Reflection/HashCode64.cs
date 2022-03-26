using System.Collections;
using System.Text;
using Cosmos.Optionals;
using Cosmos.Conversions;

namespace Cosmos.Reflection;

/// <summary>
/// HashCode 64
/// </summary>
[Serializable]
public struct HashCode64 : IEquatable<HashCode64>, IHashCode
{
    /// <summary>
    /// Zero<br />零值
    /// </summary>
    public static readonly HashCode64 Zero = default;

    /// <inheritdoc />
    public int BitLength => 64;

    public HashCode64(ulong hash)
    {
        UHash1 = (uint)(hash >> 32);
        UHash2 = (uint)(hash & 0x00000000FFFFFFFF);

        HasCreatedByteArray = false;
        Hash = null;
    }

    public HashCode64(uint hash1, uint hash2)
    {
        UHash1 = hash1;
        UHash2 = hash2;

        HasCreatedByteArray = false;
        Hash = null;
    }

    public HashCode64(long hash)
        : this(unchecked((ulong)hash)) { }

    public HashCode64(int hash1, int hash2)
        : this(unchecked((uint)hash1), unchecked((uint)hash2)) { }

    public HashCode64(HashCode32 hash1, HashCode32 hash2) : this(
        unchecked(((uint)hash1.Hash1 << 16) | (ushort)hash1.Hash2),
        unchecked((uint)(hash2.Hash1 << 16) | (ushort)hash2.Hash2)) { }

    /// <summary>
    /// Hash 1
    /// </summary>
    public int Hash1 => unchecked((int)UHash1);

    /// <summary>
    /// Hash 2
    /// </summary>
    public int Hash2 => unchecked((int)UHash2);

    /// <summary>
    /// Hash 1 in UInt32
    /// </summary>
    public uint UHash1 { get; }

    /// <summary>
    /// Hash2 in UInt32
    /// </summary>
    public uint UHash2 { get; }

    /// <summary>
    /// Try parse strictly<br />
    /// 尝试转换，严格模式
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Try parse loosely<br />
    /// 尝试转换，宽松模式
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Parse loosely <br />
    /// 转换，宽松模式
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="FormatException"></exception>
    public static HashCode64 ParseLoosely(string s)
    {
        if (s is null)
            throw new ArgumentNullException(nameof(s));
        if (!TryParseLoosely(s, out var ret))
            throw new FormatException("The string did not contain a 32-digit hexadecimal number.");

        return ret;
    }

    /// <summary>
    /// Parse strictly<br />
    /// 转换，严格模式
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="FormatException"></exception>
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

    /// <inheritdoc />
    public bool Equals(HashCode64 other) => UHash1 == other.UHash1 && UHash2 == other.UHash2;

    /// <inheritdoc />
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

    /// <inheritdoc />
    public override bool Equals(object obj) => obj is HashCode64 code64 && Equals(code64);

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
        var formatString = uppercase ? "X8" : "x8";
        return UHash1.ToString(formatString) + UHash2.ToString(formatString);
    }

    /// <inheritdoc />
    public string GetBigEndianHexString() => GetBigEndianHexString(false);

    /// <inheritdoc />
    public string GetBigEndianHexString(bool uppercase)
    {
        var formatString = uppercase ? "X8" : "x8";
        return UHash2.ToString(formatString) + UHash1.ToString(formatString);
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
        var fragment2 = GetBinStringFragments(UHash2, littleEndian == false);

        var result = littleEndian
            ? $"{fragment1}{fragment2}"
            : $"{fragment2}{fragment1}";

        if (complementZero == false || result.Length == 64)
            return result;

        return result.PadLeft(64, '0');
    }

    private string GetBinStringFragments(uint hashVal, bool firstFlag)
    {
        var fragment = ScaleConv.HexToBin(hashVal.ToString("x8"));

        if (firstFlag || fragment.Length == 32)
            return fragment;

        return fragment.PadLeft(32, '0');
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
            Hash = HashCodeUtil.InternalByteArrayConverter.ToBytes(64, UHash1, UHash2);
            HasCreatedByteArray = true;
        }
    }

    /// <inheritdoc />
    public byte[] GetByteArray()
    {
        CreateByteArray();
        var ret = new byte[64];
        Array.Copy(Hash, 0, ret, 0, 64);
        return ret;
    }

    #endregion

    #region AsBitArray

    /// <inheritdoc />
    public BitArray GetBitArray()
    {
        return new(GetByteArray()) { Length = 64 };
    }

    #endregion

    #region Convert to other HashCode

    /// <summary>
    /// Convert to two <see cref="HashCode32"/> in a tuple. <br />
    /// 在元组中返回两个 <see cref="HashCode32"/> 实例。
    /// </summary>
    /// <returns></returns>
    public (HashCode32, HashCode32) ToHashCode32Tuple()
    {
        return (
            new HashCode32(UHash1),
            new HashCode32(UHash2)
        );
    }

    #endregion
}