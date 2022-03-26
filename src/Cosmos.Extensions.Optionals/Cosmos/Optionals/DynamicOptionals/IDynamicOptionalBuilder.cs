namespace Cosmos.Optionals.DynamicOptionals;

/// <summary>
/// Interface for dynamic optional builder
/// </summary>
public interface IDynamicOptionalBuilder
{
    /// <summary>
    /// May
    /// </summary>
    /// <param name="value"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    IDynamicOptionalBuilder May(dynamic value, string key);

    /// <summary>
    /// Silence May
    /// </summary>
    /// <param name="value"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    IDynamicOptionalBuilder SilenceMay(dynamic value, string key);

    /// <summary>
    /// Build
    /// </summary>
    /// <returns></returns>
    DynamicMaybe Build();
}