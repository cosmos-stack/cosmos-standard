namespace Cosmos.Text.Internals;
/*
 * Reference to:
 *	https://github.com/KvanTTT/BaseNcoding/blob/master/BaseNcoding/BaseN.cs
 *	Author: KvanTTT (Ivan Kochurkin)
 *	License:
 *		Apache License 2.0
 *		https://github.com/KvanTTT/BaseNcoding/blob/master/LICENSE
 *
 */

internal class BaseX : BaseXCore
{
    private readonly ulong[] _powN;

    public uint BlockMaxBitsCount { get; }

    public override bool HasSpecial => false;

    public bool ReverseOrder { get; }

    public BaseX(
        string alphabet,
        uint blockMaxBitsCount = 32,
        Encoding encoding = null,
        bool reverseOrder = false,
        bool parallel = false)
        : base((uint)alphabet.Length, alphabet, '\0', encoding, parallel)
    {
        BlockMaxBitsCount = blockMaxBitsCount;
        BlockBitsCount = GetOptimalBitsCount(CharsCount, out var charsCountInBits, blockMaxBitsCount);
        BlockCharsCount = (int)charsCountInBits;
        _powN = new ulong[BlockCharsCount];
        ulong pow = 1;
        for (var i = 0; i < BlockCharsCount - 1; i++)
        {
            _powN[BlockCharsCount - 1 - i] = pow;
            pow *= CharsCount;
        }

        _powN[0] = pow;
        ReverseOrder = reverseOrder;
    }

    public override string Encode(byte[] data)
    {
        if (data == null || data.Length == 0)
            return string.Empty;

        var mainBitsLength = data.Length * 8 / BlockBitsCount * BlockBitsCount;
        var tailBitsLength = data.Length * 8 - mainBitsLength;
        var mainCharsCount = mainBitsLength * BlockCharsCount / BlockBitsCount;
        var tailCharsCount = (tailBitsLength * BlockCharsCount + BlockBitsCount - 1) / BlockBitsCount;
        var totalCharsCount = mainCharsCount + tailCharsCount;
        var iterationCount = mainCharsCount / BlockCharsCount;

        var result = new char[totalCharsCount];

        if (!Parallel)
        {
            EncodeBlock(data, result, 0, iterationCount);
        }
        else
        {
            var processorCount = Math.Min(iterationCount, Environment.ProcessorCount);
            System.Threading.Tasks.Parallel.For(0, processorCount, i =>
            {
                var beginInd = i * iterationCount / processorCount;
                var endInd = (i + 1) * iterationCount / processorCount;
                EncodeBlock(data, result, beginInd, endInd);
            });
        }

        if (tailBitsLength != 0)
        {
            var bits = GetBits64(data, mainBitsLength, tailBitsLength);
            BitsToChars(result, mainCharsCount, tailCharsCount, bits);
        }

        return new string(result);
    }

    public override byte[] Decode(string data)
    {
        if (string.IsNullOrEmpty(data))
            return Array.Empty<byte>();

        var totalBitsLength = ((data.Length - 1) * BlockBitsCount / BlockCharsCount + 8) / 8 * 8;
        var mainBitsLength = totalBitsLength / BlockBitsCount * BlockBitsCount;
        var tailBitsLength = totalBitsLength - mainBitsLength;
        var mainCharsCount = mainBitsLength * BlockCharsCount / BlockBitsCount;
        var tailCharsCount = (tailBitsLength * BlockCharsCount + BlockBitsCount - 1) / BlockBitsCount;
        var tailBits = CharsToBits(data, mainCharsCount, tailCharsCount);
        if (tailBits >> tailBitsLength != 0)
        {
            totalBitsLength += 8;
            mainBitsLength = totalBitsLength / BlockBitsCount * BlockBitsCount;
            tailBitsLength = totalBitsLength - mainBitsLength;
            mainCharsCount = mainBitsLength * BlockCharsCount / BlockBitsCount;
            tailCharsCount = (tailBitsLength * BlockCharsCount + BlockBitsCount - 1) / BlockBitsCount;
        }

        var iterationCount = mainCharsCount / BlockCharsCount;

        var result = new byte[totalBitsLength / 8];

        if (!Parallel)
        {
            DecodeBlock(data, result, 0, iterationCount);
        }
        else
        {
            var processorCount = Math.Min(iterationCount, Environment.ProcessorCount);
            System.Threading.Tasks.Parallel.For(0, processorCount, i =>
            {
                var beginInd = i * iterationCount / processorCount;
                var endInd = (i + 1) * iterationCount / processorCount;
                DecodeBlock(data, result, beginInd, endInd);
            });
        }

        if (tailCharsCount != 0)
        {
            var bits = CharsToBits(data, mainCharsCount, tailCharsCount);
            AddBits64(result, bits, mainBitsLength, tailBitsLength);
        }

        return result;
    }

    private void EncodeBlock(byte[] src, char[] dst, int beginInd, int endInd)
    {
        for (var ind = beginInd; ind < endInd; ind++)
        {
            var charInd = ind * BlockCharsCount;
            var bitInd = ind * BlockBitsCount;
            var bits = GetBits64(src, bitInd, BlockBitsCount);
            BitsToChars(dst, charInd, BlockCharsCount, bits);
        }
    }

    private void DecodeBlock(string src, byte[] dst, int beginInd, int endInd)
    {
        for (var ind = beginInd; ind < endInd; ind++)
        {
            var charInd = ind * BlockCharsCount;
            var bitInd = ind * BlockBitsCount;
            var bits = CharsToBits(src, charInd, BlockCharsCount);
            AddBits64(dst, bits, bitInd, BlockBitsCount);
        }
    }

    private static ulong GetBits64(byte[] data, int bitPos, int bitsCount)
    {
        var result = 0UL;

        var currentBytePos = Math.DivRem(bitPos, 8, out var currentBitInBytePos);

        var xLength = Math.Min(bitsCount, 8 - currentBitInBytePos);
        if (xLength != 0)
        {
            result = ((ulong)data[currentBytePos] << 56 + currentBitInBytePos) >> 64 - xLength << bitsCount - xLength;

            currentBytePos += Math.DivRem(currentBitInBytePos + xLength, 8, out currentBitInBytePos);

            var x2Length = bitsCount - xLength;
            if (x2Length > 8)
                x2Length = 8;

            while (x2Length > 0)
            {
                xLength += x2Length;
                result |= (ulong)data[currentBytePos] >> 8 - x2Length << bitsCount - xLength;

                currentBytePos += Math.DivRem(currentBitInBytePos + x2Length, 8, out currentBitInBytePos);

                x2Length = bitsCount - xLength;
                if (x2Length > 8)
                    x2Length = 8;
            }
        }

        return result;
    }

    private static void AddBits64(byte[] data, ulong value, int bitPos, int bitsCount)
    {
        unchecked
        {
            var currentBytePos = Math.DivRem(bitPos, 8, out int currentBitInBytePos);

            var xLength = Math.Min(bitsCount, 8 - currentBitInBytePos);
            if (xLength != 0)
            {
                var x1 = (byte)(value << 64 - bitsCount >> 56 + currentBitInBytePos);
                data[currentBytePos] |= x1;

                currentBytePos += Math.DivRem(currentBitInBytePos + xLength, 8, out currentBitInBytePos);

                var x2Length = bitsCount - xLength;
                if (x2Length > 8)
                    x2Length = 8;

                while (x2Length > 0)
                {
                    xLength += x2Length;
                    var x2 = (byte)(value >> bitsCount - xLength << 8 - x2Length);
                    data[currentBytePos] |= x2;

                    currentBytePos += Math.DivRem(currentBitInBytePos + x2Length, 8, out currentBitInBytePos);

                    x2Length = bitsCount - xLength;
                    if (x2Length > 8)
                        x2Length = 8;
                }
            }
        }
    }

    private void BitsToChars(char[] chars, int ind, int count, ulong block)
    {
        var result = block;
        for (var i = 0; i < count; i++)
        {
            var quotient = result / CharsCount;
            var remainder = result - quotient * CharsCount;
            result = quotient;
            chars[ind + (!ReverseOrder ? i : count - 1 - i)] = Alphabet[(int)remainder];
        }
    }

    private ulong CharsToBits(string data, int ind, int count)
    {
        ulong result = 0;
        for (var i = 0; i < count; i++)
            result += (ulong)InvAlphabet[data[ind + (!ReverseOrder ? i : count - 1 - i)]] * _powN[BlockCharsCount - 1 - i];
        return result;
    }
}