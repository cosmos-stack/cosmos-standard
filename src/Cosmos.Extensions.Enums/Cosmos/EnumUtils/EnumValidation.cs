using Cosmos.Validation.Annotations;

namespace Cosmos.EnumUtils;

/// <summary>
/// Enum validation strategy
/// </summary>
public enum EnumValidation
{
    /// <summary>
    /// Nop <br />
    /// 不做验证
    /// </summary>
    Nop = 0,

    /// <summary>
    /// <para>
    /// If the enum is a standard enum returns whether the value is defined. <br />
    /// 如果该枚举是标准枚举，则返回该值是否已定义。
    /// </para>
    /// <para>
    /// If the enum is marked with the <see cref="FlagsAttribute"/> it returns
    /// whether it's a valid flag combination of the enum's defined values or is defined. <br />
    /// 如果该枚举使用有 Flag 注解，则将返回它是枚举定义值的有效标志组合还是已定义。
    /// </para>
    /// <para>
    /// Or if the enum has an attribute that implements <see cref="IEnumVerifiableAnnotation{TEnum}"/>
    /// then that attribute's <see cref="IEnumVerifiableAnnotation{TEnum}.Verify(TEnum)"/> method is used.<br />
    /// 或者，如果枚举具有实现 <see cref="IEnumVerifiableAnnotation{TEnum}"/> 的属性，
    /// 则使用该属性的 <see cref="IEnumVerifiableAnnotation{TEnum}.Verify(TEnum)"/> 方法。
    /// </para>
    /// </summary>
    Default = 1,

    /// <summary>
    /// Returns if the value is defined. <br />
    /// 当给定值被定义了才返回
    /// </summary>
    IsDefined = 2,

    /// <summary>
    /// Returns if the value is a valid flag combination of the enum's defined values. <br />
    /// 返回该值是否是枚举定义值的有效标志组合。
    /// </summary>
    IsValidFlagCombination = 3,
}