namespace Cosmos.Optionals.NamedOptionals;

/// <summary>
/// Interface for named optional builder
/// </summary>
public interface INamedOptionalBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>
{
    /// <summary>
    /// Build
    /// </summary>
    /// <returns></returns>
    Maybe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19> Build();
}