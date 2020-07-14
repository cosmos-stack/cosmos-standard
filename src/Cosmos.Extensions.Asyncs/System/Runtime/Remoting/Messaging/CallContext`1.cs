namespace System.Runtime.Remoting.Messaging
{
    /*
     * 本扩展现已不再支持 .NET Framework。
     * 本注释用于展示兼容性写法。
     *
     * void SetData(string name, T value)
     *     for nfx:
     *         CallContext.LogicalSetData(name, new ObjectHandle(value));
     *     for core:
     *         CallContext.SetData(name, value);
     *
     * T GetData(string name)
     *     for nfx:
     *         var value = (CallContext.LogicalGetData(name) as ObjectHandle)?.Unwrap();
     *         return value is T t ? t : default;
     *     for core:
     *         var value = CallContext.GetData(name);
     *         return value is T t ? t : default;
     * 
     */

    /// <summary>
    /// Call Context
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class CallContext<T>
    {
        /// <summary>
        /// Set data
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetData(string name, T value) => CallContext.SetData(name, value);

        /// <summary>
        /// Get data
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetData(string name) => CallContext.GetData(name) is T t ? t : default;
    }
}