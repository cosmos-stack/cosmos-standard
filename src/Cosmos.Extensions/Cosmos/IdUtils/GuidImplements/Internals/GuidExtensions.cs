using System;
using Cosmos.IdUtils.GuidImplements.Core;

/*
 * Reference to:
 *      Nito.Guids
 *      Author: Stephen Cleary
 *      URL: https://github.com/StephenCleary/Guids
 *      MIT
 */

namespace Cosmos.IdUtils.GuidImplements.Internals
{
    internal static class GuidExtensions
    {
        /// <summary>
        /// Returns a 16-element byte array that contains the value of the GUID, in big-endian format.
        /// </summary>
        /// <param name="guid">The GUID.</param>
        public static byte[] ToBigEndianByteArray(this in Guid guid)
        {
            var result = guid.ToByteArray();
            GuidUtility.EndianSwap(result);
            return result;
        }

        /// <summary>
        /// Decodes a GUID into its fields.
        /// </summary>
        /// <param name="guid">The GUID to decode.</param>
        public static DecodedGuid Decode(this in Guid guid) => new DecodedGuid(guid);
    }
}
