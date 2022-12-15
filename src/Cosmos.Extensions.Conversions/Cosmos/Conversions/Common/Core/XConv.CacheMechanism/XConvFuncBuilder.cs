using System.Text;
using Cosmos.Conversions.ObjectMappingServices;
using Cosmos.Reflection;
using Natasha.CSharp.Compiler;
using Natasha.CSharp.MultiDomain.Extension;

namespace Cosmos.Conversions.Common.Core;

internal class XConvFuncBuilder<O, X>
{
    public Func<O, X, CastingContext, IObjectMapper, X> Build()
    {
        return NDelegate.UseDomain(typeof(XConv).GetDomain(), b => b.ConfigCompilerOption(opt => opt.SetCompilerFlag(CompilerBinderFlags.IgnoreAccessibility | CompilerBinderFlags.IgnoreCorLibraryDuplicatedTypes)))
                        .ConfigClass(@class => @class.AllowPrivate(typeof(XConv)))
                        .ConfigUsing("Cosmos.Conversions.DynamicXConvServices")
                        .Func<O, X, CastingContext, IObjectMapper, X>(GetScript());
    }

    private bool HasCustomConvertHandler { get; set; }

    public void SetCustomConvertHandler(Func<object, object> handler)
    {
        HasCustomConvertHandler = handler is not null;
        XConvFuncHelper<O, X>.CustomConvertHandler = handler;
    }

    public string GetScript()
    {
        // arg1: 源类型的实例，对应 from
        // arg2: 目标类型的默认值实例，对应为 defaultVal
        // arg3: 转换上下文 CastingContext，对应为 context
        // arg4: 对象映射器 IObjectMapper，对应为 mapper

        var builder = new StringBuilder();
        var oType = typeof(O);
        var xType = typeof(X);
        var h = typeof(XConvFuncHelper).GetDevelopName();
        var o = typeof(O).GetDevelopName();
        var x = typeof(X).GetDevelopName();
        var oTypeNullableFlag = Types.IsNullableType(oType);
        var xTypeNullableFlag = Types.IsNullableType(xType);
        var oTypeNullableFlagVal = XConvFuncHelper.BooleanToString(oTypeNullableFlag);
        var xTypeNullableFlagVal = XConvFuncHelper.BooleanToString(xTypeNullableFlag);

        builder.AppendLine($"""
{h}.FixContext(ref arg3);
{h}<{o},{x}>.FixTargetDefaultVal(ref arg2);
if(arg1 is null) return arg2;
""");

        if (o == x)
        {
            builder.AppendLine("return arg1.AsOrDefault(arg2);");
        }

        else if (HasCustomConvertHandler)
        {
            builder.AppendLine($"{h}<{o},{x}>.CustomConvertHandler?.Invoke(arg1).As<{x}>() ?? arg2;");
        }

        else if (oType == TypeClass.StringClazz)
        {
            builder.AppendLine($"return {XConvFuncHelper.XConvString}.FromStringTo<{x}>(arg1,typeof({x}),{xTypeNullableFlagVal},arg2);");
        }

        else if (oType == TypeClass.BooleanClazz || oType == TypeClass.BooleanNullableClazz)
        {
            builder.AppendLine($"return {XConvFuncHelper.XConvString}.FromBooleanTo<{x}>(arg1,arg3,typeof({x}),{xTypeNullableFlagVal},arg2);");
        }

        else if (oType == TypeClass.DateTimeClazz || oType == TypeClass.DateTimeNullableClazz)
        {
            builder.AppendLine($"return {XConvFuncHelper.XConvString}.FromDateTimeTo<{x}>(arg1,arg3,typeof({x}),{xTypeNullableFlagVal},arg2);");
        }

        else if (TypeDeterminer.IsEnumType(oType))
        {
            builder.AppendLine($"return {XConvFuncHelper.XConvString}.FromEnumTo<{x}>(typeof({o}),arg1,arg3,typeof({x}),{xTypeNullableFlagVal},arg2);");
        }

        else if (TypeDeterminer.IsNullableNumericType(oType) || Types.IsNumericType(oType))
        {
            builder.AppendLine($"return {XConvFuncHelper.XConvString}.FromNumericTo<{x}>(typeof({o}),{oTypeNullableFlagVal},arg1,arg3,typeof({x}),{xTypeNullableFlagVal},arg2);");
        }

        else if (TypeDeterminer.IsGuidType(oType))
        {
            builder.AppendLine($"return {XConvFuncHelper.XConvString}.FromGuidTo<{x}>(arg1,arg3,typeof({x}),{xTypeNullableFlagVal},arg2);");
        }

        else if (TypeDeterminer.IsNullableGuidType(oType))
        {
            builder.AppendLine($"return {XConvFuncHelper.XConvString}.FromNullableGuidTo<{x}>(arg1.As<Guid?>(),arg3,typeof({x}),{xTypeNullableFlagVal},arg2);");
        }

        else if (Types.IsInterfaceDefined<IConvertible>(oType))
        {
            builder.AppendLine($"return System.Convert.ChangeType(arg1,typeof({x})).AsOrDefault<{x}>(arg2);");
        }

        else if (oType == TypeClass.ObjectClazz)
        {
            builder.AppendLine($"return {XConvFuncHelper.XConvString}.FromObjTo<{x}>(arg1,arg3,typeof({x}),{xTypeNullableFlagVal},arg2);");
        }

        else if (xType == TypeClass.ObjectClazz)
        {
            builder.AppendLine($"return arg1.AsOrDefault<{x}>(arg2);");
        }

        else if (xType.IsAssignableFrom(oType))
        {
            builder.AppendLine($"return arg1.AsOrDefault<{x}>(arg2);");
        }
        else
        {
            builder.AppendLine($@"
if(arg4 is not null) return arg4.MapTo<{o},{x}>(arg1);
try {{ return arg1.As<{x}>(); }} catch {{
  try {{ return {XConvFuncHelper.DefaultObjectMapperString}.Instance.MapTo<{o},{x}>(arg1); }} catch {{
    return {(xTypeNullableFlag ? $"default({x})" : "arg2")};
  }}
}}
");
        }

        return builder.ToString();
    }
}