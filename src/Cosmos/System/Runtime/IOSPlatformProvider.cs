using System.Runtime.InteropServices;

namespace System.Runtime
{
    /// <summary>
    /// Interface of Operation System Platform information provider<br />
    /// 用于获取 <see cref="OSPlatform"/> 信息的提供者程序接口
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public interface IOSPlatformProvider
    {
        /// <summary>
        /// Get current operation system platform information<br />
        /// 获取当前操作系统平台信息（<see cref="OSPlatform"/>）
        /// </summary>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        OSPlatform GetCurrentOSPlatform();
    }
}