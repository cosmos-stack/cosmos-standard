using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

/*
 * Reference to:
 *      Mutuduxf/Zaabee.Serializers
 *          Author: Mutuduxf
 *          Url:    https://github.com/Mutuduxf/Zaabee.Serializers
 *          MIT
 *     https://github.com/Mutuduxf/Zaabee.Serializers/blob/master/Zaabee.Protobuf/Zaabee.Protobuf/SerializerBuilder.cs
 */

namespace ProtoBuf.Meta {
    /// <summary>
    /// Serializer builder
    /// </summary>
    public static class SerializerBuilder {
        private const BindingFlags Flags = BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        private static readonly ConcurrentDictionary<Type, HashSet<Type>> SubTypes = new ConcurrentDictionary<Type, HashSet<Type>>();
        private static readonly ConcurrentBag<Type> BuiltTypes = new ConcurrentBag<Type>();
        private static readonly Type ObjectType = typeof(object);

        /// <summary>
        /// Build
        /// </summary>
        /// <param name="runtimeTypeModel"></param>
        /// <typeparam name="T"></typeparam>
        public static void Build<T>(RuntimeTypeModel runtimeTypeModel) {
            Build(runtimeTypeModel, typeof(T));
        }

        /// <summary>
        /// Build
        /// </summary>
        /// <param name="runtimeTypeModel"></param>
        /// <param name="type"></param>
        public static void Build(RuntimeTypeModel runtimeTypeModel, Type type) {
            if (BuiltTypes.Contains(type))
                return;

            lock (type) {
                if (BuiltTypes.Contains(type))
                    return;

                if (runtimeTypeModel.CanSerialize(type)) {
                    if (type.IsGenericType)
                        BuildGenerics(runtimeTypeModel, type);
                    return;
                }

                var meta = runtimeTypeModel.Add(type, false);
                var fields = type.GetFields(Flags);

                meta.Add(fields.Select(m => m.Name).ToArray());
                meta.UseConstructor = false;

                BuildBaseClasses(runtimeTypeModel, type);
                BuildGenerics(runtimeTypeModel, type);

                foreach (var memberType in fields.Select(f => f.FieldType).Where(t => !t.IsPrimitive))
                    Build(runtimeTypeModel, memberType);

                BuiltTypes.Add(type);
            }
        }

        private static void BuildBaseClasses(RuntimeTypeModel runtimeTypeModel, Type type) {
            var baseType = type.BaseType;
            var inheritingType = type;

            while (baseType != null && baseType != ObjectType) {
                if (!SubTypes.TryGetValue(baseType, out var baseTypedEntry))
                    SubTypes.TryAdd(baseType, baseTypedEntry = new HashSet<Type>());

                if (!baseTypedEntry.Contains(inheritingType)) {
                    Build(runtimeTypeModel, baseType);
                    runtimeTypeModel[baseType].AddSubType(baseTypedEntry.Count + 500, inheritingType);
                    baseTypedEntry.Add(inheritingType);
                }

                inheritingType = baseType;
                baseType = baseType.BaseType;
            }
        }

        private static void BuildGenerics(RuntimeTypeModel runtimeTypeModel, Type type) {
            if (!type.IsGenericType && (type.BaseType == null || !type.BaseType.IsGenericType)) return;
            var generics = type.IsGenericType ? type.GetGenericArguments() : type.BaseType.GetGenericArguments();

            foreach (var generic in generics)
                Build(runtimeTypeModel, generic);
        }
    }
}