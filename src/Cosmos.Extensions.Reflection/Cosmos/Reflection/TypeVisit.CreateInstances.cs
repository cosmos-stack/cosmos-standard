using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AspectCore.Extensions.Reflection;

#if !NET452
using System.Collections.Concurrent;
using BTFindTree;
using Natasha.CSharp;
using Natasha.Error.Model;

#endif

namespace Cosmos.Reflection
{
    /// <summary>
    /// Descriptor of argument
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
        /// Argument name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Argument value
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Argument type
        /// </summary>
        public Type Type { get; set; }
    }

    /// <summary>
    /// Type visit, an advanced TypeReflections utility.
    /// </summary>
    public static partial class TypeVisit
    {
        #region Create Instance

        public static object CreateInstance(Type type, params object[] args)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));
            return CreateInstanceImpl(type, args);
        }

        public static TInstance CreateInstance<TInstance>(params object[] args)
        {
            return CreateInstanceImpl(Types.Of<TInstance>(), args).AsOrDefault<TInstance>();
        }

        public static TInstance CreateInstance<TInstance>(Type type, params object[] args)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));
            return CreateInstanceImpl(type, args).AsOrDefault<TInstance>();
        }

        private static object CreateInstanceImpl(Type type, params object[] args)
        {
            return args is null || args is {Length: <=0}
                ? type.GetConstructors().FirstOrDefault(WithoutParamPredicate)?.GetReflector().Invoke()
                : type.GetConstructor(Types.Of(args))?.GetReflector().Invoke(args);

            bool WithoutParamPredicate(MethodBase ci) => !ci.GetParameters().Any();
        }

#if !NET452
        public static TInstance CreateInstance<TInstance>(IEnumerable<ArgumentDescriptor> arguments)
        {
            return IsNoneParams(arguments, out var descriptors)
                ? CreateInstance<TInstance>()
                : CreateInstanceImpl(typeof(TInstance), descriptors).AsOrDefault<TInstance>();
        }

        public static TInstance CreateInstance<TInstance>(Type type, IEnumerable<ArgumentDescriptor> arguments)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));
            return IsNoneParams(arguments, out var descriptors)
                ? CreateInstance<TInstance>()
                : CreateInstanceImpl(type, descriptors).AsOrDefault<TInstance>();
        }

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

#endif

        #endregion
    }

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

#if !NET452
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

#endif
    }

#if !NET452
    public static class CtorTypeMakingHelper
    {
        /// <summary>
        /// Ctor matched result
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
            /// Values
            /// </summary>
            public readonly object[] Values;

            /// <summary>
            /// Index
            /// </summary>
            public readonly int Index;
        }

        internal class Template
        {
            public readonly ConstructorInfo[] _ctors;
            public readonly Dictionary<ConstructorInfo, int> _ctorIndexMap;
            public readonly Dictionary<string, List<(ConstructorInfo, ParameterInfo)>> _nameConstructorMap;
            public readonly int _defaultCtorIndex;
            public readonly Func<object[], object>[] _creators;
            public readonly string _typeFullQualifiedName;
            public readonly Func<IEnumerable<ArgumentDescriptor>, CtorMatchedResult> GetIndex;

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

                    _creators[index] = NDelegate.RandomDomain().Func<object[], object>($"return new {_typeFullQualifiedName}({paramsScript});");
                }

                var dynamicDictionary = new Dictionary<string, string>();
                var script = new StringBuilder();
                var resultFullQualifiedName = typeof(CtorMatchedResult).GetDevelopName();

                script.Append($@"
if(arg == default || arg.Count() == 0)
{{
    return new {resultFullQualifiedName}(null, {_defaultCtorIndex});
}}

int[] index = new int[{_ctors.Length}];
object[][] values = new object[{_ctors.Length}][];

for(var jack = 0; jack < {_ctors.Length}; ++jack)
{{
    values[jack] = new object[{maxParametersCount}];
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

                GetIndex = NDelegate.RandomDomain(c => c.SyntaxErrorBehavior = ExceptionBehavior.Throw)
                                    .UnsafeFunc<IEnumerable<ArgumentDescriptor>, CtorMatchedResult>(script.ToString());
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

#endif
}