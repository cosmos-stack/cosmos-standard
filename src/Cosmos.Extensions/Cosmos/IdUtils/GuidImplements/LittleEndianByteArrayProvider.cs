using System;

namespace Cosmos.IdUtils.GuidImplements {
    internal static class LittleEndianByteArrayProvider {
        public static Guid Create(byte[] bytes) => new Guid(bytes);
    }
}