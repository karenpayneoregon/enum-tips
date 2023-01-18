# About

Provides a method to get enum members descriptions


```csharp
public class EnumHelper
{
    public static List<KeyValuePair<string, Enum>> GetItemsAsDictionary<T>() =>
        Enum.GetValues(typeof(T)).Cast<T>()
            .Cast<Enum>()
            .Select(value => new KeyValuePair<string, Enum>(
                (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString())!,
                    typeof(DescriptionAttribute)) as DescriptionAttribute)!.Description, value))
            .ToList();

}
```

:pushpin: Example

```csharp
List<KeyValuePair<string, Enum>> result = EnumHelper.GetItemsAsDictionary<BookCategories>();

foreach (var item in result)
{
    Console.WriteLine($"{item.Value,-20} {item.Key}");
}
```