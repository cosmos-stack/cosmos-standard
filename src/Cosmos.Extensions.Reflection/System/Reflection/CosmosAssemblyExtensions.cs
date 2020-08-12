using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.DependencyModel;

namespace System.Reflection
{
    /// <summary>
    /// Cosmos <see cref="Assembly"/> extensions
    /// </summary>
    public static class CosmosAssemblyExtensions
    {
        /// <summary>
        /// Get assembly file version.<br />
        /// 获取 Assembly 文件的版本
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static string GetFileVersion(this Assembly assembly)
        {
            if (assembly is null)
                throw new ArgumentNullException(nameof(assembly));
            return FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
        }

        /// <summary>
        /// Get assembly product version.<br />
        /// 获取 Assembly 文件的产品版本 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetProductVersion(this Assembly assembly)
        {
            if (assembly is null)
                throw new ArgumentNullException(nameof(assembly));
            return FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;
        }

        /// <summary>
        /// Get CLI version. <br />
        /// 获取 CLI 版本号
        /// </summary>
        public static string GetCliVersion()
        {
            string[] dllNames =
            {
                "Microsoft.EntityFrameworkCore",
                "Microsoft.Extensions.Configuration.Binder",
                "Microsoft.Extensions.DependencyInjection",
                "Microsoft.Extensions.DependencyInjection.Abstractions",
                "Microsoft.Extensions.Configuration.Abstractions"
            };

            CompilationLibrary lib = null;

            foreach (var dllName in dllNames)
            {
                lib = DependencyContext.Default.CompileLibraries.FirstOrDefault(m => m.Name == dllName);

                if (lib != null) break;
            }

            var cliVersion = lib?.Version;

            return cliVersion;
        }
    }
}