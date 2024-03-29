﻿using System.Text.RegularExpressions;

namespace Cosmos.Text.Internals;
/*
 * Reference to:
 *	https://github.com/KvanTTT/BaseNcoding/blob/master/BaseNcoding/Base.cs
 *	Author: KvanTTT (Ivan Kochurkin)
 *	License:
 *		Apache License 2.0
 *		https://github.com/KvanTTT/BaseNcoding/blob/master/LICENSE
 *
 */

internal abstract class BaseXCore
{
    public uint CharsCount { get; }

    public double BitsPerChars => (double)BlockBitsCount / BlockCharsCount;

    public int BlockBitsCount { get; protected set; }

    public int BlockCharsCount { get; protected set; }

    public string Alphabet { get; }

    public char Special { get; }

    public abstract bool HasSpecial { get; }

    public Encoding Encoding { get; set; }

    public bool Parallel { get; set; }

    protected readonly int[] InvAlphabet;

    public BaseXCore(uint charsCount, string alphabet, char special, Encoding encoding = null, bool parallel = false)
    {
        if (alphabet.Length != charsCount)
            throw new ArgumentException($"Base string should contain {charsCount} chars");

        for (var i = 0; i < charsCount; i++)
        for (var j = i + 1; j < charsCount; j++)
            if (alphabet[i] == alphabet[j])
                throw new ArgumentException("Base string should contain distinct chars");

        if (alphabet.Contains(special))
            throw new ArgumentException("Base string should not contain special char");

        CharsCount = charsCount;
        Alphabet = alphabet;
        Special = special;

        var bitsPerChar = LogBase2(charsCount);

        BlockBitsCount = Lcm(bitsPerChar, 8);
        BlockCharsCount = BlockBitsCount / bitsPerChar;

        InvAlphabet = new int[Alphabet.Max() + 1];

        for (var i = 0; i < InvAlphabet.Length; i++)
            InvAlphabet[i] = -1;

        for (var i = 0; i < charsCount; i++)
            InvAlphabet[Alphabet[i]] = i;

        Encoding = encoding ?? Encoding.UTF8;
        Parallel = parallel;
    }

    public virtual string EncodeString(string data)
    {
        return Encode(Encoding.GetBytes(data));
    }

    public abstract string Encode(byte[] data);

    public string DecodeToString(string data)
    {
        return Encoding.GetString(Decode(Regex.Replace(data, @"\r\n?|\n", "")));
    }

    public abstract byte[] Decode(string data);

    /// <summary>
    /// From: http://stackoverflow.com/a/600306/1046374
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static bool IsPowerOf2(uint x)
    {
        var xint = x;
        if (x - xint != 0)
            return false;

        return (xint & (xint - 1)) == 0;
    }

    /// <summary>
    /// From: http://stackoverflow.com/a/13569863/1046374
    /// </summary>
    public static int Lcm(int a, int b)
    {
        int num1, num2;
        if (a > b)
        {
            num1 = a;
            num2 = b;
        }
        else
        {
            num1 = b;
            num2 = a;
        }

        for (var i = 1; i <= num2; i++)
        {
            var mult = num1 * i;
            if (mult % num2 == 0)
                return mult;
        }

        return num2;
    }

    private static int LogBase2(uint x)
    {
        var r = 0;
        while ((x >>= 1) != 0)
            r++;
        return r;
    }

    private static int LogBaseN(uint x, uint n)
    {
        var r = 0;
        while ((x /= n) != 0)
            r++;
        return r;
    }

    public static int GetOptimalBitsCount2(uint charsCount, out uint charsCountInBits,
        uint maxBitsCount = 64, bool base2BitsCount = false)
    {
        var result = 0;
        charsCountInBits = 0;
        var n1 = LogBase2(charsCount);
        var charsCountLog = Math.Log(2, charsCount);
        double maxRatio = 0;

        for (var n = n1; n <= maxBitsCount; n++)
        {
            if (base2BitsCount && n % 8 != 0)
                continue;

            var l1 = (uint)Math.Ceiling(n * charsCountLog);
            var ratio = (double)n / l1;
            if (ratio > maxRatio)
            {
                maxRatio = ratio;
                result = n;
                charsCountInBits = l1;
            }
        }

        return result;
    }

    protected static int GetOptimalBitsCount(uint charsCount, out uint charsCountInBits, uint maxBitsCount = 64, uint radix = 2)
    {
        var result = 0;
        charsCountInBits = 0;
        var n0 = LogBaseN(charsCount, radix);
        var charsCountLog = Math.Log(radix, charsCount);
        double maxRatio = 0;

        for (var n = n0; n <= maxBitsCount; n++)
        {
            var k = (uint)Math.Ceiling(n * charsCountLog);
            var ratio = (double)n / k;
            if (ratio > maxRatio)
            {
                maxRatio = ratio;
                result = n;
                charsCountInBits = k;
            }
        }

        return result;
    }
}