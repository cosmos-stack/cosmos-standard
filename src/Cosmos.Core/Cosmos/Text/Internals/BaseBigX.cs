﻿using System.Numerics;

#pragma warning disable CS8618

namespace Cosmos.Text.Internals;

/*
 * Reference to:
 *	https://github.com/KvanTTT/BaseNcoding/blob/master/BaseNcoding/BaseBigN.cs
 *	Author: KvanTTT (Ivan Kochurkin)
 *	License:
 *		Apache License 2.0
 *		https://github.com/KvanTTT/BaseNcoding/blob/master/LICENSE
 *
 */

internal class BaseBigX : BaseXCore
{
    private BigInteger[] _powN;

    public bool ReverseOrder { get; }

    public uint BlockMaxBitsCount { get; }

    public bool MaxCompression { get; }

    public override bool HasSpecial => false;

    public BaseBigX(
        string alphabet,
        uint blockMaxBitsCount = 64,
        Encoding encoding = null,
        bool reverseOrder = false,
        bool parallel = false,
        bool maxCompression = false)
        : base((uint)alphabet.Length, alphabet, '\0', encoding, parallel)
    {
        BlockMaxBitsCount = blockMaxBitsCount;
        BlockBitsCount = GetOptimalBitsCount(CharsCount, out var charsCountInBits, BlockMaxBitsCount);
        BlockCharsCount = (int)charsCountInBits;

        PreparePowN(BlockCharsCount);

        ReverseOrder = reverseOrder;
        MaxCompression = maxCompression;
    }

    public override string Encode(byte[] data)
    {
        if (data is null || data.Length == 0)
            return string.Empty;

        int blockBitsCount, blockCharsCount;
        if (!MaxCompression)
        {
            blockBitsCount = BlockBitsCount;
            blockCharsCount = BlockCharsCount;
        }
        else
        {
            blockBitsCount = data.Length * 8;
            blockCharsCount = (int)Math.Ceiling(blockBitsCount * Math.Log(2, Alphabet.Length));
            PreparePowN(blockCharsCount);
        }

        var data8 = data.Length * 8;
        var mainBitsLength = data8 / blockBitsCount * blockBitsCount;
        var tailBitsLength = data8 - mainBitsLength;
        var mainCharsCount = mainBitsLength * blockCharsCount / blockBitsCount;
        var tailCharsCount = (tailBitsLength * blockCharsCount + blockBitsCount - 1) / blockBitsCount;
        var totalCharsCount = mainCharsCount + tailCharsCount;
        var iterationCount = mainCharsCount / blockCharsCount;

        var result = new char[totalCharsCount];

        if (!Parallel)
            EncodeBlock(data, result, 0, iterationCount, blockBitsCount, blockCharsCount);
        else
        {
            var processorCount = Math.Min(iterationCount, Environment.ProcessorCount);
            System.Threading.Tasks.Parallel.For(0, processorCount, i =>
            {
                var beginInd = i * iterationCount / processorCount;
                var endInd = (i + 1) * iterationCount / processorCount;
                EncodeBlock(data, result, beginInd, endInd, blockBitsCount, blockCharsCount);
            });
        }

        if (tailBitsLength != 0)
        {
            var bits = GetBitsN(data, mainBitsLength, tailBitsLength);
            BitsToChars(result, mainCharsCount, tailCharsCount, bits);
        }

        return new string(result);
    }

    public override byte[] Decode(string data)
    {
        if (string.IsNullOrEmpty(data))
            return Array.Empty<byte>();

        int blockBitsCount, blockCharsCount;
        if (!MaxCompression)
        {
            blockBitsCount = BlockBitsCount;
            blockCharsCount = BlockCharsCount;
        }
        else
        {
            blockCharsCount = data.Length;
            blockBitsCount = (int)(blockCharsCount / Math.Log(2, Alphabet.Length)) / 8 * 8;
            PreparePowN(blockCharsCount);
        }

        var totalBitsLength = ((data.Length - 1) * blockBitsCount / blockCharsCount + 8) / 8 * 8;
        var mainBitsLength = totalBitsLength / blockBitsCount * blockBitsCount;
        var tailBitsLength = totalBitsLength - mainBitsLength;
        var mainCharsCount = mainBitsLength * blockCharsCount / blockBitsCount;
        var tailCharsCount = (tailBitsLength * blockCharsCount + blockBitsCount - 1) / blockBitsCount;
        var tailBits = CharsToBits(data, mainCharsCount, tailCharsCount);
        if (tailBits >> tailBitsLength != 0)
        {
            totalBitsLength += 8;
            mainBitsLength = totalBitsLength / blockBitsCount * blockBitsCount;
            tailBitsLength = totalBitsLength - mainBitsLength;
            mainCharsCount = mainBitsLength * blockCharsCount / blockBitsCount;
            tailCharsCount = (tailBitsLength * blockCharsCount + blockBitsCount - 1) / blockBitsCount;
        }

        var iterationCount = mainCharsCount / blockCharsCount;

        var result = new byte[totalBitsLength / 8];

        if (!Parallel)
        {
            DecodeBlock(data, result, 0, iterationCount, blockBitsCount, blockCharsCount);
        }
        else
        {
            var processorCount = Math.Min(iterationCount, Environment.ProcessorCount);
            System.Threading.Tasks.Parallel.For(0, processorCount, i =>
            {
                var beginInd = i * iterationCount / processorCount;
                var endInd = (i + 1) * iterationCount / processorCount;
                DecodeBlock(data, result, beginInd, endInd, blockBitsCount, blockCharsCount);
            });
        }

        if (tailCharsCount != 0)
        {
            var bits = CharsToBits(data, mainCharsCount, tailCharsCount);
            AddBitsN(result, bits, mainBitsLength, tailBitsLength);
        }

        return result;
    }

    private void EncodeBlock(byte[] src, char[] dst, int beginInd, int endInd, int blockBitsCount, int blockCharsCount)
    {
        for (int ind = beginInd; ind < endInd; ind++)
        {
            int charInd = ind * blockCharsCount;
            int bitInd = ind * blockBitsCount;
            BigInteger bits = GetBitsN(src, bitInd, blockBitsCount);
            BitsToChars(dst, charInd, blockCharsCount, bits);
        }
    }

    private void DecodeBlock(string src, byte[] dst, int beginInd, int endInd, int blockBitsCount, int blockCharsCount)
    {
        for (int ind = beginInd; ind < endInd; ind++)
        {
            int charInd = ind * blockCharsCount;
            int bitInd = ind * blockBitsCount;
            BigInteger bits = CharsToBits(src, charInd, blockCharsCount);
            AddBitsN(dst, bits, bitInd, blockBitsCount);
        }
    }

    private static BigInteger GetBitsN(byte[] data, int bitPos, int bitsCount)
    {
        BigInteger result = 0;

        int currentBytePos = Math.DivRem(bitPos, 8, out int currentBitInBytePos);
        int shift = 8 - currentBitInBytePos;
        int xLength = Math.Min(bitsCount, shift);
        if (xLength != 0)
        {
            result = new BigInteger((data[currentBytePos] >> shift - xLength) & ((1 << shift) - 1)) << bitsCount - xLength;

            currentBytePos += Math.DivRem(currentBitInBytePos + xLength, 8, out currentBitInBytePos);

            int x2Length = bitsCount - xLength;
            if (x2Length > 8)
                x2Length = 8;

            while (x2Length > 0)
            {
                xLength += x2Length;
                result |= (BigInteger)(data[currentBytePos] >> 8 - x2Length) << bitsCount - xLength;

                currentBytePos += Math.DivRem(currentBitInBytePos + x2Length, 8, out currentBitInBytePos);

                x2Length = bitsCount - xLength;
                if (x2Length > 8)
                    x2Length = 8;
            }
        }

        return result;
    }

    private static void AddBitsN(byte[] data, BigInteger value, int bitPos, int bitsCount)
    {
        int currentBytePos = Math.DivRem(bitPos, 8, out int currentBitInBytePos);

        int shift = 8 - currentBitInBytePos;
        int xLength = Math.Min(bitsCount, shift);
        if (xLength != 0)
        {
            data[currentBytePos] |= (byte)((byte)(value >> bitsCount - shift) & ((1 << shift) - 1));

            currentBytePos += Math.DivRem(currentBitInBytePos + xLength, 8, out currentBitInBytePos);

            int x2Length = bitsCount - xLength;
            if (x2Length > 8)
                x2Length = 8;

            while (x2Length > 0)
            {
                xLength += x2Length;
                var bitsCountMinusXLength = bitsCount - xLength;
                data[currentBytePos] |= (byte)((value >> (bitsCountMinusXLength - 8 + x2Length)) & 0xFF);

                currentBytePos += Math.DivRem(currentBitInBytePos + x2Length, 8, out currentBitInBytePos);

                x2Length = bitsCountMinusXLength;
                if (x2Length > 8)
                    x2Length = 8;
            }
        }
    }

    private void BitsToChars(char[] chars, int ind, int count, BigInteger block)
    {
        BigInteger quotient = block;
        for (int i = 0; i < count; i++)
        {
            quotient = BigInteger.DivRem(quotient, CharsCount, out BigInteger remainder);
            chars[ind + (!ReverseOrder ? i : count - 1 - i)] = Alphabet[(int)remainder];
        }
    }

    private BigInteger CharsToBits(string data, int ind, int count)
    {
        BigInteger result = 0;
        for (int i = 0; i < count; i++)
            result += InvAlphabet[data[ind + (!ReverseOrder ? i : count - 1 - i)]] * _powN![_powN.Length - 1 - i];
        return result;
    }

    private void PreparePowN(int blockCharsCount)
    {
        _powN = new BigInteger[blockCharsCount];
        BigInteger pow = 1;
        for (int i = 0; i < blockCharsCount - 1; i++)
        {
            _powN[blockCharsCount - 1 - i] = pow;
            pow *= CharsCount;
        }

        if (blockCharsCount > 0)
            _powN[0] = pow;
    }
}