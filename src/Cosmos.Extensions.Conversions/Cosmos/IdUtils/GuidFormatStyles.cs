namespace Cosmos.IdUtils;

/// <summary>
/// Guid format styles <br />
/// GUID 格式样式
/// </summary>
public enum GuidFormatStyles
{
    /// <summary>
    /// B
    /// </summary>
    B,

    /// <summary>
    /// D
    /// </summary>
    D,

    /// <summary>
    /// N
    /// </summary>
    N,

    /// <summary>
    /// P
    /// </summary>
    P
}

internal static class GuidFormatStylesExtensions
{
    public static string X(this GuidFormatStyles styles)
    {
        return styles switch
        {
            GuidFormatStyles.B => "B",
            GuidFormatStyles.D => "D",
            GuidFormatStyles.N => "N",
            GuidFormatStyles.P => "P",
            _ => "N"
        };
    }
}