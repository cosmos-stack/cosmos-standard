#if NET451

// ReSharper disable once CheckNamespace
namespace System.Threading
{
    /// <summary>
    /// Async local value changed args for .NET Framework 4.5.1
    /// </summary>
    /// <typeparam name="T"></typeparam>
    // ReSharper disable once InconsistentNaming
    public readonly struct AsyncLocalValueChangedArgs<T>
    {
        /// <summary>
        /// Previous value
        /// </summary>
        public T PreviousValue { get; }

        /// <summary>
        /// Current value
        /// </summary>
        public T CurrentValue { get; }

        /// <summary>
        /// Thread context changed
        /// </summary>
        public bool ThreadContextChanged { get; }

        internal AsyncLocalValueChangedArgs(T previousValue, T currentValue, bool contextChanged)
        {
            PreviousValue = previousValue;
            CurrentValue = currentValue;
            ThreadContextChanged = contextChanged;
        }
    }
}

#endif