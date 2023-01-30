using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace KP_ConsoleAppNet71;
internal class Helpers
{
    public static string GetDisplayName(Enum value)
    {
        var memberInfo = value.GetType()
            .GetMember(value.ToString())
            .FirstOrDefault();

        var attribute = memberInfo!.GetCustomAttribute<DisplayAttribute>();
        return attribute is not null ? attribute.GetName() : "";
    }
}
