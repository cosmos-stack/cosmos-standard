#if !NET451 && !NET452

using Cosmos.Collections;

#if NETFRAMEWORK
using System.Linq;
#endif

namespace Cosmos.Exceptions.BuildingServices;

/// <summary>
/// Exception building options.<br />
/// 异常构建器选项。
/// </summary>
public class ExceptionBuildingOptions
{
    private readonly Dictionary<string, ArgumentDescriptor> _items = new();

    /// <summary>
    /// Create a new instance of <see cref="ExceptionBuildingOptions"/>.<br />
    /// 构建一个新的 <see cref="ExceptionBuildingOptions"/> 实例。
    /// </summary>
    /// <param name="type"></param>
    public ExceptionBuildingOptions(Type type)
    {
        ExceptionType = type;
    }

    internal ExceptionBuildingOptions(Type type, Dictionary<string, IArgDescriptionVal> exceptionParams)
    {
        ExceptionType = type;
        InitWithGivenParams(exceptionParams);
    }

    private void InitWithGivenParams(Dictionary<string, IArgDescriptionVal> exceptionParams)
    {
        if (exceptionParams != null)
        {
            exceptionParams.TryGetValue(ExceptionArgConstants.INNER, out var val0)
                           .And(() => __castAndWrap<Exception>(val0))
                           .IfTrue(descriptor => AddArg(descriptor));

            exceptionParams.TryGetValue(ExceptionArgConstants.INNER_EXCEPTION, out var val1)
                           .And(() => __castAndWrap<Exception>(val1))
                           .IfTrue(descriptor => AddArg(descriptor));

            exceptionParams.TryGetValue(ExceptionArgConstants.MESSAGE, out var val2)
                           .And(() => __castAndWrap<string>(val2))
                           .IfTrue(descriptor => AddArg(descriptor));

            exceptionParams.TryGetValue(ExceptionArgConstants.PARAM_NAME, out var val3)
                           .And(() => __castAndWrap<string>(val3))
                           .And(descriptor => !string.IsNullOrWhiteSpace(descriptor.Value.As<string>()))
                           .IfTrue(descriptor => AddArg(descriptor));

            exceptionParams.TryGetValue(ExceptionArgConstants.ACTUAL_VALUE, out var val4)
                           .And(() => __castAndWrap<object>(val4))
                           .And(descriptor => descriptor.Value is not null)
                           .IfTrue(descriptor => AddArg(descriptor));

            exceptionParams.TryGetValue(ExceptionArgConstants.ERROR_CODE, out var val5)
                           .And(() => __castAndWrap<int>(val5))
                           .And(descriptor => descriptor.Value.As<int>() > 0)
                           .IfTrue(descriptor => AddArg(descriptor));

            foreach (var param in __restDtors())
                _items.AddValueIfNotExist(param.Name, param.Descriptor);
        }

        // ReSharper disable once InconsistentNaming
        BooleanVal<ArgumentDescriptor> __castAndWrap<T>(IArgDescriptionVal adv)
        {
            var dtor = adv.ToDescriptor();
            if (dtor.Type == typeof(T) && dtor.Value is T)
                return (true, dtor);
            return (false, default);
        }

        // ReSharper disable once InconsistentNaming
        IEnumerable<(string Name, ArgumentDescriptor Descriptor)> __restDtors()
        {
            var inlineArgNames = new List<string>
            {
                ExceptionArgConstants.INNER,
                ExceptionArgConstants.INNER_EXCEPTION,
                ExceptionArgConstants.MESSAGE,
                ExceptionArgConstants.PARAM_NAME,
                ExceptionArgConstants.ACTUAL_VALUE,
                ExceptionArgConstants.ERROR_CODE
            };

            foreach (var pair in exceptionParams)
            {
                if (inlineArgNames.Contains(pair.Key))
                    continue;
                yield return (pair.Key, pair.Value.ToDescriptor());
            }
        }
    }

    /// <summary>
    /// Gets exception type.<br />
    /// 获取异常类型。
    /// </summary>
    public Type ExceptionType { get; }

#if !NETFRAMEWORK
    internal IEnumerable<ArgumentDescriptor> ArgumentDescriptors => _items.Values;
#else
    internal IEnumerable<object> ArgumentDescriptors => _items.Values.Select(x => x.Value);
#endif

    /// <summary>
    /// Add args.<br />
    /// 添加参数。
    /// </summary>
    /// <param name="argumentName"></param>
    /// <param name="argumentValue"></param>
    /// <param name="overrideVal"></param>
    /// <typeparam name="TArgVal"></typeparam>
    /// <returns></returns>
    public ExceptionBuildingOptions AddArg<TArgVal>(string argumentName, TArgVal argumentValue, bool overrideVal = false)
    {
        if (_items.ContainsKey(argumentName) && !overrideVal)
            return this;

        _items.AddValueOrOverride(argumentName, new ArgumentDescriptor(argumentName, argumentValue, typeof(TArgVal)));
        return this;
    }

    /// <summary>
    /// Add args.<br />
    /// 添加参数。
    /// </summary>
    /// <param name="argumentName"></param>
    /// <param name="argumentValue"></param>
    /// <param name="predicate"></param>
    /// <param name="overrideVal"></param>
    /// <typeparam name="TArgVal"></typeparam>
    /// <returns></returns>
    public ExceptionBuildingOptions AddArg<TArgVal>(string argumentName, TArgVal argumentValue, Func<TArgVal, bool> predicate, bool overrideVal = false)
    {
        if (predicate(argumentValue))
        {
            AddArg(argumentName, argumentValue, overrideVal);
        }

        return this;
    }

    /// <summary>
    /// Add args.<br />
    /// 添加参数。
    /// </summary>
    /// <param name="descriptor"></param>
    /// <param name="overrideVal"></param>
    /// <returns></returns>
    public ExceptionBuildingOptions AddArg(ArgumentDescriptor descriptor, bool overrideVal = false)
    {
        if (descriptor is null)
            return this;

        if (_items.ContainsKey(descriptor.Name) && !overrideVal)
            return this;

        _items.AddValueOrOverride(descriptor.Name, descriptor);
        return this;
    }
}

#endif