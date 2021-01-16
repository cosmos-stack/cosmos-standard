#if !NET451 && !NET452
using System;
using System.Collections.Generic;
using Cosmos.Reflection;

namespace Cosmos.Exceptions.Common
{
    public static class CustomExceptionFuncManager
    {
        private static readonly Dictionary<Type, Func<IFluentExceptionBuilder>> _customExceptionBuilders;
        private static readonly Dictionary<Type, Func<Dictionary<string, IArgDescriptionVal>, bool>> _customExceptionCheckers;

        static CustomExceptionFuncManager()
        {
            _customExceptionBuilders = new Dictionary<Type, Func<IFluentExceptionBuilder>>();
            _customExceptionCheckers = new Dictionary<Type, Func<Dictionary<string, IArgDescriptionVal>, bool>>();
        }

        public static Exception Return(Type type, Dictionary<string, IArgDescriptionVal> exceptionParams)
        {
            return Return(type, exceptionParams, out _);
        }

        public static Exception Return(Type type, Dictionary<string, IArgDescriptionVal> exceptionParams, out IFluentExceptionBuilder builder)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));
            if (!type.IsSubclassOf(typeof(Exception)))
                throw new ArgumentException($"Type '{type}' does not be divided from {typeof(Exception)}", nameof(type));
            if (exceptionParams is null)
                return CreateAndReturnExceptionWithoutParams(type, out builder);
            CheckExceptionParams(type, exceptionParams);
            if (!_customExceptionBuilders.TryGetValue(type, out var buildingFunc))
                throw new InvalidOperationException("The construction delegate of the exception type is not registered.");
            builder = buildingFunc?.Invoke();
            if (builder is null)
                throw new InvalidOperationException("The generation of the construction delegate for this exception type failed.");
            return builder.Build(exceptionParams);
        }

        public static TException Return<TException>(Dictionary<string, IArgDescriptionVal> exceptionParams)
            where TException : Exception
        {
            return Return(typeof(TException), exceptionParams, out _) as TException;
        }

        public static TException Return<TException>(Dictionary<string, IArgDescriptionVal> exceptionParams, out IFluentExceptionBuilder builder)
            where TException : Exception
        {
            return Return(typeof(TException), exceptionParams, out builder) as TException;
        }

        private static Exception CreateAndReturnExceptionWithoutParams(Type type, out IFluentExceptionBuilder builder)
        {
            builder = ExceptionBuilder.Create(type);
            return builder.Build();
        }

        private static void CheckExceptionParams(Type type, Dictionary<string, IArgDescriptionVal> exceptionParams)
        {
            if (!_customExceptionCheckers.TryGetValue(type, out var checker))
                return;
            if (checker?.Invoke(exceptionParams) ?? true)
                return;
            throw new ArgumentException("The construction parameter of the exception type is missing");
        }

        public static void Register(Type type, Func<Dictionary<string, IArgDescriptionVal>, bool> checker, Func<IFluentExceptionBuilder> buildingDelegate)
        {
            if (type is null || buildingDelegate is null)
                return;
            _customExceptionBuilders.Add(type, buildingDelegate);
            if (checker is not null)
                _customExceptionCheckers.Add(type, checker);
        }

        public static void RegisterOrOverride(Type type, Func<Dictionary<string, IArgDescriptionVal>, bool> checker, Func<IFluentExceptionBuilder> buildingDelegate)
        {
            if (type is null || buildingDelegate is null)
                return;
            _customExceptionBuilders[type] = buildingDelegate;
            if (checker is not null)
                _customExceptionCheckers[type] = checker;
        }
    }
}
#endif