using System;

namespace Cosmos.IO.Buffers
{
    /// <summary>
    /// Bit Writer
    /// </summary>
    public static class BinaryDigitWriter
    {
        #region Span

        public static void Write(Span<byte> buffer, short value)
        {
            buffer[0] = (byte) value;
            buffer[1] = (byte) (value >> 8);
        }

        public static void Write(Span<byte> buffer, ushort value)
        {
            buffer[0] = (byte) value;
            buffer[1] = (byte) (value >> 8);
        }

        public static void Write(Span<byte> buffer, int value)
        {
            buffer[0] = (byte) value;
            buffer[1] = (byte) (value >> 8);
            buffer[2] = (byte) (value >> 16);
            buffer[3] = (byte) (value >> 24);
        }

        public static void Write(Span<byte> buffer, uint value)
        {
            buffer[0] = (byte) value;
            buffer[1] = (byte) (value >> 8);
            buffer[2] = (byte) (value >> 16);
            buffer[3] = (byte) (value >> 24);
        }

        public static void Write(Span<byte> buffer, long value)
        {
            buffer[0] = (byte) value;
            buffer[1] = (byte) (value >> 8);
            buffer[2] = (byte) (value >> 16);
            buffer[3] = (byte) (value >> 24);
            buffer[4] = (byte) (value >> 32);
            buffer[5] = (byte) (value >> 40);
            buffer[6] = (byte) (value >> 48);
            buffer[7] = (byte) (value >> 56);
        }

        public static void Write(Span<byte> buffer, ulong value)
        {
            buffer[0] = (byte) value;
            buffer[1] = (byte) (value >> 8);
            buffer[2] = (byte) (value >> 16);
            buffer[3] = (byte) (value >> 24);
            buffer[4] = (byte) (value >> 32);
            buffer[5] = (byte) (value >> 40);
            buffer[6] = (byte) (value >> 48);
            buffer[7] = (byte) (value >> 56);
        }

        #endregion

        #region Bytes

        public static void Write(byte[] buffer, int position, short value)
        {
            buffer[position + 0] = (byte) value;
            buffer[position + 1] = (byte) (value >> 8);
        }

        public static void Write(byte[] buffer, int position, ushort value)
        {
            buffer[position + 0] = (byte) value;
            buffer[position + 1] = (byte) (value >> 8);
        }

        public static void Write(byte[] buffer, int position, int value)
        {
            buffer[position + 0] = (byte) value;
            buffer[position + 1] = (byte) (value >> 8);
            buffer[position + 2] = (byte) (value >> 16);
            buffer[position + 3] = (byte) (value >> 24);
        }

        public static void Write(byte[] buffer, int position, uint value)
        {
            buffer[position + 0] = (byte) value;
            buffer[position + 1] = (byte) (value >> 8);
            buffer[position + 2] = (byte) (value >> 16);
            buffer[position + 3] = (byte) (value >> 24);
        }

        public static void Write(byte[] buffer, int position, long value)
        {
            buffer[position + 0] = (byte) value;
            buffer[position + 1] = (byte) (value >> 8);
            buffer[position + 2] = (byte) (value >> 16);
            buffer[position + 3] = (byte) (value >> 24);
            buffer[position + 4] = (byte) (value >> 32);
            buffer[position + 5] = (byte) (value >> 40);
            buffer[position + 6] = (byte) (value >> 48);
            buffer[position + 7] = (byte) (value >> 56);
        }

        public static void Write(byte[] buffer, int position, ulong value)
        {
            buffer[position + 0] = (byte) value;
            buffer[position + 1] = (byte) (value >> 8);
            buffer[position + 2] = (byte) (value >> 16);
            buffer[position + 3] = (byte) (value >> 24);
            buffer[position + 4] = (byte) (value >> 32);
            buffer[position + 5] = (byte) (value >> 40);
            buffer[position + 6] = (byte) (value >> 48);
            buffer[position + 7] = (byte) (value >> 56);
        }

        #endregion
    }
}