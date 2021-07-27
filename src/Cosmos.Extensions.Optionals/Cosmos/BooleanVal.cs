namespace Cosmos
{
    public static class BooleanVal
    {
        public static BooleanVal<T> Of<T>(bool value, T obj) => BooleanVal<T>.Of(value, obj);

        public static BooleanVal3 MayTrue() => BooleanVal3.True.Instance;

        public static BooleanVal3 MayFalse() => BooleanVal3.False.Instance;

        public static BooleanVal3 MayNull() => BooleanVal3.Null.Instance;
    }
}