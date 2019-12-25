namespace Cosmos.Optionals.NamedOptionals {
    /// <summary>
    /// Interface for named optional builder
    /// </summary>
    public interface INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7> {
        /// <summary>
        /// Build
        /// </summary>
        /// <returns></returns>
        Maybe<T1, T2, T3, T4, T5, T6, T7> Build();
    }
}