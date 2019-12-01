#if NET451

using System.Runtime.Remoting.Messaging;

// ReSharper disable once CheckNamespace
namespace System.Threading
{

    /// <summary>
    /// Async local for .NET Framework 4.5.1
    /// </summary>
    /// <typeparam name="T"></typeparam>
    // ReSharper disable once InconsistentNaming
    public class AsyncLocal<T>
    {
        private readonly string _pinedAsyncLocalName;
        private readonly Action<AsyncLocalValueChangedArgs<T>> _changedAction;

        /// <summary>
        /// Create a new instance for AsyncLocal for .NET Framework 4.5.1
        /// </summary>
        public AsyncLocal() : this(null) { }

        /// <summary>
        /// Create a new instance for AsyncLocal for .NET Framework 4.5.1
        /// </summary>
        /// <param name="handler"></param>
        public AsyncLocal(Action<AsyncLocalValueChangedArgs<T>> handler)
        {
            _pinedAsyncLocalName = GetName<T>();
            _changedAction = handler;
        }

        /// <summary>
        /// Gets or sets value
        /// </summary>
        public T Value
        {
            get
            {
                var ret = CallContext.LogicalGetData(_pinedAsyncLocalName);
                if (ret is T t)
                    return t;
                return default;
            }
            set
            {
                var previousValue = Value;
                var currentValue = value;
                var contextChanged = previousValue.Equals(currentValue);
                CallContext.LogicalSetData(_pinedAsyncLocalName, currentValue);
                CallValueChangedHandle(previousValue, currentValue, contextChanged);
            }
        }

        private void CallValueChangedHandle(T previousValue, T currentValue, bool contextChanged)
        {
            _changedAction?.Invoke(new AsyncLocalValueChangedArgs<T>(previousValue, currentValue, contextChanged));
        }

        private static string GetName<T2>()
        {
            var type = typeof(T2);
            var @namespace = type.Namespace;
            var fullname = type.FullName;
            return string.IsNullOrWhiteSpace(@namespace)
                ? fullname
                : $"{@namespace}.{fullname}";
        }
    }
}

#endif