using System.ComponentModel;
#if !NETCOREAPP3_1
using System.ComponentModel.DataAnnotations;
#endif

// ReSharper disable InconsistentNaming
namespace Cosmos.Conversions.Common.Core;

internal static partial class XConv
{
    private static bool FromEnumToString(Type enumType, object enumVal, string defaultStr, out object result)
    {
        var attributeName = string.Empty;
        var attributes = EnumsNET.Enums.GetAttributes(enumType, enumVal);
        if (attributes != null)
        {
            if (attributes.Has<DescriptionAttribute>())
            {
                attributeName = attributes.Get<DescriptionAttribute>()?.Description ?? string.Empty;
            }
            else if (attributes.Has<DisplayNameAttribute>())
            {
                attributeName = attributes.Get<DisplayNameAttribute>()?.DisplayName ?? string.Empty;
            }
#if !NETCOREAPP3_1
            else if (attributes.Has<System.ComponentModel.DataAnnotations.DisplayAttribute>())
            {
                var attribute = attributes.Get<DisplayAttribute>();
                attributeName = attribute?.GetDescription() ?? attribute?.GetName();
            }
#endif
        }

        if (string.IsNullOrWhiteSpace(attributeName))
        {
            attributeName = EnumsNET.Enums.GetMember(enumType, enumVal)?.Name ?? defaultStr;
        }

        result = attributeName;
        return true;
    }
}