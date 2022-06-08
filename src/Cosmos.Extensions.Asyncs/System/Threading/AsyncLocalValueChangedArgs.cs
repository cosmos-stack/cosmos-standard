#if NET451 || NET452

namespace System.Threading
{
    /// <summary>
    /// AsyncLocal value changed args for .NET Framework 4.5.x
    /// </summary>
    /// <typeparam name="T"></typeparam>
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