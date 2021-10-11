namespace CosmosStack.Optionals.NamedOptionals
{
    /// <summary>
    /// Interface for named optional builder
    /// </summary>
    public interface INamedOptionalBuilder<T1, T2, T3, T4, T5, T6>
    {
        /// <summary>
        /// May
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7> May<T7>(T7 value);

        /// <summary>
        /// May
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7> May<T7>(T7 value, string key);

        /// <summary>
        /// Build
        /// </summary>
        /// <returns></returns>
        Maybe<T1, T2, T3, T4, T5, T6> Build();
    }
}