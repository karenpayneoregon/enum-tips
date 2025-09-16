using System.ComponentModel;
using EnumGetDescriptions.Models;

namespace EnumGetDescriptions.Classes;

public static class EnumHelper
{
    /// <summary>
    /// Create a <see cref="KeyValuePair"/> where Key is the description,
    /// Value the enum value
    /// </summary>
    /// <typeparam name="T">enum to work with</typeparam>
    public static List<KeyValuePair<string, Enum>> GetItemsAsDictionary<T>() =>
        Enum.GetValues(typeof(T)).Cast<T>()
            .Cast<Enum>()
            .Select(value => new KeyValuePair<string, Enum>(
                (Attribute.GetCustomAttribute(value.GetType()
                        .GetField(value.ToString())!,
                    typeof(DescriptionAttribute)) as DescriptionAttribute)
                !.Description, value))
            .ToList();


    /// <summary>
    /// Converts an enumeration of type <typeparamref name="T"/> into a list of 
    /// <see cref="BookContainer"/> objects, where each container associates an 
    /// enumeration value with its description.
    /// </summary>
    /// <typeparam name="T">
    /// The enumeration type to process. Must be an enum.
    /// </typeparam>
    /// <returns>
    /// A list of <see cref="BookContainer"/> objects, each containing an enumeration 
    /// value and its corresponding description.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown if <typeparamref name="T"/> is not an enumeration type.
    /// </exception>
    public static List<BookContainer> Container<T>()
    {
        List<KeyValuePair<string, Enum>> kvp = GetItemsAsDictionary<T>();
        return kvp.Select(category 
            => new BookContainer() { Name = category.Value, Description = category.Key })
            .ToList();
    }
}

