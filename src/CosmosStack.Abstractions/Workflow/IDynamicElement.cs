namespace Cosmos.Workflow;

/// <summary>
/// Dynamic Element Interface<br />
/// 动态元素接口<br />
/// 本接口用于 CosmosStack.Walker
/// </summary>
public interface IDynamicElement
{
    /// <summary>
    /// Id<br />
    /// 编号
    /// </summary>
    string Id { get; }
}