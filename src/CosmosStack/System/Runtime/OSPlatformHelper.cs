using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace System.Runtime
{
    /// <summary>
    /// Operation system platform helper<br />
    /// 操作系统平台信息帮助者程序
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class OSPlatformHelper
    {
        /// <summary>
        /// Is current operation system Apple MacOS (OSX)<br />
        /// 当前操作系统是否是苹果 MacOS（OSX） 操作系统
        /// </summary>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static bool IsMacOS() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        /// <summary>
        /// Is current operation system Apple MacOS (OSX)<br />
        /// 当前操作系统是否是苹果 MacOS（OSX） 操作系统
        /// </summary>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static bool IsOSX() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        /// <summary>
        /// Is current operation system Microsoft Windows<br />
        /// 当前操作系统是否为微软视窗（Windows）操作系统
        /// </summary>
        /// <returns></returns>
        public static bool IsWindows() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        /// <summary>
        /// Is current operation system Linux system<br />
        /// 当前操作系统是否为 Linux 系统
        /// </summary>
        /// <returns></returns>
        public static bool IsLinux() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    }
}