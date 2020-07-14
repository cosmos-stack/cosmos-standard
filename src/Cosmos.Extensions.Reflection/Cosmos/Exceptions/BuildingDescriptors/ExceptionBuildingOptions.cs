using System;
using System.Collections.Generic;
using Cosmos.Reflection;

namespace Cosmos.Exceptions.BuildingDescriptors
{
    /// <summary>
    /// Exception building options
    /// </summary>
    public class ExceptionBuildingOptions
    {
        private Dictionary<string, CtorArgDescriptor> _items = new Dictionary<string, CtorArgDescriptor>();

        /// <summary>
        /// Create a new instance of <see cref="ExceptionBuildingOptions"/>.
        /// </summary>
        /// <param name="type"></param>
        public ExceptionBuildingOptions(Type type)
        {
            ExceptionType = type;
        }

        /// <summary>
        /// Gets exception type
        /// </summary>
        public Type ExceptionType { get; }

        internal IEnumerable<CtorArgDescriptor> ArgumentDescriptors => _items.Values;

        /// <summary>
        /// Add args
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
        /// Add args
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