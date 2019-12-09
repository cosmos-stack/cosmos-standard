using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace Cosmos.Serialization.Binary {
    internal static class BinaryManager {
        [ThreadStatic]
        private static BinaryFormatter _binaryFormatter;

        public static BinaryFormatter GetBinaryFormatter() {
            return _binaryFormatter ??= new BinaryFormatter();
        }
    }
}