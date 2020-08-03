using System;

namespace Cosmos.Optionals
{
    /// <summary>
    /// Cosmos safe invoking extensions
    /// </summary>
    public static class CosmosSafeInvokingExtensions
    {
        /// <summary>
        /// Invoke the given <see cref="EventHandler"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="sender"></param>
        public static void SafeInvoke(this EventHandler handler, object sender) =>
            handler.SafeInvoke(sender, EventArgs.Empty);

        /// <summary>
        /// Invoke the given <see cref="EventHandler"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SafeInvoke(this EventHandler handler, object sender, EventArgs e) =>
            handler?.Invoke(sender, e);

        /// <summary>
        /// Invoke the given <see cref="EventHandler{TEventArgs}"/> in a safe way.<br />
        /// 以给定参数安全执行事件
        /// </summary>
        /// <typeparam name="TEventArgs"></typeparam>
        /// <param name="hander"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SafeInvoke<TEventArgs>(this EventHandler<TEventArgs> hander, object sender, TEventArgs e) =>
            hander?.Invoke(sender, e);
    }
}