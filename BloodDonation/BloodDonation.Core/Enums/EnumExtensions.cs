using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BloodDonation.Core.Enums;
public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        var enumType = enumValue.GetType();
        var member = enumType.GetMember(enumValue.ToString())[0];
        var attribute = member.GetCustomAttribute<DisplayAttribute>();

        return attribute?.Name ?? enumValue.ToString();
    }
}
