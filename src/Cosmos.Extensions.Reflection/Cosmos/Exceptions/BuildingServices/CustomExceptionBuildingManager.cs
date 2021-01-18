#if !NET451 && !NET452
using System;
using System.Collections.Generic;
using Cosmos.Reflection;

namespace Cosmos.Exceptions.BuildingServices
{
    public static class CustomExceptionBuildingManager
    {
        private static readonly Dictionary<Type, Func<IExceptionBuilder>> _customExceptionBuilders;
        private static readonly Dictionary<Type, Func<Dictionary<string, IArgDescriptionVal>, bool>> _customExceptionCheckers;

        static CustomExceptionBuildingManager()
        {
            _customExceptionBuilders = new Dictionary<Type, Func<IExceptionBuilder>>();
            _customExceptionCheckers = new Dictionary<Type, Func<Dictionary<string, IArgDescriptionVal>, bool>>();
        }

        public static Exception Return(Type type, Dictionary<string, IArgDescriptionVal> exceptionParams)
        {
            return Return(type, exceptionParams, out _);
        }

        public static Exception Return(Type type, Dictionary<string, IArgDescriptionVal> exceptionParams, out IExceptionBuilder builder)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));
            if (!type.IsSubclassOf(typeof(Exception)))
                throw new ArgumentException($"Type '{type}' does not be divided from {typeof(Exception)}", nameof(type));
            if (exceptionParams is null)
                return CreateAndReturnExceptionWithoutParams(type, out builder);
            CheckExceptionParams(type, exceptionParams, out var needTwoStepCheck);
            if (!_customExceptionBuilders.TryGetValue(type, out var buildingFunc))
                throw new InvalidOperationException("The construction delegate of the exception type is not registered.");
            builder = buildingFunc?.Invoke();
            if (builder is null)
                throw new InvalidOperationException("The generation of the construction delegate for this exception type failed.");
            if (needTwoStepCheck && !(builder.ArgumentsChecker?.Invoke(exceptionParams) ?? true))
                throw new ArgumentException("The construction parameter of the exception type is missing");
            return builder.Build(exceptionParams);
        }

        public static TException Return<TException>(Dictionary<string, IArgDescriptionVal> exceptionParams)
            where TException : Exception
        {
            return Return(typeof(TException), exceptionParams, out _) as TException;
        }

        public static TException Return<TException>(Dictionary<string, IArgDescriptionVal> exceptionParams, out IExceptionBuilder builder)
            where TException : Exception
        {
            return Return(typeof(TException), exceptionParams, out builder) as TException;
        }

        private static Exception CreateAndReturnExceptionWithoutParams(Type type, out IExceptionBuilder builder)
        {
            builder = ExceptionBuilder.Create(type);
            return builder.Build();
        }

        private static void CheckExceptionParams(Type type, Dictionary<string, IArgDescriptionVal> exceptionParams, out bool needTwoStepCheck)
        {
            needTwoStepCheck = true;
            if (!_customExceptionCheckers.TryGetValue(type, out var checker))
                return;
            needTwoStepCheck = checker is null;
            if (checker?.Invoke(exceptionParams) ?? true)
                return;
            throw new ArgumentException("The construction parameter of the exception type is missing");
        }

        public static bool TryGetBuilder(Type type, out IExceptionBuilder builder)
        {
            builder = default;
            if (type is null)
                return false;
            if (!type.IsSubclassOf(typeof(Exception)))
                return false;
            if (!_customExceptionBuilders.TryGetValue(type, out var buildingFunc))
                return false;
            builder = buildingFunc?.Invoke();
            return builder is not null;
        }

        public static bool TryGetBuilder<TException>(out IExceptionBuilder builder) where TException : Exception
        {
            return TryGetBuilder(typeof(TException), out builder);
        }
        
        public static void Register(Type type, Func<Dictionary<string, IArgDescriptionVal>, bool> checker, Func<IExceptionBuilder> buildingDelegate)
        {
            if (type is null || buildingDelegate is null)
                return;
            _customExceptionBuilders.Add(type, buildingDelegate);
            if (checker is not null)
                _customExceptionCheckers.Add(type, checker);
        }
        
        public static void Register(Type type, Func<IExceptionBuilder> buildingDelegate)
        {
            if (type is null || buildingDelegate is null)
                return;
            _customExceptionBuilders.Add(type, buildingDelegate);
        }

        public static void RegisterOrOverride(Type type, Func<Dictionary<string, IArgDescriptionVal>, bool> checker, Func<IExceptionBuilder> buildingDelegate)
        {
            if (type is null || buildingDelegate is null)
                return;
            _customExceptionBuilders[type] = buildingDelegate;
            if (checker is not null)
                _customExceptionCheckers[type] = checker;
        }

        public static void RegisterOrOverride(Type type, Func<IExceptionBuilder> buildingDelegate)
        {
            if (type is null || buildingDelegate is null)
                return;
            _customExceptionBuilders[type] = buildingDelegate;
        }
    }
}
#endif