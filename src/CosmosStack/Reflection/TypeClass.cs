namespace Cosmos.Reflection;

/// <summary>
/// Type clazz
/// </summary>
public static class TypeClass
{
    /// <summary>
    /// Gets clazz for void.
    /// </summary>
    public static Type VoidClazz { get; } = typeof(void);

    /// <summary>
    /// Gets clazz for object.
    /// </summary>
    public static Type ObjectClazz { get; } = typeof(object);

    /// <summary>
    /// Gets clazz for object array
    /// </summary>
    public static Type ObjectArrayClazz { get; } = typeof(object[]);

    /// <summary>
    /// Gets clazz for byte
    /// </summary>
    public static Type ByteClazz { get; } = typeof(byte);

    /// <summary>
    /// Gets clazz for nullable byte
    /// </summary>
    public static Type ByteNullableClazz { get; } = typeof(byte?);

    /// <summary>
    /// Gets clazz for byte array
    /// </summary>
    public static Type ByteArrayClazz { get; } = typeof(byte[]);

    /// <summary>
    /// Gets clazz for sbyte
    /// </summary>
    public static Type SByteClazz { get; } = typeof(sbyte);

    /// <summary>
    /// Gets clazz for nullable sbyte
    /// </summary>
    public static Type SByteNullableClazz { get; } = typeof(sbyte?);

    /// <summary>
    /// Gets clazz for int16
    /// </summary>
    public static Type Int16Clazz { get; } = typeof(short);

    /// <summary>
    /// Gets clazz for nullable int16
    /// </summary>
    public static Type Int16NullableClazz { get; } = typeof(short?);

    /// <summary>
    /// Gets clazz for uint16
    /// </summary>
    public static Type UInt16Clazz { get; } = typeof(ushort);

    /// <summary>
    /// Gets clazz for nullable uint16
    /// </summary>
    public static Type UInt16NullableClazz { get; } = typeof(ushort?);

    /// <summary>
    /// Gets clazz for int32
    /// </summary>
    public static Type Int32Clazz { get; } = typeof(int);

    /// <summary>
    /// Gets clazz for nullable int32
    /// </summary>
    public static Type Int32NullableClazz { get; } = typeof(int?);

    /// <summary>
    /// Gets clazz for uint32
    /// </summary>
    public static Type UInt32Clazz { get; } = typeof(uint);

    /// <summary>
    /// Gets clazz for nullable uint32
    /// </summary>
    public static Type UInt32NullableClazz { get; } = typeof(uint?);

    /// <summary>
    /// Gets clazz for int64
    /// </summary>
    public static Type Int64Clazz { get; } = typeof(long);

    /// <summary>
    /// Gets clazz for nullable int64
    /// </summary>
    public static Type Int64NullableClazz { get; } = typeof(long?);

    /// <summary>
    /// Gets clazz for uint64
    /// </summary>
    public static Type UInt64Clazz { get; } = typeof(ulong);

    /// <summary>
    /// Gets clazz for nullable uint64
    /// </summary>
    public static Type UInt64NullableClazz { get; } = typeof(ulong?);

    /// <summary>
    /// Gets clazz for short
    /// </summary>
    public static Type ShortClazz => Int16Clazz;

    /// <summary>
    /// Gets clazz for nullable short
    /// </summary>
    public static Type ShortNullableClazz => Int16NullableClazz;

    /// <summary>
    /// Gets clazz for ushort
    /// </summary>
    public static Type UShortClazz => UInt16Clazz;

    /// <summary>
    /// Gets clazz for nullable ushort
    /// </summary>
    public static Type UShortNullableClazz => UInt16NullableClazz;

    /// <summary>
    /// Gets clazz for int
    /// </summary>
    public static Type IntClazz => Int32Clazz;

    /// <summary>
    /// Gets clazz for nullable int
    /// </summary>
    public static Type IntNullableClazz => Int32NullableClazz;

    /// <summary>
    /// Gets clazz for uint
    /// </summary>
    public static Type UIntClazz => UInt32Clazz;

    /// <summary>
    /// Gets clazz for nullable uint
    /// </summary>
    public static Type UIntNullableClazz => UInt32NullableClazz;

    /// <summary>
    /// Gets clazz for long
    /// </summary>
    public static Type LongClazz => Int64Clazz;

    /// <summary>
    /// Gets clazz for nullable long
    /// </summary>
    public static Type LongNullableClazz => Int64NullableClazz;

    /// <summary>
    /// Gets clazz for ulong
    /// </summary>
    public static Type ULongClazz => UInt64Clazz;

    /// <summary>
    /// Gets clazz for nullable ulong
    /// </summary>
    public static Type ULongNullableClazz => UInt64NullableClazz;

    /// <summary>
    /// Gets clazz for float
    /// </summary>
    public static Type FloatClazz => SingleClazz;

    /// <summary>
    /// Gets clazz for nullable float
    /// </summary>
    public static Type FloatNullableClazz => SingleNullableClazz;

    /// <summary>
    /// Gets clazz for float
    /// </summary>
    public static Type SingleClazz { get; } = typeof(float);

    /// <summary>
    /// Gets clazz for nullable float
    /// </summary>
    public static Type SingleNullableClazz { get; } = typeof(float?);

    /// <summary>
    /// Gets clazz for double
    /// </summary>
    /// <summary>
    /// Gets clazz for nullable decimal
    /// </summary>
    public static Type DoubleClazz { get; } = typeof(double);

    /// <summary>
    /// Gets clazz for nullable double
    /// </summary>
    public static Type DoubleNullableClazz { get; } = typeof(double?);

    /// <summary>
    /// Gets clazz for decimal
    /// </summary>
    public static Type DecimalClazz { get; } = typeof(decimal);

    /// <summary>
    /// Gets clazz for nullable decimal
    /// </summary>
    public static Type DecimalNullableClazz { get; } = typeof(decimal?);

    /// <summary>
    /// Gets clazz for string
    /// </summary>
    public static Type StringClazz { get; } = typeof(string);

    /// <summary>
    /// Gets clazz for DateTime
    /// </summary>
    public static Type DateTimeClazz { get; } = typeof(DateTime);

    /// <summary>
    /// Gets clazz for nullable DateTime
    /// </summary>
    public static Type DateTimeNullableClazz { get; } = typeof(DateTime?);

    /// <summary>
    /// Gets clazz for DateTimeOffset
    /// </summary>
    public static Type DateTimeOffsetClazz { get; } = typeof(DateTimeOffset);

    /// <summary>
    /// Gets clazz for nullable DateTimeOffset
    /// </summary>
    public static Type DateTimeOffsetNullableClazz { get; } = typeof(DateTimeOffset?);

    /// <summary>
    /// Gets clazz for TimeSpan
    /// </summary>
    public static Type TimeSpanClazz { get; } = typeof(TimeSpan);

    /// <summary>
    /// Gets clazz for nullable TimeSpan
    /// </summary>
    public static Type TimeSpanNullableClazz { get; } = typeof(TimeSpan?);

    /// <summary>
    /// Gets clazz for guid.
    /// </summary>
    public static Type GuidClazz { get; } = typeof(Guid);

    /// <summary>
    /// Gets clazz for nullable guid.
    /// </summary>
    public static Type GuidNullableClazz { get; } = typeof(Guid?);

    /// <summary>
    /// Gets clazz for bool.
    /// </summary>
    public static Type BooleanClazz { get; } = typeof(bool);

    /// <summary>
    /// Gets clazz for nullable bool.
    /// </summary>
    public static Type BooleanNullableClazz { get; } = typeof(bool?);

    /// <summary>
    /// Gets clazz for char.
    /// </summary>
    public static Type CharClazz { get; } = typeof(char);

    /// <summary>
    /// Gets clazz for nullable char.
    /// </summary>
    public static Type CharNullableClazz { get; } = typeof(char?);

    /// <summary>
    /// Gets clazz for Enum.
    /// </summary>
    public static Type EnumClazz { get; } = typeof(Enum);

    /// <summary>
    /// Gets clazz for ValueTuple
    /// </summary>
    public static Type ValueTupleClazz { get; } = typeof(ValueTuple);

    /// <summary>
    /// Gets clazz for Task
    /// </summary>
    public static Type TaskClazz { get; } = typeof(Task);

    /// <summary>
    /// Gets clazz for Generic Task
    /// </summary>
    public static Type GenericTaskClazz { get; } = typeof(Task<>);

    /// <summary>
    /// Gets clazz for ValueTask
    /// </summary>
    public static Type ValueTaskClazz { get; } = typeof(ValueTask);

    /// <summary>
    /// Gets clazz for Generic ValueTask
    /// </summary>
    public static Type GenericValueTaskClazz { get; } = typeof(ValueTask<>);

    /// <summary>
    /// Gets clazz for List
    /// </summary>
    public static Type ListClazz { get; } = typeof(List<>);

    /// <summary>
    /// Gets clazz for Generic List
    /// </summary>
    public static Type GenericListClazz { get; } = typeof(List<>);

    /// <summary>
    /// Gets clazz for Nullable type
    /// </summary>
    public static Type NullableClazz { get; } = typeof(Nullable);

    /// <summary>
    /// Gets clazz for Generic Nullable type
    /// </summary>
    public static Type GenericNullableClazz { get; } = typeof(Nullable<>);

    /// <summary>
    /// Gets clazz for IFormattable
    /// </summary>
    public static Type FormattableClazz { get; } = typeof(IFormattable);

    /// <summary>
    /// Gets clazz for IFormatProvider
    /// </summary>
    public static Type FormatProviderClazz { get; } = typeof(IFormatProvider);
}