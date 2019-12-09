using System;

namespace Cosmos {
    /// <summary>
    /// Type clazz
    /// </summary>
    public static class TypeClass {
        /// <summary>
        /// Gets clazz for object.
        /// </summary>
        public static Type ObjectClass { get; } = typeof(object);

        /// <summary>
        /// Gets clazz for int32
        /// </summary>
        public static Type Int32Class { get; } = typeof(int);

        /// <summary>
        /// Gets clazz for nullable int32
        /// </summary>
        public static Type Int32NullableClass { get; } = typeof(int?);


        /// <summary>
        /// Gets clazz for int64
        /// </summary>
        public static Type Int64Class { get; } = typeof(long);

        /// <summary>
        /// Gets clazz for nullable int64
        /// </summary>
        public static Type Int64NullableClass { get; } = typeof(long?);


        /// <summary>
        /// Gets clazz for int
        /// </summary>
        public static Type IntClass => Int32Class;

        /// <summary>
        /// Gets clazz for nullable int
        /// </summary>
        public static Type IntNullableClass => Int32NullableClass;

        /// <summary>
        /// Gets clazz for long
        /// </summary>
        public static Type LongClass => Int64Class;

        /// <summary>
        /// Gets clazz for nullable long
        /// </summary>
        public static Type LongNullableClass => Int64NullableClass;

        /// <summary>
        /// Gets clazz for float
        /// </summary>
        public static Type FloatClass { get; } = typeof(float);

        /// <summary>
        /// Gets clazz for nullable float
        /// </summary>
        public static Type FloatNullableClass { get; } = typeof(float?);

        /// <summary>
        /// Gets clazz for double
        /// </summary>
        /// <summary>
        /// Gets clazz for nullable decimal
        /// </summary>
        public static Type DoubleClass { get; } = typeof(double);

        /// <summary>
        /// Gets clazz for nullable double
        /// </summary>
        public static Type DoubleNullableClass { get; } = typeof(double?);

        /// <summary>
        /// Gets clazz for decimal
        /// </summary>
        public static Type DecimalClass { get; } = typeof(decimal);

        /// <summary>
        /// Gets clazz for nullable decimal
        /// </summary>
        public static Type DecimalNullableClass { get; } = typeof(decimal?);

        /// <summary>
        /// Gets clazz for string
        /// </summary>
        public static Type StringClass { get; } = typeof(string);

        /// <summary>
        /// Gets clazz for DateTime
        /// </summary>
        public static Type DateTimeClass { get; } = typeof(DateTime);

        /// <summary>
        /// Gets clazz for nullable DateTime
        /// </summary>
        public static Type DateTimeNullableClass { get; } = typeof(DateTime?);

        /// <summary>
        /// Gets clazz for TimeSpan
        /// </summary>
        public static Type TimeSpanClass { get; } = typeof(TimeSpan);

        /// <summary>
        /// Gets clazz for nullable TimeSpan
        /// </summary>
        public static Type TimeSpanNullableClass { get; } = typeof(TimeSpan?);
    }
}