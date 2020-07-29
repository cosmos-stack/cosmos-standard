using System.Collections.Generic;
using System.Linq;
using System.Text;
using AspectCore.Extensions.Reflection;
using Cosmos;
using Cosmos.Optionals;
using Cosmos.Reflection;

namespace System.Reflection
{
    /// <summary>
    /// Cosmos <see cref="Type"/> extensions
    /// </summary>
    public static partial class CosmosTypeExtensions
    {
        #region ToNonNullableType

        /// <summary>
        /// Get a non-nullable underlying version of a given <see cref="Type"/>.<br />
        /// 获取给定类型的非空版本。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type ToNonNullableType(this Type type) => type.SafeType();

        /// <summary>
        /// Get a non-nullable underlying version of a given <see cref="TypeInfo"/>.<br />
        /// 获取给定类型的非空版本。
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static TypeInfo ToNonNullableTypeInfo(this TypeInfo typeInfo) => typeInfo.SafeType();

        #endregion

        #region ToTypeInfo

        /// <summary>
        /// Get that's <see cref="TypeInfo"/><br />
        /// 获取给定对象的 <see cref="TypeInfo"/>。
        /// </summary>
        /// <param name="that"></param>
        /// <returns></returns>
        public static TypeInfo TypeInfo(this object that)
            => that.GetType().GetTypeInfo();

        /// <summary>
        /// Convert <see cref="Type"/> array to <see cref="TypeInfo"/> list.<br />
        /// 将给定的 <see cref="Type"/> 数组转换为 <see cref="TypeInfo"/> 列表。
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public static IEnumerable<TypeInfo> ToTypeInfo(this Type[] types)
            => types.Select(type => type.GetTypeInfo());

        #endregion

        #region Gets/Sets PropertyInfo

        /// <summary>
        /// Get all properties from the given Type.<br />
        /// 从给定的 Type 中获得所有属性。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="accessType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static IEnumerable<PropertyInfo> GetProperties(this Type type, PropertyAccessType accessType)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            return accessType switch
            {
                PropertyAccessType.Getters => type.GetPropertiesWithPublicInstanceGetters(),
                PropertyAccessType.Setters => type.GetPropertiesWithPublicInstanceSetters(),
                _ => throw new InvalidOperationException("Invalid operation for unknown access type")
            };
        }

        /// <summary>
        /// Get all properties from the given Type.<br />
        /// 从给定的 Type 中获得所有属性。
        /// </summary>
        /// <param name="accessType"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetProperties<T>(PropertyAccessType accessType) => typeof(T).GetProperties(accessType);

        private static IEnumerable<PropertyInfo> GetPropertiesWithPublicInstanceSetters(this Type type)
        {
            return type.GetRuntimeProperties().Where(p => p.SetMethod != null && !p.SetMethod.IsStatic && p.SetMethod.IsPublic);
        }

        private static IEnumerable<PropertyInfo> GetPropertiesWithPublicInstanceGetters(this Type type)
        {
            return type.GetRuntimeProperties().Where(p => p.GetMethod != null && !p.GetMethod.IsStatic && p.GetMethod.IsPublic);
        }

        #endregion

        #region Gets/Sets PropertyValue

        /// <summary>
        /// Get the value of the specified property name from the that.<br />
        /// 从对象中获取指定属性名称的值。
        /// </summary>
        /// <param name="that">Any <see cref="object"/></param>
        /// <param name="propertyName">Property name in this that</param>
        /// <returns>Value of the specific property in this that</returns>
        public static object GetPropertyValue(this object that, string propertyName)
            => that.TypeInfo().GetProperty(propertyName).GetReflector().GetValue(that);

        /// <summary>
        /// Get the value of the specified property name from the that.<br />
        /// 从对象中获取指定属性名称的值。
        /// </summary>
        /// <param name="that"></param>
        /// <param name="propertyName"></param>
        /// <param name="bindingAttr"></param>
        /// <returns></returns>
        public static object GetPropertyValue(this object that, string propertyName, BindingFlags bindingAttr)
            => that.TypeInfo().GetProperty(propertyName, bindingAttr).GetReflector().GetValue(that);

        /// <summary>
        /// Get the value of the specified property name from the that.<br />
        /// 从对象中获取指定属性名称的值。
        /// </summary>
        /// <param name="that">Any <see cref="object"/></param>
        /// <param name="propertyName">Property name in this that</param>
        /// <returns>Value of the specific property in this that</returns>
        public static T GetPropertyValue<T>(this object that, string propertyName)
            => that.TypeInfo().GetProperty(propertyName).GetReflector().GetValue(that).As<T>();

        /// <summary>
        /// Get the value of the specified property name from the that.<br />
        /// 从对象中获取指定属性名称的值。
        /// </summary>
        /// <param name="that"></param>
        /// <param name="propertyName"></param>
        /// <param name="bindingAttr"></param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this object that, string propertyName, BindingFlags bindingAttr)
            => that.TypeInfo().GetProperty(propertyName, bindingAttr).GetReflector().GetValue(that).As<T>();

        /// <summary>
        /// Try to get the value of the specified property name from the that.<br />
        /// 尝试从对象中获取指定属性名称的值。
        /// </summary>
        /// <param name="that">Any <see cref="object"/></param>
        /// <param name="propertyName">Property name in this that</param>
        /// <param name="value"></param>
        /// <returns>Value of the specific property in this that</returns>
        public static bool TryGetPropertyValue(this object that, string propertyName, out object value)
        {
            try
            {
                value = that.GetPropertyValue(propertyName);
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }

        /// <summary>
        /// Try to get the value of the specified property name from the that.<br />
        /// 尝试从对象中获取指定属性名称的值。
        /// </summary>
        /// <param name="that"></param>
        /// <param name="propertyName"></param>
        /// <param name="bindingAttr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool TryGetPropertyValue(this object that, string propertyName, BindingFlags bindingAttr, out object value)
        {
            try
            {
                value = that.GetPropertyValue(propertyName, bindingAttr);
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }

        /// <summary>
        /// Try to get the value of the specified property name from the that.<br />
        /// 尝试从对象中获取指定属性名称的值。
        /// </summary>
        /// <param name="that">Any <see cref="object"/></param>
        /// <param name="propertyName">Property name in this that</param>
        /// <param name="value"></param>
        /// <returns>Value of the specific property in this that</returns>
        public static bool TryGetPropertyValue<T>(this object that, string propertyName, out T value)
        {
            try
            {
                value = that.GetPropertyValue<T>(propertyName);
                return true;
            }
            catch
            {
                value = default;
                return false;
            }
        }

        /// <summary>
        /// Try to get the value of the specified property name from the that.<br />
        /// 尝试从对象中获取指定属性名称的值。
        /// </summary>
        /// <param name="that"></param>
        /// <param name="propertyName"></param>
        /// <param name="bindingAttr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool TryGetPropertyValue<T>(this object that, string propertyName, BindingFlags bindingAttr, out T value)
        {
            try
            {
                value = that.GetPropertyValue<T>(propertyName, bindingAttr);
                return true;
            }
            catch
            {
                value = default;
                return false;
            }
        }

        /// <summary>
        /// Set a value to the specified property name in the that.<br />
        /// 向对象中的指定属性名称设置值。
        /// </summary>
        /// <param name="that"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public static void SetPropertyValue(this object that, string propertyName, object value)
            => that.TypeInfo().GetProperty(propertyName).GetReflector().SetValue(that, value);

        /// <summary>
        /// Set a value to the specified property name in the that.<br />
        /// 向对象中的指定属性名称设置值。
        /// </summary>
        /// <param name="that"></param>
        /// <param name="propertyName"></param>
        /// <param name="bindingAttr"></param>
        /// <param name="value"></param>
        public static void SetPropertyValue(this object that, string propertyName, BindingFlags bindingAttr, object value)
            => that.TypeInfo().GetProperty(propertyName, bindingAttr).GetReflector().SetValue(that, value);

        /// <summary>
        /// Set a value to the specified property name in the that.<br />
        /// 向对象中的指定属性名称设置值。
        /// </summary>
        /// <param name="that"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public static void SetPropertyValue<T>(this object that, string propertyName, T value)
            => that.TypeInfo().GetProperty(propertyName).GetReflector().SetValue(that, value);

        /// <summary>
        /// Set a value to the specified property name in the that.<br />
        /// 向对象中的指定属性名称设置值。
        /// </summary>
        /// <param name="that"></param>
        /// <param name="propertyName"></param>
        /// <param name="bindingAttr"></param>
        /// <param name="value"></param>
        public static void SetPropertyValue<T>(this object that, string propertyName, BindingFlags bindingAttr, T value)
            => that.TypeInfo().GetProperty(propertyName, bindingAttr).GetReflector().SetValue(that, value);

        /// <summary>
        /// Try to set a value to the specified property name in the that.<br />
        /// 尝试向对象中的指定属性名称设置值。
        /// </summary>
        /// <param name="that"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public static bool TrySetPropertyValue(this object that, string propertyName, object value)
        {
            try
            {
                that.SetPropertyValue(propertyName, value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Try to set a value to the specified property name in the that.<br />
        /// 尝试向对象中的指定属性名称设置值。
        /// </summary>
        /// <param name="that"></param>
        /// <param name="propertyName"></param>
        /// <param name="bindingAttr"></param>
        /// <param name="value"></param>
        public static bool TrySetPropertyValue(this object that, string propertyName, BindingFlags bindingAttr, object value)
        {
            try
            {
                that.SetPropertyValue(propertyName, bindingAttr, value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Try to set a value to the specified property name in the that.<br />
        /// 尝试向对象中的指定属性名称设置值。
        /// </summary>
        /// <param name="that"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public static bool TrySetPropertyValue<T>(this object that, string propertyName, T value)
        {
            try
            {
                that.SetPropertyValue(propertyName, value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Try to set a value to the specified property name in the that.<br />
        /// 尝试向对象中的指定属性名称设置值。
        /// </summary>
        /// <param name="that"></param>
        /// <param name="propertyName"></param>
        /// <param name="bindingAttr"></param>
        /// <param name="value"></param>
        public static bool TrySetPropertyValue<T>(this object that, string propertyName, BindingFlags bindingAttr, T value)
        {
            try
            {
                that.SetPropertyValue(propertyName, bindingAttr, value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region FindGenericType

        private static readonly TypeInfo ObjectTypeInfo = TypeClass.ObjectClass.GetTypeInfo();

        /// <summary>
        /// Find <see cref="TypeInfo"/> from the given type's parameters' type
        /// </summary>
        /// <param name="definition"></param>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static TypeInfo FindGenericTypeInfo(this TypeInfo definition, TypeInfo typeInfo)
        {
            while (typeInfo != null && typeInfo != ObjectTypeInfo)
            {
                if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition().GetTypeInfo() == definition)
                    return typeInfo;

                if (definition.IsInterface)
                {
                    foreach (var type in typeInfo.GetInterfaces())
                    {
                        var __ = FindGenericTypeInfo(definition, type.GetTypeInfo());
                        if (__ != null)
                            return __;
                    }
                }

                typeInfo = typeInfo.BaseType?.GetTypeInfo();
            }

            return null;
        }

        /// <summary>
        /// Find <see cref="Type"/> from the given type's parameters' type<br />
        /// </summary>
        /// <param name="definition"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type FindGenericType(this Type definition, Type type)
            => (FindGenericTypeInfo(definition.GetTypeInfo(), type.GetTypeInfo()))?.AsType();

        #endregion

        #region GetFullyQualifiedName

        /// <summary>
        /// Get unique fully qualified name for <see cref="TypeInfo"/>.<br />
        /// 获取给定 <see cref="TypeInfo"/> 的完全限定名。
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static string GetFullyQualifiedName(this TypeInfo typeInfo)
        {
            var sb = new StringBuilder();
            if (typeInfo.IsGenericType)
            {
                sb.Append(typeInfo.GetGenericTypeDefinition().FullName)
                    .Append("[");

                var genericArgs = typeInfo.GetGenericArguments().ToTypeInfo().ToList();
                for (var i = 0; i < genericArgs.Count; i++)
                {
                    sb.Append(genericArgs[i].GetFullyQualifiedName());
                    if (i != genericArgs.Count - 1)
                        sb.Append(", ");
                }

                sb.Append("]");
            }
            else
            {
                if (!string.IsNullOrEmpty(typeInfo.FullName))
                    sb.Append(typeInfo.FullName);
                else if (!string.IsNullOrEmpty(typeInfo.Name))
                    sb.Append(typeInfo.Name);
                else
                    sb.Append(typeInfo);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Get unique fully qualified name for <see cref="TypeInfo"/>.<br />
        /// 获取给定 <see cref="TypeInfo"/> 的完全限定名。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetFullyQualifiedName(this Type type) => GetFullyQualifiedName(type.TypeInfo());

        #endregion

    }
}
