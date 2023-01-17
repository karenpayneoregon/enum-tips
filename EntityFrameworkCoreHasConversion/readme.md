# Example for using enum in EF Core 

Main Model, Wine

```csharp
public class Wine
{
    public int WineId { get; set; }
    public string Name { get; set; }
    public WineType WineType { get; set; }
    public override string ToString() => $"{WineType} {Name}";
}
```


Our enum for types of Wine

```csharp
public enum WineType : int
{
    Red = 0,
    White = 1,
    Rose = 2
}
```


```csharp

```