using CosmosStack.Optionals.NamedOptionals;

namespace CosmosStack.Optionals
{
    /// <summary>
    /// Optional utilities <br />
    /// MayBe 组件工具
    /// </summary>
    public static partial class Optional
    {
        /// <summary>
        /// Get an instance of builder, to build a named Maybe.  <br />
        /// 创建一个构建器实例，用于构建一个具名 MayBe 组件
        /// </summary>
        public static INamedOptionalBuilder Named => NamedOptionalBuilder.Create();
    }
}