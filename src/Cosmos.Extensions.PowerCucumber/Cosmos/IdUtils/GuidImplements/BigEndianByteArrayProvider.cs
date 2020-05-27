using System;
using Cosmos.IdUtils.GuidImplements.Internals;

namespace Cosmos.IdUtils.GuidImplements
{
    internal static class BigEndianByteArrayProvider
    {
        public static Guid Create(byte[] bytes) => new Guid(GuidUtility.CopyWithEndianSwap(bytes));
    }
}