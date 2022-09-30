namespace Cosmos.Verba.Boolean;

/// <summary>
/// Default global boolean verba <br />
/// 默认的全局布尔值 Verba 器
/// </summary>
internal class DefaultBooleanVerba : IBooleanVerba
{
    static DefaultBooleanVerba()
    {
        Instance = new();
    }

    /// <summary>
    /// Get a default global boolean verba instance <br />
    /// 获取一个默认的全局布尔值 Verba 器实例
    /// </summary>
    public static DefaultBooleanVerba Instance { get; }

    private DefaultBooleanVerba() { }

    /// <summary>
    /// Verba name <br />
    /// Verba 名称
    /// </summary>
    public string VerbaName => "DefaultBooleanVerba";

    /// <summary>
    /// True alias list <br />
    /// True 的别名列表
    /// </summary>
    public List<string> TrueVerbaList { get; } = new() { "1", "yes", "yep", "ok" };

    /// <summary>
    /// False alias list <br />
    /// False 的别名列表
    /// </summary>
    public List<string> FalseVerbaList { get; } = new() { "0", "no", "nope" };
}