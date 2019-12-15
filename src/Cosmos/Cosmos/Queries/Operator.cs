using System.ComponentModel;

namespace Cosmos.Queries {
    /// <summary>
    /// Operator
    /// </summary>
    public enum Operator {
        /// <summary>
        /// Equals
        /// </summary>
        [Description("等于")]
        Equal,

        /// <summary>
        /// NotEqual
        /// </summary>
        [Description("不等于")]
        NotEqual,

        /// <summary>
        /// Greater
        /// </summary>
        [Description("大于")]
        Greater,

        /// <summary>
        /// GreaterEqual
        /// </summary>
        [Description("大于等于")]
        GreaterEqual,

        /// <summary>
        /// Less
        /// </summary>
        [Description("小于")]
        Less,

        /// <summary>
        /// LessEqual
        /// </summary>
        [Description("小于等于")]
        LessEqual,

        /// <summary>
        /// Starts
        /// </summary>
        [Description("头匹配")]
        Starts,

        /// <summary>
        /// Ends
        /// </summary>
        [Description("尾匹配")]
        Ends,

        /// <summary>
        /// Contains
        /// </summary>
        [Description("包含")]
        Contains
    }
}