/*
The MIT License (MIT)
Copyright (c) 2016-2019 Maksim Volkau
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included AddOrUpdateServiceFactory
all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

// ReSharper disable CoVariantArrayConversion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

/*
 *  Reference to:
 *      dadhi/FastExpressionCompiler
 *      Author: Maksim Volkau
 *      URL: https://github.com/dadhi/FastExpressionCompiler
 *      MIT
 */

namespace Cosmos.Expressions
{
    // Helpers targeting the performance. Extensions method names may be a bit funny (non standard), 
    // in order to prevent conflicts with YOUR helpers with standard names
    internal static class Tools
    {
        internal static bool IsValueType(this Type type) => type.GetTypeInfo().IsValueType;
        internal static bool IsPrimitive(this Type type) => type.GetTypeInfo().IsPrimitive;
        internal static bool IsClass(this Type type) => type.GetTypeInfo().IsClass;

        internal static bool IsUnsigned(this Type type) =>
            type == typeof(byte) || type == typeof(ushort) || type == typeof(uint) || type == typeof(ulong);

        internal static bool IsNullable(this Type type) =>
            type.GetTypeInfo().IsGenericType && type.GetTypeInfo().GetGenericTypeDefinition() == typeof(Nullable<>);

        internal static PropertyInfo FindProperty(this Type type, string propertyName) =>
            type.GetTypeInfo().GetDeclaredProperty(propertyName);

        internal static FieldInfo FindField(this Type type, string fieldName) =>
            type.GetTypeInfo().GetDeclaredField(fieldName);

        internal static MethodInfo FindMethod(this Type type, string methodName) =>
            type.GetTypeInfo().GetDeclaredMethod(methodName);

        internal static MethodInfo FindDelegateInvokeMethod(this Type type) =>
            type.GetTypeInfo().GetDeclaredMethod("Invoke");

        internal static MethodInfo FindNullableGetValueOrDefaultMethod(this Type type) =>
            type.GetTypeInfo().GetDeclaredMethods("GetValueOrDefault").GetFirst(x => x.GetParameters().Length == 0);

        internal static MethodInfo FindValueGetterMethod(this Type type) =>
            type.GetTypeInfo().GetDeclaredMethod("get_Value");

        internal static MethodInfo FindNullableHasValueGetterMethod(this Type type) =>
            type.GetTypeInfo().GetDeclaredMethod("get_HasValue");

        internal static MethodInfo FindPropertyGetMethod(this PropertyInfo prop) =>
            prop.DeclaringType.GetTypeInfo().GetDeclaredMethod("get_" + prop.Name);

        internal static MethodInfo FindPropertySetMethod(this PropertyInfo prop) =>
            prop.DeclaringType.GetTypeInfo().GetDeclaredMethod("set_" + prop.Name);

        internal static MethodInfo FindConvertOperator(this Type type, Type sourceType, Type targetType) =>
            type.GetTypeInfo().DeclaredMethods.GetFirst(m =>
                m.IsStatic && m.ReturnType == targetType &&
                (m.Name == "op_Implicit" || m.Name == "op_Explicit") &&
                m.GetParameters()[0].ParameterType == sourceType);

        internal static ConstructorInfo FindSingleParamConstructor(this Type type, Type paramType)
        {
            foreach (var ctor in type.GetTypeInfo().DeclaredConstructors)
            {
                var parameters = ctor.GetParameters();
                if (parameters.Length == 1 && parameters[0].ParameterType == paramType)
                    return ctor;
            }

            return null;
        }

        // todo: test what is faster? Copy and inline switch? Switch in method? Ors in method?
        internal static ExpressionType GetArithmeticFromArithmeticAssignOrSelf(ExpressionType arithmetic)
        {
            switch (arithmetic)
            {
                case ExpressionType.AddAssign: return ExpressionType.Add;
                case ExpressionType.AddAssignChecked: return ExpressionType.AddChecked;
                case ExpressionType.SubtractAssign: return ExpressionType.Subtract;
                case ExpressionType.SubtractAssignChecked: return ExpressionType.SubtractChecked;
                case ExpressionType.MultiplyAssign: return ExpressionType.Multiply;
                case ExpressionType.MultiplyAssignChecked: return ExpressionType.MultiplyChecked;
                case ExpressionType.DivideAssign: return ExpressionType.Divide;
                case ExpressionType.ModuloAssign: return ExpressionType.Modulo;
                case ExpressionType.PowerAssign: return ExpressionType.Power;
                case ExpressionType.AndAssign: return ExpressionType.And;
                case ExpressionType.OrAssign: return ExpressionType.Or;
                case ExpressionType.ExclusiveOrAssign: return ExpressionType.ExclusiveOr;
                case ExpressionType.LeftShiftAssign: return ExpressionType.LeftShift;
                case ExpressionType.RightShiftAssign: return ExpressionType.RightShift;
                default: return arithmetic;
            }
        }

        public static T[] AsArray<T>(this IEnumerable<T> xs) => xs as T[] ?? xs.ToArray();

        public static IReadOnlyList<T> AsReadOnlyList<T>(this IEnumerable<T> xs) =>
            xs as IReadOnlyList<T> ?? xs.ToArray();

        private static class EmptyArray<T>
        {
            public static readonly T[] Value = new T[0];
        }

        public static T[] Empty<T>() => EmptyArray<T>.Value;

        public static T[] WithLast<T>(this T[] source, T value)
        {
            if (source == null || source.Length == 0)
                return new[] { value };
            if (source.Length == 1)
                return new[] { source[0], value };
            if (source.Length == 2)
                return new[] { source[0], source[1], value };
            var sourceLength = source.Length;
            var result = new T[sourceLength + 1];
            Array.Copy(source, result, sourceLength);
            result[sourceLength] = value;
            return result;
        }

        public static Type[] GetParamTypes(IReadOnlyList<ParameterExpression> paramExprs)
        {
            if (paramExprs == null || paramExprs.Count == 0)
                return Empty<Type>();

            if (paramExprs.Count == 1)
                return new[] { paramExprs[0].IsByRef ? paramExprs[0].Type.MakeByRefType() : paramExprs[0].Type };

            var paramTypes = new Type[paramExprs.Count];
            for (var i = 0; i < paramTypes.Length; i++)
            {
                var parameterExpr = paramExprs[i];
                paramTypes[i] = parameterExpr.IsByRef ? parameterExpr.Type.MakeByRefType() : parameterExpr.Type;
            }

            return paramTypes;
        }

        public static Type GetFuncOrActionType(Type[] paramTypes, Type returnType)
        {
            if (returnType == typeof(void))
            {
                switch (paramTypes.Length)
                {
                    case 0: return typeof(Action);
                    case 1: return typeof(Action<>).MakeGenericType(paramTypes);
                    case 2: return typeof(Action<,>).MakeGenericType(paramTypes);
                    case 3: return typeof(Action<,,>).MakeGenericType(paramTypes);
                    case 4: return typeof(Action<,,,>).MakeGenericType(paramTypes);
                    case 5: return typeof(Action<,,,,>).MakeGenericType(paramTypes);
                    case 6: return typeof(Action<,,,,,>).MakeGenericType(paramTypes);
                    case 7: return typeof(Action<,,,,,,>).MakeGenericType(paramTypes);
                    default:
                        throw new NotSupportedException(
                            $"Action with so many ({paramTypes.Length}) parameters is not supported!");
                }
            }

            paramTypes = paramTypes.WithLast(returnType);
            switch (paramTypes.Length)
            {
                case 1: return typeof(Func<>).MakeGenericType(paramTypes);
                case 2: return typeof(Func<,>).MakeGenericType(paramTypes);
                case 3: return typeof(Func<,,>).MakeGenericType(paramTypes);
                case 4: return typeof(Func<,,,>).MakeGenericType(paramTypes);
                case 5: return typeof(Func<,,,,>).MakeGenericType(paramTypes);
                case 6: return typeof(Func<,,,,,>).MakeGenericType(paramTypes);
                case 7: return typeof(Func<,,,,,,>).MakeGenericType(paramTypes);
                case 8: return typeof(Func<,,,,,,,>).MakeGenericType(paramTypes);
                default:
                    throw new NotSupportedException(
                        string.Format("Func with so many ({0}) parameters is not supported!", paramTypes.Length));
            }
        }

        public static int GetFirstIndex<T>(this IReadOnlyList<T> source, T item)
        {
            if (source == null || source.Count == 0)
                return -1;
            var count = source.Count;
            if (count == 1)
                return ReferenceEquals(source[0], item) ? 0 : -1;
            for (var i = 0; i < count; ++i)
                if (ReferenceEquals(source[i], item))
                    return i;
            return -1;
        }

        public static int GetFirstIndex<T>(this T[] source, Func<T, bool> predicate)
        {
            if (source == null || source.Length == 0)
                return -1;
            if (source.Length == 1)
                return predicate(source[0]) ? 0 : -1;
            for (var i = 0; i < source.Length; ++i)
                if (predicate(source[i]))
                    return i;
            return -1;
        }

        public static T GetFirst<T>(this IEnumerable<T> source)
        {
            var list = source as IReadOnlyList<T>;
            return list == null ? source.FirstOrDefault() : list.Count != 0 ? list[0] : default(T);
        }

        public static T GetFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var arr = source as T[];
            if (arr == null)
                return source.FirstOrDefault(predicate);
            var index = arr.GetFirstIndex(predicate);
            return index == -1 ? default(T) : arr[index];
        }

        public static R[] Map<T, R>(this IReadOnlyList<T> source, Func<T, R> project)
        {
            if (source == null || source.Count == 0)
                return Empty<R>();

            if (source.Count == 1)
                return new[] { project(source[0]) };

            var result = new R[source.Count];
            for (var i = 0; i < result.Length; ++i)
                result[i] = project(source[i]);
            return result;
        }
    }
}
