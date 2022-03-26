using Cosmos.Optionals.DynamicOptionals;

namespace Cosmos.Optionals;

/// <summary>
/// Optional utilities <br />
/// MayBe 组件工具
/// </summary>
public static partial class Optional
{
    /// <summary>
    /// Get an instance of builder, to build a dynamic Maybe. <br />
    /// 创建一个构建器实例，用于构建一个动态 MayBe 组件
    /// </summary>
    public static IDynamicOptionalBuilder Dynamic => DynamicOptionalBuilder.Create();
}