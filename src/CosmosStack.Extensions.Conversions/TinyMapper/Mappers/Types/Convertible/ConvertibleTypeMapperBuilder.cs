﻿using System;
using System.ComponentModel;
using TinyMapper.Core;
using TinyMapper.Core.DataStructures;
using TinyMapper.Core.Extensions;
using TinyMapper.Mappers.Classes.Members;

namespace TinyMapper.Mappers.Types.Convertible
{
    internal sealed class ConvertibleTypeMapperBuilder : MapperBuilder
    {
        // ReSharper disable once InconsistentNaming
        private static readonly Func<object, object> _nothingConverter = x => x;

        public ConvertibleTypeMapperBuilder(IMapperBuilderConfig config) : base(config) { }

        protected override string ScopeName => "ConvertibleTypeMappers";

        protected override Mapper BuildCore(TypePair typePair)
        {
            var converter = GetConverter(typePair);
            return new ConvertibleTypeMapper(converter);
        }

        protected override Mapper BuildCore(TypePair parentTypePair, MappingMember mappingMember)
        {
            return BuildCore(mappingMember.TypePair);
        }

        protected override bool IsSupportedCore(TypePair typePair)
        {
            return IsSupportedType(typePair.Source) || typePair.HasTypeConverter();
        }

        private static Option<Func<object, object>> ConvertEnum(TypePair pair)
        {
            Func<object, object> result;
            if (pair.IsEnumTypes)
            {
                result = x => Convert.ChangeType(x, pair.Source);
                return result.ToOption();
            }

            if (Helpers.IsEnum(pair.Target))
            {
                if (Helpers.IsEnum(pair.Source) == false)
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

            if (Helpers.IsEnum(pair.Source))
            {
                result = x => Convert.ChangeType(x, pair.Target);
                return result.ToOption();
            }

            return Option<Func<object, object>>.Empty;
        }

        private static Func<object, object> GetConverter(TypePair pair)
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
                return GetConverter(new TypePair(Nullable.GetUnderlyingType(pair.Source), pair.Target));
            }

            if (pair.Target.IsNullable())
            {
                return GetConverter(new TypePair(pair.Source, Nullable.GetUnderlyingType(pair.Target)));
            }

            return null;
        }

        private bool IsSupportedType(Type value)
        {
            return Helpers.IsPrimitive(value)
                || value == typeof(string)
                || value == typeof(Guid)
                || Helpers.IsEnum(value)
                || value == typeof(decimal)
                || value.IsNullable() && IsSupportedType(Nullable.GetUnderlyingType(value));
        }
    }
}