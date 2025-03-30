namespace EnumGeneralApp.Classes;

public static class EnumUtils
{
    /// <summary>
    /// Parses the specified string value into an enumeration value of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">
    /// The enumeration type to which the string value should be parsed. Must be a valid <see cref="System.Enum"/> type.
    /// </typeparam>
    /// <param name="value">
    /// The string representation of the enumeration value to parse. This parameter is case-insensitive.
    /// </param>
    /// <param name="defaultValue">
    /// The default value to return if the parsing fails or if the input string is null or empty.
    /// </param>
    /// <returns>
    /// The parsed enumeration value of type <typeparamref name="T"/> if the parsing is successful; otherwise, the specified <paramref name="defaultValue"/>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if the specified type <typeparamref name="T"/> is not an enumeration.
    /// </exception>
    public static T ParseEnum<T>(string value, T defaultValue) where T : struct, IConvertible
    {
        if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");
        if (string.IsNullOrEmpty(value)) return defaultValue;

        foreach (T item in Enum.GetValues(typeof(T)))
        {
            if (item.ToString()!.ToLower().Equals(value.Trim().ToLower()))
            {
                return item;
            }
        }
        return defaultValue;
    }

    public static Dictionary<int, string> ToDictionary<T>() where T : Enum
        => Enum.GetValues(typeof(T)).Cast<int>()
            .ToDictionary(item => item, item => Enum.GetName(typeof(T), item));

    //public static Dictionary<int, string> ToDictionary<TEnum>(this TEnum _) where TEnum : Enum
    //{
    //    return Enum.GetValues(typeof(TEnum))
    //        .Cast<int>()
    //        .ToDictionary(item => item, item => Enum.GetName(typeof(TEnum), item));
    //}
}