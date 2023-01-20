# Example for using enum in EF Core 

Starting with Entity Framework Core 2.1, EF supports [Value Conversions](https://learn.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations). To store the enum values as strings such as "Red", "White", etc. (below this refers to wine types) in the database; you simply need to provide one function which converts from the ModelClrType to the ProviderClrType, and another for the opposite conversion:

:pushpin: Main Model: Wine

```csharp
public class Wine
{
    public int WineId { get; set; }
    public string Name { get; set; }
    public WineType WineType { get; set; }
    public override string ToString() => $"{WineType} {Name}";
}
```


:pushpin: Our enum for types of Wine

```csharp
public enum WineType : int
{
    Red = 0,
    White = 1,
    Rose = 2
}
```

:pushpin: Setup conversion in the DbContext, `WineType` to `int`

```csharp
public class WineContext : DbContext
{
    public DbSet<Wine> Wines { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString())
            .LogTo(message => 
                Debug.WriteLine(message), 
                LogLevel.Information);
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Wine>()
            .Property(e => e.WineType)
            .HasConversion<int>();
    }
}
```

:pushpin: Querying for a specific wine category

```csharp
List<Wine> rose = context.Wines.Where(x => x.WineType == WineType.Rose).ToList();
```

## Storing enums in a database

Why store our enums in a database? So if an enum member name changes, added or removed they are kept up to date on a build of the project using a T4 template.

In this case, for wine types

![Winetypes](assets/winetypes.png)

Using Models.WineType.tt our WineType enum is generated from reading the database table WineTypes.

## Working with T4 templates in Visual Studio

- Currently there is no syntax coloration so install an extension such as [T4 Language](https://marketplace.visualstudio.com/items?itemName=bricelam.T4Language)
- Make a mistake in writing code in these templates will not be known until it's finished building so be careful.


## See also

[EF Core Value Conversions](https://github.com/karenpayneoregon/ef-core-transforming)
