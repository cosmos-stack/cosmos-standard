namespace CosmosStack.Optionals
{
    /// <summary>
    /// Interface for optional <br />
    /// MayBe 组件接口
    /// </summary>
    public interface IOptional
    {
        /// <summary>
        /// Key <br />
        /// 键
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Has value <br />
        /// 标志是否存在值
        /// </summary>
        bool HasValue { get; }
    }
}