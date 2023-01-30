using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EnumGetDescriptionsApp.Classes;
internal class Helpers
{
    public static string GetDisplayName(Enum value)
    {
        var memberInfo = value.GetType()
            .GetMember(value.ToString())
            .FirstOrDefault();

        DisplayAttribute attribute = memberInfo!.GetCustomAttribute<DisplayAttribute>();
        return attribute is not null ? attribute.GetName() : "";
    }
}
