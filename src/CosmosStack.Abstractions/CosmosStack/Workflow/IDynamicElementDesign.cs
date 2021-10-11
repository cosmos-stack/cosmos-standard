namespace CosmosStack.Workflow
{
    /// <summary>
    /// Dynamic Element Design Interface<br />
    /// 动态元素设计接口<br />
    /// 本接口用于 CosmosStack.Walker 与 CosmosStack.Flower
    /// </summary>
    public interface IDynamicElementDesign
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
        /// 用于显示的标题
        /// </summary>
        string DisplayTitle { get; set; }
    }
}