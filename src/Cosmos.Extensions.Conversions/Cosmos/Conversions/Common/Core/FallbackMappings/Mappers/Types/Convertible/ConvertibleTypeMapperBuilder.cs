using System.ComponentModel;
using Cosmos.Conversions.Common.Core.FallbackMappings.Core.DataStructures;
using Cosmos.Conversions.Common.Core.FallbackMappings.Core.Extensions;
using Cosmos.Conversions.Common.Core.FallbackMappings.Mappers.Classes.Members;
using Cosmos.Reflection;
using CosmosTypes = Cosmos.Reflection.Types;

namespace Cosmos.Conversions.Common.Core.FallbackMappings.Mappers.Types.Convertible;

internal sealed class ConvertibleTypeMapperBuilder : MapperBuilder
{
    // ReSharper disable once InconsistentNaming
    private static readonly Func<object, object> _nothingConverter = x => x;

    public ConvertibleTypeMapperBuilder(IMapperBuilderConfig config) : base(config) { }

    protected override string ScopeName => "ConvertibleTypeMappers";

    protected override Mapper BuildCore(TypePairOf typePair)
    {
        var converter = GetConverter(typePair);
        return new ConvertibleTypeMapper(converter);
    }

    protected override Mapper BuildCore(TypePairOf parentTypePair, MappingMember mappingMember)
    {
        return BuildCore(mappingMember.TypePair);
    }

    protected override bool IsSupportedCore(TypePairOf typePair)
    {
        return IsSupportedType(typePair.Source) || typePair.HasTypeConverter();
    }

    private static Option<Func<object, object>> ConvertEnum(TypePairOf pair)
    {
        Func<object, object> result;
        if (pair.IsEnumTypes)
        {
            result = x => Convert.ChangeType(x, pair.Source);
            return result.ToOption();
        }

        if (CosmosTypes.IsEnumType(pair.Target))
        {
            if (CosmosTypes.IsEnumType(pair.Source) == false)
            {
                if (pair.Source == typeof(string))
                {
                    result = x => Enum.Parse(pair.Target, x.ToString());
                    return result.ToOption();
                }
            }

            result = x => Enum.ToObject(pair.Target, Convert.ChangeType(x, Enum.GetUnderlyingType(pair.Target)));
            return result.ToOption();
        }

        if (CosmosTypes.IsEnumType(pair.Source))
        {
            result = x => Convert.ChangeType(x, pair.Target);
            return result.ToOption();
        }

        return Option<Func<object, object>>.Empty;
    }

    private static Func<object, object> GetConverter(TypePairOf pair)
    {
        if (pair.IsDeepCloneable)
        {
            return _nothingConverter;
        }

        var fromConverter = TypeDescriptor.GetConverter(pair.Source);
        if (fromConverter.CanConvertTo(pair.Target))
        {
            return x => fromConverter.ConvertTo(x, pair.Target);
        }

        var toConverter = TypeDescriptor.GetConverter(pair.Target);
        if (toConverter.CanConvertFrom(pair.Source))
        {
            return x => toConverter.ConvertFrom(x);
        }

        var enumConverter = ConvertEnum(pair);
        if (enumConverter.HasValue)
        {
            return enumConverter.Value;
        }

        if (pair.IsNullableToNotNullable)
        {
            return GetConverter(new TypePairOf(Nullable.GetUnderlyingType(pair.Source), pair.Target));
        }

        if (CosmosTypes.IsNullableType(pair.Target))
        {
            return GetConverter(new TypePairOf(pair.Source, Nullable.GetUnderlyingType(pair.Target)));
        }

        return null;
    }

    private bool IsSupportedType(Type value)
    {
        return CosmosTypes.IsPrimitiveType(value)
            || value == typeof(string)
            || value == typeof(Guid)
            || CosmosTypes.IsEnumType(value)
            || value == typeof(decimal)
            || CosmosTypes.IsNullableType(value) && IsSupportedType(Nullable.GetUnderlyingType(value));
    }
}