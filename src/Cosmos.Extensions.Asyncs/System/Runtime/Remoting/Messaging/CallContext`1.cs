namespace System.Runtime.Remoting.Messaging {
    /// <summary>
    /// Call Context
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class CallContext<T> {
        /// <summary>
        /// Set data
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetData(string name, T value) {
#if NETFRAMEWORK
            CallContext.LogicalSetData(name, new ObjectHandle(value));
#else
            CallContext.SetData(name, value);
#endif
        }

        /// <summary>
        /// Get data
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetData(string name) {
#if NETFRAMEWORK
            var value = (CallContext.LogicalGetData(name) as ObjectHandle)?.Unwrap();
#else
            var value = CallContext.GetData(name);
#endif
            return value is T t ? t : default;
        }
    }
}