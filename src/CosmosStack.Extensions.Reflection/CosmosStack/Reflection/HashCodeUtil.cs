using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmosStack.Reflection
{
    /// <summary>
    /// HashCode Utilities <br />
    /// HashCode 工具集
    /// </summary>
    public static class HashCodeUtil
    {
        /// <summary>
        /// Get HashCode
        /// </summary>
        /// <param name="hashFieldValuesFunc"></param>
        /// <returns></returns>
        public static int GetHashCode(Func<IEnumerable<object>> hashFieldValuesFunc) =>
            InternalCalculator.GetHashCodeImpl(hashFieldValuesFunc());

        /// <summary>
        /// Get HashCode
        /// </summary>
        /// <param name="hashFieldValues"></param>
        /// <returns></returns>
        public static int GetHashCode(IEnumerable<object> hashFieldValues) =>
            InternalCalculator.GetHashCodeImpl(hashFieldValues);

        internal static class InternalCalculator
        {
            public static int GetHashCodeImpl(IEnumerable<object> hashFieldValues)
            {
                // Native .NET implementation
                //var offset = 17;
                //var prime = 59;
                //
                //int HashCodeAggregator(int hashCode, object value) => value == null
                //    ? hashCode * prime + 0
                //    : hashCode * prime + value.GetHashCode();

                // http://www.isthe.com/chongo/tech/comp/fnv/index.html
                const int offset = unchecked((int)2166136261);
                const int prime = 16777619;

                int HashCodeAggregator(int hashCode, object value) => value == null
                    ? (hashCode ^ 0) * prime
                    : (hashCode ^ value.GetHashCode()) * prime;

                return hashFieldValues.Aggregate(offset, HashCodeAggregator);
            }
        }

        internal static class InternalParser
        {
            public static bool TryParse(string s, int sizeInBits, out uint[] valColl, bool strictMode)
            {
                //sizeInBits must be a number such as 32, 64, 128, 256, 512, or 1024.
                //If it is less than 32, the 'out uint[] valColl' version of the parser should be used.
                if (sizeInBits < 32)
                    goto fail;

                if (s == null)
                    goto fail;

                var len = s.Length;

                //When the length is less than 16 bits, the string is not enough to express HashCode32,
                //so the string is illegal at this time.
                if (len < 8)
                    goto fail;

                //The length of ulong is 32 bits, so we get the number of members of ValColl through this calculation.
                var size = sizeInBits / 32;

                //idx      - represents the legal Hex character read in the current string.
                //idxOfStr - represents the character offset of the current string read.
                //wasXSeen - represents whether to finish reading the hexadecimal number prefix '0x'.
                int idx = 0, idxOfStr = -1;
                var wasXSeen = false;

                valColl = new uint[size];

                int breakingBoundary, checkingBoundary, loopCounter;

                for (var idxOfValColl = 0; idxOfValColl < size; ++idxOfValColl)
                {
                    //Each character occupies 4 bits, so 32 bits correspond to 8 characters.
                    breakingBoundary = 8 * (idxOfValColl + 1);
                    checkingBoundary = 8 * idxOfValColl;
                    loopCounter = 0;

                    //When and only when the previous loop is executed (and the length reaches breakingBoundary),
                    //the current loop can be executed. After each loop, the value of idx will reach breakingBoundary.
                    //If it is less than breakingBoundary, it means that the length of the string is insufficient and the parsing is complete.
                    if (checkingBoundary != idx)
                    {
                        //If it is in strict mode, when the length of the string is insufficient, it will return the parsing failure.
                        if (strictMode)
                            goto fail;

                        //If it is not in strict mode, when the length of the string is insufficient, 0 is used for completion.
                        //At this point, it will no longer enter the parsing-loop body, but will return directly after completing all subsequent digits.
                        valColl[idxOfValColl] = 0;

                        if (idxOfValColl == size - 1)
                            goto success;

                        continue;
                    }

                    for (++idxOfStr; idxOfStr < len; ++idxOfStr)
                    {
                        var c = s[idxOfStr];

                        if (char.IsWhiteSpace(c))
                            continue;

                        switch (c)
                        {
                            case '0':
                            case '1':
                            case '2':
                            case '3':
                            case '4':
                            case '5':
                            case '6':
                            case '7':
                            case '8':
                            case '9':
                                UpdateForNumber(ref valColl[idxOfValColl], c);
                                break;

                            case 'a':
                            case 'b':
                            case 'c':
                            case 'd':
                            case 'e':
                            case 'f':
                                UpdateForLowerCaseLetter(ref valColl[idxOfValColl], c);
                                break;

                            case 'A':
                            case 'B':
                            case 'C':
                            case 'D':
                            case 'E':
                            case 'F':
                                UpdateForUpperCaseLetter(ref valColl[idxOfValColl], c);
                                break;

                            //The '0x' prefix is checked if and only if the ValColl index value is 0.
                            //If '0x' is encountered again in the middle, it is judged as an illegal Hex value.
                            case 'X':
                            case 'x':
                                if (!wasXSeen && idx == 1 && valColl[0] == 0)
                                {
                                    idx = 0;
                                    loopCounter = 0;
                                    wasXSeen = true;
                                    continue;
                                }

                                goto fail;

                            default:
                                goto fail;
                        }

                        //The loop counter is used to record the number of times the current loop is executed.
                        //When using strict mode, if the number of cycles is less than 8 times, it will be regarded as a failure.
                        ++loopCounter;

                        // Complete the calculation of the ValColl value at the current position,
                        // jump out of the loop, and execute the calculation of the next position.
                        if (++idx == breakingBoundary)
                            break;
                    }

                    //In strict mode, if the string parsing is completed,
                    //but the ValColl array fails to be assigned all the values, the return fails.
                    if (strictMode && idxOfValColl < size && idxOfStr >= len)
                        goto fail;

                    //In strict mode, if the loop counter does not loop 8 times, the parsing fails.
                    if (strictMode && loopCounter < 8)
                        goto fail;

                    if (idxOfValColl == size - 1)
                    {
                        for (++idxOfStr; idxOfStr < len; ++idxOfStr)
                            if (!char.IsWhiteSpace(s[idxOfStr]))
                                goto fail;

                        goto success;
                    }
                }

                fail:
                valColl = default;
                return false;

                success:
                return true;
            }

            public static bool TryParse(string s, int sizeInBits, out ulong[] valColl, bool strictMode)
            {
                //sizeInBits must be a number such as 64, 128, 256, 512, or 1024.
                //If it is less than 64, the 'out ulong[] valColl' version of the parser should be used.
                if (sizeInBits < 64)
                    goto fail;

                if (s == null)
                    goto fail;

                var len = s.Length;

                //When the length is less than 16 bits, the string is not enough to express HashCode64,
                //so the string is illegal at this time.
                if (len < 16)
                    goto fail;

                //The length of ulong is 64 bits, so we get the number of members of ValColl through this calculation.
                var size = sizeInBits / 64;

                //idx      - represents the legal Hex character read in the current string.
                //idxOfStr - represents the character offset of the current string read.
                //wasXSeen - represents whether to finish reading the hexadecimal number prefix '0x'.
                int idx = 0, idxOfStr = -1;
                var wasXSeen = false;

                valColl = new ulong[size];

                int breakingBoundary, checkingBoundary, loopCounter;

                for (var idxOfValColl = 0; idxOfValColl < size; ++idxOfValColl)
                {
                    //Each character occupies 4 bits, so 64 bits correspond to 16 characters.
                    breakingBoundary = 16 * (idxOfValColl + 1);
                    checkingBoundary = 16 * idxOfValColl;
                    loopCounter = 0;

                    //When and only when the previous loop is executed (and the length reaches breakingBoundary),
                    //the current loop can be executed. After each loop, the value of idx will reach breakingBoundary.
                    //If it is less than breakingBoundary, it means that the length of the string is insufficient and the parsing is complete.
                    if (checkingBoundary != idx)
                    {
                        //If it is in strict mode, when the length of the string is insufficient, it will return the parsing failure.
                        if (strictMode)
                            goto fail;

                        //If it is not in strict mode, when the length of the string is insufficient, 0 is used for completion.
                        //At this point, it will no longer enter the parsing-loop body, but will return directly after completing all subsequent digits.
                        valColl[idxOfValColl] = 0;

                        if (idxOfValColl == size - 1)
                            goto success;

                        continue;
                    }

                    for (++idxOfStr; idxOfStr < len; ++idxOfStr)
                    {
                        var c = s[idxOfStr];

                        if (char.IsWhiteSpace(c))
                            continue;

                        switch (c)
                        {
                            case '0':
                            case '1':
                            case '2':
                            case '3':
                            case '4':
                            case '5':
                            case '6':
                            case '7':
                            case '8':
                            case '9':
                                UpdateForNumber(ref valColl[idxOfValColl], c);
                                break;

                            case 'a':
                            case 'b':
                            case 'c':
                            case 'd':
                            case 'e':
                            case 'f':
                                UpdateForLowerCaseLetter(ref valColl[idxOfValColl], c);
                                break;

                            case 'A':
                            case 'B':
                            case 'C':
                            case 'D':
                            case 'E':
                            case 'F':
                                UpdateForUpperCaseLetter(ref valColl[idxOfValColl], c);
                                break;

                            //The '0x' prefix is checked if and only if the ValColl index value is 0.
                            //If '0x' is encountered again in the middle, it is judged as an illegal Hex value.
                            case 'X':
                            case 'x':
                                if (!wasXSeen && idx == 1 && valColl[0] == 0)
                                {
                                    idx = 0;
                                    loopCounter = 0;
                                    wasXSeen = true;
                                    continue;
                                }

                                goto fail;

                            default:
                                goto fail;
                        }

                        //The loop counter is used to record the number of times the current loop is executed.
                        //When using strict mode, if the number of cycles is less than 16 times, it will be regarded as a failure.
                        ++loopCounter;

                        // Complete the calculation of the ValColl value at the current position,
                        // jump out of the loop, and execute the calculation of the next position.
                        if (++idx == breakingBoundary)
                            break;
                    }

                    //In strict mode, if the string parsing is completed,
                    //but the ValColl array fails to be assigned all the values, the return fails.
                    if (strictMode && idxOfValColl < size && idxOfStr >= len)
                        goto fail;

                    //In strict mode, if the loop counter does not loop 16 times, the parsing fails.
                    if (strictMode && loopCounter < 16)
                        goto fail;

                    if (idxOfValColl == size - 1)
                    {
                        for (++idxOfStr; idxOfStr < len; ++idxOfStr)
                            if (!char.IsWhiteSpace(s[idxOfStr]))
                                goto fail;

                        goto success;
                    }
                }

                fail:
                valColl = default;
                return false;

                success:
                return true;
            }

            private static void UpdateForNumber(ref ulong val, char c) => val = (val << 4) + c - '0';

            private static void UpdateForNumber(ref uint val, char c) => val = (val << 4) + c - '0';

            private static void UpdateForLowerCaseLetter(ref ulong val, char c) => val = (val << 4) + c - ((ulong)'a' - 0xA);

            private static void UpdateForLowerCaseLetter(ref uint val, char c) => val = (val << 4) + c - ((uint)'a' - 0xA);

            private static void UpdateForUpperCaseLetter(ref ulong val, char c) => val = (val << 4) + c - ((ulong)'A' - 0xA);

            private static void UpdateForUpperCaseLetter(ref uint val, char c) => val = (val << 4) + c - ((uint)'A' - 0xA);
        }

        internal static class InternalByteArrayConverter
        {
            public static byte[] ToBytes(int sizeInBits, params ulong[] longValColl)
            {
                var size = sizeInBits < 64 ? 1 : sizeInBits / 64;
                var lastBitLength = sizeInBits % 64;

                if (longValColl is null)
                    return new byte[0];

                if (longValColl.Length < size)
                    return new byte[0];

                var valueBytes = new byte[(sizeInBits + 7) / 8];
                var destinationIndex = 0;

                for (var i = 0; i < size; ++i)
                {
                    var value = longValColl[i];
                    var fragmentLength = lastBitLength;

                    if (i == size - 1)
                        value &= (ulong.MaxValue >> (64 - lastBitLength));
                    else
                        fragmentLength = 64 / 8;

                    var fragment = new byte[fragmentLength];

                    for (var x = 0; x < fragmentLength; ++x)
                    {
                        fragment[x] = (byte)value;
                        value >>= 8;
                    }

                    Array.Copy(fragment, 0, valueBytes, destinationIndex, fragmentLength);
                    destinationIndex += fragmentLength;
                }

                return valueBytes;
            }

            public static byte[] ToBytes(int sizeInBits, params uint[] intValColl)
            {
                var size = sizeInBits < 32 ? 1 : sizeInBits / 32;
                var lastBitLength = sizeInBits % 32;

                if (intValColl is null)
                    return new byte[0];

                if (intValColl.Length < size)
                    return new byte[0];

                var valueBytes = new byte[(sizeInBits + 7) / 8];
                var destinationIndex = 0;

                for (var i = 0; i < size; ++i)
                {
                    var value = intValColl[i];
                    var fragmentLength = lastBitLength;

                    if (i == size - 1)
                        value &= (uint.MaxValue >> (32 - lastBitLength));
                    else
                        fragmentLength = 32 / 8;

                    var fragment = new byte[fragmentLength];

                    for (var x = 0; x < fragmentLength; ++x)
                    {
                        fragment[x] = (byte)value;
                        value >>= 8;
                    }

                    Array.Copy(fragment, 0, valueBytes, destinationIndex, fragmentLength);
                    destinationIndex += fragmentLength;
                }

                return valueBytes;
            }

            public static byte[] ToBytes(int sizeInBits, params ushort[] intValColl)
            {
                var size = sizeInBits < 16 ? 1 : sizeInBits / 16;
                var lastBitLength = sizeInBits % 16;

                if (intValColl is null)
                    return new byte[0];

                if (intValColl.Length < size)
                    return new byte[0];

                var valueBytes = new byte[(sizeInBits + 7) / 8];
                var destinationIndex = 0;

                for (var i = 0; i < size; ++i)
                {
                    var value = intValColl[i];
                    var fragmentLength = lastBitLength;

                    if (i == size - 1)
                        value = (ushort)(value & (ushort.MaxValue >> (16 - lastBitLength)));
                    else
                        fragmentLength = 16 / 8;

                    var fragment = new byte[fragmentLength];

                    for (var x = 0; x < fragmentLength; ++x)
                    {
                        fragment[x] = (byte)value;
                        value >>= 8;
                    }

                    Array.Copy(fragment, 0, valueBytes, destinationIndex, fragmentLength);
                    destinationIndex += fragmentLength;
                }

                return valueBytes;
            }
        }
    }
}