using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Cosmos.Reflection
{
    public enum TypeOfOptions
    {
        Owner = 0,
        Underlying = 1
    }

    /// <summary>
    /// Type Utilities
    /// </summary>
    public static partial class Types
    {
        /// <summary>
        /// Return the corresponding type according to the given generic parameter. <br />
        /// 根据给定的通用参数返回相应的类型。
        /// </summary>
        /// <typeparam name="T">Special type T</typeparam>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type Of<T>(TypeOfOptions options = TypeOfOptions.Owner)
        {
            return options switch
            {
                TypeOfOptions.Owner => typeof(T),
                TypeOfOptions.Underlying => TypeConv.GetNonNullableType<T>(),
                _ => typeof(T)
            };
        }

        /// <summary>
        /// Return the corresponding type according to the given generic parameter. <br />
        /// 根据给定的通用参数返回相应的类型。
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> Of<T1, T2>(TypeOfOptions options = TypeOfOptions.Owner)
        {
            var types = new Type[2];

            types[0] = Of<T1>(options);
            types[1] = Of<T2>(options);

            return types;
        }

        /// <summary>
        /// Return the corresponding type according to the given generic parameter. <br />
        /// 根据给定的通用参数返回相应的类型。
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> Of<T1, T2, T3>(TypeOfOptions options = TypeOfOptions.Owner)
        {
            var types = new Type[3];

            types[0] = Of<T1>(options);
            types[1] = Of<T2>(options);
            types[2] = Of<T3>(options);

            return types;
        }

        /// <summary>
        /// Return the corresponding type according to the given generic parameter. <br />
        /// 根据给定的通用参数返回相应的类型。
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> Of<T1, T2, T3, T4>(TypeOfOptions options = TypeOfOptions.Owner)
        {
            var types = new Type[4];

            types[0] = Of<T1>(options);
            types[1] = Of<T2>(options);
            types[2] = Of<T3>(options);
            types[3] = Of<T4>(options);

            return types;
        }

        /// <summary>
        /// Return the corresponding type according to the given generic parameter. <br />
        /// 根据给定的通用参数返回相应的类型。
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> Of<T1, T2, T3, T4, T5>(TypeOfOptions options = TypeOfOptions.Owner)
        {
            var types = new Type[5];

            types[0] = Of<T1>(options);
            types[1] = Of<T2>(options);
            types[2] = Of<T3>(options);
            types[3] = Of<T4>(options);
            types[4] = Of<T5>(options);

            return types;
        }

        /// <summary>
        /// Return the corresponding type according to the given generic parameter. <br />
        /// 根据给定的通用参数返回相应的类型。
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> Of<T1, T2, T3, T4, T5, T6>(TypeOfOptions options = TypeOfOptions.Owner)
        {
            var types = new Type[6];

            types[0] = Of<T1>(options);
            types[1] = Of<T2>(options);
            types[2] = Of<T3>(options);
            types[3] = Of<T4>(options);
            types[4] = Of<T5>(options);
            types[5] = Of<T6>(options);

            return types;
        }

        /// <summary>
        /// Return the corresponding type according to the given generic parameter. <br />
        /// 根据给定的通用参数返回相应的类型。
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> Of<T1, T2, T3, T4, T5, T6, T7>(TypeOfOptions options = TypeOfOptions.Owner)
        {
            var types = new Type[7];

            types[0] = Of<T1>(options);
            types[1] = Of<T2>(options);
            types[2] = Of<T3>(options);
            types[3] = Of<T4>(options);
            types[4] = Of<T5>(options);
            types[5] = Of<T6>(options);
            types[6] = Of<T7>(options);

            return types;
        }

        /// <summary>
        /// Return the corresponding type according to the given generic parameter. <br />
        /// 根据给定的通用参数返回相应的类型。
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> Of<T1, T2, T3, T4, T5, T6, T7, T8>(TypeOfOptions options = TypeOfOptions.Owner)
        {
            var types = new Type[8];

            types[0] = Of<T1>(options);
            types[1] = Of<T2>(options);
            types[2] = Of<T3>(options);
            types[3] = Of<T4>(options);
            types[4] = Of<T5>(options);
            types[5] = Of<T6>(options);
            types[6] = Of<T7>(options);
            types[7] = Of<T8>(options);

            return types;
        }

        /// <summary>
        /// Return the corresponding type according to the given generic parameter. <br />
        /// 根据给定的通用参数返回相应的类型。
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> Of<T1, T2, T3, T4, T5, T6, T7, T8, T9>(TypeOfOptions options = TypeOfOptions.Owner)
        {
            var types = new Type[9];

            types[0] = Of<T1>(options);
            types[1] = Of<T2>(options);
            types[2] = Of<T3>(options);
            types[3] = Of<T4>(options);
            types[4] = Of<T5>(options);
            types[5] = Of<T6>(options);
            types[6] = Of<T7>(options);
            types[7] = Of<T8>(options);
            types[8] = Of<T9>(options);

            return types;
        }

        /// <summary>
        /// Return the corresponding type according to the given generic parameter. <br />
        /// 根据给定的通用参数返回相应的类型。
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(TypeOfOptions options = TypeOfOptions.Owner)
        {
            var types = new Type[10];

            types[0] = Of<T1>(options);
            types[1] = Of<T2>(options);
            types[2] = Of<T3>(options);
            types[3] = Of<T4>(options);
            types[4] = Of<T5>(options);
            types[5] = Of<T6>(options);
            types[6] = Of<T7>(options);
            types[7] = Of<T8>(options);
            types[8] = Of<T9>(options);
            types[9] = Of<T10>(options);

            return types;
        }

        /// <summary>
        /// Return the corresponding type according to the given generic parameter. <br />
        /// 根据给定的通用参数返回相应的类型。
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(TypeOfOptions options = TypeOfOptions.Owner)
        {
            var types = new Type[11];

            types[0] = Of<T1>(options);
            types[1] = Of<T2>(options);
            types[2] = Of<T3>(options);
            types[3] = Of<T4>(options);
            types[4] = Of<T5>(options);
            types[5] = Of<T6>(options);
            types[6] = Of<T7>(options);
            types[7] = Of<T8>(options);
            types[8] = Of<T9>(options);
            types[9] = Of<T10>(options);
            types[10] = Of<T11>(options);

            return types;
        }

        /// <summary>
        /// Return the corresponding type according to the given generic parameter. <br />
        /// 根据给定的通用参数返回相应的类型。
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <typeparam name="T12"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(TypeOfOptions options = TypeOfOptions.Owner)
        {
            var types = new Type[12];

            types[0] = Of<T1>(options);
            types[1] = Of<T2>(options);
            types[2] = Of<T3>(options);
            types[3] = Of<T4>(options);
            types[4] = Of<T5>(options);
            types[5] = Of<T6>(options);
            types[6] = Of<T7>(options);
            types[7] = Of<T8>(options);
            types[8] = Of<T9>(options);
            types[9] = Of<T10>(options);
            types[10] = Of<T11>(options);
            types[11] = Of<T12>(options);

            return types;
        }

        /// <summary>
        /// Return the corresponding type according to the given generic parameter. <br />
        /// 根据给定的通用参数返回相应的类型。
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <typeparam name="T12"></typeparam>
        /// <typeparam name="T13"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(TypeOfOptions options = TypeOfOptions.Owner)
        {
            var types = new Type[13];

            types[0] = Of<T1>(options);
            types[1] = Of<T2>(options);
            types[2] = Of<T3>(options);
            types[3] = Of<T4>(options);
            types[4] = Of<T5>(options);
            types[5] = Of<T6>(options);
            types[6] = Of<T7>(options);
            types[7] = Of<T8>(options);
            types[8] = Of<T9>(options);
            types[9] = Of<T10>(options);
            types[10] = Of<T11>(options);
            types[11] = Of<T12>(options);
            types[12] = Of<T13>(options);

            return types;
        }

        /// <summary>
        /// Return the corresponding type according to the given generic parameter. <br />
        /// 根据给定的通用参数返回相应的类型。
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <typeparam name="T12"></typeparam>
        /// <typeparam name="T13"></typeparam>
        /// <typeparam name="T14"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(TypeOfOptions options = TypeOfOptions.Owner)
        {
            var types = new Type[14];

            types[0] = Of<T1>(options);
            types[1] = Of<T2>(options);
            types[2] = Of<T3>(options);
            types[3] = Of<T4>(options);
            types[4] = Of<T5>(options);
            types[5] = Of<T6>(options);
            types[6] = Of<T7>(options);
            types[7] = Of<T8>(options);
            types[8] = Of<T9>(options);
            types[9] = Of<T10>(options);
            types[10] = Of<T11>(options);
            types[11] = Of<T12>(options);
            types[12] = Of<T13>(options);
            types[13] = Of<T14>(options);

            return types;
        }

        /// <summary>
        /// Return the corresponding type according to the given generic parameter. <br />
        /// 根据给定的通用参数返回相应的类型。
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <typeparam name="T12"></typeparam>
        /// <typeparam name="T13"></typeparam>
        /// <typeparam name="T14"></typeparam>
        /// <typeparam name="T15"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(TypeOfOptions options = TypeOfOptions.Owner)
        {
            var types = new Type[15];

            types[0] = Of<T1>(options);
            types[1] = Of<T2>(options);
            types[2] = Of<T3>(options);
            types[3] = Of<T4>(options);
            types[4] = Of<T5>(options);
            types[5] = Of<T6>(options);
            types[6] = Of<T7>(options);
            types[7] = Of<T8>(options);
            types[8] = Of<T9>(options);
            types[9] = Of<T10>(options);
            types[10] = Of<T11>(options);
            types[11] = Of<T12>(options);
            types[12] = Of<T13>(options);
            types[13] = Of<T14>(options);
            types[14] = Of<T15>(options);

            return types;
        }

        /// <summary>
        /// Return the corresponding type according to the given generic parameter. <br />
        /// 根据给定的通用参数返回相应的类型。
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <typeparam name="T12"></typeparam>
        /// <typeparam name="T13"></typeparam>
        /// <typeparam name="T14"></typeparam>
        /// <typeparam name="T15"></typeparam>
        /// <typeparam name="T16"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> Of<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(TypeOfOptions options = TypeOfOptions.Owner)
        {
            var types = new Type[16];

            types[0] = Of<T1>(options);
            types[1] = Of<T2>(options);
            types[2] = Of<T3>(options);
            types[3] = Of<T4>(options);
            types[4] = Of<T5>(options);
            types[5] = Of<T6>(options);
            types[6] = Of<T7>(options);
            types[7] = Of<T8>(options);
            types[8] = Of<T9>(options);
            types[9] = Of<T10>(options);
            types[10] = Of<T11>(options);
            types[11] = Of<T12>(options);
            types[12] = Of<T13>(options);
            types[13] = Of<T14>(options);
            types[14] = Of<T15>(options);
            types[15] = Of<T16>(options);

            return types;
        }

        /// <summary>
        /// According to the given object, return its corresponding type. <br />
        /// 根据给定的对象，返回其对应的类型。
        /// </summary>
        /// <param name="objects">Object array</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Type[] Of(object[] objects, TypeOfOptions options = TypeOfOptions.Owner)
        {
            if (objects is null)
                return null;

            var nativeTypes = GetNativeTypeArray(objects);

            return options switch
            {
                TypeOfOptions.Owner => nativeTypes,
                TypeOfOptions.Underlying => nativeTypes.Select(TypeConv.GetNonNullableType).ToArray(),
                _ => nativeTypes
            };

            Type[] GetNativeTypeArray(object[] objectCollection)
            {
                // After the int? type is boxed, and then use GetType(), Nullable<int> will not be obtained.
                // More info
                //    https://github.com/dotnet/runtime/pull/42837
                
                //return objectCollection.Select(obj => obj?.GetType());
                if (objectCollection.Contains(null))
                    return objectCollection.Select(obj => obj?.GetType()).ToArray();
                return Type.GetTypeArray(objectCollection);
            }
        }
    }
}