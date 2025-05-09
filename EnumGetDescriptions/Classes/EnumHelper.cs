﻿using System.ComponentModel;
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


    public static List<BookContainer> Container<T>()
    {
        List<KeyValuePair<string, Enum>> kvp = GetItemsAsDictionary<T>();
        return kvp.Select(category 
            => new BookContainer() { Name = category.Value, Description = category.Key })
            .ToList();
    }
}

