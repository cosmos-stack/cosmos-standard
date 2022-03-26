﻿using System.Diagnostics.CodeAnalysis;
using Cosmos.Conversions.ObjectMappingServices;
using Cosmos.Reflection;
using TinyMapper.Bindings;
using TinyMapper.Core;
using TinyMapper.Core.DataStructures;
using TinyMapper.Core.Extensions;
using TinyMapper.Mappers;
using TinyMapper.Reflection;

namespace TinyMapper;

/// <summary>
/// TinyMapper is an object to object mapper for .NET. The main advantage is performance.
/// TinyMapper allows easily map object to object, i.e. properties or fields from one object to another.
/// </summary>
internal static class TinyMapper
{
    // ReSharper disable once InconsistentNaming
    private static readonly Dictionary<TypePairInfo, Mapper> _mappers = new();

    // ReSharper disable once InconsistentNaming
    private static readonly TargetMapperBuilder _targetMapperBuilder;

    // ReSharper disable once InconsistentNaming
    private static readonly TinyMapperConfig _config;

    // ReSharper disable once InconsistentNaming
    private static readonly object _mappersLock = new object();

    static TinyMapper()
    {
        _targetMapperBuilder = new TargetMapperBuilder(DynamicAssemblyBuilder.Get());
        _config = new TinyMapperConfig(_targetMapperBuilder);
    }

    /// <summary>
    /// Create a one-way mapping between Source and Target types.
    /// </summary>
    /// <typeparam name="TSource">Source type.</typeparam>
    /// <typeparam name="TTarget">Target type.</typeparam>
    /// <remarks>The method is thread safe.</remarks>
    public static void Bind<TSource, TTarget>()
    {
        var typePair = TypePairInfo.Create<TSource, TTarget>();
        lock (_mappersLock)
        {
            _mappers[typePair] = _targetMapperBuilder.Build(typePair);
        }
    }

    /// <summary>
    /// Create a one-way mapping between Source and Target types.
    /// </summary>
    /// <param name="sourceType">Source type.</param>
    /// <param name="targetType">Target type.</param>
    /// <remarks>The method is thread safe.</remarks>
    public static void Bind(Type sourceType, Type targetType)
    {
        if (sourceType is null)
            throw new ArgumentNullException(nameof(sourceType));
        if (targetType is null)
            throw new ArgumentNullException(nameof(targetType));
        var typePair = TypePairInfo.Create(sourceType, targetType);
        lock (_mappersLock)
        {
            _mappers[typePair] = _targetMapperBuilder.Build(typePair);
        }
    }

    /// <summary>
    /// Create a one-way mapping between Source and Target types.
    /// </summary>
    /// <typeparam name="TSource">Source type.</typeparam>
    /// <typeparam name="TTarget">Target type.</typeparam>
    /// <param name="config">BindingConfig for custom binding.</param>
    /// <remarks>The method is thread safe.</remarks>
    public static void Bind<TSource, TTarget>(Action<IDefaultBindingConfig<TSource, TTarget>> config)
    {
        var typePair = TypePairInfo.Create<TSource, TTarget>();

        var bindingConfig = new DefaultBindingConfigOf<TSource, TTarget>();
        config(bindingConfig);

        lock (_mappersLock)
        {
            _mappers[typePair] = _targetMapperBuilder.Build(typePair, bindingConfig);
        }
    }

    /// <summary>
    /// Find out if a binding exists from Source to Target.
    /// </summary>
    /// <typeparam name="TSource">Source type.</typeparam>
    /// <typeparam name="TTarget">Target type.</typeparam>
    /// <returns>True if exists, otherwise - False.</returns>
    /// <remarks>The method is thread safe.</remarks>
    public static bool BindingExists<TSource, TTarget>()
    {
        var typePair = TypePairInfo.Create<TSource, TTarget>();
        lock (_mappersLock)
        {
            return _mappers.ContainsKey(typePair);
        }
    }

    /// <summary>
    /// Find out if a binding exists from Source to Target.
    /// </summary>
    /// <param name="sourceType">Source type.</param>
    /// <param name="targetType">Target type.</param>
    /// <returns>True if exists, otherwise - False.</returns>
    /// <remarks>The method is thread safe.</remarks>
    public static bool BindingExists(Type sourceType, Type targetType)
    {
        var typePair = TypePairInfo.Create(sourceType, targetType);
        lock (_mappersLock)
        {
            return _mappers.ContainsKey(typePair);
        }
    }

    /// <summary>
    /// Maps the source to Target type.
    /// The method can be called in parallel to Map methods, but cannot be called in parallel to Bind method.
    /// </summary>
    /// <typeparam name="TSource">Source type.</typeparam>
    /// <typeparam name="TTarget">Target type.</typeparam>
    /// <param name="source">Source object.</param>
    /// <param name="target">Target object.</param>
    /// <returns>Mapped object.</returns>
    public static TTarget Map<TSource, TTarget>(TSource source, TTarget target = default)
    {
        var typePair = TypePairInfo.Create<TSource, TTarget>();

        var mapper = GetMapper(typePair);
        var result = (TTarget) mapper.Map(source, target);

        return result;
    }

    /// <summary>
    /// Maps the source to Target type.
    /// The method can be called in parallel to Map methods, but cannot be called in parallel to Bind method.
    /// </summary>
    /// <param name="sourceType">Source type.</param>
    /// <param name="targetType">Target type.</param>
    /// <param name="source">Source object.</param>
    /// <param name="target">Target object.</param>
    /// <returns>Mapped object.</returns>
    public static object Map(Type sourceType, Type targetType, object source, object target = null)
    {
        var typePair = TypePairInfo.Create(sourceType, targetType);

        var mapper = GetMapper(typePair);
        var result = mapper.Map(source, target);

        return result;
    }

    /// <summary>
    /// Configure the Mapper.
    /// </summary>
    /// <param name="config">Lambda to provide config settings</param>
    public static void Config(Action<ITinyMapperConfig> config)
    {
        config(_config);
    }

    /// <summary>
    /// Maps the source to Target type.
    /// The method can be called in parallel to Map methods, but cannot be called in parallel to Bind method.
    /// </summary>
    /// <typeparam name="TTarget">Target type.</typeparam>
    /// <param name="source">Source object [Not null].</param>
    /// <returns>Mapped object. The method can be called in parallel to Map methods, but cannot be called in parallel to Bind method.</returns>
    public static TTarget Map<TTarget>(object source)
    {
        if (source.IsNull())
        {
            throw Error.ArgumentNull("Source cannot be null. Use TinyMapper.Map<TSource, TTarget> method instead.");
        }

        var typePair = TypePairInfo.Create(source.GetType(), typeof(TTarget));

        var mapper = GetMapper(typePair);
        var result = (TTarget) mapper.Map(source);

        return result;
    }

    [SuppressMessage("ReSharper", "All")]
    private static Mapper GetMapper(TypePairInfo typePair)
    {
        Mapper mapper;

        if (_mappers.TryGetValue(typePair, out mapper) == false)
        {
            throw new DefaultMapperException(
                $"No binding found for '{typePair.Source.Name}' to '{typePair.Target.Name}'. " +
                $"Call TinyMapper.Bind<{typePair.Source.Name}, {typePair.Target.Name}>()");
        }

        //            _mappersLock.EnterUpgradeableReadLock();
        //            try
        //            {
        //                if (_mappers.TryGetValue(typePair, out mapper) == false)
        //                {
        //                    if (_config.EnablePolymorphicMapping && (mapper = GetPolymorphicMapping(typePair)) != null)
        //                    {
        //                        return mapper;
        //                    }
        //                    else if (_config.EnableAutoBinding)
        //                    {
        //                        mapper = _targetMapperBuilder.Build(typePair);
        //                        _mappersLock.EnterWriteLock();
        //                        try
        //                        {
        //                            _mappers[typePair] = mapper;
        //                        }
        //                        finally
        //                        {
        //                            _mappersLock.ExitWriteLock();
        //                        }
        //                    }
        //                    else
        //                    {
        //                        throw new TinyMapperException($"Unable to find a binding for type '{typePair.Source?.Name}' to '{typePair.Target?.Name}'.");
        //                    }
        //                }
        //            }
        //            finally
        //            {
        //                _mappersLock.ExitUpgradeableReadLock();
        //            }

        return mapper;
    }

    //Note: Lock should already be acquired for the mapper
    //        private static Mapper GetPolymorphicMapping(TypePair types)
    //        {
    //            // Walk the polymorphic heirarchy until we find a mapping match
    //            Type source = types.Source;
    //
    //            do
    //            {
    //                Mapper result;
    //                foreach (Type iface in source.GetInterfaces())
    //                {
    //                    if (_mappers.TryGetValue(TypePair.Create(iface, types.Target), out result))
    //                        return result;
    //                }
    //
    //                if (_mappers.TryGetValue(TypePair.Create(source, types.Target), out result))
    //                    return result;
    //            }
    //            while ((source = Helpers.BaseType(source)) != null);
    //
    //            return null;
    //        }
}