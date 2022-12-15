using Cosmos.Conversions.ObjectMappingServices;

namespace Cosmos.Conversions.Common.Core;

internal static class XConvFuncHelper
{
    public static readonly string DefaultObjectMapperString = typeof(DefaultObjectMapper).GetDevelopName();

    public static readonly string XConvString = typeof(XConv).GetDevelopName();

    /// <summary>
    /// 修正 CastingContext 的值，如果为空则使用默认值
    /// </summary>
    /// <param name="context"></param>
    public static void FixContext(ref CastingContext context)
    {
        context ??= CastingContext.DefaultContext;
    }

    public static string BooleanToString(bool boolean)
    {
        return boolean ? "true" : "false";
    }
}

internal static class XConvFuncHelper<O, X>
{
    /// <summary>
    /// 修正目标类型默认值
    /// </summary>
    /// <param name="defaultVal"></param>
    public static void FixTargetDefaultVal(ref X defaultVal)
    {
        if (typeof(X).IsValueType && defaultVal is null)
            defaultVal = Activator.CreateInstance<X>();
    }

    public static Func<object, object> CustomConvertHandler { get; set; }
}