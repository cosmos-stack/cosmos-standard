using System;
using System.Reflection;
using Cosmos.Conversions.StringDeterminers;

namespace Cosmos {
    /// <summary>
    /// Enum Utilities
    /// </summary>
    public static class Enums {

        /// <summary>
        /// Of
        /// </summary>
        /// <param name="member"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T Of<T>(string member, bool ignoreCase = false, T defaultVal = default) where T : struct, Enum =>
            StringEnumDeterminer<T>.To(member, ignoreCase, defaultVal);

        /// <summary>
        /// Of
        /// </summary>
        /// <param name="member"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T Of<T>(object member) where T : struct, Enum =>
            Of<T>(Conversions.ObjectConverter.ToString(member));

        /// <summary>
        /// Of
        /// </summary>
        /// <param name="member"></param>
        /// <param name="enumType"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static object Of(string member, Type enumType, bool ignoreCase = false, object defaultVal = default) =>
            StringEnumDeterminer.To(member, enumType, ignoreCase, defaultVal);

        /// <summary>
        /// Of
        /// </summary>
        /// <param name="member"></param>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static object Of(object member, Type enumType) =>
            Of(Conversions.ObjectConverter.ToString(member), enumType);

        /// <summary>
        /// Get name of member <br />
        /// 获取成员名
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="member">
        /// 成员名、值、实例均可,
        /// 范例:Enum1枚举有成员A=0,则传入Enum1.A或0,获取成员名"A"
        /// </param>
        public static string NameOf<T>(object member) =>
            NameOf(Types.Of<T>(), member);

        /// <summary>
        /// Get name of member <br />
        /// 获取成员名
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        public static string NameOf(Type type, object member) =>
            NameOf(type.GetTypeInfo(), member);

        /// <summary>
        /// Get name of member <br />
        /// 获取成员名
        /// </summary>
        /// <param name="typeinfo">枚举类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        /// <returns></returns>
        public static string NameOf(TypeInfo typeinfo, object member) {
            if (typeinfo is null) return string.Empty;
            if (member is null) return string.Empty;
            if (member is string) return member.ToString();
            return !typeinfo.IsEnum ? string.Empty : Enum.GetName(typeinfo.AsType(), member);
        }

        /// <summary>
        /// Get value of member <br />
        /// 获取成员值
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="member">
        /// 成员名、值、实例均可，
        /// 范例:Enum1枚举有成员A=0,可传入"A"、0、Enum1.A，获取值0
        /// </param>
        public static int ValueOf<T>(object member) => ValueOf(Types.Of<T>(), member);

        /// <summary>
        /// Get value of member <br />
        /// 获取成员值
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        public static int ValueOf(Type type, object member) {
            var value = Conversions.ObjectConverter.ToString(member);
            if (string.IsNullOrWhiteSpace(value)) {
                throw new ArgumentNullException(nameof(member));
            }

            return (int) Enum.Parse(type, member.ToString(), true);
        }


        /// <summary>
        /// Get description via <see cref="System.ComponentModel.DescriptionAttribute"/> <br />
        /// 获取描述，使用 <see cref="System.ComponentModel.DescriptionAttribute"/> 特性设置描述
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="member">成员名、值、实例均可</param>
        public static string GetDescription<T>(object member) =>
            Reflections.GetDescription<T>(NameOf<T>(member));

        /// <summary>
        /// Get description via <see cref="System.ComponentModel.DescriptionAttribute"/> <br />
        /// 获取描述，使用 <see cref="System.ComponentModel.DescriptionAttribute"/> 特性设置描述
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        public static string GetDescription(Type type, object member) =>
            Reflections.GetDescription(type, NameOf(type, member));

        /// <summary>
        /// Get description via <see cref="System.ComponentModel.DescriptionAttribute"/> <br />
        /// 获取描述，使用 <see cref="System.ComponentModel.DescriptionAttribute"/> 特性设置描述
        /// </summary>
        /// <param name="typeInfo">枚举类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        public static string GetDescription(TypeInfo typeInfo, object member) =>
            Reflections.GetDescription(typeInfo, NameOf(typeInfo, member));
    }
}