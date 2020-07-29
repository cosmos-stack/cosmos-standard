using System.Diagnostics;

namespace System.Reflection
{
    /// <summary>
    /// Cosmos <see cref="Assembly"/> extensions
    /// </summary>
    public static class CosmosAssemblyExtensions
    {
        /// <summary>
        /// Get assembly file version<br />
        /// 获取 Assembly 文件的版本
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static string GetFileVersion(this Assembly assembly) => FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
    }
}
