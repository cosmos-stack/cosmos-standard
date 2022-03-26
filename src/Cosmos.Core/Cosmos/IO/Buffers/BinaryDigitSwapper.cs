namespace Cosmos.IO.Buffers;

/// <summary>
/// Bit Swapper <br />
/// 字节交换
/// </summary>
public static class BinaryDigitSwapper
{
    /// <summary>
    /// Exchange the value of 8 bits before and after Int16 <br />
    /// 交换 Int16 前后 8 位的值
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short SwapInt16(short v) =>
        (short)(((v & 0xff) << 8) | ((v >> 8) & 0xff));

    /// <summary>
    /// Exchange the value of 8 bits before and after UInt16 <br />
    /// 交换 UInt16 前后 8 位的值
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort SwapUInt16(ushort v) =>
        (ushort)(((v & 0xff) << 8) | ((v >> 8) & 0xff));

    /// <summary>
    /// Exchange the value of 16 bits before and after Int32 <br />
    /// 交换 Int32 前后 16 位的值
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int SwapInt32(int v) =>
        ((SwapInt16((short)v) & 0xffff) << 0x10) | (SwapInt16((short)(v >> 0x10)) & 0xffff);

    /// <summary>
    /// Exchange the value of 16 bits before and after UInt32 <br />
    /// 交换 UInt32 前后 16 位的值
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint SwapUInt32(uint v) =>
        (uint)(((SwapUInt16((ushort)v) & 0xffff) << 0x10) | (SwapUInt16((ushort)(v >> 0x10)) & 0xffff));

    /// <summary>
    /// Exchange the value of 32 bits before and after Int64 <br />
    /// 交换 Int64 前后 32 位的值
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long SwapInt64(long v) =>
        ((SwapInt32((int)v) & 0xffffffffL) << 0x20) | (SwapInt32((int)(v >> 0x20)) & 0xffffffffL);

    /// <summary>
    /// Exchange the value of 32 bits before and after UInt64 <br />
    /// 交换 UInt64 前后 32 位的值
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong SwapUInt64(ulong v) =>
        (ulong)(((SwapUInt32((uint)v) & 0xffffffffL) << 0x20) | (SwapUInt32((uint)(v >> 0x20)) & 0xffffffffL));
}