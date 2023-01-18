# About

Shows how to create a list from an enum and also how to exclude a member.

:pushpin: All members into a list

```csharp
List<BookCategories> all = Enum.GetValues(typeof(BookCategories))
    .Cast<BookCategories>()
    .ToList();
```

:pushpin: Discard a member

```csharp
List<BookCategories> noSelect = Enum.GetValues(typeof(BookCategories))
    .Cast<BookCategories>()
    .Where(x => x != BookCategories.Select)
    .ToList();
```

:pushpin: Sorted list of strings

```csharp
List<string> list = EnumToList(typeof(BookCategories)).OrderBy(x => x).ToList();
```


:pushpin: Get int value for each member

```csharp
foreach (var value in Enum.GetValues(typeof(BookCategories)).Cast<int>().ToList())
{
    Console.WriteLine(value);
}
```