using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace EnumGetDescriptionsApp.Classes;
public static class EnumHelper
{
    /// <summary>
    /// Create a <see cref="KeyValuePair"/> where Key is the description, Value the enum value
    /// </summary>
    /// <typeparam name="T">enum to work with</typeparam>
    public static List<KeyValuePair<string, Enum>> GetItemsAsDictionary<T>() =>
        Enum.GetValues(typeof(T)).Cast<T>()
            .Cast<Enum>()
            .Select(value => new KeyValuePair<string, Enum>(
                (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString())!,
                    typeof(DescriptionAttribute)) as DescriptionAttribute)!.Description, value))
            .ToList();

    public static string GetDisplayName(this Enum enumValue) 
    {
        return enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()!
            .GetName();
    }
}
