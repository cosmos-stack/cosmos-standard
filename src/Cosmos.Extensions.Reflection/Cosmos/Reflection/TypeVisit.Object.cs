using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;

// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PossibleNullReferenceException

namespace Cosmos.Reflection
{
    public enum DeepCopyOptions
    {
        DeepCopier = 0,
        ExpressionCopier = 1,
    }

    /// <summary>
    /// Type visit, an advanced TypeReflections utility.
    /// </summary>
    public static partial class TypeVisit
    {
        public static T DeepCopy<T>(T value, DeepCopyOptions options = DeepCopyOptions.DeepCopier)
        {
            return options switch
            {
                DeepCopyOptions.DeepCopier => DeepCopier.Copy(value),
                DeepCopyOptions.ExpressionCopier => ExpressionCopier<T>.Copy(value),
                _ => ExpressionCopier<T>.Copy(value)
            };
        }

        public static T DeepCopy<T>(T value, DeepCopyContext context)
        {
            return DeepCopier.Copy(value, context);
        }
    }

    /// <summary>
    /// Type metadata visit, a meta information access entry for TypeReflections and TypeVisit.
    /// </summary>
    public static partial class TypeMetaVisitExtensions
    {
        public static T DeepCopy<T>(this T x, DeepCopyOptions options = DeepCopyOptions.DeepCopier)
        {
            return TypeVisit.DeepCopy(x, options);
        }

        public static T DeepCopy<T>(this T x, DeepCopyContext context)
        {
            return TypeVisit.DeepCopy(x, context);
        }
    }

    #region ExpressionCopier

    /*
     * Reference to:
     *  ldqk/Masuit.Tools
     *      Author: LDQK/Masuit
     *      URL: https://github.com/ldqk/Masuit.Tools
     *      Blog: https://masuit.com
     *      MIT
     */

    internal static class ExpressionCopier<T>
    {
        // ReSharper disable once InconsistentNaming
        private static readonly ParameterExpression _parameterExpression = Expression.Parameter(typeof(T), "p");

        // ReSharper disable once InconsistentNaming
        // ReSharper disable once CollectionNeverUpdated.Local
        // ReSharper disable once StaticMemberInGenericType
        private static readonly Dictionary<string, Expression> _check = new Dictionary<string, Expression>();
        private static Func<T, T> _func;

        /// <summary>
        /// Deep copy by expression
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T Copy(T source)
        {
            if (_func is null)
            {
                var memberBindings = new List<MemberBinding>();

                foreach (var item in GetAllPropertiesOrFields())
                {
                    if (_check.ContainsKey(item.Name))
                    {
                        var memberBinding = Expression.Bind(item, _check[item.Name]);
                        memberBindings.Add(memberBinding);
                    }
                    else
                    {
                        if (typeof(T).GetProperty(item.Name) != null || typeof(T).GetField(item.Name) != null)
                        {
                            var memberBinding = Expression.Bind(
                                item,
                                Expression.PropertyOrField(_parameterExpression, item.Name));
                            memberBindings.Add(memberBinding);
                        }
                    }
                }

                var memberInitExpression = Expression.MemberInit(Expression.New(typeof(T)), memberBindings.ToArray());
                var lambda = Expression.Lambda<Func<T, T>>(memberInitExpression, _parameterExpression);
                _func = lambda.Compile();
            }

            return _func.Invoke(source);
        }

        private static IEnumerable<MemberInfo> GetAllPropertiesOrFields()
        {
            foreach (var item in typeof(T).GetProperties())
                yield return item;
            foreach (var item in typeof(T).GetFields())
                yield return item;
        }
    }

    #endregion

    #region DeepCopier

    /*
     *
     *
     * MIT License
     * 
     * Copyright (c) 2017 Reuben Bond
     * 
     * Permission is hereby granted, free of charge, to any person obtaining a copy
     * of this software and associated documentation files (the "Software"), to deal
     * in the Software without restriction, including without limitation the rights
     * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
     * copies of the Software, and to permit persons to whom the Software is
     * furnished to do so, subject to the following conditions:
     * 
     * The above copyright notice and this permission notice shall be included in all
     * copies or substantial portions of the Software.
     * 
     * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
     * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
     * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
     * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
     * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
     * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
     * SOFTWARE.
     */

    /// <summary>
    /// Records details about copied objects.
    /// </summary>
    public sealed class DeepCopyContext
    {
        // ReSharper disable once InconsistentNaming
        private readonly Dictionary<object, object> copies = new(16, ReferenceEqualsComparer.Instance);

        /// <summary>
        /// Records <paramref name="copy"/> as a copy of <paramref name="original"/>.
        /// </summary>
        /// <param name="original">The original object.</param>
        /// <param name="copy">The copy of <paramref name="original"/>.</param>
        public void RecordCopy(object original, object copy) => copies[original] = copy;

        /// <summary>
        /// Returns the copy of <paramref name="original"/> if it has been copied or <see langword="null"/> if it has not yet been copied.
        /// </summary>
        /// <param name="original">The original object.</param>
        /// <param name="result">The copied object.</param>
        /// <returns>The copy of <paramref name="original"/> or <see langword="null"/> if no copy has been made.</returns>
        public bool TryGetCopy(object original, out object result) => copies.TryGetValue(original, out result);

        /// <summary>
        /// Resets this instance so that it can be reused.
        /// </summary>
        internal void Reset() => copies.Clear();
    }

    internal delegate T DeepCopyDelegate<T>(T original, DeepCopyContext context);

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class)]
    internal sealed class ImmutableAttribute : Attribute { }

    internal static class Immutable
    {
        public static Immutable<T> Create<T>(T value) => new(value);
    }

    [Immutable]
    internal struct Immutable<T>
    {
        public Immutable(T value) => Value = value;
        public T Value { get; }
    }

    internal sealed class CopyPolicy
    {
        private enum Policy
        {
            Tracking,
            Mutable,
            Immutable
        }

        private readonly ConcurrentDictionary<Type, Policy> _policies = new();
        private readonly RuntimeTypeHandle _intPtrTypeHandle = typeof(IntPtr).TypeHandle;
        private readonly RuntimeTypeHandle _uIntPtrTypeHandle = typeof(UIntPtr).TypeHandle;
        private readonly Type _delegateType = typeof(Delegate);

        public CopyPolicy() => _policies[typeof(object)] = Policy.Tracking;

        public List<FieldInfo> GetCopyableFields(Type type)
        {
            var result =
                GetAllFields(type)
                    .Where(field => IsSupportedFieldType(field.FieldType))
                    .ToList();
            result.Sort(FieldInfoComparer.Instance);
            return result;

            IEnumerable<FieldInfo> GetAllFields(Type containingType)
            {
                const BindingFlags allFields =
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
                var current = containingType;
                while (current != typeof(object) && current != null)
                {
                    var fields = current.GetFields(allFields);
                    foreach (var field in fields)
                    {
                        yield return field;
                    }

                    current = current.BaseType;
                }
            }

            bool IsSupportedFieldType(Type fieldType)
            {
                if (fieldType.IsPointer || fieldType.IsByRef) return false;

                var handle = fieldType.TypeHandle;
                if (handle.Equals(_intPtrTypeHandle)) return false;
                if (handle.Equals(_uIntPtrTypeHandle)) return false;
                if (_delegateType.IsAssignableFrom(fieldType)) return false;

                return true;
            }
        }

        public bool IsImmutable(Type type) => GetPolicy(type) == Policy.Immutable;

        public bool NeedsTracking(Type type)
        {
            if (type.IsValueType)
            {
                return false;
            }

            var policy = GetPolicy(type);
            if (policy == Policy.Mutable)
            {
                var copyableFields = GetCopyableFields(type);
                var queue = new Queue<FieldInfo>(copyableFields);
                var duplicateCheck = new HashSet<Type>(AssignableFromEqualityComparer.Instance) {type};
                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    var fieldType = current.FieldType;
                    var fieldPolicy = GetPolicy(fieldType);
                    if (fieldPolicy == Policy.Immutable)
                    {
                        continue;
                    }

                    if (fieldPolicy == Policy.Tracking)
                    {
                        _policies[type] = Policy.Tracking;
                        return true;
                    }

                    if (duplicateCheck.Add(fieldType))
                    {
                        if (typeof(IEnumerable).IsAssignableFrom(fieldType))
                        {
                            _policies[type] = Policy.Tracking;
                            return true;
                        }

                        var fieldFields = GetCopyableFields(fieldType);
                        foreach (var fieldField in fieldFields)
                        {
                            queue.Enqueue(fieldField);
                        }
                    }
                    else
                    {
                        _policies[type] = Policy.Tracking;
                        return true;
                    }
                }
            }

            return GetPolicy(type) == Policy.Tracking;
        }

        private Policy GetPolicy(Type type)
        {
            if (_policies.TryGetValue(type, out var result))
            {
                return result;
            }

            if (type.GetCustomAttribute<ImmutableAttribute>(false) != null)
            {
                return _policies[type] = Policy.Immutable;
            }

            if (type.IsPrimitive || type.IsEnum || type.IsPointer || type == typeof(string))
            {
                return _policies[type] = Policy.Immutable;
            }

            if (!type.IsSealed)
            {
                return _policies[type] = Policy.Mutable;
            }

            if (type.IsArray)
            {
                return _policies[type] = Policy.Mutable;
            }

            if (type.IsValueType)
            {
                var copyableFields = GetCopyableFields(type);
                foreach (var copyableField in copyableFields)
                {
                    var fieldType = copyableField.FieldType;
                    if (GetPolicy(fieldType) != Policy.Immutable)
                    {
                        return _policies[type] = Policy.Mutable;
                    }
                }
            }

            else if (type.IsClass)
            {
                var copyableFields = GetCopyableFields(type);
                foreach (var copyableField in copyableFields)
                {
                    if (!copyableField.IsInitOnly)
                    {
                        return _policies[type] = Policy.Mutable;
                    }

                    var fieldType = copyableField.FieldType;
                    if (GetPolicy(fieldType) != Policy.Immutable)
                    {
                        return _policies[type] = Policy.Mutable;
                    }
                }
            }

            return _policies[type] = Policy.Immutable;
        }

        private sealed class FieldInfoComparer : IComparer<FieldInfo>
        {
            public static FieldInfoComparer Instance { get; } = new();

            public int Compare(FieldInfo x, FieldInfo y)
            {
                return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
            }
        }

        private sealed class AssignableFromEqualityComparer : IEqualityComparer<Type>
        {
            public static AssignableFromEqualityComparer Instance { get; } = new();
            private static readonly Type ObjectType = typeof(object);

            public bool Equals(Type x, Type y)
            {
                if (x == ObjectType || y == ObjectType)
                {
                    return false;
                }

                return x.IsAssignableFrom(y) || y.IsAssignableFrom(x);
            }

            public int GetHashCode(Type obj) => 0;
        }
    }

    internal sealed class MethodInfos
    {
        public readonly MethodInfo TryGetCopy;
        public readonly MethodInfo RecordObject;
        public readonly MethodInfo CopyInner;
        public readonly MethodInfo GetUninitializedObject;
        public readonly MethodInfo GetTypeFromHandle;
        public readonly MethodInfo CopyArrayRank1Shallow;
        public readonly MethodInfo CopyArrayRank1;
        public readonly MethodInfo CopyArrayRank2Shallow;
        public readonly MethodInfo CopyArrayRank2;

        public MethodInfos()
        {
            GetUninitializedObject = GetFuncCall(() => FormatterServices.GetUninitializedObject(typeof(int)));
            GetTypeFromHandle = GetFuncCall(() => Type.GetTypeFromHandle(typeof(Type).TypeHandle));
            CopyInner = GetFuncCall(() => DeepCopier.Copy(default(object), default)).GetGenericMethodDefinition();
            TryGetCopy = typeof(DeepCopyContext).GetMethod("TryGetCopy");
            RecordObject = GetActionCall((DeepCopyContext ctx) => ctx.RecordCopy(default, default));

            CopyArrayRank1Shallow = GetFuncCall(() => ArrayCopier.CopyArrayRank1Shallow(default(object[]), default)).GetGenericMethodDefinition();
            CopyArrayRank1 = GetFuncCall(() => ArrayCopier.CopyArrayRank1(default(object[]), default)).GetGenericMethodDefinition();

            CopyArrayRank2Shallow = GetFuncCall(() => ArrayCopier.CopyArrayRank2Shallow(default(object[,]), default)).GetGenericMethodDefinition();
            CopyArrayRank2 = GetFuncCall(() => ArrayCopier.CopyArrayRank2(default(object[,]), default)).GetGenericMethodDefinition();

            MethodInfo GetActionCall<T>(Expression<Action<T>> expression)
            {
                return (expression.Body as MethodCallExpression)?.Method
                    ?? throw new ArgumentException("Expression type unsupported.");
            }

            MethodInfo GetFuncCall<T>(Expression<Func<T>> expression)
            {
                return (expression.Body as MethodCallExpression)?.Method
                    ?? throw new ArgumentException("Expression type unsupported.");
            }
        }
    }

    internal static class ArrayCopier
    {
        internal static T[] CopyArrayRank1<T>(T[] originalArray, DeepCopyContext context)
        {
            if (context.TryGetCopy(originalArray, out var existingCopy)) return (T[]) existingCopy;

            var length = originalArray.Length;
            var result = new T[length];
            context.RecordCopy(originalArray, result);
            for (var i = 0; i < length; i++)
            {
                var original = originalArray[i];
                if (original != null)
                {
                    if (context.TryGetCopy(original, out var existingElement))
                    {
                        result[i] = (T) existingElement;
                    }
                    else
                    {
                        var copy = CopierGenerator<T>.Copy(original, context);
                        context.RecordCopy(original, copy);
                        result[i] = copy;
                    }
                }
            }

            return result;
        }

        internal static T[,] CopyArrayRank2<T>(T[,] originalArray, DeepCopyContext context)
        {
            if (context.TryGetCopy(originalArray, out var existingCopy)) return (T[,]) existingCopy;

            var lenI = originalArray.GetLength(0);
            var lenJ = originalArray.GetLength(1);
            var result = new T[lenI, lenJ];
            context.RecordCopy(originalArray, result);
            for (var i = 0; i < lenI; i++)
            {
                for (var j = 0; j < lenJ; j++)
                {
                    var original = originalArray[i, j];
                    if (original != null)
                    {
                        if (context.TryGetCopy(original, out var existingElement))
                        {
                            result[i, j] = (T) existingElement;
                        }
                        else
                        {
                            var copy = CopierGenerator<T>.Copy(original, context);
                            context.RecordCopy(original, copy);
                            result[i, j] = copy;
                        }
                    }
                }
            }

            return result;
        }

        internal static T[] CopyArrayRank1Shallow<T>(T[] array, DeepCopyContext context)
        {
            if (context.TryGetCopy(array, out var existingCopy)) return (T[]) existingCopy;

            var length = array.Length;
            var result = new T[length];
            context.RecordCopy(array, result);
            Array.Copy(array, result, length);
            return result;
        }

        internal static T[,] CopyArrayRank2Shallow<T>(T[,] array, DeepCopyContext context)
        {
            if (context.TryGetCopy(array, out var existingCopy)) return (T[,]) existingCopy;

            var lenI = array.GetLength(0);
            var lenJ = array.GetLength(1);
            var result = new T[lenI, lenJ];
            context.RecordCopy(array, result);
            Array.Copy(array, result, array.Length);
            return result;
        }

        internal static T CopyArray<T>(T array, DeepCopyContext context)
        {
            if (context.TryGetCopy(array, out var existingCopy)) return (T) existingCopy;

            var originalArray = array as Array;
            if (originalArray == null) throw new InvalidCastException($"Cannot cast non-array type {array?.GetType()} to Array.");
            var elementType = array.GetType().GetElementType();

            var rank = originalArray.Rank;
            var lengths = new int[rank];
            for (var i = 0; i < rank; i++)
            {
                lengths[i] = originalArray.GetLength(i);
            }

            var copyArray = Array.CreateInstance(elementType, lengths);
            context.RecordCopy(originalArray, copyArray);

            if (DeepCopier.CopyPolicy.IsImmutable(elementType))
            {
                Array.Copy(originalArray, copyArray, originalArray.Length);
            }

            var index = new int[rank];
            var sizes = new int[rank];
            sizes[rank - 1] = 1;
            for (var k = rank - 2; k >= 0; k--)
            {
                sizes[k] = sizes[k + 1] * lengths[k + 1];
            }

            for (var i = 0; i < originalArray.Length; i++)
            {
                var k = i;
                for (var n = 0; n < rank; n++)
                {
                    var offset = k / sizes[n];
                    k = k - offset * sizes[n];
                    index[n] = offset;
                }

                var original = originalArray.GetValue(index);
                if (original != null)
                {
                    if (context.TryGetCopy(original, out var existingElement))
                    {
                        copyArray.SetValue(existingElement, index);
                    }
                    else
                    {
                        var copy = DeepCopier.Copy(originalArray.GetValue(index), context);
                        context.RecordCopy(original, copy);
                        copyArray.SetValue(copy, index);
                    }
                }
            }

            return (T) (object) copyArray;
        }
    }

    internal static class CopierGenerator<T>
    {
        private static readonly ConcurrentDictionary<Type, DeepCopyDelegate<T>> Copiers = new();
        private static readonly Type GenericType = typeof(T);
        private static readonly DeepCopyDelegate<T> MatchingTypeCopier = CreateCopier(GenericType);
        private static readonly Func<Type, DeepCopyDelegate<T>> GenerateCopier = CreateCopier;

        public static T Copy(T original, DeepCopyContext context)
        {
            if (original is null) return original;
            var type = original.GetType();
            if (type == GenericType) return MatchingTypeCopier(original, context);
            var result = Copiers.GetOrAdd(type, GenerateCopier);
            return result(original, context);
        }

        private static DeepCopyDelegate<T> CreateCopier(Type type)
        {
            if (type.IsArray)
            {
                return CreateArrayCopier(type);
            }

            if (DeepCopier.CopyPolicy.IsImmutable(type)) return (original, _) => original;

            // By-ref types are not supported.
            if (type.IsByRef) return ThrowNotSupportedType(type);

            var dynamicMethod = new DynamicMethod(
                type.Name + "DeepCopier",
                typeof(T),
                new[] {typeof(T), typeof(DeepCopyContext)},
                typeof(DeepCopier).Module,
                true);

            var il = dynamicMethod.GetILGenerator();

            // Declare a variable to store the result.
            il.DeclareLocal(type);

            var needsTracking = DeepCopier.CopyPolicy.NeedsTracking(type);
            var hasCopyLabel = il.DefineLabel();
            if (needsTracking)
            {
                // C#: if (context.TryGetCopy(original, out object existingCopy)) return (T)existingCopy;
                il.DeclareLocal(typeof(object));
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldloca_S, (byte) 1);
                il.Emit(OpCodes.Call, DeepCopier.MethodInfos.TryGetCopy);
                il.Emit(OpCodes.Brtrue, hasCopyLabel);
            }

            // Construct the result.
            var constructorInfo = type.GetConstructor(Type.EmptyTypes);
            if (type.IsValueType)
            {
                // Value types can be initialized directly.
                il.Emit(OpCodes.Ldloca_S, (byte) 0);
                il.Emit(OpCodes.Initobj, type);
            }
            else if (constructorInfo != null)
            {
                // If a default constructor exists, use that.
                il.Emit(OpCodes.Newobj, constructorInfo);
                il.Emit(OpCodes.Stloc_0);
            }
            else
            {
                // If no default constructor exists, create an instance using GetUninitializedObject
                il.Emit(OpCodes.Ldtoken, type);
                il.Emit(OpCodes.Call, DeepCopier.MethodInfos.GetTypeFromHandle);
                il.Emit(OpCodes.Call, DeepCopier.MethodInfos.GetUninitializedObject);
                il.Emit(OpCodes.Castclass, type);
                il.Emit(OpCodes.Stloc_0);
            }

            // An instance of a value types can never appear multiple times in an object graph,
            // so only record reference types in the context.
            if (needsTracking)
            {
                // Record the object.
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldloc_0);
                il.Emit(OpCodes.Call, DeepCopier.MethodInfos.RecordObject);
            }

            // Copy each field.
            foreach (var field in DeepCopier.CopyPolicy.GetCopyableFields(type))
            {
                // Load a reference to the result.
                if (type.IsValueType)
                {
                    // Value types need to be loaded by address rather than copied onto the stack.
                    il.Emit(OpCodes.Ldloca_S, (byte) 0);
                }
                else
                {
                    il.Emit(OpCodes.Ldloc_0);
                }

                // Load the field from the result.
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldfld, field);

                // Deep-copy the field if needed, otherwise just leave it as-is.
                if (!DeepCopier.CopyPolicy.IsImmutable(field.FieldType))
                {
                    // Copy the field using the generic DeepCopy.Copy<T> method.
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Call, DeepCopier.MethodInfos.CopyInner.MakeGenericMethod(field.FieldType));
                }

                // Store the copy of the field on the result.
                il.Emit(OpCodes.Stfld, field);
            }

            // Return the result.
            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Ret);

            if (needsTracking)
            {
                // only non-ValueType needsTracking
                il.MarkLabel(hasCopyLabel);
                il.Emit(OpCodes.Ldloc_1);
                il.Emit(OpCodes.Castclass, type);
                il.Emit(OpCodes.Ret);
            }

            return dynamicMethod.CreateDelegate(typeof(DeepCopyDelegate<T>)) as DeepCopyDelegate<T>;
        }

        private static DeepCopyDelegate<T> CreateArrayCopier(Type type)
        {
            var elementType = type.GetElementType();

            var rank = type.GetArrayRank();
            var isImmutable = DeepCopier.CopyPolicy.IsImmutable(elementType);
            MethodInfo methodInfo;
            switch (rank)
            {
                case 1:
                    if (isImmutable)
                    {
                        methodInfo = DeepCopier.MethodInfos.CopyArrayRank1Shallow;
                    }
                    else
                    {
                        methodInfo = DeepCopier.MethodInfos.CopyArrayRank1;
                    }

                    break;
                case 2:
                    if (isImmutable)
                    {
                        methodInfo = DeepCopier.MethodInfos.CopyArrayRank2Shallow;
                    }
                    else
                    {
                        methodInfo = DeepCopier.MethodInfos.CopyArrayRank2;
                    }

                    break;
                default:
                    return ArrayCopier.CopyArray;
            }

            return (DeepCopyDelegate<T>) methodInfo.MakeGenericMethod(elementType).CreateDelegate(typeof(DeepCopyDelegate<T>));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static DeepCopyDelegate<T> ThrowNotSupportedType(Type type)
        {
            throw new NotSupportedException($"Unable to copy object of type {type}.");
        }
    }

    internal sealed class ReferenceEqualsComparer : IEqualityComparer<object>
    {
        public static ReferenceEqualsComparer Instance { get; } = new();

        bool IEqualityComparer<object>.Equals(object x, object y)
        {
            return ReferenceEquals(x, y);
        }

        int IEqualityComparer<object>.GetHashCode(object obj)
        {
            return obj is null ? 0 : RuntimeHelpers.GetHashCode(obj);
        }
    }

    internal static class DeepCopier
    {
        internal static readonly CopyPolicy CopyPolicy = new();
        internal static readonly MethodInfos MethodInfos = new();
        private static readonly ThreadLocal<DeepCopyContext> Context = new(() => new DeepCopyContext());

        public static T Copy<T>(T original)
        {
            var context = Context.Value;
            try
            {
                return CopierGenerator<T>.Copy(original, context);
            }
            finally
            {
                context.Reset();
            }
        }

        public static T Copy<T>(T original, DeepCopyContext context)
        {
            return CopierGenerator<T>.Copy(original, context);
        }
    }

    #endregion
}