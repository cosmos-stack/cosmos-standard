using System;
using System.Diagnostics;
using System.Reflection;

namespace Cosmos.Reflection
{
    public static class AssemblyVisit
    {
        /// <summary>
        /// Get assembly file version.<br />
        /// 获取 Assembly 文件的版本
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static string GetFileVersion(Assembly assembly) => V(assembly).FileVersion;

        /// <summary>
        /// Get assembly product version.<br />
        /// 获取 Assembly 文件的产品版本 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetProductVersion(Assembly assembly) => V(assembly).ProductVersion;

        private static FileVersionInfo V(Assembly assembly)
        {
            if (assembly is null)
                throw new ArgumentNullException(nameof(assembly));
            return FileVersionInfo.GetVersionInfo(assembly.Location);
        }
    }
}