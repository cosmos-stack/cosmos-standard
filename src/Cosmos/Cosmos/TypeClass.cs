using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cosmos
{
    /// <summary>
    /// Type clazz
    /// </summary>
    public static class TypeClass
    {
        /// <summary>
        /// Gets clazz for void.
        /// </summary>
        public static Type VoidClass { get; } = typeof(void);

        /// <summary>
        /// Gets clazz for object.
        /// </summary>
        public static Type ObjectClass { get; } = typeof(object);

        /// <summary>
        /// Gets clazz for object array
        /// </summary>
        public static Type ObjectArrayClass { get; } = typeof(object[]);

        /// <summary>
        /// Gets clazz for byte
        /// </summary>
        public static Type ByteClass { get; } = typeof(byte);

        /// <summary>
        /// Gets clazz for nullable byte
        /// </summary>
        public static Type ByteNullableClass { get; } = typeof(byte?);

        /// <summary>
        /// Gets clazz for byte array
        /// </summary>
        public static Type ByteArrayClass { get; } = typeof(byte[]);

        /// <summary>
        /// Gets clazz for sbyte
        /// </summary>
        public static Type SByteClass { get; } = typeof(sbyte);

        /// <summary>
        /// Gets clazz for nullable sbyte
        /// </summary>
        public static Type SByteNullableClass { get; } = typeof(sbyte?);

        /// <summary>
        /// Gets clazz for int16
        /// </summary>
        public static Type Int16Class { get; } = typeof(short);

        /// <summary>
        /// Gets clazz for nullable int16
        /// </summary>
        public static Type Int16NullableClass { get; } = typeof(short?);

        /// <summary>
        /// Gets clazz for uint16
        /// </summary>
        public static Type UInt16Class { get; } = typeof(ushort);

        /// <summary>
        /// Gets clazz for nullable uint16
        /// </summary>
        public static Type UInt16NullableClass { get; } = typeof(ushort?);

        /// <summary>
        /// Gets clazz for int32
        /// </summary>
        public static Type Int32Class { get; } = typeof(int);

        /// <summary>
        /// Gets clazz for nullable int32
        /// </summary>
        public static Type Int32NullableClass { get; } = typeof(int?);

        /// <summary>
        /// Gets clazz for uint32
        /// </summary>
        public static Type UInt32Class { get; } = typeof(uint);

        /// <summary>
        /// Gets clazz for nullable uint32
        /// </summary>
        public static Type UInt32NullableClass { get; } = typeof(uint?);

        /// <summary>
        /// Gets clazz for int64
        /// </summary>
        public static Type Int64Class { get; } = typeof(long);

        /// <summary>
        /// Gets clazz for nullable int64
        /// </summary>
        public static Type Int64NullableClass { get; } = typeof(long?);

        /// <summary>
        /// Gets clazz for uint64
        /// </summary>
        public static Type UInt64Class { get; } = typeof(ulong);

        /// <summary>
        /// Gets clazz for nullable uint64
        /// </summary>
        public static Type UInt64NullableClass { get; } = typeof(ulong?);

        /// <summary>
        /// Gets clazz for short
        /// </summary>
        public static Type ShortClass => Int16Class;

        /// <summary>
        /// Gets clazz for nullable short
        /// </summary>
        public static Type ShortNullableClass => Int16NullableClass;

        /// <summary>
        /// Gets clazz for ushort
        /// </summary>
        public static Type UShortClass => UInt16Class;

        /// <summary>
        /// Gets clazz for nullable ushort
        /// </summary>
        public static Type UShortNullableClass => UInt16NullableClass;

        /// <summary>
        /// Gets clazz for int
        /// </summary>
        public static Type IntClass => Int32Class;

        /// <summary>
        /// Gets clazz for nullable int
        /// </summary>
        public static Type IntNullableClass => Int32NullableClass;

        /// <summary>
        /// Gets clazz for uint
        /// </summary>
        public static Type UIntClass => UInt32Class;

        /// <summary>
        /// Gets clazz for nullable uint
        /// </summary>
        public static Type UIntNullableClass => UInt32NullableClass;

        /// <summary>
        /// Gets clazz for long
        /// </summary>
        public static Type LongClass => Int64Class;

        /// <summary>
        /// Gets clazz for nullable long
        /// </summary>
        public static Type LongNullableClass => Int64NullableClass;

        /// <summary>
        /// Gets clazz for ulong
        /// </summary>
        public static Type ULongClass => UInt64Class;

        /// <summary>
        /// Gets clazz for nullable ulong
        /// </summary>
        public static Type ULongNullableClass => UInt64NullableClass;

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
        /// Gets clazz for DateTimeOffset
        /// </summary>
        public static Type DateTimeOffsetClass { get; } = typeof(DateTimeOffset);

        /// <summary>
        /// Gets clazz for nullable DateTimeOffset
        /// </summary>
        public static Type DateTimeOffsetNullableClass { get; } = typeof(DateTimeOffset?);

        /// <summary>
        /// Gets clazz for TimeSpan
        /// </summary>
        public static Type TimeSpanClass { get; } = typeof(TimeSpan);

        /// <summary>
        /// Gets clazz for nullable TimeSpan
        /// </summary>
        public static Type TimeSpanNullableClass { get; } = typeof(TimeSpan?);

        /// <summary>
        /// Gets clazz for guid.
        /// </summary>
        public static Type GuidClass { get; } = typeof(Guid);

        /// <summary>
        /// Gets clazz for nullable guid.
        /// </summary>
        public static Type GuidNullableClass { get; } = typeof(Guid?);

        /// <summary>
        /// Gets clazz for bool.
        /// </summary>
        public static Type BooleanClass { get; } = typeof(bool);

        /// <summary>
        /// Gets clazz for nullable bool.
        /// </summary>
        public static Type BooleanNullableClass { get; } = typeof(bool?);

        /// <summary>
        /// Gets clazz for char.
        /// </summary>
        public static Type CharClass { get; } = typeof(char);

        /// <summary>
        /// Gets clazz for nullable char.
        /// </summary>
        public static Type CharNullableClass { get; } = typeof(char?);

        /// <summary>
        /// Gets clazz for Enum.
        /// </summary>
        public static Type EnumClass { get; } = typeof(Enum);

        /// <summary>
        /// Gets clazz for ValueTuple
        /// </summary>
        public static Type ValueTupleClass { get; } = typeof(ValueTuple);

        /// <summary>
        /// Gets clazz for Task
        /// </summary>
        public static Type TaskClass { get; } = typeof(Task);

        /// <summary>
        /// Gets clazz for Generic Task
        /// </summary>
        public static Type GenericTaskClass { get; } = typeof(Task<>);

        /// <summary>
        /// Gets clazz for List
        /// </summary>
        public static Type ListClass { get; } = typeof(List<>);

        /// <summary>
        /// Gets clazz for Generic List
        /// </summary>
        public static Type GenericListClass { get; } = typeof(List<>);
    }
}