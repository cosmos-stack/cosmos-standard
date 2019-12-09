namespace Cosmos.Dependency {
    /// <summary>
    /// Register proxy type
    /// </summary>
    public enum RegisterProxyType {
        /// <summary>
        /// Type to type
        /// </summary>
        TypeToType,

        /// <summary>
        /// Type to instance
        /// </summary>
        TypeToInstance,

        /// <summary>
        /// Type to instance func
        /// </summary>
        TypeToInstanceFunc,

        /// <summary>
        /// Type self
        /// </summary>
        TypeSelf,

        /// <summary>
        /// Instance self
        /// </summary>
        InstanceSelf,

        /// <summary>
        /// Instance self func
        /// </summary>
        InstanceSelfFunc
    }
}