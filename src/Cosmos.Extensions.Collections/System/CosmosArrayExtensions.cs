namespace System
{
    /// <summary>
    /// Cosmos Array extensions
    /// </summary>
    public static class CosmosArrayExtensions
    {
        /// <summary>
        /// Copy array
        /// </summary>
        public static byte[,] Copy(this byte[,] bytes)
        {
            int width = bytes.GetLength(0),
                height = bytes.GetLength(1);
            var newBytes = new byte[width, height];
            Array.Copy(bytes, newBytes, bytes.Length);
            return newBytes;
        }

        /// <summary>
        /// Copy array
        /// </summary>
        public static byte[,,] Copy(this byte[,,] bytes)
        {
            int x = bytes.GetLength(0),
                y = bytes.GetLength(1),
                z = bytes.GetLength(2);
            var newBytes = new byte[x, y, z];
            Array.Copy(bytes, newBytes, bytes.Length);
            return newBytes;
        }
    }
}