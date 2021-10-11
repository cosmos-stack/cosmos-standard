using System.Collections.Generic;

namespace CosmosStack.Verba.Boolean
{
    /// <summary>
    /// Interface for boolean verba <br />
    /// 布尔值 Verba 接口
    /// </summary>
    public interface IBooleanVerba : IVerba
    {
        /// <summary>
        /// True alias list <br />
        /// True 别名列表
        /// </summary>
        IList<string> TrueVerbaList { get; }

        /// <summary>
        /// False alias list <br />
        /// False 别名列表
        /// </summary>
        IList<string> FalseVerbaList { get; }
    }
}