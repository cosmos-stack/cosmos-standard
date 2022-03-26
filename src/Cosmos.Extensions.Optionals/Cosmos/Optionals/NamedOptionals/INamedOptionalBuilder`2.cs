namespace Cosmos.Optionals.NamedOptionals;

/// <summary>
/// Interface for named optional builder
/// </summary>
public interface INamedOptionalBuilder<T1, T2>
{
    /// <summary>
    /// May
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T3"></typeparam>
    /// <returns></returns>
    INamedOptionalBuilder<T1, T2, T3> May<T3>(T3 value);

    /// <summary>
    /// May
    /// </summary>
    /// <param name="value"></param>
    /// <param name="key"></param>
    /// <typeparam name="T3"></typeparam>
    /// <returns></returns>
    INamedOptionalBuilder<T1, T2, T3> May<T3>(T3 value, string key);

    /// <summary>
    /// Build
    /// </summary>
    /// <returns></returns>
    Maybe<T1, T2> Build();
}