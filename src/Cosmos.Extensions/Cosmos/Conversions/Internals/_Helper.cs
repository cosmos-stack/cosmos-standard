using System;

namespace Cosmos.Conversions.Internals {
    // ReSharper disable once InconsistentNaming
    internal static class _Helper {

        public static Action<T> ConvertAct<T>(Action<object> action) where T : struct
            => action == null ? null : new Action<T>(o => action?.Invoke(o));

        public static Action<object> ConvertAct<T>(Action<T> action) where T : struct
            => action == null ? null : new Action<object>(o => action.Invoke((T) o));
    }
}