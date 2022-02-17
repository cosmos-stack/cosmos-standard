namespace Cosmos.Workflow;

/// <summary>
/// Dynamic Forms Design Interface<br />
/// 动态表单设计稿接口<br />
/// 本接口用于 CosmosStack.Walker 和 CosmosStack.Flower
/// </summary>
public interface IDynamicFormsDesign
{
    /// <summary>
    /// Id<br />
    /// 编号
    /// </summary>
    string Id { get; set; }

    /// <summary>
    /// Name<br />
    /// 名称
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Display Title<br />
    /// 用于展示的标题
    /// </summary>
    string DisplayTitle { get; set; }

    /// <summary>
    /// Elements<br />
    /// 元素集合
    /// </summary>
    IList<IDynamicElementDesign> Elements { get; }
}