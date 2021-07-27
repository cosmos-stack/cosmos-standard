using System;
using System.Runtime.CompilerServices;

namespace Cosmos.IO.Buffers
{
    /// <summary>
    /// Bit Reader
    /// </summary>
    public static class BinaryDigitReader
    {
        #region Span

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ReadInt16(Span<byte> buffer) =>
            (short) (buffer[0] | buffer[1] << 8);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ReadUInt16(Span<byte> buffer) =>
            (ushort) (buffer[0] | buffer[1] << 8);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ReadInt32(Span<byte> buffer) =>
            buffer[0] | buffer[1] << 8 | buffer[2] << 16 | buffer[3] << 24;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ReadUInt32(Span<byte> buffer) =>
            (uint) (buffer[0] | buffer[1] << 8 | buffer[2] << 16 | buffer[3] << 24);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ReadInt64(Span<byte> buffer)
        {
            var num = (uint) (buffer[0] | buffer[1] << 8 | buffer[2] << 16 | buffer[3] << 24);
            var num2 = (uint) (buffer[4] | buffer[5] << 8 | buffer[6] << 16 | buffer[7] << 24);
            return (long) ((ulong) num2 << 32 | num);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ReadUInt64(Span<byte> buffer)
        {
            var num = (uint) (buffer[0] | buffer[1] << 8 | buffer[2] << 16 | buffer[3] << 24);
            var num2 = (uint) (buffer[4] | buffer[5] << 8 | buffer[6] << 16 | buffer[7] << 24);
            return (ulong) num2 << 32 | num;
        }

        #endregion

        #region Bytes

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ReadInt16(byte[] buffer, int position) =>
            (short) (buffer[position + 0] | buffer[position + 1] << 8);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ReadUInt16(byte[] buffer, int position) =>
            (ushort) (buffer[position + 0] | buffer[position + 1] << 8);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ReadInt32(byte[] buffer, int position) =>
            buffer[position + 0] | buffer[position + 1] << 8 | buffer[position + 2] << 16 | buffer[position + 3] << 24;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ReadUInt32(byte[] buffer, int position) =>
            (uint) (buffer[position + 0] | buffer[position + 1] << 8 | buffer[position + 2] << 16 | buffer[position + 3] << 24);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ReadInt64(byte[] buffer, int position)
        {
            var num = (uint) (buffer[position + 0] | buffer[position + 1] << 8 | buffer[position + 2] << 16 | buffer[position + 3] << 24);
            var num2 = (uint) (buffer[position + 4] | buffer[position + 5] << 8 | buffer[position + 6] << 16 | buffer[position + 7] << 24);
            return (long) ((ulong) num2 << 32 | num);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ReadUInt64(byte[] buffer, int position)
        {
            var num = (uint) (buffer[position + 0] | buffer[position + 1] << 8 | buffer[position + 2] << 16 | buffer[position + 3] << 24);
            var num2 = (uint) (buffer[position + 4] | buffer[position + 5] << 8 | buffer[position + 6] << 16 | buffer[position + 7] << 24);
            return (ulong) num2 << 32 | num;
        }

        #endregion
    }
}