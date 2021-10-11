namespace CosmosStack.Optionals.NamedOptionals
{
    /// <summary>
    /// Interface for named optional builder
    /// </summary>
    public interface INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
        /// <summary>
        /// May
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T14"></typeparam>
        /// <returns></returns>
        INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> May<T14>(T14 value);

        /// <summary>
        /// May
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <typeparam name="T14"></typeparam>
        /// <returns></returns>
        INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> May<T14>(T14 value, string key);

        /// <summary>
        /// Build
        /// </summary>
        /// <returns></returns>
        Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Build();
    }
}