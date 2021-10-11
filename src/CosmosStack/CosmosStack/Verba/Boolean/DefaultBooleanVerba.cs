using System.Collections.Generic;

namespace CosmosStack.Verba.Boolean
{
    /// <summary>
    /// Default global boolean verba <br />
    /// 默认的全局布尔值 Verba 器
    /// </summary>
    public class DefaultBooleanVerba : IBooleanVerba
    {
        static DefaultBooleanVerba()
        {
            Instance = new DefaultBooleanVerba();
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
        public string VerbaName { get; } = "DefaultBooleanVerba";

        /// <summary>
        /// True alias list <br />
        /// True 的别名列表
        /// </summary>
        public IList<string> TrueVerbaList { get; } = new List<string> {"1", "yes", "yep", "ok"};

        /// <summary>
        /// False alias list <br />
        /// False 的别名列表
        /// </summary>
        public IList<string> FalseVerbaList { get; } = new List<string> {"0", "no", "nope"};
    }
}