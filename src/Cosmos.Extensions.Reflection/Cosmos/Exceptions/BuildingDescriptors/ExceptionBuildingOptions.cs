using System;
using System.Collections.Generic;
using Cosmos.Reflection;

namespace Cosmos.Exceptions.BuildingDescriptors
{
    /// <summary>
    /// Exception building options.<br />
    /// 异常构建器选项。
    /// </summary>
    public class ExceptionBuildingOptions
    {
        private readonly Dictionary<string, CtorArgDescriptor> _items = new Dictionary<string, CtorArgDescriptor>();

        /// <summary>
        /// Create a new instance of <see cref="ExceptionBuildingOptions"/>.<br />
        /// 构建一个新的 <see cref="ExceptionBuildingOptions"/> 实例。
        /// </summary>
        /// <param name="type"></param>
        public ExceptionBuildingOptions(Type type)
        {
            ExceptionType = type;
        }

        /// <summary>
        /// Gets exception type.<br />
        /// 获取异常类型。
        /// </summary>
        public Type ExceptionType { get; }

        internal IEnumerable<CtorArgDescriptor> ArgumentDescriptors => _items.Values;

        /// <summary>
        /// Add args.<br />
        /// 添加参数。
        /// </summary>
        /// <param name="argumentName"></param>
        /// <param name="argumentValue"></param>
        /// <typeparam name="TArgVal"></typeparam>
        /// <returns></returns>
        public ExceptionBuildingOptions AddArg<TArgVal>(string argumentName, TArgVal argumentValue)
        {
            if (_items.ContainsKey(argumentName))
                return this;

            _items.Add(argumentName, new CtorArgDescriptor(argumentName, argumentValue, typeof(TArgVal)));
            return this;
        }

        /// <summary>
        /// Add args.<br />
        /// 添加参数。
        /// </summary>
        /// <param name="argumentName"></param>
        /// <param name="argumentValue"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="TArgVal"></typeparam>
        /// <returns></returns>
        public ExceptionBuildingOptions AddArg<TArgVal>(string argumentName, TArgVal argumentValue, Func<TArgVal, bool> predicate)
        {
            if (predicate(argumentValue))
            {
                AddArg(argumentName, argumentValue);
            }

            return this;
        }
    }
}