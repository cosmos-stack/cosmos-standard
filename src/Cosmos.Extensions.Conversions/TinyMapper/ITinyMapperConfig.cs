namespace TinyMapper;

/// <summary>
/// Configuration for TinyMapper
/// </summary>
internal interface ITinyMapperConfig
{
    /// <summary>
    /// Custom name matching function used for auto bindings
    /// </summary>
    /// <param name="nameMatching">Function to match names</param>
    void NameMatching(Func<string, string, bool> nameMatching);

    /// <summary>
    /// Reset settings to default
    /// </summary>
    void Reset();
}