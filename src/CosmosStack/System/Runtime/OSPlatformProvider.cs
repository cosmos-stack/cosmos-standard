using System.Runtime.InteropServices;

namespace System.Runtime
{
    /// <summary>
    /// Operation System Platform information provider<br />
    /// 用于获取 <see cref="OSPlatform"/> 信息的提供者程序
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class OSPlatformProvider : IOSPlatformProvider
    {
        /// <summary>
        /// Get current operation system platform information<br />
        /// 获取当前操作系统平台信息（<see cref="OSPlatform"/>）
        /// </summary>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public virtual OSPlatform GetCurrentOSPlatform()
        {
            if (OSPlatformHelper.IsMacOS())
                return OSPlatform.OSX;
            if (OSPlatformHelper.IsWindows())
                return OSPlatform.Windows;
            return OSPlatform.Linux;
        }
    }
}
