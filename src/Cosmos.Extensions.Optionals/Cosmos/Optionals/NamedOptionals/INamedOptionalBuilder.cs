namespace Cosmos.Optionals.NamedOptionals
{
    /// <summary>
    /// Interface for named optional builder
    /// </summary>
    public interface INamedOptionalBuilder
    {
        /// <summary>
        /// May
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        INamedOptionalBuilder<T> May<T>(T value);

        /// <summary>
        /// May
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        INamedOptionalBuilder<T> May<T>(T value, string key);
    }
}