﻿using System.Text;

// ReSharper disable InconsistentNaming

namespace Cosmos.Text.Internals;
/*
 * Reference to:
 *	https://github.com/KvanTTT/BaseNcoding/blob/master/BaseNcoding/ZBase32.cs
 *	Author: KvanTTT (Ivan Kochurkin)
 *	License:
 *		Apache License 2.0
 *		https://github.com/KvanTTT/BaseNcoding/blob/master/LICENSE
 *	Witch from:
 *	 https://github.com/denxc/ZBase32Encoder/blob/master/ZBase32Encoder/ZBase32Encoder/ZBase32Encoder.cs
 */

internal unsafe class ZBase32 : BaseXCore
{
    public const string DefaultAlphabet = "ybndrfg8ejkmcpqxot1uwisza345h769";
    public const char DefaultSpecial = (char) 0;

    public override bool HasSpecial => false;

    public ZBase32(string alphabet = DefaultAlphabet, char special = DefaultSpecial, Encoding? textEncoding = null)
        : base(32, alphabet, special, textEncoding) { }

    public override string Encode(byte[] data)
    {
        unchecked
        {
            var encodedResult = new StringBuilder((int) Math.Ceiling(data.Length * 8.0 / 5.0));

            for (var i = 0; i < data.Length; i += 5)
            {
                var byteCount = Math.Min(5, data.Length - i);

                ulong buffer = 0;
                for (var j = 0; j < byteCount; ++j)
                    buffer = (buffer << 8) | data[i + j];

                var bitCount = byteCount * 8;
                while (bitCount > 0)
                {
                    var index = bitCount >= 5
                        ? (int) (buffer >> (bitCount - 5)) & 0x1f
                        : (int) (buffer & (ulong) (0x1f >> (5 - bitCount))) << (5 - bitCount);

                    encodedResult.Append(DefaultAlphabet[index]);
                    bitCount -= 5;
                }
            }

            return encodedResult.ToString();
        }
    }

    public override byte[] Decode(string data)
    {
        if (string.IsNullOrEmpty(data))
            return new byte[0];

        var result = new List<byte>((int) Math.Ceiling(data.Length * 5.0 / 8.0));

        var index = stackalloc int[8];
        for (var i = 0; i < data.Length;)
        {
            int currentPosition = i;

            var k = 0;
            while (k < 8)
            {
                if (currentPosition >= data.Length)
                {
                    index[k++] = -1;
                    continue;
                }

                if (InvAlphabet[data[currentPosition]] == -1)
                {
                    currentPosition++;
                    continue;
                }

                index[k] = data[currentPosition];
                k++;
                currentPosition++;
            }

            i = currentPosition;

            var shortByteCount = 0;
            ulong buffer = 0;
            for (var j = 0; j < 8 && index[j] != -1; ++j)
            {
#pragma warning disable CS0675
                buffer = (buffer << 5) | (ulong) (InvAlphabet[index[j]] & 0x1f);
#pragma warning restore CS0675
                shortByteCount++;
            }

            var bitCount = shortByteCount * 5;
            while (bitCount >= 8)
            {
                result.Add((byte) ((buffer >> (bitCount - 8)) & 0xff));
                bitCount -= 8;
            }
        }

        return result.ToArray();
    }
}