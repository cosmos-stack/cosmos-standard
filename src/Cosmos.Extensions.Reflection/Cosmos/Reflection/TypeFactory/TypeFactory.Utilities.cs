using System.Security.Cryptography;
using System.Text;

namespace Cosmos.Reflection;

internal static partial class TypeFactory
{
    private static string SignType(string input)
    {
        using var md5 = MD5.Create();
        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
        return BitConverter.ToString(hash);
    }
}