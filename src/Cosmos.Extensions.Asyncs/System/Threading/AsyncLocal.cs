#if NET451 || NET452

using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace System.Threading
{
    /// <summary>
    /// AsyncLocal for .NET Framework 4.5.x
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AsyncLocal<T>
    {
        private readonly string _pinedAsyncLocalName;
        private readonly Action<AsyncLocalValueChangedArgs<T>> _changedAction;

        public AsyncLocal() : this(null) { }

        public AsyncLocal(Action<AsyncLocalValueChangedArgs<T>> handler)
        {
            _pinedAsyncLocalName = GetName<T>();
            _changedAction = handler;
        }

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