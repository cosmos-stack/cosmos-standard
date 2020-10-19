using System.IO;
using System.Threading.Tasks;

namespace Cosmos.IO
{
    public static class FileHelper
    {
        public static byte[] Read(string targetFilePath)
        {
            if (!File.Exists(targetFilePath))
                return null;

            using var fs = new FileStream(targetFilePath, FileMode.Open, FileAccess.Read);
            var byteArray = new byte[fs.Length];
            fs.Read(byteArray, 0, byteArray.Length);
            return byteArray;
        }

        public static async Task<byte[]> ReadAsync(string targetFilePath)
        {
            if (!File.Exists(targetFilePath))
                return null;

#if NETSTANDARD2_1 || NETCOREAPP3_0 || NETCOREAPP3_1
            await using var fs = new FileStream(targetFilePath, FileMode.Open, FileAccess.Read);
#else
            using var fs = new FileStream(targetFilePath, FileMode.Open, FileAccess.Read);
#endif
            var byteArray = new byte[fs.Length];
            await fs.ReadAsync(byteArray, 0, byteArray.Length);
            return byteArray;
        }

        public static bool Read(byte[] byteArray, string targetFilePath, bool appendMode = false)
        {
            if (!appendMode && File.Exists(targetFilePath))
            {
                File.Create(targetFilePath);
            }

            var fileMode = appendMode ? FileMode.Append : FileMode.Open;
            using var fs = new FileStream(targetFilePath, fileMode, FileAccess.Write);
            return fs.TryWrite(byteArray, 0, byteArray.Length);
        }

        public static async Task<bool> ReadAsync(byte[] byteArray, string targetFilePath, bool appendMode = false)
        {
            if (!appendMode && File.Exists(targetFilePath))
            {
                File.Create(targetFilePath);
            }

            var fileMode = appendMode ? FileMode.Append : FileMode.Open;
#if NETSTANDARD2_1 || NETCOREAPP3_0 || NETCOREAPP3_1
            await using var fs = new FileStream(targetFilePath, fileMode, FileAccess.Write);
#else
            using var fs = new FileStream(targetFilePath, fileMode, FileAccess.Write);
#endif
            return await fs.TryWriteAsync(byteArray, 0, byteArray.Length);
        }
    }
}