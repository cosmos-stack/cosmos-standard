namespace Cosmos.Optionals.NamedOptionals {
    /// <summary>
    /// Interface for named optional builder
    /// </summary>
    public interface INamedOptionalBuilder<T> {
        /// <summary>
        /// May
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        INamedOptionalBuilder<T, T2> May<T2>(T2 value);
        
        /// <summary>
        /// May
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        INamedOptionalBuilder<T, T2> May<T2>(T2 value, string key);

        /// <summary>
        /// Build
        /// </summary>
        /// <returns></returns>
        Maybe<T> Build();
    }
}