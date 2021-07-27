using System.Runtime.CompilerServices;

namespace Cosmos
{
    public static class BooleanVal
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BooleanVal<T> Of<T>(bool value, T obj) => BooleanVal<T>.Of(value, obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BooleanVal3 MayTrue() => BooleanVal3.True.Instance;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BooleanVal3 MayFalse() => BooleanVal3.False.Instance;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BooleanVal3 MayNull() => BooleanVal3.Null.Instance;
    }
}