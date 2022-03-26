namespace Cosmos.Exceptions.BuildingServices;

    /// <summary>
    /// Custom Exception Building Manager <br />
    /// 自定义异常构建管理器
    /// </summary>
    public static class CustomExceptionBuildingManager
    {
        private static readonly Dictionary<Type, Func<IExceptionBuilder>> _customExceptionBuilders;
        private static readonly Dictionary<Type, Func<Dictionary<string, IArgDescriptionVal>, bool>> _customExceptionCheckers;

        static CustomExceptionBuildingManager()
        {
            _customExceptionBuilders = new Dictionary<Type, Func<IExceptionBuilder>>();
            _customExceptionCheckers = new Dictionary<Type, Func<Dictionary<string, IArgDescriptionVal>, bool>>();
        }

        /// <summary>
        /// Build, and return exception <br />
        /// 构建并返回异常
        /// </summary>
        /// <param name="type"></param>
        /// <param name="exceptionParams"></param>
        /// <returns></returns>
        public static Exception Return(Type type, Dictionary<string, IArgDescriptionVal> exceptionParams)
        {
            return Return(type, exceptionParams, out _);
        }

        /// <summary>
        /// Build, and return exception <br />
        /// 构建并返回异常
        /// </summary>
        /// <param name="type"></param>
        /// <param name="exceptionParams"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
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

        /// <summary>
        /// Build, and return exception <br />
        /// 构建并返回异常
        /// </summary>
        /// <param name="exceptionParams"></param>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static TException Return<TException>(Dictionary<string, IArgDescriptionVal> exceptionParams)
            where TException : Exception
        {
            return Return(typeof(TException), exceptionParams, out _) as TException;
        }

        /// <summary>
        /// Build, and return exception <br />
        /// 构建并返回异常
        /// </summary>
        /// <param name="exceptionParams"></param>
        /// <param name="builder"></param>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
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

        /// <summary>
        /// Try to create a new instance exception builder <br />
        /// 尝试创建一个新的异常构建器
        /// </summary>
        /// <param name="type"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Try to create a new instance exception builder <br />
        /// 尝试创建一个新的异常构建器
        /// </summary>
        /// <param name="builder"></param>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static bool TryGetBuilder<TException>(out IExceptionBuilder builder) where TException : Exception
        {
            return TryGetBuilder(typeof(TException), out builder);
        }

        /// <summary>
        /// To register a way to create a new exception builder. <br />
        /// 注册一种方式，创建一个新的异常构建器。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="checker"></param>
        /// <param name="buildingDelegate"></param>
        public static void Register(Type type, Func<Dictionary<string, IArgDescriptionVal>, bool> checker, Func<IExceptionBuilder> buildingDelegate)
        {
            if (type is null || buildingDelegate is null)
                return;
            _customExceptionBuilders.Add(type, buildingDelegate);
            if (checker is not null)
                _customExceptionCheckers.Add(type, checker);
        }

        /// <summary>
        /// To register a way to create a new exception builder. <br />
        /// 注册一种方式，创建一个新的异常构建器。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="buildingDelegate"></param>
        public static void Register(Type type, Func<IExceptionBuilder> buildingDelegate)
        {
            if (type is null || buildingDelegate is null)
                return;
            _customExceptionBuilders.Add(type, buildingDelegate);
        }

        /// <summary>
        /// To register or override a way to create a new exception builder. <br />
        /// 注册或覆盖一种方式，创建一个新的异常构建器。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="checker"></param>
        /// <param name="buildingDelegate"></param>
        public static void RegisterOrOverride(Type type, Func<Dictionary<string, IArgDescriptionVal>, bool> checker, Func<IExceptionBuilder> buildingDelegate)
        {
            if (type is null || buildingDelegate is null)
                return;
            _customExceptionBuilders[type] = buildingDelegate;
            if (checker is not null)
                _customExceptionCheckers[type] = checker;
        }

        /// <summary>
        /// To register or override a way to create a new exception builder. <br />
        /// 注册或覆盖一种方式，创建一个新的异常构建器。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="buildingDelegate"></param>
        public static void RegisterOrOverride(Type type, Func<IExceptionBuilder> buildingDelegate)
        {
            if (type is null || buildingDelegate is null)
                return;
            _customExceptionBuilders[type] = buildingDelegate;
        }
    }