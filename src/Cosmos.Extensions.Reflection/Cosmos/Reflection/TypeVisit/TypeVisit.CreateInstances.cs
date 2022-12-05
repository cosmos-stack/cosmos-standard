using Cosmos.Collections;
using Cosmos.Dynamic;

#if !NET451 && !NET452
using System.Text;
using System.Collections.Concurrent;
using BTFindTree;

#endif

// ReSharper disable InconsistentNaming

namespace Cosmos.Reflection;

#region Argument Description

/// <summary>
/// Argument description value interface <br />
/// 参数描述值接口
/// </summary>
public interface IArgDescriptionVal
{
    /// <summary>
    /// Name <br />
    /// 名称
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Type <br />
    /// 类型
    /// </summary>
    Type Type { get; }

    /// <summary>
    /// Descriptor of argument <br />
    /// 参数描述
    /// </summary>
    /// <returns></returns>
    ArgumentDescriptor ToDescriptor();
}

/// <summary>
/// Argument description value <br />
/// 参数描述值
/// </summary>
/// <typeparam name="T"></typeparam>
public class ArgumentDescriptionVal<T> : IArgDescriptionVal
{
    public ArgumentDescriptionVal(string name, T value)
    {
        Name = name;
        Value = value;
        Type = typeof(T);
    }

    /// <inheritdoc />
    public string Name { get; }

    /// <summary>
    /// Argument value <br />
    /// 参数值
    /// </summary>
    public T Value { get; }

    /// <inheritdoc />
    public Type Type { get; }

    /// <summary>
    /// Convert to descriptor <br />
    /// 转换为描述符
    /// </summary>
    /// <returns></returns>
    public ArgumentDescriptor ToDescriptor()
    {
        return new(Name, Value, Type);
    }
}

/// <summary>
/// Descriptor of argument <br />
/// 参数描述
/// </summary>
public class ArgumentDescriptor
{
    /// <summary>
    /// Create a new instance of <see cref="ArgumentDescriptor"/>.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <param name="type"></param>
    public ArgumentDescriptor(string name, object value, Type type)
    {
        Name = name;
        Value = value;
        Type = type;
    }

    /// <summary>
    /// Argument name <br />
    /// 参数名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Argument value <br />
    /// 参数值
    /// </summary>
    public object Value { get; set; }

    /// <summary>
    /// Argument type <br />
    /// 参数类型
    /// </summary>
    public Type Type { get; set; }

    public static implicit operator ArgumentDescriptor((string Name, object Value, Type Type) tuple)
    {
        return new(tuple.Name, tuple.Value, tuple.Type);
    }

    public static implicit operator (string Name, object Value, Type Type)(ArgumentDescriptor descriptor)
    {
        return (descriptor.Name, descriptor.Value, descriptor.Type);
    }

    /// <summary>
    /// Empty Args <br />
    /// 空参数
    /// </summary>
    public static IEnumerable<ArgumentDescriptor> EmptyArguments => Enumerable.Empty<ArgumentDescriptor>();
}

/// <summary>
/// Argument descriptor extensions <br />
/// 参数描述符扩展
/// </summary>
public static class ArgumentDescriptorExtensions
{
    /// <summary>
    /// Convert to descriptors <br />
    /// 转换为描述符
    /// </summary>
    /// <param name="descriptionVals"></param>
    /// <returns></returns>
    public static IEnumerable<ArgumentDescriptor> ToDescriptors(this IEnumerable<IArgDescriptionVal> descriptionVals)
    {
        return descriptionVals.Select(val => val.ToDescriptor());
    }

    /// <summary>
    /// Convert to dictionary <br />
    /// 转换为字典
    /// </summary>
    /// <param name="descriptionVals"></param>
    /// <returns></returns>
    public static Dictionary<string, IArgDescriptionVal> ToDictionary(this IEnumerable<IArgDescriptionVal> descriptionVals)
    {
        var d = new Dictionary<string, IArgDescriptionVal>();

        foreach (var val in descriptionVals)
        {
            d.AddValueOrOverride(val.Name, val);
        }

        return d;
    }
}

#endregion

/// <summary>
/// Type visit, an advanced TypeReflections utility. <br />
/// 类型访问器，一个高级的 TypeReflections 工具。
/// </summary>
public static partial class TypeVisit
{
    #region Create Instance

    /// <summary>
    /// Create a new instance <br />
    /// 创建实例
    /// </summary>
    /// <param name="type"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static object CreateInstance(Type type, params object[] args)
    {
        if (type is null)
            throw new ArgumentNullException(nameof(type));
        return CreateInstanceImpl(type, args);
    }

    /// <summary>
    /// Create a new instance <br />
    /// 创建实例
    /// </summary>
    /// <param name="args"></param>
    /// <typeparam name="TInstance"></typeparam>
    /// <returns></returns>
    public static TInstance CreateInstance<TInstance>(params object[] args)
    {
        return CreateInstanceImpl(Types.Of<TInstance>(), args).AsOrDefault<TInstance>();
    }

    /// <summary>
    /// Create a new instance <br />
    /// 创建实例
    /// </summary>
    /// <param name="type"></param>
    /// <param name="args"></param>
    /// <typeparam name="TInstance"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static TInstance CreateInstance<TInstance>(Type type, params object[] args)
    {
        if (type is null)
            throw new ArgumentNullException(nameof(type));
        return CreateInstanceImpl(type, args).AsOrDefault<TInstance>();
    }

    private static object CreateInstanceImpl(Type type, params object[] args)
    {
        return args is null || args.Length == 0
            ? type.GetConstructor(Type.EmptyTypes)?.GetReflector().Invoke()
            : type.GetConstructor(Types.Of(args))?.GetReflector().Invoke(args);
    }

#if !NET451 && !NET452
    /// <summary>
    /// Create a new instance <br />
    /// 创建实例
    /// </summary>
    /// <param name="arguments"></param>
    /// <typeparam name="TInstance"></typeparam>
    /// <returns></returns>
    public static TInstance CreateInstance<TInstance>(IEnumerable<ArgumentDescriptor> arguments)
    {
        return IsNoneParams(arguments, out var descriptors)
            ? CreateInstance<TInstance>()
            : CreateInstanceImpl(typeof(TInstance), descriptors).AsOrDefault<TInstance>();
    }

    /// <summary>
    /// Create a new instance <br />
    /// 创建实例
    /// </summary>
    /// <param name="type"></param>
    /// <param name="arguments"></param>
    /// <typeparam name="TInstance"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static TInstance CreateInstance<TInstance>(Type type, IEnumerable<ArgumentDescriptor> arguments)
    {
        if (type is null)
            throw new ArgumentNullException(nameof(type));
        return IsNoneParams(arguments, out var descriptors)
            ? CreateInstance<TInstance>()
            : CreateInstanceImpl(type, descriptors).AsOrDefault<TInstance>();
    }

    /// <summary>
    /// Create a new instance <br />
    /// 创建实例
    /// </summary>
    /// <param name="type"></param>
    /// <param name="arguments"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static object CreateInstance(Type type, IEnumerable<ArgumentDescriptor> arguments)
    {
        if (type is null)
            throw new ArgumentNullException(nameof(type));
        return IsNoneParams(arguments, out var descriptors)
            ? CreateInstance(type)
            : CreateInstanceImpl(type, descriptors);
    }

    private static object CreateInstanceImpl(Type type, IEnumerable<ArgumentDescriptor> arguments)
    {
        var template = CtorTypeMakingCache.GetOrCache(type, CtorTypeMakingHelper.Template.Create);
        return template.CreateInstance(arguments);
    }

    private static bool IsNoneParams(IEnumerable<ArgumentDescriptor> arguments, out List<ArgumentDescriptor> descriptors)
    {
        descriptors = null;
        if (arguments is null) return true;
        descriptors = arguments.ToList();
        return !descriptors.Any();
    }

    /// <summary>
    /// Ctor matched result <br />
    /// 构造参数命中结构
    /// </summary>
    public readonly struct CtorMatchedResult
    {
        /// <summary>
        /// Ctor matched result
        /// </summary>
        /// <param name="values"></param>
        /// <param name="index"></param>
        public CtorMatchedResult(object[] values, int index)
        {
            Values = values;
            Index = index;
        }

        /// <summary>
        /// Values <br />
        /// 值
        /// </summary>
        public readonly object[] Values;

        /// <summary>
        /// Index <br />
        /// 索引
        /// </summary>
        public readonly int Index;
    }
#endif

    #endregion

    #region Create Instance for Dynamic Type

    public static object CreateInstance(IDictionary<string, object> values)
    {
        var properties = values.ToDictionary(_ => _.Key, _ => _.Value.GetType());
        var dynamicType = TypeFactory.CreateType(properties);
        var @object = (DynamicBase)Activator.CreateInstance(dynamicType)!;
        foreach (var item in values)
            @object.SetPropertyValue(item.Key, item.Value);
        return @object;
    }

    #endregion
}

/// <summary>
/// Type visit extensions <br />
/// 类型访问器扩展
/// </summary>
public static partial class TypeVisitExtensions
{
    /// <summary>
    /// Create an instance of the specified type.<br />
    /// 创建指定类型的实例。
    /// </summary>
    /// <typeparam name="TInstance"></typeparam>
    /// <param name="type"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static TInstance CreateInstance<TInstance>(this Type type, params object[] args)
    {
        return TypeVisit.CreateInstance<TInstance>(type, args);
    }

    /// <summary>
    /// Create an instance of the specified type.<br />
    /// 创建指定类型的实例。
    /// </summary>
    /// <param name="type"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static object CreateInstance(this Type type, params object[] args)
    {
        return TypeVisit.CreateInstance(type, args);
    }

    /// <summary>
    /// Create an instance of the specified type.<br />
    /// 创建指定类型的实例。
    /// </summary>
    /// <param name="type"></param>
    /// <param name="arguments"></param>
    /// <typeparam name="TInstance"></typeparam>
    /// <returns></returns>
    public static TInstance CreateInstance<TInstance>(this Type type, IEnumerable<ArgumentDescriptor> arguments)
    {
        return TypeVisit.CreateInstance<TInstance>(type, arguments);
    }

    /// <summary>
    /// Create an instance of the specified type.<br />
    /// 创建指定类型的实例。
    /// </summary>
    /// <param name="type"></param>
    /// <param name="argument"></param>
    /// <param name="arguments"></param>
    /// <typeparam name="TInstance"></typeparam>
    /// <returns></returns>
    public static TInstance CreateInstance<TInstance>(this Type type, ArgumentDescriptor argument, params ArgumentDescriptor[] arguments)
    {
        var descriptors = arguments.ToList();
        descriptors.Insert(0, argument);
        return TypeVisit.CreateInstance<TInstance>(type, descriptors);
    }

    /// <summary>
    /// Create an instance of the specified type.<br />
    /// 创建指定类型的实例。
    /// </summary>
    /// <param name="type"></param>
    /// <param name="arguments"></param>
    /// <returns></returns>
    public static object CreateInstance(this Type type, IEnumerable<ArgumentDescriptor> arguments)
    {
        return TypeVisit.CreateInstance(type, arguments);
    }

    /// <summary>
    /// Create an instance of the specified type.<br />
    /// 创建指定类型的实例。
    /// </summary>
    /// <param name="type"></param>
    /// <param name="argument"></param>
    /// <param name="arguments"></param>
    /// <returns></returns>
    public static object CreateInstance(this Type type, ArgumentDescriptor argument, params ArgumentDescriptor[] arguments)
    {
        var descriptors = arguments.ToList();
        descriptors.Insert(0, argument);
        return TypeVisit.CreateInstance(type, descriptors);
    }
}

internal static class CtorTypeMakingHelper
{
    internal class Template
    {
        public readonly ConstructorInfo[] _ctors;
        public readonly Dictionary<ConstructorInfo, int> _ctorIndexMap;
        public readonly Dictionary<string, List<(ConstructorInfo, ParameterInfo)>> _nameConstructorMap;
        public readonly int _defaultCtorIndex;
        public readonly Func<object[], object>[] _creators;
        public readonly string _typeFullQualifiedName;
        public readonly Func<IEnumerable<ArgumentDescriptor>, TypeVisit.CtorMatchedResult> GetIndex;

        private Template(Type type)
        {
            _ctors = type.GetConstructors();
            _ctorIndexMap = new Dictionary<ConstructorInfo, int>();
            _nameConstructorMap = new Dictionary<string, List<(ConstructorInfo, ParameterInfo)>>();
            _creators = new Func<object[], object>[_ctors.Length];
            _typeFullQualifiedName = type.GetDevelopName();

            var maxParametersCount = 0;

            for (var index = 0; index < _ctors.Length; ++index)
            {
                _ctorIndexMap[_ctors[index]] = index;

                var @params = _ctors[index].GetParameters();

                if (@params.Length > maxParametersCount)
                    maxParametersCount = @params.Length;

                if (@params.Length == 0)
                    _defaultCtorIndex = index;

                var args = new ParameterInfo[@params.Length];

                for (var jack = 0; jack < @params.Length; ++jack)
                {
                    args[@params[jack].Position] = @params[jack];
                    var key = @params[jack].ParameterType.Name + @params[jack].Name;
                    if (!_nameConstructorMap.ContainsKey(key))
                        _nameConstructorMap[key] = new List<(ConstructorInfo, ParameterInfo)>();
                    _nameConstructorMap[key].Add((_ctors[index], @params[jack]));
                }

                var paramsScript = new StringBuilder();
                for (var king = 0; king < args.Length; ++king)
                {
                    paramsScript.AppendLine(@$"{args[king].Name}: arg[{king}] == null ? default : ({args[king].ParameterType.GetDevelopName()})arg[{king}]");
                    if (king != args.Length - 1)
                        paramsScript.Append(",");
                }
#if NETFRAMEWORK
                _creators[index] = NDelegate.DefaultDomain().Func<object[], object>($"return new {_typeFullQualifiedName}({paramsScript});");
#else
                _creators[index] = NDelegate.RandomDomain().Func<object[], object>($"return new {_typeFullQualifiedName}({paramsScript});");
#endif
            }

            var dynamicDictionary = new Dictionary<string, string>();
            var script = new StringBuilder();
            var resultFullQualifiedName = typeof(TypeVisit.CtorMatchedResult).GetDevelopName();

            script.Append($@"
if(arg == default || arg.Count() == 0)
{{
    return new {resultFullQualifiedName}(null, {_defaultCtorIndex});
}}

int[] index = new int[{_ctors.Length}];
System.Object[][] values = new System.Object[{_ctors.Length}][];

for(var jack = 0; jack < {_ctors.Length}; ++jack)
{{
    values[jack] = new System.Object[{maxParametersCount}];
}}

foreach(var item in arg)
{{
    string temp = item.Type.Name + item.Name;
");
            var loopScript = new StringBuilder();
            foreach (var item in _nameConstructorMap)
            {
                loopScript.Clear();
                foreach (var ctor in item.Value)
                {
                    loopScript.AppendLine($"index[{_ctorIndexMap[ctor.Item1]}]+=1;");
                    loopScript.AppendLine($"values[{_ctorIndexMap[ctor.Item1]}][{ctor.Item2.Position}] = item.Value;");
                }

                dynamicDictionary[item.Key] = loopScript.ToString();
            }

            loopScript.Clear();

            script.AppendLine(BTFTemplate.GetGroupPrecisionPointBTFScript(dynamicDictionary, "temp"));
            script.AppendLine("}");
            script.AppendLine(@$"
int maxValue = 0;
int maxIndex = 0;

for(var king = 0; king < index.Length; ++king)
{{
    if(maxValue < index[king])
    {{
        maxValue = index[king];
        maxIndex = king;
    }}
}}
return new {resultFullQualifiedName}(values[maxIndex], maxIndex);
");
#if NETFRAMEWORK
            GetIndex = NDelegate.DefaultDomain().UnsafeFunc<IEnumerable<ArgumentDescriptor>, TypeVisit.CtorMatchedResult>(script.ToString());
#else
            GetIndex = NDelegate.RandomDomain().UnsafeFunc<IEnumerable<ArgumentDescriptor>, TypeVisit.CtorMatchedResult>(script.ToString());
#endif
        }

        public object CreateInstance(IEnumerable<ArgumentDescriptor> arguments)
        {
            var result = GetIndex(arguments);
            return _creators[result.Index](result.Values);
        }

        public static Template Create<T>() => new(typeof(T));

        public static Template Create(Type type) => new(type);
    }
}

internal static class CtorTypeMakingCache
{
    private static readonly ConcurrentDictionary<Type, CtorTypeMakingHelper.Template> Templates;

    static CtorTypeMakingCache()
    {
        Templates = new ConcurrentDictionary<Type, CtorTypeMakingHelper.Template>();
    }

    public static CtorTypeMakingHelper.Template GetOrCache(Type type, Func<Type, CtorTypeMakingHelper.Template> factory)
    {
        return Templates.GetOrAdd(type, factory);
    }
}