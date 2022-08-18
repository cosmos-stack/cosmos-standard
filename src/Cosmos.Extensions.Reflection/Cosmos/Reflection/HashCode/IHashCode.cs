using System.Collections;
using System.Text;

namespace Cosmos.Reflection;

/// <summary>
/// HashCode interface <br />
/// 哈希值接口
/// </summary>
public interface IHashCode
{
    /// <summary>
    /// Bit length <br />
    /// 位宽度
    /// </summary>
    int BitLength { get; }

    /// <summary>
    /// Get string <br />
    /// 获取字符串
    /// </summary>
    /// <returns></returns>
    public string GetString();

    /// <summary>
    /// Get string <br />
    /// 获取字符串
    /// </summary>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public string GetString(Encoding encoding);

    /// <summary>
    /// Get hex string <br />
    /// 获取十六进制字符串
    /// </summary>
    /// <returns></returns>
    string GetHexString();

    /// <summary>
    /// Get hex string <br />
    /// 获取十六进制字符串
    /// </summary>
    /// <param name="uppercase"></param>
    /// <returns></returns>
    string GetHexString(bool uppercase);

    /// <summary>
    /// Get LittleEndian hex string <br />
    /// 获取 LittleEndian 十六进制字符串
    /// </summary>
    /// <returns></returns>
    string GetLittleEndianHexString();

    /// <summary>
    /// Get LittleEndian hex string <br />
    /// 获取 LittleEndian 十六进制字符串
    /// </summary>
    /// <param name="uppercase"></param>
    /// <returns></returns>
    string GetLittleEndianHexString(bool uppercase);

    /// <summary>
    /// Get BigEndian hex string <br />
    /// 获取 BigEndian 十六进制字符串
    /// </summary>
    /// <returns></returns>
    string GetBigEndianHexString();

    /// <summary>
    /// Get BigEndian hex string <br />
    /// 获取 BigEndian 十六进制字符串
    /// </summary>
    /// <param name="uppercase"></param>
    /// <returns></returns>
    string GetBigEndianHexString(bool uppercase);

    /// <summary>
    /// Get bin string <br />
    /// 获取二进制字符串
    /// </summary>
    /// <returns></returns>
    string GetBinString();

    /// <summary>
    /// Get bin string <br />
    /// 获取二进制字符串
    /// </summary>
    /// <param name="complementZero"></param>
    /// <returns></returns>
    string GetBinString(bool complementZero);

    /// <summary>
    /// Get Base64 string <br />
    /// 获取 Base64 字符串
    /// </summary>
    /// <returns></returns>
    string GetBase64String();

    /// <summary>
    /// Get byte array <br />
    /// 获取字节数组
    /// </summary>
    /// <returns></returns>
    byte[] GetByteArray();

    /// <summary>
    /// Get BitArray <br />
    /// 获取压缩数组
    /// </summary>
    /// <returns></returns>
    BitArray GetBitArray();
}